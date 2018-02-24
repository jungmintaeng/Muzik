using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Muzik
{
    public partial class MainForm : Form
    {
        public NetworkStream Netstream;
        public TcpClient client;
        const int PIANO_KIT = 0;
        const int GUITAR_KIT = 1;
        const int DRUM_KIT = 2;

        public string User;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\AudioSpectrum\AudioSpectrum\bin\Debug\AudioSpectrum.exe";

            Process.Start(path);
            this.send_Btn.Parent = this.BGPic;
        }

        // 아이콘 마우스 이벤트
        private void pianoPic_MouseEnter(object sender, EventArgs e)
        {
            pianoPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void pianoPic_MouseLeave(object sender, EventArgs e)
        {
            pianoPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void GuitarPic_MouseEnter(object sender, EventArgs e)
        {
            guitarPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void GuitarPic_MouseLeave(object sender, EventArgs e)
        {
            guitarPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void drumPic_MouseEnter(object sender, EventArgs e)
        {
            drumPlay.Visible = true;
            this.Cursor = Cursors.Hand;
        }

        private void drumPic_MouseLeave(object sender, EventArgs e)
        {
            drumPlay.Visible = false;
            this.Cursor = Cursors.Default;
        }

        private void pianoPlay_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void send_Btn_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void send_Btn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        // 아이콘 마우스 이벤트 끝

        private void pianoPic_Click(object sender, EventArgs e)
        {
            PianoForm pianoform = new PianoForm();
            pianoform.Owner = this;
            pianoform.Show();
            this.Hide();
        }

        private void GuitarPic_Click(object sender, EventArgs e)
        {
            GuitarForm guitarform = new GuitarForm();
            guitarform.Owner = this;
            guitarform.Show();
            this.Hide();
        }

        private void drumPic_Click(object sender, EventArgs e)
        {
            DrumpadForm drumform = new DrumpadForm();
            drumform.Owner = this;
            this.Hide();
            drumform.Show();
            drumform.Activate();
            drumform.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Process pr in Process.GetProcesses())
                {
                    if (pr.ProcessName.StartsWith("AudioSpectrum"))
                    {
                        pr.Kill();
                    }
                }
            }
            catch { }
        }

        private void send_Btn_Click(object sender, EventArgs e)
        {
            client cli = new client();
            cli.Owner = this;
            cli.Cli = this.client;
            cli.NetStream = this.Netstream;
            cli.Show();
        }
    }
}
