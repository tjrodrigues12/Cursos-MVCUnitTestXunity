using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExpectedObjects;
using CursoOnline.DominioTest._Util;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    //- Criar um curso com nome, carha horária, publico alvo e valor do curso
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor
    //- Todos os campos do curso são obrigatórios

    public class CursoTest //: IDisposable
    {
        private readonly ITestOutputHelper _output;
        private readonly string _nome;
        private readonly string _descricao;
        private readonly double _cargaHoraria;
        private readonly PublicoALvo _publicoAlvo;
        private readonly double _valor;

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        public CursoTest(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor Sendo Executado");
            _nome = "Informática Básica";
            _descricao = "Uma descrição...";
            _cargaHoraria = 80;
            _publicoAlvo = PublicoALvo.Estudante;
            _valor = 950;
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
            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, _descricao, _cargaHoraria,
                _publicoAlvo, _valor)).WithMessage("Nome Inválido");

        }

        [Theory(DisplayName = "NaoDeveCursoTerCargaHorariaMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //Arrange (Organização)


            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _descricao, cargaHorariaInvalida,
                _publicoAlvo, _valor)).WithMessage("Carga Horária Inválida");

        }

        [Theory(DisplayName = "NaoDeveCursoTerValorMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            //Arrange (Organização)

            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _descricao, _cargaHoraria,
                _publicoAlvo, valorInvalido)).WithMessage("Valor Inválido");

        }
    }

    public enum PublicoALvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empreendedor
    }

    public class Curso
    {

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoALvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoALvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida");

            if (valor < 1)
                throw new ArgumentException("Valor Inválido");

            this.Nome = nome;
            this.Descricao = descricao;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }


}
