using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Core
{
    public class RequestPerformanceMonitor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private Synchronizer<SimpleLog, SimpleLog, SimpleLog> SimpleLog { get; }

        public RequestPerformanceMonitor(ILogger<TRequest> logger, SimpleLog simpleLog)
        {
            timer = new Stopwatch();
            this.logger = logger;
            this.SimpleLog = new Synchronizer<SimpleLog, SimpleLog, SimpleLog>(simpleLog);
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();
            var response = await next();
            timer.Stop();

            //SimpleLog.Write(log => log.AddLogEntry($"Inside RequestPerformanceMonitor.Handle()"));

            if (timer.ElapsedMilliseconds > 5)
            {
                var name = typeof(TRequest).Name;

                // TODO: Add User Details

                //logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}", name, timer.ElapsedMilliseconds, request);
                SimpleLog.Write(log => log.AddLogEntry($"Long Running Request {name} completed in {timer.ElapsedMilliseconds} milliseconds - {request}"));
            }

            return response;
        }
    }
}
