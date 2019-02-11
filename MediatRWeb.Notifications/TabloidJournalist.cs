using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

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
