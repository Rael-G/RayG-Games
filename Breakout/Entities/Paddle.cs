using Breakout.Resources;
using RayG;
using Raylib_cs;

namespace Breakout.Entities
{
    internal class Paddle : GameObject, ICollisor
    {
        public Collisor Collisor { get; set; }

        Sprite Sprite;
        Rectangle Position;

        const float speed = 150;

        public Paddle(Sprite sprite)
        {
            Sprite = sprite;
        }

        public override void Start()
        {
            Position = new Rectangle(Window.VirtualWidth / 2 - Sprite.Width / 2, 
                Window.VirtualHeight * 0.90f, Sprite.Width, Sprite.Height);

            Collisor = new((int)Position.x, (int)Position.y, Sprite.Width, Sprite.Height, "Paddle");
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
            Collisor.Position = new(Position.x, Position.y);
            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawTexturePro(Sprite.Texture, Sprite.Source, Position, Sprite.Axis, 0, Color.WHITE);
            base.Render();
        }

        public void OnCollisionEnter(Collisor collider)
        {

        }

        public void OnCollisionExit(Collisor collider)
        {

        }
    }
}
