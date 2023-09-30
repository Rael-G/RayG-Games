using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface ICollisor
    {
        Collisor Collisor { get; set; }

        void OnCollisionEnter(Collisor collisor);
        void OnCollisionExit(Collisor collisor);
    }

    public class Collisor
    {
        public Vector2 Position { get; set; }
        public Vector2 Area { get; set; }
        public string Layer { get; set; }
        public List<Collisor> Colliders { get; set; }

        public Collisor(Vector2 position, Vector2 area, string layer = "")
        {
            Position = position;
            Area = area;
            Layer = layer;
            Colliders = new List<Collisor> { };
        }

        public bool IsColliding(Collisor collisor)
        {
            return
               Position.X < collisor.Position.X + collisor.Area.X &&
               Position.X + Area.X > collisor.Position.X &&
               Position.Y <  collisor.Position.Y + collisor.Area.Y &&
               Position.Y + Area.Y > collisor.Position.Y;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Collisor other = (Collisor)obj;
            return Position.Equals(other.Position) && Area.Equals(other.Area);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position, Area);
        }
    }
}
