using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginPageOne.ViewModels
{
    public class AddViewModel : INotifyPropertyChanged
    {
        public Command AddCommand { get; set; }
        Book swippedItem = new Book();

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                AddCommand?.ChangeCanExecute();
            }
        }

        public AddViewModel()
        {
            AddCommand = new Command(async () => await AddAsync(), () => !IsBusy);

        }

        async Task AddAsync()
        {
            Book newBook = new Book();
            if (!string.IsNullOrWhiteSpace(authorEntry) && !string.IsNullOrWhiteSpace(nameEntry))
            {
                newBook.BookName = nameEntry;
                newBook.AuthorName = authorEntry;
            }
            await App.Database.SaveBookAsync(newBook);
            await Application.Current.MainPage.Navigation.PopAsync();
            authorEntry = "";
            nameEntry = "";
        }

        string name = string.Empty;
        public string nameEntry
        {
            get => name;

            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged(nameof(nameEntry));
            }
        }

        string author = string.Empty;
        public string authorEntry
        {
            get => author;

            set
            {
                if (author == value)
                    return;
                author = value;
                OnPropertyChanged(nameof(authorEntry));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


