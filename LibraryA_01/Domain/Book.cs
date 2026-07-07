using System.ComponentModel.DataAnnotations;

namespace LibraryA_01.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int Year { get; set; }
        public int NumberOfPages { get; set; }
        public bool Available { get; set; }
        
        private Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            ISBN = string.Empty;
            Available = false;
        }
        public Book(string title, string author, string isbn, int year, int numberOfPages, bool available)
        {
            var isValid = validate(title, author, isbn);
            Id = Guid.NewGuid();
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            NumberOfPages = numberOfPages;
            Available = available;
        }
        public void Update(string title, string author, string isbn, int year, int numberOfPages, bool available)
        {
            var isValid = validate(title, author, isbn);
            Title = title;
            Author = author;
            ISBN = isbn;
            Year = year;
            NumberOfPages = numberOfPages;
            Available = available;
        }
        private bool validate(string title, string author, string isbn)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be null or empty.", nameof(author));
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be null or empty.", nameof(isbn));
            }
            return true;
        }
    }
}
