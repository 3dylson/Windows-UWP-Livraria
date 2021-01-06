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
    public class Cart 
    {
        /// <summary>
        /// Gets or sets the quantity of books. 
        /// </summary>
        public int Quantity { get; set; } = 1;
        
        
        public int BookId { get; set; }
        public int OrderId { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; } 
               
        public Cart() { }
        public Cart(int quantity, int book_id, int order_id)
        {
            Quantity = quantity;
            BookId = book_id;
            OrderId = order_id;                      
        }

        
    }


}

