using Breakout.GameLogic.States.Enums;
using RayG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.GameLogic.States
{
    internal abstract class StateBase : GameObject
    {
        protected GameStateRef StateRef { get; set; }

        protected StateBase(GameStateRef state)
        {
            StateRef = state;
        }
    }
}
