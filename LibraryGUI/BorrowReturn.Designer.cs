namespace LibraryGUI
{
    partial class BorrowReturn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowReturn));
            this.lblBorrowReturn = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnViewBorrowedBooks = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBorrowReturn
            // 
            this.lblBorrowReturn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBorrowReturn.AutoSize = true;
            this.lblBorrowReturn.BackColor = System.Drawing.Color.Transparent;
            this.lblBorrowReturn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowReturn.ForeColor = System.Drawing.Color.Aqua;
            this.lblBorrowReturn.Location = new System.Drawing.Point(35, 34);
            this.lblBorrowReturn.Name = "lblBorrowReturn";
            this.lblBorrowReturn.Size = new System.Drawing.Size(515, 37);
            this.lblBorrowReturn.TabIndex = 9;
            this.lblBorrowReturn.Text = "Borrowing And Returning Books";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBack.BackColor = System.Drawing.Color.Firebrick;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Aqua;
            this.btnBack.Location = new System.Drawing.Point(302, 203);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(177, 86);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReturn.BackColor = System.Drawing.Color.Firebrick;
            this.btnReturn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReturn.BackgroundImage")));
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Aqua;
            this.btnReturn.Location = new System.Drawing.Point(302, 84);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(177, 86);
            this.btnReturn.TabIndex = 7;
            this.btnReturn.Text = "Return Book";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnViewBorrowedBooks
            // 
            this.btnViewBorrowedBooks.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnViewBorrowedBooks.BackColor = System.Drawing.Color.Firebrick;
            this.btnViewBorrowedBooks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnViewBorrowedBooks.BackgroundImage")));
            this.btnViewBorrowedBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewBorrowedBooks.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewBorrowedBooks.ForeColor = System.Drawing.Color.Aqua;
            this.btnViewBorrowedBooks.Location = new System.Drawing.Point(97, 203);
            this.btnViewBorrowedBooks.Name = "btnViewBorrowedBooks";
            this.btnViewBorrowedBooks.Size = new System.Drawing.Size(177, 86);
            this.btnViewBorrowedBooks.TabIndex = 6;
            this.btnViewBorrowedBooks.Text = "View Borrowed Books";
            this.btnViewBorrowedBooks.UseVisualStyleBackColor = false;
            this.btnViewBorrowedBooks.Click += new System.EventHandler(this.btnViewBorrowedBooks_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBorrow.BackColor = System.Drawing.Color.Firebrick;
            this.btnBorrow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBorrow.BackgroundImage")));
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.ForeColor = System.Drawing.Color.Aqua;
            this.btnBorrow.Location = new System.Drawing.Point(97, 84);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(177, 86);
            this.btnBorrow.TabIndex = 5;
            this.btnBorrow.Text = "Borrow Book";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // BorrowReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = global::LibraryGUI.Properties.Resources.black_dark_fractal_149686_1920x1080;
            this.ClientSize = new System.Drawing.Size(584, 321);
            this.Controls.Add(this.lblBorrowReturn);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnViewBorrowedBooks);
            this.Controls.Add(this.btnBorrow);
            this.Name = "BorrowReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow Return";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBorrowReturn;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnViewBorrowedBooks;
        private System.Windows.Forms.Button btnBorrow;
    }
}