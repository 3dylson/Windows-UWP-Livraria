using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{

    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order : Entity
    {
        public decimal Total => Cart.Count * .005m;  /* ublic decimal Total { get; set; } */
        public DateTime Date_created { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        public string Shipping_address { get; set; }
                
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public int Cart_id { get; set; }
        [ForeignKey("Cart_id")]
        

        public User User { get; set; }
        public List<Cart> Cart { get; set; }  
        
        /*public Book Book { get; set; }*/

        /// <summary>
        /// Creates a new order.
        /// </summary>
        public Order() { }
        public Order( DateTime date_created, OrderStatus status, string shipping_adress,
                     int user_id, int cart_id)
        {
            /*this.Total = total;*/
            this.Date_created = date_created;
            this.Status = status;
            this.Shipping_address = shipping_adress;
            this.User_id = user_id;
            this.Cart_id = cart_id;
            
                        
        }

        public override string ToString()
        {
            return $"Total with shipping tax added:{Total}€, Ordered at:{Date_created}, Status:{Status}, Your Shipping Address is:{Shipping_address}";
        }

        /// <summary>
        /// Represents the status of an order.
        /// </summary>
        public enum OrderStatus
        {
            Processing,
            Concluded
            
        }


    }


}

