using LivrariaVirtualApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class CartViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the CartWrapper class that wraps a Cart object.
        /// </summary>
        public CartViewModel(Cart cart = null) => Cart = cart ?? new Cart();

        public BookViewModel BookViewModel { get; set; }

        public UserViewModel UserViewModel { get; set; }
       

        public ObservableCollection<Book> Books { get; set; }

        public async void LoadAllAsync()
        {
            var userId = App.UserViewModel.LoggedUser.Id;
            var list = await App.UnitOfWork.WishlistRepository
                .FindAllByUserIdAsync(userId);
        }

        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the underlying Cart object.
        /// </summary>
        public Cart Cart { get; }

        

        /// <summary>
        /// Gets or sets the book for the cart.
        /// </summary>
        public Book Book
        {
            get => Cart.Book;
            set
            {
                if (Cart.Book != value)
                {
                    Cart.Book = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Gets or sets the book quantity for the Cart.
        /// </summary>
        public int Quantity
        {
            get => Cart.Quantity;
            set
            {
                if (Cart.Quantity != value)
                {
                    Cart.Quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        




    }
}
