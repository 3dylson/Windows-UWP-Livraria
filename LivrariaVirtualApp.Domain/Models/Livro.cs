using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Livro : Entity{
        public Livro(string nome, string isbn, string genero, string fe, string dimensoes,
            int numPag, string idioma, int anoEdicao, string quantidade, float preco,
            byte[] imagem, int quant, int idEditora /*,int IdLivraria*/)
        {
            this.Nome = nome;
            this.Isbn = isbn;
            this.Genero = genero;
            this.FaixaEtaria = fe;
            this.Dimensoes = dimensoes;
            this.Imagem = imagem;
            this.Idioma = idioma;
            this.AnoEdicao = anoEdicao;
            this.Quantidade = quantidade;
            this.Preco = preco;
            this.NumeroPaginas = numPag;
            this.Idioma = idioma;
            this.EditoraId = idEditora;

        }

        public Livro() { }

        public Editora Editora
        {
            get; set;
        }

        public string Nome
        {
            get; set;
        }

        public int EditoraId
        {
            get;
            set;
        }

        public string NomeEditora
        {
            get;
            set;
        }

        public string Isbn
        {
            get;
            set;
        }

        public string Genero
        {
            get;
            set;
        }
        public string FaixaEtaria
        {
            get;
            set;
        }

        public int NumeroPaginas
        {
            get;
            set;
        }

        public string Dimensoes
        {
            get;
            set;
        }

        public string Idioma
        {
            get;
            set;
        }
        public int AnoEdicao
        {
            get;
            set;
        }
        public string Quantidade
        {
            get;
            set;
        }
        public float Preco { get; set; }
        public byte[] Imagem { get; set; }


        public override string ToString()
        {
            return String.Format("Livro: {0}\nEditora: {1}\nISBN: {3}\nGénero: {4}\n" +
                "Faixa Etária: {5}\nDimensões: {6}\nNúmero de Páginas: {7}\nIdioma: {8}\n" +
                "Ano de Edição: {9}\nPreço: {10}\nQuantidae : {11}\n", this.Nome, this.NomeEditora,
                this.Isbn, this.Genero, this.FaixaEtaria, this.Dimensoes, this.NumeroPaginas,
                this.Idioma, this.AnoEdicao, this.Preco, this.Quantidade);
        }


    }
}
