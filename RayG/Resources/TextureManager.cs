using Raylib_cs;

namespace RayG
{
    public class TextureManager : ResourceManager<Texture2D>
    {
        /// <param name="path">The path to the font resource files, relative to the location of the executable.</param>
        public TextureManager(string path) : base(path) { }

        /// <summary>
        /// Retrieves a texture resource by its name.
        /// </summary>
        /// <param name="name">The name of the texture resource to retrieve.</param>
        /// <returns>The texture resource identified by the specified name.</returns>
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