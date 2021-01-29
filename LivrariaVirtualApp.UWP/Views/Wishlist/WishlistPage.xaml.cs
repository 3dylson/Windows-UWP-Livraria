using LivrariaVirtualApp.UWP.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Wishlist
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WishlistPage : Page
    {
        public WishlistViewModel WishlistViewModel { get; set; }

        public WishlistPage()
        {
            this.InitializeComponent();
            WishlistViewModel = new WishlistViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            WishlistViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);

        }

        private void StackPanel_Tapped(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
