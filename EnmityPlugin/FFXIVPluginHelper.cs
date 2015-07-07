using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using Advanced_Combat_Tracker;
using System.Runtime.InteropServices;


namespace Tamagawa.EnmityPlugin
{
    public static class FFXIVPluginHelper
    {
        private static Regex regVersion = new Regex(@"FileVersion: (?<version>\d+\.\d+\.\d+\.\d+)\n", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static ActPluginData _plugin = null;

        public static object Instance
        {
            get
            {
                if (_plugin == null && ActGlobals.oFormActMain.Visible)
                {
                    foreach (ActPluginData plugin in ActGlobals.oFormActMain.ActPlugins)
                    {
                        if (plugin.pluginFile.Name == "FFXIV_ACT_Plugin.dll" && plugin.lblPluginStatus.Text == "FFXIV Plugin Started.")
                        {
                            _plugin = plugin;
                            break;
                        }
                    }
                }
                return _plugin;
            }
        }

        public enum FFXIVClientMode
        {
            Unknown = 0,
            FFXIV_32 = 1,
            FFXIV_64 = 2,
        }

        public static Version GetVersion
        {
            get
            {
                if (_plugin != null)
                {
                    return new Version(regVersion.Match(_plugin.pluginVersion).Groups["version"].ToString());
                }
                return null;
            }
        }

        public static Process GetFFXIVProcess
        {
            get
            {
                try
                {
                    FieldInfo fi = _plugin.pluginObj.GetType().GetField("_Memory", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var memory = fi.GetValue(_plugin.pluginObj);
                    if (memory == null) return null;

                    fi = memory.GetType().GetField("_config", BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance);
                    var config = fi.GetValue(memory);
                    if (config == null) return null;

                    fi = config.GetType().GetField("Process", BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance);
                    var process = fi.GetValue(config);
                    if (process == null) return null;

                    return (Process)process;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static FFXIVClientMode GetFFXIVClientMode
        {
            get
            {
                Process p = GetFFXIVProcess;
                if (p != null)
                {
                    if (p.ProcessName == "ffxiv")
                    {
                        return FFXIVClientMode.FFXIV_32;
                    }
                    else if (p.ProcessName == "ffxiv_dx11")
                    {
                        return FFXIVClientMode.FFXIV_64;
                    }
                }
                return FFXIVClientMode.Unknown;
            }
        }

        public static List<Combatant> GetCombatantList(IntPtr charmapAddress)
        {
            FFXIVClientMode mode = GetFFXIVClientMode;
            int num = 344;
            List<Combatant> result = new List<Combatant>();

            int sz = (mode == FFXIVClientMode.FFXIV_64) ? 8 : 4;
            byte[] source = GetByteArray(charmapAddress, sz * num);
            if (source == null || source.Length == 0) { return result; }
            unsafe
            {
                for (int i = 0; i < num; i++)
                {
                    IntPtr p;
                    if (mode == FFXIVClientMode.FFXIV_64)
                    {
                        fixed (byte* bp = source) p = new IntPtr(*(Int64*)&bp[i * sz]);
                    }
                    else
                    {
                        fixed (byte* bp = source) p = new IntPtr(*(Int32*)&bp[i * sz]);
                    }

                    if (!(p == IntPtr.Zero))
                    {
                        byte[] c = GetByteArray(p, 0x3F40);
                        Combatant combatant = GetCombatantFromByteArray(c);
                        if (combatant.type != TargetType.PC && combatant.type != TargetType.Monster)
                        {
                            continue;
                        }
                        if (combatant.ID != 0 && combatant.ID != 3758096384u && !result.Exists((Combatant x) => x.ID == combatant.ID))
                        {
                            result.Add(combatant);
                        }
                    }
                }
            }
            return result;
        }

        public unsafe static Combatant GetCombatantFromByteArray(byte[] source)
        {
            int offset = 0;
            Combatant combatant = new Combatant();
            fixed (byte* p = source)
            {
                combatant.Name    = FFXIVPluginHelper.GetStringFromBytes(source, 48);
                combatant.ID      = *(uint*)&p[0x74];
                combatant.OwnerID = *(uint*)&p[0x84];
                if (combatant.OwnerID == 3758096384u)
                {
                    combatant.OwnerID = 0u;
                }
                combatant.type = (TargetType)p[0x8A];
                combatant.EffectiveDistance = p[0x91];

                offset = (GetFFXIVClientMode == FFXIVClientMode.FFXIV_64) ? 176 : 160;
                combatant.PosX = *(Single*)&p[offset];
                combatant.PosZ = *(Single*)&p[offset + 4];
                combatant.PosY = *(Single*)&p[offset + 8];

                if (combatant.type == TargetType.PC || combatant.type == TargetType.Monster)
                {
                    offset = (GetFFXIVClientMode == FFXIVClientMode.FFXIV_64) ? 5872 : 5312;
                    combatant.Job       = p[offset];
                    combatant.Level     = p[offset + 1];
                    combatant.CurrentHP = *(int*)&p[offset + 8];
                    combatant.MaxHP     = *(int*)&p[offset + 12];
                    combatant.CurrentMP = *(int*)&p[offset + 16];
                    combatant.MaxMP     = *(int*)&p[offset + 20];
                    combatant.CurrentTP = *(short*)&p[offset + 24];
                    combatant.MaxTP     = 1000;
                }
                else
                {
                    combatant.CurrentHP =
                    combatant.MaxHP     =
                    combatant.CurrentMP =
                    combatant.MaxMP     =
                    combatant.MaxTP     =
                    combatant.CurrentTP = 0;
                }
            }
            return combatant;
        }

        private static bool Peek(IntPtr address, byte[] buffer)
        {
            Process process = GetFFXIVProcess;
            IntPtr zero = IntPtr.Zero;
            IntPtr nSize = new IntPtr(buffer.Length);
            return NativeMethods.ReadProcessMemory(process.Handle, address, buffer, nSize, ref zero);
        }

        public static string GetStringFromBytes(byte[] source, int offset = 0, int size = 256)
        {
            var bytes = new byte[size];
            Array.Copy(source, offset, bytes, 0, size);
            var realSize = 0;
            for (var i = 0; i < size; i++)
            {
                if (bytes[i] != 0)
                {
                    continue;
                }
                realSize = i;
                break;
            }
            Array.Resize(ref bytes, realSize);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static byte[] GetByteArray(IntPtr address, int length)
        {
            var data = new byte[length];
            Peek(address, data);
            return data;
        }

        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public unsafe static int GetInt32(IntPtr address, int offset = 0)
        {
            int ret;
            var value = new byte[4];
            Peek(IntPtr.Add(address,  offset), value);
            fixed (byte* p = &value[0]) ret = *(int*)p;
            return ret;
        }

        /// <summary>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public unsafe static uint GetUInt32(IntPtr address, int offset = 0)
        {
            uint ret;
            var value = new byte[4];
            Peek(IntPtr.Add(address, offset), value);
            fixed (byte* p = &value[0]) ret = *(uint*)p;
            return ret;
        }

        //
        // Signature Sscan
        // 
        public static List<IntPtr> SigScan(string pattern, int offset = 0, bool bRIP = false)
        {
            IntPtr arg_05_0 = IntPtr.Zero;
            if (pattern == null || pattern.Length % 2 != 0)
            {
                return new List<IntPtr>();
            }

            byte?[] array = new byte?[pattern.Length / 2];
            for (int i = 0; i < pattern.Length / 2; i++)
            {
                string text = pattern.Substring(i * 2, 2);
                if (text == "??")
                {
                    array[i] = null;
                }
                else
                {
                    array[i] = new byte?(Convert.ToByte(text, 16));
                }
            }

            int num = 4096;
            Process process = GetFFXIVProcess;

            int moduleMemorySize = process.MainModule.ModuleMemorySize;
            IntPtr baseAddress = process.MainModule.BaseAddress;
            IntPtr intPtr = IntPtr.Add(baseAddress, moduleMemorySize);
            IntPtr intPtr2 = baseAddress;
            byte[] array2 = new byte[num];
            List<IntPtr> list = new List<IntPtr>();
            while (intPtr2.ToInt64() < intPtr.ToInt64())
            {
                IntPtr zero = IntPtr.Zero;
                IntPtr nSize = new IntPtr(num);
                if (IntPtr.Add(intPtr2, num).ToInt64() > intPtr.ToInt64())
                {
                    nSize = (IntPtr)(intPtr.ToInt64() - intPtr2.ToInt64());
                }
                if (NativeMethods.ReadProcessMemory(process.Handle, intPtr2, array2, nSize, ref zero))
                {
                    int num2 = 0;
                    while ((long)num2 < zero.ToInt64() - (long)array.Length - (long)offset - 4L + 1L)
                    {
                        int num3 = 0;
                        for (int j = 0; j < array.Length; j++)
                        {
                            if (!array[j].HasValue)
                            {
                                num3++;
                            }
                            else
                            {
                                if (array[j].Value != array2[num2 + j])
                                {
                                    break;
                                }
                                num3++;
                            }
                        }
                        if (num3 == array.Length)
                        {
                            IntPtr item;
                            if (bRIP)
                            {
                                item = new IntPtr(BitConverter.ToInt32(array2, num2 + array.Length + offset));
                                item = new IntPtr(intPtr2.ToInt64() + (long)num2 + (long)array.Length + 4L + item.ToInt64());
                            }
                            else if (GetFFXIVClientMode == FFXIVPluginHelper.FFXIVClientMode.FFXIV_64)
                            {
                                item = new IntPtr(BitConverter.ToInt64(array2, num2 + array.Length + offset));
                                item = new IntPtr(item.ToInt64());
                            }
                            else
                            {
                                item = new IntPtr(BitConverter.ToInt32(array2, num2 + array.Length + offset));
                                item = new IntPtr(item.ToInt64());
                            }
                            list.Add(item);
                        }
                        num2++;
                    }
                }
                intPtr2 = IntPtr.Add(intPtr2, num);
            }
            return list;
        }
    }

    public enum TargetType : byte
    {
        Unknown   = 0x00,
        PC        = 0x01,
        Monster   = 0x02,
        NPC       = 0x03,
        Aetheryte = 0x05,
        Gathering = 0x06,
        Minion    = 0x09
    }

    public class Combatant
    {
        public uint ID;
        public uint OwnerID;
        public int Order;
        public TargetType type;
        public byte Job;
        public byte Level;
        public string Name;

        public int CurrentHP;
        public int MaxHP;
        public int CurrentMP;
        public int MaxMP;
        public short MaxTP;
        public short CurrentTP;

        public Single PosX;
        public Single PosY;
        public Single PosZ;
        public byte EffectiveDistance;
        public string Distance;
        public string HorizontalDistance;

        public string HPPercent
        {
            get
            {
                try
                {
                    if (MaxHP == 0) return "0.00";
                    return (Convert.ToDouble(CurrentHP) / Convert.ToDouble(MaxHP) * 100).ToString("0.00");
                }
                catch
                {
                    return "0.00";
                }
            }
        }

        public float GetDistanceTo(Combatant target)
        {
            var distanceX = (float)Math.Abs(PosX - target.PosX);
            var distanceY = (float)Math.Abs(PosY - target.PosY);
            var distanceZ = (float)Math.Abs(PosZ - target.PosZ);
            return (float)Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY) + (distanceZ * distanceZ));
        }

        public float GetHorizontalDistanceTo(Combatant target)
        {
            var distanceX = (float)Math.Abs(PosX - target.PosX);
            var distanceY = (float)Math.Abs(PosY - target.PosY);
            return (float)Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY));
        }
    }
}
