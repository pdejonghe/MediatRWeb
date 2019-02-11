using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using MediatRWeb.Core;

namespace MediatRWeb.Notifications
{
    public class RoyaltyWatcher : INotificationHandler<RoyaltyEvent>
    {
        private readonly ILogger<RoyaltyWatcher> logger;
        private Synchronizer<SimpleLog, SimpleLog, SimpleLog> SimpleLog { get; }


        public RoyaltyWatcher(ILogger<RoyaltyWatcher> logger, SimpleLog simpleLog)
        {
            this.logger = logger;
            this.SimpleLog = new Synchronizer<SimpleLog, SimpleLog, SimpleLog>(simpleLog);
        }

        public Task Handle(RoyaltyEvent royaltyEvent, CancellationToken cancellationToken)
        {
            //logger.LogWarning($"Royals Magazine Headline: {royaltyEvent.Message}!");
            this.SimpleLog.Write(log => log.AddLogEntry($"Royals Magazine Headline: {royaltyEvent.Message}!"));

            return Task.CompletedTask;
        } 
    }
}
