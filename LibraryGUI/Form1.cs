using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagementSystem;

namespace LibraryGUI
{
    public partial class FirstGUI : Form
    {
        public static Library library;
        public FirstGUI()
        {
            InitializeComponent();
            library = new Library();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals("admin"))
            {
                MessageBox.Show($"Welcome, {txtText.Text}", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                // Load next windows form
                var library = new MainLibraryGUI();
                library.Show();
                
            }
            else
            {
                MessageBox.Show("Wrong, Try again", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            txtText.Clear();
            txtPass.Clear();

        }

        private void FirstGUI_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Enter your pass phrase to continue.", "Pass Phrase", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
