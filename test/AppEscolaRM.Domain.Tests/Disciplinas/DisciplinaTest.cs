
namespace AppEscolaRM.Domain.Tests.Disciplinas
{
    using Domain.Disciplinas;
    using Xunit;

    public class DisciplinaTest
    {
        [Fact]
        public void DisciplinaDeveSerValida()
        {
            var disciplina = new Disciplina("Matemática", "1", 2017);

            var resultado = disciplina.EhValido();

            Assert.True(resultado);
            Assert.Equal("Matemática", disciplina.Nome);
            Assert.Equal("1", disciplina.Semestre);
            Assert.Equal(2017, disciplina.Ano);
        }

        [Fact]
        public void DisciplinaNaoDeveTerNomeVazio()
        {
            var disciplina = new Disciplina("", "1", 2017);

            var resultado = disciplina.EhValido();

            Assert.False(resultado);
            Assert.Equal("", disciplina.Nome);
            Assert.Equal(1, disciplina.ValidationResult.Errors.Count);
            Assert.Equal("O nome da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("1", disciplina.Semestre);
            Assert.Equal(2017, disciplina.Ano);
        }

        [Fact]
        public void DisciplinaNaoDeveTerSemestreVazio()
        {
            var disciplina = new Disciplina("Português", "", 2017);

            var resultado = disciplina.EhValido();

            Assert.False(resultado);
            Assert.Equal("Português", disciplina.Nome);
            Assert.Equal(1, disciplina.ValidationResult.Errors.Count);
            Assert.Equal("O semestre da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("", disciplina.Semestre);
            Assert.Equal(2017, disciplina.Ano);
        }

        [Fact]
        public void DisciplinaNaoDeveTerAnoZerado()
        {
            var disciplina = new Disciplina("Português", "1", 0);

            var resultado = disciplina.EhValido();

            Assert.False(resultado);
            Assert.Equal("Português", disciplina.Nome);
            Assert.Equal(1, disciplina.ValidationResult.Errors.Count);
            Assert.Equal("O ano da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("1", disciplina.Semestre);
            Assert.Equal(0, disciplina.Ano);
        }

        [Fact]
        public void DisciplinaNaoDeveTerTodosOsCamposObrigatoriosVazios()
        {
            var disciplina = new Disciplina("", "", 0);

            var resultado = disciplina.EhValido();

            Assert.False(resultado);
            Assert.Equal(3, disciplina.ValidationResult.Errors.Count);
            Assert.Equal("", disciplina.Nome);       
            Assert.Equal("O nome da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[0].ErrorMessage);
            Assert.Equal("", disciplina.Semestre);
            Assert.Equal("O semestre da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[1].ErrorMessage);
            Assert.Equal(0, disciplina.Ano);
            Assert.Equal("O ano da disciplina precisa ser fornecido.", disciplina.ValidationResult.Errors[2].ErrorMessage);
        }
    }
}
