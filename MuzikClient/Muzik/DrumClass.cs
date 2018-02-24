using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FMOD;
using System.Drawing;
using System.Windows.Forms;

namespace Muzik
{
    public class DrumPlayer
    {
        public const int NUM_SONGS = 9;
        public const int RECORD_CHANNEL = NUM_SONGS;
        public const int PRESET_CHANNEL = NUM_SONGS + 1;
        public bool recordPlaying = false;

        public FMOD.System FMODSystem;
        public FMOD.Channel[] Channel;
        public FMOD.Sound[] Songs;

        public static DrumPlayer _instance;

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            if (Environment.Is64BitProcess)
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\64\\fmod.dll"));
            else
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\32\\fmod.dll"));

            _instance = new DrumPlayer();
        }

        public void Unload()
        {
            FMODSystem.release();
        }

        public DrumPlayer()
        {
            FMOD.Factory.System_Create(out FMODSystem);

            FMODSystem.setDSPBufferSize(1024, 10);
            FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);

            Songs = new FMOD.Sound[NUM_SONGS + 2];
            Channel = new FMOD.Channel[NUM_SONGS + 2];

            LoadSong(0, "ClHihat");
            LoadSong(1, "Crash");
            LoadSong(2, "HiSnare");
            LoadSong(3, "HiTom");
            LoadSong(4, "Kick");
            LoadSong(5, "LowTom");
            LoadSong(6, "OpHihat");
            LoadSong(7, "Ride");
            LoadSong(8, "Snare");
        }

        public void LoadRecorded()
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Drum\Recording.wav", FMOD.MODE.DEFAULT, out Songs[RECORD_CHANNEL]);
        }

        public void LoadPreset(string path)
        {
            FMOD.RESULT r = FMODSystem.createStream(path, FMOD.MODE.DEFAULT, out Songs[PRESET_CHANNEL]);
            if (r == FMOD.RESULT.OK)
                MessageBox.Show("Load 성공");
        }

        public void PlayPreset()
        {
            if (Songs[PRESET_CHANNEL] != null)
            {
                FMODSystem.playSound(Songs[PRESET_CHANNEL], null, false, out Channel[PRESET_CHANNEL]);
                Channel[PRESET_CHANNEL].setMode(FMOD.MODE.DEFAULT);
            }
        }

        public void PlayRecorded()
        {
            FMODSystem.playSound(Songs[RECORD_CHANNEL], null, false, out Channel[RECORD_CHANNEL]);
            Channel[RECORD_CHANNEL].setVolume(10);
            Channel[RECORD_CHANNEL].setMode(FMOD.MODE.DEFAULT);
        }

        public void LoadSong(int songId, string name)
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Drum\" + name + ".wav", FMOD.MODE.DEFAULT, out Songs[songId]);
        }

        public bool IsPlaying(FMOD.Channel channel)
        {
            bool returnbool = false;
            if(channel != null)
                channel.isPlaying(out returnbool);
            return  returnbool;
        }

        public void Play(int songId)
        {
            if (songId >= 0 && songId < NUM_SONGS + 2 && Songs[songId] != null)
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

        public void Stop()
        {
            for (int i = 0; i < NUM_SONGS + 2; i++)
                if (IsPlaying(Channel[i]))
                    Channel[i].stop();
        }
    }
}