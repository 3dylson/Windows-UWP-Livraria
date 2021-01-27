using LivrariaVirtualApp.Domain.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class BookViewModel : BindableBase
    {
        

        public ObservableCollection<Book> Books { get; set; }

        public ObservableCollection<Wishlist> Wishlists { get; set; }

        public ObservableCollection<Cart> Carts { get; set; }

        public Wishlist Wishlist { get; set; }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }


        private string _categoryName;

        public string CategoryName
        {
            get { return _categoryName; }
            set
            {
                Set(ref _categoryName, value);
                OnPropertyChanged(nameof(Invalid));
                OnPropertyChanged(nameof(Valid));
            }
        }

        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set
            {
                Set(ref _bookName, value);
                OnPropertyChanged(nameof(Invalid));
                OnPropertyChanged(nameof(Valid));
            }
        }

        private string _bookISBN;

        public string BookISBN
        {
            get { return _bookISBN; }
            set { Set(ref _bookISBN, value); }

        }

        private string _bookParental_guide;

        public string BookParental_guide
        {
            get { return _bookParental_guide; }
            set { Set(ref _bookParental_guide, value); }

        }

        private string _bookLanguage;

        public string BookLanguage
        {
            get { return _bookLanguage; }
            set { Set(ref _bookLanguage, value); }

        }

        private decimal _bookPrice;

        public decimal BookPrice
        {
            get { return _bookPrice; }
            set { Set(ref _bookPrice, value); }

        }


        //private DateTime _bookRealease_date;

        //public DateTime BookRealease_date
        //{
        //    get { return _bookRealease_date; }
        //    set { Set(ref _bookRealease_date, value); }

        //}

        private string _bookPublisher;

        public string BookPublisher
        {
            get { return _bookPublisher; }
            set { Set(ref _bookPublisher, value); }

        }

        private string _bookPages;

        public string BookPages
        {
            get { return _bookPages; }
            set { Set(ref _bookPages, value); }

        }

        private string _bookOverview;

        public string BookOverview
        {
            get { return _bookOverview; }
            set { Set(ref _bookOverview, value); }

        }

        private byte[] _image;

        public byte[] Image
        {
            get { return _image; }
            set
            {
                Set(ref _image, value);
            }
        }

        public bool Invalid
        {
            get { return !Valid; }
        }

        public bool Valid
        {
            get
            {
                bool res = !string.IsNullOrEmpty(BookName) && !string.IsNullOrEmpty(CategoryName);
                return res;
            }
        }

        public BookViewModel()
        {
            Book = new Book();
            Books = new ObservableCollection<Book>();
            Wishlists = new ObservableCollection<Wishlist>();
            Carts = new ObservableCollection<Cart>();

            TitleText = "Books";
        }


        private string _titleText;
        public string TitleText
        {
            get { return _titleText; }
            set
            {
                Set(ref _titleText, value);
            }
        }

        private Book _book;
        public Book Book
        {
            get { return _book; }
            set
            {
                _book = value;
                CategoryName = _book?.Category?.Name;
                BookName = _book?.Name;
                BookISBN = _book?.ISBN;
                BookParental_guide = _book?.Parental_guide;
                BookLanguage = _book?.Language;
                BookPrice = (decimal)(_book?.Price);
                //BookRealease_date = (DateTime)(_book?.Realease_date);
                BookPublisher = _book?.Publisher;
                BookPages = _book?.Pages;
                BookOverview = _book?.Overview;
                Image = _book?.Image;
            }
        }

        internal async void DeleteBookAsync(Book m)
        {
            await App.UnitOfWork.BookRepository.DeleteAsync(m);
            Books.Remove(m);
        }

        public async void LoadAllByLoggedUserAsync()
        {
            List<Book> list = null;
            User logged = App.UserViewModel.LoggedUser;

            var userId = logged.Id;
            list = await App.UnitOfWork.BookRepository
                .FindAllByUserIdAsync(userId);

            Books.Clear();
            foreach (var l in list)
            {
                Books.Add(l);
            }
        }

        public async void LoadAllAsync()
        {
            var list = await App.UnitOfWork.BookRepository.FindAllAsync();
            Books.Clear();
            foreach (var l in list)
            {
                Books.Add(l);
            }
        }

        internal async Task<Book> AddBookAsync()
        {
            // Get existing Category or Create a new one
            Category category = new Category(CategoryName);
            Category categoryUpdated = await App.UnitOfWork.CategoryRepository.FindOrCreate(category);

            // Fill Book fields
            Book.Category_id = categoryUpdated.Id;
            Book.Category = null;
            Book.Name = BookName;
            Book.ISBN = BookISBN;
            Book.Parental_guide = BookParental_guide;
            Book.Language = BookLanguage;
            Book.Price = BookPrice;
            //Book.Realease_date = BookRealease_date;
            Book.Publisher = BookPublisher;
            Book.Overview = BookOverview;
            Book.Image = Image;

            // Create Book
            return await App.UnitOfWork.BookRepository.UpsertAsync(Book);
        }

        internal async Task<ObservableCollection<Category>> LoadCategoriesByNameStartWithAsync(string categoryName)
        {
            var list = await App.UnitOfWork.CategoryRepository.FindAllByNameStartWithAsync(categoryName);
            return new ObservableCollection<Category>(list);
        }

        internal async Task<ObservableCollection<Book>> LoadBooksByCategoryStartWithAsync(string text)
        {
            var list = new List<Book>();

            int categoryId = 0;
            Category cat = await App.UnitOfWork.CategoryRepository.FindByNameAsync(CategoryName);

            // Teaser expression
            categoryId = cat?.Id ?? -1;

            list = await App.UnitOfWork.BookRepository
                .FindAllByCategoryStartWithAsync(categoryId, text);
            return new ObservableCollection<Book>(list);
        }



        public async void LoadAllByWishlistAsync()
        {
            if (Wishlist.Id != 0)
            {
                var userId = App.UserViewModel.LoggedUser.Id;
                var list = await App.UnitOfWork.BookRepository
                    .FindAllByUserIdAndWishlistAsync(userId, Wishlist.Id);

                Books.Clear();

                foreach (var l in list)
                    Books.Add(l);

                TitleText = $"Books of {Wishlist.Name}";
            }
        }

        internal async Task <object> AddBookToWishlistAsync()
        {
            Book book = new Book(BookName);
            Book bookupdated = await App.UnitOfWork.BookRepository.FindOrCreate(book);

            User user = await App.UnitOfWork.UserRepository.FindByIdAsync(App.UserViewModel.LoggedUser.Id);
            Wishlist w = user.AddBook(bookupdated);
            await App.UnitOfWork.UserRepository.UpdateAsync(user);

            Wishlist wishlist = await App.UnitOfWork.WishlistRepository.FindByIdAsync(Wishlist.Id);
            

            return await App.UnitOfWork.WishlistRepository.UpsertAsync(wishlist) != null;
        }

        internal async Task<object> AddBookToCartAsync()
        {
            Book book = new Book(BookName);
            Book bookupdated = await App.UnitOfWork.BookRepository.FindOrCreate(book);

            Order order = new Order();
            Order orderupdated = await App.UnitOfWork.OrderRepository.FindOrCreate(order);
            Cart c = order.AddBook(bookupdated.Id, 1);
            await App.UnitOfWork.OrderRepository.UpdateAsync(order);


            return await App.UnitOfWork.OrderRepository.UpsertAsync(order) != null;
        }



    }
}
