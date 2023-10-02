﻿using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird
{

    internal class Camera : GameObject
    {
        public Camera2D Camera2d;

        private Vector2 _target;
        private Vector2 _offset;

        public Camera()
        {
            Camera2d = new Camera2D();
        }

        public override void Start()
        {
            _offset = new Vector2(Window.Width / 2, Window.Height / 2);
            _target = new Vector2(Window.VirtualWidth / 2, Window.VirtualHeight / 2);
            base.Start();
        }

        public override void Update()
        {
            Camera2d.target =_target;
            Camera2d.offset = _offset;
            Camera2d.zoom = Window.Scale;
            Camera2d.rotation = 0;

            base.Update();
        }

    }
}