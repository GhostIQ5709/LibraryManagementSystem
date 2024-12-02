using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        public List<Book> books;
        public List<User> users;
        public FileManager fileManager;
        public BorrowingHistory borrowingHistory;
        public ReportGenerator reportGenerator;

        public List<Book> Books => books;
        public List<User> Users => users;
        public BorrowingHistory BorrowingHistory => borrowingHistory;

        public Library()
        {
            fileManager = new FileManager();
            books = fileManager.LoadBooks() ?? new List<Book>();
            users = fileManager.LoadUsers() ?? new List<User>();
            borrowingHistory = fileManager.LoadBorrowingHistory() ?? new BorrowingHistory();
            reportGenerator = new ReportGenerator(this, borrowingHistory);

            // Populate with dummy data for testing
            PopulateWithDummyData();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Users");
                Console.WriteLine("3. Borrow and Return Books");
                Console.WriteLine("4. Generate Reports");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageBooks();
                        break;
                    case "2":
                        ManageUsers();
                        break;
                    case "3":
                        BorrowAndReturnBooks();
                        break;
                    case "4":
                        GenerateReports();
                        break;
                    case "5":
                        SaveData();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void SaveData()
        {
            try
            {
                fileManager.SaveBooks(books);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving books: {ex.Message}");
            }

            try
            {
                fileManager.SaveUsers(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving users: {ex.Message}");
            }

            try
            {
                fileManager.SaveBorrowingHistory(borrowingHistory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving borrowing history: {ex.Message}");
            }
        }

        private void PopulateWithDummyData()
        {
            // Add dummy books
            books.Add(new Book("To Kill a Mockingbird", "Harper Lee", 1960));
            books.Add(new Book("1984", "George Orwell", 1949));
            books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
            books.Add(new Book("The Catcher in the Rye", "J.D. Salinger", 1951));

            // Add dummy users
            users.Add(new User("John Doe", "john.doe@example.com"));
            users.Add(new User("Jane Smith", "jane.smith@example.com"));
            users.Add(new User("Alice Johnson", "alice.johnson@example.com"));

            // Simulate borrowing books
            var user1 = users[0];
            var user2 = users[1];
            var book1 = books[0];
            var book2 = books[1];

            BorrowBook(user1, book1);
            BorrowBook(user2, book2);
        }

        public void AddBook(string title, string author, int publicationYear)
        {
            var book = new Book(title, author, publicationYear);
            books.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        public void AddUser(string name, string email)
        {
            var user = new User(name, email);
            users.Add(user);
            Console.WriteLine("User added successfully.");
        }

        public void BorrowBook(User user, Book book)
        {
            if (!book.IsBorrowed)
            {
                user.BorrowBook(book);
                book.IsBorrowed = true;
                book.BorrowedBy = user;
                borrowingHistory.RecordBorrowing(user, book);
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry, the book '{book.Title}' is not available for borrowing.");
            }
        }

        public void ReturnBook(User user, Book book)
        {
            if (user.BorrowedBooks.Contains(book))
            {
                user.ReturnBook(book);
                book.IsBorrowed = false;
                book.BorrowedBy = null;
                borrowingHistory.RecordReturning(user, book);
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine($"The book '{book.Title}' was not borrowed by '{user.Name}'.");
            }
        }

        private void ManageBooks()
        {
            bool managingBooks = true;
            while (managingBooks)
            {
                Console.WriteLine("Book Management");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. View Book List");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookFlow();
                        break;
                    case "2":
                        RemoveBookFlow();
                        break;
                    case "3":
                        ViewBookList();
                        break;
                    case "4":
                        managingBooks = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddBookFlow()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("Enter book author: ");
            string author = Console.ReadLine();
            Console.Write("Enter publication year: ");
            try
            {
                int publicationYear = Convert.ToInt32(Console.ReadLine());
            } catch (Exception ex) {
                Console.WriteLine($"Invalid year. Please try again. Error: {ex.Message}");
            }
        }

        private void RemoveBookFlow()
        {
            Console.Write("Enter book title to remove: ");
            string bookTitle = Console.ReadLine();
            var bookToRemove = books.Find(b => b.Title == bookTitle);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        private void ViewBookList()
        {
            Console.WriteLine("Book List:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}, Available: {!book.IsBorrowed}");
            }
        }

        private void ManageUsers()
        {
            bool managingUsers = true;
            while (managingUsers)
            {
                Console.WriteLine("User Management");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Deactivate User");
                Console.WriteLine("3. View User List");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUserFlow();
                        break;
                    case "2":
                        DeactivateUserFlow();
                        break;
                    case "3":
                        ViewUserList();
                        break;
                    case "4":
                        managingUsers = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddUserFlow()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine();
            Console.Write("Enter user email: ");
            string email = Console.ReadLine();
            AddUser(name, email);
        }

        private void DeactivateUserFlow()
        {
            Console.Write("Enter user email to deactivate: ");
            string userEmail = Console.ReadLine();
            var userToDeactivate = users.Find(u => u.Email == userEmail);
            if (userToDeactivate != null)
            {
                userToDeactivate.IsActive = false;
                Console.WriteLine("User deactivated successfully.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void ViewUserList()
        {
            Console.WriteLine("User List:");
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Name}, Email: {user.Email}, Active: {user.IsActive}");
            }
        }

        private void BorrowAndReturnBooks()
        {
            bool borrowingAndReturning = true;
            while (borrowingAndReturning)
            {
                Console.WriteLine("Borrowing and Returning Books");
                Console.WriteLine("1. Borrow Book");
                Console.WriteLine("2. Return Book");
                Console.WriteLine("3. View Borrowed Books");
                Console.WriteLine("4. Back to Main Menu");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BorrowBookFlow();
                        break;
                    case "2":
                        ReturnBookFlow();
                        break;
                    case "3":
                        ViewBorrowedBooksFlow();
                        break;
                    case "4":
                        borrowingAndReturning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void BorrowBookFlow()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                Console.Write("Enter book title: ");
                string bookTitle = Console.ReadLine();
                var book = books.Find(b => b.Title == bookTitle);
                if (book != null)
                {
                    BorrowBook(user, book);
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void ReturnBookFlow()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                Console.Write("Enter book title: ");
                string bookTitle = Console.ReadLine();
                var book = user.BorrowedBooks.Find(b => b.Title == bookTitle);
                if (book != null)
                {
                    ReturnBook(user, book);
                }
                else
                {
                    Console.WriteLine("User has not borrowed this book.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void ViewBorrowedBooksFlow()
        {
            Console.Write("Enter user email: ");
            string userEmail = Console.ReadLine();
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                Console.WriteLine($"{user.Name}'s Borrowed Books:");
                foreach (var book in user.BorrowedBooks)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        private void GenerateReports()
        {
            reportGenerator.GeneratePopularBooksReport();
            reportGenerator.GenerateActiveUsersReport();
            reportGenerator.GenerateLibraryStatisticsReport();
        }
    }
}
