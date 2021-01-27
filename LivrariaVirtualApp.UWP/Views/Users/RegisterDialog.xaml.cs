using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Users
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterDialog : ContentDialog
    {
        public UserViewModel UserViewModel { get; set; }

        public RegisterDialog()
        {
            InitializeComponent();
            UserViewModel = App.UserViewModel;
            UserViewModel.User = new User();
        }

        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var deferral = args.GetDeferral();
            args.Cancel = !await UserViewModel.RegisterAsync();
            deferral.Complete();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}