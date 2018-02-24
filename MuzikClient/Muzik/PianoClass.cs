using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;
using System.Runtime.InteropServices;

namespace Muzik
{
    class PianoClass
    {
        public const int NUM_SONGS = 32;
        public const int RECORD_CHANNEL = NUM_SONGS;
        public const int PRESET_CHANNEL = NUM_SONGS + 1;
        public bool recordPlaying = false;

        public FMOD.System FMODSystem;
        public FMOD.Channel[] Channel;
        public FMOD.Sound[] Songs;

        public static PianoClass _instance;

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            if (Environment.Is64BitProcess)
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\64\\fmod.dll"));
            else
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\32\\fmod.dll"));

            _instance = new PianoClass();
        }

        public void Unload()
        {
            FMODSystem.release();
        }

        public PianoClass()
        {
            FMOD.Factory.System_Create(out FMODSystem);

            FMODSystem.setDSPBufferSize(1024, 10);
            FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);

            Songs = new FMOD.Sound[NUM_SONGS + 2];
            Channel = new FMOD.Channel[NUM_SONGS + 2];

            LoadSong(0, "C");
            LoadSong(1, "D");
            LoadSong(2, "E");
            LoadSong(3, "F");
            LoadSong(4, "G");
            LoadSong(5, "A");
            LoadSong(6, "B");
            LoadSong(7, "HighC");
            LoadSong(8, "majC");
            LoadSong(9, "majD");
            LoadSong(10, "majE");
            LoadSong(11, "majF");
            LoadSong(12, "majG");
            LoadSong(13, "majA");
            LoadSong(14, "majB");
            LoadSong(15, "majC#");
            LoadSong(16, "majD#");
            LoadSong(17, "majF#");
            LoadSong(18, "majG#");
            LoadSong(19, "majA#");
            LoadSong(20, "lowCm");
            LoadSong(21, "lowDm");
            LoadSong(22, "lowEm");
            LoadSong(23, "lowFm");
            LoadSong(24, "lowGm");
            LoadSong(25, "lowAm");
            LoadSong(26, "lowBm");
            LoadSong(27, "lowC#m");
            LoadSong(28, "lowD#m");
            LoadSong(29, "lowF#m");
            LoadSong(30, "lowG#m");
            LoadSong(31, "lowA#m");
        }

        public void LoadRecorded()
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Piano\Recording.wav", FMOD.MODE.DEFAULT, out Songs[RECORD_CHANNEL]);
        }

        public void PlayRecorded()
        {
            FMODSystem.playSound(Songs[RECORD_CHANNEL], null, false, out Channel[RECORD_CHANNEL]);
            Channel[RECORD_CHANNEL].setVolume(10);
            Channel[RECORD_CHANNEL].setMode(FMOD.MODE.DEFAULT);
        }

        public void LoadSong(int songId, string name)
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Piano\" + name + ".wav", FMOD.MODE.DEFAULT, out Songs[songId]);
        }

        public bool IsPlaying(FMOD.Channel channel)
        {
            bool returnbool = false;
            channel.isPlaying(out returnbool);
            return returnbool;
        }

        public void Play(int songId)
        {
            if (songId >= 0 && songId < NUM_SONGS && Songs[songId] != null)
            {
                FMODSystem.playSound(Songs[songId], null, false, out Channel[songId]);
                Channel[songId].setMode(FMOD.MODE.DEFAULT);
            }
        }

        public void UpdateVolume(float Value)
        {
            for (int i = 0; i < NUM_SONGS; i++)
                if (Channel[i] != null)
                    Channel[i].setVolume(Value / 100);
        }

        public void UpdateVolume(int channnel, float Value)
        {
                if (Channel[channnel] != null)
                    Channel[channnel].setVolume(Value / 100);
        }

        public void Stop()
        {
            for (int i = 0; i < NUM_SONGS + 2; i++)
                if (IsPlaying(Channel[i]))
                    Channel[i].stop();
        }
        public void Stop(int i)
        {
                if (Channel[i] != null)
                    Channel[i].stop();
        }
    }
}
