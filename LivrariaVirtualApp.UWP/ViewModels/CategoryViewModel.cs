using LivrariaVirtualApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaVirtualApp.UWP.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Category> BooksCategories { get; set; }

        public CategoryViewModel()
        {
            Category = new Category();
            BooksCategories = new ObservableCollection<Category>();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Category Category { get; set; }

        private Category _category;





    }
}