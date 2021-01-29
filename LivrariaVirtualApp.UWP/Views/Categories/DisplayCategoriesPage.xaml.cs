using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Categories
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DisplayCategoriesPage : Page
    {
        public CategoryViewModel CategoryViewModel { get; set; }

        public DisplayCategoriesPage()
        {
            this.InitializeComponent();
            CategoryViewModel = new CategoryViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await CategoryViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private void BooksFrom(object sender, RoutedEventArgs e)
        {
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
        }
    }
}