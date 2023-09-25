using Engine._Builder;
using Raylib_cs;

namespace Engine
{
    public class Window
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fullscreen { get; set; }

        private static Window? _instance;

        private Window(string name, int width, int height, bool fullscreen)
        {
            Name = name;
            Width = width;
            Height = height;
            Fullscreen = fullscreen;
        }

        public static Window GetInstance()
        {
            _instance ??= new WindowBuilder().Build();
            return _instance;
        }

        public static Window GetInstance(string name, int width,
            int height, bool fullscreen)
        {
            _instance ??= new Window(name, width, height, fullscreen);

            return _instance;
        }

        public void Init()
        {
            Raylib.InitWindow(Width, Height, Name);

            if (Raylib.IsWindowFullscreen() != Fullscreen)
            {
                Raylib.ToggleFullscreen();
            }
        }

        public void Close()
        {
            Raylib.CloseWindow();
        }
    }
}
