using Raylib_cs;

namespace RayG
{
    public static class Window
    {
        //Default Options
        private static string _name = "Default";
        private static int _width = 1280;
        private static int _height = 720;
        private static int _virtualWidth = _width;
        private static int _virtualHeight = _height;
        private static bool _fullscreen = false;

        public static string Name { get { return _name; } set { _name = value; } }
        public static int Width { get { return _width; } set { _width = value; } }
        public static int VirtualWidth { get { return _virtualWidth; } set { _virtualWidth = value; } }
        public static int VirtualHeight { get { return _virtualHeight; } set { _virtualHeight = value; } }
        public static int Height { get { return _height; } set { _height = value; } }
        public static bool Fullscreen { get { return _fullscreen; } set { _fullscreen = value; } }

        internal static void Init()
        {
            Raylib.InitWindow(Width, Height, Name);

            if (Raylib.IsWindowFullscreen() != Fullscreen)
            {
                Raylib.ToggleFullscreen();
            }
        }

        internal static void Close()
        {
            Raylib.CloseWindow();
        }
    }
}
