# MediatRWeb
Explore MediatR library in ASP.Net Core

Two NotificationHandlers have been implemented: RoyaltyWatcher and TabloidJournalist. Both get the publication of any RoyaltyEvent, and can react accordingly.

Two RequestHandlers have been implemented: BarTender and LiquorStore. However, due to the nature of requests, only one handler can react on it. The response of the second handler should never be triggered.
