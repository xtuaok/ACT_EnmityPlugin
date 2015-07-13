using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Advanced_Combat_Tracker;
using System.Reflection;

namespace Tamagawa.EnmityPlugin
{

    public static class FFXIVProcessHelper
    {
        public static IList<Process> GetFFXIVProcessList()
        {
            return (
                from x in Process.GetProcessesByName("ffxiv")
                where !x.HasExited && x.MainModule != null && x.MainModule.ModuleName == "ffxiv.exe"
                select x).Union(
                from x in Process.GetProcessesByName("ffxiv_dx11")
                where !x.HasExited && x.MainModule != null && x.MainModule.ModuleName == "ffxiv_dx11.exe"
                select x).ToList<Process>();
        }

        public static Process GetFFXIVProcess(int pid = 0)
        {
            Process result;
            try
            {
                IList<Process> list = GetFFXIVProcessList();
                if (pid == 0)
                {
                    if (list.Any<Process>())
                    {
                        result = (
                            from x in list
                            orderby x.Id
                            select x).FirstOrDefault<Process>();
                    }
                    else
                    {
                        result = null;
                    }
                }
                else
                {
                    result = list.FirstOrDefault((Process x) => x.Id == pid);
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }
    }

    public static class FFXIVPluginHelper
     {
        private static ActPluginData _plugin;

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
     }
}

