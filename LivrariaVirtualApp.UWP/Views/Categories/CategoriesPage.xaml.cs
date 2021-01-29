using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Categories
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoriesPage : Page
    {
        public CategoryViewModel CategoryViewModel { get; set; }

        public CategoriesPage()
        {
            InitializeComponent();
            CategoryViewModel = new CategoryViewModel();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CategoryViewModel.UpsertAsync() != null)
            {
                Frame.GoBack();
            }
            else
            {
                FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                CategoryViewModel = e.Parameter as CategoryViewModel;
                base.OnNavigatedTo(e);
            }
        }
    }
}