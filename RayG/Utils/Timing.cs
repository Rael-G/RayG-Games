namespace RayG
{
    public class Timing
    {
        /// <summary>
        /// Executes an action repeatedly with a specific interval in seconds.
        /// </summary>
        /// <param name="interval">The interval between each execution of the action in seconds.</param>
        /// <param name="action">The action to be executed repeatedly.</param>
        /// <param name="cancellationToken">The cancellation token to stop the repeated execution.</param>
        public static async Task EveryAsync(float interval, Action action, CancellationToken cancellationToken)
        {
            int intervalInMilliseconds = (int)(interval * 1000);

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(intervalInMilliseconds, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                    break;

                action();
            }
        }

        /// <summary>
        /// Executes an action after a specific time interval in seconds.
        /// </summary>
        /// <param name="interval">The time interval to wait in seconds before executing the action.</param>
        /// <param name="action">The action to be executed after the time interval.</param>
        public static async Task AfterAsync(float interval, Action action)
        {
            int intervalInMillisecongs = (int)(interval *= 1000);
            await Task.Delay(intervalInMillisecongs);
            action();
        }

        /// <summary>
        /// Gradually interpolates a value from "from" to "to" over a specified time period.
        /// </summary>
        /// <param name="duration">The duration of the interpolation in seconds.</param>
        /// <param name="from">The initial value of the interpolation.</param>
        /// <param name="to">The final value of the interpolation.</param>
        /// <param name="target">The action that receives the interpolated values (e.g., (t) => x = t).</param>
        public static async Task InterpolateAsync(float duration, float from, float to, Action<float> target)
        {
            var distance = to - from;
            double currentTime = 0;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            while (currentTime < duration)
            {
                await Task.Delay(1);
                currentTime = stopwatch.Elapsed.TotalSeconds;
                var t = (float)currentTime / duration;
                var value = from + t * distance;
                target(value);
            }
            target(to);
        }

        /// <summary>
        /// Executes a list of tasks sequentially, waiting for each one to complete before starting the next.
        /// </summary>
        /// <param name="tasks">A collection of functions that return tasks to be executed sequentially.</param>
        public static async void ChainAsync(IEnumerable<Func<Task>> tasks)
        {
            foreach (var funcTask in tasks)
            {
                var task = funcTask();
                await task;
            }
        }
    }
}