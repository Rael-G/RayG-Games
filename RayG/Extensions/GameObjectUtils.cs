using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayG
{
    public static class GameObjectUtils
    {
        /// <summary>
        /// Adds GameObjects to the list and initializes them by calling their Awake and Start methods.
        /// </summary>
        /// <param name="gameObjects">The list of GameObjects to add to.</param>
        /// <param name="items">The GameObjects to add and initialize.</param>
        public static void AddStart(this List<GameObject> gameObjects, params GameObject[] items)
        {
            foreach (var item in items)
            {
                gameObjects.Add(item);
                item.Awake();
                item.Start();
            }
        }

        /// <summary>
        /// Adds a collection of GameObjects to the list and initiates Awake and Start methods for each.
        /// </summary>
        /// <param name="gameObjects">The list of GameObjects to add to.</param>
        /// <param name="items">The collection of GameObjects to add and initialize.</param>
        public static void AddRangeStart(this List<GameObject> gameObjects, IEnumerable<GameObject> items)
        {
            gameObjects.AddRange(items);
            foreach (var item in items)
            {
                item.Awake();
                item.Start();
            }
        }
    }
}
