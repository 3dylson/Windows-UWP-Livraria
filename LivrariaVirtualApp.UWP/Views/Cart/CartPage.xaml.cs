using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Cart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CartPage : Page
    {
        public CartViewModel CartViewModel { get; set; }
        public BookViewModel BookViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public CartPage()
        {
            this.InitializeComponent();
            CartViewModel = new CartViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CartViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}