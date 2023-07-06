using MediatR;

namespace CqrsMediatRExample.Notifications
{
    public record ProductAddedNotifications(Product product) : INotification;
}
