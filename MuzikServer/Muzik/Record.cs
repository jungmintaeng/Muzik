using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CSCore;
using CSCore.SoundIn;
using CSCore.Codecs.WAV;

namespace Muzik
{
    public class Record
    {
        private WasapiCapture capture;
        private WaveWriter ww;

        public Record(string instName)
        {
            capture = new WasapiLoopbackCapture();
            capture.Initialize();
            ww = new WaveWriter(System.IO.Directory.GetCurrentDirectory() + @"\Music\"+ instName +@"\Recording.wav", capture.WaveFormat);
            capture.DataAvailable += (s, e) =>
            {
                //녹음 데이터 설정
                ww.Write(e.Data, e.Offset, e.ByteCount);
            };
        }

        public void Start()
        {
            capture.Start();
        }

        public void Stop()
        {
            capture.Stop();
        }

        public void Abort()
        {
            capture.Dispose();
            ww.Dispose();
        }
    }
}
/*
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
    
        public static void Start()
        {
            mciSendString("open new type waveaudio alias recsound", null, 0 , 0);
            mciSendString("record recsound", null, 0, 0);
        }

        public static void Stop()
        {
            mciSendString(@"save recsound " + System.IO.Directory.GetCurrentDirectory() + @"\Music\Drum\Recording.wav", null, 0, 0);
            mciSendString("close recsound ", null, 0, 0);
        }

        public static void PlayRecorded()
        {
            mciSendString("open \"" + System.IO.Directory.GetCurrentDirectory() + @"\Music\Drum\CliHihat.wav" + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
        }*/
