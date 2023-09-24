namespace Engine
{
    public class GameObject
    {
        public List<GameObject> Childs { get; set; }

        public GameObject()
        {
            Childs = new List<GameObject>();
        }

        virtual public void Start()
        {
            foreach (var child in Childs)
            {
                child.Start();
            }
        }

        virtual public void Update()
        {
            foreach (var child in Childs)
            {
                child.Update();
            }
        }

        virtual public void Render()
        {
            foreach (var child in Childs)
            {
                child.Render();
            }
        }
    }
}