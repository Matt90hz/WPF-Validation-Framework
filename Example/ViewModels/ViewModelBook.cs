using Example.Models;
using Example.Services;
using Example.ViewModels.Base;
using System;
using System.Linq;

namespace Example.ViewModels
{
    /// <summary>
    /// Rappresentation of the <see cref="Book"/> type for display
    /// </summary>
    public class ViewModelBook : BaseViewModel
    {
        private int _id;
        private string _iSBN = string.Empty;
        private string _title = string.Empty;
        private string _author = string.Empty;
        private string _pages = "100";
        private DateTime _written = DateTime.Today;
        private DateTime _published = DateTime.Today.AddDays(100);
        private string _publisherEmail = string.Empty;

        public string ISBN
        {
            get => _iSBN;
            set
            {
                _iSBN = value;
                OnPropertyChange();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChange();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChange();
            }
        }

        public string Pages
        {
            get => _pages;
            set
            {
                _pages = value;
                OnPropertyChange();
            }
        }

        public DateTime Written
        {
            get => _written;
            set
            {
                _written = value;
                OnPropertyChange();
            }
        }

        public DateTime Published
        {
            get => _published;
            set
            {
                _published = value;
                OnPropertyChange();
            }
        }

        public string PublisherEmail
        {
            get => _publisherEmail;
            set
            {
                _publisherEmail = value;
                OnPropertyChange();
            }
        }

        /// <summary>
        /// Create a new instance of <see cref="ViewModelBook"/>.
        /// </summary>
        public ViewModelBook()
        {

        }

        /// <summary>
        /// Create a new instance of <see cref="ViewModelBook"/> and matches <see cref="Book"/> properties with <see cref="ViewModelBook"/> properties.
        /// </summary>
        /// <param name="book"></param>
        public ViewModelBook(Book book)
        {
            _id = book.Id;
            _iSBN = book.ISBN;
            _title = book.Title;
            _author = book.Author;
            _pages = book.Pages.ToString();
            _written = book.Written;
            _published = book.Published;
            _publisherEmail = book.PublisherEmail;
        }

        /// <summary>
        /// Pass back the values to the <see cref="Book"/> type.
        /// </summary>
        /// <returns>A <see cref="Book"/> instance with matching properties to this <see cref="ViewModelBook"/>.</returns>
        public Book EmitBook()
        {
            return new Book()
            {
                Id = _id == default ? BookService.Books.Max(b => b.Id) + 1 : _id,
                ISBN = this.ISBN,
                Title = this.Title,
                Author = this.Author,
                Pages = int.Parse(this.Pages),
                Written = this.Written,
                Published = this.Published,
                PublisherEmail = this.PublisherEmail
            };
        }
    }

}
