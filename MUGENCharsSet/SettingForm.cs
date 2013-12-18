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
            MainForm owner = (MainForm)Owner;
            txtMugenExePath.Text = owner.AppSetting.MugenExePath;
            txtEditProgramPath.Text = owner.AppSetting.EditProgramPath;
        }

        /// <summary>
        /// 当单击打开MUGEN程序路径按钮时发生
        /// </summary>
        private void btnOpenMugenExePath_Click(object sender, EventArgs e)
        {
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
                owner.AppSetting.EditProgramPath = txtEditProgramPath.Text.Trim();
                if (!File.Exists(MUGENSetting.GetMugenCfgPath(txtMugenExePath.Text.Trim())))
                {
                    throw new ApplicationException("mugen.cfg文件不存在！");
                }
                if (owner.AppSetting.MugenExePath != txtMugenExePath.Text.Trim())
                {
                    owner.AppSetting.MugenExePath = txtMugenExePath.Text.Trim();
                    owner.ReadCharacterList();
                }
            }
            catch(ApplicationException ex)
            {
                ShowErrorMsg(ex.Message);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 当单击取消按钮时发生
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 当单击默认值按钮时发生
        /// </summary>
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtEditProgramPath.Text = ApplicationSetting.DefaultEditProgramPath;
        }

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
