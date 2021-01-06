using LivrariaVirtualApp.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace LivrariaVirtualApp.Domain.Models
{
    /// <summary>
    /// Represents a cart on an order.
    /// </summary>
    public class Cart : DbContext
    {
        /// <summary>
        /// Gets or sets the quantity of books. 
        /// </summary>
        public int Quantity { get; set; } = 1;
        
        
        public int Book_id { get; set; }
        public int Order_id { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; } 
               
        public Cart() { }
        public Cart(int quantity, int book_id, int order_id)
        {
            Quantity = quantity;
            Book_id = book_id;
            Order_id = order_id;                      
        }

        
    }


}

