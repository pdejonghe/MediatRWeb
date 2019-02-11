using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWeb.Notifications
{
    public class TabloidJournalist : INotificationHandler<RoyaltyEvent>
    {
        private readonly ILogger<TabloidJournalist> logger;

        public TabloidJournalist(ILogger<TabloidJournalist> logger) => this.logger = logger;

        public Task Handle(RoyaltyEvent royaltyEvent, CancellationToken cancellationToken)
        {
            logger.LogWarning($"Daily Mirror Headline: {royaltyEvent.Message}!");

            return Task.CompletedTask;
        }
    }
}
