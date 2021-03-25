using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCarRental
{
    public partial class Login : Form
    {
        private readonly CarRentalEntities _db;

        public Login()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var uesrname = tbUsername.Text.Trim();
                var password = tbPassword.Text;

                var hashed_password = Utils.HashPassword(password);
                Console.WriteLine("hashed : " + hashed_password);

                var user = _db.Users.FirstOrDefault(q => q.username == uesrname && q.password == hashed_password &&
                    q.isActive == true);

                if (user == null)
                {
                    MessageBox.Show("Please provide valid credentials.");
                }
                else
                {
                    /*
                                        var role = user.UserRoles.FirstOrDefault(); // 1 row htae pl u mhr mos => ma use tos
                                        var roleShortName = role.Role.shortname;    // shortName ko roleShortName htae put
                                        var mainWindow = new MainWindow(this, roleShortName);   // pe yin MainWnidow ko pay lite 
                    */

                    var mainWindow = new MainWindow(this, user);   // a paw ka lo tutu pl, but user so tak objet 1 ku lone ko send pay
                    mainWindow.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong.Please try again!");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
