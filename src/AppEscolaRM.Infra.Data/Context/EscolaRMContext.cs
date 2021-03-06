﻿using AppEscolaRM.Domain.Alunos;
using AppEscolaRM.Domain.Disciplinas;
using AppEscolaRM.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEscolaRM.Infra.Data.Context
{
    public class EscolaRMContext : DbContext
    {
        public EscolaRMContext()
            : base("EscolaRMConnection")
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.DisciplinasCursadas)
                .WithMany(d => d.AlunosMatriculados)
                .Map(ad => 
                        {
                            ad.MapLeftKey("AlunoId");
                            ad.MapRightKey("DisciplinaId");
                            ad.ToTable("Matriculas");
                        });

            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new DisciplinaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
