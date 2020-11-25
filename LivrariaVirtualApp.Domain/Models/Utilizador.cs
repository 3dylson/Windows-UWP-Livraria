using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Utilizador : Entity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NIF { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Morada { get; set; }
        public long Telefone { get; set; }
        public int Admin { get; set; }
        
        
        public int IDlivraria { get; set; }
        public Livraria Livraria { get; set; }

        public Utilizador() { }
        public Utilizador(int id, string nome, string nif, string email, string datanascimento, 
                          string morada, long telefone, int admin, int idlivraria)
        {
            this.ID = id;
            this.Nome = nome;
            this.NIF = nif;
            this.Email = email;
            this.DataNascimento = datanascimento;
            this.Morada = morada;
            this.Telefone = telefone;
            this.Admin = admin;
            this.IDlivraria = idlivraria;

        }

        public override string ToString()
        {
            return $"ID:{Id}, Nome:{Nome}, NIF:{NIF}, Email:{Email}, Data de Nascimento:{DataNascimento}, " +
                   $"Morada:{Morada}, Telefone:{Telefone}";
        }




    }


}

