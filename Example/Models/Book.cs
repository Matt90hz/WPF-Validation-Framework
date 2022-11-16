using System;

namespace Example.Models
{
    /// <summary>
    /// Example of a model see <see cref="Base.BaseModel"/> for validation notification details.
    /// </summary>
    public class Book
    {
        public int Id { get; set; }

        public string ISBN { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public int Pages { get; set; }

        public DateTime Written { get; set; }

        public DateTime Published { get; set; }

        public string PublisherEmail { get; set; } = string.Empty;

    }
}
