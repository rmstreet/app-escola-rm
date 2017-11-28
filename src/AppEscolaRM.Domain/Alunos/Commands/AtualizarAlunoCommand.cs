using System;

namespace AppEscolaRM.Domain.Alunos.Commands
{
    public class AtualizarAlunoCommand : BaseAlunoCommand
    {
        public AtualizarAlunoCommand(Guid id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}
