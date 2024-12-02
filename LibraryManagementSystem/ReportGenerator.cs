using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class ReportGenerator
    {
        private Library library;
        private BorrowingHistory borrowingHistory;

        public ReportGenerator(Library library, BorrowingHistory borrowingHistory)
        {
            this.library = library;
            this.borrowingHistory = borrowingHistory;
        }

        public void GeneratePopularBooksReport()
        {
            var popularBooks = borrowingHistory.GetBorrowedBooks()
                .GroupBy(b => b.Book)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key);

            Console.WriteLine("Popular Books Report:");
            Console.WriteLine("---------------------");
            foreach (var book in popularBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}, Borrowing Count: {borrowingHistory.GetBorrowedBooks().Count(b => b.Book == book)}");
            }
            Console.WriteLine();
        }

        public void GenerateActiveUsersReport()
        {
            var activeUsers = library.Users.Where(u => u.IsActive).OrderByDescending(u => u.BorrowedBooks.Count);

            Console.WriteLine("Active Users Report:");
            Console.WriteLine("-------------------");
            foreach (var user in activeUsers)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Borrowed Books: {user.BorrowedBooks.Count}");
            }
            Console.WriteLine();
        }

        public void GenerateLibraryStatisticsReport()
        {
            var totalBooks = library.Books.Count;
            var availableBooks = library.Books.Count(b => b.IsBorrowed);
            var borrowedBooks = borrowingHistory.GetBorrowedBooks().Count;
            var activeUsers = library.Users.Count(u => u.IsActive);

            Console.WriteLine("Library Statistics Report:");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Total Books: {totalBooks}");
            Console.WriteLine($"Available Books: {availableBooks}");
            Console.WriteLine($"Borrowed Books: {borrowedBooks}");
            Console.WriteLine($"Active Users: {activeUsers}");
            Console.WriteLine();
        }
    }
}
