using CqrsMediatRExample.Notifications;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotifications>
    {
        private readonly FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotifications notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Email Sent");
            await Task.CompletedTask;
        }
    }
}
