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
            var colliders = gameObject.ColliderDetecter();

            gameObject.CollisionCleaner();
            gameObject.CollisionChecker(colliders);
        }

        //Finds all collisors within this GameObject.Childs recursively
        private static List<Collisor> ColliderDetecter(this GameObject gameObject)
        {
            List<Collisor> colliders = new();
            foreach (var child in gameObject.Childs)
            {
                colliders.AddRange(child.ColliderDetecter());

                if (child is ICollisor colChild)
                {
                    colliders.Add(colChild.Collisor);
                }
            }
            return colliders;
        }

        //If a previous colliding object is no more colliding, remove it from 
        //   Collisor.Colliders and calls OnCollisionExit, ecursively on all Childs
        private static void CollisionCleaner(this GameObject gameObject )
        {
            foreach (var child in gameObject.Childs)
            {
                child.CollisionCleaner(); 
            }

            if (gameObject is ICollisor colObject)

            for (int i = colObject.Collisor.Colliders.Count - 1; i >= 0; i--)
            {
                var collider = colObject.Collisor.Colliders[i];
                if (!colObject.Collisor.IsColliding(collider))
                {
                     colObject.Collisor.Colliders.RemoveAt(i);
                     colObject.OnCollisionExit(collider);
                }
            }
        }

        //Verify if this GameObject.Collisor is Colliding with any
        //collider found in received Colliders List, recursively on all Childs
        private static void CollisionChecker(this GameObject gameObject, List<Collisor> colliders )
        {
            foreach (var collider in colliders)
            {
                foreach (var child in gameObject.Childs)
                {
                    child.CollisionChecker(colliders); 
                }

                if (gameObject is ICollisor colObject)

                if (collider != colObject.Collisor
                    && !colObject.Collisor.Colliders.Contains(collider))
                {
                    if (colObject.Collisor.IsColliding(collider))
                    {
                        colObject.Collisor.Colliders.Add(collider);
                        colObject.OnCollisionEnter(collider);
                    }
                }
            }
        }
    }
}
