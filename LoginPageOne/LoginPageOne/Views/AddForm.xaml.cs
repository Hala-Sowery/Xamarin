using System;
using System.Collections.Generic;
using LoginPageOne.ViewModels;
using Xamarin.Forms;

namespace LoginPageOne
{
    public partial class AddForm : ContentPage
    {
        public AddForm()
        {
            InitializeComponent();
            BindingContext = new AddViewModel();
        }
    }
}

