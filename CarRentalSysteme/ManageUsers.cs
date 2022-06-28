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
    public partial class ManageUsers : Form
    {
        private readonly carrentalEntities _db;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new carrentalEntities();
        }

       

       

        public void PopulateGrid()
        {

            var users = _db.Users
            .Select(q => new
            {
                q.id,
                q.username,
                q.UserRoles.FirstOrDefault().Role.name,
                q.isActive
            })
            .ToList();
            gvUserList.DataSource = users;
            gvUserList.Columns["username"].HeaderText = "Username";
            gvUserList.Columns["name"].HeaderText = "Role Name";
            gvUserList.Columns["isActive"].HeaderText = "Active";


            gvUserList.Columns["id"].Visible = false;
        }


        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            if (!CarRentalApp.Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row 
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                //query database for record 
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                var hashed_password = CarRentalApp.Utils.DefaultHashedPassword();
                user.password = hashed_password;
                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s Password has been reset!");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeactivateUser_Click_1(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row 
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                //query database for record 
                var user = _db.Users.FirstOrDefault(q => q.id == id);
                //if (user.isActive == true) 
                //    user.isActive = false; 
                //else 
                //    user.isActive = true; 
                user.isActive = user.isActive == true ? false : true;
                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s active status has changed!");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void gvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
