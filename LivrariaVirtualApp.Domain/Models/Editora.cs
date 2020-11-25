using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Editora : Entity{
        //coleção de livros
        public List<Livro> Livros
        {
            get; set;
        }

      
        public Editora(string nome, string morada, string distrito, string email, long telefone)
        {
            this.Nome = nome;
            this.Morada = morada;
            this.Distrito = distrito;
            this.Email = email;
            this.Telefone = telefone;
        }
        //construtor por defeito 
        public Editora(){}

        public string Nome
        {
            get; set;
        }

        public string Distrito
        {
            get;
            set;
        }
        public string Morada{
            get;
            set;
        }   

        public string Email
        {
            get;
            set;
        }

        public long Telefone
        {
            get;
            set;
        }

        public override string ToString()
        {
            return String.Format("{0}, com sede em {1},{2}.\nTelefone:{3},Email:{4}", this.Nome,
                this.Morada, this.Distrito, this.Telefone, this.Email);
        }

    }
}
