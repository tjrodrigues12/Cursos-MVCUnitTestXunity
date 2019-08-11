﻿
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string _nome = "Informática Básica";
        private string _descricao = "Uma descrição...";
        private double _cargaHoraria = 80;
        private PublicoALvo _publicoAlvo = PublicoALvo.Estudante;
        private double _valor = 950;

        public static CursoBuilder New()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }
        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }
        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }

    }
}
