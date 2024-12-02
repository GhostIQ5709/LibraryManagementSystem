using System;

namespace LibraryManagementSystem
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsBorrowed { get; set; }
        public User BorrowedBy { get; set; }

        // Parameterless constructor for serialization
        public Book() { }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            IsBorrowed = false;
            BorrowedBy = null;
        }

        public override bool Equals(object obj)
        {
            var book = obj as Book;
            if (book == null)
            {
                return false;
            }
            return Title == book.Title && Author == book.Author && PublicationYear == book.PublicationYear;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (Title?.GetHashCode() ?? 0);
                hash = hash * 23 + (Author?.GetHashCode() ?? 0);
                hash = hash * 23 + PublicationYear.GetHashCode();
                return hash;
            }
        }
    }
}
