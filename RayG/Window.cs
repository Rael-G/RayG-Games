using Raylib_cs;

namespace RayG
{
    public static class Window
    {
        //Default Options
        private static string _name = "Default";
        private static int _width = 800;
        private static int _height = 450;
        private static int _virtualWidth = _width;
        private static int _virtualHeight = _height;

        public static string Name { get => _name; set => _name = value; }
        public static int Width { get => Raylib.GetScreenWidth(); set => _width = value; }
        public static int Height { get => Raylib.GetScreenHeight(); set => _height = value; }
        public static int VirtualWidth { get => _virtualWidth; set => _virtualWidth = value; }
        public static int VirtualHeight { get => _virtualHeight; set => _virtualHeight = value; }
        public static int Scale 
        { 
            get 
            {
                var scale = (_height + _width) / (VirtualHeight + VirtualWidth);
                if (scale < 1)
                {
                    scale = 1;
                }
                return scale;
            } 
        }

        public static void ResizeWindow(int width, int height)
        {
            _width = width;
            _height = height;
            Raylib.SetWindowSize(width, height);
        }

        internal static void Init()
        {
            Raylib.InitWindow(_width, _height, Name);
            Raylib.SetWindowMinSize(_virtualWidth, _virtualHeight);
        }

        internal static void Close()
        {
            Raylib.CloseWindow();
        }
    }
}
