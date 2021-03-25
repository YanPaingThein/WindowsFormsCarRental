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
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private ManageVehicleListing _manageVehicleListing;
        private readonly CarRentalEntities _db;

        public AddEditVehicle(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();
        }

        //Overload constructor
        public AddEditVehicle(TypesOfCar carToEdit, ManageVehicleListing manageVehicleListing = null) 
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            _manageVehicleListing = manageVehicleListing;
            if (carToEdit == null)
            {
                MessageBox.Show("Please select a vilid record to edit.");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
        }

        private void PopulateFields(TypesOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModle.Text = car.Model;
            tbVin.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var errorMsg = "";
                var successMsg = "Operation complete.Refresh Grid to see changes.";

                var make = tbMake.Text;
                var model = tbModle.Text;
                var vin = tbVin.Text;
                var year = int.Parse(tbYear.Text);
                var licensePlateNum = tbLicenseNum.Text;

                if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model))
                {
                    errorMsg += "Please ensure that you provide a make and a mode.";
                    MessageBox.Show(errorMsg);
                } 
                else
                {
                    //if(isEditMode == true)
                    if (isEditMode)
                    {
                        //Edit code 
                        var id = int.Parse(lblId.Text);
                        var car = _db.TypesOfCars.FirstOrDefault(q => q.Id == id);
                        car.Make = tbMake.Text;
                        car.Model = tbModle.Text;
                        car.VIN = tbVin.Text;
                        car.Year = int.Parse(tbYear.Text);
                        car.LicensePlateNumber = tbLicenseNum.Text;

                        /*_db.SaveChanges();
                        mode = "Update";
                        MessageBox.Show($"{mode} {successMsg}");
                        Close();*/
                    }
                    else
                    {
                        //Add code
                        var newCar = new TypesOfCar
                        {
                            LicensePlateNumber = tbLicenseNum.Text,
                            Make = tbMake.Text,
                            Model = tbModle.Text,
                            VIN = tbVin.Text,
                            Year = int.Parse(tbYear.Text)
                        };

                        _db.TypesOfCars.Add(newCar);
                    }
                    _db.SaveChanges();
                    _manageVehicleListing.PopulateGrid();
                    MessageBox.Show($"{successMsg}");
                    Close();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
