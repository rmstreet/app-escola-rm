
namespace AppEscolaRM.Domain.Alunos.Repository
{
    public interface IValidadorCpfRepository
    {
        bool ValidarCPF(string cpf);
    }
}
