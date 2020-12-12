using LivrariaVirtualApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Parental_guide { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public int Available { get; set; }
        public DateTime Realease_date { get; set; }
        public string Publisher { get; set; }
        public string Pages { get; set; }
        public string Overview { get; set; }
        public byte[] Image { get; set; }

                
        public int Category_id { get; set; }
        

        public Category Category { get; set; }
        
        public Book() { }
        public Book(string name, string isbn, string pg, string language,
                     decimal price, int available, DateTime release_date, string publisher,
                     string pages, string overview, byte[] image, int category_id)
        {
            this.Name = name;
            this.ISBN = isbn;
            this.Parental_guide = pg;
            this.Language = language;
            this.Price = price;
            this.Available = available;
            this.Realease_date = release_date;
            this.Publisher = publisher;
            this.Pages = pages;
            this.Overview = overview;
            this.Image = image;
            this.Category_id = category_id;

                        
        }

        public override string ToString()
        {
            return $"{Name}, ISBN:{ISBN}, Parental Guide:{Parental_guide}, Language:{Language}, Price:{Price}, Available:{Available}, Release Date:{Realease_date}," +
                   $"Publisher:{Publisher}, Pages:{Pages}, Overview:{Overview}, Image:{Image}";
        }




    }


}

