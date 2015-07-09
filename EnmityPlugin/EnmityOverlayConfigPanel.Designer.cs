namespace Tamagawa.EnmityPlugin
{
    partial class EnmityOverlayConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnmityOverlayConfigPanel));
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Process = new System.Windows.Forms.Label();
            this.table_Process = new System.Windows.Forms.TableLayoutPanel();
            this.comboProcessList = new System.Windows.Forms.ComboBox();
            this.buttonRefreshProcessList = new System.Windows.Forms.Button();
            this.label_ShowOverlay = new System.Windows.Forms.Label();
            this.checkEnmityVisible = new System.Windows.Forms.CheckBox();
            this.label_Clickthru = new System.Windows.Forms.Label();
            this.checkEnmityClickThru = new System.Windows.Forms.CheckBox();
            this.label_LockOverlay = new System.Windows.Forms.Label();
            this.checkLock = new System.Windows.Forms.CheckBox();
            this.label_URL = new System.Windows.Forms.Label();
            this.table_URL = new System.Windows.Forms.TableLayoutPanel();
            this.textEnmityUrl = new System.Windows.Forms.TextBox();
            this.buttonEnmitySelectFile = new System.Windows.Forms.Button();
            this.label_ScanInterval = new System.Windows.Forms.Label();
            this.nudEnmityScanInterval = new System.Windows.Forms.NumericUpDown();
            this.label_Hotkey = new System.Windows.Forms.Label();
            this.table_Hotkey = new System.Windows.Forms.TableLayoutPanel();
            this.checkEnmityEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.textEnmityGlobalHotkey = new System.Windows.Forms.TextBox();
            this.label_Framerate = new System.Windows.Forms.Label();
            this.nudEnmityMaxFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label_Help = new System.Windows.Forms.Label();
            this.panel_Buttons = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEnmityCopyActXiv = new System.Windows.Forms.Button();
            this.buttonEnmityReloadBrowser = new System.Windows.Forms.Button();
            this.tableLayoutPanel7.SuspendLayout();
            this.table_Process.SuspendLayout();
            this.table_URL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityScanInterval)).BeginInit();
            this.table_Hotkey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityMaxFrameRate)).BeginInit();
            this.panel_Buttons.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.label_Process, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.table_Process, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label_ShowOverlay, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityVisible, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.label_Clickthru, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityClickThru, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.label_LockOverlay, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.checkLock, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.label_URL, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.table_URL, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.label_ScanInterval, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityScanInterval, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.label_Hotkey, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.table_Hotkey, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.label_Framerate, 0, 7);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityMaxFrameRate, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.label_Help, 1, 8);
            this.tableLayoutPanel7.Controls.Add(this.panel_Buttons, 1, 9);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // label_Process
            // 
            resources.ApplyResources(this.label_Process, "label_Process");
            this.label_Process.Name = "label_Process";
            // 
            // table_Process
            // 
            resources.ApplyResources(this.table_Process, "table_Process");
            this.table_Process.Controls.Add(this.comboProcessList, 0, 0);
            this.table_Process.Controls.Add(this.buttonRefreshProcessList, 1, 0);
            this.table_Process.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.table_Process.Name = "table_Process";
            // 
            // comboProcessList
            // 
            resources.ApplyResources(this.comboProcessList, "comboProcessList");
            this.comboProcessList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProcessList.FormattingEnabled = true;
            this.comboProcessList.Name = "comboProcessList";
            this.comboProcessList.SelectedIndexChanged += new System.EventHandler(this.comboProcessList_SelectedIndexChanged);
            // 
            // buttonRefreshProcessList
            // 
            resources.ApplyResources(this.buttonRefreshProcessList, "buttonRefreshProcessList");
            this.buttonRefreshProcessList.Name = "buttonRefreshProcessList";
            this.buttonRefreshProcessList.UseVisualStyleBackColor = true;
            this.buttonRefreshProcessList.Click += new System.EventHandler(this.buttonRefreshProcessList_Click);
            // 
            // label_ShowOverlay
            // 
            resources.ApplyResources(this.label_ShowOverlay, "label_ShowOverlay");
            this.label_ShowOverlay.Name = "label_ShowOverlay";
            // 
            // checkEnmityVisible
            // 
            resources.ApplyResources(this.checkEnmityVisible, "checkEnmityVisible");
            this.checkEnmityVisible.Name = "checkEnmityVisible";
            this.checkEnmityVisible.UseVisualStyleBackColor = true;
            this.checkEnmityVisible.CheckedChanged += new System.EventHandler(this.checkEnmityVisible_CheckedChanged);
            // 
            // label_Clickthru
            // 
            resources.ApplyResources(this.label_Clickthru, "label_Clickthru");
            this.label_Clickthru.Name = "label_Clickthru";
            // 
            // checkEnmityClickThru
            // 
            resources.ApplyResources(this.checkEnmityClickThru, "checkEnmityClickThru");
            this.checkEnmityClickThru.Name = "checkEnmityClickThru";
            this.checkEnmityClickThru.UseVisualStyleBackColor = true;
            this.checkEnmityClickThru.CheckedChanged += new System.EventHandler(this.checkEnmityClickThru_CheckedChanged);
            // 
            // label_LockOverlay
            // 
            resources.ApplyResources(this.label_LockOverlay, "label_LockOverlay");
            this.label_LockOverlay.Name = "label_LockOverlay";
            // 
            // checkLock
            // 
            resources.ApplyResources(this.checkLock, "checkLock");
            this.checkLock.Name = "checkLock";
            this.checkLock.UseVisualStyleBackColor = true;
            this.checkLock.CheckedChanged += new System.EventHandler(this.checkLock_CheckedChanged);
            // 
            // label_URL
            // 
            resources.ApplyResources(this.label_URL, "label_URL");
            this.label_URL.Name = "label_URL";
            // 
            // table_URL
            // 
            resources.ApplyResources(this.table_URL, "table_URL");
            this.table_URL.Controls.Add(this.textEnmityUrl, 0, 0);
            this.table_URL.Controls.Add(this.buttonEnmitySelectFile, 1, 0);
            this.table_URL.Name = "table_URL";
            // 
            // textEnmityUrl
            // 
            resources.ApplyResources(this.textEnmityUrl, "textEnmityUrl");
            this.textEnmityUrl.Name = "textEnmityUrl";
            this.textEnmityUrl.TextChanged += new System.EventHandler(this.textEnmityUrl_TextChanged);
            // 
            // buttonEnmitySelectFile
            // 
            resources.ApplyResources(this.buttonEnmitySelectFile, "buttonEnmitySelectFile");
            this.buttonEnmitySelectFile.Name = "buttonEnmitySelectFile";
            this.buttonEnmitySelectFile.UseVisualStyleBackColor = true;
            this.buttonEnmitySelectFile.Click += new System.EventHandler(this.buttonEnmitySelectFile_Click);
            // 
            // label_ScanInterval
            // 
            resources.ApplyResources(this.label_ScanInterval, "label_ScanInterval");
            this.label_ScanInterval.Name = "label_ScanInterval";
            // 
            // nudEnmityScanInterval
            // 
            resources.ApplyResources(this.nudEnmityScanInterval, "nudEnmityScanInterval");
            this.nudEnmityScanInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudEnmityScanInterval.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudEnmityScanInterval.Name = "nudEnmityScanInterval";
            this.nudEnmityScanInterval.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudEnmityScanInterval.ValueChanged += new System.EventHandler(this.nudEnmityScanInterval_ValueChanged);
            // 
            // label_Hotkey
            // 
            resources.ApplyResources(this.label_Hotkey, "label_Hotkey");
            this.label_Hotkey.Name = "label_Hotkey";
            // 
            // table_Hotkey
            // 
            resources.ApplyResources(this.table_Hotkey, "table_Hotkey");
            this.table_Hotkey.Controls.Add(this.checkEnmityEnableGlobalHotkey, 0, 0);
            this.table_Hotkey.Controls.Add(this.textEnmityGlobalHotkey, 1, 0);
            this.table_Hotkey.Name = "table_Hotkey";
            // 
            // checkEnmityEnableGlobalHotkey
            // 
            resources.ApplyResources(this.checkEnmityEnableGlobalHotkey, "checkEnmityEnableGlobalHotkey");
            this.checkEnmityEnableGlobalHotkey.Name = "checkEnmityEnableGlobalHotkey";
            this.checkEnmityEnableGlobalHotkey.UseVisualStyleBackColor = true;
            this.checkEnmityEnableGlobalHotkey.CheckedChanged += new System.EventHandler(this.checkEnmityEnableGlobalHotkey_CheckedChanged);
            // 
            // textEnmityGlobalHotkey
            // 
            resources.ApplyResources(this.textEnmityGlobalHotkey, "textEnmityGlobalHotkey");
            this.textEnmityGlobalHotkey.Name = "textEnmityGlobalHotkey";
            this.textEnmityGlobalHotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEnmityGlobalHotkey_KeyDown);
            // 
            // label_Framerate
            // 
            resources.ApplyResources(this.label_Framerate, "label_Framerate");
            this.label_Framerate.Name = "label_Framerate";
            // 
            // nudEnmityMaxFrameRate
            // 
            resources.ApplyResources(this.nudEnmityMaxFrameRate, "nudEnmityMaxFrameRate");
            this.nudEnmityMaxFrameRate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudEnmityMaxFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEnmityMaxFrameRate.Name = "nudEnmityMaxFrameRate";
            this.nudEnmityMaxFrameRate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudEnmityMaxFrameRate.ValueChanged += new System.EventHandler(this.nudEnmityMaxFrameRate_ValueChanged);
            // 
            // label_Help
            // 
            resources.ApplyResources(this.label_Help, "label_Help");
            this.label_Help.Name = "label_Help";
            // 
            // panel_Buttons
            // 
            this.panel_Buttons.Controls.Add(this.tableLayoutPanel8);
            resources.ApplyResources(this.panel_Buttons, "panel_Buttons");
            this.panel_Buttons.Name = "panel_Buttons";
            // 
            // tableLayoutPanel8
            // 
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.buttonEnmityCopyActXiv, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.buttonEnmityReloadBrowser, 1, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // buttonEnmityCopyActXiv
            // 
            resources.ApplyResources(this.buttonEnmityCopyActXiv, "buttonEnmityCopyActXiv");
            this.buttonEnmityCopyActXiv.Name = "buttonEnmityCopyActXiv";
            this.buttonEnmityCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonEnmityCopyActXiv.Click += new System.EventHandler(this.buttonEnmityCopyActXiv_Click);
            // 
            // buttonEnmityReloadBrowser
            // 
            resources.ApplyResources(this.buttonEnmityReloadBrowser, "buttonEnmityReloadBrowser");
            this.buttonEnmityReloadBrowser.Name = "buttonEnmityReloadBrowser";
            this.buttonEnmityReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonEnmityReloadBrowser.Click += new System.EventHandler(this.buttonEnmityReloadBrowser_Click);
            // 
            // EnmityOverlayConfigPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel7);
            this.Name = "EnmityOverlayConfigPanel";
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.table_Process.ResumeLayout(false);
            this.table_URL.ResumeLayout(false);
            this.table_URL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityScanInterval)).EndInit();
            this.table_Hotkey.ResumeLayout(false);
            this.table_Hotkey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityMaxFrameRate)).EndInit();
            this.panel_Buttons.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label_Help;
        private System.Windows.Forms.Label label_Framerate;
        private System.Windows.Forms.NumericUpDown nudEnmityMaxFrameRate;
        private System.Windows.Forms.Label label_Clickthru;
        private System.Windows.Forms.Label label_ShowOverlay;
        private System.Windows.Forms.Label label_URL;
        private System.Windows.Forms.CheckBox checkEnmityVisible;
        private System.Windows.Forms.CheckBox checkEnmityClickThru;
        private System.Windows.Forms.Panel panel_Buttons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button buttonEnmityReloadBrowser;
        private System.Windows.Forms.Button buttonEnmityCopyActXiv;
        private System.Windows.Forms.TableLayoutPanel table_URL;
        private System.Windows.Forms.TextBox textEnmityUrl;
        private System.Windows.Forms.Button buttonEnmitySelectFile;
        private System.Windows.Forms.Label label_ScanInterval;
        private System.Windows.Forms.NumericUpDown nudEnmityScanInterval;
        private System.Windows.Forms.Label label_Hotkey;
        private System.Windows.Forms.CheckBox checkEnmityEnableGlobalHotkey;
        private System.Windows.Forms.TextBox textEnmityGlobalHotkey;
        private System.Windows.Forms.TableLayoutPanel table_Hotkey;
        private System.Windows.Forms.Label label_LockOverlay;
        private System.Windows.Forms.CheckBox checkLock;
        private System.Windows.Forms.Label label_Process;
        private System.Windows.Forms.TableLayoutPanel table_Process;
        private System.Windows.Forms.ComboBox comboProcessList;
        private System.Windows.Forms.Button buttonRefreshProcessList;
    }
}
