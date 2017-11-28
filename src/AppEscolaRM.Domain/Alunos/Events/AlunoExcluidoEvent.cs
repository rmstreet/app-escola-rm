
namespace AppEscolaRM.Domain.Alunos.Events
{
    using System;
    public class AlunoExcluidoEvent : BaseAlunoEvent
    {
        public AlunoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
