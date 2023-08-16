using System.Diagnostics;

namespace RestaurantAPI.Middleware
{
    public class TimeMeasure : IMiddleware
    {
        private readonly ILogger<TimeMeasure> _logger;

        public TimeMeasure(ILogger<TimeMeasure> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch zegar = new Stopwatch();

            zegar.Start();
            await next.Invoke(context);
            zegar.Stop();

            var time = zegar.Elapsed.Seconds;

            if (time > 4)
            {
                var message = $"Request [{context.Request.Method}] at [{context.Request.Path}] took {time} seconds";

                _logger.LogInformation(message);
            }
            
        }
    }
}
