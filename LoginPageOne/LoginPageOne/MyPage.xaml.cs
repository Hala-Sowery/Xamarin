using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LoginPageOne
{
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GeBooksAsync();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SaveBookAsync(new Book
                {
                    Name = nameEntry.Text,
                });

                nameEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GeBooksAsync();
            }
        }

        Book lastSelection;
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Book;

            nameEntry.Text = lastSelection.Name;
        }

        // Update
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            if (lastSelection != null)
            {
                lastSelection.Name = nameEntry.Text;

                await App.Database.UpdateBookAsync(lastSelection);

                collectionView.ItemsSource = await App.Database.GeBooksAsync();
            }
        }

        // Delete
        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            if (lastSelection != null)
            {
                await App.Database.DeleteBookAsync(lastSelection);

                collectionView.ItemsSource = await App.Database.GeBooksAsync();

                nameEntry.Text = "";
            }
        }
    }
}

