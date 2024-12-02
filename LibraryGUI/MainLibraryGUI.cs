using LibraryManagementSystem;
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
    public partial class MainLibraryGUI : Form
    {
        private Library library;
        private BorrowingHistory borrowingHistory;
        public MainLibraryGUI()
        {
            InitializeComponent();
            library = new Library();
            borrowingHistory = new BorrowingHistory();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            var bookManagement = new ManageBooks();
            bookManagement.Show();
            Hide();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var ManageUsers = new ManageUsers();
            ManageUsers.Show();
            Hide();
        }

        private void btnBorrowReturn_Click(object sender, EventArgs e)
        {
            var borrow = new BorrowReturn();
            borrow.Show();
            Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reports = FirstGUI.library.reportGenerator;
            var history = FirstGUI.library.borrowingHistory;
            var popularBooks = borrowingHistory.GetBorrowedBooks()
                .GroupBy(b => b.Book)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key);
            string list = "";
            foreach (var book in popularBooks)
            {
               list += ($"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}, Borrowing Count: {borrowingHistory.GetBorrowedBooks().Count(b => b.Book == book)}\n");
            }
            MessageBox.Show($"{list}", "Popular Books Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var activeUsers = library.Users.Where(u => u.IsActive).OrderByDescending(u => u.BorrowedBooks.Count);
            foreach (var user in activeUsers)
            {
               list += ($"Name: {user.Name}, Email: {user.Email}, Borrowed Books: {user.BorrowedBooks.Count}\n");
            }
            MessageBox.Show($"{list}", "Active Users Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
           var totalBooks = library.Books.Count;
            var availableBooks = library.Books.Count(b => b.IsBorrowed);
            var borrowedBooks = borrowingHistory.GetBorrowedBooks().Count;
            var ActiveUser = library.Users.Count(u => u.IsActive);
            MessageBox.Show($"Total Books: {totalBooks}\n Available Books: {availableBooks}\n Borrowed Books: {borrowedBooks}\n Active Users: {ActiveUser}", "Library Statistics Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

