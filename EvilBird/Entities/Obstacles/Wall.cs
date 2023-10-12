using RayG;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal class Wall : GameObject, ICollisor
    {
        public Collisor Collisor { get; set ; }

        public Wall(int positionY)
        {
            Collisor = new Collisor(new Vector2(0, positionY), new Vector2(Window.VirtualWidth, 1), "Wall");
        }

        public void OnCollisionEnter(Collisor collider)
        {
        }

        public void OnCollisionExit(Collisor collisor)
        {
        }
    }
}
