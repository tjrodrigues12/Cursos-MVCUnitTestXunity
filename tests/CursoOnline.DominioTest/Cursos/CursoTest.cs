using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ExpectedObjects;

namespace CursoOnline.DominioTest.Cursos
{

    //- Criar um curso com nome, carha horária, publico alvo e valor do curso
    //- As opções para público alvo são: Estudante, Universitário, Empregado e Empreendedor
    //- Todos os campos do curso são obrigatórios

    public class CursoTest
    {

        [Fact]
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

        [Fact]
        public void NaoDeveCursoTerNomeVazio()
        {

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
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.PublicoAlvo = publicoAlvo;
            this.Valor = valor;
        }
    }


}
