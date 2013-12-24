namespace MUGENCharsSet
{
    partial class StartUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartUpForm));
            this.grpMugenExePath = new System.Windows.Forms.GroupBox();
            this.lblMugenExePath = new System.Windows.Forms.Label();
            this.txtMugenExePath = new System.Windows.Forms.TextBox();
            this.btnOpenMugenExePath = new System.Windows.Forms.Button();
            this.ofdOpenMugenExePath = new System.Windows.Forms.OpenFileDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.grpMugenExePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMugenExePath
            // 
            this.grpMugenExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMugenExePath.Controls.Add(this.lblMugenExePath);
            this.grpMugenExePath.Controls.Add(this.txtMugenExePath);
            this.grpMugenExePath.Controls.Add(this.btnOpenMugenExePath);
            this.grpMugenExePath.Location = new System.Drawing.Point(12, 12);
            this.grpMugenExePath.Name = "grpMugenExePath";
            this.grpMugenExePath.Size = new System.Drawing.Size(387, 43);
            this.grpMugenExePath.TabIndex = 1;
            this.grpMugenExePath.TabStop = false;
            this.grpMugenExePath.Text = "MUGEN程序";
            // 
            // lblMugenExePath
            // 
            this.lblMugenExePath.AutoSize = true;
            this.lblMugenExePath.Location = new System.Drawing.Point(6, 18);
            this.lblMugenExePath.Name = "lblMugenExePath";
            this.lblMugenExePath.Size = new System.Drawing.Size(83, 12);
            this.lblMugenExePath.TabIndex = 0;
            this.lblMugenExePath.Text = "MUGEN程序位置";
            // 
            // txtMugenExePath
            // 
            this.txtMugenExePath.AllowDrop = true;
            this.txtMugenExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMugenExePath.Location = new System.Drawing.Point(95, 15);
            this.txtMugenExePath.Name = "txtMugenExePath";
            this.txtMugenExePath.Size = new System.Drawing.Size(253, 21);
            this.txtMugenExePath.TabIndex = 1;
            this.ttpCommon.SetToolTip(this.txtMugenExePath, "可将程序拖拽到此处");
            this.txtMugenExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMugenExePath_DragDrop);
            this.txtMugenExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMugenExePath_DragEnter);
            // 
            // btnOpenMugenExePath
            // 
            this.btnOpenMugenExePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMugenExePath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenMugenExePath.Location = new System.Drawing.Point(354, 14);
            this.btnOpenMugenExePath.Name = "btnOpenMugenExePath";
            this.btnOpenMugenExePath.Size = new System.Drawing.Size(27, 23);
            this.btnOpenMugenExePath.TabIndex = 2;
            this.btnOpenMugenExePath.Text = "...";
            this.btnOpenMugenExePath.UseVisualStyleBackColor = true;
            this.btnOpenMugenExePath.Click += new System.EventHandler(this.btnOpenMugenExePath_Click);
            // 
            // ofdOpenMugenExePath
            // 
            this.ofdOpenMugenExePath.Filter = "可执行程序|*.exe";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(243, 61);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(324, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StartUpForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(411, 94);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpMugenExePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择MUGEN程序位置";
            this.Load += new System.EventHandler(this.StartUpForm_Load);
            this.grpMugenExePath.ResumeLayout(false);
            this.grpMugenExePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMugenExePath;
        private System.Windows.Forms.Label lblMugenExePath;
        private System.Windows.Forms.TextBox txtMugenExePath;
        private System.Windows.Forms.Button btnOpenMugenExePath;
        private System.Windows.Forms.OpenFileDialog ofdOpenMugenExePath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip ttpCommon;
    }
}