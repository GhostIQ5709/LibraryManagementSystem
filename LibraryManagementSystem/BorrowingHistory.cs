using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryManagementSystem
{
    public class BorrowingHistory
    {
        public List<Borrowing> borrowings;

        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime ReturnedOn { get; set; }
        public BorrowingHistory()
        {
            borrowings = new List<Borrowing>();
        }

        public void RecordBorrowing(User user, Book book)
        {
            var borrowing = new Borrowing(user, book, DateTime.Now);
            borrowings.Add(borrowing);
        }

        public void RecordReturning(User user, Book book)
        {
            var borrowing = borrowings.Find(b => b.User == user && b.Book == book && b.ReturnDate == null);
            if (borrowing != null)
            {
                borrowing.ReturnDate = DateTime.Now;
            }
        }

        public List<Borrowing> GetBorrowedBooks()
        {
            return borrowings.FindAll(b => b.ReturnDate == null);
        }
    }

    public class Borrowing
    {
        public User User { get; }
        public Book Book { get; }
        public DateTime BorrowDate { get; }
        public DateTime? ReturnDate { get; set; }

        // Parameterless constructor for serialization
        public Borrowing() { }

        public Borrowing(User user, Book book, DateTime borrowDate)
        {
            User = user;
            Book = book;
            BorrowDate = borrowDate;
            ReturnDate = null;
        }
    }

    public class Returning
    {
        public User User { get; set; }
        public Book Book { get; set; }
        public DateTime ReturnedAt { get; set; }
    }
}