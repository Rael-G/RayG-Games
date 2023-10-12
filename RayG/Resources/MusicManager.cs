using Raylib_cs;

namespace RayG
{
    public class MusicManager : ResourceManager<Music>
    {
        /// <param name="path">The path to the font resource files, relative to the location of the executable.</param>
        public MusicManager(string path) : base(path) { }

        /// <summary>
        /// Starts playing a music resource with optional volume and pitch settings.
        /// </summary>
        /// <param name="name">The name of the music resource to play.</param>
        /// <param name="volume">The volume level (0.0 to 1.0, 1.0 by default).</param>
        /// <param name="pitch">The pitch (speed) of playback (1.0 by default).</param>
        public void StartMusic(string name, float volume = 1f, float pitch = 1f)
        {
            var song = Resources[name];
            Raylib.SetMusicVolume(song, volume);
            Raylib.SetMusicPitch(song, pitch);
            Raylib.PlayMusicStream(song);
        }

        /// <summary>
        /// Updates the playback of a music resource; should be called once per frame.
        /// </summary>
        /// <param name="name">The name of the music resource to update.</param>
        public void UpdateMusic(string name)
        {
            var song = Resources[name];
            Raylib.UpdateMusicStream(song);
        }

        protected override void Load()
        {
            foreach (var file in Files)
            {
                var song = Raylib.LoadMusicStream(file);

                var name = System.IO.Path.GetFileNameWithoutExtension(file);
                Resources.Add(name, song);
            }
        }

        protected override void Unload()
        {
            foreach (var song in Resources)
            {
                Raylib.UnloadMusicStream(song.Value);
            }
            Resources.Clear();
        }
    }
}