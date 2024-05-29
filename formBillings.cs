
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CoffeeStation
{
    public partial class formBillings : Form
    {
        private Dictionary<string, Dictionary<string, double>> GetDataByCategory = new Dictionary<string, Dictionary<string, double>>();
        public formBillings()
        {
            InitializeComponent();
            guna2vScrollBar1.BindingContainer = guna2DataGridView1;
            guna2vScrollBar1.AutoScroll = true;


            GetDataByCategory.Add("Sales", new Dictionary<string, double>());
            GetDataByCategory.Add("Revenue", new Dictionary<string, double>());
            GetDataByCategory.Add("Commissions", new Dictionary<string, double>());
            GetDataByCategory.Add("Expense", new Dictionary<string, double>());
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int idx = 0;
            List<string> lables = new List<string>();
            foreach (var item in guna2ComboBox1.Items)
            {
                for (int i = 1; i <= 12; i++)
                {
                    var date = new DateTime(2023, i, 1);
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);

                    int r = guna2DataGridView1.Rows.Add(new object[]
                    {
                        monthName,0
                    });
                    guna2DataGridView1.Rows[r].Tag = item;
                    guna2DataGridView1.Rows[r].Visible = (idx == 0);
                    if (idx == 0) lables.Add(monthName);
                    switch (idx)
                    {
                        case 0:
                            cSales.DataPoints.Add(monthName, 0);
                            break;
                        case 1:
                            cRevenue.DataPoints.Add(monthName, 0);
                            break;
                        case 2:
                            cCommissions.DataPoints.Add(monthName, 0);
                            break;
                        case 3:
                            cExpense.DataPoints.Add(monthName, 0);
                            break;
                    }

                }
                if (idx == 0)
                {
                    lables.Add(" ");

                }
                idx++;
                gunaChart1.Update();
            }


        }


        private double GetDataForCategory(string category, string month)
        {
            //check if data exists for category and month
            if (GetDataByCategory.ContainsKey(category) && GetDataByCategory[category].ContainsKey(month))
            {
                return GetDataByCategory[category][month];
            }
            return 0;//Defult value in no data exists
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedComboboxItem = guna2ComboBox1.Text;
            guna2DataGridView1.Rows.Clear();

            //Populate DataGridView Based on the Selected Item

            foreach (var item in guna2ComboBox1.Items)
            {
                for (int i = 1; i <= 12; i++)
                {
                    var date = new DateTime(2023, i, 1);
                    string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(date.Month);

                    int r = guna2DataGridView1.Rows.Add(new object[]
                    {
                        monthName,
                        GetDataForCategory(selectedComboboxItem,monthName)//get Data for Selected Item
                    }); ;
                    guna2DataGridView1.Rows[r].Tag = item;
                    guna2DataGridView1.Rows[r].Visible = (item.ToString() == selectedComboboxItem);
                }

            }
        }


        private double salesSum = 0.0;
        private double RevenueSum = 0.0;
        private double CommissionsSum = 0.0;
        private double ExpenseSum = 0.0;


        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string selectedComboBoxItem = guna2ComboBox1.Text;
            string month = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            double value;
            // try to parse entered value
            if (double.TryParse(guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), out value))
            {
                //store value crossponding catagory and month

                if (!GetDataByCategory.ContainsKey(selectedComboBoxItem))
                {
                    GetDataByCategory[selectedComboBoxItem] = new Dictionary<string, double>();
                }
                GetDataByCategory[selectedComboBoxItem][month] = value;

            }
            else
            {
                //Handle invalid input (non numeric values)
                guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value = GetDataForCategory(selectedComboBoxItem, month);
            }




            var charts = cSales;
            switch (guna2ComboBox1.SelectedIndex)
            {
                case 1:
                    charts = cRevenue;
                    break;
                case 2:
                    charts = cCommissions;
                    break;
                case 3:
                    charts = cExpense;
                    break;
            }
            charts.DataPoints.Clear();
            double totalsum = 0.0;

            //Itrate through Gridview Rows
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                //Check if Row is Visible
                if (row.Visible)
                {
                    var CellValue = row.Cells[1].Value;
                    if (CellValue != null)
                    {
                        if (double.TryParse(CellValue.ToString(), out double value1))
                        {
                            string monthName = row.Cells[0].Value.ToString();
                            charts.DataPoints.Add(monthName, value1);
                            totalsum += value1;

                        }
                    }

                }
            }
            gunaChart1.Update();

            //Update Appropriate sum variable based on selected category

            switch (selectedComboBoxItem)
            {
                case "Sales":
                    salesSum = totalsum;
                    break;
                case "Revenue":
                    RevenueSum = totalsum;
                    break;
                case "Commissions":
                    CommissionsSum = totalsum;
                    break;
                case "Expense":
                    ExpenseSum = totalsum;
                    break;
            }

            //update lables with calculated sum
            lblsales.Text = salesSum.ToString();
            lblrevenue.Text = RevenueSum.ToString();
            lblexp.Text = ExpenseSum.ToString();
            lblComs.Text = CommissionsSum.ToString();



        }
    }
}