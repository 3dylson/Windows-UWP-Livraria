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
            Name = name;
            ISBN = isbn;
            Parental_guide = pg;
            Language = language;
            Price = price;
            Available = available;
            Realease_date = release_date;
            Publisher = publisher;
            Pages = pages;
            Overview = overview;
            Image = image;
            Category_id = category_id;

                        
        }

        public override string ToString()
        {
            return $"{Name}, ISBN:{ISBN}, Parental Guide:{Parental_guide}, Language:{Language}, Available:{Available}, Release Date:{Realease_date}," +
                   $"Publisher:{Publisher}, Pages:{Pages}, Overview:{Overview}, Image:{Image} \n{Price}";
        }




    }


}

