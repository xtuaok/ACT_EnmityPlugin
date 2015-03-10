using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using RainbowMage.OverlayPlugin;

namespace Tamagawa.EnmityPlugin
{
    public partial class EnmityOverlayConfigPanel : UserControl
    {
        private EnmityOverlay overlay;
        private EnmityOverlayConfig config;

        public EnmityOverlayConfigPanel(EnmityOverlay overlay)
        {
            InitializeComponent();

            this.overlay = overlay;
            this.config = overlay.Config;

            SetupControlProperties();
            SetupConfigEventHandlers();
        }

        private void SetupControlProperties()
        {
            this.checkEnmityVisible.Checked = this.config.IsVisible;
            this.checkEnmityClickThru.Checked = this.config.IsClickThru;
            this.textEnmityUrl.Text = this.config.Url;
            this.nudEnmityMaxFrameRate.Value = this.config.MaxFrameRate;
            this.nudEnmityScanInterval.Value = this.config.ScanInterval;
            this.checkEnmityEnableGlobalHotkey.Checked = this.config.GlobalHotkeyEnabled;
            this.textEnmityGlobalHotkey.Enabled = this.checkEnmityEnableGlobalHotkey.Checked;
            this.textEnmityGlobalHotkey.Text = GetHotkeyString(this.config.GlobalHotkeyModifiers, this.config.GlobalHotkey);
        }

        private void SetupConfigEventHandlers()
        {
            this.config.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnmityVisible.Checked = e.IsVisible;
                });
            };
            this.config.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnmityClickThru.Checked = e.IsClickThru;
                });
            };
            this.config.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textEnmityUrl.Text = e.NewUrl;
                });
            };
            this.config.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudEnmityMaxFrameRate.Value = e.NewFrameRate;
                });
            };
            this.config.ScanIntervalChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudEnmityScanInterval.Value = e.NewScanInterval;
                });
            };
            this.config.GlobalHotkeyEnabledChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnmityEnableGlobalHotkey.Checked = e.NewGlobalHotkeyEnabled;
                    this.textEnmityGlobalHotkey.Enabled = this.checkEnmityEnableGlobalHotkey.Checked;
                });
            };
            this.config.GlobalHotkeyChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textEnmityGlobalHotkey.Text = GetHotkeyString(this.config.GlobalHotkeyModifiers, e.NewHotkey);
                });
            };
            this.config.GlobalHotkeyModifiersChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textEnmityGlobalHotkey.Text = GetHotkeyString(e.NewHotkey, this.config.GlobalHotkey);
                });
            };
        }

        private void InvokeIfRequired(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void checkEnmityVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsVisible = this.checkEnmityVisible.Checked;
            if (this.overlay != null)
            {
                if (this.config.IsVisible == true) {
                    this.overlay.Start();
                }
                else
                {
                    this.overlay.Stop();
                }
            }
        }

        private void checkEnmityClickThru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.IsClickThru = this.checkEnmityClickThru.Checked;
        }

        private void textEnmityUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.Url = this.textEnmityUrl.Text;
        }

        private void buttonEnmitySelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonEnmityCopyActXiv_Click(object sender, EventArgs e)
        {
            var json = this.overlay.CreateJsonData();
            if (!string.IsNullOrWhiteSpace(json))
            {
                Clipboard.SetText("var ActXiv = " + json + ";");
            }
        }

        private void buttonEnmityReloadBrowser_Click(object sender, EventArgs e)
        {
            this.overlay.Navigate(this.config.Url);
        }

        private void nudEnmityMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.MaxFrameRate = (int)nudEnmityMaxFrameRate.Value;
        }

        private void nudEnmityScanInterval_ValueChanged(object sender, EventArgs e)
        {
            this.config.ScanInterval = (int)nudEnmityScanInterval.Value;
            if (this.overlay != null)
            {
                this.overlay.UpdateScanInterval();
            }
        }

        private void checkEnmityEnableGlobalHotkey_CheckedChanged(object sender, EventArgs e)
        {
            this.config.GlobalHotkeyEnabled = this.checkEnmityEnableGlobalHotkey.Checked;
            this.textEnmityGlobalHotkey.Enabled = this.config.GlobalHotkeyEnabled;
        }

        private void textEnmityGlobalHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            var key = RemoveModifiers(e.KeyCode, e.Modifiers);
            this.config.GlobalHotkey = key;
            this.config.GlobalHotkeyModifiers = e.Modifiers;
        }

        /// <summary>
        ///   Generates human readable keypress string
        ///   人間が読めるキー押下文字列を生成します
        /// </summary>
        /// <param name="Modifier"></param>
        /// <param name="key"></param>
        /// <param name="defaultText"></param>
        /// <returns></returns>
        private string GetHotkeyString(Keys Modifier, Keys key, String defaultText = "")
        {
            StringBuilder sbKeys = new StringBuilder();
            if ((Modifier & Keys.Shift) == Keys.Shift)
            {
                sbKeys.Append("Shift + ");
            }
            if ((Modifier & Keys.Control) == Keys.Control)
            {
                sbKeys.Append("Ctrl + ");
            }
            if ((Modifier & Keys.Alt) == Keys.Alt)
            {
                sbKeys.Append("Alt + ");
            }
            if ((Modifier & Keys.LWin) == Keys.LWin || (Modifier & Keys.RWin) == Keys.RWin)
            {
                sbKeys.Append("Win + ");
            }
            sbKeys.Append(Enum.ToObject(typeof(Keys), key).ToString());
            return sbKeys.ToString();
        }

        /// <summary>
        ///  Removes stray references to Left/Right shifts, etc and modifications of the actual key value caused by bitwise operations
        ///  ビット単位の操作に起因する左/右シフト、などと実際のキー値の変更に浮遊の参照を削除します。
        /// </summary>
        /// <param name="KeyCode"></param>
        /// <param name="Modifiers"></param>
        /// <returns></returns>
        private Keys RemoveModifiers(Keys KeyCode, Keys Modifiers)
        {
            var key = KeyCode;
            var modifiers = new List<Keys>() { Keys.ControlKey, Keys.LControlKey, Keys.Alt, Keys.ShiftKey, Keys.Shift, Keys.LShiftKey, Keys.RShiftKey, Keys.Control, Keys.LWin, Keys.RWin };
            foreach (var mod in modifiers)
            {
                if (key.HasFlag(mod))
                {
                    if (key == mod)
                        key &= ~mod;
                }
            }
            return key;
        }

    }
}
