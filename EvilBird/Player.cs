using RayG;
using RayG.Interfaces;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird
{
    internal class Player : GameObject, ICollisor

        { 
        private Vector2 _size;
        public Vector2 _position;

        private TextureManager _textureManager;
        private Texture2D Texture;
        public Collisor Collisor { get; set; }

        public Player(TextureManager textureManager) 
        {
            _textureManager = textureManager;
            Collisor = new(_position, _size, "Player");
        }

        public override void Start()
        {
            Texture = _textureManager.GetTexture("EvilBird");

            _size = new Vector2(Texture.width, Texture.height);
            _position = new Vector2(-_size.X / 2, -_size.Y / 2);
            base.Start();
        }

        public override void Update()
        {

            base.Update();
        }

        public override void Render()
        {
            Raylib.DrawTexture(Texture, (int)_position.X, (int)_position.Y, Color.WHITE);
            base.Render();
        }

        public void OnCollisionEnter(Collisor collisor)
        {

        }

        public void OnCollisionExit(Collisor collisor)
        {

        }
    }
}
