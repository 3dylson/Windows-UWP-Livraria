using LivrariaVirtualApp.UWP.ViewModels;
using LivrariaVirtualApp.UWP.Views.Books;
using LivrariaVirtualApp.UWP.Views.Cart;
using LivrariaVirtualApp.UWP.Views.Categories;
using LivrariaVirtualApp.UWP.Views.Orders;
using LivrariaVirtualApp.UWP.Views.Users;
using LivrariaVirtualApp.UWP.Views.Wishlist;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace LivrariaVirtualApp.UWP
{

    public sealed partial class MainPage : Page
    {
        public UserViewModel UserViewModel { get; set; }
        public MainViewModel ViewModel { get; set; }

        public MainPage()
        {
            InitializeComponent();

            UserViewModel = App.UserViewModel;
            ViewModel = new MainViewModel();
            
        }
            

        public Frame AppFrame => frame;

        private void NavigationView_ItemInvoked(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs args)
        {
            var selectedItem = args.InvokedItem as NavigationViewItem;
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
                    case "displaycategories":
                        AppFrame.Navigate(typeof(DisplayCategoriesPage));
                        break;
                    case "userlist":
                        AppFrame.Navigate(typeof(UserListPage));
                        break;
                    case "orderlist":
                        AppFrame.Navigate(typeof(OrderListPage));
                        break;
                    case "orders":
                        AppFrame.Navigate(typeof(OrdersPage));
                        break;



                }
            }
        }

        /// <summary>
        /// Ensures the nav menu reflects reality when navigation is triggered outside of
        /// the nav menu buttons.
        /// </summary>
        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(CategoriesPage))
                {
                    navBar.SelectedItem = categories;
                }
                else if (e.SourcePageType == typeof(ManageBooksPage))
                {
                    navBar.SelectedItem = books;
                }
                else if (e.SourcePageType == typeof(AdminDashBoard))
                {
                    navBar.SelectedItem = admin;
                }
                else if (e.SourcePageType == typeof(BooksPage))
                {
                    navBar.SelectedItem = displaybooks;
                }
                else if (e.SourcePageType == typeof(DisplayCategoriesPage))
                {
                    navBar.SelectedItem = displaycategories;
                }
                else if (e.SourcePageType == typeof(UserListPage))
                {
                    navBar.SelectedItem = userlist;
                }
                else if (e.SourcePageType == typeof(OrderListPage))
                {
                    navBar.SelectedItem = orderlist;
                }
                else if (e.SourcePageType == typeof(OrdersPage))
                {
                    navBar.SelectedItem = orders;                       ;
                }
            }
        }



        /// <summary>
        /// Navigates the frame to the previous page.
        /// </summary>
        private void NavigationView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(typeof(BooksPage));
        }

        private void BtnCart(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(typeof(CartPage));
        }

        private void btnWishlist(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(typeof(WishlistPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme = ElementTheme.Light;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var validUser = App.UserViewModel.LoggedUser;
            ViewModel.Theme();
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
