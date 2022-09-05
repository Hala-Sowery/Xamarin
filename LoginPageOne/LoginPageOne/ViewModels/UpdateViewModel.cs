using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LoginPageOne.ViewModels
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        public Command UpdateCommand { get; set; }
        Book swippedItem = new Book();
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                UpdateCommand?.ChangeCanExecute();
            }
        }

        public UpdateViewModel(Book book)
        {
            nameEntry = book.BookName;
            authorEntry = book.AuthorName;
            swippedItem = book;
            UpdateCommand = new Command(async () => await UpdateAsync(), () => !IsBusy);

        }

        async Task UpdateAsync()
        {
            swippedItem.BookName = nameEntry;
            swippedItem.AuthorName = authorEntry;
            await App.Database.UpdateBookAsync(swippedItem);
            await Application.Current.MainPage.Navigation.PopAsync();
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