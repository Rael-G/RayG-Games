namespace RayG
{
    public interface ICollisor
    {
        Collisor Collisor { get; set; }

        void OnCollisionEnter(Collision collisor);
        void OnCollisionExit(Collisor collisor);
    }
}
