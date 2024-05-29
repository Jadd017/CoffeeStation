using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStation
{
    public partial class formSubMenu1 : Form
    {
        public formSubMenu1()
        {
            InitializeComponent();
        }
        private void insertusers()
        {
            try
            {
                string username = usernametb.Text;
                string password = passtb.Text;
                string email = emailtb.Text;
                string firstname = fntb.Text;
                string lastname = lntb.Text;
                string address = addresstb.Text;
                string phone = phonetb.Text;
                DateTime dob = dobtb.Value;
                int managerid = 1;
                int status = 1;

                AddEmployee.addNewEmployee(firstname, lastname, username, password, address, phone, email, dob, managerid, status);
                MessageBox.Show("User is added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        private void formSubMenu1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            // Check if all textboxes are filled
            if (!string.IsNullOrEmpty(usernametb.Text) && !string.IsNullOrEmpty(passtb.Text) &&
                !string.IsNullOrEmpty(emailtb.Text) && !string.IsNullOrEmpty(phonetb.Text) &&
                !string.IsNullOrEmpty(addresstb.Text) && !string.IsNullOrEmpty(lntb.Text) &&
                  !string.IsNullOrEmpty(fntb.Text))
            {
                if (!AddEmployee.IsUsernameUnique(usernametb.Text))
                {
                    MessageBox.Show("Username is already taken by another employee");
                    return;
                }
                else
                {
                    // All textboxes are filled, proceed with your event logic
                    // Your event logic goes here
                    insertusers();
                }
              
            }
            else
            {
                // Show a message to the user indicating that all fields need to be filled
                MessageBox.Show("Please fill in all the textboxes.");
            }
        }
    }
}
