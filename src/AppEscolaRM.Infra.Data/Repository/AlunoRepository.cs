
namespace AppEscolaRM.Infra.Data.Repository
{
    using Domain.Alunos;
    using Domain.Alunos.Repository;
    using Data.Context;

    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EscolaRMContext context)
            : base(context)
        {
        }

    }
}
