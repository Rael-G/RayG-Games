using RayG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayG
{
    public static class Collisions
    {
        public static void Collision(this GameObject gameObject)
        {
            var colliders = gameObject.CollisionRecursion();
            foreach (var child in gameObject.Childs)
            {
                if (child is ICollisor collisorChild)
                {
                    //If a previous colliding object is no more colliding, remove it from 
                    // its Collisor.Colliders List
                    for (int i = collisorChild.Collisor.Colliders.Count - 1; i >= 0; i--)
                    {
                        var collider = collisorChild.Collisor.Colliders[i];
                        if (!collisorChild.Collisor.IsColliding(collider))
                        {
                            collisorChild.Collisor.Colliders.RemoveAt(i);
                            collisorChild.OnCollisionExit(collider);
                        }
                    }

                    //Verify if this GameObject.Collisor is Colliding with any
                    //collider found by CollisionRecursion()
                    foreach (var collider in colliders)
                    {
                        if (collider != collisorChild.Collisor
                            && !collisorChild.Collisor.Colliders.Contains(collider))
                        {
                            if (collisorChild.Collisor.IsColliding(collider))
                            {
                                collisorChild.Collisor.Colliders.Add(collider);
                                collisorChild.OnCollisionEnter(collider);
                            }
                        }
                    }
                }
            }
        }

        //Finds all collisors recursively
        private static List<Collisor> CollisionRecursion(this GameObject gameObject)
        {
            List<Collisor> colliders = new();
            foreach (var child in gameObject.Childs)
            {
                colliders.AddRange(child.CollisionRecursion());

                if (child is ICollisor colChild)
                {
                    colliders.Add(colChild.Collisor);
                }
            }
            return colliders;
        }
    }
}
