using Raylib_cs;

namespace RayG
{
    public class SoundManager : ResourceManager<Sound>
    {
        public SoundManager(string path) : base(path) { }

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
