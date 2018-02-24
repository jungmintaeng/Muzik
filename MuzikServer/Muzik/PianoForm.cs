using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;


namespace Muzik
{
    public partial class PianoForm : Form
    {
        private bool recording = false;
        Record record;

        public PianoForm()
        {
            InitializeComponent();
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PianoForm_Load(object sender, EventArgs e)
        {
            PianoClass.Init();

            this.KeyPreview = true;
        }

        private void LowCs_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(15);
        }

        private void LowDs_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(16);
        }

        private void LowFs_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(17);
        }

        private void LowGs_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(18);
        }

        private void LowAs_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(19);
        }

        private void LowC_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(8);
        }

        private void LowD_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(9);
        }

        private void LowE_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(10);
        }

        private void LowF_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(11);
        }

        private void LowG_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(12);
        }

        private void LowA_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(13);
        }

        private void LowB_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(14);
        }

        private void LowCsm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(27);
        }

        private void LowDsm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(28);
        }

        private void LowFsm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(29);
        }

        private void LowGsm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(30);
        }

        private void LowAsm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(31);
        }

        private void LowCm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(20);
        }

        private void LowDm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(21);
        }

        private void LowEm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(22);
        }

        private void LowFm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(23);
        }

        private void LowGm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(24);
        }

        private void LowAm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(25);
        }

        private void LowBm_Btn_Click(object sender, EventArgs e)
        {
            PianoClass._instance.Play(26);
        }

        private void Piano_Pic_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                record.Stop();
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.White;
                label1.Text = "Click Piano picture to start recording";
                recording = false;
                playRecorded_Btn.Enabled = true;
                save_Btn.Enabled = true;
                record.Abort();
                PianoClass._instance.LoadRecorded();
            }
            else
            {
                if (PianoClass._instance.Songs[PianoClass.RECORD_CHANNEL] != null)
                    PianoClass._instance.Songs[PianoClass.RECORD_CHANNEL].release();
                record = new Record("Piano");
                record.Start();
                label1.Text = "Recording..... Click to STOP";
                label1.ForeColor = Color.Red;
                label1.BackColor = Color.Yellow;
                save_Btn.Enabled = false;
                playRecorded_Btn.Enabled = false;
                recording = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PianoClass._instance.PlayRecorded();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("먼저 녹음부터 하시고 들어보세요 !");
            }
        }

        private void PianoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PianoClass._instance.Unload();
            this.Owner.Show();
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                PianoClass._instance.Songs[PianoClass.RECORD_CHANNEL].release();
                FolderBrowserDialog f = new FolderBrowserDialog();
                f.ShowDialog();
                if (f.SelectedPath != null)
                {
                    int i = 0;
                    while (true)
                    {
                        i++;
                        if (!File.Exists(f.SelectedPath + "\\recording" + i.ToString() + ".wav"))
                        {
                            File.Copy(Directory.GetCurrentDirectory() + @"\Music\Piano\Recording.wav", f.SelectedPath + "\\recording" + i.ToString() + ".wav");
                            break;
                        }
                    }
                    if (File.Exists(f.SelectedPath + "\\recording" + i.ToString() + ".wav"))
                        PianoClass._instance.LoadRecorded();
                }
            }
            catch { }
        }
    }
}
