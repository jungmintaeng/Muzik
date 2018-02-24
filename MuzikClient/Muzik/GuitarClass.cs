using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FMOD;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Muzik
{
    class GuitarClass
    {
        public const int NUM_SONGS = 28;
        public const int RECORD_CHANNEL = NUM_SONGS;
        public const int PRESET_CHANNEL = NUM_SONGS + 1;
        public bool recordPlaying = false;

        public FMOD.System FMODSystem;
        public FMOD.Channel[] Channel;
        public FMOD.Sound[] Songs;

        public static GuitarClass _instance;

        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        public static void Init()
        {
            if (Environment.Is64BitProcess)
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\64\\fmod.dll"));
            else
                LoadLibrary(System.IO.Path.GetFullPath("FMOD\\32\\fmod.dll"));

            _instance = new GuitarClass();
        }

        public void Unload()
        {
            FMODSystem.release();
        }

        public GuitarClass()
        {
            FMOD.Factory.System_Create(out FMODSystem);

            FMODSystem.setDSPBufferSize(1024, 10);
            FMODSystem.init(32, FMOD.INITFLAGS.NORMAL, (IntPtr)0);

            Songs = new FMOD.Sound[NUM_SONGS + 2];
            Channel = new FMOD.Channel[NUM_SONGS + 2];

            LoadSong(0, "A");
            LoadSong(1, "A7");
            LoadSong(2, "Am");
            LoadSong(3, "Am7");

            LoadSong(4, "B");
            LoadSong(5, "B7");
            LoadSong(6, "Bm");
            LoadSong(7, "Bm7");

            LoadSong(8, "C");
            LoadSong(9, "C7");
            LoadSong(10, "Cm");
            LoadSong(11, "Cm7");

            LoadSong(12, "D");
            LoadSong(13, "D7");
            LoadSong(14, "Dm");
            LoadSong(15, "Dm7");

            LoadSong(16, "E");
            LoadSong(17, "E7");
            LoadSong(18, "Em");
            LoadSong(19, "Em7");

            LoadSong(20, "F");
            LoadSong(21, "F7");
            LoadSong(22, "Fm");
            LoadSong(23, "Fm7");

            LoadSong(24, "G");
            LoadSong(25, "G7");
            LoadSong(26, "Gm");
            LoadSong(27, "Gm7");
        }

        public void LoadRecorded()
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Guitar\Recording.wav", FMOD.MODE.DEFAULT, out Songs[RECORD_CHANNEL]);
        }

        public void PlayRecorded()
        {
            FMODSystem.playSound(Songs[RECORD_CHANNEL], null, false, out Channel[RECORD_CHANNEL]);
            Channel[RECORD_CHANNEL].setVolume(10);
            Channel[RECORD_CHANNEL].setMode(FMOD.MODE.DEFAULT);
        }

        public void LoadSong(int songId, string name)
        {
            FMOD.RESULT r = FMODSystem.createStream(System.IO.Directory.GetCurrentDirectory() + @"\Music\Guitar\" + name + ".wav", FMOD.MODE.LOOP_NORMAL, out Songs[songId]);
        }

        public void LoadPreset(string path)
        {
            FMOD.RESULT r = FMODSystem.createStream(path, FMOD.MODE.DEFAULT, out Songs[PRESET_CHANNEL]);
            if (r == FMOD.RESULT.OK)
                MessageBox.Show("Load 성공");
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
                Channel[songId].setMode(FMOD.MODE.LOOP_NORMAL);
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

        public void Stop(int num)
        {
                if (Channel[num] != null)
                    Channel[num].stop();
        }
    }
}
