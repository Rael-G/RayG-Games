using RayG.Interfaces;

namespace RayG
{
    public class GameObject : IDisposable
    {
        public List<GameObject> Childs { get; set; }

        public GameObject(GameObject? parent = null)
        {
            Childs = new List<GameObject>();
        }

        public virtual void Config()
        {
            foreach (var child in Childs)
            {
                child.Config();
            }
        }

        public virtual void Start()
        {
            foreach (var child in Childs)
            {
                child.Start();
            }
        }

        public virtual void Update()
        {
            foreach (var child in Childs)
            {
                child.Update();
            }
        }

        public virtual void Render()
        {
            foreach (var child in Childs)
            {
                child.Render();
            }
        }

        public virtual void Canvas()
        {
            foreach (var child in Childs)
            {
                child.Canvas();
            }
        }

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