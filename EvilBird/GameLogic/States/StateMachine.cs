using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using EvilBird.Resources;
using RayG;

namespace EvilBird.GameLogic.States
{
    internal class StateMachine : GameObject
    {
        GameState GameStateActual { get; set; }
        GameStateRef GameStateRef { get; set; }
        StartState StartState { get; set; }
        CountDownState CountDownState { get; set; }
        PlayState PlayState { get; set; }
        ScoreState ScoreState { get; set; }

        TextureManager TextureManager { get; set; }

        GameObject States { get; set; }

        public StateMachine(TextureManager textureManager) 
        {
            TextureManager = textureManager;
            States = new GameObject();
            GameStateRef = new(GameState.Start);
            Childs.Add(States);
        }

        public override void Update()
        {
            if (GameStateActual != GameStateRef.State)
            {
                GameStateActual = GameStateRef.State;

                switch (GameStateActual)
                {
                    case GameState.Start:
                        StartGame();
                        break;
                    case GameState.CountDown:
                         CountDown();
                        break;
                    case GameState.Play:
                        Play();
                        break;
                    case GameState.Score:
                        Stop();
                        break;
                }
            }
            base.Update();
        }

        public void StartGame()
        {
            StartState = new(GameStateRef);
            States.Childs.Add(StartState);
            StartState.Start();
        }

        public void CountDown()
        {
            if (States.Childs.Contains(StartState))
            {
                States.Childs.Remove(StartState);
                StartState.Dispose();
            }
            else if (States.Childs.Contains(ScoreState))
            {
                States.Childs.Remove(ScoreState);
                ScoreState.Dispose();
            }

            CountDownState = new(GameStateRef);
            States.Childs.Add(CountDownState);
            CountDownState.Start();
        }

        public void Play()
        {
            if (States.Childs.Contains(CountDownState))
            {
                States.Childs.Remove(CountDownState);
                CountDownState.Dispose();
            }

            PlayState = new(GameStateRef, new Bird(TextureManager), new ObstacleManager(TextureManager));
            States.Childs.Add(PlayState);
            PlayState.Start();
        }

        public void Stop()
           {
            if (States.Childs.Contains(PlayState))
            {
                States.Childs.Remove(PlayState);
                PlayState.Dispose();
            }

            ScoreState = new ScoreState(GameStateRef);
            States.Childs.Add(ScoreState);
            ScoreState.Start();
        }
    }
}
