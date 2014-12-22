using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerQueryManagement
{
    public partial class CustomerUI : Form
    {
        enum CustomerStatus
    {
        Not_Served,
        On_Served,
        Served
    }
        public CustomerUI()
        {
            InitializeComponent();
        }
        List<Customer> customers = new List<Customer>();
        string connectionString =
              @"Data Source= (LOCAL)\SQLEXPRESS; Database = Customer DB; Integrated Security = true";
        private void enqueueButton_Click(object sender, EventArgs e)
        {
            SaveData();
            ListView();
        
          
        }

        public void ShowNoOfCustomerServedToday()
        {
            SqlConnection aSqlConnection = new SqlConnection(connectionString);
            aSqlConnection.Open();
            string commandText = "SELECT COUNT(SerialNo) FROM tCustomers WHERE CustomerSerial = '"+CustomerStatus.Served+"'";
            SqlCommand aSqlCommand = new SqlCommand(commandText, aSqlConnection);
            SqlDataReader aSqlDataReader = aSqlCommand.ExecuteReader();
            aSqlDataReader.Read();
            int noOfServedCustomer = Convert.ToInt32(aSqlDataReader[0]);
            aSqlConnection.Close();
            servedLabel.Text = noOfServedCustomer.ToString();

        }

        private void SaveData()
        {
            Customer aCustomer = new Customer();
           
            aCustomer.name = nameEnqueueTextBox.Text;
            aCustomer.complain = complainEnqueueTextBox.Text;
           
          
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "INSERT INTO tCustomers VALUES('" + aCustomer.name + "','" + aCustomer.complain + "','" +
                           CustomerStatus.Not_Served + "')";
            SqlCommand command = new SqlCommand(query, connection);
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
            {
                MessageBox.Show("Successfully Saved!");
            }
            else
            {
                MessageBox.Show("Couldn't Save the data ", " Error");
            }
        }


        private void ListView()
        {
            string connection = @"Data Source= (LOCAL)\SQLEXPRESS; Database = Customer DB; Integrated Security = true";
            SqlConnection Connection = new SqlConnection(connection);
            Connection.Open();
            string newquery = "SELECT* FROM tCustomers WHERE CustomerSerial = '"+CustomerStatus.Not_Served+"' OR CustomerSerial = '"+CustomerStatus.On_Served+"'";
            SqlCommand newcommand = new SqlCommand(newquery, Connection);
            SqlDataReader reader = newcommand.ExecuteReader();
            
            List<Customer> customers = new List<Customer>();
           
            while (reader.Read())
            {
                Customer aCustomer = new Customer();
                aCustomer.serialNo = reader["SerialNo"].ToString();
                aCustomer.name = reader["CustomerName"].ToString();
                aCustomer.complain = reader["CustomerComplain"].ToString();
                aCustomer.status = reader["CustomerSerial"].ToString();

                customers.Add(aCustomer);
            }
            Connection.Close();
            customerListView.Items.Clear();
            foreach(Customer aCustomer in customers)
            {
                ListViewItem myView = new ListViewItem();


                myView.Text = (aCustomer.serialNo);
                myView.SubItems.Add(aCustomer.name);
                myView.SubItems.Add(aCustomer.complain);
                myView.SubItems.Add(aCustomer.status);


                customerListView.Items.Add(myView);
               
            }
            remainingLabel.Text = customers.Count.ToString();
            ShowNoOfCustomerServedToday();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            ListView();
        }

        private void dequeueButton_Click(object sender, EventArgs e)
        {
            int i = 0;
            string connection = @"Data Source= (LOCAL)\SQLEXPRESS; Database = Customer DB; Integrated Security = true";
            using (SqlConnection Connection = new SqlConnection(connection))
            {

                Connection.Open();
                string newquery = "UPDATE tCustomers SET CustomerSerial = '" + CustomerStatus.On_Served +
                                  "' WHERE SerialNo = (SELECT MIN (SerialNo)+"+i+" FROM tCustomers);";
                using (SqlCommand newcommand = new SqlCommand(newquery, Connection))
                {
                    newcommand.ExecuteNonQuery();
                }

                i++;
                string query = "SELECT* FROM tCustomers WHERE CustomerSerial = '" + CustomerStatus.On_Served + "' UPDATE tCustomers SET CustomerSerial = '"+CustomerStatus.Served+"'WHERE CustomerSerial = '"+CustomerStatus.On_Served+"';";
                using (SqlCommand command = new SqlCommand(query, Connection))
                {
                
                SqlDataReader reader = command.ExecuteReader();

            
            //List<Customer> customers = new List<Customer>();

            customerListView.Items.Clear();
                    while (reader.Read())
                    {
                        Customer aCustomer = new Customer();
                        aCustomer.serialNo = reader["SerialNo"].ToString();
                        aCustomer.name = reader["CustomerName"].ToString();
                        aCustomer.complain = reader["CustomerComplain"].ToString();
                        aCustomer.status = reader["CustomerSerial"].ToString();

                   

                    serialDequeueTextBox.Text = aCustomer.serialNo;
                        nameDequeueTextBox.Text = aCustomer.name;
                        complainDequeueTextBox.Text = aCustomer.complain;
                        customerListView.Items.RemoveAt(0);
                    }
                }
                Connection.Close();
            }
        }
        }
    }

