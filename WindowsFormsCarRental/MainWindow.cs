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
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addRentalRecord = new AddEditRentalRecord();
            addRentalRecord.ShowDialog();
            addRentalRecord.MdiParent = this;
            
        }

        private void manageVehicleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == "ManageVehicleListing");
            if (!isOpen)
            {
                var vehicleListing = new ManageVehicleListing();
                vehicleListing.MdiParent = this;
                vehicleListing.Show();
            }
            
        }

        private void viewAchieveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageRentalRecood = new ManageRentalRecord();
            manageRentalRecood.MdiParent = this;
            manageRentalRecood.Show();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageUser = new ManageUser();
            manageUser.MdiParent = this;
            manageUser.Show();

            // Utls.FormOpen so pe cnodition sit tr kyan tay
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.password == Utils.DefaultHashPassword())
            {
                var resetPassword = new ResetPassword(_user);
                resetPassword.ShowDialog();
            }

            var username = _user.username;
            toolStripStatusLabel1.Text = $"Login in as {username}";
            if (_roleName != "admin")
            {
                manageUserToolStripMenuItem.Visible = false;
            }
        }

    }
}
