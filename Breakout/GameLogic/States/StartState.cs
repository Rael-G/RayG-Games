using RayG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameLogic.States
{
    internal class StartState : GameObject
    {
        GameStateRef State { get; set; }

        public StartState(GameStateRef state) 
        {
            State = state;
        }
    }
}
