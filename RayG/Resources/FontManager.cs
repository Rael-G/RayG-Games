using Raylib_cs;

namespace RayG
{
    public class FontManager : ResourceManager<Font>
    {
        public FontManager(string path, string[] names) : base(path, names) { }

        public Font GetFont(string name)
        {
            return Resources[name];
        }

        protected override void Load()
        {
            foreach (var name in Names)
            {
                var font = Raylib.LoadFont(Path + name);

                var splitedName = name.Split('.');
                Resources.Add(splitedName[0], font);
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