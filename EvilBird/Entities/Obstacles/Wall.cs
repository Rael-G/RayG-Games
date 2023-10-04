using RayG;
using RayG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird.Entities.Obstacles
{
    internal class Wall : GameObject, ICollisor
    {
        public Collisor Collisor { get; set ; }

        public Wall(int positionY)
        {
            Collisor = new Collisor(new Vector2(0, positionY), new Vector2(Window.VirtualWidth, 1), "Wall");
        }

        public void OnCollisionEnter(Collisor collisor)
        {
        }

        public void OnCollisionExit(Collisor collisor)
        {
        }
    }
}
