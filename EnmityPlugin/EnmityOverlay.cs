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
    [Serializable()]

    public class EnmityOverlay : OverlayBase<EnmityOverlayConfig>
    {
        private FFXIVMemory _memory = null;
        private bool suppress_log = false;
        private bool isDebug = false;
        private object _lock = new object();

        public EnmityOverlay(EnmityOverlayConfig config) : base(config, config.Name)
        {
            if (config.Name.Equals("EnmityDebug"))
            {
                isDebug = true;
            }
        }

        public override void Dispose()
        {
            this.xivWindowTimer.Enabled = false;
            this.timer.Enabled = false;
            if (this._memory != null) this._memory.Dispose();
            base.Dispose();
        }

        public void changeProcessId(int processId)
        {
            lock (_lock)
            {
                Process p = null;

                if (Config.FollowFFXIVPlugin)
                {
                    if (FFXIVPluginHelper.Instance != null)
                    {
                        p = FFXIVPluginHelper.GetFFXIVProcess;
                    }
                }
                else
                {
                    p = FFXIVProcessHelper.GetFFXIVProcess(processId);
                }

                if ((_memory == null && p != null) ||
                    (_memory != null && p != null && p.Id != _memory.process.Id))
                {
                    _memory = new FFXIVMemory(this, p);
                }
                else if (_memory != null && p == null)
                {
                    _memory.Dispose();
                    _memory = null;
                }
            }
        }

        public void LogDebug(string format, params object[] args)
        {
            LogLevel level = isDebug ? LogLevel.Info : LogLevel.Debug;
            Log(level, format, args);
        }

        public void LogError(string format, params object[] args)
        {
            Log(LogLevel.Error, format, args);
        }

        public void LogWarning(string format, params object[] args)
        {
            Log(LogLevel.Warning, format, args);
        }

        public void LogInfo(string format, params object[] args)
        {
            Log(LogLevel.Info, format, args);
        }

        /// <summary>
        /// プロセスの有効性をチェック
        /// </summary>
        private void checkProcessId()
        {
            try
            {
                if (Config.FollowFFXIVPlugin)
                {
                    Process p = null;
                    if (FFXIVPluginHelper.Instance != null)
                    {
                        p = FFXIVPluginHelper.GetFFXIVProcess;
                        if (p == null || (_memory != null && _memory.process.Id != p.Id))
                        {
                            if (_memory != null) _memory.Dispose();
                            _memory = null;
                        }
                    }
                }

                if (_memory == null)
                {
                    changeProcessId(0);
                }
                else if (_memory.validateProcess())
                {
                    // スキャン間隔をもどす
                    if (timer.Interval != this.Config.ScanInterval)
                    {
                        timer.Interval = this.Config.ScanInterval;
                    }

                    if (suppress_log == true)
                    {
                        suppress_log = false;
                    }
                }
                else
                {
                    _memory.Dispose();
                    _memory = null;
                }
            }
            catch (Exception ex)
            {
                if (suppress_log == false)
                {
                    LogError(ex.Message);
                }
            }
        }

        protected override void Update()
        {
            int delay = 3000;
            try
            {
                // プロセスチェック
                checkProcessId();

                if (_memory == null)
                {
                    // スキャン間隔を一旦遅くする
                    timer.Interval = delay;
                    if (suppress_log == false)
                    {
                        suppress_log = true;
                        LogWarning(Messages.ProcessNotFound);
                        LogDebug(Messages.UpdateScanInterval, delay);
                    }
                }

                string updateScript = CreateEventDispatcherScript();
                if (this.Overlay != null &&
                    this.Overlay.Renderer != null &&
                    this.Overlay.Renderer.Browser != null)
                {
                    this.Overlay.Renderer.Browser.GetMainFrame().ExecuteJavaScript(updateScript, null, 0);
                }
            }
            catch (Exception ex)
            {
                LogError("Update: {1}", this.Name, ex);
            }
        }

        /// <summary>
        /// データを取得し、JSONを作る
        /// </summary>
        /// <returns></returns>
        internal string CreateJsonData()
        {
            // シリアライザ
            var serializer = new JavaScriptSerializer();

            // キャラリスト
            List<Combatant> combatants;
            // 自キャラ
            Combatant mychar;

            // Overlay に渡すオブジェクト
            EnmityObject enmity = new EnmityObject();
            enmity.Entries = new List<EnmityEntry>();

            // なんかプロセスがおかしいとき
            if (_memory == null || _memory.validateProcess() == false)
            {
                enmity.Target = new Combatant() {
                    Name = "Failed to scan memory.",
                    ID = 0,
                    MaxHP = 0,
                    CurrentHP = 0,
                    Distance = "0.00",
                    EffectiveDistance = 0,
                    HorizontalDistance = "0.00"
                };
                return serializer.Serialize(enmity);
            }
            try
            {
                combatants = _memory.Combatants;

                // 自キャラ
                mychar = _memory.GetSelfCombatant();

                // 各種ターゲット
                enmity.Target = _memory.GetTargetCombatant();
                enmity.Focus = _memory.GetFocusCombatant();
                enmity.Hover = _memory.GetHoverCombatant();
                enmity.Anchor = _memory.GetAnchorCombatant();
                enmity.AggroList = _memory.GetAggroList();

                // ターゲット
                if (enmity.Target != null)
                {
                    if (enmity.Target.TargetID > 0)
                    {
                        enmity.TargetOfTarget = combatants.FirstOrDefault((Combatant x) => x.ID == (enmity.Target.TargetID));
                    }
                    // 距離計算
                    enmity.Target.Distance = mychar.GetDistanceTo(enmity.Target).ToString("0.00");
                    enmity.Target.HorizontalDistance = mychar.GetHorizontalDistanceTo(enmity.Target).ToString("0.00");
                    if (enmity.Target.type == ObjectType.Monster)
                    {
                        enmity.Entries = _memory.GetEnmityEntryList();
                    }
                }

                if (enmity.Focus != null)
                {
                    enmity.Focus.Distance = mychar.GetDistanceTo(enmity.Focus).ToString("0.00");
                    enmity.Focus.HorizontalDistance = mychar.GetHorizontalDistanceTo(enmity.Focus).ToString("0.00");
                }
                if (enmity.Anchor != null)
                {
                    enmity.Anchor.Distance = mychar.GetDistanceTo(enmity.Anchor).ToString("0.00");
                    enmity.Anchor.HorizontalDistance = mychar.GetHorizontalDistanceTo(enmity.Anchor).ToString("0.00");
                }
                if (enmity.Hover != null)
                {
                    enmity.Hover.Distance = mychar.GetDistanceTo(enmity.Hover).ToString("0.00");
                    enmity.Hover.HorizontalDistance = mychar.GetHorizontalDistanceTo(enmity.Hover).ToString("0.00");
                }
                if (enmity.TargetOfTarget != null)
                {
                    enmity.TargetOfTarget.Distance = mychar.GetDistanceTo(enmity.TargetOfTarget).ToString("0.00");
                    enmity.TargetOfTarget.HorizontalDistance = mychar.GetHorizontalDistanceTo(enmity.TargetOfTarget).ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                LogError("Update: {1}", this.Name, ex);
            }
            return serializer.Serialize(enmity);
        }

        private string CreateEventDispatcherScript()
        {
            return "var ActXiv = { 'Enmity': " + this.CreateJsonData() + " };\n" +
                   "document.dispatchEvent(new CustomEvent('onOverlayDataUpdate', { detail: ActXiv }));";
        }

        /// <summary>
        /// スキャン間隔を更新する
        /// </summary>
        public void UpdateScanInterval()
        {
            timer.Interval = this.Config.ScanInterval;
            LogDebug(Messages.UpdateScanInterval, this.Config.ScanInterval);
        }

        /// <summary>
        /// スキャンを開始する
        /// </summary>
        public new void Start()
        {
            if (OverlayAddonMain.UpdateMessage != String.Empty)
            {
                LogInfo(OverlayAddonMain.UpdateMessage);
                OverlayAddonMain.UpdateMessage = String.Empty;
            }
            if (this.Config.IsVisible == false)
            {
                return;
            }
            LogInfo(Messages.StartScanning);
            suppress_log = false;
            timer.Start();            
        }

        /// <summary>
        /// スキャンを停止する
        /// </summary>
        public new void Stop()
        {
            if (timer.Enabled)
            {
                timer.Stop();
                LogInfo(Messages.StopScanning);
            }
        }

        protected override void InitializeTimer()
        {
            base.InitializeTimer();
        }

        //// JSON用オブジェクト
        private class EnmityObject
        {
            public Combatant Target;
            public Combatant Focus;
            public Combatant Hover;
            public Combatant Anchor;
            public Combatant TargetOfTarget;
            public List<EnmityEntry> Entries;
            public List<AggroEntry> AggroList;
        }
    }
}
