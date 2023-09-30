using Raylib_cs;

namespace RayG
{
    public class Game
    {
        GameObject GameObject { get; set; }

        public Game(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public void Run()
        {
            GameObject.Config();

            Window.Init();

            GameObject.Start();

            while (!Raylib.WindowShouldClose())
            {
                GameObject.Update();

                Raylib.BeginDrawing();

                GameObject.Render();
                GameObject.Canvas();

                Raylib.EndDrawing();
            }

            GameObject.Dispose();

            Window.Close();
        }   
    }
}
