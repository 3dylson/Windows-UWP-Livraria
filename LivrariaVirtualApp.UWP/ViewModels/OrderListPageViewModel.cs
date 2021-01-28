using LivrariaVirtualApp.Domain.Models;
using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    /// <summary>
    /// Encapsulates data for the OrderListPage. The page UI
    /// binds to the properties defined here.
    /// </summary>
    public class OrderListPageViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the OrderListPageViewModel class.
        /// </summary>
        public OrderListPageViewModel() => IsLoading = false;

        /// <summary>
        /// Gets the unfiltered collection of all orders. 
        /// </summary>
        private List<Order> MasterOrdersList { get; } = new List<Order>();

        /// <summary>
        /// Gets the orders to display.
        /// </summary>
        public ObservableCollection<Order> Orders { get; private set; } = new ObservableCollection<Order>();

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that specifies whether orders are being loaded.
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private Order _selectedOrder;

        /// <summary>
        /// Gets or sets the selected order.
        /// </summary>
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (Set(ref _selectedOrder, value))
                {
                    // Clear out the existing customer.
                    SelectedCustomer = null;
                    if (_selectedOrder != null)
                    {
                        Task.Run(() => LoadCustomer(_selectedOrder.User_id));
                    }
                    OnPropertyChanged(nameof(SelectedOrderGrandTotalFormatted));
                }
            }
        }

        /// <summary>
        /// Gets a formatted version of the selected order's grand total value.
        /// </summary>
        public string SelectedOrderGrandTotalFormatted => (SelectedOrder?.Total ?? 0).ToString("c");

        private User _selectedCustomer;

        /// <summary>
        /// Gets or sets the selected customer.
        /// </summary>
        public User SelectedCustomer
        {
            get => _selectedCustomer;
            set => Set(ref _selectedCustomer, value);
        }

        /// <summary>
        /// Loads the specified customer and sets the
        /// SelectedCustomer property.
        /// </summary>
        /// <param name="userId">The customer to load.</param>
        private async void LoadCustomer(int userId)
        {
            var customer = await App.UnitOfWork.UserRepository.GetAsync(userId);
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                SelectedCustomer = customer;
            });
        }

        /// <summary>
        /// Retrieves orders from the data source.
        /// </summary>
        public async void LoadOrders()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                IsLoading = true;
                Orders.Clear();
                MasterOrdersList.Clear();
            });

            var orders = await Task.Run(App.UnitOfWork.OrderRepository.FindAllAsync);

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                foreach (var order in orders)
                {
                    Orders.Add(order);
                    MasterOrdersList.Add(order);
                }

                IsLoading = false;
            });
        }

        /// <summary>
        /// Submits a query to the data source.
        /// </summary>
        public async void QueryOrders(string query)
        {
            IsLoading = true;
            Orders.Clear();
            if (!string.IsNullOrEmpty(query))
            {
                var results = await App.UnitOfWork.OrderRepository.GetAsync(query);
                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    foreach (Order o in results)
                    {
                        Orders.Add(o);
                    }
                    IsLoading = false;
                });
            }
        }

        /// <summary>
        /// Deletes the specified order from the database.
        /// </summary>
        public async Task DeleteOrder(Order orderToDelete) =>
            await App.UnitOfWork.OrderRepository.DeleteAsync(orderToDelete);

        /// <summary>
        /// Stores the order suggestions.
        /// </summary>
        public ObservableCollection<Order> OrderSuggestions { get; } = new ObservableCollection<Order>();

        /// <summary>
        /// Queries the database and updates the list of new order suggestions.
        /// </summary>
        public void UpdateOrderSuggestions(string queryText)
        {
            OrderSuggestions.Clear();
            if (!string.IsNullOrEmpty(queryText))
            {
                string[] parameters = queryText.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var resultList = MasterOrdersList
                    .Where(order => parameters
                        .Any(parameter =>
                            order.Shipping_address.StartsWith(parameter) ||
                            order.UserOrdering.Contains(parameter) ||
                            order.Id.ToString().StartsWith(parameter)))
                    .OrderByDescending(order => parameters
                        .Count(parameter =>
                            order.Shipping_address.StartsWith(parameter) ||
                            order.UserOrdering.Contains(parameter) ||
                            order.Id.ToString().StartsWith(parameter)));

                foreach (Order order in resultList)
                {
                    OrderSuggestions.Add(order);
                }
            }
        }
    }
}
