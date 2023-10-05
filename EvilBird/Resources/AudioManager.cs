using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird.Resources
{
    internal class AudioManager : GameObject
    {
        private static readonly string _soundPath
           = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Audio\Sound\");
        private Dictionary<string, Sound> Sounds { get; }
        
        private static readonly string _musicPath
           = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Audio\Music\");
        private Dictionary<string, Music> Songs { get; }

        public AudioManager()
        {
            Sounds = new Dictionary<string, Sound>();
            Songs = new Dictionary<string, Music>();
        }

        public override void Start()
        {
            Load();
            base.Start();
        }

        public override void Dispose()
        {
            Unload();
            base.Dispose();
        }

        public void PlaySound(string name)
        {
            var sound = Sounds[name];
            Raylib.PlaySound(sound);
        }

        public void StartMusic(string name)
        {
            var music = Songs[name];
            Raylib.PlayMusicStream(music);
        }
        public void UpdateMusic(string name)
        {
            var music = Songs[name];
            Raylib.UpdateMusicStream(music);
        }

        private void Load()
        {
            Sound Countdown = Raylib.LoadSound(_soundPath + "Countdown.wav");
            Sounds.Add("Countdown", Countdown);
            
            Sound Death = Raylib.LoadSound(_soundPath + "Death.wav");
            Sounds.Add("Death", Death);

            Sound Jump = Raylib.LoadSound(_soundPath + "Jump.wav");
            Sounds.Add("Jump", Jump);
            
            Sound Corn = Raylib.LoadSound(_soundPath + "Corn.wav");
            Sounds.Add("Corn", Corn);

            Music Music = Raylib.LoadMusicStream(_musicPath + "Music.mp3");
            Songs.Add("Music", Music);
        }

        private void Unload()
        {
            foreach (var sound in Sounds)
            {
                Raylib.UnloadSound(sound.Value);
            }
            Sounds.Clear();
            
            foreach (var music in Songs)
            {
                Raylib.UnloadMusicStream(music.Value);
            }
            Songs.Clear();
        }
    }
}
