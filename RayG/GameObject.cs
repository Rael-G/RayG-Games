﻿using RayG.Interfaces;

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

        public void Collision()
        {
            //TO STUDY:
            //Collision Tree
            foreach (var child in Childs)
            {
                if (child is ICollisor collisorChild)
                {
                    for (int i = collisorChild.Collisor.Colliders.Count - 1; i >= 0; i--)
                    {
                        var collider = collisorChild.Collisor.Colliders[i];
                        if (!collisorChild.Collisor.IsColliding(collider))
                        {
                            collisorChild.Collisor.Colliders.RemoveAt(i);
                            collisorChild.OnCollisionExit(collider);
                        }
                    }

                    foreach (var otherChild in Childs)
                    {
                        if (otherChild is ICollisor otherCollisorChild 
                            && otherCollisorChild != collisorChild 
                            && !collisorChild.Collisor.Colliders.Contains(otherCollisorChild.Collisor))
                        {
                            if (collisorChild.Collisor.IsColliding(otherCollisorChild.Collisor))
                            {
                                collisorChild.Collisor.Colliders.Add(otherCollisorChild.Collisor);
                                collisorChild.OnCollisionEnter(otherCollisorChild.Collisor);
                            }
                        }
                    }
                }
            }
        }
    }
}