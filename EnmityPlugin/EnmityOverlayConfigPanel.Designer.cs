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
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nudEnmityMaxFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.checkEnmityVisible = new System.Windows.Forms.CheckBox();
            this.checkEnmityClickThru = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEnmityReloadBrowser = new System.Windows.Forms.Button();
            this.buttonEnmityCopyActXiv = new System.Windows.Forms.Button();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.textEnmityUrl = new System.Windows.Forms.TextBox();
            this.buttonEnmitySelectFile = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.nudEnmityScanInterval = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkEnmityEnableGlobalHotkey = new System.Windows.Forms.CheckBox();
            this.textEnmityGlobalHotkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkLock = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityMaxFrameRate)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityScanInterval)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.label11, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.label14, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityMaxFrameRate, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityVisible, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityClickThru, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.panel3, 1, 8);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityScanInterval, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.checkLock, 1, 2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
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
            1,
            0,
            0,
            0});
            this.nudEnmityMaxFrameRate.ValueChanged += new System.EventHandler(this.nudEnmityMaxFrameRate_ValueChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // checkEnmityVisible
            // 
            resources.ApplyResources(this.checkEnmityVisible, "checkEnmityVisible");
            this.checkEnmityVisible.Name = "checkEnmityVisible";
            this.checkEnmityVisible.UseVisualStyleBackColor = true;
            this.checkEnmityVisible.CheckedChanged += new System.EventHandler(this.checkEnmityVisible_CheckedChanged);
            // 
            // checkEnmityClickThru
            // 
            resources.ApplyResources(this.checkEnmityClickThru, "checkEnmityClickThru");
            this.checkEnmityClickThru.Name = "checkEnmityClickThru";
            this.checkEnmityClickThru.UseVisualStyleBackColor = true;
            this.checkEnmityClickThru.CheckedChanged += new System.EventHandler(this.checkEnmityClickThru_CheckedChanged);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.tableLayoutPanel8);
            this.panel3.Name = "panel3";
            // 
            // tableLayoutPanel8
            // 
            resources.ApplyResources(this.tableLayoutPanel8, "tableLayoutPanel8");
            this.tableLayoutPanel8.Controls.Add(this.buttonEnmityReloadBrowser, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.buttonEnmityCopyActXiv, 0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            // 
            // buttonEnmityReloadBrowser
            // 
            resources.ApplyResources(this.buttonEnmityReloadBrowser, "buttonEnmityReloadBrowser");
            this.buttonEnmityReloadBrowser.Name = "buttonEnmityReloadBrowser";
            this.buttonEnmityReloadBrowser.UseVisualStyleBackColor = true;
            this.buttonEnmityReloadBrowser.Click += new System.EventHandler(this.buttonEnmityReloadBrowser_Click);
            // 
            // buttonEnmityCopyActXiv
            // 
            resources.ApplyResources(this.buttonEnmityCopyActXiv, "buttonEnmityCopyActXiv");
            this.buttonEnmityCopyActXiv.Name = "buttonEnmityCopyActXiv";
            this.buttonEnmityCopyActXiv.UseVisualStyleBackColor = true;
            this.buttonEnmityCopyActXiv.Click += new System.EventHandler(this.buttonEnmityCopyActXiv_Click);
            // 
            // tableLayoutPanel9
            // 
            resources.ApplyResources(this.tableLayoutPanel9, "tableLayoutPanel9");
            this.tableLayoutPanel9.Controls.Add(this.textEnmityUrl, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.buttonEnmitySelectFile, 1, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
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
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.checkEnmityEnableGlobalHotkey, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textEnmityGlobalHotkey, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // checkLock
            // 
            resources.ApplyResources(this.checkLock, "checkLock");
            this.checkLock.Name = "checkLock";
            this.checkLock.UseVisualStyleBackColor = true;
            this.checkLock.CheckedChanged += new System.EventHandler(this.checkLock_CheckedChanged);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityMaxFrameRate)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityScanInterval)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudEnmityMaxFrameRate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkEnmityVisible;
        private System.Windows.Forms.CheckBox checkEnmityClickThru;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button buttonEnmityReloadBrowser;
        private System.Windows.Forms.Button buttonEnmityCopyActXiv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox textEnmityUrl;
        private System.Windows.Forms.Button buttonEnmitySelectFile;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudEnmityScanInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkEnmityEnableGlobalHotkey;
        private System.Windows.Forms.TextBox textEnmityGlobalHotkey;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkLock;
    }
}
