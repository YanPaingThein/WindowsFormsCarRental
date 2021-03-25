using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCarRental
{
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities _db;

        public ManageVehicleListing()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            //select * from TypesOfCars
            //var cars = _db.TypesOfCars.ToList();

            //Select Id as CarId, Make as CarName from TypesOfCars
            //var cars = _db.TypesOfCars.Select(q => new { CarId = q.Id, CarName = q.Make }).ToList();

            var cars = _db.TypesOfCars
                .Select(q => new 
                { 
                    Make = q.Make,
                    Model = q.Model,
                    VIN = q.VIN,
                    Year = q.Year,
                    LicensePlateNumber = q.LicensePlateNumber,
                    q.Id
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false;
            /*gvVehicleList.Columns[0].HeaderText = "ID";
            gvVehicleList.Columns[1].HeaderText = "NAME";*/
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var addEditVehicle = new AddEditVehicle(this);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                //launch AddEditVehicle window with data
                var addEditVehicle = new AddEditVehicle(car, this); // kyite tak name pay los ya
                addEditVehicle.MdiParent = this.MdiParent;
                addEditVehicle.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void bthDeleteCar_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);

                DialogResult dr = MessageBox.Show("Are you sure want to delete this RECORD?",
                    "Delete", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Warning);


                if (dr == DialogResult.Yes)
                {
                    //delete vehincle fro, tbl
                    _db.TypesOfCars.Remove(car);
                    _db.SaveChanges();
                }
                PopulateGrid();     //List ko refresh pyan lote tak code tay yay htr tak method.
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
        
        public void PopulateGrid()
        {
            var cars = _db.TypesOfCars
                 .Select(q => new
                 {
                     Make = q.Make,
                     Model = q.Model,
                     VIN = q.VIN,
                     Year = q.Year,
                     LicensePlateNumber = q.LicensePlateNumber,
                     q.Id
                 })
                 .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns["Id"].Visible = false;
        }

    }
}
