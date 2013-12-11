using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace MUGENCharsSet
{
    /// <summary>
    /// MUGENCharsSet主窗口
    /// </summary>
    public partial class MainForm : Form
    {
        public const string CHARS_DIR = @"chars\";  //人物文件夹名
        public const string MULTI_VALUE = "(多值)";   //多值的显示值
        public const int PAL_NO_COLUMN_NO = 0;  //序号的列数
        public const int PAL_VAL_COLUMN_NO = 1; //Pal值的列数
        public const string DATA_SECTION = "Data";  //Data配置分段
        public const string MUGEN_PATH_ITEM = "MugenPath";  //根目录绝对路径配置项
        public const string AUTO_SORT_ITEM = "AutoSort";    //自动排序配置项
        public const string EDIT_PROGRAM_ITEM = "EditProgram";  //文本编辑器配置项
        public const string DEF_EDIT_PROGRAM = "notepad.exe";   //默认文本编辑器路径

        private string _mugenDirPath = "";
        private bool _modifyEnabled = false;
        private bool _multiModified = false;
        private string _editProgram = DEF_EDIT_PROGRAM;
        private string[] _allActFileList;
        private StringCollection curDefList = new StringCollection();   //def文件绝对路径列表
        private Character curChar = null;   //当前MUGEN人物类
        private bool isLstCharPreparing = false;    //lstChar控件是否在设置DataSource过程中
        private int curLstCharSearchNo = -1;    //当前人物列表搜索索引号

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取或设置MUGEN程序根目录绝对路径
        /// </summary>
        private string MugenDirPath
        {
            get { return _mugenDirPath; }
            set { _mugenDirPath = Tools.getCorrectDirPath(value); }
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
                return Tools.getCorrectDirPath(Application.UserAppDataPath) + Application.ProductName + ".ini";
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
        public string[] AllActFileList
        {
            get { return _allActFileList; }
            set { _allActFileList = value; }
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
                    if (!_multiModified)
                    {
                        resetControl();
                        foreach (Control ctlTemp in grpProperty.Controls)
                        {
                            if (ctlTemp is TextBox) ((TextBox)ctlTemp).Text = MULTI_VALUE;
                        }
                    }
                    txtName.ReadOnly = true;
                    txtDisplayName.ReadOnly = true;
                    grpPal.Enabled = false;
                    btnRestore.Enabled = true;
                    lblDefPath.Text = MULTI_VALUE;
                    ttpCommon.SetToolTip(lblDefPath, MULTI_VALUE);
                    curDefList.Clear();
                    foreach (int i in lstChars.SelectedIndices)
                    {
                        curDefList.Add(((CharFile)lstChars.Items[i]).DefPath);
                    }
                    setMutliDefPathLabel();
                    curChar = new Character();
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
                    resetControl();
                }
                _modifyEnabled = value;
            }
        }

        /// <summary>
        /// 重置人物属性设置及色表设置控件
        /// </summary>
        private void resetControl()
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
        private void readIniSet()
        {
            try
            {
                IniFiles ini = new IniFiles(IniFilePath);
                txtMugenDir.Text = ini.ReadString(DATA_SECTION, MUGEN_PATH_ITEM, "");
                if (ini.ReadInteger(DATA_SECTION, AUTO_SORT_ITEM, 0) == 1)
                {
                    chkAutoSort.Checked = true;
                }
                EditProgram = ini.ReadString(DATA_SECTION, EDIT_PROGRAM_ITEM, DEF_EDIT_PROGRAM);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 读取人物列表
        /// </summary>
        private void readCharList()
        {
            if (txtMugenDir.Text.Trim() == String.Empty)
            {
                ShowErrorMsg("路径不得为空！");
                txtMugenDir.Focus();
                return;
            }
            else MugenDirPath = txtMugenDir.Text.Trim();
            ModifyEnabled = false;
            MultiModified = false;
            lstChars.DataSource = null;
            txtKeyword.Clear();
            if (!Directory.Exists(MugenCharsDirPath))
            {
                ShowErrorMsg("无法找到MUGEN人物文件夹！");
                return;
            }
            ArrayList charList = new ArrayList();
            scanCharDir(charList, MugenCharsDirPath);
            if (chkAutoSort.Checked) charList.Sort(new CharFile.CharFileCompare());
            isLstCharPreparing = true;
            lstChars.DataSource = charList;
            lstChars.DisplayMember = "Name";
            lstChars.ValueMember = "DefPath";
            lstChars.SelectedIndex = -1;
            isLstCharPreparing = false;
            writeIniSet(DATA_SECTION, MUGEN_PATH_ITEM, MugenDirPath);
            return;
        }

        /// <summary>
        /// 扫描人物文件夹以获取人物列表
        /// </summary>
        /// <param name="charList">人物列表</param>
        /// <param name="dir">人物文件夹</param>
        private void scanCharDir(ArrayList charList, string dir)
        {
            string[] tempDefList = Directory.GetFiles(dir, "*" + Character.DEF_EXT);
            foreach (string tempDef in tempDefList)
            {
                try
                {
                    if (!File.Exists(tempDef)) continue;
                    IniFiles ini = new IniFiles(tempDef);
                    string name = Character.getTrimName(ini.ReadString(Character.INFO_SECTION, Character.NAME_ITEM, ""));
                    if (name == String.Empty) continue;
                    string cns = ini.ReadString(Character.FILES_SECTION, Character.CNS_ITEM, "").Trim();
                    if (cns == String.Empty || !File.Exists(Tools.getFileDirPath(tempDef) + cns)) continue;
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
                scanCharDir(charList, tempDir);
            }
        }

        /// <summary>
        /// 读取单个人物设置
        /// </summary>
        private void readSingleCharSet()
        {
            if (lstChars.SelectedIndices.Count != 1) return;
            curDefList.Clear();
            ModifyEnabled = false;
            MultiModified = false;
            curDefList.Add(lstChars.SelectedValue.ToString());
            if (!File.Exists(curDefList[0]))
            {
                ShowErrorMsg("def文件不存在！");
                return;
            }
            try
            {
                curChar = new Character(curDefList[0]);
            }
            catch (ApplicationException ex)
            {
                ModifyEnabled = false;
                ShowErrorMsg(ex.Message);
                return;
            }
            setDefPathLabel(curDefList[0]);
            txtName.Text = curChar.Name;
            txtDisplayName.Text = curChar.DisplayName;
            txtLife.Text = curChar.Life.ToString();
            txtAttack.Text = curChar.Attack.ToString();
            txtDefence.Text = curChar.Defence.ToString();
            txtPower.Text = curChar.Power.ToString();
            AllActFileList = curChar.AllActFileList;
            if (AllActFileList.Length == 0)
            {
                ShowErrorMsg("色表文件未找到！");
                return;
            }
            DataGridViewComboBoxColumn dgvPalFileList = (DataGridViewComboBoxColumn)dgvPal.Columns[1];
            dgvPalFileList.Items.AddRange(AllActFileList);
            foreach (string palKey in curChar.PalList)
            {
                dgvPal.Rows.Add(palKey);
            }
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                foreach (string item in AllActFileList)
                {
                    if (Tools.getSlashPath(curChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()].ToLower())
                        == Tools.getSlashPath(item.ToLower()))
                    {
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value = item;
                    }
                }
            }
            ModifyEnabled = true;
            if (!File.Exists(curDefList[0] + Character.BAK_EXT)) btnRestore.Enabled = false;
        }

        /// <summary>
        /// 批量读取人物设置
        /// </summary>
        private void readMultiCharSet()
        {
            if (lstChars.SelectedIndices.Count <= 1) return;
            MultiModified = true;
        }

        /// <summary>
        /// 在标签上显示当前读取的def文件相对路径
        /// </summary>
        /// <param name="defFullPath">def文件绝对路径</param>
        private void setDefPathLabel(string defFullPath)
        {
            string msg = defFullPath.Substring(MugenCharsDirPath.Length);
            lblDefPath.Text = msg;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        /// <summary>
        /// 在标签上显示当前批量读取的def文件相对路径
        /// </summary>
        private void setMutliDefPathLabel()
        {
            string msg = "";
            foreach (string def in curDefList)
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
        private void writeSingleCharSet()
        {
            try
            {
                readValues();
                readPalValues();
                curChar.writeCharSet();
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
        private void writeMultiCharSet()
        {
            if (curDefList.Count == 0) return;
            int total = 0;
            try
            {
                readValues();
                total = Character.writeMultiCharSet(curDefList, curChar);
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
        private void readValues()
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
                            if (txtTemp.Name == txtLife.Name) curChar.Life = value;
                            else if (txtTemp.Name == txtAttack.Name) curChar.Attack = value;
                            else if (txtTemp.Name == txtDefence.Name) curChar.Defence = value;
                            else if (txtTemp.Name == txtPower.Name) curChar.Power = value;
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
                        if (txtTemp.Name == txtName.Name) curChar.Name = txtTemp.Text.Trim();
                        else if (txtTemp.Name == txtDisplayName.Name) curChar.DisplayName = txtTemp.Text.Trim();
                    }
                }
            }
        }

        /// <summary>
        /// 读取Pal属性字段
        /// </summary>
        private void readPalValues()
        {
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                if (dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value != null &&
                    dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString() != String.Empty)
                    curChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()] =
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString();
            }
        }

        /// <summary>
        /// 在人物列表里查找关键字
        /// </summary>
        /// <param name="isUp">是否向上搜索</param>
        private void searchKeyword(bool isUp)
        {
            string keyword = txtKeyword.Text.Trim();
            if (keyword == String.Empty) return;
            if (lstChars.Items.Count == 0) return;
            if (lstChars.SelectedIndex != -1) curLstCharSearchNo = lstChars.SelectedIndex;
            lstChars.SelectedIndex = -1;
            bool isFind = false;
            if (isUp)
            {
                for (int i = curLstCharSearchNo - 1; i >= 0; i--)
                {
                    if (((CharFile)lstChars.Items[i]).Name.ToString().IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstChars.SelectedIndex = i;
                        curLstCharSearchNo = i;
                        isFind = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = curLstCharSearchNo + 1; i < lstChars.Items.Count; i++)
                {
                    if (((CharFile)lstChars.Items[i]).Name.ToString().IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstChars.SelectedIndex = i;
                        curLstCharSearchNo = i;
                        isFind = true;
                        break;
                    }
                }
            }
            if (!isFind)
            {
                if (curLstCharSearchNo != -1)
                {
                    if (isUp) curLstCharSearchNo = lstChars.Items.Count;
                    else curLstCharSearchNo = -1;
                    searchKeyword(isUp);
                }
                else curLstCharSearchNo = -1;
            }
        }

        /// <summary>
        /// 写入程序配置
        /// </summary>
        /// <param name="section">配置分段</param>
        /// <param name="item">配置项</param>
        /// <param name="value">配置值</param>
        /// <returns>是否写入成功</returns>
        public bool writeIniSet(string section, string item, string value)
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            readIniSet();
        }

        private void btnOpenMugenDir_Click(object sender, EventArgs e)
        {
            if (fbdMugenDir.ShowDialog() == DialogResult.OK)
            {
                txtMugenDir.Text = fbdMugenDir.SelectedPath;
                readCharList();
            }
        }

        private void btnReadChars_Click(object sender, EventArgs e)
        {
            readCharList();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                writeMultiCharSet();
            }
            else
            {
                writeSingleCharSet();
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
                readSingleCharSet();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                int total = Character.backupMultiCharSet(curDefList);
                if (total > 0) ShowSuccessMsg(total + "条项目备份成功！");
                else ShowErrorMsg("备份失败！");
            }
            else
            {
                try
                {
                    curChar.backupCharSet();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ShowSuccessMsg("备份成功！");
                if (File.Exists(curDefList[0] + Character.BAK_EXT)) btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (MultiModified)
            {
                int total = Character.restoreMultiCharSet(curDefList);
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
                    curChar.restoreCharSet();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                readSingleCharSet();
                ShowSuccessMsg("恢复成功！");
            }
        }

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

        private void lstChars_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLstCharPreparing) return;
            if (lstChars.SelectedIndices.Count > 1)
            {
                readMultiCharSet();
            }
            else
            {
                readSingleCharSet();
            }
        }

        private void tsmiOpenDefFile_Click(object sender, EventArgs e)
        {
            if (lstChars.SelectedIndex < 0) return;
            string path = lstChars.SelectedValue.ToString();
            if (File.Exists(path))
            {
                try
                {
                    System.Diagnostics.Process.Start(EditProgram, path);
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
                string path = Character.getCnsPath(lstChars.SelectedValue.ToString());
                if (File.Exists(path))
                    System.Diagnostics.Process.Start(EditProgram, path);
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
                    System.Diagnostics.Process.Start("explorer.exe", "/select," + path);
                }
                catch (Exception)
                {
                    ShowErrorMsg("打开文件夹失败！");
                    return;
                }
            }
            else ShowErrorMsg("def文件不存在！");
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
            if (e.KeyValue == (int)Keys.Enter) readCharList();
        }

        private void chkAutoSort_CheckedChanged(object sender, EventArgs e)
        {
            writeIniSet(DATA_SECTION, AUTO_SORT_ITEM, chkAutoSort.Checked ? "1" : "0");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (lstChars.Items.Count > 0)
            {
                for (int i = 0; i < lstChars.Items.Count; i++)
                {
                    lstChars.SetSelected(i, true);
                }
            }
        }

        private void btnSelectInvert_Click(object sender, EventArgs e)
        {
            if (lstChars.Items.Count > 0)
            {
                bool isAllSelect = true;
                for (int i = 0; i < lstChars.Items.Count; i++)
                {
                    bool blnTemp = !lstChars.GetSelected(i);
                    lstChars.SetSelected(i, blnTemp);
                    if (blnTemp) isAllSelect = false;
                }
                if (isAllSelect) ModifyEnabled = false;
            }
        }

        private void btnSearchUp_Click(object sender, EventArgs e)
        {
            searchKeyword(true);
        }

        private void btnSearchDown_Click(object sender, EventArgs e)
        {
            searchKeyword(false);
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

        private void tsmiOpenMugenDir_Click(object sender, EventArgs e)
        {
            btnOpenMugenDir_Click(null, null);
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
    }

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
}
