using RayG;
using Raylib_cs;

namespace Pong.Resources
{
    public class AudioManager : GameObject
    {
        private static readonly string audioPath =
            Path.Combine(Directory.GetCurrentDirectory() + @"\Data\Audio\Sfx\");

        private Sound pongFx;
        private Sound wallFx;
        private Sound scoreFx;

        private Dictionary<string, Sound> Sounds { get; set; }

        public AudioManager()
        {
            Sounds = new Dictionary<string, Sound>();
        }

        public override void Start()
        {
            pongFx = Raylib.LoadSound(audioPath + "Pong.wav");
            wallFx = Raylib.LoadSound(audioPath + "Wall.wav");
            scoreFx = Raylib.LoadSound(audioPath + "Score.wav");

            Sounds.Add("pong", pongFx);
            Sounds.Add("wall", wallFx);
            Sounds.Add("score", scoreFx);

            base.Start();
        }

        public override void Dispose()
        {
            Sounds.Clear();
            Raylib.UnloadSound(pongFx);
            Raylib.UnloadSound(wallFx);
            Raylib.UnloadSound(scoreFx);

            base.Dispose();
        }

        public void Play(string name)
        {
            var sound = Sounds[name];
            Raylib.PlaySound(sound);
        }
    }
}
