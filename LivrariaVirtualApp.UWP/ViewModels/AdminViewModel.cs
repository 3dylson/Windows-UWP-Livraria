using LivrariaVirtualApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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
