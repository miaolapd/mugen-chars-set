namespace MUGENCharsSet
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.btnOpenEditProgram = new System.Windows.Forms.Button();
            this.txtEditProgram = new System.Windows.Forms.TextBox();
            this.lblEditProgram = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.ofdEditProgram = new System.Windows.Forms.OpenFileDialog();
            this.grpSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSetting
            // 
            this.grpSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetting.Controls.Add(this.btnOpenEditProgram);
            this.grpSetting.Controls.Add(this.txtEditProgram);
            this.grpSetting.Controls.Add(this.lblEditProgram);
            this.grpSetting.Location = new System.Drawing.Point(12, 12);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(379, 71);
            this.grpSetting.TabIndex = 0;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "程序设置";
            // 
            // btnOpenEditProgram
            // 
            this.btnOpenEditProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenEditProgram.Location = new System.Drawing.Point(342, 27);
            this.btnOpenEditProgram.Name = "btnOpenEditProgram";
            this.btnOpenEditProgram.Size = new System.Drawing.Size(31, 23);
            this.btnOpenEditProgram.TabIndex = 2;
            this.btnOpenEditProgram.Text = "...";
            this.btnOpenEditProgram.UseVisualStyleBackColor = true;
            this.btnOpenEditProgram.Click += new System.EventHandler(this.btnOpenEditProgram_Click);
            // 
            // txtEditProgram
            // 
            this.txtEditProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditProgram.Location = new System.Drawing.Point(89, 29);
            this.txtEditProgram.Name = "txtEditProgram";
            this.txtEditProgram.Size = new System.Drawing.Size(247, 21);
            this.txtEditProgram.TabIndex = 1;
            // 
            // lblEditProgram
            // 
            this.lblEditProgram.AutoSize = true;
            this.lblEditProgram.Location = new System.Drawing.Point(6, 32);
            this.lblEditProgram.Name = "lblEditProgram";
            this.lblEditProgram.Size = new System.Drawing.Size(77, 12);
            this.lblEditProgram.TabIndex = 0;
            this.lblEditProgram.Text = "文本编辑器：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(92, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(173, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(254, 95);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 3;
            this.btnDefault.Text = "默认值";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // ofdEditProgram
            // 
            this.ofdEditProgram.Filter = "可执行程序|*.exe";
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(403, 130);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.grpSetting.ResumeLayout(false);
            this.grpSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.TextBox txtEditProgram;
        private System.Windows.Forms.Label lblEditProgram;
        private System.Windows.Forms.Button btnOpenEditProgram;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.OpenFileDialog ofdEditProgram;
    }
}