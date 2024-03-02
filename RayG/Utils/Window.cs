using Raylib_cs;

namespace RayG
{
    /// <summary>
    /// Provides configuration and management for the game window.
    /// </summary>
    public static class Window
    {
        //Default Options
        private static string _name = "Default";
        private static int _width = 800;
        private static int _height = 450;
        private static int _virtualWidth = _width;
        private static int _virtualHeight = _height;
        private static ConfigFlags[] _flags = Array.Empty<ConfigFlags>();
        private static bool _running = true;

        /// <summary>
        /// Gets or sets the name of the game window.
        /// </summary>
        public static string Name { get => _name; set => _name = value; }

        /// <summary>
        /// Gets or sets the actual width of the game window.
        /// </summary>
        public static int Width 
        { 
            get => Raylib.GetScreenWidth() > 0 ?
                Raylib.GetScreenWidth() : _width; 
            set => _width = value; 
        }

        /// <summary>
        /// Gets or sets the actual height of the game window.
        /// </summary>
        public static int Height 
        { 
            get => Raylib.GetScreenHeight() > 0 ?
                Raylib.GetScreenHeight() : _height;
            set => _height = value; 
        }

        /// <summary>
        /// Gets or sets the virtual width used for rendering and scaling.
        /// </summary>
        public static int VirtualWidth { get => _virtualWidth; set => _virtualWidth = value; }

        /// <summary>
        /// Gets or sets the virtual height used for rendering and scaling.
        /// </summary>
        public static int VirtualHeight { get => _virtualHeight; set => _virtualHeight = value; }

        /// <summary>
        /// Sets configuration flags for the game window.
        /// </summary>
        public static ConfigFlags[] Flags { set => _flags = value; }

        /// <summary>
        /// Gets or sets a value indicating whether the game window is currently running.
        /// </summary>
        public static bool Running { get => !Raylib.WindowShouldClose() && _running; 
            set => _running = value; }

        /// <summary>
        /// Gets the current scaling factor based on the virtual and actual sizes.
        /// </summary>
        public static float Scale 
        { 
            get 
            {
                float scale = (float)(Width + Height) / (float)(VirtualHeight + VirtualWidth);
                return scale;
            } 
        }

        /// <summary>
        /// Resizes the game window to the specified width and height.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
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
            Raylib.SetExitKey(KeyboardKey.Null);
            foreach (var flag in _flags)
            {
                Raylib.SetWindowState(flag);
            }
        }

        internal static void Close()
        {
            Raylib.CloseWindow();
        }
    }
}
