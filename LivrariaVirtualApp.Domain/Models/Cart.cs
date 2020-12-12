using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace LivrariaVirtualApp.Domain.Models
{
    /// <summary>
    /// Represents a cart (book + quantity + Subtotal ) on an order.
    /// </summary>
    public class Cart : Entity
    {
        /// <summary>
        /// Gets or sets the quantity of books. 
        /// </summary>
        public int Quantity { get; set; } = 1;
               
        public decimal Subtotal { get; set; } /* public decimal Subtotal => Cart.Sum(cart => Book.Price * Quantity); */

        public int User_id { get; set; }

        public int Book_id { get; set; }


        public User User { get; set; }
       
        public List<Book> Books { get; set; }
        public Cart() { }
        public Cart(int quantity, decimal subtotal, int user_id, int cart_id )
        {
            this.Quantity = quantity;
            this.Subtotal = subtotal;
            this.User_id = user_id;
            this.Id = cart_id;
                        
        }

        public override string ToString()
        {
            return $"Quantity:{Quantity}, Subtotal:{Subtotal}€";
        }




    }


}

