﻿using LivrariaVirtualApp.Domain.SeedWork;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Wishlist : Entity
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public int User_id { get; set; }

        public int BookId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }

        public Wishlist()
        {
        }

        public Wishlist(string name_wishlist, int wishlist_id) /*string colorCode*/
        {
            Name = name_wishlist;
            Id = wishlist_id;
            //Color = colorCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}