
namespace AppEscolaRM.Domain.Core.Notifications
{
    using Events;
    using System.Collections.Generic;

    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
