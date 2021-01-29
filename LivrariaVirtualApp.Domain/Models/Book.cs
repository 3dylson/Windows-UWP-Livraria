using LivrariaVirtualApp.Domain.SeedWork;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Parental_guide { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }

        //public DateTime Realease_date { get; set; }
        public string Publisher { get; set; }

        public string Pages { get; set; }
        public string Overview { get; set; }
        public byte[] Image { get; set; }

        public int Category_id { get; set; }

        public Category Category { get; set; }

        public Book()
        {
        }

        public Book(string name) /*string isbn, string pg, string language, decimal price, string publisher, string pages, string overview, byte[] image, int category_id*/
        {
            this.Name = name;
            //this.ISBN = isbn;
            //this.Parental_guide = pg;
            //this.Language = language;
            //this.Price = price;

            //this.Publisher = publisher;
            //this.Pages = pages;
            //this.Overview = overview;
            //this.Image = image;
            //this.Category_id = category_id;
        }

        public override string ToString()
        {
            return $"{Name}, ISBN:{ISBN}, Parental Guide:{Parental_guide}, Language:{Language}," +
                   $"Publisher:{Publisher}, Pages:{Pages}, Overview:{Overview}, Image:{Image} \n{Price}";
        }
    }
}