
namespace AppEscolaRM.Domain.Alunos.Commands
{
    using Core.Commands;
    using System;

    public abstract class BaseAlunoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }
    }
}
