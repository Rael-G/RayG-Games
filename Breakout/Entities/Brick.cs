using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Brick : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }

        Sprite Sprite;
        Rectangle Position;
        public int Life;
        int Tier;

        SoundManager _soundManager;

        public Brick(SoundManager soundManager, Sprite sprite, int tier, Vector2 position)
        { 
            _soundManager = soundManager;
            Sprite = sprite;
            Tier = tier;
            Position = new Rectangle(position.X, position.Y, Sprite.Width, Sprite.Height);
            Life = Tier + 1;
            Collisor = new Collisor(Position.x, Position.y, Position.width, Position.height, "Brick");
        }

        public override void Update()
        {
            Collisor.Position = new Vector2(Position.x, Position.y);

            if (Life <= 0) 
            {
                Collisor.Active = false;
            }
            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawRectangleV(Collisor.Position, Collisor.Area, Raylib_cs.Color.VIOLET);
            if (Life > 0)
            {
                Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Raylib_cs.Color.WHITE);
            }
            base.Render();
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.Collisor.Layer == "Ball")
            {
                _soundManager.PlaySound("Brick");
                Life--;
            }
        }

        public void OnCollisionExit(Collisor collider)
        {

        }
    }
}
