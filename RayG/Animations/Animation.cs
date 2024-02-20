namespace RayG
{
    public class Animation
    {
        /// <summary>
        /// Gets the total number of frames in the animation.
        /// </summary>
        public int Frames { get; }

        /// <summary>
        /// Gets the interval between frames in the animation.
        /// </summary>
        public float Interval { get; }

        /// <summary>
        /// Gets an array of sprites representing the frames of the animation.
        /// </summary>
        public Sprite[] Sprite { get; }

        /// <summary>
        /// Gets or sets the index of the current frame in the animation.
        /// </summary>
        public int CurrentFrame { get; internal set; }

        public Animation(int frames, Sprite[] sprite, float interval)
        {
            Frames = frames;
            Sprite = sprite;
            CurrentFrame = 0;
            Interval = interval;
        }

        /// <summary>
        /// Flips horizontally all sprites in the animation.
        /// </summary>
        public void FlipHorizontally()
        {
            for (int i = 0; i < Sprite.Length; i++)
            {
                Sprite[i].FlipHorizontally();
            }
        }
    }
}
