using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    /// <summary>
    /// Represents a User.
    /// </summary>
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birth_date { get; set; }
        public string Phone { get; set; }
        public int Admin { get; set; }

        public List<Wishlist> Wishlists { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Order { get; set; }    
        public User() { }
        public User(string name, string email, string password, string birth_date, 
                          string phone, int admin, int user_id)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Birth_date = birth_date;
            this.Phone = phone;
            this.Admin = admin;
            this.Id = user_id;
            
            
            
        }

        /// <summary>
        /// Returns the User's infos.
        /// </summary>
        public override string ToString() =>  $"Name:{Name}, Email:{Email}, Birthday:{Birth_date}, " +
                   $"Phone number:{Phone}";

    }


}

