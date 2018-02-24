using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Muzik
{
    public partial class DrumpadForm : Form
    {
        private bool recording = false;
        private Record record;

        public DrumpadForm()
        {
            InitializeComponent();
        }

        private void DrumpadForm_Load(object sender, EventArgs e)
        {
            DrumPlayer.Init();
            DrumPlayer._instance.UpdateVolume(100);
            this.KeyPreview = true;
            hit2.Parent = BG_Pic;
            hit3.Parent = BG_Pic;
            hit9.Parent = BG_Pic;
        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    {
                        DrumPlayer._instance.Play(1);//Crash
                        hit1.Visible = true;
                        break;
                    }
                case Keys.NumPad2:
                    {
                        DrumPlayer._instance.Play(3);//HiTom
                        hit2.Visible = true;
                        break;
                    }
                case Keys.NumPad3:
                    {
                        DrumPlayer._instance.Play(5);//LowTom
                        hit3.Visible = true;
                        break;
                    }
                case Keys.NumPad4:
                    {
                        DrumPlayer._instance.Play(0);//ClHihat
                        hit4.Visible = true;
                        break;
                    }
                case Keys.NumPad5:
                    {
                        DrumPlayer._instance.Play(4);//Kick
                        hit5.Visible = true;
                        break;
                    }
                case Keys.NumPad6:
                    {
                        DrumPlayer._instance.Play(7);//Ride
                        hit6.Visible = true;
                        break;
                    }
                case Keys.NumPad7:
                    {
                        DrumPlayer._instance.Play(6);//OpHihat
                        hit7.Visible = true;
                        break;
                    }
                case Keys.NumPad8:
                    {
                        DrumPlayer._instance.Play(2);//HiSnare
                        hit8.Visible = true;
                        break;
                    }
                case Keys.NumPad9:
                    {
                        DrumPlayer._instance.Play(8);//Snare
                        hit9.Visible = true;
                        break;
                    }
                case Keys.R:
                    {
                        try
                        {
                            if (recording)
                            {
                                record.Stop();
                                save_Btn.Enabled = true;
                                playRecordedBtn.Enabled = true;
                                releasePreset_Btn.Enabled = true;
                                loadPreset_Btn.Enabled = true;
                                DrumPlayer._instance.Stop();
                                label1.ForeColor = Color.Black;
                                label1.BackColor = Color.Gray;
                                label1.Text = "녹음 : R";
                                recording = false;
                                record.Abort();
                                DrumPlayer._instance.LoadRecorded();
                            }
                            else
                            {
                                if (DrumPlayer._instance.Songs[DrumPlayer.RECORD_CHANNEL] != null)
                                    DrumPlayer._instance.Songs[DrumPlayer.RECORD_CHANNEL].release();
                                record = new Record("Drum");
                                record.Start();
                                label1.Text = "Stop : R(Rec..)";
                                label1.ForeColor = Color.Red;
                                label1.BackColor = Color.Yellow;
                                recording = true;
                                save_Btn.Enabled = false;
                                playRecordedBtn.Enabled = false;
                                releasePreset_Btn.Enabled = false;
                                loadPreset_Btn.Enabled = false;
                            }
                        }
                        catch { }
                        break;
                    }
            }//switch 끝
        }//keydownevent 끝

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    {
                        hit1.Visible = false;
                        break;
                    }
                case Keys.NumPad2:
                    {
                        hit2.Visible = false;
                        break;
                    }
                case Keys.NumPad3:
                    {
                        hit3.Visible = false;
                        break;
                    }
                case Keys.NumPad4:
                    {
                        hit4.Visible = false;
                        break;
                    }
                case Keys.NumPad5:
                    {
                        hit5.Visible = false;
                        break;
                    }
                case Keys.NumPad6:
                    {
                        hit6.Visible = false;
                        break;
                    }
                case Keys.NumPad7:
                    {
                        hit7.Visible = false;
                        break;
                    }
                case Keys.NumPad8:
                    {
                        hit8.Visible = false;
                        break;
                    }
                case Keys.NumPad9:
                    {
                        hit9.Visible = false;
                        break;
                    }
            }//switch 끝
        }//keydownevent 끝

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playRecordedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DrumPlayer._instance.PlayRecorded();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("들어보기 전에 녹음부터 하시기 바랍니다 !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrumpadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DrumPlayer._instance.Unload();
            this.Owner.Show();
        }

        private void loadPreset_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DrumPlayer._instance.Stop();
                OpenFileDialog file = new OpenFileDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    DrumPlayer._instance.LoadPreset(file.FileName);
                    fileName_Label.Text = file.FileName;
                }
                FileInfo f = new FileInfo(file.FileName);
                DrumPlayer._instance.Play(DrumPlayer.PRESET_CHANNEL);
                if (f.Name == "Recording.wav")
                    DrumPlayer._instance.Channel[DrumPlayer.PRESET_CHANNEL].setVolume(10);
            }
            catch { }
        }

        private void releasePreset_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DrumPlayer._instance.Stop();
                if (DrumPlayer._instance.Songs[DrumPlayer.PRESET_CHANNEL] != null)
                    DrumPlayer._instance.Songs[DrumPlayer.PRESET_CHANNEL].release();
                fileName_Label.Text = "";
            }
            catch { }
        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DrumPlayer._instance.Songs[DrumPlayer.RECORD_CHANNEL].release();
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
                            File.Copy(Directory.GetCurrentDirectory() + @"\Music\Drum\Recording.wav", f.SelectedPath + "\\recording" + i.ToString() + ".wav");
                            break;
                        }

                    }
                    if (File.Exists(f.SelectedPath + "\\recording" + i.ToString() + ".wav"))
                        DrumPlayer._instance.LoadRecorded();
                }
            }
            catch(NullReferenceException)
            {
                
            }
        }
    }
}
