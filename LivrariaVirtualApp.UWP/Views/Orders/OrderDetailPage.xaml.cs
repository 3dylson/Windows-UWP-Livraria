using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
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

namespace LivrariaVirtualApp.UWP.Views.Orders
{
    /// <summary>
    /// Displays and edits an order.
    /// </summary>
    public sealed partial class OrderDetailPage : Page, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes the page.
        /// </summary>
        public OrderDetailPage() => InitializeComponent();

        /// <summary>
        /// Stores the view model. 
        /// </summary>
        private OrderViewModel _viewModel;

        /// <summary>
        /// We use this object to bind the UI to our data.
        /// </summary>
        public OrderViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel != value)
                {
                    _viewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Loads the specified order, a cached order, or creates a new order.
        /// </summary>
        /// <param name="e">Info about the event.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var id = (int)e.Parameter;
            var user = App.ViewModel.Users.Where(cust => cust.User.Id == id).FirstOrDefault();

            if (user != null)
            {
                // Order is a new order
                ViewModel = new OrderViewModel(new Order(user.User));
            }
            else
            {
                // Order is an existing order.
                var order = await App.UnitOfWork.OrderRepository.FindByIdAsync(id);
                ViewModel = new OrderViewModel(order);
            }

            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Check whether there are unsaved changes and warn the user.
        /// </summary>
        protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (ViewModel.IsModified)
            {
                var saveDialog = new SaveChangesDialog()
                {
                    Title = $"Save changes to Invoice # {ViewModel.Id.ToString()}?",
                    Message = $"Invoice # {ViewModel.Id.ToString()} " +
                        "has unsaved changes that will be lost. Do you want to save your changes?"
                };

                await saveDialog.ShowAsync();
                SaveChangesDialogResult result = saveDialog.Result;

                switch (result)
                {
                    case SaveChangesDialogResult.Save:
                        await ViewModel.SaveOrderAsync();
                        break;
                    case SaveChangesDialogResult.DontSave:
                        break;
                    case SaveChangesDialogResult.Cancel:
                        if (e.NavigationMode == NavigationMode.Back)
                        {
                            Frame.GoForward();
                        }
                        else
                        {
                            Frame.GoBack();
                        }
                        e.Cancel = true;

                        // This flag gets cleared on navigation, so restore it. 
                        ViewModel.IsModified = true;
                        break;
                }
            }

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Creates an email to the current customer.
        /// </summary>
        private async void emailButton_Click(object sender, RoutedEventArgs e)
        {
            var emailMessage = new EmailMessage
            {
                Body = $"Dear {ViewModel.UserOrdering},",
                Subject = "A message from Livraria about order " +
                    $"#{ViewModel.Id} placed on {ViewModel.Date_created.ToString("MM/dd/yyyy")} "
            };

            if (!string.IsNullOrEmpty(ViewModel.User.Email))
            {
                var emailRecipient = new EmailRecipient(ViewModel.User.Email);
                emailMessage.To.Add(emailRecipient);
            }

            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }

        /// <summary>
        /// A workaround for earlier versions of Windows 10.
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

        /// <summary>
        /// Reloads the order.
        /// </summary>
        private async void RefreshButton_Click(object sender, RoutedEventArgs e) =>
            ViewModel = await OrderViewModel.CreateFromid(ViewModel.Id);

        /// <summary>
        /// Reverts the page.
        /// </summary>
        private async void RevertButton_Click(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveChangesDialog()
            {
                Title = $"Save changes to Invoice # {ViewModel.Id.ToString()}?",
                Message = $"Invoice # {ViewModel.Id.ToString()} " +
                    "has unsaved changes that will be lost. Do you want to save your changes?"
            };
            await saveDialog.ShowAsync();
            SaveChangesDialogResult result = saveDialog.Result;

            switch (result)
            {
                case SaveChangesDialogResult.Save:
                    await ViewModel.SaveOrderAsync();
                    ViewModel = await OrderViewModel.CreateFromid(ViewModel.Id);
                    break;
                case SaveChangesDialogResult.DontSave:
                    ViewModel = await OrderViewModel.CreateFromid(ViewModel.Id);
                    break;
                case SaveChangesDialogResult.Cancel:
                    break;
            }
        }

        /// <summary>
        /// Saves the current order.
        /// </summary>
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ViewModel.SaveOrderAsync();
            }
            catch (OrderSavingException ex)
            {
                var dialog = new ContentDialog()
                {
                    Title = "Unable to save",
                    Content = $"There was an error saving your order:\n{ex.Message}",
                    PrimaryButtonText = "OK"
                };

                await dialog.ShowAsync();
            }
        }

        /// <summary>
        /// Queries for products.
        /// </summary>
        private void ProductSearchBox_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ViewModel.UpdateProductSuggestions(sender.Text);
            }
        }

        /// <summary>
        /// Notifies the page that a new item was chosen.
        /// </summary>
        private void ProductSearchBox_SuggestionChosen(AutoSuggestBox sender,
            AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                var selectedProduct = args.SelectedItem as Book;
                ViewModel.NewCart.Book = selectedProduct;
            }
        }

        /// <summary>
        /// Adds the new line item to the list of line items.
        /// </summary>
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Carts.Add(ViewModel.NewCart.Cart);
            ClearCandidateProduct();
        }

        /// <summary>
        /// Clears the new line item without adding it to the list of line items.
        /// </summary>
        private void CancelProductButton_Click(object sender, RoutedEventArgs e)
        {
            ClearCandidateProduct();
        }

        /// <summary>
        /// Cleears the new line item entry area.
        /// </summary>
        private void ClearCandidateProduct()
        {
            ProductSearchBox.Text = string.Empty;
            ViewModel.NewCart = new CartViewModel();
        }

        /// <summary>
        /// Removes a line item from the order.
        /// </summary>
               
        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            //private void RemoveProduct_Click(object sender, RoutedEventArgs e) =>
            //    ViewModel.Carts.Remove((sender as FrameworkElement).DataContext as Cart);

        }

        /// <summary>
        /// Fired when a property value changes. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies listeners that a property value changed. 
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
