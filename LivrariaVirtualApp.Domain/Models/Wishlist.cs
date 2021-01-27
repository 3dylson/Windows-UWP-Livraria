using LivrariaVirtualApp.Domain.SeedWork;

namespace LivrariaVirtualApp.Domain.Models
{
    public class Wishlist : Entity
    {
        public string Name { get; set; }

        public int User_id { get; set; }

        public int BookId { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }

        public Wishlist()
        {
        }

        public Wishlist(string name_wishlist, int wishlist_id)
        {
            Name = name_wishlist;
            Id = wishlist_id;
        }

        public Wishlist AddBook(int userId)
        {
            var existingbook = Wishlists
                .SingleOrDefault(p => p.User_id == userId);

            if (existingbook == null)
            {
                Wishlist slp = new Wishlist(Id, userId);
                Wishlists.Add(slp)
            }
            else
            {
                existingbook = null;
            }
            return existingbook;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}