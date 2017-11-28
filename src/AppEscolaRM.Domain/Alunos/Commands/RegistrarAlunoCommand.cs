
namespace AppEscolaRM.Domain.Alunos.Commands
{
    public class RegistrarAlunoCommand : BaseAlunoCommand
    {
        public RegistrarAlunoCommand(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }
    }
}
