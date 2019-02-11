using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Core
{
    public class RequestLogger<TRequest> : MediatR.Pipeline.IRequestPreProcessor<TRequest>
    {
        private readonly ILogger logger;
        private Synchronizer<SimpleLog, SimpleLog, SimpleLog> SimpleLog { get; }

        public RequestLogger(ILogger<TRequest> logger, SimpleLog simpleLog)
        {
            this.logger = logger;
            this.SimpleLog = new Synchronizer<SimpleLog, SimpleLog, SimpleLog>(simpleLog);
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            // TODO: Add User Details

            //logger.LogWarning("Request details: {Name} {@Request}", name, request);
            SimpleLog.Write(log => log.AddLogEntry($"Request details: {name}  {request}"));

            return Task.CompletedTask;
        }
    }
}
