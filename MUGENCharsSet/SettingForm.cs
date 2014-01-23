using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MUGENCharsSet
{
    /// <summary>
    /// 设置窗口类
    /// </summary>
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
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

        /// <summary>
        /// 当窗口加载时发生
        /// </summary>
        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtMugenExePath.Text = AppConfig.MugenExePath;
            txtEditProgramPath.Text = AppConfig.EditProgramPath;
            chkShowCharacterScreenMark.Checked = AppConfig.ShowCharacterScreenMark;
        }

        /// <summary>
        /// 当单击打开MUGEN程序路径按钮时发生
        /// </summary>
        private void btnOpenMugenExePath_Click(object sender, EventArgs e)
        {
            ofdExePath.FileName = AppConfig.MugenExePath;
            if (File.Exists(AppConfig.MugenExePath))
            {
                ofdExePath.InitialDirectory = AppConfig.MugenExePath.GetDirPathOfFile();
            }
            if (ofdExePath.ShowDialog() == DialogResult.OK)
            {
                txtMugenExePath.Text = ofdExePath.FileName;
            }
        }

        /// <summary>
        /// 当单击打开文本编辑器程序路径按钮时发生
        /// </summary>
        private void btnOpenEditProgramPath_Click(object sender, EventArgs e)
        {
            if (ofdExePath.ShowDialog() == DialogResult.OK)
            {
                txtEditProgramPath.Text = ofdExePath.FileName;
            }
        }

        /// <summary>
        /// 当单击确定按钮时发生
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            MainForm owner = (MainForm)Owner;
            try
            {
                AppConfig.EditProgramPath = txtEditProgramPath.Text.Trim();
                AppConfig.ShowCharacterScreenMark = chkShowCharacterScreenMark.Checked;
                string mugenCfgPath = txtMugenExePath.Text.Trim().GetDirPathOfFile() + MugenSetting.DataDir + MugenSetting.MugenCfgFileName;
                if (!File.Exists(mugenCfgPath))
                {
                    throw new ApplicationException("mugen.cfg文件不存在！");
                }
                if (AppConfig.MugenExePath != txtMugenExePath.Text.Trim())
                {
                    AppConfig.MugenExePath = txtMugenExePath.Text.Trim();
                    MugenSetting.Init(AppConfig.MugenExePath);
                    owner.ReadCharacterList(true);
                    owner.ReadMugenCfgSetting();
                }
            }
            catch(ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
        }

        /// <summary>
        /// 当单击默认值按钮时发生
        /// </summary>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtEditProgramPath.Text = AppConfig.DefaultEditProgramPath;
            chkShowCharacterScreenMark.Checked = false;
        }

        /// <summary>
        /// 当文件拖拽到程序路径文本框时发生
        /// </summary>
        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            ((TextBox)sender).Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        }

        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
    }
}
