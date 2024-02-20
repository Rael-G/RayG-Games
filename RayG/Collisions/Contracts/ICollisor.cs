namespace RayG
{
    public interface ICollisor
    {
        /// <summary>
        /// The collisor associated with this object.
        /// </summary>
        Collisor Collisor { get; set; }

        /// <summary>
        /// Called when this object enters a collision with another collisor.
        /// </summary>
        void OnCollisionEnter(Collisor collisor);

        /// <summary>
        /// Called when this object keeps collision with another collisor.
        /// </summary>
        void OnCollision(Collisor collisor);

        /// <summary>
        /// Called when this object exits a collision with another collisor.
        /// </summary>
        void OnCollisionExit(Collisor collisor);
    }
}
