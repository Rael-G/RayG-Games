namespace RayG
{
    public class GameObject : IDisposable
    {
        public List<GameObject> Children { get; set; }

        public GameObject()
        {
            Children = new List<GameObject>();
        }

        /// <summary>
        ///  Configures this GameObject only before window initialization.
        /// </summary>
        public virtual void Config()
        {
            foreach (var child in Children)
            {
                child.Config();
            }
        }

        /// <summary>
        /// Performs initialization operations before the Start method.
        /// </summary>
        public virtual void Awake()
        {
            foreach (var child in Children)
            {
                child.Awake();
            }
        }

        /// <summary>
        /// Initializes this GameObject.
        /// </summary>
        public virtual void Start()
        {
            foreach (var child in Children)
            {
                child.Start();
            }
        }

        /// <summary>
        /// Updates this GameObject once per frame.
        /// </summary>
        public virtual void EarlyUpdate()
        {
            foreach (var child in Children)
            {
                child.EarlyUpdate();
            }
        }

        /// <summary>
        /// Updates this GameObject once per frame.
        /// </summary>
        public virtual void Update()
        {
            foreach (var child in Children)
            {
                child.Update();
            }
        }

        /// <summary>
        /// Updates this GameObject once per frame.
        /// </summary>
        public virtual void LateUpdate()
        {
            foreach (var child in Children)
            {
                child.LateUpdate();
            }
        }

        /// <summary>
        ///  Performs drawing operations.
        /// </summary>
        public virtual void Render()
        {
            foreach (var child in Children)
            {
                child.Render();
            }
        }

        /// <summary>
        ///  Performs drawing operations after the Render method.
        /// </summary>
        public virtual void Canvas()
        {
            foreach (var child in Children)
            {
                child.Canvas();
            }
        }

        /// <summary>
        /// Releases resources of this GameObject and its descendants.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
            foreach (var child in Children)
            {
                child.Dispose();
            }

            Children.Clear();
        }

        /// <summary>
        /// Disposes of the specified child GameObject, removing it from the collection.
        /// </summary>
        /// <param name="child">The child GameObject to dispose of.</param>
        public void Dispose(GameObject child)
        {
            if (Children.Contains(child))
            {
                child.Dispose();
                Children.Remove(child);
            }
        }
    }
}