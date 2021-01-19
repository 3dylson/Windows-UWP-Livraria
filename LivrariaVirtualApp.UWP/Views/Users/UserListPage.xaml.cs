using LivrariaVirtualApp.UWP.ViewModels;
using LivrariaVirtualApp.UWP.Views.Orders;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LivrariaVirtualApp.UWP.Views.Users
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserListPage : Page
    {
        public UserListPage()
        {
            this.InitializeComponent();
            //Window.Current.SizeChanged += CurrentWindow_SizeChanged;
        }

        /// <summary>
        /// Gets the app-wide ViewModel instance.
        /// </summary>
        public MainViewModel ViewModel => App.ViewModel;

        /// <summary>
        /// Adjust the command bar label positions depending on the window width.
        /// </summary>
        //private void CurrentWindow_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        //{
        //    if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile" &&
        //        e.Size.Width >= (double)App.Current.Resources["MediumWindowSnapPoint"])
        //    {
        //        mainCommandBar.DefaultLabelPosition = CommandBarDefaultLabelPosition.Right;
        //    }
        //    else
        //    {
        //        mainCommandBar.DefaultLabelPosition = CommandBarDefaultLabelPosition.Bottom;
        //    }
        //}

        private void CustomerSearchBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (CustomerSearchBox != null)
            {
                CustomerSearchBox.AutoSuggestBox.QuerySubmitted += CustomerSearchBox_QuerySubmitted;
                CustomerSearchBox.AutoSuggestBox.TextChanged += CustomerSearchBox_TextChanged;
                CustomerSearchBox.AutoSuggestBox.PlaceholderText = "Search users...";
            }
        }

        /// <summary>
        /// Updates the search box items source when the user changes the search text.
        /// </summary>
        private async void CustomerSearchBox_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
            // We only want to get results when it was a user typing,
            // otherwise we assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // If no search query is entered, refresh the complete list.
                if (String.IsNullOrEmpty(sender.Text))
                {
                    await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                        await ViewModel.GetUserListAsync());
                    sender.ItemsSource = null;
                }
                else
                {
                    string[] parameters = sender.Text.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    sender.ItemsSource = ViewModel.Users
                        .Where(user => parameters.Any(parameter =>
                            user.Address.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            user.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            user.Email.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .OrderByDescending(user => parameters.Count(parameter =>
                            user.Address.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            user.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            user.Email.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .Select(user => $"{user.Name}");
                }
            }
        }

        /// <summary>
        /// Filters the user list based on the search text.
        /// </summary>
        private async void CustomerSearchBox_QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (String.IsNullOrEmpty(args.QueryText))
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                    await ViewModel.GetUserListAsync());
            }
            else
            {
                string[] parameters = sender.Text.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var matches = ViewModel.Users.Where(user => parameters
                    .Any(parameter =>
                        user.Address.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        user.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        user.Email.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(user => parameters.Count(parameter =>
                        user.Address.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        user.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        user.Email.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    ViewModel.Users.Clear();
                    foreach (var match in matches)
                    {
                        ViewModel.Users.Add(match);
                    }
                });
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

        /// <summary>
        /// Menu flyout click control for selecting a customer and displaying details.
        /// </summary>
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedUser != null)
            {
                Frame.Navigate(typeof(UserDetailPage), ViewModel.SelectedUser.User.Id,
                    new DrillInNavigationTransitionInfo());
            }
        }

        /// <summary>
        /// Navigates to a blank customer details page for the user to fill in.
        /// </summary>
        private void CreateCustomer_Click(object sender, RoutedEventArgs e) =>
            Frame.Navigate(typeof(UserDetailPage), null, new DrillInNavigationTransitionInfo());

        /// <summary>
        /// Reverts all changes to the row if the row has changes but a cell is not currently in edit mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape &&
                ViewModel.SelectedUser != null &&
                ViewModel.SelectedUser.IsModified &&
                !ViewModel.SelectedUser.IsInEdit)
            {
                (sender as DataGrid).CancelEdit(DataGridEditingUnit.Row);
            }
        }

        /// <summary>
        /// Selects the tapped customer. 
        /// </summary>
        private void DataGrid_RightTapped(object sender, RightTappedRoutedEventArgs e) =>
            ViewModel.SelectedUser = (e.OriginalSource as FrameworkElement).DataContext as UserViewModel;

        /// <summary>
        /// Opens the order detail page for the user to create an order for the selected customer.
        /// </summary>
        private void AddOrder_Click(object sender, RoutedEventArgs e) =>
            Frame.Navigate(typeof(OrderDetailPage), ViewModel.SelectedUser.User.Id);

        /// <summary>
        /// Sorts the data in the DataGrid.
        /// </summary>
        private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e) =>
            (sender as DataGrid).Sort(e.Column, ViewModel.Users.Sort);



    }
}
