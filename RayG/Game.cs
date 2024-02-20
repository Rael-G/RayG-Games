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

        /// <summary>
        /// Initiates and runs the game loop, handling game initialization, 
        /// updates, rendering, and disposal.
        /// </summary>
        public void Run()
        {
            GameObject.Config();

            Window.Init();
            Raylib.InitAudioDevice();

            GameObject.Awake();
            GameObject.Start();

            while (Window.Running)
            {
                GameObject.EarlyUpdate();
                GameObject.Update();
                GameObject.LateUpdate();

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
