using System;
using System.Collections.Generic;
using LoginPageOne.ViewModels;
using Xamarin.Forms;

namespace LoginPageOne
{
    public partial class UpdateForm : ContentPage
    {
        public UpdateForm() { }
        public UpdateForm(Book book)
        {
            InitializeComponent();
            BindingContext = new UpdateViewModel(book);
        }
    }
}

