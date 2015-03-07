using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using RainbowMage.OverlayPlugin;

namespace Tamagawa.EnmityPlugin
{
    class EnmityOverlay : OverlayBase<EnmityOverlayConfig>
    {
        private static string charmapSignature = "FFFFFFFF????????DB0FC93FDB0F49416F12833A00000000????????DB0FC93FDB0F49416F12833A00000000";
        private static int charmapOffset = 44;
        private static string targetSignature = "403F00000000000000000000000000000000????0000????000000000000??000000????????DB0FC93FDB0F49416F12833A";
        private static int targetOffset = 218;
        private static int pid = 0;
        private IntPtr charmapAddress = IntPtr.Zero;
        private IntPtr targetAddress = IntPtr.Zero;
        private IntPtr hateAddress = IntPtr.Zero;
        private bool suppress_log = false;

        public EnmityOverlay(EnmityOverlayConfig config) : base(config, "EnmityOverlay")
        {            
            /// FIXME: 継承するとなぜかOnLogできないので追加する
            this.Overlay.Renderer.BrowserError += (o, e) =>
            {
                Log(LogLevel.Error, "BrowserError: {0}, {1}, {2}", e.ErrorCode, e.ErrorText, e.Url);
            };
            this.Overlay.Renderer.BrowserLoad += (o, e) =>
            {
                Log(LogLevel.Debug, "BrowserLoad: {0}: {1}", e.HttpStatusCode, e.Url);
            };
            this.Overlay.Renderer.BrowserConsoleLog += (o, e) =>
            {
                Log(LogLevel.Info, "BrowserConsole: {0} (Source: {1}, Line: {2})", e.Message, e.Source, e.Line);
            };
        }

        /// <summary>
        /// プロセスの変更をチェック
        /// </summary>
        private void checkProcessId()
        {
            try
            {
                if (FFXIVPluginHelper.Instance != null)
                {
                    if (pid != FFXIVPluginHelper.GetFFXIVProcess.Id)
                    {
                        pid = FFXIVPluginHelper.GetFFXIVProcess.Id;
                        if (pid != 0)
                        {
                            getPointerAddress();
                            // スキャン間隔をもどす
                            timer.Interval = this.Config.ScanInterval;
                            suppress_log = false;
                        }
                    }
                }
            }
            catch
            {
                pid = 0;
            }
        }

        /// <summary>
        /// 各ポインタのアドレスを取得 (基本的に一回でいい)
        /// </summary>
        private void getPointerAddress()
        {
            /// CHARMAP
            List<IntPtr> list = FFXIVPluginHelper.SigScan(charmapSignature, charmapOffset);
            if (list == null || list.Count == 0)
            {
                charmapAddress = IntPtr.Zero;
            }
            if (list.Count == 1)
            {
                charmapAddress = list[0];
                hateAddress = charmapAddress - 120664; // patch >= 2.51
            }

            /// TARGET
            list = FFXIVPluginHelper.SigScan(targetSignature, targetOffset);
            if (list == null || list.Count == 0)
            {
                targetAddress = IntPtr.Zero;
            }
            if (list.Count == 1)
            {
                targetAddress = list[0];
            }
            Log(LogLevel.Debug, "Charmap Address: 0x{0:X}, HateStructure: 0x{1:X}", (int)charmapAddress, (int)hateAddress);
            Log(LogLevel.Debug, "Target Address: 0x{0:X}", (int)targetAddress);
        }

        //public override void Navigate(string url)
        //{
        //    base.Navigate(url);
        //}

        protected override void Update()
        {
            try
            {
                checkProcessId(); // プロセスチェック
                if (pid == 0)
                {
                    if (suppress_log == false)
                    {
                        Log(LogLevel.Warning, Messages.ProcessNotFound);
                        suppress_log = true;
                    }
                    // スキャン間隔を一旦遅くする
                    timer.Interval = 3000;
                    // return; 一応表示するので戻らない
                }

                var updateScript = CreateEventDispatcherScript();

                if (this.Overlay != null &&
                    this.Overlay.Renderer != null &&
                    this.Overlay.Renderer.Browser != null)
                {
                    this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
                }
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Update: {1}", this.Name, ex);
            }
        }

