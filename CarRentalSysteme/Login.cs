using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSysteme
{
    public partial class Login : Form
    {
        private readonly carrentalEntities _db;
        public Login()
        {
            InitializeComponent();
            _db = new carrentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create();

                var username = tbUsername.Text.Trim();
                var password = tbPassword.Text;

                var hashed_password = CarRentalApp.Utils.HashPassword(password);

                //Check for matching username, password and active flag 
                var user = _db.Users.FirstOrDefault(q => q.username == username && q.password == hashed_password && q.isActive == true);
                //if (user == null)
                //{
                //  MessageBox.Show("Please provide valid credentials");
                //}
                var mainWindow = new MainWindow(this, user);
                mainWindow.Show();
                Hide();
                //else
                //{
                
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please try again");
            }
        }
    }
}
