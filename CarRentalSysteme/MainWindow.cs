using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSysteme
{
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public User _user;
       

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login, User user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
           
        }
   
       

        private void MainWindow_Load_1(object sender, EventArgs e)
        {
            //if (_user.password == CarRentalApp.Utils.DefaultHashedPassword())
            //{
            //    var resetPassword = new ResetPassword(_user);
            //    resetPassword.ShowDialog();
            //}

            //var username = _user.username;
           
            
        }

      

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mangeRental = new ManageRentalRecords();
            mangeRental.MdiParent = this;
            mangeRental.Show();
        }

       

        private void manageRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mangeRentalRecord = new ManageVehicleListing();
            mangeRentalRecord.MdiParent = this;
            mangeRentalRecord.Show();
        }

        private void manageuserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageUser = new ManageUsers();
            manageUser.MdiParent = this;
            manageUser.Show();
        }
    }
}
