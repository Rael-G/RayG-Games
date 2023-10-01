using RayG;
using Raylib_cs;

namespace Pong.Resources
{
    public class FontManager : GameObject
    {
        private static readonly string fontPath = Path.Combine(Directory.GetCurrentDirectory() +
            @"\Data\Fonts\");

        private Font fontMecha;

        private Dictionary<string, Font> Fonts { get; set; }

        public FontManager()
        {
            Fonts = new Dictionary<string, Font>();
        }

        public override void Start()
        {
            fontMecha = Raylib.LoadFont(fontPath + "mecha.png");
            Fonts.Add("mecha", fontMecha);

            base.Start();
        }

        public override void Dispose()
        {
            Fonts.Clear();
            Raylib.UnloadFont(fontMecha);

            base.Dispose();
        }

        public Font GetFont(string name)
        {
            return Fonts.Where(f => f.Key == name).FirstOrDefault().Value;
        }
    }
}
