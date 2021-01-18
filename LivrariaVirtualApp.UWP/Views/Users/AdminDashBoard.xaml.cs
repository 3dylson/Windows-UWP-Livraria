using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using LivrariaVirtualApp.UWP.local_Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Users
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminDashBoard : Page
    {

        public AdminViewModel AdminViewModel  { get; }
        public UserViewModel UserViewModel { get; set; }
        public AdminDashBoard()
        {
            this.InitializeComponent();
            AdminViewModel = new AdminViewModel();
            UserViewModel = App.UserViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AdminViewModel.LoadAllUsersAsync();
            //base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            AdminViewModel.Unload();
        }

        //private void OnItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (e.ClickedItem is Control control)
        //    {
        //        DashboardViewModel.ItemSelected(control.Tag as String);
        //    }
        //}
    }
}
