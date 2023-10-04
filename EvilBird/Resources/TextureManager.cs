using RayG;
using Raylib_cs;

namespace EvilBird.Resources
{
    internal class TextureManager : GameObject
    {
        private static readonly string _path
           = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Textures\");
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
            Texture2D EvilBirdRising = Raylib.LoadTexture(_path + "EvilBirdRising.png");
            Textures.Add("EvilBirdRising", EvilBirdRising);

            Texture2D EvilBirdFalling = Raylib.LoadTexture(_path + "EvilBirdFalling.png");
            Textures.Add("EvilBirdFalling", EvilBirdFalling);

            Texture2D Scarecrow = Raylib.LoadTexture(_path + "Scarecrow.png");
            Textures.Add("Scarecrow", Scarecrow);

            Texture2D WheatFarmBack = Raylib.LoadTexture(_path + "WheatFarmBack.png");
            Textures.Add("WheatFarmBack", WheatFarmBack);

            Texture2D WheatFarmMid = Raylib.LoadTexture(_path + "WheatFarmMid.png");
            Textures.Add("WheatFarmMid", WheatFarmMid);

            Texture2D WheatFarmFront = Raylib.LoadTexture(_path + "WheatFarmFront.png");
            Textures.Add("WheatFarmFront", WheatFarmFront);
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
