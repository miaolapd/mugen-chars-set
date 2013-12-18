namespace MUGENCharsSet
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ctxmnuCharacterList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxTsmiOpenDefFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiOpenCnsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiOpenDefDir = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiCopyDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiDeleteCharacter = new System.Windows.Forms.ToolStripMenuItem();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.cboReadCharacterType = new System.Windows.Forms.ComboBox();
            this.btnSearchDown = new System.Windows.Forms.Button();
            this.btnSearchUp = new System.Windows.Forms.Button();
            this.chkAutoSort = new System.Windows.Forms.CheckBox();
            this.btnSearchAll = new System.Windows.Forms.Button();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.tsmiApp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetSystemDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetSelectDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTsmiApp1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLaunchMugenExe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSelectDef = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSystemDef = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenMugenCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageCharacter = new System.Windows.Forms.TabPage();
            this.grpDefPath = new System.Windows.Forms.GroupBox();
            this.lblDefPath = new System.Windows.Forms.Label();
            this.grpPal = new System.Windows.Forms.GroupBox();
            this.dgvPal = new System.Windows.Forms.DataGridView();
            this.PalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PalVal = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grpProperty = new System.Windows.Forms.GroupBox();
            this.txtDefence = new System.Windows.Forms.TextBox();
            this.lblDefence = new System.Windows.Forms.Label();
            this.txtAttack = new System.Windows.Forms.TextBox();
            this.lblAttack = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtLife = new System.Windows.Forms.TextBox();
            this.lblLife = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpChars = new System.Windows.Forms.GroupBox();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSelectInvert = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lstCharacterList = new System.Windows.Forms.ListBox();
            this.btnRefreshCharacterList = new System.Windows.Forms.Button();
            this.fswCharacterCns = new System.IO.FileSystemWatcher();
            this.ofdDefPath = new System.Windows.Forms.OpenFileDialog();
            this.ctxmnuCharacterList.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageCharacter.SuspendLayout();
            this.grpDefPath.SuspendLayout();
            this.grpPal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPal)).BeginInit();
            this.grpProperty.SuspendLayout();
            this.grpChars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswCharacterCns)).BeginInit();
            this.SuspendLayout();
            // 
            // ctxmnuCharacterList
            // 
            this.ctxmnuCharacterList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTsmiOpenDefFile,
            this.ctxTsmiOpenCnsFile,
            this.ctxTsmiOpenDefDir,
            this.ctxTsmiCopyDefPath,
            this.ctxTsmiDeleteCharacter});
            this.ctxmnuCharacterList.Name = "contextMenuStrip1";
            this.ctxmnuCharacterList.Size = new System.Drawing.Size(213, 114);
            // 
            // ctxTsmiOpenDefFile
            // 
            this.ctxTsmiOpenDefFile.Name = "ctxTsmiOpenDefFile";
            this.ctxTsmiOpenDefFile.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiOpenDefFile.Text = "打开def文件(&D)";
            this.ctxTsmiOpenDefFile.Click += new System.EventHandler(this.ctxTsmiOpenDefFile_Click);
            // 
            // ctxTsmiOpenCnsFile
            // 
            this.ctxTsmiOpenCnsFile.Name = "ctxTsmiOpenCnsFile";
            this.ctxTsmiOpenCnsFile.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiOpenCnsFile.Text = "打开cns文件(&C)";
            this.ctxTsmiOpenCnsFile.Click += new System.EventHandler(this.ctxTsmiOpenCnsFile_Click);
            // 
            // ctxTsmiOpenDefDir
            // 
            this.ctxTsmiOpenDefDir.Name = "ctxTsmiOpenDefDir";
            this.ctxTsmiOpenDefDir.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiOpenDefDir.Text = "打开文件夹(&O)";
            this.ctxTsmiOpenDefDir.Click += new System.EventHandler(this.ctxTsmiOpenDefDir_Click);
            // 
            // ctxTsmiCopyDefPath
            // 
            this.ctxTsmiCopyDefPath.Name = "ctxTsmiCopyDefPath";
            this.ctxTsmiCopyDefPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.ctxTsmiCopyDefPath.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiCopyDefPath.Text = "复制def文件路径";
            this.ctxTsmiCopyDefPath.Click += new System.EventHandler(this.ctxTsmiCopyDefPath_Click);
            // 
            // ctxTsmiDeleteCharacter
            // 
            this.ctxTsmiDeleteCharacter.Name = "ctxTsmiDeleteCharacter";
            this.ctxTsmiDeleteCharacter.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxTsmiDeleteCharacter.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiDeleteCharacter.Text = "删除人物";
            this.ctxTsmiDeleteCharacter.Click += new System.EventHandler(this.ctxTsmiDeleteCharacter_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(468, 462);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(72, 29);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "还原";
            this.ttpCommon.SetToolTip(this.btnRestore, "快捷键：Ctrl+R");
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackup.Enabled = false;
            this.btnBackup.Location = new System.Drawing.Point(390, 462);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(72, 29);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "备份";
            this.ttpCommon.SetToolTip(this.btnBackup, "快捷键：Ctrl+B");
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(312, 462);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 29);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重置";
            this.ttpCommon.SetToolTip(this.btnReset, "快捷键：Ctrl+S");
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModify.Enabled = false;
            this.btnModify.Location = new System.Drawing.Point(234, 462);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(72, 29);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "修改";
            this.ttpCommon.SetToolTip(this.btnModify, "快捷键：Ctrl+Enter");
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // cboReadCharacterType
            // 
            this.cboReadCharacterType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReadCharacterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReadCharacterType.FormattingEnabled = true;
            this.cboReadCharacterType.Items.AddRange(new object[] {
            "select.def",
            "人物文件夹"});
            this.cboReadCharacterType.Location = new System.Drawing.Point(6, 425);
            this.cboReadCharacterType.Name = "cboReadCharacterType";
            this.cboReadCharacterType.Size = new System.Drawing.Size(208, 20);
            this.cboReadCharacterType.TabIndex = 8;
            this.ttpCommon.SetToolTip(this.cboReadCharacterType, "选择读取人物列表类型");
            this.cboReadCharacterType.SelectedIndexChanged += new System.EventHandler(this.cboReadCharacterType_SelectedIndexChanged);
            // 
            // btnSearchDown
            // 
            this.btnSearchDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDown.Location = new System.Drawing.Point(162, 19);
            this.btnSearchDown.Name = "btnSearchDown";
            this.btnSearchDown.Size = new System.Drawing.Size(23, 23);
            this.btnSearchDown.TabIndex = 2;
            this.btnSearchDown.Text = "∨";
            this.ttpCommon.SetToolTip(this.btnSearchDown, "向下搜索");
            this.btnSearchDown.UseVisualStyleBackColor = true;
            this.btnSearchDown.Click += new System.EventHandler(this.btnSearchDown_Click);
            // 
            // btnSearchUp
            // 
            this.btnSearchUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchUp.Location = new System.Drawing.Point(138, 19);
            this.btnSearchUp.Name = "btnSearchUp";
            this.btnSearchUp.Size = new System.Drawing.Size(23, 23);
            this.btnSearchUp.TabIndex = 1;
            this.btnSearchUp.Text = "∧";
            this.ttpCommon.SetToolTip(this.btnSearchUp, "向上搜索");
            this.btnSearchUp.UseVisualStyleBackColor = true;
            this.btnSearchUp.Click += new System.EventHandler(this.btnSearchUp_Click);
            // 
            // chkAutoSort
            // 
            this.chkAutoSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoSort.AutoSize = true;
            this.chkAutoSort.Location = new System.Drawing.Point(142, 400);
            this.chkAutoSort.Name = "chkAutoSort";
            this.chkAutoSort.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSort.TabIndex = 7;
            this.chkAutoSort.Text = "自动排序";
            this.ttpCommon.SetToolTip(this.chkAutoSort, "按照人物名称自动排序");
            this.chkAutoSort.UseVisualStyleBackColor = true;
            this.chkAutoSort.CheckedChanged += new System.EventHandler(this.chkAutoSort_CheckedChanged);
            // 
            // btnSearchAll
            // 
            this.btnSearchAll.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchAll.Location = new System.Drawing.Point(186, 19);
            this.btnSearchAll.Name = "btnSearchAll";
            this.btnSearchAll.Size = new System.Drawing.Size(28, 23);
            this.btnSearchAll.TabIndex = 3;
            this.btnSearchAll.Text = "All";
            this.ttpCommon.SetToolTip(this.btnSearchAll, "全部搜索");
            this.btnSearchAll.UseVisualStyleBackColor = true;
            this.btnSearchAll.Click += new System.EventHandler(this.btnSearchAll_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiApp,
            this.tsmiEdit,
            this.tsmiHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(559, 25);
            this.mnuMain.TabIndex = 9;
            // 
            // tsmiApp
            // 
            this.tsmiApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetSystemDefPath,
            this.tsmiSetSelectDefPath,
            this.tsmiReload,
            this.tssTsmiApp1,
            this.tsmiLaunchMugenExe,
            this.tsmiSetting});
            this.tsmiApp.Name = "tsmiApp";
            this.tsmiApp.Size = new System.Drawing.Size(60, 21);
            this.tsmiApp.Text = "程序(&A)";
            // 
            // tsmiSetSystemDefPath
            // 
            this.tsmiSetSystemDefPath.Name = "tsmiSetSystemDefPath";
            this.tsmiSetSystemDefPath.Size = new System.Drawing.Size(220, 22);
            this.tsmiSetSystemDefPath.Text = "选择system.def文件(&T)";
            this.tsmiSetSystemDefPath.Click += new System.EventHandler(this.tsmiSetSystemDefPath_Click);
            // 
            // tsmiSetSelectDefPath
            // 
            this.tsmiSetSelectDefPath.Name = "tsmiSetSelectDefPath";
            this.tsmiSetSelectDefPath.Size = new System.Drawing.Size(220, 22);
            this.tsmiSetSelectDefPath.Text = "选择select.def文件(&L)";
            this.tsmiSetSelectDefPath.Click += new System.EventHandler(this.tsmiSetSelectDefPath_Click);
            // 
            // tsmiReload
            // 
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiReload.Size = new System.Drawing.Size(220, 22);
            this.tsmiReload.Text = "重新载入";
            this.tsmiReload.Click += new System.EventHandler(this.tsmiReload_Click);
            // 
            // tssTsmiApp1
            // 
            this.tssTsmiApp1.Name = "tssTsmiApp1";
            this.tssTsmiApp1.Size = new System.Drawing.Size(217, 6);
            // 
            // tsmiLaunchMugenExe
            // 
            this.tsmiLaunchMugenExe.Name = "tsmiLaunchMugenExe";
            this.tsmiLaunchMugenExe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.tsmiLaunchMugenExe.Size = new System.Drawing.Size(220, 22);
            this.tsmiLaunchMugenExe.Text = "运行MUGEN程序";
            this.tsmiLaunchMugenExe.Click += new System.EventHandler(this.tsmiLaunchMugenExe_Click);
            // 
            // tsmiSetting
            // 
            this.tsmiSetting.Name = "tsmiSetting";
            this.tsmiSetting.Size = new System.Drawing.Size(220, 22);
            this.tsmiSetting.Text = "设置(&S)";
            this.tsmiSetting.Click += new System.EventHandler(this.tsmiSetting_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenSelectDef,
            this.tsmiOpenSystemDef,
            this.tsmiOpenMugenCfg});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(59, 21);
            this.tsmiEdit.Text = "编辑(&E)";
            // 
            // tsmiOpenSelectDef
            // 
            this.tsmiOpenSelectDef.Name = "tsmiOpenSelectDef";
            this.tsmiOpenSelectDef.Size = new System.Drawing.Size(205, 22);
            this.tsmiOpenSelectDef.Text = "打开select.def文件(&S)";
            this.tsmiOpenSelectDef.Click += new System.EventHandler(this.tsmiOpenSelectDef_Click);
            // 
            // tsmiOpenSystemDef
            // 
            this.tsmiOpenSystemDef.Name = "tsmiOpenSystemDef";
            this.tsmiOpenSystemDef.Size = new System.Drawing.Size(205, 22);
            this.tsmiOpenSystemDef.Text = "打开system.def文件(&T)";
            this.tsmiOpenSystemDef.Click += new System.EventHandler(this.tsmiOpenSystemDef_Click);
            // 
            // tsmiOpenMugenCfg
            // 
            this.tsmiOpenMugenCfg.Name = "tsmiOpenMugenCfg";
            this.tsmiOpenMugenCfg.Size = new System.Drawing.Size(205, 22);
            this.tsmiOpenMugenCfg.Text = "打开mugen.cfg文件(&M)";
            this.tsmiOpenMugenCfg.Click += new System.EventHandler(this.tsmiOpenMugenCfg_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(61, 21);
            this.tsmiHelp.Text = "帮助(&H)";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(116, 22);
            this.tsmiAbout.Text = "关于(&A)";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageCharacter);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(559, 526);
            this.tabMain.TabIndex = 0;
            // 
            // pageCharacter
            // 
            this.pageCharacter.AllowDrop = true;
            this.pageCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.pageCharacter.Controls.Add(this.grpDefPath);
            this.pageCharacter.Controls.Add(this.btnRestore);
            this.pageCharacter.Controls.Add(this.btnBackup);
            this.pageCharacter.Controls.Add(this.btnReset);
            this.pageCharacter.Controls.Add(this.btnModify);
            this.pageCharacter.Controls.Add(this.grpPal);
            this.pageCharacter.Controls.Add(this.grpProperty);
            this.pageCharacter.Controls.Add(this.grpChars);
            this.pageCharacter.Location = new System.Drawing.Point(4, 22);
            this.pageCharacter.Name = "pageCharacter";
            this.pageCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.pageCharacter.Size = new System.Drawing.Size(551, 500);
            this.pageCharacter.TabIndex = 0;
            this.pageCharacter.Text = "人物属性";
            this.ttpCommon.SetToolTip(this.pageCharacter, "可将人物def文件拖拽至此处");
            this.pageCharacter.DragDrop += new System.Windows.Forms.DragEventHandler(this.pageCharacter_DragDrop);
            this.pageCharacter.DragEnter += new System.Windows.Forms.DragEventHandler(this.pageCharacter_DragEnter);
            // 
            // grpDefPath
            // 
            this.grpDefPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDefPath.Controls.Add(this.lblDefPath);
            this.grpDefPath.Location = new System.Drawing.Point(234, 6);
            this.grpDefPath.Name = "grpDefPath";
            this.grpDefPath.Size = new System.Drawing.Size(307, 37);
            this.grpDefPath.TabIndex = 1;
            this.grpDefPath.TabStop = false;
            this.grpDefPath.Text = "人物配置文件";
            // 
            // lblDefPath
            // 
            this.lblDefPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDefPath.AutoEllipsis = true;
            this.lblDefPath.Location = new System.Drawing.Point(6, 17);
            this.lblDefPath.Name = "lblDefPath";
            this.lblDefPath.Size = new System.Drawing.Size(295, 12);
            this.lblDefPath.TabIndex = 0;
            // 
            // grpPal
            // 
            this.grpPal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPal.Controls.Add(this.dgvPal);
            this.grpPal.Location = new System.Drawing.Point(234, 242);
            this.grpPal.Name = "grpPal";
            this.grpPal.Size = new System.Drawing.Size(307, 214);
            this.grpPal.TabIndex = 3;
            this.grpPal.TabStop = false;
            this.grpPal.Text = "色表设置";
            // 
            // dgvPal
            // 
            this.dgvPal.AllowUserToAddRows = false;
            this.dgvPal.AllowUserToDeleteRows = false;
            this.dgvPal.AllowUserToResizeRows = false;
            this.dgvPal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PalNo,
            this.PalVal});
            this.dgvPal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPal.Location = new System.Drawing.Point(3, 17);
            this.dgvPal.Name = "dgvPal";
            this.dgvPal.RowHeadersVisible = false;
            this.dgvPal.RowTemplate.Height = 23;
            this.dgvPal.Size = new System.Drawing.Size(301, 194);
            this.dgvPal.TabIndex = 0;
            this.dgvPal.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPal_EditingControlShowing);
            // 
            // PalNo
            // 
            this.PalNo.HeaderText = "No.";
            this.PalNo.Name = "PalNo";
            this.PalNo.ReadOnly = true;
            this.PalNo.Width = 60;
            // 
            // PalVal
            // 
            this.PalVal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PalVal.FillWeight = 184F;
            this.PalVal.HeaderText = "色表";
            this.PalVal.Name = "PalVal";
            // 
            // grpProperty
            // 
            this.grpProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProperty.Controls.Add(this.txtDefence);
            this.grpProperty.Controls.Add(this.lblDefence);
            this.grpProperty.Controls.Add(this.txtAttack);
            this.grpProperty.Controls.Add(this.lblAttack);
            this.grpProperty.Controls.Add(this.txtPower);
            this.grpProperty.Controls.Add(this.lblPower);
            this.grpProperty.Controls.Add(this.txtLife);
            this.grpProperty.Controls.Add(this.lblLife);
            this.grpProperty.Controls.Add(this.txtDisplayName);
            this.grpProperty.Controls.Add(this.lblDisplayName);
            this.grpProperty.Controls.Add(this.txtName);
            this.grpProperty.Controls.Add(this.lblName);
            this.grpProperty.Location = new System.Drawing.Point(234, 49);
            this.grpProperty.Name = "grpProperty";
            this.grpProperty.Size = new System.Drawing.Size(307, 187);
            this.grpProperty.TabIndex = 2;
            this.grpProperty.TabStop = false;
            this.grpProperty.Text = "人物属性设置";
            // 
            // txtDefence
            // 
            this.txtDefence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefence.Location = new System.Drawing.Point(61, 128);
            this.txtDefence.MaxLength = 10;
            this.txtDefence.Name = "txtDefence";
            this.txtDefence.Size = new System.Drawing.Size(240, 21);
            this.txtDefence.TabIndex = 5;
            this.txtDefence.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblDefence
            // 
            this.lblDefence.AutoSize = true;
            this.lblDefence.Location = new System.Drawing.Point(6, 131);
            this.lblDefence.Name = "lblDefence";
            this.lblDefence.Size = new System.Drawing.Size(41, 12);
            this.lblDefence.TabIndex = 0;
            this.lblDefence.Text = "防御力";
            // 
            // txtAttack
            // 
            this.txtAttack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttack.Location = new System.Drawing.Point(61, 101);
            this.txtAttack.MaxLength = 10;
            this.txtAttack.Name = "txtAttack";
            this.txtAttack.Size = new System.Drawing.Size(240, 21);
            this.txtAttack.TabIndex = 4;
            this.txtAttack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblAttack
            // 
            this.lblAttack.AutoSize = true;
            this.lblAttack.Location = new System.Drawing.Point(6, 104);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(41, 12);
            this.lblAttack.TabIndex = 0;
            this.lblAttack.Text = "攻击力";
            // 
            // txtPower
            // 
            this.txtPower.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPower.Location = new System.Drawing.Point(61, 155);
            this.txtPower.MaxLength = 10;
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(240, 21);
            this.txtPower.TabIndex = 6;
            this.txtPower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Location = new System.Drawing.Point(6, 158);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(41, 12);
            this.lblPower.TabIndex = 0;
            this.lblPower.Text = "气上限";
            // 
            // txtLife
            // 
            this.txtLife.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLife.Location = new System.Drawing.Point(61, 74);
            this.txtLife.MaxLength = 10;
            this.txtLife.Name = "txtLife";
            this.txtLife.Size = new System.Drawing.Size(240, 21);
            this.txtLife.TabIndex = 3;
            this.txtLife.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(6, 77);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(41, 12);
            this.lblLife.TabIndex = 0;
            this.lblLife.Text = "生命值";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.Location = new System.Drawing.Point(61, 47);
            this.txtDisplayName.MaxLength = 255;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(240, 21);
            this.txtDisplayName.TabIndex = 2;
            this.txtDisplayName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 50);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(41, 12);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "显示名";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(61, 20);
            this.txtName.MaxLength = 255;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 21);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textProperty_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 23);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(29, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "名称";
            // 
            // grpChars
            // 
            this.grpChars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpChars.Controls.Add(this.btnSearchAll);
            this.grpChars.Controls.Add(this.cboReadCharacterType);
            this.grpChars.Controls.Add(this.btnSearchDown);
            this.grpChars.Controls.Add(this.btnSearchUp);
            this.grpChars.Controls.Add(this.txtKeyword);
            this.grpChars.Controls.Add(this.btnSelectInvert);
            this.grpChars.Controls.Add(this.btnSelectAll);
            this.grpChars.Controls.Add(this.chkAutoSort);
            this.grpChars.Controls.Add(this.lstCharacterList);
            this.grpChars.Controls.Add(this.btnRefreshCharacterList);
            this.grpChars.Location = new System.Drawing.Point(8, 6);
            this.grpChars.Name = "grpChars";
            this.grpChars.Size = new System.Drawing.Size(220, 485);
            this.grpChars.TabIndex = 0;
            this.grpChars.TabStop = false;
            this.grpChars.Text = "人物列表";
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 20);
            this.txtKeyword.MaxLength = 255;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(126, 21);
            this.txtKeyword.TabIndex = 0;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSelectInvert
            // 
            this.btnSelectInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectInvert.Location = new System.Drawing.Point(49, 396);
            this.btnSelectInvert.Name = "btnSelectInvert";
            this.btnSelectInvert.Size = new System.Drawing.Size(42, 23);
            this.btnSelectInvert.TabIndex = 6;
            this.btnSelectInvert.Text = "反选";
            this.btnSelectInvert.UseVisualStyleBackColor = true;
            this.btnSelectInvert.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 396);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(42, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lstCharacterList
            // 
            this.lstCharacterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCharacterList.ContextMenuStrip = this.ctxmnuCharacterList;
            this.lstCharacterList.FormattingEnabled = true;
            this.lstCharacterList.HorizontalScrollbar = true;
            this.lstCharacterList.ItemHeight = 12;
            this.lstCharacterList.Location = new System.Drawing.Point(6, 53);
            this.lstCharacterList.Name = "lstCharacterList";
            this.lstCharacterList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstCharacterList.Size = new System.Drawing.Size(208, 340);
            this.lstCharacterList.TabIndex = 4;
            this.lstCharacterList.SelectedIndexChanged += new System.EventHandler(this.lstCharacterList_SelectedIndexChanged);
            // 
            // btnRefreshCharacterList
            // 
            this.btnRefreshCharacterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCharacterList.Location = new System.Drawing.Point(6, 451);
            this.btnRefreshCharacterList.Name = "btnRefreshCharacterList";
            this.btnRefreshCharacterList.Size = new System.Drawing.Size(208, 28);
            this.btnRefreshCharacterList.TabIndex = 9;
            this.btnRefreshCharacterList.Text = "刷新人物列表";
            this.btnRefreshCharacterList.UseVisualStyleBackColor = true;
            this.btnRefreshCharacterList.Click += new System.EventHandler(this.btnRefreshCharacterList_Click);
            // 
            // fswCharacterCns
            // 
            this.fswCharacterCns.EnableRaisingEvents = true;
            this.fswCharacterCns.Filter = "*.cns";
            this.fswCharacterCns.IncludeSubdirectories = true;
            this.fswCharacterCns.SynchronizingObject = this;
            this.fswCharacterCns.Changed += new System.IO.FileSystemEventHandler(this.fswCharacterCns_Changed);
            // 
            // ofdDefPath
            // 
            this.ofdDefPath.FileName = "*.def";
            this.ofdDefPath.Filter = "def文件|*.def";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 551);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M.U.G.E.N人物设置";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ctxmnuCharacterList.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageCharacter.ResumeLayout(false);
            this.grpDefPath.ResumeLayout(false);
            this.grpPal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPal)).EndInit();
            this.grpProperty.ResumeLayout(false);
            this.grpProperty.PerformLayout();
            this.grpChars.ResumeLayout(false);
            this.grpChars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswCharacterCns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxmnuCharacterList;
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenDefFile;
        private System.Windows.Forms.ToolTip ttpCommon;
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenDefDir;
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenCnsFile;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiApp;
        private System.Windows.Forms.ToolStripMenuItem tsmiLaunchMugenExe;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiDeleteCharacter;
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiCopyDefPath;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage pageCharacter;
        private System.Windows.Forms.GroupBox grpDefPath;
        private System.Windows.Forms.Label lblDefPath;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.GroupBox grpPal;
        private System.Windows.Forms.DataGridView dgvPal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PalNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn PalVal;
        private System.Windows.Forms.GroupBox grpProperty;
        private System.Windows.Forms.TextBox txtDefence;
        private System.Windows.Forms.Label lblDefence;
        private System.Windows.Forms.TextBox txtAttack;
        private System.Windows.Forms.Label lblAttack;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtLife;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox grpChars;
        private System.Windows.Forms.ComboBox cboReadCharacterType;
        private System.Windows.Forms.Button btnSearchDown;
        private System.Windows.Forms.Button btnSearchUp;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSelectInvert;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.CheckBox chkAutoSort;
        private System.Windows.Forms.ListBox lstCharacterList;
        private System.Windows.Forms.Button btnRefreshCharacterList;
        private System.Windows.Forms.Button btnSearchAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSelectDef;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSystemDef;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenMugenCfg;
        private System.IO.FileSystemWatcher fswCharacterCns;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetSystemDefPath;
        private System.Windows.Forms.ToolStripSeparator tssTsmiApp1;
        private System.Windows.Forms.OpenFileDialog ofdDefPath;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetSelectDefPath;
    }
}

