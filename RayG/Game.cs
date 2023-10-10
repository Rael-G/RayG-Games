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
            Raylib.InitAudioDevice();

            GameObject.Start();

            while (Window.Running)
            {
                GameObject.Update();

                Raylib.BeginDrawing();

                GameObject.Render();
                GameObject.Canvas();

                Raylib.EndDrawing();
            }

            GameObject.Dispose();

            Raylib.CloseAudioDevice();
            Window.Close();
        }   
    }
}
