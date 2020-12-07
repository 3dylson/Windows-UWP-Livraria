using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Parceiro : Entity
    {
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Atividade { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        

        public Parceiro() { }
        public Parceiro(string nome, string nif, string atividade, string email, long telefone)
        {
            this.Nome = nome;
            this.NIF = nif;
            this.Atividade = atividade;
            this.Email = email;
            this.Telefone = telefone;
            

        }

        public override string ToString()
        {
            return $"Nome:{Nome}, NIF:{NIF}, Atividade:{Atividade}, Email:{Email}"; 
        
        
        }




    }


}

