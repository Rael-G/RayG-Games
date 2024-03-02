namespace RayG
{
    public abstract class ResourceManager<T> : GameObject
    {
        private string _path = string.Empty;
        protected string Path 
        { 
            get => _path;
            set => _path = Directory.GetCurrentDirectory() + "\\" + value;
        }
        protected string[] Files { get; set; }
        protected Dictionary<string, T> Resources { get; }

        public ResourceManager(string path)
        {
            Resources = new Dictionary<string, T>();
            Path = path;
            Files = GetFiles();
        }

        public override void Awake()
        {
            Load();
            base.Awake();
        }

        public override void Dispose()
        {
            Unload();
            base.Dispose();
        }


        protected abstract void Load();

        protected abstract void Unload();

        private string[] GetFiles()
        {
            string[] files = Array.Empty<string>();
            if (Directory.Exists(Path))
            {
                files = Directory.GetFiles(Path);
            }

            return files;
        }
    }
}
