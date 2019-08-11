using System;
using Xunit;
using Xunit.Abstractions;
using ExpectedObjects;
using Bogus;

using CursoOnline.DominioTest._Util;
using CursoOnline.DominioTest._Builders;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.DominioTest.Cursos
{
    //- Criar um curso com nome, carha horária, publico alvo e valor do curso
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor
    //- Todos os campos do curso são obrigatórios

    public class CursoTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoALvo _publicoAlvo;
        private readonly double _valor;

        public void Dispose()
        {
            _output.WriteLine("Disposable Sendo Executado");
        }

        public CursoTest(ITestOutputHelper output)
        {
            var faker = new Faker();
            _output = output;
            _output.WriteLine("Construtor Sendo Executado");
            _nome = faker.Commerce.ProductName();
            _descricao = faker.Lorem.Paragraph();
            _cargaHoraria = faker.Random.Double(1, 100);
            _publicoAlvo = PublicoALvo.Estudante;
            _valor = faker.Random.Double(100,1000);

        }

        [Fact(DisplayName = "DeveCriarCurso")]
        public void DeveCriarCurso()
        {

            //Arrange (Organização)
            var cursoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor                
            };

            //Act (Ação)
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            //Assert (Afirmar)
            //Assert.Equal(cursoEsperado.Nome, curso.Nome);
            //Assert.Equal(cursoEsperado.CargaHoraria, curso.CargaHoraria);
            //Assert.Equal(cursoEsperado.PublicoAlvo, curso.PublicoAlvo);
            //Assert.Equal(cursoEsperado.Valor, curso.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory(DisplayName = "NaoDeveCursoTerNomeVazio")]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            //Arrange (Organização)

            //Act (Ação)

            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().ComNome(nomeInvalido).Build())
                .WithMessage("Nome Inválido");

        }

        [Theory(DisplayName = "NaoDeveCursoTerCargaHorariaMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //Arrange (Organização)


            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().ComCargaHoraria(cargaHorariaInvalida).Build())
                .WithMessage("Carga Horária Inválida");

        }

        [Theory(DisplayName = "NaoDeveCursoTerValorMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            //Arrange (Organização)

            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => CursoBuilder.New().ComValor(valorInvalido).Build())
                .WithMessage("Valor Inválido");

        }
    }
}
