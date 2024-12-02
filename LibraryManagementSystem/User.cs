using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        // Parameterless constructor for serialization
        public User()
        {
            BorrowedBooks = new List<Book>();
        }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
            IsActive = true;
            BorrowedBooks = new List<Book>();
        }

        public void BorrowBook(Book book)
        {
            BorrowedBooks.Add(book);
        }

        public void ReturnBook(Book book)
        {
            BorrowedBooks.Remove(book);
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user == null)
            {
                return false;
            }
            return Email == user.Email;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (Email?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
