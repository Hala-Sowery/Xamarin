using System;
using System.IO;
using LoginPageOne.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginPageOne
{
    public partial class App : Application
    {
        private static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "booksLibrary.db3"));
                }

                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            var database = Database;

            MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new BooksListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

