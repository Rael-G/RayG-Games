namespace RayG
{
    public class GameObject : IDisposable
    {
        public List<GameObject> Childs { get; set; }

        public GameObject()
        {
            Childs = new List<GameObject>();
        }

        /// <summary>
        ///  Configures this GameObject only before window initialization.
        /// </summary>
        public virtual void Config()
        {
            foreach (var child in Childs)
            {
                child.Config();
            }
        }

        /// <summary>
        /// Performs initialization operations before the Start method.
        /// </summary>
        public virtual void Awake()
        {
            foreach (var child in Childs)
            {
                child.Awake();
            }
        }

        /// <summary>
        /// Initializes this GameObject.
        /// </summary>
        public virtual void Start()
        {
            foreach (var child in Childs)
            {
                child.Start();
            }
        }

        /// <summary>
        /// Updates this GameObject once per frame.
        /// </summary>
        public virtual void Update()
        {
            foreach (var child in Childs)
            {
                child.Update();
            }
        }

        /// <summary>
        ///  Performs drawing operations.
        /// </summary>
        public virtual void Render()
        {
            foreach (var child in Childs)
            {
                child.Render();
            }
        }

        /// <summary>
        ///  Performs drawing operations after the Render method.
        /// </summary>
        public virtual void Canvas()
        {
            foreach (var child in Childs)
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
            foreach (var child in Childs)
            {
                child.Dispose();
            }

            Childs.Clear();
        } 
    }
}