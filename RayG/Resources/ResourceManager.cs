using System.IO;

namespace RayG
{
    public abstract class ResourceManager<T> : GameObject
    {
        private string _path;
        //Relative to executable
        protected string Path 
        { 
            get => _path;
            set => _path = Directory.GetCurrentDirectory() + "\\" + value;
        }
        protected string[] Names { get; set; }
        protected Dictionary<string, T> Resources { get; }

        public ResourceManager(string path, string[] names)
        {
            Resources = new Dictionary<string, T>();
            Path = path;
            Names = names;
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

        protected abstract void Load();

        protected abstract void Unload();
    }
}
