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
    public partial class formSubMenu2 : Form
    {
        formDashboard dashboard;

        public formSubMenu2()
        {
            InitializeComponent();
        }

        private void formSubMenu2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
        private void insertusers()
        {
            try
            {
                string prdctname = prdctnametb.Text;
                string prdctqutity = prdctqutb.Text;
                string unitprice = unitpricetb.Text;
                string suppname = suppnametb.Text;
                string suppphone = suppphonetb.Text;
                string compemail = compemailtb.Text;
                string compname = compnametb.Text;
                DateTime dd = ddtb.Value;
                int managerid = 1;
                int status = 1;

               // AddEmployee.addNewEmployee(firstname, lastname, username, password, address, phone, email, dob, managerid, status);
                MessageBox.Show("User is added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            // Check if all textboxes are filled
            if (!string.IsNullOrEmpty(prdctnametb.Text) && !string.IsNullOrEmpty(prdctqutb.Text) &&
                !string.IsNullOrEmpty(unitpricetb.Text) && !string.IsNullOrEmpty(compnametb.Text) &&
                !string.IsNullOrEmpty(compemailtb.Text) && !string.IsNullOrEmpty(suppphonetb.Text) &&
                  !string.IsNullOrEmpty(suppnametb.Text))
            {
                try
                {
                   
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            else
            {
                // Show a message to the user indicating that all fields need to be filled
                MessageBox.Show("Please fill in all the textboxes.");
            }
        }
        List<string> itemsToAdd = new List<string>();

        private void button3_Click(object sender, EventArgs e)
        {
           
                // Add item name and price to the list
                string itemName = itemname.Text;
                string itemPrice = itemprice.Text;
                string itemDescription = itemName + " - $" + itemPrice;
                itemsToAdd.Add(itemDescription);

            // Add more items as needed

            // Pass the list of items to Form2 to create buttons
            if (dashboard == null)
            {
                dashboard = new formDashboard();
                dashboard.AddButtons(itemsToAdd);
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }




        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Add("gram");
            comboBox7.Items.Add("L");
            comboBox7.Items.Add("ml");
            comboBox7.Items.Add("tbsp");
            comboBox7.Items.Add("tsp");
            comboBox7.Items.Add("Oz");
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Add("gram");
            comboBox8.Items.Add("L");
            comboBox8.Items.Add("ml");
            comboBox8.Items.Add("tbsp");
            comboBox8.Items.Add("tsp");
            comboBox8.Items.Add("Oz");
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Items.Add("gram");
            comboBox9.Items.Add("L");
            comboBox9.Items.Add("ml");
            comboBox9.Items.Add("tbsp");
            comboBox9.Items.Add("tsp");
            comboBox9.Items.Add("Oz");
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox10.Items.Add("gram");
            comboBox10.Items.Add("L");
            comboBox10.Items.Add("ml");
            comboBox10.Items.Add("tbsp");
            comboBox10.Items.Add("tsp");
            comboBox10.Items.Add("Oz");
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Add("gram");
            comboBox11.Items.Add("L");
            comboBox11.Items.Add("ml");
            comboBox11.Items.Add("tbsp");
            comboBox11.Items.Add("tsp");
            comboBox11.Items.Add("Oz");
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox12.Items.Add("gram");
            comboBox12.Items.Add("L");
            comboBox12.Items.Add("ml");
            comboBox12.Items.Add("tbsp");
            comboBox12.Items.Add("tsp");
            comboBox12.Items.Add("Oz");
        }
    }
    }

