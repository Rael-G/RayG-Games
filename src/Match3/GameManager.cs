﻿using Match3.Entities;
using Match3.GameLogic;
using RayG;
using Raylib_cs;

namespace Match3
{
    internal class GameManager : GameObject
    {
        Camera _camera;
        TextureManager _textureManager;
        SpriteSheet _spriteSheet;
        Board _board;
        GameController _controller;

        public override void Config()
        {
            Window.Name = "Match3";
            Window.Width = 1920;
            Window.Height = 1080;
            Window.VirtualWidth = 320;
            Window.VirtualHeight = 180;
            Raylib.SetTargetFPS(144);
            base.Config();
        }

        public override void Awake()
        {
            _textureManager = new TextureManager(@"Data\Match3\Textures\");
            
            _camera = new();

            Children.Add( _textureManager );
            Children.Add(_camera);
            base.Awake();
        }

        public override void Start()
        {
            var texture = _textureManager.GetTexture("Blocks");
            _spriteSheet = new SpriteSheet(texture);
            _board = new Board(_spriteSheet);
            _controller = new(_board);

            Children.Add(_spriteSheet);
            Children.Add( _board );
            Children.Add(_controller);
            base.Start();
        }

        public override void Render()
        {
            Raylib.ClearBackground(Raylib.GetColor(0x111111FF));
            Raylib.BeginMode2D(_camera.Camera2d);
            base.Render();
            Raylib.EndMode2D();
        }
    }
}
