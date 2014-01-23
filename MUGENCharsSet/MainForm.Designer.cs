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
            this.ctxTsmiAddCharacter = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiDeleteCharacter = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiConvertToWideScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxTsmiConvertToNormalScreen = new System.Windows.Forms.ToolStripMenuItem();
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
            this.pageCharacter = new System.Windows.Forms.TabPage();
            this.grpSprite = new System.Windows.Forms.GroupBox();
            this.cboSelectableActFileList = new System.Windows.Forms.ComboBox();
            this.lblSpriteVersion = new System.Windows.Forms.Label();
            this.picSpriteImage = new System.Windows.Forms.PictureBox();
            this.grpMugenInfo = new System.Windows.Forms.GroupBox();
            this.lblMugenInfo = new System.Windows.Forms.Label();
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
            this.grpCharacterList = new System.Windows.Forms.GroupBox();
            this.lblCharacterSelectCount = new System.Windows.Forms.Label();
            this.lblCharacterCount = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSelectInvert = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lstCharacterList = new System.Windows.Forms.ListBox();
            this.btnRefreshCharacterList = new System.Windows.Forms.Button();
            this.btnMugenCfgRestore = new System.Windows.Forms.Button();
            this.btnMugenCfgBackup = new System.Windows.Forms.Button();
            this.btnMugenCfgReset = new System.Windows.Forms.Button();
            this.btnMugenCfgModify = new System.Windows.Forms.Button();
            this.lblKeyPressStart = new System.Windows.Forms.Label();
            this.lblKeyPressZ = new System.Windows.Forms.Label();
            this.lblKeyPressY = new System.Windows.Forms.Label();
            this.lblKeyPressX = new System.Windows.Forms.Label();
            this.lblKeyPressC = new System.Windows.Forms.Label();
            this.lblKeyPressB = new System.Windows.Forms.Label();
            this.lblKeyPressA = new System.Windows.Forms.Label();
            this.lblKeyPressRight = new System.Windows.Forms.Label();
            this.lblKeyPressLeft = new System.Windows.Forms.Label();
            this.lblKeyPressCrouch = new System.Windows.Forms.Label();
            this.lblKeyPressJump = new System.Windows.Forms.Label();
            this.cboFullScreen = new System.Windows.Forms.ComboBox();
            this.cboRenderMode = new System.Windows.Forms.ComboBox();
            this.lblFullScreen = new System.Windows.Forms.Label();
            this.lblRenderMode = new System.Windows.Forms.Label();
            this.txtGameHeight = new System.Windows.Forms.TextBox();
            this.lblGameHeight = new System.Windows.Forms.Label();
            this.txtGameWidth = new System.Windows.Forms.TextBox();
            this.lblGameWidth = new System.Windows.Forms.Label();
            this.trbGameSpeed = new System.Windows.Forms.TrackBar();
            this.trbDifficulty = new System.Windows.Forms.TrackBar();
            this.cboTeamLoseOnKO = new System.Windows.Forms.ComboBox();
            this.lblTeamLoseOnKO = new System.Windows.Forms.Label();
            this.txtTeam1VS2Life = new System.Windows.Forms.TextBox();
            this.lblTeam1VS2Life = new System.Windows.Forms.Label();
            this.txtGameFrame = new System.Windows.Forms.TextBox();
            this.lblGameFrame = new System.Windows.Forms.Label();
            this.lblGameSpeed = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtMugenCfgLife = new System.Windows.Forms.TextBox();
            this.lblMugenCfgLife = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.cboP2Start = new System.Windows.Forms.ComboBox();
            this.cboP1Start = new System.Windows.Forms.ComboBox();
            this.cboP2Z = new System.Windows.Forms.ComboBox();
            this.cboP1Z = new System.Windows.Forms.ComboBox();
            this.cboP2Y = new System.Windows.Forms.ComboBox();
            this.cboP1Y = new System.Windows.Forms.ComboBox();
            this.cboP2X = new System.Windows.Forms.ComboBox();
            this.cboP1X = new System.Windows.Forms.ComboBox();
            this.cboP2C = new System.Windows.Forms.ComboBox();
            this.cboP1C = new System.Windows.Forms.ComboBox();
            this.cboP2B = new System.Windows.Forms.ComboBox();
            this.cboP1B = new System.Windows.Forms.ComboBox();
            this.cboP2A = new System.Windows.Forms.ComboBox();
            this.cboP1A = new System.Windows.Forms.ComboBox();
            this.cboP2Right = new System.Windows.Forms.ComboBox();
            this.cboP1Right = new System.Windows.Forms.ComboBox();
            this.cboP2Left = new System.Windows.Forms.ComboBox();
            this.cboP1Left = new System.Windows.Forms.ComboBox();
            this.cboP2Crouch = new System.Windows.Forms.ComboBox();
            this.cboP1Crouch = new System.Windows.Forms.ComboBox();
            this.cboP2Jump = new System.Windows.Forms.ComboBox();
            this.cboP1Jump = new System.Windows.Forms.ComboBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCharacterByDefOrArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeSystemDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeSelectDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeFightDefPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tssTsmiFiles1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLaunchMugenExe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSelectDef = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenSystemDef = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpenMugenCfg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageMugenCfgSetting = new System.Windows.Forms.TabPage();
            this.grpKeyPressSetting = new System.Windows.Forms.GroupBox();
            this.lblKeyPressP2 = new System.Windows.Forms.Label();
            this.lblKeyPressP1 = new System.Windows.Forms.Label();
            this.grpDisplaySetting = new System.Windows.Forms.GroupBox();
            this.grpBaseSetting = new System.Windows.Forms.GroupBox();
            this.lblMugenCfgLifePercent = new System.Windows.Forms.Label();
            this.lblTeam1VS2LifePercent = new System.Windows.Forms.Label();
            this.lblGameSpeedValue = new System.Windows.Forms.Label();
            this.lblDifficultyValue = new System.Windows.Forms.Label();
            this.fswCharacterCns = new System.IO.FileSystemWatcher();
            this.ofdDefPath = new System.Windows.Forms.OpenFileDialog();
            this.ofdAddCharacterPath = new System.Windows.Forms.OpenFileDialog();
            this.ctxmnuCharacterList.SuspendLayout();
            this.pageCharacter.SuspendLayout();
            this.grpSprite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteImage)).BeginInit();
            this.grpMugenInfo.SuspendLayout();
            this.grpDefPath.SuspendLayout();
            this.grpPal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPal)).BeginInit();
            this.grpProperty.SuspendLayout();
            this.grpCharacterList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbGameSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDifficulty)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.pageMugenCfgSetting.SuspendLayout();
            this.grpKeyPressSetting.SuspendLayout();
            this.grpDisplaySetting.SuspendLayout();
            this.grpBaseSetting.SuspendLayout();
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
            this.ctxTsmiAddCharacter,
            this.ctxTsmiDeleteCharacter,
            this.ctxTsmiConvertToWideScreen,
            this.ctxTsmiConvertToNormalScreen});
            this.ctxmnuCharacterList.Name = "contextMenuStrip1";
            this.ctxmnuCharacterList.Size = new System.Drawing.Size(213, 180);
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
            // ctxTsmiAddCharacter
            // 
            this.ctxTsmiAddCharacter.Name = "ctxTsmiAddCharacter";
            this.ctxTsmiAddCharacter.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ctxTsmiAddCharacter.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiAddCharacter.Text = "添加所选人物";
            this.ctxTsmiAddCharacter.Click += new System.EventHandler(this.ctxTsmiAddCharacter_Click);
            // 
            // ctxTsmiDeleteCharacter
            // 
            this.ctxTsmiDeleteCharacter.Name = "ctxTsmiDeleteCharacter";
            this.ctxTsmiDeleteCharacter.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.ctxTsmiDeleteCharacter.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiDeleteCharacter.Text = "删除所选人物";
            this.ctxTsmiDeleteCharacter.Click += new System.EventHandler(this.ctxTsmiDeleteCharacter_Click);
            // 
            // ctxTsmiConvertToWideScreen
            // 
            this.ctxTsmiConvertToWideScreen.Name = "ctxTsmiConvertToWideScreen";
            this.ctxTsmiConvertToWideScreen.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiConvertToWideScreen.Text = "转换为宽屏人物包(&W)";
            this.ctxTsmiConvertToWideScreen.Click += new System.EventHandler(this.ctxTsmiConvertToWideScreen_Click);
            // 
            // ctxTsmiConvertToNormalScreen
            // 
            this.ctxTsmiConvertToNormalScreen.Name = "ctxTsmiConvertToNormalScreen";
            this.ctxTsmiConvertToNormalScreen.Size = new System.Drawing.Size(212, 22);
            this.ctxTsmiConvertToNormalScreen.Text = "转换为普屏人物包(&N)";
            this.ctxTsmiConvertToNormalScreen.Click += new System.EventHandler(this.ctxTsmiConvertToNormalScreen_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRestore.Enabled = false;
            this.btnRestore.Location = new System.Drawing.Point(468, 462);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(72, 29);
            this.btnRestore.TabIndex = 9;
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
            this.btnBackup.TabIndex = 8;
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
            this.btnReset.TabIndex = 7;
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
            this.btnModify.TabIndex = 6;
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
            this.cboReadCharacterType.Location = new System.Drawing.Point(6, 381);
            this.cboReadCharacterType.Name = "cboReadCharacterType";
            this.cboReadCharacterType.Size = new System.Drawing.Size(130, 20);
            this.cboReadCharacterType.TabIndex = 9;
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
            this.chkAutoSort.Location = new System.Drawing.Point(142, 383);
            this.chkAutoSort.Name = "chkAutoSort";
            this.chkAutoSort.Size = new System.Drawing.Size(72, 16);
            this.chkAutoSort.TabIndex = 10;
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
            // pageCharacter
            // 
            this.pageCharacter.AllowDrop = true;
            this.pageCharacter.BackColor = System.Drawing.SystemColors.Control;
            this.pageCharacter.Controls.Add(this.grpSprite);
            this.pageCharacter.Controls.Add(this.grpMugenInfo);
            this.pageCharacter.Controls.Add(this.grpDefPath);
            this.pageCharacter.Controls.Add(this.btnRestore);
            this.pageCharacter.Controls.Add(this.btnBackup);
            this.pageCharacter.Controls.Add(this.btnReset);
            this.pageCharacter.Controls.Add(this.btnModify);
            this.pageCharacter.Controls.Add(this.grpPal);
            this.pageCharacter.Controls.Add(this.grpProperty);
            this.pageCharacter.Controls.Add(this.grpCharacterList);
            this.pageCharacter.Location = new System.Drawing.Point(4, 22);
            this.pageCharacter.Name = "pageCharacter";
            this.pageCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.pageCharacter.Size = new System.Drawing.Size(551, 500);
            this.pageCharacter.TabIndex = 0;
            this.pageCharacter.Text = "人物属性";
            this.ttpCommon.SetToolTip(this.pageCharacter, "可将单个或多个人物def文件或压缩包拖拽至此处");
            this.pageCharacter.DragDrop += new System.Windows.Forms.DragEventHandler(this.pageCharacter_DragDrop);
            this.pageCharacter.DragEnter += new System.Windows.Forms.DragEventHandler(this.pageCharacter_DragEnter);
            this.pageCharacter.Enter += new System.EventHandler(this.pageCharacter_Enter);
            // 
            // grpSprite
            // 
            this.grpSprite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSprite.Controls.Add(this.cboSelectableActFileList);
            this.grpSprite.Controls.Add(this.lblSpriteVersion);
            this.grpSprite.Controls.Add(this.picSpriteImage);
            this.grpSprite.Location = new System.Drawing.Point(418, 50);
            this.grpSprite.Name = "grpSprite";
            this.grpSprite.Size = new System.Drawing.Size(123, 187);
            this.grpSprite.TabIndex = 4;
            this.grpSprite.TabStop = false;
            this.grpSprite.Text = "人物模型";
            // 
            // cboSelectableActFileList
            // 
            this.cboSelectableActFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSelectableActFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectableActFileList.DropDownWidth = 200;
            this.cboSelectableActFileList.FormattingEnabled = true;
            this.cboSelectableActFileList.Location = new System.Drawing.Point(8, 161);
            this.cboSelectableActFileList.Name = "cboSelectableActFileList";
            this.cboSelectableActFileList.Size = new System.Drawing.Size(109, 20);
            this.cboSelectableActFileList.TabIndex = 2;
            this.ttpCommon.SetToolTip(this.cboSelectableActFileList, "预览使用指定色表文件的人物模型");
            this.cboSelectableActFileList.SelectedIndexChanged += new System.EventHandler(this.cboSelectableActFileList_SelectedIndexChanged);
            // 
            // lblSpriteVersion
            // 
            this.lblSpriteVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpriteVersion.Location = new System.Drawing.Point(6, 146);
            this.lblSpriteVersion.Name = "lblSpriteVersion";
            this.lblSpriteVersion.Size = new System.Drawing.Size(111, 12);
            this.lblSpriteVersion.TabIndex = 1;
            this.lblSpriteVersion.Text = "SFF版本：1.01";
            this.lblSpriteVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picSpriteImage
            // 
            this.picSpriteImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.picSpriteImage.Location = new System.Drawing.Point(3, 17);
            this.picSpriteImage.Name = "picSpriteImage";
            this.picSpriteImage.Size = new System.Drawing.Size(117, 126);
            this.picSpriteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSpriteImage.TabIndex = 0;
            this.picSpriteImage.TabStop = false;
            // 
            // grpMugenInfo
            // 
            this.grpMugenInfo.Controls.Add(this.lblMugenInfo);
            this.grpMugenInfo.Location = new System.Drawing.Point(8, 6);
            this.grpMugenInfo.Name = "grpMugenInfo";
            this.grpMugenInfo.Size = new System.Drawing.Size(220, 38);
            this.grpMugenInfo.TabIndex = 0;
            this.grpMugenInfo.TabStop = false;
            this.grpMugenInfo.Text = "MUGEN信息";
            // 
            // lblMugenInfo
            // 
            this.lblMugenInfo.AutoSize = true;
            this.lblMugenInfo.Location = new System.Drawing.Point(6, 17);
            this.lblMugenInfo.Name = "lblMugenInfo";
            this.lblMugenInfo.Size = new System.Drawing.Size(0, 12);
            this.lblMugenInfo.TabIndex = 0;
            // 
            // grpDefPath
            // 
            this.grpDefPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDefPath.Controls.Add(this.lblDefPath);
            this.grpDefPath.Location = new System.Drawing.Point(234, 6);
            this.grpDefPath.Name = "grpDefPath";
            this.grpDefPath.Size = new System.Drawing.Size(307, 38);
            this.grpDefPath.TabIndex = 2;
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
            this.grpPal.Location = new System.Drawing.Point(234, 243);
            this.grpPal.Name = "grpPal";
            this.grpPal.Size = new System.Drawing.Size(307, 213);
            this.grpPal.TabIndex = 5;
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
            this.dgvPal.Size = new System.Drawing.Size(301, 193);
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
            this.grpProperty.Location = new System.Drawing.Point(234, 50);
            this.grpProperty.Name = "grpProperty";
            this.grpProperty.Size = new System.Drawing.Size(178, 187);
            this.grpProperty.TabIndex = 3;
            this.grpProperty.TabStop = false;
            this.grpProperty.Text = "人物属性设置";
            this.ttpCommon.SetToolTip(this.grpProperty, "可将单个或多个人物def文件或压缩包拖拽至此处");
            // 
            // txtDefence
            // 
            this.txtDefence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefence.Location = new System.Drawing.Point(61, 128);
            this.txtDefence.MaxLength = 10;
            this.txtDefence.Name = "txtDefence";
            this.txtDefence.Size = new System.Drawing.Size(111, 21);
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
            this.txtAttack.Size = new System.Drawing.Size(111, 21);
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
            this.txtPower.Size = new System.Drawing.Size(111, 21);
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
            this.txtLife.Size = new System.Drawing.Size(111, 21);
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
            this.txtDisplayName.Size = new System.Drawing.Size(111, 21);
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
            this.txtName.Size = new System.Drawing.Size(111, 21);
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
            // grpCharacterList
            // 
            this.grpCharacterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpCharacterList.Controls.Add(this.lblCharacterSelectCount);
            this.grpCharacterList.Controls.Add(this.lblCharacterCount);
            this.grpCharacterList.Controls.Add(this.btnSearchAll);
            this.grpCharacterList.Controls.Add(this.cboReadCharacterType);
            this.grpCharacterList.Controls.Add(this.btnSearchDown);
            this.grpCharacterList.Controls.Add(this.btnSearchUp);
            this.grpCharacterList.Controls.Add(this.txtKeyword);
            this.grpCharacterList.Controls.Add(this.btnSelectInvert);
            this.grpCharacterList.Controls.Add(this.btnSelectAll);
            this.grpCharacterList.Controls.Add(this.chkAutoSort);
            this.grpCharacterList.Controls.Add(this.lstCharacterList);
            this.grpCharacterList.Controls.Add(this.btnRefreshCharacterList);
            this.grpCharacterList.Location = new System.Drawing.Point(8, 50);
            this.grpCharacterList.Name = "grpCharacterList";
            this.grpCharacterList.Size = new System.Drawing.Size(220, 441);
            this.grpCharacterList.TabIndex = 1;
            this.grpCharacterList.TabStop = false;
            this.grpCharacterList.Text = "人物列表";
            // 
            // lblCharacterSelectCount
            // 
            this.lblCharacterSelectCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacterSelectCount.Location = new System.Drawing.Point(87, 357);
            this.lblCharacterSelectCount.Name = "lblCharacterSelectCount";
            this.lblCharacterSelectCount.Size = new System.Drawing.Size(72, 18);
            this.lblCharacterSelectCount.TabIndex = 7;
            this.lblCharacterSelectCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCharacterCount
            // 
            this.lblCharacterCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCharacterCount.Location = new System.Drawing.Point(155, 357);
            this.lblCharacterCount.Name = "lblCharacterCount";
            this.lblCharacterCount.Size = new System.Drawing.Size(59, 18);
            this.lblCharacterCount.TabIndex = 8;
            this.lblCharacterCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(6, 20);
            this.txtKeyword.MaxLength = 255;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(126, 21);
            this.txtKeyword.TabIndex = 0;
            this.txtKeyword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKeyword_KeyDown);
            // 
            // btnSelectInvert
            // 
            this.btnSelectInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectInvert.Location = new System.Drawing.Point(44, 352);
            this.btnSelectInvert.Name = "btnSelectInvert";
            this.btnSelectInvert.Size = new System.Drawing.Size(37, 23);
            this.btnSelectInvert.TabIndex = 6;
            this.btnSelectInvert.Text = "反选";
            this.btnSelectInvert.UseVisualStyleBackColor = true;
            this.btnSelectInvert.Click += new System.EventHandler(this.btnSelectInvert_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 352);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(37, 23);
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
            this.lstCharacterList.Size = new System.Drawing.Size(208, 292);
            this.lstCharacterList.TabIndex = 4;
            this.lstCharacterList.SelectedIndexChanged += new System.EventHandler(this.lstCharacterList_SelectedIndexChanged);
            // 
            // btnRefreshCharacterList
            // 
            this.btnRefreshCharacterList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshCharacterList.Location = new System.Drawing.Point(6, 407);
            this.btnRefreshCharacterList.Name = "btnRefreshCharacterList";
            this.btnRefreshCharacterList.Size = new System.Drawing.Size(208, 28);
            this.btnRefreshCharacterList.TabIndex = 11;
            this.btnRefreshCharacterList.Text = "刷新人物列表";
            this.btnRefreshCharacterList.UseVisualStyleBackColor = true;
            this.btnRefreshCharacterList.Click += new System.EventHandler(this.btnRefreshCharacterList_Click);
            // 
            // btnMugenCfgRestore
            // 
            this.btnMugenCfgRestore.Enabled = false;
            this.btnMugenCfgRestore.Location = new System.Drawing.Point(335, 344);
            this.btnMugenCfgRestore.Name = "btnMugenCfgRestore";
            this.btnMugenCfgRestore.Size = new System.Drawing.Size(71, 29);
            this.btnMugenCfgRestore.TabIndex = 6;
            this.btnMugenCfgRestore.Text = "恢复";
            this.ttpCommon.SetToolTip(this.btnMugenCfgRestore, "快捷键：Ctrl+R");
            this.btnMugenCfgRestore.UseVisualStyleBackColor = true;
            this.btnMugenCfgRestore.Click += new System.EventHandler(this.btnMugenCfgRestore_Click);
            // 
            // btnMugenCfgBackup
            // 
            this.btnMugenCfgBackup.Enabled = false;
            this.btnMugenCfgBackup.Location = new System.Drawing.Point(258, 344);
            this.btnMugenCfgBackup.Name = "btnMugenCfgBackup";
            this.btnMugenCfgBackup.Size = new System.Drawing.Size(71, 29);
            this.btnMugenCfgBackup.TabIndex = 5;
            this.btnMugenCfgBackup.Text = "备份";
            this.ttpCommon.SetToolTip(this.btnMugenCfgBackup, "快捷键：Ctrl+B");
            this.btnMugenCfgBackup.UseVisualStyleBackColor = true;
            this.btnMugenCfgBackup.Click += new System.EventHandler(this.btnMugenCfgBackup_Click);
            // 
            // btnMugenCfgReset
            // 
            this.btnMugenCfgReset.Enabled = false;
            this.btnMugenCfgReset.Location = new System.Drawing.Point(181, 344);
            this.btnMugenCfgReset.Name = "btnMugenCfgReset";
            this.btnMugenCfgReset.Size = new System.Drawing.Size(71, 29);
            this.btnMugenCfgReset.TabIndex = 4;
            this.btnMugenCfgReset.Text = "重置";
            this.ttpCommon.SetToolTip(this.btnMugenCfgReset, "快捷键：Ctrl+S");
            this.btnMugenCfgReset.UseVisualStyleBackColor = true;
            this.btnMugenCfgReset.Click += new System.EventHandler(this.btnMugenCfgReset_Click);
            // 
            // btnMugenCfgModify
            // 
            this.btnMugenCfgModify.Enabled = false;
            this.btnMugenCfgModify.Location = new System.Drawing.Point(104, 344);
            this.btnMugenCfgModify.Name = "btnMugenCfgModify";
            this.btnMugenCfgModify.Size = new System.Drawing.Size(71, 29);
            this.btnMugenCfgModify.TabIndex = 3;
            this.btnMugenCfgModify.Text = "修改";
            this.ttpCommon.SetToolTip(this.btnMugenCfgModify, "快捷键：Ctrl+Enter");
            this.btnMugenCfgModify.UseVisualStyleBackColor = true;
            this.btnMugenCfgModify.Click += new System.EventHandler(this.btnMugenCfgModify_Click);
            // 
            // lblKeyPressStart
            // 
            this.lblKeyPressStart.AutoSize = true;
            this.lblKeyPressStart.Location = new System.Drawing.Point(6, 305);
            this.lblKeyPressStart.Name = "lblKeyPressStart";
            this.lblKeyPressStart.Size = new System.Drawing.Size(35, 12);
            this.lblKeyPressStart.TabIndex = 32;
            this.lblKeyPressStart.Text = "START";
            this.ttpCommon.SetToolTip(this.lblKeyPressStart, "开始键");
            // 
            // lblKeyPressZ
            // 
            this.lblKeyPressZ.AutoSize = true;
            this.lblKeyPressZ.Location = new System.Drawing.Point(6, 278);
            this.lblKeyPressZ.Name = "lblKeyPressZ";
            this.lblKeyPressZ.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressZ.TabIndex = 29;
            this.lblKeyPressZ.Text = "Z";
            this.ttpCommon.SetToolTip(this.lblKeyPressZ, "热键2");
            // 
            // lblKeyPressY
            // 
            this.lblKeyPressY.AutoSize = true;
            this.lblKeyPressY.Location = new System.Drawing.Point(6, 251);
            this.lblKeyPressY.Name = "lblKeyPressY";
            this.lblKeyPressY.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressY.TabIndex = 26;
            this.lblKeyPressY.Text = "Y";
            this.ttpCommon.SetToolTip(this.lblKeyPressY, "重拳");
            // 
            // lblKeyPressX
            // 
            this.lblKeyPressX.AutoSize = true;
            this.lblKeyPressX.Location = new System.Drawing.Point(6, 224);
            this.lblKeyPressX.Name = "lblKeyPressX";
            this.lblKeyPressX.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressX.TabIndex = 23;
            this.lblKeyPressX.Text = "X";
            this.ttpCommon.SetToolTip(this.lblKeyPressX, "轻拳");
            // 
            // lblKeyPressC
            // 
            this.lblKeyPressC.AutoSize = true;
            this.lblKeyPressC.Location = new System.Drawing.Point(6, 197);
            this.lblKeyPressC.Name = "lblKeyPressC";
            this.lblKeyPressC.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressC.TabIndex = 20;
            this.lblKeyPressC.Text = "C";
            this.ttpCommon.SetToolTip(this.lblKeyPressC, "热键1");
            // 
            // lblKeyPressB
            // 
            this.lblKeyPressB.AutoSize = true;
            this.lblKeyPressB.Location = new System.Drawing.Point(6, 170);
            this.lblKeyPressB.Name = "lblKeyPressB";
            this.lblKeyPressB.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressB.TabIndex = 17;
            this.lblKeyPressB.Text = "B";
            this.ttpCommon.SetToolTip(this.lblKeyPressB, "重脚");
            // 
            // lblKeyPressA
            // 
            this.lblKeyPressA.AutoSize = true;
            this.lblKeyPressA.Location = new System.Drawing.Point(6, 143);
            this.lblKeyPressA.Name = "lblKeyPressA";
            this.lblKeyPressA.Size = new System.Drawing.Size(11, 12);
            this.lblKeyPressA.TabIndex = 14;
            this.lblKeyPressA.Text = "A";
            this.ttpCommon.SetToolTip(this.lblKeyPressA, "轻脚");
            // 
            // lblKeyPressRight
            // 
            this.lblKeyPressRight.AutoSize = true;
            this.lblKeyPressRight.Location = new System.Drawing.Point(6, 116);
            this.lblKeyPressRight.Name = "lblKeyPressRight";
            this.lblKeyPressRight.Size = new System.Drawing.Size(35, 12);
            this.lblKeyPressRight.TabIndex = 11;
            this.lblKeyPressRight.Text = "RIGHT";
            this.ttpCommon.SetToolTip(this.lblKeyPressRight, "前");
            // 
            // lblKeyPressLeft
            // 
            this.lblKeyPressLeft.AutoSize = true;
            this.lblKeyPressLeft.Location = new System.Drawing.Point(6, 89);
            this.lblKeyPressLeft.Name = "lblKeyPressLeft";
            this.lblKeyPressLeft.Size = new System.Drawing.Size(29, 12);
            this.lblKeyPressLeft.TabIndex = 8;
            this.lblKeyPressLeft.Text = "LEFT";
            this.ttpCommon.SetToolTip(this.lblKeyPressLeft, "后");
            // 
            // lblKeyPressCrouch
            // 
            this.lblKeyPressCrouch.AutoSize = true;
            this.lblKeyPressCrouch.Location = new System.Drawing.Point(6, 62);
            this.lblKeyPressCrouch.Name = "lblKeyPressCrouch";
            this.lblKeyPressCrouch.Size = new System.Drawing.Size(29, 12);
            this.lblKeyPressCrouch.TabIndex = 5;
            this.lblKeyPressCrouch.Text = "DWON";
            this.ttpCommon.SetToolTip(this.lblKeyPressCrouch, "蹲");
            // 
            // lblKeyPressJump
            // 
            this.lblKeyPressJump.AutoSize = true;
            this.lblKeyPressJump.Location = new System.Drawing.Point(6, 35);
            this.lblKeyPressJump.Name = "lblKeyPressJump";
            this.lblKeyPressJump.Size = new System.Drawing.Size(17, 12);
            this.lblKeyPressJump.TabIndex = 2;
            this.lblKeyPressJump.Text = "UP";
            this.ttpCommon.SetToolTip(this.lblKeyPressJump, "跳");
            // 
            // cboFullScreen
            // 
            this.cboFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFullScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFullScreen.FormattingEnabled = true;
            this.cboFullScreen.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cboFullScreen.Location = new System.Drawing.Point(118, 94);
            this.cboFullScreen.Name = "cboFullScreen";
            this.cboFullScreen.Size = new System.Drawing.Size(123, 20);
            this.cboFullScreen.TabIndex = 7;
            this.ttpCommon.SetToolTip(this.cboFullScreen, "是否全屏");
            // 
            // cboRenderMode
            // 
            this.cboRenderMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRenderMode.FormattingEnabled = true;
            this.cboRenderMode.Items.AddRange(new object[] {
            "OpenGL",
            "OpenGLScreen",
            "DirectX",
            "System"});
            this.cboRenderMode.Location = new System.Drawing.Point(118, 68);
            this.cboRenderMode.Name = "cboRenderMode";
            this.cboRenderMode.Size = new System.Drawing.Size(123, 20);
            this.cboRenderMode.TabIndex = 5;
            this.ttpCommon.SetToolTip(this.cboRenderMode, "渲染模式");
            // 
            // lblFullScreen
            // 
            this.lblFullScreen.AutoSize = true;
            this.lblFullScreen.Location = new System.Drawing.Point(6, 97);
            this.lblFullScreen.Name = "lblFullScreen";
            this.lblFullScreen.Size = new System.Drawing.Size(65, 12);
            this.lblFullScreen.TabIndex = 6;
            this.lblFullScreen.Text = "FullScreen";
            this.ttpCommon.SetToolTip(this.lblFullScreen, "是否全屏");
            // 
            // lblRenderMode
            // 
            this.lblRenderMode.AutoSize = true;
            this.lblRenderMode.Location = new System.Drawing.Point(6, 71);
            this.lblRenderMode.Name = "lblRenderMode";
            this.lblRenderMode.Size = new System.Drawing.Size(65, 12);
            this.lblRenderMode.TabIndex = 4;
            this.lblRenderMode.Text = "RenderMode";
            this.ttpCommon.SetToolTip(this.lblRenderMode, "渲染模式");
            // 
            // txtGameHeight
            // 
            this.txtGameHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameHeight.Location = new System.Drawing.Point(118, 41);
            this.txtGameHeight.MaxLength = 10;
            this.txtGameHeight.Name = "txtGameHeight";
            this.txtGameHeight.Size = new System.Drawing.Size(123, 21);
            this.txtGameHeight.TabIndex = 3;
            this.ttpCommon.SetToolTip(this.txtGameHeight, "游戏屏幕分辨率高度");
            // 
            // lblGameHeight
            // 
            this.lblGameHeight.AutoSize = true;
            this.lblGameHeight.Location = new System.Drawing.Point(6, 44);
            this.lblGameHeight.Name = "lblGameHeight";
            this.lblGameHeight.Size = new System.Drawing.Size(65, 12);
            this.lblGameHeight.TabIndex = 2;
            this.lblGameHeight.Text = "GameHeight";
            this.ttpCommon.SetToolTip(this.lblGameHeight, "游戏屏幕分辨率高度");
            // 
            // txtGameWidth
            // 
            this.txtGameWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameWidth.Location = new System.Drawing.Point(118, 14);
            this.txtGameWidth.MaxLength = 10;
            this.txtGameWidth.Name = "txtGameWidth";
            this.txtGameWidth.Size = new System.Drawing.Size(123, 21);
            this.txtGameWidth.TabIndex = 1;
            this.ttpCommon.SetToolTip(this.txtGameWidth, "游戏屏幕分辨率宽度");
            // 
            // lblGameWidth
            // 
            this.lblGameWidth.AutoSize = true;
            this.lblGameWidth.Location = new System.Drawing.Point(6, 17);
            this.lblGameWidth.Name = "lblGameWidth";
            this.lblGameWidth.Size = new System.Drawing.Size(59, 12);
            this.lblGameWidth.TabIndex = 0;
            this.lblGameWidth.Text = "GameWidth";
            this.ttpCommon.SetToolTip(this.lblGameWidth, "游戏屏幕分辨率宽度");
            // 
            // trbGameSpeed
            // 
            this.trbGameSpeed.AutoSize = false;
            this.trbGameSpeed.LargeChange = 3;
            this.trbGameSpeed.Location = new System.Drawing.Point(117, 92);
            this.trbGameSpeed.Maximum = 9;
            this.trbGameSpeed.Minimum = -9;
            this.trbGameSpeed.Name = "trbGameSpeed";
            this.trbGameSpeed.Size = new System.Drawing.Size(107, 24);
            this.trbGameSpeed.TabIndex = 7;
            this.ttpCommon.SetToolTip(this.trbGameSpeed, "游戏运行速度");
            this.trbGameSpeed.ValueChanged += new System.EventHandler(this.trbGameSpeed_ValueChanged);
            // 
            // trbDifficulty
            // 
            this.trbDifficulty.AutoSize = false;
            this.trbDifficulty.LargeChange = 2;
            this.trbDifficulty.Location = new System.Drawing.Point(118, 10);
            this.trbDifficulty.Maximum = 8;
            this.trbDifficulty.Minimum = 1;
            this.trbDifficulty.Name = "trbDifficulty";
            this.trbDifficulty.Size = new System.Drawing.Size(106, 24);
            this.trbDifficulty.TabIndex = 1;
            this.ttpCommon.SetToolTip(this.trbDifficulty, "游戏难度");
            this.trbDifficulty.Value = 1;
            this.trbDifficulty.ValueChanged += new System.EventHandler(this.trbDifficulty_ValueChanged);
            // 
            // cboTeamLoseOnKO
            // 
            this.cboTeamLoseOnKO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboTeamLoseOnKO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeamLoseOnKO.FormattingEnabled = true;
            this.cboTeamLoseOnKO.Items.AddRange(new object[] {
            "否",
            "是"});
            this.cboTeamLoseOnKO.Location = new System.Drawing.Point(118, 176);
            this.cboTeamLoseOnKO.Name = "cboTeamLoseOnKO";
            this.cboTeamLoseOnKO.Size = new System.Drawing.Size(123, 20);
            this.cboTeamLoseOnKO.TabIndex = 13;
            this.ttpCommon.SetToolTip(this.cboTeamLoseOnKO, "组队模式中，如果2P输了，电脑控制的人物是否继续战斗");
            // 
            // lblTeamLoseOnKO
            // 
            this.lblTeamLoseOnKO.AutoSize = true;
            this.lblTeamLoseOnKO.Location = new System.Drawing.Point(6, 179);
            this.lblTeamLoseOnKO.Name = "lblTeamLoseOnKO";
            this.lblTeamLoseOnKO.Size = new System.Drawing.Size(83, 12);
            this.lblTeamLoseOnKO.TabIndex = 12;
            this.lblTeamLoseOnKO.Text = "Team.LoseOnKO";
            this.ttpCommon.SetToolTip(this.lblTeamLoseOnKO, "组队模式中，如果2P输了，电脑控制的人物是否继续战斗");
            // 
            // txtTeam1VS2Life
            // 
            this.txtTeam1VS2Life.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTeam1VS2Life.Location = new System.Drawing.Point(118, 149);
            this.txtTeam1VS2Life.MaxLength = 10;
            this.txtTeam1VS2Life.Name = "txtTeam1VS2Life";
            this.txtTeam1VS2Life.Size = new System.Drawing.Size(106, 21);
            this.txtTeam1VS2Life.TabIndex = 11;
            this.ttpCommon.SetToolTip(this.txtTeam1VS2Life, "假如我方以1人出场，对方2人的话，我方将以指定百分比的生命力出战");
            // 
            // lblTeam1VS2Life
            // 
            this.lblTeam1VS2Life.AutoSize = true;
            this.lblTeam1VS2Life.Location = new System.Drawing.Point(6, 152);
            this.lblTeam1VS2Life.Name = "lblTeam1VS2Life";
            this.lblTeam1VS2Life.Size = new System.Drawing.Size(83, 12);
            this.lblTeam1VS2Life.TabIndex = 10;
            this.lblTeam1VS2Life.Text = "Team.1VS2Life";
            this.ttpCommon.SetToolTip(this.lblTeam1VS2Life, "假如我方以1人出场，对方2人的话，我方将以指定百分比的生命力出战");
            // 
            // txtGameFrame
            // 
            this.txtGameFrame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGameFrame.Location = new System.Drawing.Point(118, 122);
            this.txtGameFrame.MaxLength = 10;
            this.txtGameFrame.Name = "txtGameFrame";
            this.txtGameFrame.Size = new System.Drawing.Size(123, 21);
            this.txtGameFrame.TabIndex = 9;
            this.ttpCommon.SetToolTip(this.txtGameFrame, "游戏的每秒运行的帧数，默认值：60");
            // 
            // lblGameFrame
            // 
            this.lblGameFrame.AutoSize = true;
            this.lblGameFrame.Location = new System.Drawing.Point(6, 125);
            this.lblGameFrame.Name = "lblGameFrame";
            this.lblGameFrame.Size = new System.Drawing.Size(95, 12);
            this.lblGameFrame.TabIndex = 8;
            this.lblGameFrame.Text = "GameSpeed(帧率)";
            this.ttpCommon.SetToolTip(this.lblGameFrame, "游戏的每秒运行的帧数，默认值：60");
            // 
            // lblGameSpeed
            // 
            this.lblGameSpeed.AutoSize = true;
            this.lblGameSpeed.Location = new System.Drawing.Point(6, 98);
            this.lblGameSpeed.Name = "lblGameSpeed";
            this.lblGameSpeed.Size = new System.Drawing.Size(59, 12);
            this.lblGameSpeed.TabIndex = 6;
            this.lblGameSpeed.Text = "GameSpeed";
            this.ttpCommon.SetToolTip(this.lblGameSpeed, "游戏运行速度");
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.Location = new System.Drawing.Point(118, 68);
            this.txtTime.MaxLength = 10;
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(123, 21);
            this.txtTime.TabIndex = 5;
            this.ttpCommon.SetToolTip(this.txtTime, "每个回合的时间，-1为无限时间");
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(6, 71);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 12);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Time";
            this.ttpCommon.SetToolTip(this.lblTime, "每个回合的时间，-1为无限时间");
            // 
            // txtMugenCfgLife
            // 
            this.txtMugenCfgLife.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMugenCfgLife.Location = new System.Drawing.Point(118, 40);
            this.txtMugenCfgLife.MaxLength = 10;
            this.txtMugenCfgLife.Name = "txtMugenCfgLife";
            this.txtMugenCfgLife.Size = new System.Drawing.Size(106, 21);
            this.txtMugenCfgLife.TabIndex = 3;
            this.ttpCommon.SetToolTip(this.txtMugenCfgLife, "游戏中人物生命力的百分比，默认值：100");
            // 
            // lblMugenCfgLife
            // 
            this.lblMugenCfgLife.AutoSize = true;
            this.lblMugenCfgLife.Location = new System.Drawing.Point(6, 43);
            this.lblMugenCfgLife.Name = "lblMugenCfgLife";
            this.lblMugenCfgLife.Size = new System.Drawing.Size(29, 12);
            this.lblMugenCfgLife.TabIndex = 2;
            this.lblMugenCfgLife.Text = "Life";
            this.ttpCommon.SetToolTip(this.lblMugenCfgLife, "游戏中人物生命力的百分比，默认值：100");
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(6, 17);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(65, 12);
            this.lblDifficulty.TabIndex = 0;
            this.lblDifficulty.Text = "Difficulty";
            this.ttpCommon.SetToolTip(this.lblDifficulty, "游戏难度");
            // 
            // cboP2Start
            // 
            this.cboP2Start.FormattingEnabled = true;
            this.cboP2Start.Location = new System.Drawing.Point(145, 302);
            this.cboP2Start.MaxLength = 255;
            this.cboP2Start.Name = "cboP2Start";
            this.cboP2Start.Size = new System.Drawing.Size(86, 20);
            this.cboP2Start.TabIndex = 34;
            this.ttpCommon.SetToolTip(this.cboP2Start, "开始键");
            // 
            // cboP1Start
            // 
            this.cboP1Start.FormattingEnabled = true;
            this.cboP1Start.Location = new System.Drawing.Point(53, 302);
            this.cboP1Start.MaxLength = 255;
            this.cboP1Start.Name = "cboP1Start";
            this.cboP1Start.Size = new System.Drawing.Size(86, 20);
            this.cboP1Start.TabIndex = 33;
            this.ttpCommon.SetToolTip(this.cboP1Start, "开始键");
            // 
            // cboP2Z
            // 
            this.cboP2Z.FormattingEnabled = true;
            this.cboP2Z.Location = new System.Drawing.Point(145, 275);
            this.cboP2Z.MaxLength = 255;
            this.cboP2Z.Name = "cboP2Z";
            this.cboP2Z.Size = new System.Drawing.Size(86, 20);
            this.cboP2Z.TabIndex = 31;
            this.ttpCommon.SetToolTip(this.cboP2Z, "热键2");
            // 
            // cboP1Z
            // 
            this.cboP1Z.FormattingEnabled = true;
            this.cboP1Z.Location = new System.Drawing.Point(53, 275);
            this.cboP1Z.MaxLength = 255;
            this.cboP1Z.Name = "cboP1Z";
            this.cboP1Z.Size = new System.Drawing.Size(86, 20);
            this.cboP1Z.TabIndex = 30;
            this.ttpCommon.SetToolTip(this.cboP1Z, "热键2");
            // 
            // cboP2Y
            // 
            this.cboP2Y.FormattingEnabled = true;
            this.cboP2Y.Location = new System.Drawing.Point(145, 248);
            this.cboP2Y.MaxLength = 255;
            this.cboP2Y.Name = "cboP2Y";
            this.cboP2Y.Size = new System.Drawing.Size(86, 20);
            this.cboP2Y.TabIndex = 28;
            this.ttpCommon.SetToolTip(this.cboP2Y, "重拳");
            // 
            // cboP1Y
            // 
            this.cboP1Y.FormattingEnabled = true;
            this.cboP1Y.Location = new System.Drawing.Point(53, 248);
            this.cboP1Y.MaxLength = 255;
            this.cboP1Y.Name = "cboP1Y";
            this.cboP1Y.Size = new System.Drawing.Size(86, 20);
            this.cboP1Y.TabIndex = 27;
            this.ttpCommon.SetToolTip(this.cboP1Y, "重拳");
            // 
            // cboP2X
            // 
            this.cboP2X.FormattingEnabled = true;
            this.cboP2X.Location = new System.Drawing.Point(145, 221);
            this.cboP2X.MaxLength = 255;
            this.cboP2X.Name = "cboP2X";
            this.cboP2X.Size = new System.Drawing.Size(86, 20);
            this.cboP2X.TabIndex = 25;
            this.ttpCommon.SetToolTip(this.cboP2X, "轻拳");
            // 
            // cboP1X
            // 
            this.cboP1X.FormattingEnabled = true;
            this.cboP1X.Location = new System.Drawing.Point(53, 221);
            this.cboP1X.MaxLength = 255;
            this.cboP1X.Name = "cboP1X";
            this.cboP1X.Size = new System.Drawing.Size(86, 20);
            this.cboP1X.TabIndex = 24;
            this.ttpCommon.SetToolTip(this.cboP1X, "轻拳");
            // 
            // cboP2C
            // 
            this.cboP2C.FormattingEnabled = true;
            this.cboP2C.Location = new System.Drawing.Point(145, 194);
            this.cboP2C.MaxLength = 255;
            this.cboP2C.Name = "cboP2C";
            this.cboP2C.Size = new System.Drawing.Size(86, 20);
            this.cboP2C.TabIndex = 22;
            this.ttpCommon.SetToolTip(this.cboP2C, "热键1");
            // 
            // cboP1C
            // 
            this.cboP1C.FormattingEnabled = true;
            this.cboP1C.Location = new System.Drawing.Point(53, 194);
            this.cboP1C.MaxLength = 255;
            this.cboP1C.Name = "cboP1C";
            this.cboP1C.Size = new System.Drawing.Size(86, 20);
            this.cboP1C.TabIndex = 21;
            this.ttpCommon.SetToolTip(this.cboP1C, "热键1");
            // 
            // cboP2B
            // 
            this.cboP2B.FormattingEnabled = true;
            this.cboP2B.Location = new System.Drawing.Point(145, 167);
            this.cboP2B.MaxLength = 255;
            this.cboP2B.Name = "cboP2B";
            this.cboP2B.Size = new System.Drawing.Size(86, 20);
            this.cboP2B.TabIndex = 19;
            this.ttpCommon.SetToolTip(this.cboP2B, "重脚");
            // 
            // cboP1B
            // 
            this.cboP1B.FormattingEnabled = true;
            this.cboP1B.Location = new System.Drawing.Point(53, 167);
            this.cboP1B.MaxLength = 255;
            this.cboP1B.Name = "cboP1B";
            this.cboP1B.Size = new System.Drawing.Size(86, 20);
            this.cboP1B.TabIndex = 18;
            this.ttpCommon.SetToolTip(this.cboP1B, "重脚");
            // 
            // cboP2A
            // 
            this.cboP2A.FormattingEnabled = true;
            this.cboP2A.Location = new System.Drawing.Point(145, 140);
            this.cboP2A.MaxLength = 255;
            this.cboP2A.Name = "cboP2A";
            this.cboP2A.Size = new System.Drawing.Size(86, 20);
            this.cboP2A.TabIndex = 16;
            this.ttpCommon.SetToolTip(this.cboP2A, "轻脚");
            // 
            // cboP1A
            // 
            this.cboP1A.FormattingEnabled = true;
            this.cboP1A.Location = new System.Drawing.Point(53, 140);
            this.cboP1A.MaxLength = 255;
            this.cboP1A.Name = "cboP1A";
            this.cboP1A.Size = new System.Drawing.Size(86, 20);
            this.cboP1A.TabIndex = 15;
            this.ttpCommon.SetToolTip(this.cboP1A, "轻脚");
            // 
            // cboP2Right
            // 
            this.cboP2Right.FormattingEnabled = true;
            this.cboP2Right.Location = new System.Drawing.Point(145, 113);
            this.cboP2Right.MaxLength = 255;
            this.cboP2Right.Name = "cboP2Right";
            this.cboP2Right.Size = new System.Drawing.Size(86, 20);
            this.cboP2Right.TabIndex = 13;
            this.ttpCommon.SetToolTip(this.cboP2Right, "前");
            // 
            // cboP1Right
            // 
            this.cboP1Right.FormattingEnabled = true;
            this.cboP1Right.Location = new System.Drawing.Point(53, 113);
            this.cboP1Right.MaxLength = 255;
            this.cboP1Right.Name = "cboP1Right";
            this.cboP1Right.Size = new System.Drawing.Size(86, 20);
            this.cboP1Right.TabIndex = 12;
            this.ttpCommon.SetToolTip(this.cboP1Right, "前");
            // 
            // cboP2Left
            // 
            this.cboP2Left.FormattingEnabled = true;
            this.cboP2Left.Location = new System.Drawing.Point(145, 86);
            this.cboP2Left.MaxLength = 255;
            this.cboP2Left.Name = "cboP2Left";
            this.cboP2Left.Size = new System.Drawing.Size(86, 20);
            this.cboP2Left.TabIndex = 10;
            this.ttpCommon.SetToolTip(this.cboP2Left, "后");
            // 
            // cboP1Left
            // 
            this.cboP1Left.FormattingEnabled = true;
            this.cboP1Left.Location = new System.Drawing.Point(53, 86);
            this.cboP1Left.MaxLength = 255;
            this.cboP1Left.Name = "cboP1Left";
            this.cboP1Left.Size = new System.Drawing.Size(86, 20);
            this.cboP1Left.TabIndex = 9;
            this.ttpCommon.SetToolTip(this.cboP1Left, "后");
            // 
            // cboP2Crouch
            // 
            this.cboP2Crouch.FormattingEnabled = true;
            this.cboP2Crouch.Location = new System.Drawing.Point(145, 59);
            this.cboP2Crouch.MaxLength = 255;
            this.cboP2Crouch.Name = "cboP2Crouch";
            this.cboP2Crouch.Size = new System.Drawing.Size(86, 20);
            this.cboP2Crouch.TabIndex = 7;
            this.ttpCommon.SetToolTip(this.cboP2Crouch, "蹲");
            // 
            // cboP1Crouch
            // 
            this.cboP1Crouch.FormattingEnabled = true;
            this.cboP1Crouch.Location = new System.Drawing.Point(53, 59);
            this.cboP1Crouch.MaxLength = 255;
            this.cboP1Crouch.Name = "cboP1Crouch";
            this.cboP1Crouch.Size = new System.Drawing.Size(86, 20);
            this.cboP1Crouch.TabIndex = 6;
            this.ttpCommon.SetToolTip(this.cboP1Crouch, "蹲");
            // 
            // cboP2Jump
            // 
            this.cboP2Jump.FormattingEnabled = true;
            this.cboP2Jump.Location = new System.Drawing.Point(145, 32);
            this.cboP2Jump.MaxLength = 255;
            this.cboP2Jump.Name = "cboP2Jump";
            this.cboP2Jump.Size = new System.Drawing.Size(86, 20);
            this.cboP2Jump.TabIndex = 4;
            this.ttpCommon.SetToolTip(this.cboP2Jump, "跳");
            // 
            // cboP1Jump
            // 
            this.cboP1Jump.FormattingEnabled = true;
            this.cboP1Jump.Location = new System.Drawing.Point(53, 32);
            this.cboP1Jump.MaxLength = 255;
            this.cboP1Jump.Name = "cboP1Jump";
            this.cboP1Jump.Size = new System.Drawing.Size(86, 20);
            this.cboP1Jump.TabIndex = 3;
            this.ttpCommon.SetToolTip(this.cboP1Jump, "跳");
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFiles,
            this.tsmiEdit,
            this.tsmiHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(559, 25);
            this.mnuMain.TabIndex = 0;
            // 
            // tsmiFiles
            // 
            this.tsmiFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddCharacterByDefOrArchive,
            this.tsmiChangeSystemDefPath,
            this.tsmiChangeSelectDefPath,
            this.tsmiChangeFightDefPath,
            this.tsmiReload,
            this.tssTsmiFiles1,
            this.tsmiLaunchMugenExe,
            this.tsmiSetting});
            this.tsmiFiles.Name = "tsmiFiles";
            this.tsmiFiles.Size = new System.Drawing.Size(58, 21);
            this.tsmiFiles.Text = "文件(&F)";
            // 
            // tsmiAddCharacterByDefOrArchive
            // 
            this.tsmiAddCharacterByDefOrArchive.Name = "tsmiAddCharacterByDefOrArchive";
            this.tsmiAddCharacterByDefOrArchive.Size = new System.Drawing.Size(220, 22);
            this.tsmiAddCharacterByDefOrArchive.Text = "添加人物文件或压缩包(&A)";
            this.tsmiAddCharacterByDefOrArchive.Click += new System.EventHandler(this.tsmiAddCharacterByDefOrArchive_Click);
            // 
            // tsmiChangeSystemDefPath
            // 
            this.tsmiChangeSystemDefPath.Name = "tsmiChangeSystemDefPath";
            this.tsmiChangeSystemDefPath.Size = new System.Drawing.Size(220, 22);
            this.tsmiChangeSystemDefPath.Text = "更换system.def文件(&T)";
            this.tsmiChangeSystemDefPath.Click += new System.EventHandler(this.tsmiChangeSystemDefPath_Click);
            // 
            // tsmiChangeSelectDefPath
            // 
            this.tsmiChangeSelectDefPath.Name = "tsmiChangeSelectDefPath";
            this.tsmiChangeSelectDefPath.Size = new System.Drawing.Size(220, 22);
            this.tsmiChangeSelectDefPath.Text = "更换select.def文件(&L)";
            this.tsmiChangeSelectDefPath.Click += new System.EventHandler(this.tsmiChangeSelectDefPath_Click);
            // 
            // tsmiChangeFightDefPath
            // 
            this.tsmiChangeFightDefPath.Name = "tsmiChangeFightDefPath";
            this.tsmiChangeFightDefPath.Size = new System.Drawing.Size(220, 22);
            this.tsmiChangeFightDefPath.Text = "更换fight.def文件(&F)";
            this.tsmiChangeFightDefPath.Click += new System.EventHandler(this.tsmiChangeFightDefPath_Click);
            // 
            // tsmiReload
            // 
            this.tsmiReload.Name = "tsmiReload";
            this.tsmiReload.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiReload.Size = new System.Drawing.Size(220, 22);
            this.tsmiReload.Text = "重新载入";
            this.tsmiReload.Click += new System.EventHandler(this.tsmiReload_Click);
            // 
            // tssTsmiFiles1
            // 
            this.tssTsmiFiles1.Name = "tssTsmiFiles1";
            this.tssTsmiFiles1.Size = new System.Drawing.Size(217, 6);
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
            this.tabMain.Controls.Add(this.pageMugenCfgSetting);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(559, 526);
            this.tabMain.TabIndex = 1;
            // 
            // pageMugenCfgSetting
            // 
            this.pageMugenCfgSetting.BackColor = System.Drawing.SystemColors.Control;
            this.pageMugenCfgSetting.Controls.Add(this.btnMugenCfgRestore);
            this.pageMugenCfgSetting.Controls.Add(this.btnMugenCfgBackup);
            this.pageMugenCfgSetting.Controls.Add(this.btnMugenCfgReset);
            this.pageMugenCfgSetting.Controls.Add(this.btnMugenCfgModify);
            this.pageMugenCfgSetting.Controls.Add(this.grpKeyPressSetting);
            this.pageMugenCfgSetting.Controls.Add(this.grpDisplaySetting);
            this.pageMugenCfgSetting.Controls.Add(this.grpBaseSetting);
            this.pageMugenCfgSetting.Location = new System.Drawing.Point(4, 22);
            this.pageMugenCfgSetting.Name = "pageMugenCfgSetting";
            this.pageMugenCfgSetting.Padding = new System.Windows.Forms.Padding(3);
            this.pageMugenCfgSetting.Size = new System.Drawing.Size(551, 500);
            this.pageMugenCfgSetting.TabIndex = 1;
            this.pageMugenCfgSetting.Text = "主程序配置";
            this.pageMugenCfgSetting.Enter += new System.EventHandler(this.pageMugenCfgSetting_Enter);
            // 
            // grpKeyPressSetting
            // 
            this.grpKeyPressSetting.Controls.Add(this.cboP2Start);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Start);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Z);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Z);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Y);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Y);
            this.grpKeyPressSetting.Controls.Add(this.cboP2X);
            this.grpKeyPressSetting.Controls.Add(this.cboP1X);
            this.grpKeyPressSetting.Controls.Add(this.cboP2C);
            this.grpKeyPressSetting.Controls.Add(this.cboP1C);
            this.grpKeyPressSetting.Controls.Add(this.cboP2B);
            this.grpKeyPressSetting.Controls.Add(this.cboP1B);
            this.grpKeyPressSetting.Controls.Add(this.cboP2A);
            this.grpKeyPressSetting.Controls.Add(this.cboP1A);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Right);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Right);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Left);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Left);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Crouch);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Crouch);
            this.grpKeyPressSetting.Controls.Add(this.cboP2Jump);
            this.grpKeyPressSetting.Controls.Add(this.cboP1Jump);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressStart);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressZ);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressY);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressX);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressC);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressB);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressA);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressRight);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressLeft);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressCrouch);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressJump);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressP2);
            this.grpKeyPressSetting.Controls.Add(this.lblKeyPressP1);
            this.grpKeyPressSetting.Location = new System.Drawing.Point(261, 6);
            this.grpKeyPressSetting.Name = "grpKeyPressSetting";
            this.grpKeyPressSetting.Size = new System.Drawing.Size(238, 332);
            this.grpKeyPressSetting.TabIndex = 2;
            this.grpKeyPressSetting.TabStop = false;
            this.grpKeyPressSetting.Text = "按键设置";
            // 
            // lblKeyPressP2
            // 
            this.lblKeyPressP2.AutoSize = true;
            this.lblKeyPressP2.Location = new System.Drawing.Point(176, 17);
            this.lblKeyPressP2.Name = "lblKeyPressP2";
            this.lblKeyPressP2.Size = new System.Drawing.Size(17, 12);
            this.lblKeyPressP2.TabIndex = 1;
            this.lblKeyPressP2.Text = "2P";
            // 
            // lblKeyPressP1
            // 
            this.lblKeyPressP1.AutoSize = true;
            this.lblKeyPressP1.Location = new System.Drawing.Point(86, 17);
            this.lblKeyPressP1.Name = "lblKeyPressP1";
            this.lblKeyPressP1.Size = new System.Drawing.Size(17, 12);
            this.lblKeyPressP1.TabIndex = 0;
            this.lblKeyPressP1.Text = "1P";
            // 
            // grpDisplaySetting
            // 
            this.grpDisplaySetting.Controls.Add(this.cboFullScreen);
            this.grpDisplaySetting.Controls.Add(this.cboRenderMode);
            this.grpDisplaySetting.Controls.Add(this.lblFullScreen);
            this.grpDisplaySetting.Controls.Add(this.lblRenderMode);
            this.grpDisplaySetting.Controls.Add(this.txtGameHeight);
            this.grpDisplaySetting.Controls.Add(this.lblGameHeight);
            this.grpDisplaySetting.Controls.Add(this.txtGameWidth);
            this.grpDisplaySetting.Controls.Add(this.lblGameWidth);
            this.grpDisplaySetting.Location = new System.Drawing.Point(8, 216);
            this.grpDisplaySetting.Name = "grpDisplaySetting";
            this.grpDisplaySetting.Size = new System.Drawing.Size(247, 122);
            this.grpDisplaySetting.TabIndex = 1;
            this.grpDisplaySetting.TabStop = false;
            this.grpDisplaySetting.Text = "显示设置";
            // 
            // grpBaseSetting
            // 
            this.grpBaseSetting.Controls.Add(this.lblMugenCfgLifePercent);
            this.grpBaseSetting.Controls.Add(this.lblTeam1VS2LifePercent);
            this.grpBaseSetting.Controls.Add(this.lblGameSpeedValue);
            this.grpBaseSetting.Controls.Add(this.lblDifficultyValue);
            this.grpBaseSetting.Controls.Add(this.trbGameSpeed);
            this.grpBaseSetting.Controls.Add(this.trbDifficulty);
            this.grpBaseSetting.Controls.Add(this.cboTeamLoseOnKO);
            this.grpBaseSetting.Controls.Add(this.lblTeamLoseOnKO);
            this.grpBaseSetting.Controls.Add(this.txtTeam1VS2Life);
            this.grpBaseSetting.Controls.Add(this.lblTeam1VS2Life);
            this.grpBaseSetting.Controls.Add(this.txtGameFrame);
            this.grpBaseSetting.Controls.Add(this.lblGameFrame);
            this.grpBaseSetting.Controls.Add(this.lblGameSpeed);
            this.grpBaseSetting.Controls.Add(this.txtTime);
            this.grpBaseSetting.Controls.Add(this.lblTime);
            this.grpBaseSetting.Controls.Add(this.txtMugenCfgLife);
            this.grpBaseSetting.Controls.Add(this.lblMugenCfgLife);
            this.grpBaseSetting.Controls.Add(this.lblDifficulty);
            this.grpBaseSetting.Location = new System.Drawing.Point(8, 6);
            this.grpBaseSetting.Name = "grpBaseSetting";
            this.grpBaseSetting.Size = new System.Drawing.Size(247, 204);
            this.grpBaseSetting.TabIndex = 0;
            this.grpBaseSetting.TabStop = false;
            this.grpBaseSetting.Text = "基础设置";
            // 
            // lblMugenCfgLifePercent
            // 
            this.lblMugenCfgLifePercent.AutoSize = true;
            this.lblMugenCfgLifePercent.Location = new System.Drawing.Point(230, 43);
            this.lblMugenCfgLifePercent.Name = "lblMugenCfgLifePercent";
            this.lblMugenCfgLifePercent.Size = new System.Drawing.Size(11, 12);
            this.lblMugenCfgLifePercent.TabIndex = 3;
            this.lblMugenCfgLifePercent.Text = "%";
            // 
            // lblTeam1VS2LifePercent
            // 
            this.lblTeam1VS2LifePercent.AutoSize = true;
            this.lblTeam1VS2LifePercent.Location = new System.Drawing.Point(230, 152);
            this.lblTeam1VS2LifePercent.Name = "lblTeam1VS2LifePercent";
            this.lblTeam1VS2LifePercent.Size = new System.Drawing.Size(11, 12);
            this.lblTeam1VS2LifePercent.TabIndex = 11;
            this.lblTeam1VS2LifePercent.Text = "%";
            // 
            // lblGameSpeedValue
            // 
            this.lblGameSpeedValue.AutoSize = true;
            this.lblGameSpeedValue.Location = new System.Drawing.Point(224, 98);
            this.lblGameSpeedValue.Name = "lblGameSpeedValue";
            this.lblGameSpeedValue.Size = new System.Drawing.Size(0, 12);
            this.lblGameSpeedValue.TabIndex = 7;
            // 
            // lblDifficultyValue
            // 
            this.lblDifficultyValue.AutoSize = true;
            this.lblDifficultyValue.Location = new System.Drawing.Point(230, 17);
            this.lblDifficultyValue.Name = "lblDifficultyValue";
            this.lblDifficultyValue.Size = new System.Drawing.Size(0, 12);
            this.lblDifficultyValue.TabIndex = 1;
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
            this.ofdDefPath.Filter = "def文件|*.def";
            // 
            // ofdAddCharacterPath
            // 
            this.ofdAddCharacterPath.Filter = "压缩包文件|*.zip;*.rar;*.7z;*.tar;*.gz;*.bz2|人物def文件|*.def";
            this.ofdAddCharacterPath.Multiselect = true;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ctxmnuCharacterList.ResumeLayout(false);
            this.pageCharacter.ResumeLayout(false);
            this.grpSprite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSpriteImage)).EndInit();
            this.grpMugenInfo.ResumeLayout(false);
            this.grpMugenInfo.PerformLayout();
            this.grpDefPath.ResumeLayout(false);
            this.grpPal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPal)).EndInit();
            this.grpProperty.ResumeLayout(false);
            this.grpProperty.PerformLayout();
            this.grpCharacterList.ResumeLayout(false);
            this.grpCharacterList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbGameSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbDifficulty)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.pageMugenCfgSetting.ResumeLayout(false);
            this.grpKeyPressSetting.ResumeLayout(false);
            this.grpKeyPressSetting.PerformLayout();
            this.grpDisplaySetting.ResumeLayout(false);
            this.grpDisplaySetting.PerformLayout();
            this.grpBaseSetting.ResumeLayout(false);
            this.grpBaseSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswCharacterCns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>人物列表控件右键菜单</summary>
        private System.Windows.Forms.ContextMenuStrip ctxmnuCharacterList;
        /// <summary>打开人物def文件右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenDefFile;
        /// <summary>公共提示控件</summary>
        private System.Windows.Forms.ToolTip ttpCommon;
        /// <summary>打开人物文件夹右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenDefDir;
        /// <summary>打开人物cns文件右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiOpenCnsFile;
        /// <summary>主菜单</summary>
        private System.Windows.Forms.MenuStrip mnuMain;
        /// <summary>帮助菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        /// <summary>文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiFiles;
        /// <summary>运行MUGEN程序菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiLaunchMugenExe;
        /// <summary>关于菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        /// <summary>设置菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiSetting;
        /// <summary>删除所选人物右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiDeleteCharacter;
        /// <summary>复制所选人物def文件路径右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiCopyDefPath;
        /// <summary>主标签页控件</summary>
        private System.Windows.Forms.TabControl tabMain;
        /// <summary>人物标签页</summary>
        private System.Windows.Forms.TabPage pageCharacter;
        /// <summary>人物def文件路径组合框</summary>
        private System.Windows.Forms.GroupBox grpDefPath;
        /// <summary>人物def文件路径标签</summary>
        private System.Windows.Forms.Label lblDefPath;
        /// <summary>恢复按钮</summary>
        private System.Windows.Forms.Button btnRestore;
        /// <summary>备份按钮</summary>
        private System.Windows.Forms.Button btnBackup;
        /// <summary>重置按钮</summary>
        private System.Windows.Forms.Button btnReset;
        /// <summary>修改按钮</summary>
        private System.Windows.Forms.Button btnModify;
        /// <summary>色表组合框</summary>
        private System.Windows.Forms.GroupBox grpPal;
        /// <summary>色表网格数据控件</summary>
        private System.Windows.Forms.DataGridView dgvPal;
        /// <summary>色表配置项索引栏</summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn PalNo;
        /// <summary>色表配置值栏</summary>
        private System.Windows.Forms.DataGridViewComboBoxColumn PalVal;
        /// <summary>人物属性组合框</summary>
        private System.Windows.Forms.GroupBox grpProperty;
        /// <summary>防御力文本框</summary>
        private System.Windows.Forms.TextBox txtDefence;
        /// <summary>防御力标签</summary>
        private System.Windows.Forms.Label lblDefence;
        /// <summary>攻击力文本框</summary>
        private System.Windows.Forms.TextBox txtAttack;
        /// <summary>攻击力标签</summary>
        private System.Windows.Forms.Label lblAttack;
        /// <summary>气上限文本框</summary>
        private System.Windows.Forms.TextBox txtPower;
        /// <summary>气上限标签</summary>
        private System.Windows.Forms.Label lblPower;
        /// <summary>生命值文本框</summary>
        private System.Windows.Forms.TextBox txtLife;
        /// <summary>生命值标签</summary>
        private System.Windows.Forms.Label lblLife;
        /// <summary>显示名文本框</summary>
        private System.Windows.Forms.TextBox txtDisplayName;
        /// <summary>显示名标签</summary>
        private System.Windows.Forms.Label lblDisplayName;
        /// <summary>人物名称文本框</summary>
        private System.Windows.Forms.TextBox txtName;
        /// <summary>人物名称标签</summary>
        private System.Windows.Forms.Label lblName;
        /// <summary>人物列表组合框</summary>
        private System.Windows.Forms.GroupBox grpCharacterList;
        /// <summary>读取人物列表类型</summary>
        private System.Windows.Forms.ComboBox cboReadCharacterType;
        /// <summary>向下搜索按钮</summary>
        private System.Windows.Forms.Button btnSearchDown;
        /// <summary>向上搜索按钮</summary>
        private System.Windows.Forms.Button btnSearchUp;
        /// <summary>搜索关键字文本框</summary>
        private System.Windows.Forms.TextBox txtKeyword;
        /// <summary>反选按钮</summary>
        private System.Windows.Forms.Button btnSelectInvert;
        /// <summary>全选按钮</summary>
        private System.Windows.Forms.Button btnSelectAll;
        /// <summary>自动排序复选框</summary>
        private System.Windows.Forms.CheckBox chkAutoSort;
        /// <summary>人物列表框</summary>
        private System.Windows.Forms.ListBox lstCharacterList;
        /// <summary>刷新人物列表按钮</summary>
        private System.Windows.Forms.Button btnRefreshCharacterList;
        /// <summary>全部搜索按钮</summary>
        private System.Windows.Forms.Button btnSearchAll;
        /// <summary>重新载入菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiReload;
        /// <summary>编辑菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        /// <summary>打开select.def文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSelectDef;
        /// <summary>打开system.def文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenSystemDef;
        /// <summary>打开mugen.cfg文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenMugenCfg;
        /// <summary>监视人物cns文件FileSystemWatcher控件</summary>
        private System.IO.FileSystemWatcher fswCharacterCns;
        /// <summary>更换system.def文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeSystemDefPath;
        /// <summary>文件菜单项分隔符</summary>
        private System.Windows.Forms.ToolStripSeparator tssTsmiFiles1;
        /// <summary>打开def文件对话框</summary>
        private System.Windows.Forms.OpenFileDialog ofdDefPath;
        /// <summary>更换select.def文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeSelectDefPath;
        /// <summary>所选人物个数标签</summary>
        private System.Windows.Forms.Label lblCharacterSelectCount;
        /// <summary>人物总数标签</summary>
        private System.Windows.Forms.Label lblCharacterCount;
        /// <summary>MUGEN信息组合框</summary>
        private System.Windows.Forms.GroupBox grpMugenInfo;
        /// <summary>MUGEN信息标签</summary>
        private System.Windows.Forms.Label lblMugenInfo;
        /// <summary>转换为宽屏人物包右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiConvertToWideScreen;
        /// <summary>转换为普屏人物包右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiConvertToNormalScreen;
        /// <summary>mugen.cfg文件设置标签页</summary>
        private System.Windows.Forms.TabPage pageMugenCfgSetting;
        /// <summary>基础信息组合框</summary>
        private System.Windows.Forms.GroupBox grpBaseSetting;
        /// <summary>TeamLoseOnKO下拉列表</summary>
        private System.Windows.Forms.ComboBox cboTeamLoseOnKO;
        /// <summary>TeamLoseOnKO标签</summary>
        private System.Windows.Forms.Label lblTeamLoseOnKO;
        /// <summary>Team1VS2Life文本框</summary>
        private System.Windows.Forms.TextBox txtTeam1VS2Life;
        /// <summary>Team1VS2Life标签</summary>
        private System.Windows.Forms.Label lblTeam1VS2Life;
        /// <summary>游戏速度(帧率)文本框</summary>
        private System.Windows.Forms.TextBox txtGameFrame;
        /// <summary>游戏速度(帧率)标签</summary>
        private System.Windows.Forms.Label lblGameFrame;
        /// <summary>游戏速度文本框</summary>
        private System.Windows.Forms.Label lblGameSpeed;
        /// <summary>每回合时间文本框</summary>
        private System.Windows.Forms.TextBox txtTime;
        /// <summary>每回合时间标签</summary>
        private System.Windows.Forms.Label lblTime;
        /// <summary>游戏人物生命力文本框</summary>
        private System.Windows.Forms.TextBox txtMugenCfgLife;
        /// <summary>游戏人物生命力标签</summary>
        private System.Windows.Forms.Label lblMugenCfgLife;
        /// <summary>游戏难度标签</summary>
        private System.Windows.Forms.Label lblDifficulty;
        /// <summary>显示设置组合框</summary>
        private System.Windows.Forms.GroupBox grpDisplaySetting;
        /// <summary>是否全屏下拉列表</summary>
        private System.Windows.Forms.ComboBox cboFullScreen;
        /// <summary>渲染模式下拉列表</summary>
        private System.Windows.Forms.ComboBox cboRenderMode;
        /// <summary>是否全屏标签</summary>
        private System.Windows.Forms.Label lblFullScreen;
        /// <summary>渲染模式标签</summary>
        private System.Windows.Forms.Label lblRenderMode;
        /// <summary>游戏屏幕高度文本框</summary>
        private System.Windows.Forms.TextBox txtGameHeight;
        /// <summary>游戏屏幕高度标签</summary>
        private System.Windows.Forms.Label lblGameHeight;
        /// <summary>游戏屏幕宽度文本框</summary>
        private System.Windows.Forms.TextBox txtGameWidth;
        /// <summary>游戏屏幕宽度标签</summary>
        private System.Windows.Forms.Label lblGameWidth;
        /// <summary>按键设置组合框</summary>
        private System.Windows.Forms.GroupBox grpKeyPressSetting;
        /// <summary>跳键标签</summary>
        private System.Windows.Forms.Label lblKeyPressJump;
        /// <summary>P2按键标签</summary>
        private System.Windows.Forms.Label lblKeyPressP2;
        /// <summary>P1按键标签</summary>
        private System.Windows.Forms.Label lblKeyPressP1;
        /// <summary>开始键标签</summary>
        private System.Windows.Forms.Label lblKeyPressStart;
        /// <summary>Z键标签</summary>
        private System.Windows.Forms.Label lblKeyPressZ;
        /// <summary>Y键标签</summary>
        private System.Windows.Forms.Label lblKeyPressY;
        /// <summary>X键标签</summary>
        private System.Windows.Forms.Label lblKeyPressX;
        /// <summary>C键标签</summary>
        private System.Windows.Forms.Label lblKeyPressC;
        /// <summary>B键标签</summary>
        private System.Windows.Forms.Label lblKeyPressB;
        /// <summary>A键标签</summary>
        private System.Windows.Forms.Label lblKeyPressA;
        /// <summary>向前键标签</summary>
        private System.Windows.Forms.Label lblKeyPressRight;
        /// <summary>向后键标签</summary>
        private System.Windows.Forms.Label lblKeyPressLeft;
        /// <summary>蹲键标签</summary>
        private System.Windows.Forms.Label lblKeyPressCrouch;
        /// <summary>恢复mugen.cfg文件按钮</summary>
        private System.Windows.Forms.Button btnMugenCfgRestore;
        /// <summary>备份mugen.cfg文件按钮</summary>
        private System.Windows.Forms.Button btnMugenCfgBackup;
        /// <summary>重置mugen.cfg文件按钮</summary>
        private System.Windows.Forms.Button btnMugenCfgReset;
        /// <summary>修改mugen.cfg文件按钮</summary>
        private System.Windows.Forms.Button btnMugenCfgModify;
        /// <summary>游戏难度滑动条</summary>
        private System.Windows.Forms.TrackBar trbDifficulty;
        /// <summary>游戏速度滑动条</summary>
        private System.Windows.Forms.TrackBar trbGameSpeed;
        /// <summary>游戏速度值标签</summary>
        private System.Windows.Forms.Label lblGameSpeedValue;
        /// <summary>游戏难度值标签</summary>
        private System.Windows.Forms.Label lblDifficultyValue;
        /// <summary>Team1VS2Life百分号标签</summary>
        private System.Windows.Forms.Label lblTeam1VS2LifePercent;
        /// <summary>游戏人物生命力百分号标签</summary>
        private System.Windows.Forms.Label lblMugenCfgLifePercent;
        /// <summary>P2跳键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Jump;
        /// <summary>P1跳键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Jump;
        /// <summary>P2开始键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Start;
        /// <summary>P1开始键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Start;
        /// <summary>P2 Z键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Z;
        /// <summary>P1 Z键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Z;
        /// <summary>P2 Y键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Y;
        /// <summary>P1 Y键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Y;
        /// <summary>P2 X键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2X;
        /// <summary>P1 X键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1X;
        /// <summary>P2 C键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2C;
        /// <summary>P1 C键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1C;
        /// <summary>P2 B键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2B;
        /// <summary>P1 B键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1B;
        /// <summary>P2 A键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2A;
        /// <summary>P1 A键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1A;
        /// <summary>P2向前键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Right;
        /// <summary>P1向前键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Right;
        /// <summary>P2向后键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Left;
        /// <summary>P1向后键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Left;
        /// <summary>P2蹲键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP2Crouch;
        /// <summary>P1蹲键下拉框</summary>
        private System.Windows.Forms.ComboBox cboP1Crouch;
        /// <summary>人物模型组合框</summary>
        private System.Windows.Forms.GroupBox grpSprite;
        /// <summary>人物模型图片控件</summary>
        private System.Windows.Forms.PictureBox picSpriteImage;
        /// <summary>SFF文件版本标签</summary>
        private System.Windows.Forms.Label lblSpriteVersion;
        /// <summary>可选色表文件下拉框</summary>
        private System.Windows.Forms.ComboBox cboSelectableActFileList;
        /// <summary>添加所选人物右键菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem ctxTsmiAddCharacter;
        /// <summary>添加人物压缩包菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiAddCharacterByDefOrArchive;
        /// <summary>添加人物文件对话框</summary>
        private System.Windows.Forms.OpenFileDialog ofdAddCharacterPath;
        /// <summary>更换fight.def文件菜单项</summary>
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeFightDefPath;
    }
}

