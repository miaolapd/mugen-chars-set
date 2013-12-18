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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.grpSetting = new System.Windows.Forms.GroupBox();
            this.btnOpenEditProgramPath = new System.Windows.Forms.Button();
            this.txtEditProgramPath = new System.Windows.Forms.TextBox();
            this.lblEditProgram = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.ofdExePath = new System.Windows.Forms.OpenFileDialog();
            this.grpMugenExePath = new System.Windows.Forms.GroupBox();
            this.lblMugenExePath = new System.Windows.Forms.Label();
            this.txtMugenExePath = new System.Windows.Forms.TextBox();
            this.btnOpenMugenExePath = new System.Windows.Forms.Button();
            this.ttpCommon = new System.Windows.Forms.ToolTip(this.components);
            this.grpSetting.SuspendLayout();
            this.grpMugenExePath.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSetting
            // 
            this.grpSetting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSetting.Controls.Add(this.btnOpenEditProgramPath);
            this.grpSetting.Controls.Add(this.txtEditProgramPath);
            this.grpSetting.Controls.Add(this.lblEditProgram);
            this.grpSetting.Location = new System.Drawing.Point(12, 61);
            this.grpSetting.Name = "grpSetting";
            this.grpSetting.Size = new System.Drawing.Size(391, 43);
            this.grpSetting.TabIndex = 1;
            this.grpSetting.TabStop = false;
            this.grpSetting.Text = "程序设置";
            // 
            // btnOpenEditProgramPath
            // 
            this.btnOpenEditProgramPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenEditProgramPath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenEditProgramPath.Location = new System.Drawing.Point(358, 12);
            this.btnOpenEditProgramPath.Name = "btnOpenEditProgramPath";
            this.btnOpenEditProgramPath.Size = new System.Drawing.Size(27, 23);
            this.btnOpenEditProgramPath.TabIndex = 2;
            this.btnOpenEditProgramPath.Text = "...";
            this.btnOpenEditProgramPath.UseVisualStyleBackColor = true;
            this.btnOpenEditProgramPath.Click += new System.EventHandler(this.btnOpenEditProgramPath_Click);
            // 
            // txtEditProgramPath
            // 
            this.txtEditProgramPath.AllowDrop = true;
            this.txtEditProgramPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditProgramPath.Location = new System.Drawing.Point(107, 14);
            this.txtEditProgramPath.Name = "txtEditProgramPath";
            this.txtEditProgramPath.Size = new System.Drawing.Size(245, 21);
            this.txtEditProgramPath.TabIndex = 1;
            this.ttpCommon.SetToolTip(this.txtEditProgramPath, "可将程序拖拽到此处");
            this.txtEditProgramPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtEditProgramPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // lblEditProgram
            // 
            this.lblEditProgram.AutoSize = true;
            this.lblEditProgram.Location = new System.Drawing.Point(6, 17);
            this.lblEditProgram.Name = "lblEditProgram";
            this.lblEditProgram.Size = new System.Drawing.Size(77, 12);
            this.lblEditProgram.TabIndex = 0;
            this.lblEditProgram.Text = "文本编辑器：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(101, 110);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(182, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(263, 110);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 4;
            this.btnDefault.Text = "默认值";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // ofdExePath
            // 
            this.ofdExePath.Filter = "可执行程序|*.exe";
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
            this.grpMugenExePath.Size = new System.Drawing.Size(391, 43);
            this.grpMugenExePath.TabIndex = 0;
            this.grpMugenExePath.TabStop = false;
            this.grpMugenExePath.Text = "MUGEN程序";
            // 
            // lblMugenExePath
            // 
            this.lblMugenExePath.AutoSize = true;
            this.lblMugenExePath.Location = new System.Drawing.Point(6, 18);
            this.lblMugenExePath.Name = "lblMugenExePath";
            this.lblMugenExePath.Size = new System.Drawing.Size(95, 12);
            this.lblMugenExePath.TabIndex = 0;
            this.lblMugenExePath.Text = "MUGEN程序位置：";
            // 
            // txtMugenExePath
            // 
            this.txtMugenExePath.AllowDrop = true;
            this.txtMugenExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMugenExePath.Location = new System.Drawing.Point(107, 15);
            this.txtMugenExePath.Name = "txtMugenExePath";
            this.txtMugenExePath.Size = new System.Drawing.Size(245, 21);
            this.txtMugenExePath.TabIndex = 1;
            this.ttpCommon.SetToolTip(this.txtMugenExePath, "可将程序拖拽到此处");
            this.txtMugenExePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath_DragDrop);
            this.txtMugenExePath.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath_DragEnter);
            // 
            // btnOpenMugenExePath
            // 
            this.btnOpenMugenExePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMugenExePath.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenMugenExePath.Location = new System.Drawing.Point(358, 14);
            this.btnOpenMugenExePath.Name = "btnOpenMugenExePath";
            this.btnOpenMugenExePath.Size = new System.Drawing.Size(27, 23);
            this.btnOpenMugenExePath.TabIndex = 2;
            this.btnOpenMugenExePath.Text = "...";
            this.btnOpenMugenExePath.UseVisualStyleBackColor = true;
            this.btnOpenMugenExePath.Click += new System.EventHandler(this.btnOpenMugenExePath_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(415, 145);
            this.Controls.Add(this.grpMugenExePath);
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
            this.grpMugenExePath.ResumeLayout(false);
            this.grpMugenExePath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSetting;
        private System.Windows.Forms.TextBox txtEditProgramPath;
        private System.Windows.Forms.Label lblEditProgram;
        private System.Windows.Forms.Button btnOpenEditProgramPath;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.OpenFileDialog ofdExePath;
        private System.Windows.Forms.GroupBox grpMugenExePath;
        private System.Windows.Forms.Label lblMugenExePath;
        private System.Windows.Forms.TextBox txtMugenExePath;
        private System.Windows.Forms.Button btnOpenMugenExePath;
        private System.Windows.Forms.ToolTip ttpCommon;
    }
}