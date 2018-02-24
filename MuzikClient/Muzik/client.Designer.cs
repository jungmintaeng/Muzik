namespace Muzik
{
    partial class client
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SelectFileBtn = new System.Windows.Forms.Button();
            this.FilePathBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(14, 284);
            this.ProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(359, 22);
            this.ProgressBar.TabIndex = 37;
            // 
            // FileTextBox
            // 
            this.FileTextBox.Location = new System.Drawing.Point(69, 49);
            this.FileTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.ReadOnly = true;
            this.FileTextBox.Size = new System.Drawing.Size(303, 25);
            this.FileTextBox.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("한컴 바겐세일 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(16, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 25);
            this.label4.TabIndex = 34;
            this.label4.Text = "File ";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(69, 18);
            this.PathTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(303, 25);
            this.PathTextBox.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 바겐세일 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(15, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Path ";
            // 
            // SendBtn
            // 
            this.SendBtn.Font = new System.Drawing.Font("한컴 바겐세일 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SendBtn.Location = new System.Drawing.Point(14, 222);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(359, 52);
            this.SendBtn.TabIndex = 31;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // SelectFileBtn
            // 
            this.SelectFileBtn.Font = new System.Drawing.Font("한컴 바겐세일 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SelectFileBtn.Location = new System.Drawing.Point(14, 166);
            this.SelectFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFileBtn.Name = "SelectFileBtn";
            this.SelectFileBtn.Size = new System.Drawing.Size(359, 52);
            this.SelectFileBtn.TabIndex = 30;
            this.SelectFileBtn.Text = "Select file";
            this.SelectFileBtn.UseVisualStyleBackColor = true;
            this.SelectFileBtn.Click += new System.EventHandler(this.SelectFileBtn_Click);
            // 
            // FilePathBtn
            // 
            this.FilePathBtn.Font = new System.Drawing.Font("한컴 바겐세일 B", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FilePathBtn.Location = new System.Drawing.Point(14, 80);
            this.FilePathBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilePathBtn.Name = "FilePathBtn";
            this.FilePathBtn.Size = new System.Drawing.Size(359, 52);
            this.FilePathBtn.TabIndex = 29;
            this.FilePathBtn.Text = "File Path";
            this.FilePathBtn.UseVisualStyleBackColor = true;
            this.FilePathBtn.Click += new System.EventHandler(this.FilePathBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 325);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.FileTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.SelectFileBtn);
            this.Controls.Add(this.FilePathBtn);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "client";
            this.Text = "client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button SelectFileBtn;
        private System.Windows.Forms.Button FilePathBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}