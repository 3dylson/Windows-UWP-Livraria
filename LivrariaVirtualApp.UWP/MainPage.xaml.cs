using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.ViewModels;
using LivrariaVirtualApp.UWP.Views.Books;
using LivrariaVirtualApp.UWP.Views.Categories;
using LivrariaVirtualApp.UWP.Views.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace LivrariaVirtualApp.UWP
{

    public sealed partial class MainPage : Page
    {
        public UserViewModel UserViewModel { get; set; }
        public BookViewModel BookViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            UserViewModel = App.UserViewModel;
            CategoryViewModel = App.CategoryViewModel;
            BookViewModel = App.BookViewModel;
        }

        public Frame AppFrame => frame;

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var selectedItem = args.InvokedItemContainer as NavigationViewItem;
            if (selectedItem != null)
            {
                switch (selectedItem.Tag)
                {
                    case "categories":
                        AppFrame.Navigate(typeof(CategoriesPage));
                        break;
                    case "books":
                        AppFrame.Navigate(typeof(BooksPage));
                        break;
                       
                }
            }
        }

        private async void btnRegister_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dlg = new RegisterDialog();
            var res = await dlg.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsAdmin)
                {
                    AppFrame.Navigate(typeof(AdminPage));
                }
            }
        }

        private void btnLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UserViewModel.DoLogout();
            AppFrame.BackStack.Clear();
            AppFrame.Content = null;
        }

        private async void btnLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dlg = new LoginDialog();
            var res = await dlg.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsAdmin)
                {
                    AppFrame.Navigate(typeof(AdminPage));
                }
            }
        }
    }
}
