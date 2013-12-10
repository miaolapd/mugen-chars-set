using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Collections.Specialized;

namespace MUGENCharsSet
{
    public partial class MainForm : Form
    {
        public const string CHARS_DIR = @"chars\";
        public const string MULTI_VALUE = "(多值)";
        public const int PAL_NO_COLUMN_NO = 0;
        public const int PAL_VAL_COLUMN_NO = 1;
        public const string DATA_SECTION = "Data";
        public const string MUGEN_PATH_ITEM = "MugenPath";
        public const string AUTO_SORT_ITEM = "AutoSort";
        public const string EDIT_PROGRAM_ITEM = "EditProgram";
        public const string DEF_EDIT_PROGRAM = "notepad.exe";

        private string _MugenDir = "";
        private bool modifyEnabled = false;
        private bool multiModified = false;
        private StringCollection curDefList = new StringCollection();
        private Character curChar = null;
        private string[] allActFileList;
        private bool isLstCharPreparing = false;
        private int curLstCharSearchNo = -1;
        private string editProgram = DEF_EDIT_PROGRAM;

        public MainForm()
        {
            InitializeComponent();
        }

        private string MugenDir
        {
            get { return _MugenDir; }
            set { _MugenDir = Tools.getCorrectDirPath(value); }
        }

        private string MugenCharsDir
        {
            get { return MugenDir + CHARS_DIR; }
        }

        public string IniFilePath
        {
            get
            {
                return Tools.getCorrectDirPath(Application.UserAppDataPath) + Application.ProductName + ".ini";
            }
        }

        public string EditProgram
        {
            get { return editProgram; }
            set { editProgram = value; }
        }

        private bool MultiModified
        {
            get { return multiModified; }
            set
            {
                if (value)
                {
                    if (!multiModified)
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
                    foreach(int i in lstChars.SelectedIndices)
                    {
                        curDefList.Add(((CharFile)lstChars.Items[i]).Def);
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
                multiModified = value;
            }
        }

        private bool ModifyEnabled
        {
            get { return modifyEnabled; }
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
                modifyEnabled = value;
            }
        }

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

        private void readCharList()
        {
            if (txtMugenDir.Text.Trim() == String.Empty)
            {
                ShowErrorMsg("路径不得为空！");
                txtMugenDir.Focus();
                return;
            }
            else MugenDir = txtMugenDir.Text.Trim();
            ModifyEnabled = false;
            MultiModified = false;
            lstChars.DataSource = null;
            curLstCharSearchNo = -1;
            txtKeyword.Clear();
            if (!Directory.Exists(MugenCharsDir))
            {
                ShowErrorMsg("无法找到MUGEN人物文件夹！");
                return;
            }
            ArrayList charList = new ArrayList();
            scanCharDir(charList, MugenCharsDir);
            if (chkAutoSort.Checked) charList.Sort(new CharFile());
            isLstCharPreparing = true;
            lstChars.DataSource = charList;
            lstChars.DisplayMember = "Name";
            lstChars.ValueMember = "Def";
            lstChars.SelectedIndex = -1;
            isLstCharPreparing = false;
            writeIniSet(DATA_SECTION, MUGEN_PATH_ITEM, MugenDir);
            return;
        }

        private void scanCharDir(ArrayList charList,string dir)
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
                    if (cns == String.Empty || !File.Exists(Tools.getFileDir(tempDef) + cns)) continue;
                    charList.Add(new CharFile(name, tempDef));
                }
                catch(ApplicationException ex)
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
            allActFileList = curChar.AllActFileList;
            if (allActFileList.Length == 0)
            {
                ShowErrorMsg("色表文件未找到！");
                return;
            }
            DataGridViewComboBoxColumn dgvPalFileList = (DataGridViewComboBoxColumn)dgvPal.Columns[1];
            dgvPalFileList.Items.AddRange(allActFileList);
            foreach (string palKey in curChar.PalList)
            {
                dgvPal.Rows.Add(palKey);
            }
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                foreach (string item in allActFileList)
                {
                    if (Tools.getSlashDir(curChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()].ToLower())
                        == Tools.getSlashDir(item.ToLower()))
                    {
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value = item;
                    }
                }
            }
            ModifyEnabled = true;
            if (!File.Exists(curDefList[0] + Character.BAK_EXT)) btnRestore.Enabled = false;
        }

        private void readMultiCharSet()
        {
            if (lstChars.SelectedIndices.Count <= 1) return;
            MultiModified = true;
        }

        private void setDefPathLabel(string defFullPath)
        {
            string msg = defFullPath.Substring(MugenCharsDir.Length);
            lblDefPath.Text = msg;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        private void setMutliDefPathLabel()
        {
            string msg = "";
            foreach(string def in curDefList)
            {
                string strTemp = def.Substring(MugenCharsDir.Length);
                msg += strTemp + "\r\n";
            }
            lblDefPath.Text = MULTI_VALUE;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        private void writeSingleCharSet()
        {
            try
            {
                readValues();
                readPalValue();
                curChar.writeCharSet();
            }
            catch (Exception ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            ShowSuccessMsg("修改成功！");
        }

        private void writeMultiCharSet()
        {
            if (curDefList.Count == 0) return;
            int total = 0;
            try
            {
                readValues();
                total = Character.writeMultiCharSet(curDefList, curChar);
            }
            catch(Exception ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            if (total > 0) ShowSuccessMsg(total + "条项目修改成功！");
            else ShowErrorMsg("修改失败！");
        }

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

        private void readPalValue()
        {
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                if (dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value != null &&
                    dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString() != String.Empty)
                    curChar.PalList[dgvPal.Rows[i].Cells[PAL_NO_COLUMN_NO].Value.ToString()] =
                        dgvPal.Rows[i].Cells[PAL_VAL_COLUMN_NO].Value.ToString();
            }
        }

        private void searchKeyword(bool isUp)
        {
            string keyword = txtKeyword.Text.Trim();
            if (keyword == String.Empty) return;
            if (lstChars.Items.Count == 0) return;
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
            if(MultiModified)
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
            if(MultiModified)
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
                catch(ApplicationException ex)
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

        private void ShowSuccessMsg(string msg)
        {
            MessageBox.Show(msg, "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
            catch(Exception)
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

        private void textProperty_Enter(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //txt.SelectAll();
        }

        private void textProperty_Click(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //if (txt.Tag == null)
            //{
            //    txt.SelectAll();
            //    txt.Tag = 1;
            //}
        }

        private void textProperty_Leave(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;
            //txt.Tag = null;
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
            else curLstCharSearchNo = -1;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyValue)
            {
                case (int)Keys.Enter:
                    if (e.Control)
                    {
                        if(btnModify.Enabled) btnModify_Click(null, null);
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

    public class CharFile : IComparer
    {
        private string name;
        private string def;

        public CharFile() : this("", "")
        {

        }

        public CharFile(string strName, string strDef)
        {
            name = strName;
            def = strDef;
        }

        public string Name
        {
            get { return name; }
        }

        public string Def
        {
            get { return def; }
        }

        int IComparer.Compare(Object x, Object y)
        {
            CharFile a = (CharFile)x;
            CharFile b = (CharFile)y;
            return String.Compare(a.Name, b.Name);
        }

    }
}
