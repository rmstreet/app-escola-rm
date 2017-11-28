
namespace AppEscolaRM.DomainTests.Alunos
{
    using Domain.Alunos;
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

    }
}
