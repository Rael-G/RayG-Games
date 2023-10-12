using Raylib_cs;

namespace RayG
{
    public class FontManager : ResourceManager<Font>
    {
        public FontManager(string path) : base(path) { }

        public Font GetFont(string name)
        {
            return Resources[name];
        }

        protected override void Load()
        {
            foreach (var file in Files)
            {
                var font = Raylib.LoadFont(file);

                var name = System.IO.Path.GetFileNameWithoutExtension(file);
                Resources.Add(name, font);
            }
        }

        protected override void Unload()
        {
            foreach (var texture in Resources)
            {
                Raylib.UnloadFont(texture.Value);
            }
            Resources.Clear();
        }
    }
}