using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Order : Entity
    {
        public decimal Total { get; set; }
        public DateTimeKind Date_created { get; set; }
        public Enum Status { get; set; }
        public string Shipping_address { get; set; }
                
        public int User_id { get; set; }
        public int Cart_id { get; set; }
        public int Book_id { get; set; }

        public User User { get; set; }
        public Cart Cart { get; set; }
        public Book Book { get; set; }
        public Order() { }
        public Order(decimal total, DateTimeKind date_created, Enum status, string shipping_adress,
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




    }


}

