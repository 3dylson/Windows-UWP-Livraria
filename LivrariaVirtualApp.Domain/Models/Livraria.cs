using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Livraria : Entity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Descricao { get; set; }
        public string AnoFundacao { get; set; }
        

        public Livraria() { }
        public Livraria(int id, string nome, string nif, string descricao, string anofundacao)
        {
            this.ID = id;
            this.Nome = nome;
            this.NIF = nif;
            this.Descricao = descricao;
            this.AnoFundacao =anofundacao;
            

        }

        public override string ToString()
        {
            return $"ID:{Id}, Nome:{Nome}, NIF:{NIF}, Descrição:{Descricao}, Ano Fundação:{AnoFundacao}";
        }




    }


}

