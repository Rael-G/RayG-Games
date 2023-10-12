using System.Numerics;

namespace RayG
{
    public class Collisor
    {
        public Vector2 Position { get; set; }
        public Vector2 Area { get; set; }
        public string Layer { get; set; }
        public List<Collisor> Colliders { get; set; }
        public bool Active { get; set; }

        public Collisor(Vector2 position, Vector2 area, string layer = "")
        {
            Position = position;
            Area = area;
            Layer = layer;
            Colliders = new List<Collisor> { };
            Active = true;
        }

        public Collisor(float positionX, float positionY, float width, float height, string layer = "")
        {
            Position = new Vector2(positionX, positionY);
            Area = new Vector2(width, height);
            Layer = layer;
            Colliders = new List<Collisor> { };
            Active = true;
        }

        public bool IsColliding(Collisor collider)
        {
            //AABB
            if (Active)
            {
               return
                   Position.X < collider.Position.X + collider.Area.X &&
                   Position.X + Area.X > collider.Position.X &&
                   Position.Y < collider.Position.Y + collider.Area.Y &&
                   Position.Y + Area.Y > collider.Position.Y;
            }

            return false;
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
