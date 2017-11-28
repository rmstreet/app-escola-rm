
namespace AppEscolaRM.Domain.Alunos.Commands
{
    using System;
    public class ExcluirAlunoCommand : BaseAlunoCommand
    {
        public ExcluirAlunoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
