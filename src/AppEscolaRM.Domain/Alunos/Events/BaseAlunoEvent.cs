
namespace AppEscolaRM.Domain.Alunos.Events
{
    using Core.Events;
    using System;

    public class BaseAlunoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
    }
}
