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
using System.Text.RegularExpressions;

namespace MUGENCharsSet
{
    /// <summary>
    /// 程序主窗口类
    /// </summary>
    public partial class MainForm : Form
    {
        #region 类常量

        /// <summary>多值的显示值</summary>
        public const string MultiValue = "(多值)";
        /// <summary>序号的列数</summary>
        public const int PalNoColumnNo = 0;
        /// <summary>Pal值的列数</summary>
        public const int PalValColumnNo = 1;

        #endregion

        #region 类私有变量
        private bool _modifyEnabled = false;
        private bool _multiModified = false;
        private List<Character> _characterList;
        private bool _characterListControlPreparing = false;

        #endregion

        #region 类属性

        /// <summary>
        /// 获取或设置MUGEN人物列表
        /// </summary>
        private List<Character> CharacterList
        {
            get { return _characterList; }
            set { _characterList = value; }
        }

        /// <summary>
        /// 获取或设置人物列表控件是否处于配置DataSource准备过程中
        /// </summary>
        private bool CharacterListControlPreparing
        {
            get { return _characterListControlPreparing; }
            set { _characterListControlPreparing = value; }
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
                    txtName.ReadOnly = true;
                    txtDisplayName.ReadOnly = true;
                    grpPal.Enabled = false;
                    btnRestore.Enabled = false;
                    ResetCharacterControls();
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
                    btnRestore.Enabled = false;
                }
                else
                {
                    btnModify.Enabled = false;
                    btnReset.Enabled = false;
                    btnBackup.Enabled = false;
                    btnRestore.Enabled = false;
                    ResetCharacterControls();
                }
                _modifyEnabled = value;
            }
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

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
        private void ResetCharacterControls()
        {
            lblDefPath.Text = "";
            ttpCommon.SetToolTip(lblDefPath, "");
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
        private void ReadIniSetting()
        {
            AppSetting.Init();
            chkAutoSort.Checked = AppSetting.AutoSort;
            cboReadCharacterType.SelectedIndex = (int)AppSetting.ReadCharacterType;
        }

        /// <summary>
        /// 读取人物列表
        /// </summary>
        public void ReadCharacterList()
        {
            ModifyEnabled = false;
            MultiModified = false;
            lstCharacterList.DataSource = null;
            txtKeyword.Clear();
            lblMugenInfo.Text = "";
            lblCharacterCount.Text = "";
            lblCharacterSelectCount.Text = "";
            try
            {
                MugenSetting.ReadMugenSetting();
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            if (!Directory.Exists(MugenSetting.MugenCharsDirPath))
            {
                ShowErrorMsg("无法找到MUGEN人物文件夹！");
                return;
            }
            CharacterList = new List<Character>();
            try
            {
                if (AppSetting.ReadCharacterType == AppSetting.ReadCharTypeEnum.CharsDir)
                {
                    Character.ScanCharacterDir(CharacterList, MugenSetting.MugenCharsDirPath);
                }
                else
                {
                    Character.ReadSelectDefCharacterList(CharacterList);
                }
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            if (AppSetting.AutoSort)
            {
                CharacterList.Sort();
            }
            if (CharacterList.Count != 0)
            {
                RefreshCharacterListDataSource(CharacterList);
            }
            lblMugenInfo.Text = String.Format("MUGEN版本：{0}  画面包状态：{1}屏", MugenSetting.Version == MugenSetting.MugenVersion.WIN ? "win" : "1.x",
                MugenSetting.IsWideScreen ? "宽" : "普");
            lblCharacterCount.Text = String.Format("共{0}项", lstCharacterList.Items.Count);
            fswCharacterCns.Path = MugenSetting.MugenCharsDirPath;
            fswCharacterCns.EnableRaisingEvents = true;
            SetMugenVersionForControls(MugenSetting.Version);
        }

        /// <summary>
        /// 刷新人物列表控件的DataSource
        /// </summary>
        /// <param name="characterList">人物列表</param>
        private void RefreshCharacterListDataSource(List<Character> characterList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = characterList;
            CharacterListControlPreparing = true;
            lstCharacterList.DataSource = bs;
            lstCharacterList.DisplayMember = "ItemName";
            lstCharacterList.ValueMember = "DefPath";
            lstCharacterList.ClearSelected();
            CharacterListControlPreparing = false;
        }

        /// <summary>
        /// 读取单个人物设置
        /// </summary>
        private void ReadCharacter()
        {
            if (lstCharacterList.SelectedItems.Count != 1) return;
            ModifyEnabled = false;
            MultiModified = false;
            Character character = (Character)lstCharacterList.SelectedItem;
            if (!File.Exists(character.DefPath))
            {
                ShowErrorMsg("人物def文件不存在！");
                return;
            }
            character.ReadPalSetting();
            SetSingleCharacterLabel(character);
            txtName.Text = character.Name;
            txtDisplayName.Text = character.DisplayName;
            txtLife.Text = character.Life.ToString();
            txtAttack.Text = character.Attack.ToString();
            txtDefence.Text = character.Defence.ToString();
            txtPower.Text = character.Power.ToString();
            if (character.PalList.Count > 0)
            {
                string[] selectableActFileList = character.SelectableActFileList;
                DataGridViewComboBoxColumn dgvPalFileList = (DataGridViewComboBoxColumn)dgvPal.Columns[PalValColumnNo];
                dgvPalFileList.Items.AddRange(selectableActFileList);
                foreach (string palKey in character.PalList.Keys)
                {
                    dgvPal.Rows.Add(palKey);
                }
                for (int i = 0; i < dgvPal.Rows.Count; i++)
                {
                    foreach (string item in selectableActFileList)
                    {
                        if (Tools.GetSlashPath(character.PalList[dgvPal.Rows[i].Cells[PalNoColumnNo].Value.ToString()].ToLower())
                            == Tools.GetSlashPath(item.ToLower()))
                        {
                            dgvPal.Rows[i].Cells[PalValColumnNo].Value = item;
                        }
                    }
                }
            }
            ModifyEnabled = true;
            if (File.Exists(character.DefPath + Character.BakExt))
            {
                btnRestore.Enabled = true;
            }
        }

        /// <summary>
        /// 批量读取人物设置
        /// </summary>
        private void MultiReadCharacter()
        {
            if (lstCharacterList.SelectedItems.Count <= 1) return;
            Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
            lstCharacterList.SelectedItems.CopyTo(characterList, 0);
            MultiModified = true;
            SetMutliCharacterLabel(characterList);
            string name = characterList[0].Name;
            string displayName = characterList[0].DisplayName;
            int life = characterList[0].Life;
            int attack = characterList[0].Attack;
            int defence = characterList[0].Defence;
            int power = characterList[0].Power;
            txtName.Text = name;
            txtDisplayName.Text = displayName;
            txtLife.Text = life.ToString();
            txtAttack.Text = attack.ToString();
            txtDefence.Text = defence.ToString();
            txtPower.Text = power.ToString();
            bool canRestore = false;
            foreach (Character character in characterList)
            {
                if (name != character.Name) txtName.Text = MultiValue;
                if (displayName != character.DisplayName) txtDisplayName.Text = MultiValue;
                if (life != character.Life) txtLife.Text = MultiValue;
                if (attack != character.Attack) txtAttack.Text = MultiValue;
                if (defence != character.Defence) txtDefence.Text = MultiValue;
                if (power != character.Power) txtPower.Text = MultiValue;
                if (File.Exists(character.DefPath + Character.BakExt)) canRestore = true;
            }
            btnRestore.Enabled = canRestore;
        }

        /// <summary>
        /// 在标签上显示当前人物的def文件相对路径
        /// </summary>
        /// <param name="defFullPath">def文件绝对路径</param>
        private void SetSingleCharacterLabel(Character character)
        {
            string path = character.DefPath.Substring(MugenSetting.MugenCharsDirPath.Length);
            lblDefPath.Text = path;
            ttpCommon.SetToolTip(lblDefPath, path);
        }

        /// <summary>
        /// 在标签上显示当前批量读取的人物的def文件相对路径
        /// </summary>
        private void SetMutliCharacterLabel(Character[] characterList)
        {
            string msg = "";
            foreach (Character character in characterList)
            {
                msg += character.DefPath.Substring(MugenSetting.MugenCharsDirPath.Length) + "\r\n";
            }
            lblDefPath.Text = MultiValue;
            ttpCommon.SetToolTip(lblDefPath, msg);
        }

        /// <summary>
        /// 修改单个人物设置
        /// </summary>
        private void ModifyCharacter()
        {
            if (lstCharacterList.SelectedItems.Count != 1) return;
            Character character = ((Character)lstCharacterList.SelectedItem);
            string oriName = character.Name;
            try
            {
                string name, displayName;
                int life, attack, defence, power;
                ReadCharacterControlsValue(out name, out displayName, out life, out attack, out defence, out power);
                character.Name = name;
                character.DisplayName = displayName;
                character.Life = life;
                character.Attack = attack;
                character.Defence = defence;
                character.Power = power;
                ReadPalValues(character.PalList);
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            try
            {
                fswCharacterCns.EnableRaisingEvents = false;
                character.Save();
            }
            catch (ApplicationException)
            {
                fswCharacterCns.EnableRaisingEvents = true;
                ShowErrorMsg("修改失败！");
                return;
            }
            if (oriName != character.Name)
            {
                int index = lstCharacterList.SelectedIndex;
                RefreshCharacterListDataSource(CharacterList);
                lstCharacterList.SelectedIndex = index;
            }
            fswCharacterCns.EnableRaisingEvents = true;
            ShowSuccessMsg("修改成功！");
        }

        /// <summary>
        /// 批量修改人物设置
        /// </summary>
        private void MultiModifyCharacter()
        {
            if (lstCharacterList.SelectedItems.Count <= 1) return;
            Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
            lstCharacterList.SelectedItems.CopyTo(characterList, 0);
            int total = 0;
            try
            {
                string name, displayName;
                int life, attack, defence, power;
                ReadCharacterControlsValue(out name, out displayName, out life, out attack, out defence, out power);
                for (int i = 0; i < characterList.Length; i++)
                {
                    characterList[i].Life = life;
                    characterList[i].Attack = attack;
                    characterList[i].Defence = defence;
                    characterList[i].Power = power;
                }
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            fswCharacterCns.EnableRaisingEvents = false;
            total = Character.MultiSave(characterList);
            if (total > 0)
            {
                ShowSuccessMsg(String.Format("共{0}条项目修改成功！", total));
            }
            else
            {
                ShowErrorMsg("修改失败！");
            }
            fswCharacterCns.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 读取人物属性控件的值
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        private void ReadCharacterControlsValue(out string name, out string displayName,
            out int life, out int attack, out int defence, out int power)
        {
            name = ""; displayName = "";
            life = 0; attack = 0; defence = 0; power = 0;
            foreach (Control control in grpProperty.Controls)
            {
                if (control is TextBox)
                {
                    TextBox txtTemp = (TextBox)control;
                    try
                    {
                        if (txtTemp.Text.Trim() == String.Empty) throw new ApplicationException("字段不得为空！");
                        TextBox[] txtIntegerArray = { txtLife, txtAttack, txtDefence, txtPower };
                        if (txtIntegerArray.Contains(txtTemp))
                        {
                            int value = 0;
                            if (txtTemp.Text.Trim() == MultiValue) value = 0;
                            else value = Convert.ToInt32(txtTemp.Text.Trim());
                            if (value < 0) throw new ApplicationException("数值不得小于0！");
                            if (txtTemp == txtLife) life = value;
                            else if (txtTemp == txtAttack) attack = value;
                            else if (txtTemp == txtDefence) defence = value;
                            else if (txtTemp == txtPower) power = value;
                        }
                        else
                        {
                            if (txtTemp == txtName) name = txtTemp.Text.Trim();
                            else if (txtTemp == txtDisplayName) displayName = txtTemp.Text.Trim();
                        }
                    }
                    catch (FormatException)
                    {
                        txtTemp.SelectAll();
                        txtTemp.Focus();
                        throw new ApplicationException("数值格式错误！");
                    }
                    catch (OverflowException)
                    {
                        txtTemp.SelectAll();
                        txtTemp.Focus();
                        throw new ApplicationException("数值超过范围！");
                    }
                    catch (ApplicationException ex)
                    {
                        txtTemp.SelectAll();
                        txtTemp.Focus();
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 读取Pal属性字段
        /// </summary>
        private void ReadPalValues(Dictionary<string, string> palList)
        {
            for (int i = 0; i < dgvPal.Rows.Count; i++)
            {
                if (dgvPal.Rows[i].Cells[PalValColumnNo].Value != null &&
                    dgvPal.Rows[i].Cells[PalValColumnNo].Value.ToString() != String.Empty)
                {
                    palList[dgvPal.Rows[i].Cells[PalNoColumnNo].Value.ToString()] =
                        dgvPal.Rows[i].Cells[PalValColumnNo].Value.ToString();
                }
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
            if (lstCharacterList.Items.Count == 0) return;
            int searchIndex = -1;
            if (lstCharacterList.SelectedIndex != -1)
            {
                searchIndex = lstCharacterList.SelectedIndex;
            }
            else
            {
                if (isUp) searchIndex = lstCharacterList.Items.Count;
                else searchIndex = -1;
            }
            lstCharacterList.ClearSelected();
            bool isFind = false;
            if (isUp)
            {
                for (int i = searchIndex - 1; i >= 0; i--)
                {
                    if (((Character)lstCharacterList.Items[i]).Name.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstCharacterList.SelectedIndex = i;
                        searchIndex = i;
                        isFind = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = searchIndex + 1; i < lstCharacterList.Items.Count; i++)
                {
                    if (((Character)lstCharacterList.Items[i]).Name.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        lstCharacterList.SelectedIndex = i;
                        searchIndex = i;
                        isFind = true;
                        break;
                    }
                }
            }
            if (!isFind)
            {
                if (searchIndex == -1 || searchIndex == lstCharacterList.Items.Count)
                {
                    searchIndex = -1;
                }
                else
                {
                    if (isUp) searchIndex = lstCharacterList.Items.Count;
                    else searchIndex = -1;
                    SearchKeyword(isUp);
                }
            }
        }

        /// <summary>
        /// 在人物列表里查找全部关键字
        /// </summary>
        private void SearchAllKeyword()
        {
            string keyword = txtKeyword.Text.Trim();
            if (keyword == String.Empty) return;
            if (lstCharacterList.Items.Count == 0) return;
            lstCharacterList.ClearSelected();
            CharacterListControlPreparing = true;
            for (int i = 0; i < lstCharacterList.Items.Count; i++)
            {
                if (((Character)lstCharacterList.Items[i]).Name.IndexOf(keyword, StringComparison.CurrentCultureIgnoreCase) >= 0)
                {
                    lstCharacterList.SetSelected(i, true);
                }
            }
            CharacterListControlPreparing = false;
            lstCharacterList_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 转换为宽/普屏人物包
        /// </summary>
        /// <param name="isWideScreen">是否宽屏</param>
        private void ConvertToFitScreen(bool isWideScreen)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            string stcommonPath = MugenSetting.MugenDataDirPath + MugenSetting.StcommonFileName;
            if (!File.Exists(stcommonPath))
            {
                ShowErrorMsg("公共common1.cns文件不存在！");
                return;
            }
            try
            {
                string stcommonContent = File.ReadAllText(stcommonPath);
                string msg = String.Format("公共common1.cns文件不适合{0}屏，是否要转换？", isWideScreen ? "宽" : "普");
                if (isWideScreen)
                {
                    if (Character.IsStcommonWideScreen(stcommonContent) == 0)
                    {
                        if (MessageBox.Show(msg, "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Character.StcommonConvertToWideScreen(stcommonPath);
                        }
                    }
                }
                else
                {
                    if (Character.IsStcommonWideScreen(stcommonContent) == 1)
                    {
                        if (MessageBox.Show(msg, "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Character.StcommonConvertToNormalScreen(stcommonPath);
                        }
                    }
                }
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            fswCharacterCns.EnableRaisingEvents = false;
            if (MultiModified)
            {
                Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
                lstCharacterList.SelectedItems.CopyTo(characterList, 0);
                int total = 0;
                if (isWideScreen)
                {
                    total = Character.MultiConvertToWideScreen(characterList);
                }
                else
                {
                    total = Character.MultiConvertToNormalScreen(characterList);
                }
                if (total > 0)
                {
                    ShowSuccessMsg(String.Format("共{0}条项目转换成功！", total));
                }
                else
                {
                    fswCharacterCns.EnableRaisingEvents = true;
                    ShowErrorMsg("转换失败！");
                    return;
                }
            }
            else
            {
                Character character = (Character)lstCharacterList.SelectedItem;
                try
                {
                    if (isWideScreen)
                    {
                        character.ConvertToWideScreen();
                    }
                    else
                    {
                        character.ConvertToNormalScreen();
                    }
                }
                catch (ApplicationException ex)
                {
                    fswCharacterCns.EnableRaisingEvents = true;
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ShowSuccessMsg("转换成功！");
            }
            int[] selectedIndices = new int[lstCharacterList.SelectedIndices.Count];
            lstCharacterList.SelectedIndices.CopyTo(selectedIndices, 0);
            RefreshCharacterListDataSource(CharacterList);
            foreach (int index in selectedIndices)
            {
                lstCharacterList.SetSelected(index, true);
            }
            fswCharacterCns.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 为不同的MUGEN程序版本设置相应的控件
        /// </summary>
        /// <param name="version">MUGEN程序版本</param>
        private void SetMugenVersionForControls(MugenSetting.MugenVersion version)
        {
            if (version == MugenSetting.MugenVersion.WIN)
            {
                ctxTsmiConvertToWideScreen.Enabled = false;
                ctxTsmiConvertToNormalScreen.Enabled = false;
                txtGameWidth.Enabled = false;
                txtGameHeight.Enabled = false;
                cboRenderMode.Enabled = false;
            }
            else
            {
                ctxTsmiConvertToWideScreen.Enabled = true;
                ctxTsmiConvertToNormalScreen.Enabled = true;
                txtGameWidth.Enabled = true;
                txtGameHeight.Enabled = true;
                cboRenderMode.Enabled = true;
            }
            KeyPressComboBoxInit();
        }

        #endregion

        #region 类事件

        /// <summary>
        /// 当窗口加载时发生
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ReadIniSetting();
            string mugenCfgPath = Tools.GetDirPathOfFile(AppSetting.MugenExePath) + MugenSetting.DataDir + MugenSetting.MugenCfgFileName;
            if (AppSetting.MugenExePath == String.Empty || !File.Exists(AppSetting.MugenExePath) || !File.Exists(mugenCfgPath))
            {
                Visible = false;
                StartUpForm startUpForm = new StartUpForm();
                startUpForm.Owner = this;
                if (startUpForm.ShowDialog() != DialogResult.OK)
                {
                    Close();
                    return;
                }
            }
            try
            {
                MugenSetting.Init(AppSetting.MugenExePath);
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                Close();
                return;
            }
            ReadCharacterListProgressForm readCharListProgressForm = new ReadCharacterListProgressForm();
            readCharListProgressForm.Owner = this;
            readCharListProgressForm.ShowDialog();
            Visible = true;
        }

        /// <summary>
        /// 当人物属性标签页获得焦点时发生
        /// </summary>
        private void pageCharacter_Enter(object sender, EventArgs e)
        {
            Size = new Size(575, 590);
        }

        /// <summary>
        /// 当单击刷新人物列表按钮时发生
        /// </summary>
        private void btnRefreshCharacterList_Click(object sender, EventArgs e)
        {
            ReadCharacterList();
        }

        /// <summary>
        /// 当单击修改人物设置按钮时发生
        /// </summary>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            if (MultiModified)
            {
                MultiModifyCharacter();
            }
            else
            {
                ModifyCharacter();
            }
        }

        /// <summary>
        /// 当单击重置人物设置按钮时发生
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            if (MultiModified)
            {
                MultiReadCharacter();
            }
            else
            {
                ReadCharacter();
            }
        }

        /// <summary>
        /// 当单击备份人物设置按钮时发生
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            if (MultiModified)
            {
                Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
                lstCharacterList.SelectedItems.CopyTo(characterList, 0);
                int total = Character.MultiBackup(characterList);
                if (total > 0)
                {
                    ShowSuccessMsg(String.Format("共{0}条项目备份成功！", total));
                }
                else
                {
                    ShowErrorMsg("备份失败！");
                    return;
                }
            }
            else
            {
                Character character = (Character)lstCharacterList.SelectedItem;
                try
                {
                    character.Backup();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ShowSuccessMsg("备份成功！");
            }
            btnRestore.Enabled = true;
        }

        /// <summary>
        /// 当单击恢复人物设置按钮时发生
        /// </summary>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            fswCharacterCns.EnableRaisingEvents = false;
            if (MultiModified)
            {
                Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
                lstCharacterList.SelectedItems.CopyTo(characterList, 0);
                int total = Character.MultiRestore(characterList);
                if (total > 0)
                {
                    ShowSuccessMsg(String.Format("共{0}条项目还原成功！", total));
                    MultiReadCharacter();
                }
                else
                {
                    ShowErrorMsg("还原失败！");
                }
            }
            else
            {
                Character character = (Character)lstCharacterList.SelectedItem;
                try
                {
                    character.Restore();
                    character.ReadCharacterSetting();
                }
                catch (ApplicationException ex)
                {
                    fswCharacterCns.EnableRaisingEvents = true;
                    ShowErrorMsg(ex.Message);
                    return;
                }
                ReadCharacter();
                ShowSuccessMsg("恢复成功！");
            }
            fswCharacterCns.EnableRaisingEvents = true;
        }

        /// <summary>
        /// 当人物列表控件选择项改变时发生
        /// </summary>
        private void lstCharacterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CharacterListControlPreparing) return;
            lblCharacterSelectCount.Text = String.Format("已选{0}项", lstCharacterList.SelectedItems.Count);
            if (lstCharacterList.SelectedItems.Count > 1)
            {
                MultiReadCharacter();
            }
            else
            {
                ReadCharacter();
            }
        }

        /// <summary>
        /// 当点击色表单元格时自动显示下拉框
        /// </summary>
        private void dgvPal_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                SendKeys.Send("{F4}");
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 当自动选择属性改变时发生
        /// </summary>
        private void chkAutoSort_CheckedChanged(object sender, EventArgs e)
        {
            AppSetting.AutoSort = chkAutoSort.Checked;
        }

        /// <summary>
        /// 当单击全选按钮时发生
        /// </summary>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.Items.Count == 0) return;
            CharacterListControlPreparing = true;
            for (int i = 0; i < lstCharacterList.Items.Count; i++)
            {
                lstCharacterList.SetSelected(i, true);
            }
            CharacterListControlPreparing = false;
            lstCharacterList_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// 当单击反选按钮时发生
        /// </summary>
        private void btnSelectInvert_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.Items.Count == 0) return;
            if (lstCharacterList.SelectedItems.Count == 0)
            {
                btnSelectAll_Click(null, null);
                return;
            }
            CharacterListControlPreparing = true;
            bool isAllSelect = true;
            for (int i = 0; i < lstCharacterList.Items.Count; i++)
            {
                bool isSelected = !lstCharacterList.GetSelected(i);
                lstCharacterList.SetSelected(i, isSelected);
                if (isSelected)
                {
                    isAllSelect = false;
                }
            }
            CharacterListControlPreparing = false;
            lstCharacterList_SelectedIndexChanged(null, null);
            if (isAllSelect)
            {
                ModifyEnabled = false;
            }
        }

        /// <summary>
        /// 当单击向上搜索按钮时发生
        /// </summary>
        private void btnSearchUp_Click(object sender, EventArgs e)
        {
            SearchKeyword(true);
        }

        /// <summary>
        /// 当单击向下搜索按钮时发生
        /// </summary>
        private void btnSearchDown_Click(object sender, EventArgs e)
        {
            SearchKeyword(false);
        }

        /// <summary>
        /// 当单击全部搜索按钮时发生
        /// </summary>
        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            SearchAllKeyword();
        }

        /// <summary>
        /// 当搜索文本框控件按下某个键时发生
        /// </summary>
        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                btnSearchDown_Click(null, null);
            }
        }

        /// <summary>
        /// 当窗体控件按下某个键时发生
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (pageCharacter.CanFocus)
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
            else if (pageMugenCfgSetting.CanFocus)
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.Enter:
                        if (e.Control)
                        {
                            if (btnMugenCfgModify.Enabled) btnMugenCfgModify_Click(null, null);
                        }
                        break;
                    case (int)Keys.S:
                        if (e.Control)
                        {
                            if (btnMugenCfgReset.Enabled) btnMugenCfgReset_Click(null, null);
                        }
                        break;
                    case (int)Keys.B:
                        if (e.Control)
                        {
                            if (btnMugenCfgBackup.Enabled) btnMugenCfgBackup_Click(null, null);
                        }
                        break;
                    case (int)Keys.R:
                        if (e.Control)
                        {
                            if (btnMugenCfgRestore.Enabled) btnMugenCfgRestore_Click(null, null);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 当人物属性文本框控件按下某个键时发生
        /// </summary>
        private void textProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        /// <summary>
        /// 当读取人物列表类型控件选择项改变时发生
        /// </summary>
        private void cboReadCharacterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppSetting.ReadCharacterType = (AppSetting.ReadCharTypeEnum)cboReadCharacterType.SelectedIndex;
        }

        /// <summary>
        /// 当人物文件夹下的cns文件改变时发生
        /// </summary>
        private void fswCharacterCns_Changed(object sender, FileSystemEventArgs e)
        {
            string cnsPath = e.FullPath;
            foreach (Character character in CharacterList)
            {
                if (character.CnsFullPath.ToLower() == cnsPath.ToLower())
                {
                    character.ReadCharacterSetting();
                    break;
                }
            }
        }

        /// <summary>
        /// 当人物def文件拖拽到人物属性标签页时发生
        /// </summary>
        private void pageCharacter_DragDrop(object sender, DragEventArgs e)
        {
            lstCharacterList.ClearSelected();
            ModifyEnabled = false;
            CharacterListControlPreparing = true;
            foreach (string defPath in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Path.GetExtension(defPath) != Character.DefExt) continue;
                for (int i = 0; i < lstCharacterList.Items.Count; i++)
                {
                    if (((Character)lstCharacterList.Items[i]).Equals(defPath))
                    {
                        lstCharacterList.SetSelected(i, true);
                        break;
                    }
                }
            }
            CharacterListControlPreparing = false;
            lstCharacterList_SelectedIndexChanged(null, null);
        }

        private void pageCharacter_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        #endregion

        #region 人物列表右键菜单

        /// <summary>
        /// 当单击打开def文件右键菜单项时发生
        /// </summary>
        private void ctxTsmiOpenDefFile_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
            lstCharacterList.SelectedItems.CopyTo(characterList, 0);
            if (characterList.Length > 1)
            {
                if (MessageBox.Show("是否要打开多个文件？", "操作确认", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            }
            foreach (Character character in characterList)
            {
                if (!File.Exists(character.DefPath))
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("人物def文件不存在！");
                        return;
                    }
                }
                try
                {
                    Process.Start(AppSetting.EditProgramPath, character.DefPath);
                }
                catch (Exception)
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("未找到文本编辑器！");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 当单击打开cns文件右键菜单项时发生
        /// </summary>
        private void ctxTsmiOpenCnsFile_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
            lstCharacterList.SelectedItems.CopyTo(characterList, 0);
            if (characterList.Length > 1)
            {
                if (MessageBox.Show("是否要打开多个文件？", "操作确认", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            }
            foreach (Character character in characterList)
            {
                if (!File.Exists(character.CnsFullPath))
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("人物cns文件不存在！");
                        return;
                    }
                }
                try
                {
                    Process.Start(AppSetting.EditProgramPath, character.CnsFullPath);
                }
                catch (Exception)
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("未找到文本编辑器！");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 当单击打开文件夹右键菜单项时发生
        /// </summary>
        private void ctxTsmiOpenDefDir_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
            lstCharacterList.SelectedItems.CopyTo(characterList, 0);
            if (characterList.Length > 1)
            {
                if (MessageBox.Show("是否要打开多个文件夹？", "操作确认", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes) return;
            }
            foreach (Character character in characterList)
            {
                if (!File.Exists(character.DefPath))
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("人物def文件不存在！");
                        return;
                    }
                }
                try
                {
                    Process.Start("explorer.exe", "/select," + character.DefPath);
                }
                catch (Exception)
                {
                    if (MultiModified)
                    {
                        continue;
                    }
                    else
                    {
                        ShowErrorMsg("打开文件夹失败！");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 当单击复制def文件路径右键菜单项时发生
        /// </summary>
        private void ctxTsmiCopyDefPath_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            string copyContent = "";
            for (int i = 0; i < lstCharacterList.SelectedItems.Count; i++)
            {
                copyContent += Tools.GetSlashPath(((Character)lstCharacterList.SelectedItems[i]).DefPath.Substring(MugenSetting.MugenCharsDirPath.Length));
                if (i < lstCharacterList.SelectedItems.Count - 1)
                {
                    copyContent += "\r\n";
                }
            }
            try
            {
                Clipboard.SetDataObject(copyContent, true, 2, 200);
            }
            catch (Exception)
            {
                ShowErrorMsg("复制失败！");
                return;
            }
            ShowSuccessMsg(String.Format("{0}条项目已复制到剪贴板！", lstCharacterList.SelectedItems.Count));
        }

        /// <summary>
        /// 当单击转换为宽屏人物包右键菜单项时发生
        /// </summary>
        private void ctxTsmiConvertToWideScreen_Click(object sender, EventArgs e)
        {
            ConvertToFitScreen(true);
        }

        /// <summary>
        /// 当单击转换为普屏人物包右键菜单项时发生
        /// </summary>
        private void ctxTsmiConvertToNormalScreen_Click(object sender, EventArgs e)
        {
            ConvertToFitScreen(false);
        }

        /// <summary>
        /// 当单击删除人物右键菜单项时发生
        /// </summary>
        private void ctxTsmiDeleteCharacter_Click(object sender, EventArgs e)
        {
            if (lstCharacterList.SelectedItems.Count == 0) return;
            if (MessageBox.Show("是否删除人物？", "操作确认", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (MultiModified)
            {
                Character[] characterList = new Character[lstCharacterList.SelectedItems.Count];
                lstCharacterList.SelectedItems.CopyTo(characterList, 0);
                int total = Character.MultiDelete(characterList);
                if (total == 0)
                {
                    ShowErrorMsg("删除失败！");
                    return;
                }
                foreach (Character character in characterList)
                {
                    CharacterList.Remove(character);
                }
            }
            else
            {
                Character character = (Character)lstCharacterList.SelectedItem;
                try
                {
                    character.Delete();
                }
                catch (ApplicationException ex)
                {
                    ShowErrorMsg(ex.Message);
                    return;
                }
                CharacterList.Remove(character);
            }
            int index = lstCharacterList.SelectedIndex;
            RefreshCharacterListDataSource(CharacterList);
            if (index < lstCharacterList.Items.Count)
            {
                lstCharacterList.SelectedIndex = index;
            }
            else
            {
                lstCharacterList.SelectedIndex = lstCharacterList.Items.Count - 1;
            }
            lblCharacterCount.Text = String.Format("共{0}项", lstCharacterList.Items.Count);
            if (lstCharacterList.Items.Count == 0)
            {
                lblCharacterSelectCount.Text = "";
                ModifyEnabled = false;
            }
        }

        #endregion

        #region 主菜单

        /// <summary>
        /// 当单击选择system.def文件菜单项时发生
        /// </summary>
        private void tsmiSetSystemDefPath_Click(object sender, EventArgs e)
        {
            ofdDefPath.FileName = MugenSetting.SystemDefPath;
            if (File.Exists(MugenSetting.SystemDefPath))
            {
                ofdDefPath.InitialDirectory = Tools.GetDirPathOfFile(MugenSetting.SystemDefPath);
            }
            else
            {
                ofdDefPath.InitialDirectory = MugenSetting.MugenDataDirPath;
            }
            if (ofdDefPath.ShowDialog() != DialogResult.OK) return;
            try
            {
                MugenSetting.SystemDefPath = ofdDefPath.FileName;
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            ReadCharacterList();
        }

        /// <summary>
        /// 当单击选择select.def文件菜单项时发生
        /// </summary>
        private void tsmiSetSelectDefPath_Click(object sender, EventArgs e)
        {
            ofdDefPath.FileName = MugenSetting.SelectDefPath;
            if (File.Exists(MugenSetting.SelectDefPath))
            {
                ofdDefPath.InitialDirectory = Tools.GetDirPathOfFile(MugenSetting.SelectDefPath);
            }
            else
            {
                ofdDefPath.InitialDirectory = MugenSetting.MugenDataDirPath;
            }
            if (ofdDefPath.ShowDialog() != DialogResult.OK) return;
            try
            {
                MugenSetting.SelectDefPath = ofdDefPath.FileName;
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            ReadCharacterList();
        }

        /// <summary>
        /// 当单击重新载入菜单项时发生
        /// </summary>
        private void tsmiReload_Click(object sender, EventArgs e)
        {
            ReadCharacterList();
            ReadMugenCfgSetting();
        }

        /// <summary>
        /// 当单击运行MUGEN程序菜单项时发生
        /// </summary>
        private void tsmiLaunchMugenExe_Click(object sender, EventArgs e)
        {
            if (File.Exists(AppSetting.MugenExePath))
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(AppSetting.MugenExePath);
                    psi.UseShellExecute = false;
                    psi.WorkingDirectory = MugenSetting.MugenDirPath;
                    Process.Start(psi);
                }
                catch (Exception)
                {
                    ShowErrorMsg("运行MUGEN程序失败！");
                    return;
                }
            }
            else
            {
                ShowErrorMsg("MUGEN程序不存在！");
            }
        }

        /// <summary>
        /// 当单击设置菜单项时发生
        /// </summary>
        private void tsmiSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.Owner = this;
            settingForm.ShowDialog();
        }

        /// <summary>
        /// 当单击打开select.def菜单项时发生
        /// </summary>
        private void tsmiOpenSelectDef_Click(object sender, EventArgs e)
        {
            if (File.Exists(MugenSetting.SelectDefPath))
            {
                try
                {
                    Process.Start(AppSetting.EditProgramPath, MugenSetting.SelectDefPath);
                }
                catch (Exception)
                {
                    ShowErrorMsg("未找到文本编辑器！");
                    return;
                }
            }
            else
            {
                ShowErrorMsg("select.def文件不存在！");
            }
        }

        /// <summary>
        /// 当单击打开system.def菜单项时发生
        /// </summary>
        private void tsmiOpenSystemDef_Click(object sender, EventArgs e)
        {
            if (File.Exists(MugenSetting.SystemDefPath))
            {
                try
                {
                    Process.Start(AppSetting.EditProgramPath, MugenSetting.SystemDefPath);
                }
                catch (Exception)
                {
                    ShowErrorMsg("未找到文本编辑器！");
                    return;
                }
            }
            else
            {
                ShowErrorMsg("system.def文件不存在！");
            }
        }

        /// <summary>
        /// 当单击打开mugen.cfg菜单项时发生
        /// </summary>
        private void tsmiOpenMugenCfg_Click(object sender, EventArgs e)
        {
            if (File.Exists(MugenSetting.MugenCfgPath))
            {
                try
                {
                    Process.Start(AppSetting.EditProgramPath, MugenSetting.MugenCfgPath);
                }
                catch (Exception)
                {
                    ShowErrorMsg("未找到文本编辑器！");
                    return;
                }
            }
            else
            {
                ShowErrorMsg("mugen.cfg文件不存在！");
            }
        }

        /// <summary>
        /// 当单击关于菜单项时发生
        /// </summary>
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        #endregion

        #region 主程序配置标签页

        private bool _mugenCfgModifyEnabled = false;

        /// <summary>
        /// 获取或设置主程序配置标签页是否进入修改模式
        /// </summary>
        private bool MugenCfgModifyEnabled
        {
            get { return _mugenCfgModifyEnabled; }
            set
            {
                if (value)
                {
                    btnMugenCfgModify.Enabled = true;
                    btnMugenCfgReset.Enabled = true;
                    btnMugenCfgBackup.Enabled = true;
                    btnMugenCfgRestore.Enabled = false;
                }
                else
                {
                    btnMugenCfgModify.Enabled = false;
                    btnMugenCfgReset.Enabled = false;
                    btnMugenCfgBackup.Enabled = false;
                    btnMugenCfgRestore.Enabled = false;
                    ResetMugenCfgControls();
                }
                _mugenCfgModifyEnabled = value;
            }
        }

        /// <summary>
        /// 重置主程序配置标签页上的各个控件
        /// </summary>
        private void ResetMugenCfgControls()
        {
            foreach (Control groupBox in pageMugenCfgSetting.Controls)
            {
                if (groupBox is GroupBox)
                {
                    foreach (Control control in ((GroupBox)groupBox).Controls)
                    {
                        if (control is TextBox)
                        {
                            ((TextBox)control).Clear();
                        }
                        else if (control is ComboBox)
                        {
                            ((ComboBox)control).SelectedIndex = -1;
                        }
                    }
                }
            }
            trbDifficulty.Value = 1;
            trbGameSpeed.Value = 0;
        }

        /// <summary>
        /// 读取mugen.cfg文件配置
        /// </summary>
        public void ReadMugenCfgSetting()
        {
            try
            {
                MugenSetting.ReadMugenCfgSetting();
            }
            catch (ApplicationException ex)
            {
                MugenCfgModifyEnabled = false;
                ShowErrorMsg(ex.Message);
                return;
            }
            try
            {
                trbDifficulty.Value = MugenSetting.Difficulty;
            }
            catch (ArgumentOutOfRangeException)
            {
                trbDifficulty.Value = 1;
            }
            finally
            {
                trbDifficulty_ValueChanged(null, null);
            }
            txtMugenCfgLife.Text = MugenSetting.Life.ToString();
            txtTime.Text = MugenSetting.Time.ToString();
            try
            {
                trbGameSpeed.Value = MugenSetting.GameSpeed;
            }
            catch (ArgumentOutOfRangeException)
            {
                trbGameSpeed.Value = 0;
            }
            finally
            {
                trbGameSpeed_ValueChanged(null, null);
            }
            txtGameFrame.Text = MugenSetting.GameFrame.ToString();
            txtTeam1VS2Life.Text = MugenSetting.Team1VS2Life.ToString();
            cboTeamLoseOnKO.SelectedIndex = Convert.ToInt32(MugenSetting.TeamLoseOnKO);
            txtGameWidth.Text = MugenSetting.GameWidth.ToString();
            txtGameHeight.Text = MugenSetting.GameHeight.ToString();
            cboRenderMode.SelectedIndex = Tools.GetComboBoxEqualValueIndex(cboRenderMode, MugenSetting.RenderMode);
            cboFullScreen.SelectedIndex = Convert.ToInt32(MugenSetting.FullScreen);

            cboP1Jump.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Jump);
            cboP1Crouch.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Crouch);
            cboP1Left.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Left);
            cboP1Right.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Right);
            cboP1A.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.A);
            cboP1B.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.B);
            cboP1C.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.C);
            cboP1X.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.X);
            cboP1Y.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Y);
            cboP1Z.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Z);
            cboP1Start.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP1.Start);

            cboP2Jump.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Jump);
            cboP2Crouch.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Crouch);
            cboP2Left.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Left);
            cboP2Right.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Right);
            cboP2A.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.A);
            cboP2B.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.B);
            cboP2C.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.C);
            cboP2X.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.X);
            cboP2Y.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Y);
            cboP2Z.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Z);
            cboP2Start.Text = KeyPressSetting.GetKeyName(MugenSetting.KeyPressP2.Start);

            MugenCfgModifyEnabled = true;
            if (File.Exists(MugenSetting.MugenCfgPath + MugenSetting.BakExt))
            {
                btnMugenCfgRestore.Enabled = true;
            }
        }

        /// <summary>
        /// 读取主程序配置标签页上控件的值
        /// </summary>
        /// <exception cref="System.ApplicationException"></exception>
        private void ReadMugenCfgControlsValue()
        {
            foreach (Control groupBox in pageMugenCfgSetting.Controls)
            {
                if (groupBox is GroupBox)
                {
                    foreach (Control control in ((GroupBox)groupBox).Controls)
                    {
                        if (!control.Enabled) continue;
                        try
                        {
                            if (control is TextBox)
                            {
                                if (((TextBox)control).Text.Trim() == String.Empty) throw new ApplicationException("字段不得为空！");
                            }
                            else if (control is ComboBox)
                            {
                                if (((ComboBox)control).DropDownStyle == ComboBoxStyle.DropDownList)
                                {
                                    if (((ComboBox)control).SelectedIndex == -1) throw new ApplicationException("必须选择一项！");
                                }
                                else
                                {
                                    if (((ComboBox)control).Text.Trim() == String.Empty) throw new ApplicationException("字段不得为空！");
                                }
                            }
                            if (control == trbDifficulty) MugenSetting.Difficulty = trbDifficulty.Value;
                            else if (control == txtLife) MugenSetting.Life = Convert.ToInt32(txtLife.Text.Trim());
                            else if (control == txtTime) MugenSetting.Time = Convert.ToInt32(txtTime.Text.Trim());
                            else if (control == trbGameSpeed) MugenSetting.GameSpeed = trbGameSpeed.Value;
                            else if (control == txtGameFrame) MugenSetting.GameFrame = Convert.ToInt32(txtGameFrame.Text.Trim());
                            else if (control == txtTeam1VS2Life) MugenSetting.Team1VS2Life = Convert.ToInt32(txtTeam1VS2Life.Text.Trim());
                            else if (control == cboTeamLoseOnKO) MugenSetting.TeamLoseOnKO = Convert.ToBoolean(cboTeamLoseOnKO.SelectedIndex);
                            else if (control == txtGameWidth) MugenSetting.GameWidth = Convert.ToInt32(txtGameWidth.Text.Trim());
                            else if (control == txtGameHeight) MugenSetting.GameHeight = Convert.ToInt32(txtGameHeight.Text.Trim());
                            else if (control == cboRenderMode) MugenSetting.RenderMode = cboRenderMode.SelectedItem.ToString();
                            else if (control == cboFullScreen) MugenSetting.FullScreen = Convert.ToBoolean(cboFullScreen.SelectedIndex);
                            else if (control == cboP1Jump) MugenSetting.KeyPressP1.Jump = KeyPressSetting.GetKeyCode(cboP1Jump.Text.Trim());
                            else if (control == cboP1Crouch) MugenSetting.KeyPressP1.Crouch = KeyPressSetting.GetKeyCode(cboP1Crouch.Text.Trim());
                            else if (control == cboP1Left) MugenSetting.KeyPressP1.Left = KeyPressSetting.GetKeyCode(cboP1Left.Text.Trim());
                            else if (control == cboP1Right) MugenSetting.KeyPressP1.Right = KeyPressSetting.GetKeyCode(cboP1Right.Text.Trim());
                            else if (control == cboP1A) MugenSetting.KeyPressP1.A = KeyPressSetting.GetKeyCode(cboP1A.Text.Trim());
                            else if (control == cboP1B) MugenSetting.KeyPressP1.B = KeyPressSetting.GetKeyCode(cboP1B.Text.Trim());
                            else if (control == cboP1C) MugenSetting.KeyPressP1.C = KeyPressSetting.GetKeyCode(cboP1C.Text.Trim());
                            else if (control == cboP1X) MugenSetting.KeyPressP1.X = KeyPressSetting.GetKeyCode(cboP1X.Text.Trim());
                            else if (control == cboP1Y) MugenSetting.KeyPressP1.Y = KeyPressSetting.GetKeyCode(cboP1Y.Text.Trim());
                            else if (control == cboP1Z) MugenSetting.KeyPressP1.Z = KeyPressSetting.GetKeyCode(cboP1Z.Text.Trim());
                            else if (control == cboP1Start) MugenSetting.KeyPressP1.Start = KeyPressSetting.GetKeyCode(cboP1Start.Text.Trim());
                            else if (control == cboP2Jump) MugenSetting.KeyPressP2.Jump = KeyPressSetting.GetKeyCode(cboP2Jump.Text.Trim());
                            else if (control == cboP2Crouch) MugenSetting.KeyPressP2.Crouch = KeyPressSetting.GetKeyCode(cboP2Crouch.Text.Trim());
                            else if (control == cboP2Left) MugenSetting.KeyPressP2.Left = KeyPressSetting.GetKeyCode(cboP2Left.Text.Trim());
                            else if (control == cboP2Right) MugenSetting.KeyPressP2.Right = KeyPressSetting.GetKeyCode(cboP2Right.Text.Trim());
                            else if (control == cboP2A) MugenSetting.KeyPressP2.A = KeyPressSetting.GetKeyCode(cboP2A.Text.Trim());
                            else if (control == cboP2B) MugenSetting.KeyPressP2.B = KeyPressSetting.GetKeyCode(cboP2B.Text.Trim());
                            else if (control == cboP2C) MugenSetting.KeyPressP2.C = KeyPressSetting.GetKeyCode(cboP2C.Text.Trim());
                            else if (control == cboP2X) MugenSetting.KeyPressP2.X = KeyPressSetting.GetKeyCode(cboP2X.Text.Trim());
                            else if (control == cboP2Y) MugenSetting.KeyPressP2.Y = KeyPressSetting.GetKeyCode(cboP2Y.Text.Trim());
                            else if (control == cboP2Z) MugenSetting.KeyPressP2.Z = KeyPressSetting.GetKeyCode(cboP2Z.Text.Trim());
                            else if (control == cboP2Start) MugenSetting.KeyPressP2.Start = KeyPressSetting.GetKeyCode(cboP2Start.Text.Trim());
                        }
                        catch (FormatException)
                        {
                            if (control is TextBox) ((TextBox)control).SelectAll();
                            control.Focus();
                            throw new ApplicationException("数值格式错误！");
                        }
                        catch (OverflowException)
                        {
                            if (control is TextBox) ((TextBox)control).SelectAll();
                            control.Focus();
                            throw new ApplicationException("数值超过范围！");
                        }
                        catch (ApplicationException ex)
                        {
                            if (control is TextBox) ((TextBox)control).SelectAll();
                            control.Focus();
                            throw ex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始化按键设置下拉列表
        /// </summary>
        private void KeyPressComboBoxInit()
        {
            foreach (Control control in grpKeyPressSetting.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).Items.Clear();
                    ((ComboBox)control).Items.AddRange(KeyPressSetting.KeyCode.Values.ToArray());
                }
            }
        }

        /// <summary>
        /// 当主程序配置标签页获得焦点时发生
        /// </summary>
        private void pageMugenCfgSetting_Enter(object sender, EventArgs e)
        {
            Size = new Size(532, 468);
            if (!MugenCfgModifyEnabled)
            {
                ReadMugenCfgSetting();
            }
        }

        /// <summary>
        /// 当单击主程序配置标签页的修改按钮时发生
        /// </summary>
        private void btnMugenCfgModify_Click(object sender, EventArgs e)
        {
            try
            {
                ReadMugenCfgControlsValue();
                MugenSetting.SaveMugenCfgSetting();
            }
            catch (ApplicationException ex)
            {
                try
                {
                    MugenSetting.ReadMugenCfgSetting();
                }
                catch (ApplicationException) { }
                ShowErrorMsg(ex.Message);
                return;
            }
            ShowSuccessMsg("设置修改成功！");
        }

        /// <summary>
        /// 当单击主程序配置标签页的重置按钮时发生
        /// </summary>
        private void btnMugenCfgReset_Click(object sender, EventArgs e)
        {
            ReadMugenCfgSetting();
        }

        /// <summary>
        /// 当单击主程序配置标签页的备份按钮时发生
        /// </summary>
        private void btnMugenCfgBackup_Click(object sender, EventArgs e)
        {
            try
            {
                MugenSetting.BackupMugenCfgSetting();
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            btnMugenCfgRestore.Enabled = true;
            ShowSuccessMsg("设置备份成功！");
        }

        /// <summary>
        /// 当单击主程序配置标签页的还原按钮时发生
        /// </summary>
        private void btnMugenCfgRestore_Click(object sender, EventArgs e)
        {
            try
            {
                MugenSetting.RestoreMugenCfgSetting();
            }
            catch (ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            ReadMugenCfgSetting();
            ShowSuccessMsg("设置还原成功！");
        }

        /// <summary>
        /// 当Difficulty滑动条的值改变时发生
        /// </summary>
        private void trbDifficulty_ValueChanged(object sender, EventArgs e)
        {
            lblDifficultyValue.Text = trbDifficulty.Value.ToString();
        }

        /// <summary>
        /// 当GameSpeed滑动条的值改变时发生
        /// </summary>
        private void trbGameSpeed_ValueChanged(object sender, EventArgs e)
        {
            lblGameSpeedValue.Text = (trbGameSpeed.Value > 0 ? "+" : "") + trbGameSpeed.Value;
        }

        #endregion

    }
}
