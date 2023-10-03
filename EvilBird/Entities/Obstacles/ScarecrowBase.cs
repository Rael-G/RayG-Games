using EvilBird.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal abstract class ScarecrowBase : GameObject
    {
        private float _initialPosition;
        private float _speed;

        public Vector2 Position;
        protected Texture2D Texture;
        protected Vector2 ResetPos;

        public ScarecrowBase(float initialPosition, Texture2D texture)
        {
            Texture = texture;
            _initialPosition = initialPosition;
        }

        public override void Start()
        {
            _speed = 100;
        }

        public override void Update()
        {
            Position.X += -_speed * Raylib.GetFrameTime();
            base.Update();
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
    }
}
