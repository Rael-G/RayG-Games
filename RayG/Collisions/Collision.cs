namespace RayG
{
    public static class Collision
    {
        /// <summary>
        /// Performs collision detection and handling for a GameObject and its descendants.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void StartCollision(this GameObject gameObject)
        {
            var collideable = gameObject.ColliderDetecter();
            CollisionCleaner(collideable);
            CollisionChecker(collideable);
            CollisionResolver(collideable);
        }

        //Finds all collisors within this GameObject.Childs recursively
        private static List<GameObject> ColliderDetecter(this GameObject gameObject)
        {
            List<GameObject> collideable = new();
            foreach (var child in gameObject.Children)
            {
                collideable.AddRange(child.ColliderDetecter());

                if (child is ICollisor colChild)
                {
                    collideable.Add((GameObject)colChild);
                }
            }
            return collideable;
        }

        //If a previous colliding object is no more colliding, remove it from 
        //   Collisor.Colliders and calls OnCollisionExit
        private static void CollisionCleaner(List<GameObject> Collideable)
        {
            foreach (var gameObject in Collideable)
            {
                if (gameObject is ICollisor colObject && !colObject.Collisor.Static)
                {
                    for (int i = colObject.Collisor.Colliders.Count - 1; i >= 0; i--)
                    {
                        var collider = colObject.Collisor.Colliders[i];
                        if (!colObject.Collisor.IsColliding(collider))
                        {
                            colObject.Collisor.Colliders.RemoveAt(i);
                            colObject.OnCollisionExit(collider);
                        }
                        else
                            colObject.OnCollision(collider);
                    }
                }
            }
        }

        //Verify if GameObjects are colliding with each other
        //  and calls OnCollisinoEnter
        private static void CollisionChecker(List<GameObject> collideable)
        {
            foreach (var gameObject in collideable)
            {
                if (gameObject is ICollisor colObject && !colObject.Collisor.Static)
                {
                    foreach (var otherGameObject in collideable)
                    {
                        if (otherGameObject is ICollisor otherColObject)
                        {
                            if (colObject.Collisor != otherColObject.Collisor
                                && !colObject.Collisor.Colliders.Contains(otherColObject.Collisor))
                            {
                                if (colObject.Collisor.IsColliding(otherColObject.Collisor))
                                {
                                    colObject.Collisor.Colliders.Add(otherColObject.Collisor);
                                    colObject.OnCollisionEnter(otherColObject.Collisor);
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void CollisionResolver(List<GameObject> collideable)
        {
            foreach(var gameObject in collideable)
            {
                if (gameObject is ICollisor colObject && !colObject.Collisor.Static)
                {
                    colObject.Collisor.Resolve();
                }
            }
        }
    }
}
