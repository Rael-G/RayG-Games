using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using RayG;

namespace EvilBird.GameLogic.States
{
    internal class PlayState : GameObject
    {
        GameStateRef GameStateRef { get; set; }
        Bird Bird { get; set; }
        ObstacleManager ObstacleManager { get; set; }

        public PlayState(GameStateRef gameState, Bird bird, ObstacleManager obstacleManager)
        {
            GameStateRef = gameState;
            Bird = bird;
            ObstacleManager = obstacleManager;
        }

        public override void Start()
        {
            Childs = new() { Bird,  ObstacleManager };
            Bird._dead = false;
            base.Start();
        }

        public override void Update()
        {
            if (Bird._dead == true)
            {
                GameStateRef.State = GameState.Score;
            }
            this.Collision();
            base.Update();
        }
    }
}
