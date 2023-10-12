using Raylib_cs;

namespace RayG
{
    public class SoundManager : ResourceManager<Sound>
    {
        /// <param name="path">The path to the font resource files, relative to the location of the executable.</param>
        public SoundManager(string path) : base(path) { }

        /// <summary>
        /// Plays a sound resource with optional volume and pitch adjustments.
        /// </summary>
        /// <param name="name">The name of the sound resource to play.</param>
        /// <param name="volume">The volume level (0.0 to 1.0, 1.0 by default).</param>
        /// <param name="pitch">The pitch (1.0 by default).</param>
        public void PlaySound(string name, float volume = 1f, float pitch = 1f)
        {
            var sound = Resources[name];
            Raylib.SetSoundVolume(sound, volume);
            Raylib.SetSoundPitch(sound, pitch);
            Raylib.PlaySound(Resources[name]);
        }

        protected override void Load()
        { 
            foreach (var file in Files)
            {
                var sound = Raylib.LoadSound(file);

                var name = System.IO.Path.GetFileNameWithoutExtension(file);
                Resources.Add(name, sound);
            }
        }

        protected override void Unload()
        {
            foreach (var sound in Resources)
            {
                Raylib.UnloadSound(sound.Value);
            }
            Resources.Clear();
        }
    }
}
