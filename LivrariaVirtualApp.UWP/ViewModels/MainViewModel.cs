using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel() => Task.Run(GetUserListAsync);

        public ObservableCollection<UserViewModel> Users { get; }
            = new ObservableCollection<UserViewModel>();

        private UserViewModel _selectedUser;

        public UserViewModel SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }


        /// <summary>
        /// Gets the complete list of users from the database.
        /// </summary>
        public async Task GetUserListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var customers = await App.UnitOfWork.UserRepository.FindAllAsync();
            if (customers == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Users.Clear();
                foreach (var c in customers)
                {
                    Users.Add(new UserViewModel(c));
                }
                IsLoading = false;
            });
        }

        /// <summary>
        /// Saves any modified customers and reloads the customer list from the database.
        /// </summary>
        public void Sync()
        {
            Task.Run(async () =>
            {
                IsLoading = true;
                foreach (var modifiedUser in Users
                    .Where(user => user.IsModified).Select(user => user.User))
                {
                    await App.UnitOfWork.UserRepository.UpsertAsync(modifiedUser);
                }

                await GetUserListAsync();
                IsLoading = false;
            });
        }


    }
}
