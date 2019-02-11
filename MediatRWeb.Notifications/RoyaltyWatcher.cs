using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Notifications
{
    public class RoyaltyWatcher : INotificationHandler<RoyaltyEvent>
    {
        private readonly ILogger<RoyaltyWatcher> logger;

        public RoyaltyWatcher(ILogger<RoyaltyWatcher> logger) => this.logger = logger;

        public Task Handle(RoyaltyEvent royaltyEvent, CancellationToken cancellationToken)
        {
            logger.LogWarning($"Royals Magazine Headline: {royaltyEvent.Message}!");

            return Task.CompletedTask;
        } 
    }
}
