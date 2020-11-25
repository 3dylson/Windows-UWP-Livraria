using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Parceiros : Entity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Atividade { get; set; }
        public string Email { get; set; }
        public long Telefone { get; set; }
        

        public Parceiros() { }
        public Parceiros(int id, string nome, string nif, string atividade, string email, long telefone)
        {
            this.ID = id;
            this.Nome = nome;
            this.NIF = nif;
            this.Atividade = atividade;
            this.Email = email;
            

        }

        public override string ToString()
        {
            return $"ID:{Id}, Nome:{Nome}, NIF:{NIF}, Atividade:{Atividade}, Email:{Email}"; 
        
        
        }




    }


}

