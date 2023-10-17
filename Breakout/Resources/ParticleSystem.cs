using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Resources
{
    public class ParticleSystem : GameObject
    {
        public static Color[] Colors =
        {
            Color.BLUE, Color.DARKGREEN, Color.RED, Color.VIOLET, Color.YELLOW, Color.BLACK, Color.ORANGE
        };

        const int Max = 15;
        const float gravity = -15;
        const float spread = 0.15f;

        Particle[] Particles = new Particle[Max];

        public override void Update()
        {
            var deltatime = Raylib.GetFrameTime();
            for (int i = 0; i < Max; i++)
            {
                if (Particles[i].Active)
                {
                    Particles[i].Position.Y -= deltatime * gravity;
                    Particles[i].Alpha = Particles[i].Alpha - 0.005f;
                    if (Particles[i].Alpha < 0)
                    {
                        Particles[i].Active = false;
                    }
                }
            }
            base.Update();
        }

        public override void Render()
        {
            Raylib.BeginBlendMode(BlendMode.BLEND_ALPHA);

            for (int i = 0; i < Max; i++)
            {
                if (Particles[i].Active)
                {
                    Raylib.DrawRectangleV(Particles[i].Position, Particles[i].Size,
                        Raylib.Fade(Particles[i].Color, Particles[i].Alpha));

                }
            }

            base.Render();
            Raylib.EndBlendMode();
        }

        public void SetParticles(Vector2 position, Vector2 size, Color color, float alpha)
        {
            for (int i = 0; i < Max; i++)
            {
                Particles[i] = new Particle(position, size, color, alpha);
                Spread(ref Particles[i].Position, spread);
            }
        }

        public void SetParticles(float posX, float posY, float width, float heigth, Color color, float alpha)
        {
            Vector2 position = new Vector2(posX, posY);
            Vector2 size = new Vector2(width, heigth);
            SetParticles(position, size, color, alpha);
        }

        void Spread(ref Vector2 position, float area)
        {
            position.X = Raylib.GetRandomValue((int)(position.X - (position.X * area / 2)), (int)(position.X + (position.Y * area / 2)));
            position.Y = Raylib.GetRandomValue((int)(position.Y - (position.Y * area)), (int)(position.Y + (position.Y * area)));
        }
    }
}
