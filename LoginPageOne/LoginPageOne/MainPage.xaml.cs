using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPageOne.Views;
using Xamarin.Forms;

namespace LoginPageOne
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new BooksListPage());
        }

        //void OnImageNameTapped(object sender, EventArgs args)
        //{
        //    try
        //    {
        //        DisplayAlert("Facebook", "You clicked on facebook image", "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

