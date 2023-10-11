using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            refreshGrid();
        }

        public static NpgsqlConnection con;
        public static NpgsqlCommand cmd;


        private void saleWindow_Click(object sender, RoutedEventArgs e)
        {
            Sale saleWindow = new Sale();
            saleWindow.Show();
            this.Close();
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                string query = "select * from produce where product_id=@pId";
                cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pId", int.Parse(search.Text));
                bool noData = true;
                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    noData = false;
                    product.Text = dr["name"].ToString();
                    productID.Text = dr["product_id"].ToString();
                    amount.Text = dr["amount"].ToString();
                    price.Text = dr["price"].ToString();
                    dataID.Text = dr["produce_id"].ToString();
                }

                if (noData)
                {
                    MessageBox.Show("Cannot find produce");
                }
                con.Close();
            } catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void refreshGrid()
        {
            try
            {
                establishConnect();

                con.Open();
                string query = "select * from produce;";
                cmd = new NpgsqlCommand(query, con);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // send dataTable information to datagrid itemsource
                dataGrid.ItemsSource = dt.AsDataView();

                DataContext = da;
                con.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                string query = "insert into produce values (default, @name, @pId, @amount, @price);";

                cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", product.Text);
                cmd.Parameters.AddWithValue("@pId", int.Parse(productID.Text));
                cmd.Parameters.AddWithValue("@amount", double.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", double.Parse(price.Text));
               
                NpgsqlDataReader dr = cmd.ExecuteReader();

                con.Close();
                refreshGrid();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                string query = "update produce set name = @name, product_id = @pId, amount = @amount, price = @price where produce_id = @primaryID";

                cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@name", product.Text);
                cmd.Parameters.AddWithValue("@pId", int.Parse(productID.Text));
                cmd.Parameters.AddWithValue("@amount", double.Parse(amount.Text));
                cmd.Parameters.AddWithValue("@price", double.Parse(price.Text));
                cmd.Parameters.AddWithValue("@primaryID", int.Parse(dataID.Text));

                NpgsqlDataReader dr = cmd.ExecuteReader();

                con.Close();
                refreshGrid();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                establishConnect();
                con.Open();

                string query = "delete from produce where produce_id = @primaryID";

                cmd = new NpgsqlCommand(query, con);

                cmd.Parameters.AddWithValue("@primaryID", int.Parse(dataID.Text));

                NpgsqlDataReader dr = cmd.ExecuteReader();

                con.Close();
                refreshGrid();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
