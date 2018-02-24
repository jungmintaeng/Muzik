using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMOD;
using System.IO;

namespace Muzik
{
    public partial class GuitarForm : Form
    {
        bool recording = false;
        Record record;

        public GuitarForm()
        {
            InitializeComponent();
        }

        private void GuitarForm_Load(object sender, EventArgs e)
        {
            GuitarClass.Init();
            GuitarClass._instance.UpdateVolume(100);
            
            this.KeyPreview = true;
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.R)
            {
                if (recording)
                {
                    record.Stop();
                    recording_Label.ForeColor = Color.White;
                    recording_Label.BackColor = Color.Maroon;
                    recording_Label.Text = "녹음 : R";
                    save_Btn.Enabled = true;
                    playRecorded_Btn.Enabled = true;
                    recording = false;
                    record.Abort();
                    GuitarClass._instance.LoadRecorded();
                }
                else
                {
                    if (GuitarClass._instance.Songs[GuitarClass.RECORD_CHANNEL] != null)
                        GuitarClass._instance.Songs[GuitarClass.RECORD_CHANNEL].release();
                    record = new Record("Guitar");
                    record.Start();
                    recording_Label.Text = "Stop : R(Rec..)";
                    recording_Label.ForeColor = Color.Red;
                    recording_Label.BackColor = Color.Yellow;
                    save_Btn.Enabled = false;
                    playRecorded_Btn.Enabled = false;
                    recording = true;
                }
            }
        }


        //마우스 클릭, 클릭 뗐을 때 음원파일 재생, 정지
        private void A_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(0);
        }

        private void A_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(0);
        }

        private void A7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(1);
        }

        private void A7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(1);
        }

        private void Am_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(2);
        }

        private void Am_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(2);
        }

        private void Am7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(3);
        }

        private void Am7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(3);
        }

        private void B_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(4);
        }

        private void B_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(4);
        }

        private void B7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(5);
        }

        private void B7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(5);
        }

        private void Bm_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(6);
        }

        private void Bm_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(6);
        }

        private void Bm7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(7);
        }

        private void Bm7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(7);
        }

        private void C_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(8);
        }

        private void C_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(8);
        }

        private void C7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(9);
        }

        private void C7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(9);
        }

        private void Cm_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(10);
        }

        private void Cm_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(10);
        }

        private void Cm7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(11);
        }

        private void Cm7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(11);
        }

        private void D_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(12);
        }

        private void D_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(12);
        }

        private void D7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(13);
        }

        private void D7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(13);
        }

        private void Dm_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(14);
        }

        private void Dm_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(14);
        }

        private void Dm7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(15);
        }

        private void Dm7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(15);
        }

        private void E_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(16);
        }

        private void E_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(16);
        }

        private void E7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(17);
        }

        private void E7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(17);
        }

        private void Em_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(18);
        }

        private void Em_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(18);
        }

        private void Em7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(19);
        }

        private void Em7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(19);
        }

        private void F_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(20);
        }

        private void F_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(20);
        }

        private void F7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(21);
        }

        private void F7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(21);
        }

        private void Fm_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(22);
        }

        private void Fm_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(22);
        }

        private void Fm7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(23);
        }

        private void Fm7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(23);
        }

        private void G_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(24);
        }

        private void G_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(24);
        }

        private void G7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(25);
        }

        private void G7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(25);
        }

        private void Gm_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(26);
        }

        private void Gm_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(26);
        }

        private void Gm7_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Play(27);
        }

        private void Gm7_Btn_MouseUp(object sender, MouseEventArgs e)
        {
            GuitarClass._instance.Stop(27);
        }

        private void exit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playRecorded_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                GuitarClass._instance.PlayRecorded();
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("먼저 녹음하고 들어보세요!");
            }
        }

        private void GuitarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuitarClass._instance.Unload();
            this.Owner.Show();
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                GuitarClass._instance.Songs[GuitarClass.RECORD_CHANNEL].release();
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
                            File.Copy(Directory.GetCurrentDirectory() + @"\Music\Guitar\Recording.wav", f.SelectedPath + "\\recording" + i.ToString() + ".wav");
                            break;
                        }
                    }
                    if (File.Exists(f.SelectedPath + "\\recording" + i.ToString() + ".wav"))
                        GuitarClass._instance.LoadRecorded();
                }
            }
            catch { }
        }
    }
}
