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

namespace Tamagawa.EnmityPlugin
{
    public partial class ControlPanel : UserControl
    {
        PluginMain pluginMain;
        PluginConfig config;

        public ControlPanel(PluginMain pluginMain, PluginConfig config)
        {
            InitializeComponent();

            this.pluginMain = pluginMain;
            this.config = config;

            SetupEnmityConfigHandlers();

            SetupEnmityTab();

            this.menuFollowLatestLog.Checked = this.config.FollowLatestLog;
            this.listViewLog.VirtualListSize = pluginMain.Logs.Count;
            this.pluginMain.Logs.ListChanged += (o, e) =>
            {
                this.listViewLog.BeginUpdate();
                this.listViewLog.VirtualListSize = pluginMain.Logs.Count;
                if (this.config.FollowLatestLog && this.pluginMain.Logs.Count > 0)
                {
                    this.listViewLog.EnsureVisible(this.pluginMain.Logs.Count - 1);
                }
                this.listViewLog.EndUpdate();
            };
        }

        private void SetupEnmityTab()
        {
            this.checkEnmityVisible.Checked = config.EnmityOverlay.IsVisible;
            this.checkEnmityClickThru.Checked = config.EnmityOverlay.IsClickThru;
            this.textEnmityUrl.Text = config.EnmityOverlay.Url;
            this.nudEnmityMaxFrameRate.Value = config.EnmityOverlay.MaxFrameRate;
            this.nudEnmityScanInterval.Value = config.EnmityOverlay.ScanInterval;
        }

        private void SetupEnmityConfigHandlers()
        {
            this.config.EnmityOverlay.VisibleChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnmityVisible.Checked = e.IsVisible;
                });
            };
            this.config.EnmityOverlay.ClickThruChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.checkEnmityClickThru.Checked = e.IsClickThru;
                });
            };
            this.config.EnmityOverlay.UrlChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.textEnmityUrl.Text = e.NewUrl;
                });
            };
            this.config.EnmityOverlay.MaxFrameRateChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudEnmityMaxFrameRate.Value = e.NewFrameRate;
                });
            };
            this.config.EnmityOverlay.ScanIntervalChanged += (o, e) =>
            {
                this.InvokeIfRequired(() =>
                {
                    this.nudEnmityScanInterval.Value = e.NewScanInterval;
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

        private void menuLogCopy_Click(object sender, EventArgs e)
        {
            if (listViewLog.SelectedIndices.Count > 0)
            {
                var sb = new StringBuilder();
                foreach (int index in listViewLog.SelectedIndices)
                {
                    sb.AppendFormat(
                        "{0}: {1}: {2}",
                        pluginMain.Logs[index].Time,
                        pluginMain.Logs[index].Level,
                        pluginMain.Logs[index].Message);
                    sb.AppendLine();
                }
                Clipboard.SetText(sb.ToString());
            }
        }

        private void listViewLog_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= pluginMain.Logs.Count) 
            {
                e.Item = new ListViewItem();
                return;
            };

            var log = this.pluginMain.Logs[e.ItemIndex];
            e.Item = new ListViewItem(log.Time.ToString());
            e.Item.UseItemStyleForSubItems = true;
            e.Item.SubItems.Add(log.Level.ToString());
            e.Item.SubItems.Add(log.Message);

            e.Item.ForeColor = Color.Black;
            if (log.Level == LogLevel.Warning)
            {
                e.Item.BackColor = Color.LightYellow;
            }
            else if (log.Level == LogLevel.Error)
            {
                e.Item.BackColor = Color.LightPink;
            }
            else
            {
                e.Item.BackColor = Color.White;
            }
        }

        private void menuFollowLatestLog_Click(object sender, EventArgs e)
        {
            this.config.FollowLatestLog = menuFollowLatestLog.Checked;
        }

        private void menuClearLog_Click(object sender, EventArgs e)
        {
            this.pluginMain.Logs.Clear();
        }

        private void menuCopyLogAll_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (var log in this.pluginMain.Logs)
            {
                sb.AppendFormat(
                    "{0}: {1}: {2}",
                    log.Time,
                    log.Level,
                    log.Message);
                sb.AppendLine();
            }
            Clipboard.SetText(sb.ToString());
        }

        // EnmityOverlay
        private void checkEnmityVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.config.EnmityOverlay.IsVisible = this.checkEnmityVisible.Checked;
            if (pluginMain.EnmityOverlay != null)
            {
                if (this.config.EnmityOverlay.IsVisible == true) {
                    pluginMain.EnmityOverlay.Start();
                }
                else
                {
                    pluginMain.EnmityOverlay.Stop();
                }
            }
        }

        private void checkEnmityClickThru_CheckedChanged(object sender, EventArgs e)
        {
            this.config.EnmityOverlay.IsClickThru = this.checkEnmityClickThru.Checked;
        }

        private void textEnmityUrl_TextChanged(object sender, EventArgs e)
        {
            this.config.EnmityOverlay.Url = this.textEnmityUrl.Text;
        }

        private void buttonEnmitySelectFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.config.EnmityOverlay.Url = new Uri(ofd.FileName).ToString();
            }
        }

        private void buttonEnmityCopyActXiv_Click(object sender, EventArgs e)
        {
            var json = pluginMain.EnmityOverlay.CreateJsonData();
            if (!string.IsNullOrWhiteSpace(json))
            {
                Clipboard.SetText("var ActXiv = " + json + ";");
            }
        }

        private void buttonEnmityReloadBrowser_Click(object sender, EventArgs e)
        {
            pluginMain.EnmityOverlay.Navigate(config.EnmityOverlay.Url);
        }

        private void nudEnmityMaxFrameRate_ValueChanged(object sender, EventArgs e)
        {
            this.config.EnmityOverlay.MaxFrameRate = (int)nudEnmityMaxFrameRate.Value;
        }

        private void nudEnmityScanInterval_ValueChanged(object sender, EventArgs e)
        {
            this.config.EnmityOverlay.ScanInterval = (int)nudEnmityScanInterval.Value;
            if (pluginMain.EnmityOverlay != null)
            {
                pluginMain.EnmityOverlay.Stop();
                pluginMain.EnmityOverlay.Start();
            }
        }
    }
}
