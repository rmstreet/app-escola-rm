
namespace AppEscolaRM.Infra.Data.Mappings
{
    using AppEscolaRM.Domain.Alunos;
    using System.Data.Entity.ModelConfiguration;

    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            HasKey(a => a.Id);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Cpf)
                .IsRequired()
                .HasMaxLength(11);            
        }
    }
}
