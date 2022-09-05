using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LoginPageOne
{
    public class BookListViewModel : INotifyPropertyChanged
    {
        public Book swippedItem { get; set; }
        public ObservableCollection<Book> collectionView { get; set; } = new ObservableCollection<Book>();
        public Command deleteCommand { get; set; }
        public Command OpenEditPage { get; set; }
        public Command OpenAddPage { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
                deleteCommand?.ChangeCanExecute();
            }
        }

        public BookListViewModel()
        {
            OpenAddPage = new Command(async () => await OpenAdd(), () => !IsBusy);
            OpenEditPage = new Command<Book>(async (book) => await OpenEdit(book));
            deleteCommand = new Command<Book>(async (book) => await DeleteBook(book));

        }

        async Task DeleteBook(Book book)
        {
            await App.Database.DeleteBookAsync(book);
            var data = await App.Database.GeBooksAsync();
            //collectionView = new ObservableCollection<Book>(data);
            collectionView.Clear();
            foreach (var k in data)
            {
                collectionView.Add(k);
            }
            //collectionView.ItemsSource = await App.Database.GeBooksAsync();
        }

        async Task OpenEdit(Book book)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UpdateForm(book));
        }
        async private Task OpenAdd()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddForm());
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


