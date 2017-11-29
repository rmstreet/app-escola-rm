
namespace AppEscolaRM.Domain.Disciplinas
{
    using AppEscolaRM.Domain.Alunos;
    using Core.Models;
    using FluentValidation;
    using System;
    using System.Collections.Generic;

    public class Disciplina : Entity<Disciplina>
    {               

        public Disciplina(string nome, string semestre, int ano)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Semestre = semestre;
            Ano = ano;
        }

        public string Nome { get; private set; }
        public string Semestre { get; private set; }
        public int Ano { get; private set; }

        public virtual ICollection<Aluno> AlunosMatriculados { get; set; }

        public string SemestreAno => (!string.IsNullOrEmpty(Semestre) && Ano != 0) ? string.Format("{0}/{1}", Semestre, Ano) : "";

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarSemestre();
            ValidarAno();

            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(d => d.Nome)
                .NotEmpty().WithMessage("O nome da disciplina precisa ser fornecido.");
        }

        private void ValidarSemestre()
        {
            RuleFor(d => d.Semestre)
                .NotEmpty().WithMessage("O semestre da disciplina precisa ser fornecido.");
        }

        private void ValidarAno()
        {
            RuleFor(d => d.Ano)
                .NotEmpty().WithMessage("O ano da disciplina precisa ser fornecido.");
                
        }

        #endregion

    }
}
