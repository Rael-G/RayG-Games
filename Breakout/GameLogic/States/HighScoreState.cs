using RayG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameLogic.States
{
    internal class HighScoreState : GameObject
    {
        GameStateRef State { get; set; }

        public HighScoreState(GameStateRef state)
        {
            State = state;
        }
    }
}
