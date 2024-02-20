using RayG;
using Raylib_cs;

namespace Mario
{
    internal class Player : GameObject, ICollisor
    {
        public Animation Animation { get; set; }
        public Animator Animator { get; set; }
        public Rectangle Rectangle;
        public Collisor Collisor { get; set; }

        private float FallForce;
        private bool Jumping;

        private const float JUMP_FORCE = 450f;
        private const float SPEED = 100;
        private const float GRAVITY = 5;

        private bool left;

        public Player(Animator animator) 
        {
            Animator = animator;
            Animation = Animator.SetAnimation("idle");
            
            Rectangle = new(376, 267,
                Animation.Sprite[Animation.CurrentFrame].Width + 5, Animation.Sprite[Animation.CurrentFrame].Height + 5);
            Collisor = new(Rectangle);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            Animations();
            Flip();
            Move();
            base.Update();
        }

        public override void LateUpdate()
        {
            Rectangle.x = Collisor.Position.X + Animation.Sprite[Animation.CurrentFrame].Axis.X;
            Rectangle.y = Collisor.Position.Y + Animation.Sprite[Animation.CurrentFrame].Axis.Y;
            base.LateUpdate();
        }

        public override void Render()
        {
            //Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y, (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.GRAY);
            Raylib.DrawTexturePro(Animation.Sprite[Animation.CurrentFrame].Texture, Animation.Sprite[Animation.CurrentFrame].Source, Rectangle, Animation.Sprite[Animation.CurrentFrame].Axis, 0, Color.WHITE);
            base.Render();
        }

        private void Move()
        {
            var deltatime = Raylib.GetFrameTime();

            if (FallForce != 0)
                Jumping = true;
            else 
                Jumping = false;

            FallForce += GRAVITY * deltatime;
            
            var x = Collisor.Position.X;
            var y = Collisor.Position.Y;

            x += HorizontalAxis() * SPEED * deltatime;

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE) && !Jumping)
            {
                FallForce = -JUMP_FORCE * deltatime;
            }

            y += FallForce;

            Collisor.Position = new(x, y);
        }

        private void Animations()
        {
            if (Jumping)
            {
                if (FallForce < 0)
                    Animation = Animator.SetAnimation("jump");
                else
                    Animation = Animator.SetAnimation("fall");
            }
            else if (HorizontalAxis() != 0)
            {
                Animation = Animator.SetAnimation("run");
            }
            else
            {
                Animation = Animator.SetAnimation("idle");
            }
        }

        private void Flip()
        {
            if (HorizontalAxis() < 0)
            {
                if (!left)
                {
                    left = true;
                    Animator.FlipHorizontally();
                }
            }
            if (HorizontalAxis() > 0)
            {
                if (left)
                {
                    left = false;
                    Animator.FlipHorizontally();
                }
            }
        }

        //RAYG
        private float HorizontalAxis()
        {
            float axis = 0;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                axis = 0;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                axis = -1;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                axis = 1;
            }

            return axis;
        }

        public void OnCollisionEnter(Collisor collisor)
        {
            var side = Collisor.CollisionSide(collisor);
            if (side == Side.Bottom)
            {
                FallForce = 0;
            }

            Console.WriteLine(side);
        }

        public void OnCollision(Collisor collisor)
        {
            var side = Collisor.CollisionSide(collisor);

            if (side == Side.Top)
            {
                FallForce = 0;
            }
        }

        public void OnCollisionExit(Collisor collisor)
        {
        }
    }
}
