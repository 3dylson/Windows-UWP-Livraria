using LivrariaVirtualApp.UWP.ViewModels;
using LivrariaVirtualApp.UWP.Views.Books;
using LivrariaVirtualApp.UWP.Views.Categories;
using LivrariaVirtualApp.UWP.Views.Users;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace LivrariaVirtualApp.UWP
{

    public sealed partial class MainPage : Page
    {
        public UserViewModel UserViewModel { get; set; }
        public BookViewModel BookViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
        public AdminViewModel AdminViewModel { get; set; }
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            UserViewModel = App.UserViewModel;
            CategoryViewModel = App.CategoryViewModel;
            BookViewModel = App.BookViewModel;
            ViewModel = App.ViewModel;
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
                        AppFrame.Navigate(typeof(ManageBooksPage));
                        break;
                    case "admin":
                        AppFrame.Navigate(typeof(AdminDashBoard));
                        break;
                    case "displaybooks":
                        AppFrame.Navigate(typeof(BooksPage));
                        break;
                    //case "displaycategories":
                    //    AppFrame.Navigate(typeof(DisplayCategoriesPage));
                    //    break;
                    case "userlist":
                        AppFrame.Navigate(typeof(UserListPage));
                        break;
                    //case "orderlist":
                    //    AppFrame.Navigate(typeof(OrderListPage));
                    //    break;



                }
            }
        }

        private async void btnRegister_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dlg = new RegisterDialog();
            var res = await dlg.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                if (App.UserViewModel.IsLogged)
                {
                    AppFrame.Navigate(typeof(BooksPage));
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
                    AppFrame.Navigate(typeof(AdminDashBoard));
                }
            }
        }
    }
}
