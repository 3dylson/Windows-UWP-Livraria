using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaVirtualApp.Domain.Models
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order : Entity
    {
        public virtual decimal Total
        {
            get
            {
                return Cart.Sum(bookCart => bookCart.Book.Price * bookCart.Quantity);
            }

            protected set { }
        }

        public DateTime Date_created { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        public string UserOrdering { get; set; }
        public string Shipping_address { get; set; }

        public int User_id { get; set; }

        public User User { get; set; }
        public List<Cart> Cart { get; set; } = new List<Cart>();

        /// <summary>
        /// Creates a new order.
        /// </summary>
        public Order() { }

        public Order(User user) : this()
        {
            User = user;
            UserOrdering = $"{user.Name}";
            Shipping_address = user.Address;
        }

        public override string ToString()
        {
            return $"Total:{Total}€, Ordered at:{Date_created}, Status:{Status}, Your Shipping Address is:{Shipping_address} \nThank You {UserOrdering}! ";
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