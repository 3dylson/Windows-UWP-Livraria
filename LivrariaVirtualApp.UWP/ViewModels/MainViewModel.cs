using Microsoft.Toolkit.Uwp.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            Task.Run(GetUserListAsync);
            //Task.Run(GetBookListAsync);
            MyBackGround = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        public ObservableCollection<UserViewModel> Users { get; }
            = new ObservableCollection<UserViewModel>();

        public ObservableCollection<BookViewModel> Books { get; }
            = new ObservableCollection<BookViewModel>();

        private UserViewModel _selectedUser;

        public UserViewModel SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }

        private BookViewModel _selectedBook;

        public BookViewModel SelectedBook
        {
            get => _selectedBook;
            set => Set(ref _selectedBook, value);
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private Brush _myBackGround;

        public Brush MyBackGround
        {
            get
            {
                return _myBackGround;
            }
            set
            {
                _myBackGround = value;
                OnPropertyChanged();
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        protected new void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void Theme()
        {
            MyBackGround = new SolidColorBrush(Color.FromArgb(255, 0, 0, 255));
        }

        /// <summary>
        /// Gets the complete list of users from the database.
        /// </summary>
        public async Task GetUserListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var customers = await App.UnitOfWork.UserRepository.FindAllAsync();
            if (customers == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Users.Clear();
                foreach (var c in customers)
                {
                    Users.Add(new UserViewModel(c));
                }
                IsLoading = false;
            });
        }

        /// <summary>
        /// Saves any modified customers and reloads the customer list from the database.
        /// </summary>
        public void Sync()
        {
            Task.Run(async () =>
            {
                IsLoading = true;
                foreach (var modifiedUser in Users
                    .Where(user => user.IsModified).Select(user => user.User))
                {
                    await App.UnitOfWork.UserRepository.UpsertAsync(modifiedUser);
                }

                await GetUserListAsync();
                IsLoading = false;
            });
        }
    }
}