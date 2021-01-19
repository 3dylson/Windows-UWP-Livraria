using LivrariaVirtualApp.Domain.Models;
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
   public class UserViewModel : BindableBase, IEditableObject
    {

        public UserViewModel(User user = null) => User = user ?? new User();

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                if (_user != value)
                {
                    _user = value;
                    RefreshOrders();

                    // Raise the PropertyChanged event for all properties.
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public string Name
        {
            get => User.Name;
            set
            {
                if (value != User.Name)
                {
                    User.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        public string UserName => IsNewUser && string.IsNullOrEmpty(Name) ? "New user" : $"{Name}";

        public string Email
        {
            get => User.Email;
            set
            {
                if (value != User.Email)
                {
                    User.Email = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string Phone
        {
            get => User.Phone;
            set
            {
                if (value != User.Phone)
                {
                    User.Email = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get => User.Address;
            set
            {
                if (value != User.Address)
                {
                    User.Address = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the underlying model has been modified. 
        /// </summary>
        /// <remarks>
        /// Used when sync'ing with the server to reduce load and only upload the models that have changed.
        /// </remarks>
        public bool IsModified { get; set; }

        /// <summary>
        /// Gets the collection of the user's orders.
        /// </summary>
        public ObservableCollection<Order> Orders { get; } = new ObservableCollection<Order>();

        private Order _selectedOrder;

        /// <summary>
        /// Gets or sets the currently selected order.
        /// </summary>
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that indicates whether to show a progress bar. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private bool _isNewUser;

        /// <summary>
        /// Gets or sets a value that indicates whether this is a new user.
        /// </summary>
        public bool IsNewUser
        {
            get => _isNewUser;
            set => Set(ref _isNewUser, value);
        }

        private bool _isInEdit = false;

        /// <summary>
        /// Gets or sets a value that indicates whether the user data is being edited.
        /// </summary>
        public bool IsInEdit
        {
            get => _isInEdit;
            set => Set(ref _isInEdit, value);
        }

        private User _loggedUser;

        public User LoggedUser
        {
            get { return _loggedUser; }
            set
            {
                _loggedUser = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(IsLogged));
                OnPropertyChanged(nameof(IsNotLogged));
                OnPropertyChanged(nameof(IsAdmin));
   
            }
        }

        public bool IsLogged
        {
            get => LoggedUser != null;
        }

        public bool IsNotLogged
        {
            get => !IsLogged;
        }

        public bool IsAdmin => LoggedUser != null && LoggedUser.Admin == 1;


        /// <summary>
        /// Saves user data that has been edited.
        /// </summary>
        public async Task SaveAsync()
        {
            IsInEdit = false;
            IsModified = false;
            if (IsNewUser)
            {
                IsNewUser = false;
                App.UnitOfWork.UserRepository.Add(this);
            }

            await App.Repository.Customers.UpsertAsync(Model);
        }


        internal async Task<bool> DoLoginAsync()
        {
            var user = await App.UnitOfWork.UserRepository.FindByEmailAndPassword(User.Email, User.Password);

            LoggedUser = user;
            ShowError = user == null;
            return !ShowError;
        }

        public void DoLogout()
        {
            LoggedUser = null;
        }

        internal async Task<bool> RegisterAsync()
        {
            bool err = true;    

            var user = await App.UnitOfWork.UserRepository.FindByEmail(User.Email);
            if (user == null)
            {
                user = await App.UnitOfWork.UserRepository.CreateAsync(User);
                LoggedUser = user;
                err = false;
            }

            ShowError = err;

            return !ShowError;
        }

        private bool _showError;

        public bool ShowError
        {
            get { return _showError; }
            set
            {
                _showError = value;
                OnPropertyChanged();
            }
        }

    }
}
