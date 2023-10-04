using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal abstract class ScarecrowBase : GameObject, ICollisor
    {
        private float _initialPosition;
        private const float _speed = 100;
        public Vector2 Position;
        protected Vector2 ResetPos;
        protected Vector2 Size;

        public Collisor Collisor { get; set; }

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
            Position.X += -_speed * Raylib.GetFrameTime();
            
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
            Position.X += _initialPosition;
            Position.Y += spawn;
        }

        public void ResetPosition(float spawn)
        {
            Position = ResetPos;
            Position.Y += spawn;
        }

        virtual public void OnCollisionEnter(Collisor collisor)
        {
            
        }

        public void OnCollisionExit(Collisor collisor)
        {
           
        }
    }
}
