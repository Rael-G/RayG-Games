using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal abstract class ScarecrowBase : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }
        public Vector2 Position { get; set; }
        protected Vector2 ResetPos { get; set; }
        protected Vector2 Size { get; set; }

        const float _speed = 100;
        readonly float _initialPosition;

        public ScarecrowBase(float initialPosition)
        {
            _initialPosition = initialPosition;
        }

        public override void Start()
        {
            Size = new Vector2(64, 128);
            Collisor = new(Position, new Vector2(Size.X / 2, Size.Y), "Scarecrow");
        }

        public override void Update()
        {
            Position = new(Position.X - _speed * Raylib.GetFrameTime(), Position.Y);
            
            base.Update();
        }

        public override void Render()
        {
            //Draw Collisor
            //Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y,
            //    (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.VIOLET);
        }

        public void BeginPosition(float spawn)
        {
            Position = ResetPos;
            Position = new(Position.X + _initialPosition, Position.Y + spawn);
        }

        public void ResetPosition(float spawn)
        {
            Position = new(ResetPos.X, ResetPos.Y + spawn);
        }

        virtual public void OnCollisionEnter(Collision collision)
        {
            
        }

        public void OnCollisionExit(Collisor collisor)
        {
           
        }
    }
}
