using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine._Builder
{
    public class WindowBuilder
    {
        private string _name = "Default";
        private int _width = 1280;
        private int _height = 720;
        private bool _fullscreen = false;

        public WindowBuilder() { }

        public WindowBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public WindowBuilder SetWidth(int width)
        {
            _width = width;
            return this;
        }

        public WindowBuilder SetHeight(int height)
        {
            _height = height;
            return this;
        }

        public WindowBuilder SetFullscreen(bool fullscreen)
        {
            _fullscreen = fullscreen;
            return this;
        }

        //  NOTE
        //  If there is an existing instance, all its properties will be replaced.
        //  This should be used only to create new window, otherwise,
        //  use Window.GetInstance() and its Set Methods.
        public Window Build()
        {
            return Window.GetInstance(_name, _width, _height, _fullscreen);
        }
    }
}
