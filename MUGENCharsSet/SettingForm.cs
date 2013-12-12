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

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtEditProgram.Text = ((MainForm)Owner).EditProgram;
        }

        private void btnOpenEditProgram_Click(object sender, EventArgs e)
        {
            if (ofdEditProgram.ShowDialog() == DialogResult.OK)
            {
                txtEditProgram.Text = ofdEditProgram.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string editProgram = txtEditProgram.Text.Trim();
            if (editProgram == String.Empty)
            {
                ShowErrorMsg("字段不得为空！");
                txtEditProgram.SelectAll();
                txtEditProgram.Focus();
                return;
            }
            if (Path.GetExtension(editProgram) != ".exe")
            {
                ShowErrorMsg("必须为可执行程序！");
                txtEditProgram.SelectAll();
                txtEditProgram.Focus();
                return;
            }
            MainForm owner = (MainForm)Owner;
            owner.EditProgram = editProgram;
            owner.WriteIniSet(MainForm.DATA_SECTION, MainForm.EDIT_PROGRAM_ITEM, editProgram);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtEditProgram.Text = MainForm.DEF_EDIT_PROGRAM;
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
    }
}
