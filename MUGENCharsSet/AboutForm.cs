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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblAppName.Text = "M.U.G.E.N人物设置 " + Application.ProductVersion.Substring(0, Application.ProductVersion.LastIndexOf("."));
            lblAuthor.Text = "程序设计：" + Application.CompanyName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
