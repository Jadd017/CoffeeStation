using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace CoffeeStation
{

    public partial class formDashboard : Form
    {

        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

        public formDashboard()
        {
            InitializeComponent();
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
        }
       

        private void formDashboard_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

        }
        /* private void ItemButton_Click(object sender, EventArgs e)
         {
             // Retrieve the price from button's tag and display it below the button
             Button clickedButton = (Button)sender;
             decimal itemPrice = (decimal)clickedButton.Tag;

             MessageBox.Show($"Price: {itemPrice:C}");
         }*/
        public void AddButtons(List<string> items)
        {foreach (string item in items)
            {
                Button newButton = new Button();
                newButton.Text = item;
                newButton.Size =new Size(100,115);
                newButton.BackColor = Color.White;
                newButton.Font = new Font("Arial", 12, FontStyle.Bold);

                flowLayoutPanel1.Controls.Add(newButton);
            }
        }

            private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private string PromptForTableName2()
        {


            string tableName2 = Microsoft.VisualBasic.Interaction.InputBox("Enter table name:", "New Table", "");

            return tableName2;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string tableName2 = PromptForTableName2();

            if (!string.IsNullOrEmpty(tableName2))
            {
                Button button = new Button();
                button.Text = tableName2;

                // Set the size of the new button
                button.Size = new Size(80, 90); // Example size, adjust as needed
                button.BackColor = Color.DimGray;

                // Set text color and font size
                button.ForeColor = Color.Black; // Example color, adjust as needed
                button.Font = new Font("Arial", 10, FontStyle.Regular); // Example font, adjust as needed

                // Add the new button to the FlowLayoutPanel
                flowLayoutPanel2.FlowDirection = FlowDirection.LeftToRight; // Set flow direction to left-to-right
                flowLayoutPanel2.Controls.Add(button);
                /*  string tableName2 = PromptForTableName2();

                  if (!string.IsNullOrEmpty(tableName2))
                  {
                      Button Button = new Button();
                      Button.Text = tableName2;

                      // Set the size of the new button
                      Button.Size = new Size(100, 97); // Example size, adjust as needed
                      Button.BackColor = Color.WhiteSmoke;

                      // Set text color and font size
                      Button.ForeColor = Color.Black; // Example color, adjust as needed
                      Button.Font = new Font("Arial", 10, FontStyle.Regular); // Example font, adjust as needed

                      // Add the new button to the FlowLayoutPanel
                      panel2.Controls.Add(Button);
                  } */
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
