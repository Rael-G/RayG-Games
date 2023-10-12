using Raylib_cs;

namespace RayG
{
    public class FontManager : ResourceManager<Font>
    {

        /// <param name="path">The path to the font resource files, relative to the location of the executable.</param>
        public FontManager(string path) : base(path) { }

        /// <summary>
        /// Retrieves a font resource by its name.
        /// </summary>
        /// <param name="name">The name of the font resource to retrieve.</param>
        /// <returns>The font resource identified by the specified name.</returns>
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