        /// <summary>
        /// データを取得し、JSONを作る
        /// </summary>
        /// <returns></returns>
        internal string CreateJsonData()
        {
            /// シリアライザ
            var serializer = new JavaScriptSerializer();
            /// Overlay に渡すオブジェクト
            EnmityObject enmity = new EnmityObject();
            enmity.Entries = new List<EnmityEntry>();

            uint currentTarget;
            uint currentTargetID;

            //// なんかプロセスがおかしいとき
            if (pid == 0)
            {
                enmity.Target = new TargetInfo{
                    Name = "FFXIV process is not available.",
                    ID = 0,
                    MaxHP = 0,
                    CurrentHP = 0,
                    Distance = "0.00m",
                    EffectiveDistance = 0,
                    HorizontalDistance = "0.00m"

                };
                return serializer.Serialize(enmity);
            }

            var targetInfoSource = FFXIVPluginHelper.GetByteArray((uint)targetAddress.ToInt64(), 128);
            unsafe
            {
                fixed (byte* p = &targetInfoSource[0x0]) currentTarget = *(uint*)p;
                fixed (byte* p = &targetInfoSource[0x5C]) currentTargetID = *(uint*)p;
            }
            /// なにもターゲットしてない
            if (currentTarget <= 0)
            {
                enmity.Target = new TargetInfo
                {
                    Name = "No target",
                    ID = 0,
                    MaxHP = 0,
                    CurrentHP = 0,
                    Distance = "0.00m",
                    EffectiveDistance = 0,
                    HorizontalDistance = "0.00m"
                };
                return serializer.Serialize(enmity);
            }

            try
            {
                /// 自キャラ
                var address = FFXIVPluginHelper.GetUInt32((uint)charmapAddress.ToInt64());
                var source =  FFXIVPluginHelper.GetByteArray(address, 0x3F40);
                TargetInfo mypc = FFXIVPluginHelper.GetTargetInfoFromByteArray(source);

                /// カレントターゲット
                source = FFXIVPluginHelper.GetByteArray(currentTarget, 0x3F40);
                enmity.Target = FFXIVPluginHelper.GetTargetInfoFromByteArray(source);

                /// 距離計算
                enmity.Target.Distance = String.Format("{0,5:F2}m", mypc.GetDistanceTo(enmity.Target));
                enmity.Target.HorizontalDistance = String.Format("{0,5:F2}m", mypc.GetHorizontalDistanceTo(enmity.Target));

                if (enmity.Target.Type == TargetType.Monster)
                {
                    /// 周辺の戦闘キャラリスト(IDからNameを取得するため)
                    List<Combatant> combatantList = FFXIVPluginHelper.GetCombatantList();

                    /// 一度に全部読む
                    byte[] buffer = FFXIVPluginHelper.GetByteArray((uint)hateAddress.ToInt64(), 16 * 72);
                    uint TopEnmity = 0;
                    ///
                    for (int i = 0; i < 16; i++ )
                    {
                        int p = i * 72;
                        uint _id;
                        uint _enmity;

                        unsafe
                        {
                            fixed (byte* bp = &buffer[p]) _id = *(uint*)bp;
                            fixed (byte* bp = &buffer[p+4]) _enmity = *(uint*)bp;
                        }
                        var entry = new EnmityEntry()
                        {
                            ID = _id,
                            Enmity = _enmity,
                            isMe = false
                        };
                        if (entry.ID > 0)
                        {
                            Combatant c = combatantList.Find(x => x.ID == entry.ID);
                            if (c != null)
                            {
                                entry.Name = c.Name;
                                entry.Job = c.Job;
                                entry.OwnerID = c.OwnerID;
                            }
                            if (entry.ID == mypc.ID)
                            {
                                entry.isMe = true;
                            }
                            if (TopEnmity == 0)
                            {
                                TopEnmity = entry.Enmity;
                            }
                            entry.HateRate = (int)(((double)entry.Enmity / (double)TopEnmity)*100);
                            enmity.Entries.Add(entry);
                        }
                        else
                        {
                            break; // もう読まない
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(LogLevel.Error, "Update: {1}", this.Name, ex);
            }
            return serializer.Serialize(enmity);
        }

        private string CreateEventDispatcherScript()
        {
            return "var ActXiv = { 'Enmity': " + this.CreateJsonData() + " };\n" +
                   "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', { detail: ActXiv }));";
        }

        /// <summary>
        /// スキャンを開始する
        /// </summary>
        public new void Start()
        {
            if (this.Config.IsVisible == false) {
                return;
            }
            timer.Interval = this.Config.ScanInterval;
            timer.Start();
            Log(LogLevel.Info, Messages.StartScanning);
        }

        /// <summary>
        /// スキャンを停止する
        /// </summary>
        public new void Stop()
        {
            timer.Stop();
            Log(LogLevel.Info, Messages.StopScanning);
        }

        protected override void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = this.Config.ScanInterval;
            timer.Elapsed += (o, e) =>
            {
                try
                {
                    Update();
                }
                catch (Exception ex)
                {
                    Log(LogLevel.Error, "Update: {0}", ex.ToString());
                }
            };
        }

        ///
        /// Job enum
        ///
        public enum JobEnum : byte
        {
            UNKNOWN,
            GLD,
            PGL,
            MRD,
            LNC,
            ARC,
            CNJ,
            THM,
            CRP,
            BSM,
            ARM,
            GSM,
            LTW,
            WVR,
            ALC,
            CUL,
            MIN,
            BTN,
            FSH,
            PLD,
            MNK,
            WAR,
            DRG,
            BRD,
            WHM,
            BLM,
            ACN,
            SMN,
            SCH,
            ROG,
            NIN
        }

        //// 敵視されてるキャラエントリ
        private class EnmityEntry
        {
            public uint ID;
            public uint OwnerID;
            public string Name;
            public uint Enmity;
            public bool isMe;
            public int HateRate;
            public int Job;
            public string JobName
            {
                get
                {
                    return Enum.GetName(typeof(JobEnum), Job);
                }
            }
            public string EnmityString
            {
                get
                {
                    return Enmity.ToString("##,#");
                }
            }
            public bool isPet
            {
                get
                {
                    return (OwnerID != 0);
                }
            }
        }

        //// JSON用オブジェクト
        private class EnmityObject
        {
            public TargetInfo Target;
            public List<EnmityEntry> Entries;
        }
    }
}
