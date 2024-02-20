using System.Text.Json;

namespace RayG
{
    public class MapManager : ResourceManager<Map>
    {
        public MapManager(string path) : base(path) { }

        /// <summary>
        /// Gets the map with the specified name.
        /// </summary>
        /// <param name="name">The name of the map.</param>
        /// <returns>The map associated with the given name.</returns>
        public Map GetMap(string name)
        {
            return Resources[name];
        }

        protected override void Load()
        {
            foreach (var file in Files)
            {
                var map = LoadMap(file);

                var name = System.IO.Path.GetFileNameWithoutExtension(file);
                Resources.Add(name, map);
            }
        }

        protected override void Unload()
        {
            // Not currently needed for map unloading.
            Resources.Clear();
        }

        private Map LoadMap(string name)
        {
            var fullPath = System.IO.Path.Combine(Path, name);
            var json = File.ReadAllText(fullPath);

            return JsonSerializer.Deserialize<Map>(json);
        }
    }
}
