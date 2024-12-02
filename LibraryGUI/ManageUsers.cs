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
    public partial class ManageUsers : Form
    {
        private Library library;
        public ManageUsers()
        {
            InitializeComponent();
            library = new Library();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Back to manage books
            var back = new MainLibraryGUI();
            back.Show();
            Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string name = Interaction.InputBox("Enter your Name: ", "Username");
            string email = Interaction.InputBox("Enter your E-Mail: ", "Email");
            if(name != null && email != null)
            {
                users.Add(new User(name, email));
                MessageBox.Show($"User with the name: {name}, and E-mail: {email} has been added successfully", "User Added Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(name == null && email == null)
            {
                MessageBox.Show($"These fields are required", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string userEmail = Interaction.InputBox("Enter E-Mail to deactivate the user:", "Deactivate User");
            var userToDeactivate = users.Find(u => u.Email == userEmail);
            if (userToDeactivate != null)
            {
                userToDeactivate.IsActive = false;
                MessageBox.Show("User deactivated successfully.", "Deactivation Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("User not found.", "Deactivating User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            var users = FirstGUI.library.users;
            string list = "";
            foreach(var user in users)
            {
                list += $"Name: {user.Name}, Email: {user.Email}, IsActive: {user.IsActive}\n";
            }
            MessageBox.Show($"{list}", "User List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
