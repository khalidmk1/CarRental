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
    public partial class ManageVehicleListing : Form
    {
        private readonly carrentalEntities _db;
        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new carrentalEntities();
        }

        

        //New Function to PopulateGrid. Can be called anytime we need a grid refresh 
        public void PopulateGrid()
        {
            // Select a custom model collection of cars from database 
            var cars = _db.TypeOfCars
                .Select(q => new
                {
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.Vin,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            //Hide the column for ID. Changed from the hard coded column value to the name,  
            // to make it more dynamic.  
            gvVehicleList.Columns["Id"].Visible = false;
        }
       

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (!CarRentalApp.Utils.FormIsOpen("AddEditVehicle"))
            {
                var addEditVehicle = new AddEditVehicle(this);
                addEditVehicle.ShowDialog();
                addEditVehicle.MdiParent = this.MdiParent;
            }
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row 
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //query database for record 
                var car = _db.TypeOfCars.FirstOrDefault(q => q.Id == id);

                //launch AddEditVehicle window with data 
                if (!CarRentalApp.Utils.FormIsOpen("AddEditVehicle"))
                {
                    var addEditVehicle = new AddEditVehicle(car, this);
                    addEditVehicle.MdiParent = this.MdiParent;
                    addEditVehicle.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteCar_Click_1(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row 
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //query database for record 
                var car = _db.TypeOfCars.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete This Record?",
                "Delete", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    //delete vehicle from table 
                    _db.TypeOfCars.Remove(car);
                    _db.SaveChanges();
                }
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void tbnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
