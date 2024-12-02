using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagementSystem
{
    public class FileManager
    {
        private const string BooksFilePath = "books.txt";
        private const string UsersFilePath = "users.txt";
        private const string BorrowingHistoryFilePath = "borrowingHistory.txt";

        public List<Book> LoadBooks()
        {
            var books = new List<Book>();
            if (File.Exists(BooksFilePath))
            {
                var lines = File.ReadAllLines(BooksFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        var book = new Book(parts[0], parts[1], int.Parse(parts[2]))
                        {
                            IsBorrowed = bool.Parse(parts[3])
                        };
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public void SaveBooks(List<Book> books)
        {
            var uniqueBooks = new HashSet<string>();
            var lines = new List<string>();
            foreach (var book in books)
            {
                var bookKey = $"{book.Title}|{book.Author}|{book.PublicationYear}";
                if (!uniqueBooks.Contains(bookKey))
                {
                    uniqueBooks.Add(bookKey);
                    lines.Add($"{book.Title}|{book.Author}|{book.PublicationYear}|{book.IsBorrowed}");
                }
            }
            File.WriteAllLines(BooksFilePath, lines);
        }

        public List<User> LoadUsers()
        {
            var users = new List<User>();
            if (File.Exists(UsersFilePath))
            {
                var lines = File.ReadAllLines(UsersFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        var user = new User(parts[0], parts[1])
                        {
                            IsActive = bool.Parse(parts[2])
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public void SaveUsers(List<User> users)
        {
            var uniqueUsers = new HashSet<string>();
            var lines = new List<string>();
            foreach (var user in users)
            {
                var userKey = $"{user.Name}|{user.Email}";
                if (!uniqueUsers.Contains(userKey))
                {
                    uniqueUsers.Add(userKey);
                    lines.Add($"{user.Name}|{user.Email}|{user.IsActive}");
                }
            }
            File.WriteAllLines(UsersFilePath, lines);
        }

        public BorrowingHistory LoadBorrowingHistory()
        {
            var borrowingHistory = new BorrowingHistory();
            if (File.Exists(BorrowingHistoryFilePath))
            {
                var lines = File.ReadAllLines(BorrowingHistoryFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        var user = new User(parts[0], parts[1]);
                        var book = new Book(parts[2], parts[3], 0);  // publication year is not stored here
                        borrowingHistory.RecordBorrowing(user, book);
                    }
                }
            }
            return borrowingHistory;
        }

        public void SaveBorrowingHistory(BorrowingHistory borrowingHistory)
        {
            var uniqueBorrowings = new HashSet<string>();
            var lines = new List<string>();
            foreach (var borrowing in borrowingHistory.GetBorrowedBooks())
            {
                var borrowingKey = $"{borrowing.User.Name}|{borrowing.User.Email}|{borrowing.Book.Title}|{borrowing.Book.Author}";
                if (!uniqueBorrowings.Contains(borrowingKey))
                {
                    uniqueBorrowings.Add(borrowingKey);
                    lines.Add(borrowingKey);
                }
            }
            File.WriteAllLines(BorrowingHistoryFilePath, lines);
        }
    }
}
