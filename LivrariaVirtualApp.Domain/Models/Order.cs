﻿using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Order : Entity
    {
        public decimal Total { get; set; }
        public DateTime Date_created { get; set; } = DateTime.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        public string Shipping_address { get; set; }
                
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public int Cart_id { get; set; }
        [ForeignKey("Cart_id")]
        public int Book_id { get; set; }
        [ForeignKey("Book_id")]

        public User User { get; set; }
        public Cart Cart { get; set; }
        public Book Book { get; set; }
        public Order() { }
        public Order(decimal total, DateTime date_created, OrderStatus status, string shipping_adress,
                     int User_id, int Cart_id, int Book_id)
        {
            this.Total = total;
            this.Date_created = date_created;
            this.Status = status;
            this.Shipping_address = shipping_adress;
            this.User_id = User_id;
            this.Cart_id = Cart_id;
            this.Book_id = Book_id;
                        
        }

        public override string ToString()
        {
            return $"Total:{Total}, Ordered at:{Date_created}, Status:{Status}, Your Shipping Address is:{Shipping_address}";
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

