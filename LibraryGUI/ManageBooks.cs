using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using LibraryManagementSystem;


namespace LibraryGUI
{
    public partial class ManageBooks : Form
    {
        private Library library;
        public ManageBooks()
        {
            InitializeComponent();
            library = new Library();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            var books = FirstGUI.library.books;
            string title = Interaction.InputBox("Enter Book Title", "Title: ");
            string author = Interaction.InputBox("Enter Book Author", "Author: ");
            try
            {
               var publicationYear = Convert.ToInt32(Interaction.InputBox("Enter Book Publication Year", "Publication Year: "));
                books.Add(new Book(title, author, publicationYear));
                MessageBox.Show($"Book {title}, added successfully", $"{ title}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch(Exception ex)
            {
                MessageBox.Show($"Invalid Input: Expected a number.", $"{ex}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            var goBack = new MainLibraryGUI();
            goBack.Show();
            // Close this window
            Hide();
        }

        private void btnRemoveBook_Click(object sender, EventArgs e)
        {
            var books = FirstGUI.library.books;
            string bookTitle = Interaction.InputBox("Book Title:", "Enter Book Title: ");
            var bookToRemove = books.Find(b => b.Title == bookTitle);
            if(bookToRemove != null)
            {
                books.Remove(bookToRemove);
                MessageBox.Show("Book Removed Successfully", $"Book {bookTitle}, Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Book not found: \" {bookTitle}\".", $"Book not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBookList_Click(object sender, EventArgs e)
        {
            var books = FirstGUI.library.books;
            string list = "";
            foreach (var book in books)
            {
                list += $"Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}, Available: {!book.IsBorrowed}\n";
            }
            MessageBox.Show($"{list}", "Book List: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ManageBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
