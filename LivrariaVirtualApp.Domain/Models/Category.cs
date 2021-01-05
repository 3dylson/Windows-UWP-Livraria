using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        
        public List<Book> Books { get; set; }
        public Category() { }
        public Category(string name)
        {
            Name = name;
                                  
        }

        public override string ToString()
        {
            return Name;
        }

    }


}

