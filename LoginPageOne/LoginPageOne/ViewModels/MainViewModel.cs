using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginPageOne.Views;
using Xamarin.Forms;

namespace LoginPageOne
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Command LoginCommand { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                LoginCommand?.ChangeCanExecute();

            }
        }

        public MainViewModel()
        {

            LoginCommand = new Command(async () => await LoginAsync(), () => !IsBusy);

        }
        private async Task LoginAsync()
        {
            try
            {

                IsBusy = true;

                await Task.Delay(2000);
                if (CheckEmpty())
                {
                    if (name == "admin")
                    {
                        this.LoginCommand = new Command(async () =>
                        {

                            await Application.Current.MainPage.Navigation.PushAsync(new BooksListPage());
                        });
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Entries can not be empty", "Ok");

                }

            }
            finally
            {
                IsBusy = false;
            }
        }


        private bool CheckEmpty()
        {

            if ((string.IsNullOrEmpty(Name)) || (string.IsNullOrEmpty(Pass)))
            {
                return false;

            }
            return true;
        }

        string name = string.Empty;
        public string Name
        {
            get => name;

            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        string pass = string.Empty;
        public string Pass
        {
            get => pass;

            set
            {
                if (pass == value)
                    return;
                pass = value;
                OnPropertyChanged(nameof(Pass));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

