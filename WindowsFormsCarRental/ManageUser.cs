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
    public partial class ManageUser : Form
    {
        private readonly CarRentalEntities _db;

        public ManageUser()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
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
                //get id of selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                //var genericPassword = "123";
                //var hashed_password = Utils.HashPassword(genericPassword);
                var hashed_password = Utils.DefaultHashPassword();
                user.password = hashed_password;
                _db.SaveChanges();

                MessageBox.Show($"{user.username}'s Password has been reset.");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void bthDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                //get id of selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var user = _db.Users.FirstOrDefault(q => q.id == id);

                // if(user.isActive == true)
                //    user.isActive = false;
                // else
                //    user.isActive = true;
                user.isActive = user.isActive == true ? false : true;
                _db.SaveChanges();

                MessageBox.Show($"{user.username} Active Status has changed.");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            PopulateGrid();
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
                }).ToList();
            gvUserList.DataSource = users;
            gvUserList.Columns["username"].HeaderText = "Username";
            gvUserList.Columns["name"].HeaderText = "Role Name";
            gvUserList.Columns["isActive"].HeaderText = "Active";
            gvUserList.Columns["Id"].Visible = false;
        }
    }
}
