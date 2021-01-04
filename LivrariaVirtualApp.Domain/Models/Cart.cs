using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace LivrariaVirtualApp.Domain.Models
{
    /// <summary>
    /// Represents a cart on an order.
    /// </summary>
    public class Cart : Entity
    {
        /// <summary>
        /// Gets or sets the quantity of books. 
        /// </summary>
        public int Quantity { get; set; } = 1;
        
        
        public int Book_id { get; set; }
        public int User_id { get; set; }
        public int Order_id { get; set; }

        public Book Book { get; set; }
        public User User { get; set; }
        public Order Order { get; set; } /*= new Order();*/
               
        public List<Book> Books { get; set; }
        public Cart() { }
        public Cart(int quantity, int user_id, int book_id, int order_id)
        {
            Quantity = quantity;
            Book_id = book_id;
            User_id = user_id;
            Order_id = order_id;                      
        }

        
    }


}

