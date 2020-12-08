using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Cart : Entity
    {
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
                
        public int User_id { get; set; }
        

        public User User { get; set; }
        
        public List<Book> Books { get; set; }
        public Cart() { }
        public Cart(int quantity, decimal subtotal, int User_id, int cart_id )
        {
            this.Quantity = quantity;
            this.Subtotal = subtotal;
            this.User_id = User_id;
            this.Id = cart_id;
                        
        }

        public override string ToString()
        {
            return $"Quantity:{Quantity}, Subtotal:{Subtotal}€";
        }




    }


}

