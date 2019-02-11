using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

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
