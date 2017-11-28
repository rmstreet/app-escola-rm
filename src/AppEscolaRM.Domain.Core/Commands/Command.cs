
namespace AppEscolaRM.Domain.Core.Commands
{
    using Events;
    using System;
    public class Command : Message
    {
        public DateTime Timestamp { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
