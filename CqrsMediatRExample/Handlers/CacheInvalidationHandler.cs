using CqrsMediatRExample.Notifications;
using MediatR;

namespace CqrsMediatRExample.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotifications>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;


        public async Task Handle(ProductAddedNotifications notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
