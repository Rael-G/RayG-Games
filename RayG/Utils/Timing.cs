namespace RayG
{
    public class Timing
    {
        public static async Task EveryAsync(int interval, Action action)
        {
            interval *= 1000;
            while (true)
            {
                await Task.Delay(interval);
                action();
            }
        }

        public static async Task AfterAsync(int interval, Action action)
        {
            interval *= 1000;
            await Task.Delay(interval);
            action();
        }

        public static async Task InterpolateAsync(int duration, float from, float to, Action<float> target)
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
        }

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