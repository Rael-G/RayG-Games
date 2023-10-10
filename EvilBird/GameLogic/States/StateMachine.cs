using EvilBird.Entities;
using EvilBird.Entities.Obstacles;
using EvilBird.Enums;
using RayG;

namespace EvilBird.GameLogic.States
{
    internal class StateMachine : GameObject
    {
        GameState GameStateActual;
        GameStateRef GameStateRef;
        StartState StartState;
        CountDownState CountDownState;
        PlayState PlayState;
        ScoreState ScoreState;

        TextureManager _textureManager;
        SoundManager _audioManager;

        GameObject States { get; set; }

        public StateMachine(TextureManager textureManager, SoundManager audioManager) 
        {
            _textureManager = textureManager;
            _audioManager = audioManager;
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

            CountDownState = new(GameStateRef, _audioManager);
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

            PlayState = new(GameStateRef, new Bird(_textureManager, _audioManager), new ObstacleManager(_textureManager));
            States.Childs.Add(PlayState);
            PlayState.Start();
        }

        public void Stop()
        {
            var corns = PlayState.Corns;

            if (States.Childs.Contains(PlayState))
            {
                States.Childs.Remove(PlayState);
                PlayState.Dispose();
            }

            ScoreState = new ScoreState(GameStateRef, corns.ToString());
            States.Childs.Add(ScoreState);
            ScoreState.Start();
        }
    }
}