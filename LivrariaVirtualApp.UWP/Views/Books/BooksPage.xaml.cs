﻿using System;
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

namespace LivrariaVirtualApp.UWP.Views.Books
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        public BookViewModel BookViewModel { }

        public BooksPage()
        {
            InitializeComponent();

        }





        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(ProductAddToFormPage), ProductViewModel);
        //}

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender is FrameworkElement fe && fe.DataContext is ShoppingListProduct p)
        //    {
        //        ProductViewModel.DeleteAsync(p);
        //    }
        //}
    }
}
