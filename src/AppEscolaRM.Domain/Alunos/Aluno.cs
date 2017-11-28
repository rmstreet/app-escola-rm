
namespace AppEscolaRM.Domain.Alunos
{
    using Core.Models;
    using FluentValidation;
    using System;

    public class Aluno : Entity<Aluno>
    {
        
        public Aluno(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }



        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarCpf();

            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do aluno precisa ser fornecido.");
        }

        private void ValidarCpf()
        {
            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("O cpf do aluno precisa ser fornecido.");
        }

        #endregion

    }
}
