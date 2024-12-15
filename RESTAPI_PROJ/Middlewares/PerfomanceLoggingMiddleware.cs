using System.Collections.Concurrent;
using System.Diagnostics;
using Serilog;
namespace RESTAPI_PROJ.Middlewares
{
    public class PerfomanceLoggingMiddleware
    {
        private readonly ILogger<PerfomanceLoggingMiddleware> _logger;
        private static readonly ConcurrentDictionary<string, (long totalTime, int requestCount)> _routeStats = new();
        private readonly RequestDelegate _next;

        public PerfomanceLoggingMiddleware(ILogger<PerfomanceLoggingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // Measure the start time of the request
            var stopwatch = Stopwatch.StartNew();

            // Let the request proceed through the pipeline
            await _next(context);

            // Measure the end time of request
            stopwatch.Stop();

            // Get the route (path) of the request
            var route = context.Request.Path.Value;

            // Calculate average time taken for this route
            _routeStats.AddOrUpdate(route!, (stopwatch.ElapsedMilliseconds, 1), (_, data) =>
            {
                var (totalTime, requestCount) = data;
                return (totalTime + stopwatch.ElapsedMilliseconds, requestCount + 1);
            });


            // Check if the response is success.
            if (context.Response.StatusCode == 200)
            {
                // Log the performance data for the route
                var (averageTime, requestCount) = _routeStats[route!];

                // Foramt for log data
                var logData = $"Route: {route}, Time: {stopwatch.ElapsedMilliseconds}ms Average Time: {averageTime / requestCount}ms, Total Requests: {requestCount}";
                // Log the performance data using Serilog
                Log.Information(logData);
            }
        }
    }
}
