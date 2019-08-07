using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExpectedObjects;
using CursoOnline.DominioTest._Util;

namespace CursoOnline.DominioTest.Cursos
{

    //- Criar um curso com nome, carha horária, publico alvo e valor do curso
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor
    //- Todos os campos do curso são obrigatórios

    public class CursoTest
    {

        [Fact(DisplayName = "DeveCriarCurso")]
        public void DeveCriarCurso()
        {

            //Arrange (Organização)
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoALvo.Estudante,
                Valor = (double)950
            };

            //Act (Ação)
            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
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
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoALvo.Estudante,
                Valor = (double)950
            };

            //Act (Ação)


            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).WithMessage("Nome Inválido");

        }

        [Theory(DisplayName = "NaoDeveCursoTerCargaHorariaMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            //Arrange (Organização)
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoALvo.Estudante,
                Valor = (double)950
            };


            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHorariaInvalida,
                cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).WithMessage("Carga Horária Inválida");

        }


        [Theory(DisplayName = "NaoDeveCursoTerValorMenorQue1")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            //Arrange (Organização)
            var cursoEsperado = new
            {
                Nome = (string)"Informática Básica",
                CargaHoraria = (double)80,
                PublicoAlvo = PublicoALvo.Estudante,
                Valor = (double)950
            };

            //Assert (Afirmar)
            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria,
                cursoEsperado.PublicoAlvo, valorInvalido)).WithMessage("Valor Inválido");
            
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
        public double CargaHoraria { get; private set; }
        public PublicoALvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string nome, double cargaHoraria, PublicoALvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome Inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida");

            if (valor < 1)
                throw new ArgumentException("Valor Inválido");

            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }


}
