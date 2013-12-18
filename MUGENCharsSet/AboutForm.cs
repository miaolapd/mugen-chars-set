using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MUGENCharsSet
{
    /// <summary>
    /// 关于窗口类
    /// </summary>
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当窗口加载时发生
        /// </summary>
        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblAppName.Text = "M.U.G.E.N人物设置 " + Application.ProductVersion;
            lblAuthor.Text = "程序设计：" + Application.CompanyName;
        }

        /// <summary>
        /// 当单击确定按钮时发生
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 当单击程序项目Url时发生
        /// </summary>
        private void lnkAppUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo proInfo = new System.Diagnostics.ProcessStartInfo(lnkAppUrl.Text);
                System.Diagnostics.Process pro = System.Diagnostics.Process.Start(proInfo);
            }
            catch (Exception) { }
        }
    }
}
