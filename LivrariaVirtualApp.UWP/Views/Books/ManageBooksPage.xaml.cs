using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Books
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageBooksPage : Page
    {
        public BookViewModel BookViewModel { get; set; }

        public ManageBooksPage()
        {
            this.InitializeComponent();
            BookViewModel = new BookViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BookViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BookFormPage));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement fe && fe.DataContext is Book m)
            {
                BookViewModel.Book = m;
                this.Frame.Navigate(typeof(BookFormPage), BookViewModel);
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Eliminar livro permanentemente?",
                Content = "Pretende mesmo eliminar?",
                PrimaryButtonText = "Eliminar",
                CloseButtonText = "Cancelar"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                if (sender is FrameworkElement fe && fe.DataContext is Book m)
                {
                    BookViewModel.DeleteBookAsync(m);
                }
            }
        }
    }
}