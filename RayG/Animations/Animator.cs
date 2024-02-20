namespace RayG
{
    public class Animator
    {
        private Dictionary<string, Animation> Animations { get; }

        private Animation? _currentAnimation;
        private CancellationTokenSource _cancelationToken;

        public Animator(Dictionary<string, Animation> animations) 
        { 
            Animations = animations;
            _cancelationToken = new CancellationTokenSource();
        }

        /// <summary>
        /// Sets the animation to the one with the specified name.
        /// </summary>
        /// <param name="name">The name of the animation to change to.</param>
        /// <returns>The new current animation.</returns>
        public Animation SetAnimation(string name)
        {
            if (_currentAnimation == Animations[name])
                return _currentAnimation;

            _currentAnimation = Animations[name];
            _cancelationToken.Cancel();
            _cancelationToken = new CancellationTokenSource();

            var task = Timing.EveryAsync(_currentAnimation.Interval, () => 
                _currentAnimation.CurrentFrame = _currentAnimation.CurrentFrame < _currentAnimation.Frames - 1 ? 
                _currentAnimation.CurrentFrame + 1 : 0, 
                _cancelationToken.Token);

            return _currentAnimation;
        }

        /// <summary>
        /// Flips horizontally all sprites in all animations managed by the animator.
        /// </summary>
        public void FlipHorizontally()
        {
            foreach (var animation in Animations)
            {
                animation.Value.FlipHorizontally();
            }
        }
    }
}
