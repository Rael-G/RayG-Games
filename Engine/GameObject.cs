namespace Engine
{
    public class GameObject : IDisposable
    {
        public List<GameObject> Childs { get; set; }
        public GameObject? Parent { get; set; }

        public GameObject(GameObject? parent = null)
        {
            Childs = new List<GameObject>();
            Parent = parent;
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

        public void Collision()
        {
            //TO STUDY:
            //Collision Tree
            foreach (var child in Childs)
            {
                if (child is ICollisor collisionChild)
                {
                    for (int i = collisionChild.Collisor.Colliders.Count - 1; i >= 0; i--)
                    {
                        var c = collisionChild.Collisor.Colliders[i];
                        if (!collisionChild.Collisor.IsColliding(c))
                        {
                            collisionChild.Collisor.Colliders.RemoveAt(i);
                            collisionChild.OnCollisionExit(c);
                        }
                    }

                    foreach (var otherChild in Childs)
                    {
                        if (otherChild is ICollisor otherCollisionChild 
                            && otherCollisionChild != collisionChild 
                            && !collisionChild.Collisor.Colliders.Contains(otherCollisionChild.Collisor))
                        {
                            if (collisionChild.Collisor.IsColliding(otherCollisionChild.Collisor))
                            {
                                collisionChild.Collisor.Colliders.Add(otherCollisionChild.Collisor);
                                collisionChild.OnCollisionEnter(otherCollisionChild.Collisor);
                            }
                        }
                    }
                }
            }
        }
    }
}