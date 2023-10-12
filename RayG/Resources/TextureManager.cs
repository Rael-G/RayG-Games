using Raylib_cs;

namespace RayG
{
    public class TextureManager : ResourceManager<Texture2D>
    {
        public TextureManager(string path) : base(path) { }

        public Texture2D GetTexture(string name)
        {
            return Resources[name];
        }

        protected override void Load()
        {
            foreach (var file in Files)
            {
                var texture = Raylib.LoadTexture(file);

                var name = System.IO.Path.GetFileNameWithoutExtension(file);
                Resources.Add(name, texture);
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