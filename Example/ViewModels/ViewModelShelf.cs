using Example.Models;
using Example.Services;
using Example.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Example.ViewModels
{
    /// <summary>
    /// Class for display books and curd operations.
    /// </summary>
    public class ViewModelShelf : BaseViewModel
    {
        private ViewModelBook? _currentBook;
        private readonly ObservableCollection<ViewModelBook> _books = new(BookService.Books.Select(b => new ViewModelBook(b)));

        /// <summary>
        /// Collection of books to display.
        /// </summary>
        public IEnumerable<ViewModelBook> Books => _books;

        /// <summary>
        /// Keep track of the sected item in the colelction <see cref="Books"/>.
        /// </summary>
        public ViewModelBook? CurrentBook
        {
            get => _currentBook;
            set
            {
                _currentBook = value;
                OnPropertyChange();
                OnPropertyChange(nameof(IsSelected));
            }
        }

        /// <summary>
        /// <c>True</c> if <see cref="CurrentBook"/> is not null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public bool IsSelected => CurrentBook is not null;

        /// <summary>
        /// Initialize a new istance of the class <see cref="ViewModelShelf"/> and registers the <see cref="CommandBinding"/>.
        /// </summary>
        public ViewModelShelf()
        {
            //Register action on default framework commands (!Not ideal becouse it bounds the a View type but fine for an example.)
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), new CommandBinding(ApplicationCommands.New, New));
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), new CommandBinding(ApplicationCommands.Delete, Delete, CanDelete));
        }

        /// <summary>
        /// Set a freshly created <see cref="ViewModelBook"/> on the <see cref="CurrentBook"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="eventArgs"></param>
        public void New(object target, ExecutedRoutedEventArgs eventArgs)
        {
            var book = new ViewModelBook()
            {
                Author = "Name Surname",
                Title = "Titile",
                ISBN = "",
                Pages = "100",
                PublisherEmail = "mail@example.com",
            };
            _books.Add(book);
            CurrentBook = book;
        }
       
        /// <summary>
        /// Remove the <see cref="CurrentBook"/> from <see cref="Books"/>.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="eventArgs"></param>
        public void Delete(object target, ExecutedRoutedEventArgs eventArgs)
        {
            if (CurrentBook is null) return;

            _books.Remove(CurrentBook);
        }

        /// <summary>
        /// <c>True</c> if <see cref="CurrentBook"/> is not null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public void CanDelete(object sender, CanExecuteRoutedEventArgs eventArgs) => eventArgs.CanExecute = IsSelected;
    }
}
