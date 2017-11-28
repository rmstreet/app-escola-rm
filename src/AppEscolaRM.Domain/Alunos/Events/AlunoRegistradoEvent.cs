
namespace AppEscolaRM.Domain.Alunos.Events
{
    using System;

    public class AlunoRegistradoEvent : BaseAlunoEvent
    {
        public AlunoRegistradoEvent(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;

            AggregateId = Id;
        }
    }
}
