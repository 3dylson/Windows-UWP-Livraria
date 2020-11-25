using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Autor : Entity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Biografia { get; set; }
        public string Nacionalidade { get; set; }
        

        public Autor() { }
        public Autor(int id, string nome, string datanascimento, string biografia, string nacionalidade)
        {
            this.ID = id;
            this.Nome = nome;
            this.DataNascimento = datanascimento;
            this.Biografia = biografia;
            this.Nacionalidade = nacionalidade;
            

        }

        public override string ToString()
        {
            return $"ID:{Id}, Nome:{Nome}, Data de Nascimento:{DataNascimento}, Biografia:{Biografia}," +
                   $" Nacionalidade:{Nacionalidade}";
        }




    }


}

