using Raylib_cs;

namespace RayG
{
    public class TextureManager : ResourceManager<Texture2D>
    {
        public TextureManager(string path, string[] names) : base(path, names) { }

        public Texture2D GetTexture(string name)
        {
            return Resources[name];
        }

        protected override void Load()
        {
            foreach (var name in Names)
            {
                var texture = Raylib.LoadTexture(Path + name);

                var splitedName = name.Split('.');
                Resources.Add(splitedName[0], texture);
            }
        }

        protected override void Unload()
        {
            foreach (var texture in Resources)
            {
                Raylib.UnloadTexture(texture.Value);
            }
            Resources.Clear();
        }
    }
}