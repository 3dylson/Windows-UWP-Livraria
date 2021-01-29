using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Books
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BooksPage : Page
    {
        public BookViewModel BookViewModel { get; set; }

        public BooksPage()
        {
            InitializeComponent();
            BookViewModel = new BookViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            BookViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private void ContentGridView_SelectionChanged(object sender, RoutedEventArgs e)
        {
        }

        private void ContentGridView_ItemClick(object sender, RoutedEventArgs e)
        {
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Fav_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BookSearchBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Controls.CollapsibleSearchBox searchBox)
            {
                searchBox.AutoSuggestBox.PlaceholderText = "Search books...";
            }
        }

        /// <summary>
        /// Workaround to support earlier versions of Windows.
        /// </summary>
        private void CommandBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Bottom;
            }
            else
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Right;
            }
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