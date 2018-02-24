namespace Muzik
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainBGPanel = new System.Windows.Forms.Panel();
            this.drumPlay = new System.Windows.Forms.PictureBox();
            this.guitarPlay = new System.Windows.Forms.PictureBox();
            this.pianoPlay = new System.Windows.Forms.PictureBox();
            this.drumPic = new System.Windows.Forms.PictureBox();
            this.GuitarPic = new System.Windows.Forms.PictureBox();
            this.pianoPic = new System.Windows.Forms.PictureBox();
            this.BGPic = new System.Windows.Forms.PictureBox();
            this.send_Btn = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.MainBGPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drumPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guitarPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drumPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuitarPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.send_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.drumPlay);
            this.panel1.Controls.Add(this.guitarPlay);
            this.panel1.Controls.Add(this.pianoPlay);
            this.panel1.Controls.Add(this.drumPic);
            this.panel1.Controls.Add(this.GuitarPic);
            this.panel1.Controls.Add(this.pianoPic);
            this.panel1.Location = new System.Drawing.Point(12, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 235);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MD아트체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(405, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "드럼연주하기";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MD아트체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(216, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "기타연주하기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MD아트체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(11, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "피아노연주하기";
            // 
            // MainBGPanel
            // 
            this.MainBGPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MainBGPanel.Controls.Add(this.send_Btn);
            this.MainBGPanel.Controls.Add(this.BGPic);
            this.MainBGPanel.Location = new System.Drawing.Point(1, -1);
            this.MainBGPanel.Name = "MainBGPanel";
            this.MainBGPanel.Size = new System.Drawing.Size(543, 504);
            this.MainBGPanel.TabIndex = 3;
            // 
            // drumPlay
            // 
            this.drumPlay.BackColor = System.Drawing.Color.Transparent;
            this.drumPlay.Image = global::Muzik.Properties.Resources.Play;
            this.drumPlay.Location = new System.Drawing.Point(404, 31);
            this.drumPlay.Name = "drumPlay";
            this.drumPlay.Size = new System.Drawing.Size(98, 49);
            this.drumPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drumPlay.TabIndex = 5;
            this.drumPlay.TabStop = false;
            this.drumPlay.Visible = false;
            // 
            // guitarPlay
            // 
            this.guitarPlay.BackColor = System.Drawing.Color.Transparent;
            this.guitarPlay.Image = global::Muzik.Properties.Resources.Play;
            this.guitarPlay.Location = new System.Drawing.Point(209, 31);
            this.guitarPlay.Name = "guitarPlay";
            this.guitarPlay.Size = new System.Drawing.Size(104, 49);
            this.guitarPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guitarPlay.TabIndex = 4;
            this.guitarPlay.TabStop = false;
            this.guitarPlay.Visible = false;
            // 
            // pianoPlay
            // 
            this.pianoPlay.BackColor = System.Drawing.Color.Transparent;
            this.pianoPlay.Image = global::Muzik.Properties.Resources.Play;
            this.pianoPlay.Location = new System.Drawing.Point(14, 31);
            this.pianoPlay.Name = "pianoPlay";
            this.pianoPlay.Size = new System.Drawing.Size(104, 49);
            this.pianoPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pianoPlay.TabIndex = 3;
            this.pianoPlay.TabStop = false;
            this.pianoPlay.Visible = false;
            // 
            // drumPic
            // 
            this.drumPic.Image = global::Muzik.Properties.Resources.탬버린;
            this.drumPic.Location = new System.Drawing.Point(404, 86);
            this.drumPic.Name = "drumPic";
            this.drumPic.Size = new System.Drawing.Size(98, 106);
            this.drumPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drumPic.TabIndex = 2;
            this.drumPic.TabStop = false;
            this.drumPic.Click += new System.EventHandler(this.drumPic_Click);
            this.drumPic.MouseEnter += new System.EventHandler(this.drumPic_MouseEnter);
            this.drumPic.MouseLeave += new System.EventHandler(this.drumPic_MouseLeave);
            // 
            // GuitarPic
            // 
            this.GuitarPic.Image = global::Muzik.Properties.Resources.우쿨렐레;
            this.GuitarPic.Location = new System.Drawing.Point(209, 86);
            this.GuitarPic.Name = "GuitarPic";
            this.GuitarPic.Size = new System.Drawing.Size(104, 106);
            this.GuitarPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GuitarPic.TabIndex = 1;
            this.GuitarPic.TabStop = false;
            this.GuitarPic.Click += new System.EventHandler(this.GuitarPic_Click);
            this.GuitarPic.MouseEnter += new System.EventHandler(this.GuitarPic_MouseEnter);
            this.GuitarPic.MouseLeave += new System.EventHandler(this.GuitarPic_MouseLeave);
            // 
            // pianoPic
            // 
            this.pianoPic.Image = global::Muzik.Properties.Resources.피아노;
            this.pianoPic.Location = new System.Drawing.Point(14, 86);
            this.pianoPic.Name = "pianoPic";
            this.pianoPic.Size = new System.Drawing.Size(104, 106);
            this.pianoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pianoPic.TabIndex = 0;
            this.pianoPic.TabStop = false;
            this.pianoPic.Click += new System.EventHandler(this.pianoPic_Click);
            this.pianoPic.MouseEnter += new System.EventHandler(this.pianoPic_MouseEnter);
            this.pianoPic.MouseLeave += new System.EventHandler(this.pianoPic_MouseLeave);
            // 
            // BGPic
            // 
            this.BGPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BGPic.Image = global::Muzik.Properties.Resources.melody_148443_1280;
            this.BGPic.Location = new System.Drawing.Point(11, 13);
            this.BGPic.Name = "BGPic";
            this.BGPic.Size = new System.Drawing.Size(522, 237);
            this.BGPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BGPic.TabIndex = 0;
            this.BGPic.TabStop = false;
            // 
            // send_Btn
            // 
            this.send_Btn.BackColor = System.Drawing.Color.Transparent;
            this.send_Btn.Image = global::Muzik.Properties.Resources.unnamed;
            this.send_Btn.Location = new System.Drawing.Point(262, 141);
            this.send_Btn.Name = "send_Btn";
            this.send_Btn.Size = new System.Drawing.Size(100, 91);
            this.send_Btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.send_Btn.TabIndex = 0;
            this.send_Btn.TabStop = false;
            this.send_Btn.Click += new System.EventHandler(this.send_Btn_Click);
            this.send_Btn.MouseEnter += new System.EventHandler(this.send_Btn_MouseEnter);
            this.send_Btn.MouseLeave += new System.EventHandler(this.send_Btn_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainBGPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muzik";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainBGPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drumPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guitarPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drumPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuitarPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pianoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BGPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.send_Btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BGPic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox drumPic;
        private System.Windows.Forms.PictureBox GuitarPic;
        private System.Windows.Forms.PictureBox pianoPic;
        private System.Windows.Forms.PictureBox pianoPlay;
        private System.Windows.Forms.PictureBox drumPlay;
        private System.Windows.Forms.PictureBox guitarPlay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MainBGPanel;
        private System.Windows.Forms.PictureBox send_Btn;
    }
}

