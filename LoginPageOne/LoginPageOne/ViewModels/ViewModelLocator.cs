using System;
namespace LoginPageOne
{
    public class ViewModelLocator
    {
        private static BookListViewModel _myViewModel = new BookListViewModel();
        public static BookListViewModel MainViewModel
        {
            get
            {
                return _myViewModel;
            }
        }
    }
}

