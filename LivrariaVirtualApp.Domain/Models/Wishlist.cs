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
        public int Book_id { get; set; }
        [ForeignKey("Book_id")]

        public User User { get; set; }
        public List<Book> Books { get; set; }
        public Wishlist() { }
        public Wishlist(string name_wishlist, int wishlist_id)
        {
            this.Name = name_wishlist;
            this.Id = wishlist_id;
                        
        }

        public override string ToString()
        {
            return Name;
        }




    }


}

