using EvilBird.Resources;
using RayG;

namespace EvilBird.Entities.Obstacles
{
    internal class ObstacleManager : GameObject
    {
        TextureManager _textureManager;
        public ObstacleManager(TextureManager textureManager) 
        {
            _textureManager = textureManager;
        }

        public override void Start()
        {
            var scarecrow1 = new ScarecrowControl(0, _textureManager);
            var scarecrow2 = new ScarecrowControl(Window.VirtualWidth / 2 - 16, _textureManager);
            var scarecrow3 = new ScarecrowControl(Window.VirtualWidth - 16, _textureManager);

            Childs = new() { scarecrow1, scarecrow2, scarecrow3 };

            base.Start();
        }
    }
}
