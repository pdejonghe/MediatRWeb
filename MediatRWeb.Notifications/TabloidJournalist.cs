using MediatR;
using MediatRWeb.Core;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Notifications
{
    public class TabloidJournalist : INotificationHandler<RoyaltyEvent>
    {
        private readonly ILogger<TabloidJournalist> logger;
        private Synchronizer<SimpleLog, SimpleLog, SimpleLog> SimpleLog { get; }

        public TabloidJournalist(ILogger<TabloidJournalist> logger, SimpleLog simpleLog)
        {
            this.logger = logger;
            this.SimpleLog = new Synchronizer<SimpleLog, SimpleLog, SimpleLog>(simpleLog);
        } 

        public Task Handle(RoyaltyEvent royaltyEvent, CancellationToken cancellationToken)
        {
            //logger.LogWarning($"Daily Mirror Headline: {royaltyEvent.Message}!");
            SimpleLog.Write(log => log.AddLogEntry($"Daily Mirror Headline: {royaltyEvent.Message}!"));

            return Task.CompletedTask;
        }
    }
}
