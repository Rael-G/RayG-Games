namespace RayG
{
    public struct Collision
    {
        public Collisor Collisor { get; set; }
        public Side Side { get; set; }

        public Collision(Collisor collisor, Side side)
        {
            Collisor = collisor;
            Side = side;
        }
    }
}
