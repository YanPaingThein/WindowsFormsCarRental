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
    public partial class ResetPassword : Form
    {
        private readonly CarRentalEntities _db;
        private User _user;

        public ResetPassword(User user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var password = tbPassword.Text;
                var confirmPassword = tbConfirmPassword.Text;
                var uesr = _db.Users.FirstOrDefault(q => q.id == _user.id);

                if (password != confirmPassword)
                {
                    MessageBox.Show("Password not match! Please try again!");
                }

                uesr.password = Utils.HashPassword(password);
                _db.SaveChanges();
                MessageBox.Show("Password was reset successful.");
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured! Please try again?");
            }
            
        }
    }
}
