using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Game : GameObject
    {
        private Window Window { get; set; }

        public Game(List<GameObject> gameObjects, Window window)
        {
            Childs = gameObjects;
            Window = window;
        }

        public void Run()
        {
            Window.Init();

            Start();

            while (!Raylib.WindowShouldClose())
            {
                Update();

                Raylib.BeginDrawing();
                Render();
                Raylib.EndDrawing();
            }

            Window.Close();
        }
    }
}
