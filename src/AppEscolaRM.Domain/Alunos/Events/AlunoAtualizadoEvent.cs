
namespace AppEscolaRM.Domain.Alunos.Events
{
    using System;
    public class AlunoAtualizadoEvent : BaseAlunoEvent
    {
        public AlunoAtualizadoEvent(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;

            AggregateId = id;
        }
    }
}
