using RayG;
using Raylib_cs;

namespace Breakout.Resources
{
    internal class TextureManager : GameObject
    {
        private static readonly string _path
           = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Breakout\Textures\");
        private Dictionary<string, Texture2D> Textures { get; }

        public TextureManager()
        {
            Textures = new Dictionary<string, Texture2D>();
        }

        public override void Start()
        {
            Load();
            base.Start();
        }

        public override void Dispose()
        {
            Unload();
            base.Dispose();
        }

        public Texture2D GetTexture(string name)
        {
            return Textures[name];
        }

        private void Load()
        {
            Texture2D RedBlueGirl = Raylib.LoadTexture(_path + "RedBlueGirl.png");
            Textures.Add("RedBlueGirl", RedBlueGirl);
        }

        private void Unload()
        {
            foreach (var texture in Textures)
            {
                Raylib.UnloadTexture(texture.Value);
            }
            Textures.Clear();
        }
    }
}
