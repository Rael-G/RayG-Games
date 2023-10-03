﻿using EvilBird.Resources;
using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System.Numerics;

namespace EvilBird.Entities.Obstacles
{
    internal abstract class ScarecrowBase : GameObject, ICollisor
    {
        private float _initialPosition;
        private float _speed;

        public Vector2 Position;
        protected Texture2D Texture;
        protected Vector2 ResetPos;

        public Collisor Collisor { get; set; }

        public ScarecrowBase(float initialPosition, Texture2D texture)
        {
            Texture = texture;
            _initialPosition = initialPosition;
        }

        public override void Start()
        {
            _speed = 100;
            Collisor = new(Position, new Vector2(Texture.width / 2, Texture.height), "Scarecrow");
        }

        public override void Update()
        {
            Position.X += -_speed * Raylib.GetFrameTime();
            
            base.Update();
        }

        public override void Render()
        {
            //Draw Collisor
            Raylib.DrawRectangle((int)Collisor.Position.X, (int)Collisor.Position.Y,
                (int)Collisor.Area.X, (int)Collisor.Area.Y, Color.VIOLET);
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

        public void OnCollisionEnter(Collisor collisor)
        {
            
        }

        public void OnCollisionExit(Collisor collisor)
        {
           
        }
    }
}
