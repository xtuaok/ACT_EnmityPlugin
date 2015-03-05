namespace Tamagawa.EnmityPlugin
{
    partial class ControlPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuLogList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuCopyLogAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFollowLatestLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClearLog = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityMaxFrameRate)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnmityScanInterval)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuLogList.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.listViewLog);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.tableLayoutPanel7);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            resources.ApplyResources(this.tableLayoutPanel7, "tableLayoutPanel7");
            this.tableLayoutPanel7.Controls.Add(this.label11, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityMaxFrameRate, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityVisible, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.checkEnmityClickThru, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.panel3, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.label18, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.nudEnmityScanInterval, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel1, 1, 4);
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
            1000,
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
            // listViewLog
            // 
            resources.ApplyResources(this.listViewLog, "listViewLog");
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewLog.ContextMenuStrip = this.contextMenuLogList;
            this.listViewLog.FullRowSelect = true;
            this.listViewLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewLog.HideSelection = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            this.listViewLog.VirtualMode = true;
            this.listViewLog.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewLog_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // contextMenuLogList
            // 
            resources.ApplyResources(this.contextMenuLogList, "contextMenuLogList");
            this.contextMenuLogList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyLogAll,
            this.menuLogCopy,
            this.toolStripMenuItem1,
            this.menuFollowLatestLog,
            this.toolStripMenuItem2,
            this.menuClearLog});
            this.contextMenuLogList.Name = "contextMenuLogList";
            // 
            // menuCopyLogAll
            // 
            resources.ApplyResources(this.menuCopyLogAll, "menuCopyLogAll");
            this.menuCopyLogAll.Name = "menuCopyLogAll";
            this.menuCopyLogAll.Click += new System.EventHandler(this.menuCopyLogAll_Click);
            // 
            // menuLogCopy
            // 
            resources.ApplyResources(this.menuLogCopy, "menuLogCopy");
            this.menuLogCopy.Name = "menuLogCopy";
            this.menuLogCopy.Click += new System.EventHandler(this.menuLogCopy_Click);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // menuFollowLatestLog
            // 
            resources.ApplyResources(this.menuFollowLatestLog, "menuFollowLatestLog");
            this.menuFollowLatestLog.CheckOnClick = true;
            this.menuFollowLatestLog.Name = "menuFollowLatestLog";
            this.menuFollowLatestLog.Click += new System.EventHandler(this.menuFollowLatestLog_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // menuClearLog
            // 
            resources.ApplyResources(this.menuClearLog, "menuClearLog");
            this.menuClearLog.Name = "menuClearLog";
            this.menuClearLog.Click += new System.EventHandler(this.menuClearLog_Click);
            // 
            // ControlPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ControlPanel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
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
            this.contextMenuLogList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuLogList;
        private System.Windows.Forms.ToolStripMenuItem menuLogCopy;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFollowLatestLog;
        private System.Windows.Forms.ToolStripMenuItem menuCopyLogAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuClearLog;
        private System.Windows.Forms.TabPage tabPage3;
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
    }
}
