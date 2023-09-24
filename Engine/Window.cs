using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Window
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private static Window? _instance;

        private Window(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        public static Window GetInstance(string name = "Default", int width = 1280, int height = 720)
        {
            if (_instance == null)
            {
                _instance = new Window(name, width, height);
                return _instance;
            }

            return _instance;
        }

        public void Init()
        {
            Raylib.InitWindow(Width, Height, Name);
        }

        public void Close()
        {
            Raylib.CloseWindow();
        }
    }
}
