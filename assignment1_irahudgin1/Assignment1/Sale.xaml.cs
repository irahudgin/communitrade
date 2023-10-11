using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Sale : Window
    {
        public static NpgsqlConnection con;
        public static NpgsqlCommand cmd;
        public Sale()
        {
            InitializeComponent();
            confirmSale.IsEnabled = false;
        }
        

        private void establishConnect()
        {
            // need to install postgresql adapter/library from packageManager
            // NpgSQL
            // create instances of connector and command adapter

            try
            {
                con = new NpgsqlConnection(get_ConnectionString());
            }
            catch (NpgsqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private string get_ConnectionString()
        {
            // pass 5 values: host, port, dbName, userName, password

            string host = "Host=localhost;";
            string port = "Port=5432;";
            string dbName = "Database=producePro;";
            string userName = "Username=postgres;";
            string password = "Password=irahudgin;";

            string connectionString = string.Format("{0}{1}{2}{3}{4}", host, port, dbName, userName, password);
            return connectionString;
        }

        private void calculateTotal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                int prodId = int.Parse(productId.Text);

                string query = "select amount from produce where product_id = @prodId";
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                double amountProduce = 0;
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    amountProduce = double.Parse(dr["amount"].ToString());
                }

                double amountRequested = double.Parse(amountKg.Text);

                if ((amountProduce - amountRequested) < 0)
                {
                    con.Close();
                    MessageBox.Show("Not enough produce in stock. Check stock and try again");
                    Sale newSale = new Sale();
                    newSale.Show();
                    this.Close();
                    return;
                }

                con.Close();
                con.Open();

                query = "select price from produce where product_id = @pId";
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pId", int.Parse(productId.Text));
                bool noData = true;
                dr = cmd.ExecuteReader();
                string priceStr = "";
                 
                while (dr.Read())
                {
                    noData = false;
                    priceStr = dr["price"].ToString();
                }
                if (noData)
                {
                    MessageBox.Show("Cannot find produce");
                }

                double priceMulti = double.Parse(priceStr);
                double priceTotal = priceMulti * double.Parse(amountKg.Text);
                total.Text = priceTotal.ToString();
                /// MessageBox.Show(priceTotal.ToString());
                confirmSale.IsEnabled = true;


                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void confirmSale_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                double totalDoub = double.Parse(total.Text);
                double amountDoub = double.Parse(amountKg.Text);
                int prodId = int.Parse(productId.Text);
                string customerName = custName.Text;

                string query = "insert into sale values (default, @custname, @prodId, @amountBought)";
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@custname", customerName);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                cmd.Parameters.AddWithValue("@amountBought", amountDoub);

                NpgsqlDataReader dr = cmd.ExecuteReader();
                con.Close();
                con.Open();

                query = "update produce set amount = amount - @amount where product_id = @prodId";
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@prodId", prodId);
                cmd.Parameters.AddWithValue("@amount", amountDoub);
                dr = cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Sale Confirmed!");
                Sale newSale = new Sale();
                newSale.Show();
                this.Close();
                Admin adminWindow = new Admin();
                adminWindow.Show();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
