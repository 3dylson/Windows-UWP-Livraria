using LivrariaVirtualApp.Domain.Models;
using System.Collections.Generic;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class AdminViewModel : BindableBase
    {
        private List<User> _users;

        public List<User> Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        public async void LoadAllUsersAsync()
        {
            Users = await App.UnitOfWork.UserRepository.FindAllAsync();
        }

        public void Unload()
        {
            Users = null;
        }

        //public void ItemSelected(string item)
        //{
        //    switch (item)
        //    {
        //        case "Users":
        //            AppFrame.Navigate(typeof(UsersPage));
        //            break;
        //    }
        //}
    }
}