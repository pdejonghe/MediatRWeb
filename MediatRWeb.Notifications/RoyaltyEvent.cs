using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace MediatRWeb.Notifications
{
    public class RoyaltyEvent : INotification
    {
        public string Message { get; }

        public RoyaltyEvent(string message) => Message = message;
    }
}
