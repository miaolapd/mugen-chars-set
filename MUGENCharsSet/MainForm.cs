using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGENCharsSet主窗口
    /// </summary>
    public partial class MainForm : Form
    {
        #region 类常量

        public const string CHARS_DIR = @"chars\";  //人物文件夹名
        public const string MULTI_VALUE = "(多值)";   //多值的显示值
        public const int PAL_NO_COLUMN_NO = 0;  //序号的列数
        public const int PAL_VAL_COLUMN_NO = 1; //Pal值的列数
        public const string DATA_SECTION = "Data";  //Data配置分段
        public const string MUGEN_PATH_ITEM = "MugenPath";  //MUGEN程序绝对路径配置项
        public const string AUTO_SORT_ITEM = "AutoSort";    //自动排序配置项
        public const string EDIT_PROGRAM_ITEM = "EditProgram";  //文本编辑器配置项
        public const string READ_CHAR_TYPE_ITEM = "ReadCharType";   //读取人物列表类型配置项
        public const string DEF_EDIT_PROGRAM = "notepad.exe";   //默认文本编辑器路径
        public const string SELECT_DEF_PATH = @"data\select.def";   //select.def文件相对路径

        #endregion

        #region 类私有变量

        private string _mugenExePath = "";
        private bool _modifyEnabled = false;
        private bool _multiModified = false;
        private string _editProgram = DEF_EDIT_PROGRAM;
        private string[] _allActFileList;
        private StringCollection _curDefList = new StringCollection();
        private Character _curChar = null;
        private ArrayList _charList = null;
        private bool _isLstCharPreparing = false;
        private int _curLstCharSearchIndex = -1;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region 类属性

        /// <summary>
        /// 获取或设置MUGEN程序绝对路径
        /// </summary>
        private string MugenExePath
        {
            get { return _mugenExePath; }
            set
            {
                if (Path.GetExtension(value) != ".exe") throw (new ApplicationException("必须为可执行程序！"));
                else _mugenExePath = value;
            }
        }

        /// <summary>
        /// 获取MUGEN程序根目录绝对路径
        /// </summary>
        private string MugenDirPath
        {
            get { return Tools.GetFileDirName(MugenExePath); }
        }

        /// <summary>
        /// 获取MUGEN人物文件夹绝对路径
        /// </summary>
        private string MugenCharsDirPath
        {
            get { return MugenDirPath + CHARS_DIR; }
        }

        /// <summary>
        /// 获取程序配置文件绝对路径
        /// </summary>
        public string IniFilePath
        {
            get
            {
                return Tools.GetFormatDirPath(Application.UserAppDataPath) + Application.ProductName + ".ini";
            }
        }

        /// <summary>
        /// 获取或设置文本编辑器路径
        /// </summary>
        public string EditProgram
        {
            get { return _editProgram; }
            set { _editProgram = value; }
        }

        /// <summary>
        /// 获取或设置当前所有可用的act文件相对路径列表
        /// </summary>
        private string[] AllActFileList
        {
            get { return _allActFileList; }
            set { _allActFileList = value; }
        }

        /// <summary>
        /// 获取或设置当前def文件绝对路径列表
        /// </summary>
        private StringCollection CurDefList
        {
            get { return _curDefList; }
            set { _curDefList = value; }
        }

        /// <summary>
        /// 获取或设置当前MUGEN人物类
        /// </summary>
        private Character CurChar
        {
            get { return _curChar; }
            set { _curChar = value; }
        }

        /// <summary>
        /// 获取或设置MUGEN人物列表
        /// </summary>
        private ArrayList CharList
        {
            get { return _charList; }
            set { _charList = value; }
        }

        /// <summary>
        /// 获取或设置人物列表控件是否处于配置DataSource准备过程中
        /// </summary>
        private bool IsLstCharPreparing
        {
            get { return _isLstCharPreparing; }
            set { _isLstCharPreparing = value; }
        }

        /// <summary>
        /// 获取或设置当前人物列表搜索索引
        /// </summary>
        private int CurLstCharSearchIndex
        {
            get { return _curLstCharSearchIndex; }
            set { _curLstCharSearchIndex = value; }
        }

        /// <summary>
        /// 获取或设置是否进入批量修改模式
        /// </summary>
        private bool MultiModified
        {
            get { return _multiModified; }
            set
            {
                if (value)
                {
                    ResetControl();
                    txtName.ReadOnly = true;
                    txtDisplayName.ReadOnly = true;
                    grpPal.Enabled = false;
                    btnRestore.Enabled = true;
                    lblDefPath.Text = MULTI_VALUE;
                }
                else
                {
                    txtName.ReadOnly = false;
                    txtDisplayName.ReadOnly = false;
                    grpPal.Enabled = true;
                }
                _multiModified = value;
            }
        }

        /// <summary>
        /// 获取或设置是否进入修改模式
        /// </summary>
        private bool ModifyEnabled
        {
            get { return _modifyEnabled; }
            set
            {
                if (value)
                {
                    btnModify.Enabled = true;
                    btnReset.Enabled = true;
                    btnBackup.Enabled = true;
                    btnRestore.Enabled = true;
                }
                else
                {
                    btnModify.Enabled = false;
                    btnReset.Enabled = false;
                    btnBackup.Enabled = false;
                    btnRestore.Enabled = false;
                    ResetControl();
                }
                _modifyEnabled = value;
            }
        }

        #endregion

        #region 类方法

        /// <summary>
        /// 显示操作成功消息
        /// </summary>
        /// <param name="msg">消息</param>
        private void ShowSuccessMsg(string msg)
        {
            MessageBox.Show(msg, "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示操作失败消息
        /// </summary>
        /// <param name="msg">消息</param>
        private void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 重置人物属性设置及色表设置控件
        /// </summary>
        private void ResetControl()
        {
            lblDefPath.Text = "";
            foreach (Control ctlTemp in grpProperty.Controls)
            {
                if (ctlTemp is TextBox)
                    ((TextBox)ctlTemp).Clear();
            }
            dgvPal.Rows.Clear();
            ((DataGridViewComboBoxColumn)dgvPal.Columns[1]).Items.Clear();
        }

        /// <summary>
        /// 读取程序配置
        /// </summary>
        private void ReadIniSet()
        {
            try
            {
                IniFiles ini = new IniFiles(IniFilePath);
                txtMugenExePath.Text = ini.ReadString(DATA_SECTION, MUGEN_PATH_ITEM, "");
                if (ini.ReadInteger(DATA_SECTION, AUTO_SORT_ITEM, 0) == 1)
                    chkAutoSort.Checked = true;
                EditProgram = ini.ReadString(DATA_SECTION, EDIT_PROGRAM_ITEM, DEF_EDIT_PROGRAM);
                if (ini.ReadInteger(DATA_SECTION, READ_CHAR_TYPE_ITEM, 0) == 1)
                    cbbReadCharType.SelectedIndex = 1;
                else
                    cbbReadCharType.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 读取人物列表
        /// </summary>
        private void ReadCharList()
        {
            if (txtMugenExePath.Text.Trim() == String.Empty)
            {
                ShowErrorMsg("路径不得为空！");
                txtMugenExePath.Focus();
                return;
            }
            else
            {
                try { MugenExePath = txtMugenExePath.Text.Trim(); }
                catch(ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
            }
            ModifyEnabled = false;
            MultiModified = false;
            lstChars.DataSource = null;
            txtKeyword.Clear();
            if (!Directory.Exists(MugenCharsDirPath))
            {
                ShowErrorMsg("无法找到MUGEN人物文件夹！");
                return;
            }
            CharList = new ArrayList();
            ScanCharDir(CharList, MugenCharsDirPath);
            if (chkAutoSort.Checked) CharList.Sort(new CharFile.CharFileCompare());
            BindingSource bs = new BindingSource();
            bs.DataSource = CharList;
            IsLstCharPreparing = true;
            lstChars.DataSource = bs;
            lstChars.DisplayMember = "Name";
            lstChars.ValueMember = "DefPath";
            lstChars.SelectedIndex = -1;
            IsLstCharPreparing = false;
            WriteIniSet(DATA_SECTION, MUGEN_PATH_ITEM, MugenExePath);
            return;
        }

        /// <summary>
        /// 扫描人物文件夹以获取人物列表
        /// </summary>
        /// <param name="charList">人物列表</param>
        /// <param name="dir">人物文件夹</param>
        private void ScanCharDir(ArrayList charList, string dir)
        {
            string[] tempDefList = Directory.GetFiles(dir, "*" + Character.DEF_EXT);
            foreach (string tempDef in tempDefList)
            {
                try
                {
                    if (!File.Exists(tempDef)) continue;
                    IniFiles ini = new IniFiles(tempDef);
                    string name = Character.GetTrimName(ini.ReadString(Character.INFO_SECTION, Character.NAME_ITEM, ""));
                    if (name == String.Empty) continue;
                    string cns = ini.ReadString(Character.FILES_SECTION, Character.CNS_ITEM, "").Trim();
                    if (cns == String.Empty || !File.Exists(Tools.GetFileDirName(tempDef) + cns)) continue;
                    charList.Add(new CharFile(name, tempDef));
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
            }
            string[] tempDirArr = Directory.GetDirectories(dir);
            foreach (string tempDir in tempDirArr)
            {
                ScanCharDir(charList, tempDir);
            }
        }

        /// <summary>
        /// 读取单个人物设置
        /// </summary>
        private void ReadSingleCharSet()
        {
            if (lstChars.SelectedIndices.Count != 1) return;
            CurDefList.Clear();
            ModifyEnabled = false;
            MultiModified = false;
            CurDefList.Add(lstChars.SelectedValue.ToString());
            if (!File.Exists(CurDefList[0]))
            {
                ShowErrorMsg("def文件不存在！");
                return;
            }
            try
            {
                CurChar = new Character(CurDefList[0]);
            }
            catch (ApplicationException ex)
            {
                ModifyEnabled = false;
                ShowErrorMsg(ex.Message);
                return;
            }
            SetDefPathLabel(CurDefList[0]);
            txtName.Text = CurChar.Name;
            txtDisplayName.Text = CurChar.DisplayName;
            txtLife.Text = CurChar.Life.ToString();
            txtAttack.Text = CurChar.Attack.ToString();
            txtDefence.Text = CurChar.Defence.ToString();
            txtPower.Text = CurChar.Power.ToString();
            AllActFileList = CurChar.AllActFileList;
            if (AllActFileList.Length == 0)
            {
                ShowErrorMsg("色表文件未找到！");
                return;
            }
            DataGridViewComboBoxColumn dgvPalFileList = (DataGridViewComboBoxColumn)dgvPal.Columns[1];
            dgvPalFileList.Items.AddRange(AllActFileList);
            foreach (string palKey in CurChar.PalList)
            {
                dgvPal.Rows.Add(palKey);
            }
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                foreach (string item in AllActFileList)
                {
                    if (Tools.GetSlashPath(CurChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()].ToLower())
                        == Tools.GetSlashPath(item.ToLower()))
                    {
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value = item;
                    }
                }
            }
            ModifyEnabled = true;
            if (!File.Exists(CurDefList[0] + Character.BAK_EXT)) btnRestore.Enabled = false;
        }

        /// <summary>
        /// 批量读取人物设置
        /// </summary>
        private void ReadMultiCharSet()
        {
            if (lstChars.SelectedIndices.Count <= 1) return;
            CurDefList.Clear();
            ArrayList multiCharList = new ArrayList();
            foreach (int i in lstChars.SelectedIndices)
            {
                string defPath = ((CharFile)lstChars.Items[i]).DefPath;
                CurDefList.Add(defPath);
                multiCharList.Add(new CharacterBase(defPath));
            }
            SetMutliDefPathLabel();
            MultiModified = true;
            string name = ((CharacterBase)multiCharList[0]).Name,
                displayName = ((CharacterBase)multiCharList[0]).DisplayName;
            int life = ((CharacterBase)multiCharList[0]).Life,
                attack = ((CharacterBase)multiCharList[0]).Attack,
                defence = ((CharacterBase)multiCharList[0]).Defence,
                power = ((CharacterBase)multiCharList[0]).Power;
            txtName.Text = name;
            txtDisplayName.Text = displayName;
            txtLife.Text = life.ToString();
            txtAttack.Text = attack.ToString();
            txtDefence.Text = defence.ToString();
            txtPower.Text = power.ToString();
            foreach (CharacterBase singleChar in multiCharList)
            {
                if (name != singleChar.Name) txtName.Text = MULTI_VALUE;
                if (displayName != singleChar.DisplayName) txtDisplayName.Text = MULTI_VALUE;
                if (life != singleChar.Life) txtLife.Text = MULTI_VALUE;
                if (attack != singleChar.Attack) txtAttack.Text = MULTI_VALUE;
                if (defence != singleChar.Defence) txtDefence.Text = MULTI_VALUE;
                if (power != singleChar.Power) txtPower.Text = MULTI_VALUE;
            }
        }

        /// <summary>
        /// 在标签上显示当前读取的def文件相对路径
        /// </summary>
        /// <param name="defFullPath">def文件绝对路径</param>
        private void SetDefPathLabel(string defFullPath)
        {
            string msg = defFullPath.Substring(MugenCharsDirPath.Length);
            lblDefPath.Text = msg;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        /// <summary>
        /// 在标签上显示当前批量读取的def文件相对路径
        /// </summary>
        private void SetMutliDefPathLabel()
        {
            string msg = "";
            foreach (string def in CurDefList)
            {
                string strTemp = def.Substring(MugenCharsDirPath.Length);
                msg += strTemp + "\r\n";
            }
            lblDefPath.Text = MULTI_VALUE;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        /// <summary>
        /// 写入单个人物设置
        /// </summary>
        private void WriteSingleCharSet()
        {
            try
            {
                ReadValues();
                ReadPalValues();
                CurChar.WriteCharSet();
            }
            catch (Exception ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            ShowSuccessMsg("修改成功！");
        }

        /// <summary>
        /// 批量写入人物设置
        /// </summary>
        private void WriteMultiCharSet()
        {
            if (CurDefList.Count == 0) return;
            int total = 0;
            try
            {
                ReadValues();
                total = Character.WriteMultiCharSet(CurDefList, CurChar);
            }
            catch (Exception ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            if (total > 0) ShowSuccessMsg(total + "条项目修改成功！");
            else ShowErrorMsg("修改失败！");
        }

        /// <summary>
        /// 读取人物属性字段
        /// </summary>
        private void ReadValues()
        {
            foreach (Control ctlTemp in grpProperty.Controls)
            {
                if (ctlTemp is TextBox)
                {
                    TextBox txtTemp = ((TextBox)ctlTemp);
                    if (txtTemp.Text.Trim() == String.Empty)
                    {
                        txtTemp.SelectAll();
                        txtTemp.Focus();
                        throw (new ApplicationException("字段不得为空！"));
                    }
                    string[] txtIntNameArr = { txtLife.Name, txtAttack.Name, txtDefence.Name, txtPower.Name };
                    if (txtIntNameArr.Contains(txtTemp.Name))
                    {
                        try
                        {
                            int value = 0;
                            if (txtTemp.Text.Trim() == MULTI_VALUE) value = 0;
                            else value = Convert.ToInt32(txtTemp.Text.Trim());
                            if (value < 0) throw (new ApplicationException("数值不得小于0！"));
                            if (txtTemp.Name == txtLife.Name) CurChar.Life = value;
                            else if (txtTemp.Name == txtAttack.Name) CurChar.Attack = value;
                            else if (txtTemp.Name == txtDefence.Name) CurChar.Defence = value;
                            else if (txtTemp.Name == txtPower.Name) CurChar.Power = value;
                        }
                        catch (FormatException)
                        {
                            txtTemp.SelectAll();
                            txtTemp.Focus();
                            throw (new ApplicationException("数值格式错误！"));
                        }
                        catch (OverflowException)
                        {
                            txtTemp.SelectAll();
                            txtTemp.Focus();
                            throw (new ApplicationException("数值超过范围！"));
                        }
                    }
                    else
                    {
                        if (txtTemp.Name == txtName.Name) CurChar.Name = txtTemp.Text.Trim();
                        else if (txtTemp.Name == txtDisplayName.Name) CurChar.DisplayName = txtTemp.Text.Trim();
                    }
                }
            }
        }

        /// <summary>
        /// 读取Pal属性字段
        /// </summary>
        private void ReadPalValues()
        {
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                if (dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value != null &&
                    dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString() != String.Empty)
                    CurChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()] =
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString();
            }
        }

        /// <summary>
        /// 在人物列表里查找关键字
        /// </summary>
        /// <param name="isUp">是否向上搜索</param>
        private void SearchKeyword(bool isUp)
        {
            string keyword = txtKeyword.Text.Trim();
            if (keyword == String.Empty) return;
            if (lstChars.Items.Count == 0) return;
            if (lstChars.SelectedIndex != -1) CurLstCharSearchIndex = lstChars.SelectedIndex;
            lstChars.SelectedIndex = -1;
            bool isFind = false;
            if (isUp)
            {
                for (int i = CurLstCharSearchIndex - 1; i >= 0; i--)
                {
                    if (((CharFile)lstChars.Items[i]).Name.ToString().IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstChars.SelectedIndex = i;
                        CurLstCharSearchIndex = i;
                        isFind = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = CurLstCharSearchIndex + 1; i < lstChars.Items.Count; i++)
                {
                    if (((CharFile)lstChars.Items[i]).Name.ToString().IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstChars.SelectedIndex = i;
                        CurLstCharSearchIndex = i;
                        isFind = true;
                        break;
                    }
                }
            }
            if (!isFind)
            {
                if (CurLstCharSearchIndex != -1)
                {
                    if (isUp) CurLstCharSearchIndex = lstChars.Items.Count;
                    else CurLstCharSearchIndex = -1;
                    SearchKeyword(isUp);
                }
                else CurLstCharSearchIndex = -1;
            }
        }

        /// <summary>
        /// 写入程序配置
        /// </summary>
        /// <param name="section">配置分段</param>
        /// <param name="item">配置项</param>
        /// <param name="value">配置值</param>
        /// <returns>是否写入成功</returns>
        public bool WriteIniSet(string section, string item, string value)
        {
            try
            {
                IniFiles ini = new IniFiles(IniFilePath);
                ini.WriteString(section, item, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region 类事件

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadIniSet();
        }

        private void btnOpenMugenExe_Click(object sender, EventArgs e)
        {
            if (ofdOpenMugenExe.ShowDialog() == DialogResult.OK)
            {
                txtMugenExePath.Text = ofdOpenMugenExe.FileName;
                ReadCharList();
            }
        }

        private void btnReadChars_Click(object sender, EventArgs e)
        {
            ReadCharList();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                WriteMultiCharSet();
            }
            else
            {
                WriteSingleCharSet();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                foreach (Control ctlTemp in grpProperty.Controls)
                {
                    if (ctlTemp is TextBox) ((TextBox)ctlTemp).Text = MULTI_VALUE;
                }
            }
            else
            {
                ReadSingleCharSet();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                int total = Character.BackupMultiCharSet(CurDefList);
                if (total > 0) ShowSuccessMsg(total + "条项目备份成功！");
                else ShowErrorMsg("备份失败！");
            }
            else
            {
                try
                {
                    CurChar.BackupCharSet();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ShowSuccessMsg("备份成功！");
                if (File.Exists(CurDefList[0] + Character.BAK_EXT)) btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                int total = Character.RestoreMultiCharSet(CurDefList);
                if (total > 0)
                {
                    ShowSuccessMsg(total + "条项目还原成功！");
                    btnReset_Click(null, null);
                }
                else ShowErrorMsg("还原失败！");
            }
            else
            {
                try
                {
                    CurChar.RestoreCharSet();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ReadSingleCharSet();
                ShowSuccessMsg("恢复成功！");
            }
        }

        private void lstChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsLstCharPreparing) return;
            if (lstChars.SelectedIndices.Count > 1)
            {
                ReadMultiCharSet();
            }
            else
            {
                ReadSingleCharSet();
            }
        }

        // 当点击色表单元格时自动显示下拉框
        private void dgvPal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                SendKeys.Send("{F4}");
            }
            catch (Exception) { }
        }

        private void txtMugenDir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter) ReadCharList();
        }

        private void chkAutoSort_CheckedChanged(object sender, EventArgs e)
        {
            WriteIniSet(DATA_SECTION, AUTO_SORT_ITEM, chkAutoSort.Checked ? "1" : "0");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (lstChars.Items.Count > 0)
            {
                IsLstCharPreparing = true;
                for (int i = 0; i < lstChars.Items.Count; i++)
                {
                    lstChars.SetSelected(i, true);
                }
                IsLstCharPreparing = false;
                lstChars_SelectedIndexChanged(null, null);
            }
        }

        private void btnSelectInvert_Click(object sender, EventArgs e)
        {
            if (lstChars.Items.Count > 0)
            {
                IsLstCharPreparing = true;
                bool isAllSelect = true;
                for (int i = 0; i < lstChars.Items.Count; i++)
                {
                    bool blnTemp = !lstChars.GetSelected(i);
                    lstChars.SetSelected(i, blnTemp);
                    if (blnTemp) isAllSelect = false;
                }
                IsLstCharPreparing = false;
                lstChars_SelectedIndexChanged(null, null);
                if (isAllSelect) ModifyEnabled = false;
            }
        }

        private void btnSearchUp_Click(object sender, EventArgs e)
        {
            SearchKeyword(true);
        }

        private void btnSearchDown_Click(object sender, EventArgs e)
        {
            SearchKeyword(false);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter) btnSearchDown_Click(null, null);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (int)Keys.Enter:
                    if (e.Control)
                    {
                        if (btnModify.Enabled) btnModify_Click(null, null);
                    }
                    break;
                case (int)Keys.S:
                    if (e.Control)
                    {
                        if (btnReset.Enabled) btnReset_Click(null, null);
                    }
                    break;
                case (int)Keys.B:
                    if (e.Control)
                    {
                        if (btnBackup.Enabled) btnBackup_Click(null, null);
                    }
                    break;
                case (int)Keys.R:
                    if (e.Control)
                    {
                        if (btnRestore.Enabled) btnRestore_Click(null, null);
                    }
                    break;
            }
        }

        private void textProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void cbbReadCharType_SelectedIndexChanged(object sender, EventArgs e)
        {
            WriteIniSet(DATA_SECTION, READ_CHAR_TYPE_ITEM, cbbReadCharType.SelectedIndex.ToString());
        }

        #endregion

        #region 人物列表右键菜单

        private void tsmiOpenDefFile_Click(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndex < 0) return;
            string path = lstChars.SelectedValue.ToString();
            if (File.Exists(path))
            {
                try
                {
                    Process.Start(EditProgram, path);
                }
                catch (Exception)
                {
                    ShowErrorMsg("未找到文本编辑器！");
                    return;
                }
            }
            else ShowErrorMsg("def文件不存在！");
        }

        private void tsmiOpenCnsFile_Click(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndex < 0) return;
            try
            {
                string path = Character.GetCnsPath(lstChars.SelectedValue.ToString());
                if (File.Exists(path))
                    Process.Start(EditProgram, path);
                else ShowErrorMsg("cns文件不存在！");
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            catch (Exception)
            {
                ShowErrorMsg("未找到文本编辑器！");
                return;
            }
        }

        private void tsmiOpenDefDir_Click(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndex < 0) return;
            string path = lstChars.SelectedValue.ToString();
            if (File.Exists(path))
            {
                try
                {
                    Process.Start("explorer.exe", "/select," + path);
                }
                catch (Exception)
                {
                    ShowErrorMsg("打开文件夹失败！");
                    return;
                }
            }
            else ShowErrorMsg("def文件不存在！");
        }

        private void tsmiDeleteChar_Click(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndices.Count <= 0) return;
            if(MultiModified)
            {

            }
            else
            {
                if (CurChar == null) return;
                try
                {
                    CurChar.DeleteChar();
                }
                catch(ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                int index = lstChars.SelectedIndex;
                CharList.Remove((CharFile)lstChars.SelectedItem);
                BindingSource bs = new BindingSource();
                bs.DataSource = CharList;
                IsLstCharPreparing = true;
                lstChars.DataSource = bs;
                IsLstCharPreparing = false;
                lstChars.ClearSelected();
                if (index < lstChars.Items.Count) lstChars.SelectedIndex = index;
                else lstChars.SelectedIndex = lstChars.Items.Count - 1;
            }
        }

        #endregion

        #region 主菜单

        private void tsmiLaunchMugenExe_Click(object sender, EventArgs e)
        {
            if (MugenExePath == String.Empty)
            {
                try { MugenExePath = txtMugenExePath.Text.Trim(); }
                catch(ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
            }
            if (File.Exists(MugenExePath))
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(MugenExePath);
                    psi.UseShellExecute = false;
                    psi.WorkingDirectory = MugenDirPath;
                    Process.Start(psi);
                }
                catch (Exception)
                {
                    ShowErrorMsg("运行MUGEN程序失败！");
                    return;
                }
            }
            else ShowErrorMsg("MUGEN程序不存在！");
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Owner = this;
            settingForm.ShowDialog();
        }

        private void tsmiOpenSelectDef_Click(object sender, EventArgs e)
        {
            string path = MugenDirPath + SELECT_DEF_PATH;
            if (File.Exists(path))
            {
                try
                {
                    Process.Start(EditProgram, path);
                }
                catch (Exception)
                {
                    ShowErrorMsg("未找到文本编辑器！");
                    return;
                }
            }
            else ShowErrorMsg("select.def文件不存在！");
        }

        #endregion
    }

    #region 人物文件类

    /// <summary>
    /// 人物文件类（为人物列表控件DataSource所使用）
    /// </summary>
    public class CharFile
    {
        private string _name;
        private string _defPath;

        /// <summary>
        /// 类构造函数
        /// </summary>
        /// <param name="name">人物名</param>
        /// <param name="def">def文件绝对路径</param>
        public CharFile(string name, string def)
        {
            _name = name;
            _defPath = def;
        }

        /// <summary>
        /// 获取人物名
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// 获取def文件绝对路径
        /// </summary>
        public string DefPath
        {
            get { return _defPath; }
        }

        /// <summary>
        /// 用于比较两个CharFile类的大小
        /// </summary>
        public class CharFileCompare : IComparer
        {
            public CharFileCompare()
            {

            }

            int IComparer.Compare(Object x, Object y)
            {
                CharFile cx = (CharFile)x;
                CharFile cy = (CharFile)y;
                return String.Compare(cx.Name, cy.Name);
            }
        }

    }

    #endregion
}
