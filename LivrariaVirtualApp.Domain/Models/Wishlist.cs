using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Wishlist : Entity
    {
        public string Name { get; set; }
                
        public int User_id { get; set; }
        
        public int BookId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public Wishlist() { }
        public Wishlist(string name_wishlist, int wishlist_id)
        {
            Name = name_wishlist;
            Id = wishlist_id;
                        
        }

        public override string ToString()
        {
            return Name;
        }




    }


}

