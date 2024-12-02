using LibraryManagementSystem;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryGUI
{
    public partial class BorrowReturn : Form
    {
        private Library library;
        public BorrowReturn()
        {
            InitializeComponent();
            library = new Library();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var back = new MainLibraryGUI();
            back.Show();
            Close();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string userEmail = Interaction.InputBox("Enter user email: ", "Borrow Book");
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                string bookTitle = Interaction.InputBox("Enter Book Title: ", "Borrow Book");
                var book = FirstGUI.library.books.Find(b => b.Title == bookTitle);
                if (book != null)
                {
                    FirstGUI.library.BorrowBook(user, book);
                }
                else
                {
                    MessageBox.Show("Book not found.", "Book not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("User not found.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnViewBorrowedBooks_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string userEmail = Interaction.InputBox("Enter user email: ", "Borrow Book");
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                string list = "";
                foreach(var book in user.BorrowedBooks)
                {
                    list += $"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}";
                }
                MessageBox.Show($"{list}.", $"{user.Name}'s Borrowed Books:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User not found.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string userEmail = Interaction.InputBox("Enter user's Email: ", "Return Book");
            var user = users.Find(u => u.Email == userEmail);
            if (user != null)
            {
                string bookTitle =Interaction.InputBox("Enter Book Title:", "Return Book");
                var book = user.BorrowedBooks.Find(b => b.Title == bookTitle);
                if (book != null)
                {
                    FirstGUI.library.ReturnBook(user, book);
                }
                else
                {
                    MessageBox.Show("User has not borrowed this book.", "Return Book", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("User not found.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
