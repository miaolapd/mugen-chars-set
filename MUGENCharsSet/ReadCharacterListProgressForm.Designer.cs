namespace MUGENCharsSet
{
    partial class ReadCharacterListProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadCharacterListProgressForm));
            this.prgReadCharacterList = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // prgReadCharacterList
            // 
            this.prgReadCharacterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgReadCharacterList.Location = new System.Drawing.Point(0, 0);
            this.prgReadCharacterList.MarqueeAnimationSpeed = 10;
            this.prgReadCharacterList.Name = "prgReadCharacterList";
            this.prgReadCharacterList.Size = new System.Drawing.Size(237, 29);
            this.prgReadCharacterList.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgReadCharacterList.TabIndex = 0;
            // 
            // ReadCharacterListProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 29);
            this.Controls.Add(this.prgReadCharacterList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReadCharacterListProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "正在读取人物列表……";
            this.Load += new System.EventHandler(this.ReadCharacterListProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgReadCharacterList;
    }
}