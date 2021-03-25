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
    public partial class AddEditRentalRecord : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities _db;

        public AddEditRentalRecord()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Record";
            isEditMode = false;
            _db = new CarRentalEntities();
        }

        public AddEditRentalRecord(CarRentalRecord recordToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Record";
            isEditMode = true;
            _db = new CarRentalEntities();
            PopulateFields(recordToEdit);
        }

        private void PopulateFields(CarRentalRecord recordToEdit)
        {
            tbCustomerName.Text = recordToEdit.CustomerName;
            dtpRent.Value = (DateTime)recordToEdit.DateRented;
            dtpReturn.Value = (DateTime)recordToEdit.DateReturned;
            tbCost.Text = recordToEdit.Cost.ToString();
            lblRecordId.Text = recordToEdit.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String customerName = tbCustomerName.Text;
                var dateRent = dtpRent.Value;
                var dateReturn = dtpReturn.Value;
                double cost = Convert.ToDouble(tbCost.Text);
                var carType = cbTypeOfCar.Text;
                var isValid = true;
                var errorMsg = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    isValid = false;
                    errorMsg += "Error : Please enter missing data!\n\r";
                }

                if (dateRent > dateReturn)
                {
                    isValid = false;
                    errorMsg += "Error : Wrong date!\n\r";
                }

                // if (isValid == true)   ------ same is below
                /*if (isValid)
                {
                    if (isEditMode)
                    {
                        var id = int.Parse(lblRecordId.Text);
                        var rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        rentalRecord.CustomerName = customerName;
                        rentalRecord.DateRented = dateRent;
                        rentalRecord.DateReturned = dateReturn;
                        rentalRecord.Cost = (decimal)cost;      // Decimal.Parse ko use los ma ya; bcs of .Parse ka string ko pl use los ya tr
                        rentalRecord.TypeOfCarId = (int)cbTypeOfCar.SelectedValue;

                        _db.SaveChanges();

                        MessageBox.Show($"CustomerName : {customerName}\n\r" +
                        $"Rented Date : {dateRent}\n\r" +
                        $"Returned Date : {dateReturn}\n\r" +
                        $"Cost : {cost}\n\r" +
                        $"Car Type : {carType}\n\r" +
                        $"Thanks you !"
                    }
                    else
                    {
                        var rentalRecord = new CarRentalRecord();
                        rentalRecord.CustomerName = customerName;
                        rentalRecord.DateRented = dateRent;
                        rentalRecord.DateReturned = dateReturn;
                        rentalRecord.Cost = (decimal)cost;      // Decimal.Parse ko use los ma ya; bcs of .Parse ka string ko pl use los ya tr
                        rentalRecord.TypeOfCarId = (int)cbTypeOfCar.SelectedValue;
                        _db.CarRentalRecords.Add(rentalRecord);
                        _db.SaveChanges();

                        MessageBox.Show($"CustomerName : {customerName}\n\r" +
                        $"Rented Date : {dateRent}\n\r" +
                        $"Returned Date : {dateReturn}\n\r" +
                        $"Cost : {cost}\n\r" +
                        $"Car Type : {carType}\n\r" +
                        $"Thanks you !"
                        );
                    }
                    Close();
                }*/
                if (isValid)
                {
                    //Declare an object of the record to be added
                    var rentalRecord = new CarRentalRecord();
                    if (isEditMode)
                    {
                        //If in edit mode,then get ID and retrieve the record from the database and place
                        //The result in the record object
                        var id = int.Parse(lblRecordId.Text);
                        rentalRecord = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                    }
                    //populate the record objects with values from the form
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = dateRent;
                    rentalRecord.DateReturned = dateReturn;
                    rentalRecord.Cost = (decimal)cost;      // Decimal.Parse ko use los ma ya; bcs of .Parse ka string ko pl use los ya tr
                    rentalRecord.TypeOfCarId = (int)cbTypeOfCar.SelectedValue;

                    //if not editMode, add the record to the DB
                    if (!isEditMode)
                        _db.CarRentalRecords.Add(rentalRecord);

                    //save changes made to the entity
                    _db.SaveChanges();

                    MessageBox.Show($"CustomerName : {customerName}\n\r" +
                        $"Rented Date : {dateRent}\n\r" +
                        $"Returned Date : {dateReturn}\n\r" +
                        $"Cost : {cost}\n\r" +
                        $"Car Type : {carType}\n\r" +
                        $"Thanks you !"
                        );

                    Close();
                }
                else
                {
                    MessageBox.Show(errorMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;                  // to end program
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // select * from TypesOfCars
            //var cars = carRentalEntities.TypesOfCars.ToList();

            var cars = _db.TypesOfCars
                .Select(q => new {Id = q.Id, Name = q.Make + " " + q.Model})
                .ToList();
            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "Id";
            cbTypeOfCar.DataSource = cars;
        }
        
    }
}
