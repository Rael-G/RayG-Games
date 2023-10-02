﻿using RayG;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilBird
{
    internal class TextureManager : GameObject
    {
        private static readonly string _path
           = Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Textures\");
        private Dictionary<string, Texture2D> Textures { get; }

        public TextureManager() 
        {
            Textures = new Dictionary<string, Texture2D>();
        }

        public override void Start()
        {
            Load();
            base.Start();
        }

        public override void Dispose() 
        {
            Unload();
            base.Dispose();
        }

        public Texture2D GetTexture(string name)
        {
            return Textures[name];
        }

        private void Load()
        {
            Texture2D EvilBird = Raylib.LoadTexture(_path + "EvilBird.png");
            Textures.Add("EvilBird", EvilBird);

            Texture2D Scarecrow = Raylib.LoadTexture(_path + "Scarecrow.png");
            Textures.Add("Scarecrow", Scarecrow);

            Texture2D WheatFarmBack = Raylib.LoadTexture(_path + "WheatFarmBack.png");
            Textures.Add("WheatFarmBack", WheatFarmBack);

            Texture2D WheatFarmMid = Raylib.LoadTexture(_path + "WheatFarmMid.png");
            Textures.Add("WheatFarmMid", WheatFarmMid);

            Texture2D WheatFarmFront = Raylib.LoadTexture(_path + "WheatFarmFront.png");
            Textures.Add("WheatFarmFront", WheatFarmFront);
        }

        private void Unload()
        {
            foreach (var texture in Textures)
            {
                Raylib.UnloadTexture(texture.Value);

            }
            Textures.Clear();
        }
    }
}
