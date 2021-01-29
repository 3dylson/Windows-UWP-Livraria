using LivrariaVirtualApp.Domain.Models;
using LivrariaVirtualApp.UWP.Utils;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class WishlistViewModel : BindableBase
    {
        public Wishlist Wishlist { get; set; }

        public ObservableCollection<Wishlist> Wishlists { get; set; }

        public Color WishlistColor { get; set; }

        public WishlistViewModel()
        {
            Wishlist = new Wishlist();
            Wishlists = new ObservableCollection<Wishlist>();
            WishlistColor = Color.FromArgb(0, 255, 255, 255);
        }

        public async void LoadAllAsync()
        {
            var userId = App.UserViewModel.LoggedUser.Id;
            var list = await App.UnitOfWork.WishlistRepository
                .FindAllByUserIdAsync(userId);

            Wishlists.Clear();
            foreach (var l in list)
            {
                Wishlists.Add(l);
            }
        }

        internal async Task<Wishlist> UpsertAsync()
        {
            Wishlist.User_id = App.UserViewModel.LoggedUser.Id;

            if (Wishlist.Id == 0)
            {
            }
            Wishlist.Color = WishlistColor.ToString();

            var newWishlist = await App.UnitOfWork.WishlistRepository
                .UpsertAsync(Wishlist);

            return newWishlist;
        }

        //internal async Task<bool> DeleteWishlistAsync(Wishlist model)
        //{
        //    bool res = false;
        //    if (!model.Any())
        //    {
        //        await App.UnitOfWork.WishlistRepository.DeleteAsync(model);
        //        res = true;
        //    }

        //    return res;
        //}

        internal void RefreshItem(Wishlist model)
        {
            if (model != null)
            {
                Wishlist = model;
                WishlistColor = ColorConverter.GetColorFromCode(
                    Wishlist.Color);
            }
        }
    }
}