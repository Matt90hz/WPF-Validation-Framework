using Example.Models;
using System;
using System.Collections.Generic;

namespace Example.Services
{
    /// <summary>
    /// Fake repository to show some functionality in the example
    /// </summary>
    public static class BookService
    {
        /// <summary>
        /// Seeded list of <see cref="Book"/>.
        /// </summary>
        public static IEnumerable<Book> Books { get; } = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                ISBN = "0-306-40615-2",
                Title = "The art of thumbs",
                Author = "John Magnum",
                Pages = 1500,
                Written = new DateTime(1822,9,12),
                Published = new DateTime(1823,6,16),
                PublisherEmail = "penguin@bookforeveryone.com"
            },
            new Book()
            {
                Id = 2,
                ISBN = "0-306-40615-2",
                Title = "Beyond the bench",
                Author = "Annalise Rogers",
                Pages = 72,
                Written = new DateTime(2002,3,24),
                Published = new DateTime(2006,12,5),
                PublisherEmail = "penguin@bookforeveryone.com"
            },
            new Book()
            {
                Id = 3,
                ISBN = "0-306-40615-2",
                Title = "Yellow rooster",
                Author = "Alfonso Rivera",
                Pages = 700,
                Written = new DateTime(1978,1,13),
                Published = new DateTime(1980,7,15),
                PublisherEmail = "penguin@bookforeveryone.com"
            }
        };

    }
}
