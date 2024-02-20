using Breakout.Resources;
using RayG;
using Raylib_cs;
using System.Numerics;

namespace Breakout.Entities
{
    internal class Brick : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }

        public int Color { get; private set; }
        public int Tier { get; private set; }
        public bool Dead { get; private set; }
        public int Score { get; set; }

        Sprite Sprite;
        Rectangle Position;
        

        readonly SoundManager _soundManager;
        readonly SpriteSheetCustom _spriteSheet;
        readonly ParticleSystem _particle;

        public Brick(SoundManager soundManager, SpriteSheetCustom spriteSheet, ParticleSystem particle, int color, int tier, Vector2 position)
        {
            _particle = particle;
            _soundManager = soundManager;
            _spriteSheet = spriteSheet;
            Color = color;
            Tier = tier;

            Position = new Rectangle(position.X, position.Y, SpriteSheetCustom.Width, SpriteSheetCustom.Height);
            Collisor = new Collisor(Position.x, Position.y, Position.width, Position.height, "Brick");
        }

        public override void Update()
        {
            Collisor.Position = new Vector2(Position.x, Position.y);
            Sprite = _spriteSheet.Bricks[Color, Tier];

            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Raylib_cs.Color.WHITE);

            base.Render();
        }

        public void OnCollisionEnter(Collisor collider)
        {
            if (collider.Layer == "Ball")
            {
                _particle.SetParticles(collider.Position.X, collider.Position.Y, 1, 1, ParticleSystem.Colors[Color], 0.5f);

                if (Color == 0 && Tier > 0)
                {
                    Score = Tier * 200 + 20;
                    Tier--;
                    Color = SpriteSheetCustom.Yellow;
                    _soundManager.PlaySound("Brick");
                }
                else if(Color > 0)
                {
                    Score = Tier * 200 + 20;
                    Color--;
                    _soundManager.PlaySound("Brick");
                }
                else
                {
                    _soundManager.PlaySound("Explosion", 0.10f);
                    Score = Tier * 200 + 20;
                    Dead = true;
                    Collisor.Active = false;
                }
            }
        }

        public void OnCollisionExit(Collisor collider)
        {

        }

        public void OnCollision(Collisor collisor)
        {

        }
    }
}
