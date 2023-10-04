using EvilBird.Enums;
using RayG;
using Raylib_cs;

namespace EvilBird.GameLogic.States
{
    internal class CountDownState : GameObject
    {
        GameStateRef GameStateRef { get; set; }
        int Count { get; set; }

        public CountDownState(GameStateRef gameState) 
        {
            GameStateRef = gameState;
        }

        public override void Start()
        {
            Count = 3;
        }

        public override void Update()
        {
            //Every 1s Count--
            //if (Count == -1)
            GameStateRef.State = GameState.Play;
        }

        public override void Canvas()
        {
            Raylib.DrawText(Count.ToString(), Window.VirtualWidth / 2,
                Window.VirtualHeight / 2, 50, Color.WHITE);
        }
    }
}
