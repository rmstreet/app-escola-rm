
namespace AppEscolaRM.Domain.Core.Bus
{
    using Commands;
    using Events;

    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
