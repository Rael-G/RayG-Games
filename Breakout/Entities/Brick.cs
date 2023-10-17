using Breakout.GameLogic;
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
        public int Color;
        public int Tier;
        public bool Dead;
        public int Score;

        SoundManager _soundManager;
        SpriteSheet _spriteSheet;
        ParticleSystem _particle;

        public Brick(SoundManager soundManager, SpriteSheet spriteSheet, ParticleSystem particle, int color, int tier, Vector2 position)
        {
            _particle = particle;
            _soundManager = soundManager;
            _spriteSheet = spriteSheet;
            Color = color;
            Tier = tier;
            Dead = false;
            Position = new Rectangle(position.X, position.Y, SpriteSheet.Width, SpriteSheet.Height);
            Collisor = new Collisor(Position.x, Position.y, Position.width, Position.height, "Brick");
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            Collisor.Position = new Vector2(Position.x, Position.y);
            Sprite = _spriteSheet.Bricks[Color, Tier];

            base.Update();
        }

        public override void Render()
        {
            //Draw Collisor
            //Raylib.DrawRectangleV(Collisor.Position, Collisor.Area, Raylib_cs.Color.VIOLET);

            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Raylib_cs.Color.WHITE);

            if (!Dead)
            {
                Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Raylib_cs.Color.WHITE);
            }
            base.Render();
        }

        public void OnCollisionEnter(Collisor collider)
        {
            if (collider.Layer == "Ball")
            {
                _particle.SetParticles(collider.Position.X, collider.Position.Y, 1, 1, ParticleSystem.Colors[Color], 0.5f);

                if (Color == 0 && Tier > 0)
                {
                    Score = Tier * 200;
                    Tier--;
                    Color = SpriteSheet.Yellow;
                    _soundManager.PlaySound("Brick");


                }
                else if(Color > 0)
                {
                    Score = 25;
                    Color--;
                    _soundManager.PlaySound("Brick");

                }
                else
                {
                    _soundManager.PlaySound("Explosion", 0.10f);
                    Score = 25;
                    Dead = true;
                    Collisor.Active = false;
                }
            }
        }

        public void OnCollisionExit(Collisor collider)
        {

        }
    }
}
