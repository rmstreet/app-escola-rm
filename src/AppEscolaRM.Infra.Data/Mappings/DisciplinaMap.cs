using AppEscolaRM.Domain.Disciplinas;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscolaRM.Infra.Data.Mappings
{
    public class DisciplinaMap : EntityTypeConfiguration<Disciplina>
    {
        public DisciplinaMap()
        {
            HasKey(d => d.Id);

            Property(d => d.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(d => d.Semestre)
                .IsRequired()
                .HasMaxLength(1);

            Property(d => d.Ano)
                .IsRequired();
               
        }
    }
}
