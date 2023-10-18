using System.Text;
using System.Text.Json;

namespace RayG
{
    public class SaveManager<T>
    {
        /// <summary>
        /// Gets the path for the save folder.
        /// </summary>
        public string Path { get; set; }

        public SaveManager(string path) => Path = path;

        /// <summary>
        /// Saves the specified data to a file in the file system.
        /// </summary>
        /// <param name="name">The name of the file to be saved.</param>
        /// <param name="data">The data to be saved.</param>
        /// <returns>A task representing the save operation.</returns>
        /// <exception cref="IOException">Thrown if an I/O error occurs while writing to the file.</exception>
        public async Task SaveDataAsync(string name, T data)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            var fullPath = System.IO.Path.Combine(Path, name);
            var json = JsonSerializer.Serialize(data);
            var base64Data = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            await File.WriteAllTextAsync(fullPath, base64Data);
        }

        /// <summary>
        /// Loads data from a file in the file system.
        /// </summary>
        /// <param name="name">The name of the file to be loaded.</param>
        /// <returns>A task representing the load operation, with the loaded data or the default value if the file does not exist.</returns>
        /// <exception cref="IOException">Thrown if an I/O error occurs while writing to the file.</exception>
        public async Task<T?> LoadDataAsync(string name)
        {
            var fullPath = System.IO.Path.Combine(Path, name);
            var base64Data = await File.ReadAllTextAsync(fullPath);
            var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64Data));

            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
