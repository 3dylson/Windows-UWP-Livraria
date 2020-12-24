using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.ViewModels;
using System;
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
            this.InitializeComponent();
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

        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            birth_date.Text = "Select a date from the calendar";
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            birth_date.Text = "Enter a date or click the calendar";
        }

        // If the text is a valid date show a message.
        // If the text is not a valid date, thow an exception.
    //    private void DatePicker_DateValidationError(object sender,
    //                    DatePickerDateValidationErrorEventArgs e)
    //    {
    //        DateTime newDate;
    //        DatePicker datePickerObj = sender as DatePicker;

    //        if (DateTime.TryParse(e.Text, out newDate))
    //        {
                
    //                MessageBox.Show(String.Format("The date, {0}, cannot be selected.",
    //                                               e.Text));
                
    //        }
    //        else
    //        {
    //            e.ThrowException = true;
    //        }
    //    }
    }
}
