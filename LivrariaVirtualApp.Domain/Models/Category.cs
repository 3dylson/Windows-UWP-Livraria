using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
              

        public Category() { }
        public Category(string name, int category_id)
        {
            this.Name = name;
            this.Id = category_id;
                        
        }

        public override string ToString()
        {
            return Name;
        }




    }


}

