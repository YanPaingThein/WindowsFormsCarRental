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
    public partial class ManageRentalRecord : Form
    {
        private readonly CarRentalEntities _db;

        public ManageRentalRecord()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddEditRentalRecord
            {
                MdiParent = this.MdiParent
            };
            addRentalRecord.Show();                 //Difference way to initialize object
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                //launch AddEditVehicle window with data
                var addEditRentalRecord = new AddEditRentalRecord(record); // kyite tak name pay los ya
                addEditRentalRecord.MdiParent = this.MdiParent;
                addEditRentalRecord.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void bthDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                //delete vehincle fro, tbl
                _db.CarRentalRecords.Remove(record);
                _db.SaveChanges();

                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageRenatlRecord_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PopulateGrid()
        {
            var record = _db.CarRentalRecords
                .Select(q => new
                {
                    Customer = q.CustomerName,
                    DateOut = q.DateRented,
                    DateIn = q.DateReturned,
                    Id = q.id,
                    q.Cost,
                    Car = q.TypesOfCar.Make + " " + q.TypesOfCar.Model      // Name nak lo chin los , ID ko pl u tr ma hote pl nak
                }).ToList();
            gvRecordList.DataSource = record;
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["Id"].Visible = false;
        }
    }
}
