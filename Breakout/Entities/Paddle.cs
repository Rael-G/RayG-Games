using Breakout.Resources;
using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Entities
{
    internal class Paddle : GameObject
    {
        Sprite Sprite;
        Rectangle Position;

        const float speed = 100;

        public Paddle(Sprite sprite)
        {
            Sprite = sprite;
        }

        public override void Start()
        {
            Position = new Rectangle(Window.VirtualWidth / 2 - Sprite.Width / 2, 
                Window.VirtualHeight * 0.90f, Sprite.Width, Sprite.Height); 
            base.Start();
        }

        public override void Update()
        {
            var deltatime = Raylib.GetFrameTime();
            if(Position.x > 0 && Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                Position.x += -speed * deltatime;
            }
            else if (Position.x < Window.VirtualWidth - Sprite.Width && Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) 
            {
                Position.x += speed * deltatime;
            }
            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Color.WHITE);
            base.Render();
        }
    }
}
