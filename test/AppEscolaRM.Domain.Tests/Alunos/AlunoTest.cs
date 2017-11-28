
namespace AppEscolaRM.Domain.Tests.Alunos
{
    using AppEscolaRM.Domain.Alunos;
    using Xunit;

    public class AlunoTest
    {
        [Fact]
        public void AlunoDeveSerValido()
        {
            var aluno = new Aluno("Daniele", "52110655658");

            var resultado = aluno.EhValido();

            Assert.True(resultado);
            Assert.Equal("Daniele", aluno.Nome);
            Assert.Equal("52110655658", aluno.Cpf);
        }

        [Fact]
        public void AlunoNaoDeveTerNomeVazio()
        {
            var aluno = new Aluno("", "52110655658");

            var resultado = aluno.EhValido();

            Assert.False(resultado);
            Assert.Equal(1, aluno.ValidationResult.Errors.Count);
            Assert.Equal("", aluno.Nome);
            Assert.Equal("O nome do aluno precisa ser fornecido.", aluno.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("52110655658", aluno.Cpf);
        }

        [Fact]
        public void AlunoNaoDeveTerCpfVazio()
        {
            var aluno = new Aluno("Afonso", "");

            var resultado = aluno.EhValido();

            Assert.False(resultado);
            Assert.Equal(1, aluno.ValidationResult.Errors.Count);
            Assert.Equal("Afonso", aluno.Nome);
            Assert.Equal("", aluno.Cpf);
            Assert.Equal("O cpf do aluno precisa ser fornecido.", aluno.ValidationResult.Errors[0].ErrorMessage);            
        }

        [Fact]
        public void AlunoNaoDeveTerTodosOsCamposObrigatoriosVazios()
        {
            var aluno = new Aluno("", "");

            var resultado = aluno.EhValido();

            Assert.False(resultado);
            Assert.Equal(2, aluno.ValidationResult.Errors.Count);
            Assert.Equal("", aluno.Nome);
            Assert.Equal("O nome do aluno precisa ser fornecido.", aluno.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("", aluno.Cpf);
            Assert.Equal("O cpf do aluno precisa ser fornecido.", aluno.ValidationResult.Errors[1].ErrorMessage);
        }
    }
}