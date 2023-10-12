using System.Numerics;

namespace RayG
{
    public class Collisor
    {
        /// <summary>
        /// Position of the collisor in 2D space.
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Area (dimensions) of the collisor in 2D space.
        /// </summary>
        public Vector2 Area { get; set; }

        /// <summary>
        /// Layer to which the collisor belongs.
        /// </summary>
        public string Layer { get; set; }

        /// <summary>
        /// List of collisors that the current collisor is in contact with.
        /// </summary>
        public List<Collisor> Colliders { get; set; }

        /// <summary>
        /// Value indicating whether the collisor is active and participating in collisions.
        /// </summary>
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

        /// <summary>
        /// Checks if this collisor is colliding with another collisor using AABB collision detection.
        /// </summary>
        /// <param name="collider">The collisor to check for collision.</param>
        /// <returns>True if a collision is detected; otherwise, false.</returns>
        internal bool IsColliding(Collisor collider)
        {
            if (Active && collider.Active)
            {
                return
                    Position.X < collider.Position.X + collider.Area.X &&
                    Position.X + Area.X > collider.Position.X &&
                    Position.Y < collider.Position.Y + collider.Area.Y &&
                    Position.Y + Area.Y > collider.Position.Y;
            }

            return false;
        }


        /// <summary>
        /// Determines the side of collision with another collisor.
        /// </summary>
        /// <param name="collider">The collisor to check for collision.</param>
        /// <returns>The side of collision (e.g., Top, Bottom, Left, Right).</returns>
        public Side CollisionSide(Collisor collider)
        {
            var topCollision = Position.Y + Area.Y - collider.Position.Y;
            var bottomCollision = collider.Position.Y + collider.Area.Y - Position.Y;
            var leftCollision = Position.X + Area.X - collider.Position.X;
            var rightCollision = collider.Position.X + collider.Area.X - Position.X;

            if (topCollision < bottomCollision && topCollision < leftCollision && topCollision < rightCollision)
            {
                return Side.Top;
            }
            if (bottomCollision < topCollision && bottomCollision < leftCollision && bottomCollision < rightCollision)
            {
                return Side.Bottom;
            }
            if (leftCollision < bottomCollision && leftCollision < topCollision && leftCollision < rightCollision)
            {
                return Side.Left;
            }
            else
            {
                return Side.Right;
            }
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
