using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LoginPageOne.Views
{
    public partial class BooksListPage : ContentPage
    {
        BookListViewModel vm = new BookListViewModel();
        public BooksListPage()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //collectionView.ItemsSource = await App.Database.GeBooksAsync();
            var data = await App.Database.GeBooksAsync();
            vm.collectionView = new ObservableCollection<Book>(data);
            collectionView.ItemsSource = vm.collectionView;
        }
    }
}

