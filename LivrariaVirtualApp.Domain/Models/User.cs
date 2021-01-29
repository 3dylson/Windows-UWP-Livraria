using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                var data = Encoding.UTF8.GetBytes(value);
                var hashData = new SHA1Managed().ComputeHash(data);
                password = BitConverter.ToString(hashData).Replace("-", "").ToUpper();
            }
        }

        private string password;
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Admin { get; set; }

        public List<Wishlist> Wishlists { get; set; }
        public List<Order> Orders { get; set; }

        public User()
        {
        }

        public User(string name, string email, string password,
                          string phone, int admin, string address, int user_id)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
            Address = address;
            Admin = admin;
            Id = user_id;
        }

        public Wishlist AddBook(Book book)
        {
            var existingBook = Wishlists
                .SingleOrDefault(p => p.BookId == book.Id);

            if (existingBook == null)
            {
                existingBook = new Wishlist(Name, book.Id);
                Wishlists.Add(existingBook);
            }
            return existingBook;
        }

        /// <summary>
        /// Returns the User's infos.
        /// </summary>
        public override string ToString() => $"Name:{Name}, Email:{Email}, " +
                   $"Phone number:{Phone}, Address:{Address}";
    }
}