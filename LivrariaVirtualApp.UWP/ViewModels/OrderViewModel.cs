using LivrariaVirtualApp.Domain.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using static LivrariaVirtualApp.Domain.Models.Order;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class OrderViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the OrderViewModel class that wraps the specified Order object.
        /// </summary>
        /// <param name="model">The order to wrap.</param>
        public OrderViewModel(Order model)
        {
            Model = model;

            // Create an ObservableCollection to wrap Order.LineItems so we can track
            // product additions and deletions.
            Carts = new ObservableCollection<Cart>(Model.Cart);
            Carts.CollectionChanged += Carts_Changed;

            NewCart = new CartViewModel();

            if (model.User == null)
            {
                Task.Run(() => LoadUser(Model.User_id));
            }
        }

        /// <summary>
        /// Creates an OrderViewModel that wraps an Order object created from the specified ID.
        /// </summary>
        public async static Task<OrderViewModel> CreateFromid(int orderId) =>
            new OrderViewModel(await GetOrder(orderId));

        /// <summary>
        /// Gets the underlying Order object.
        /// </summary>
        public Order Model { get; }

        /// <summary>
        /// Loads the customer with the specified ID.
        /// </summary>
        private async void LoadUser(int userId)
        {
            var user = await App.UnitOfWork.UserRepository.GetAsync(userId);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                User = user;
            });
        }

        /// <summary>
        /// Returns the order with the specified ID.
        /// </summary>
        private static async Task<Order> GetOrder(int orderId) =>
            await App.UnitOfWork.OrderRepository.GetAsync(orderId);

        /// <summary>
        /// Gets a value that specifies whether the user can refresh the page.
        /// </summary>
        public bool CanRefresh => Model != null && !IsModified && IsExistingOrder;

        /// <summary>
        /// Gets a value that specifies whether the user can revert changes.
        /// </summary>
        public bool CanRevert => Model != null && IsModified && IsExistingOrder;

        private bool _IsModified = false;

        /// <summary>
        /// Gets or sets a value that indicates whether the underlying model has been modified.
        /// </summary>
        public bool IsModified
        {
            get => _IsModified;
            set
            {
                if (value != _IsModified)
                {
                    // Only record changes after the order has loaded.
                    if (IsLoaded)
                    {
                        _IsModified = value;
                        OnPropertyChanged();
                    }
                }
            }
        }

        /// <summary>
        /// Gets a value that indicates whether this is an existing order.
        /// </summary>
        public bool IsExistingOrder => !IsNewOrder;

        /// <summary>
        /// Gets a value that indicates whether there is a backing order.
        /// </summary>
        public bool IsLoaded => Model != null && (IsNewOrder || Model.User != null);

        /// <summary>
        /// Gets a value that indicates whether there is not a backing order.
        /// </summary>
        public bool IsNotLoaded => !IsLoaded;

        /// <summary>
        /// Gets a value that indicates whether this is a newly-created order.
        /// </summary>
        public bool IsNewOrder => Model.Id == 0;

        /// <summary>
        /// Gets or sets the invoice number for this order.
        /// </summary>
        public int Id
        {
            get => Model.Id;
            set
            {
                if (Model.Id != value)
                {
                    Model.Id = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsNewOrder));
                    OnPropertyChanged(nameof(IsLoaded));
                    OnPropertyChanged(nameof(IsNotLoaded));
                    OnPropertyChanged(nameof(IsNewOrder));
                    OnPropertyChanged(nameof(IsExistingOrder));
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer for this order. This value is null
        /// unless you manually retrieve the customer (using CustomerId) and
        /// set it.
        /// </summary>
        public User User
        {
            get => Model.User;
            set
            {
                if (Model.User != value)
                {
                    var isLoadingOperation = Model.User == null &&
                        value != null && !IsNewOrder;
                    Model.User = value;
                    OnPropertyChanged();
                    if (isLoadingOperation)
                    {
                        OnPropertyChanged(nameof(IsLoaded));
                        OnPropertyChanged(nameof(IsNotLoaded));
                    }
                    else
                    {
                        IsModified = true;
                    }
                }
            }
        }

        private ObservableCollection<Cart> _carts;

        /// <summary>
        /// Gets the line items in this invoice.
        /// </summary>
        public ObservableCollection<Cart> Carts
        {
            get => _carts;
            set
            {
                if (_carts != value)
                {
                    if (value != null)
                    {
                        value.CollectionChanged += Carts_Changed;
                    }

                    if (_carts != null)
                    {
                        _carts.CollectionChanged -= Carts_Changed;
                    }
                    _carts = value;
                    OnPropertyChanged();
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Notifies anyone listening to this object that a line item changed.
        /// </summary>
        private void Carts_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Carts != null)
            {
                Model.Cart = Carts.ToList();
            }

            OnPropertyChanged(nameof(Carts));
            OnPropertyChanged(nameof(Total));
            IsModified = true;
        }

        private CartViewModel _newCart;

        /// <summary>
        /// Gets or sets the line item that the user is currently working on.
        /// </summary>
        public CartViewModel NewCart
        {
            get => _newCart;
            set
            {
                if (value != _newCart)
                {
                    if (value != null)
                    {
                        value.PropertyChanged += NewCart_PropertyChanged;
                    }

                    if (_newCart != null)
                    {
                        _newCart.PropertyChanged -= NewCart_PropertyChanged;
                    }

                    _newCart = value;
                    UpdateNewCartBindings();
                }
            }
        }

        private void NewCart_PropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateNewCartBindings();

        private void UpdateNewCartBindings()
        {
            OnPropertyChanged(nameof(NewCart));
            OnPropertyChanged(nameof(HasNewCart));
            OnPropertyChanged(nameof(NewCartBookListPriceFormatted));
        }

        /// <summary>
        /// Gets or sets whether there is a new line item in progress.
        /// </summary>
        public bool HasNewCart => NewCart != null && NewCart.Book != null;

        /// <summary>
        /// Gets the product list price of the new line item, formatted for display.
        /// </summary>
        public string NewCartBookListPriceFormatted => (NewCart?.Book?.Price ?? 0).ToString("c");

        /// <summary>
        /// Gets or sets the date this order was placed.
        /// </summary>
        public DateTime Date_created
        {
            get => Model.Date_created;
            set
            {
                if (Model.Date_created != value)
                {
                    Model.Date_created = value;
                    OnPropertyChanged();
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets the total. This value is calculated automatically.
        /// </summary>
        public decimal Total => Model.Total;

        /// <summary>
        /// Gets or sets the shipping address, which may be different
        /// from the customer's primary address.
        /// </summary>
        public string Shipping_address
        {
            get => Model.Shipping_address;
            set
            {
                if (Model.Shipping_address != value)
                {
                    Model.Shipping_address = value;
                    OnPropertyChanged();
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets the set of order status values so we can populate the order status combo box.
        /// </summary>
        public List<string> OrderStatusValues => Enum.GetNames(typeof(OrderStatus)).ToList();

        /// <summary>
        /// Sets the Status property by parsing a string representation of the enum value.
        /// </summary>
        public OrderStatus SetOrderStatus(object value) => OrderStatus = value == null ?
            OrderStatus.Processing : (OrderStatus)Enum.Parse(typeof(OrderStatus), value as string);

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        public OrderStatus OrderStatus
        {
            get => Model.Status;
            set
            {
                if (Model.Status != value)
                {
                    Model.Status = value;
                    OnPropertyChanged();
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the order's customer.
        /// </summary>
        public string UserOrdering
        {
            get => Model.UserOrdering;
            set
            {
                if (Model.UserOrdering != value)
                {
                    Model.UserOrdering = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Saves the current order to the database.
        /// </summary>
        public async Task SaveOrderAsync()
        {
            Order result = null;
            try
            {
                result = await App.UnitOfWork.OrderRepository.UpsertAsync(Model);
            }
            catch (Exception ex)
            {
                throw new OrderSavingException("Unable to save. There might have been a problem " +
                    "connecting to the database. Please try again.", ex);
            }

            if (result != null)
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsModified = false);
            }
            else
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(() => new OrderSavingException(
                    "Unable to save. There might have been a problem " +
                    "connecting to the database. Please try again."));
            }
        }

        /// <summary>
        /// Stores the product suggestions.
        /// </summary>
        public ObservableCollection<Book> ProductSuggestions { get; } = new ObservableCollection<Book>();

        /// <summary>
        /// Queries the database and updates the list of new product suggestions.
        /// </summary>
        public async void UpdateProductSuggestions(string queryText)
        {
            ProductSuggestions.Clear();

            if (!string.IsNullOrEmpty(queryText))
            {
                var suggestions = await App.UnitOfWork.BookRepository.GetAsync(queryText);

                foreach (Book p in suggestions)
                {
                    ProductSuggestions.Add(p);
                }
            }
        }
    }
}