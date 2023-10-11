using Raylib_cs;

namespace RayG
{
    public class MusicManager : ResourceManager<Music>
    {
        public MusicManager(string path, string[] names) : base(path, names) { }

        public void StartMusic(string name, float volume = 1f, float pitch = 1f)
        {
            var song = Resources[name];
            Raylib.SetMusicVolume(song, volume);
            Raylib.SetMusicPitch(song, pitch);
            Raylib.PlayMusicStream(song);
        }

        public void UpdateMusic(string name)
        {
            var song = Resources[name];
            Raylib.UpdateMusicStream(song);
        }

        protected override void Load()
        {
            foreach (var name in Names)
            {
                var song = Raylib.LoadMusicStream(Path + name);

                var splitedName = name.Split('.');
                Resources.Add(splitedName[0], song);
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