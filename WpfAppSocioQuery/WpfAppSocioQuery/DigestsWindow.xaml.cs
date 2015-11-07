using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace WpfAppSocioQuery
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class DigestsWindow : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand SelectAllDigests = new SqlCommand("SELECT * FROM Digests");
        DataSet digestsSet;

        public DigestsWindow()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            SelectAllDigests.Connection = sqlConnection1;
            reader = SelectAllDigests.ExecuteReader();

            Window qwe = Application.Current.MainWindow;
            ArticlesWindow articlesWindow = (ArticlesWindow)qwe;
            digestsSet = articlesWindow.digestsSet;
        }

        void WriteTextBlockFromReader()
        {
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["Name"].ToString();
                textBox3.Text = reader["Type"].ToString();
                textBox4.Text = reader["Number"].ToString();
                textBox5.Text = reader["Year"].ToString();
                textBox6.Text = reader["City"].ToString();
                textBox7.Text = reader["Publisher"].ToString();
                textBox8.Text = reader["TotalPages"].ToString();
                
            }
            else
            {
                reader.Close();
                reader = SelectAllDigests.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["Name"].ToString();
                    textBox3.Text = reader["Type"].ToString();
                    textBox4.Text = reader["Number"].ToString();
                    textBox5.Text = reader["Year"].ToString();
                    textBox6.Text = reader["City"].ToString();
                    textBox7.Text = reader["Publisher"].ToString();
                    textBox8.Text = reader["TotalPages"].ToString();
                }
            }
        }

        private void NextDigest_Click(object sender, RoutedEventArgs e)
        {
            WriteTextBlockFromReader();
        }

        private void UpdateDigest_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand UpdateDigestContent = new SqlCommand("UPDATE Digests SET Name='" + textBox2.Text + "', Type='" + textBox3.Text + "', Number='" + textBox4.Text + "', Year='" + textBox5.Text + "', City='" + textBox6.Text + "', Publisher='" + textBox7.Text + "', TotalPages='" + textBox8.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateDigestContent.Connection = sqlConnection2;
            UpdateDigestContent.ExecuteNonQuery();
        }

        private void AddNewDigest_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddDigest = new SqlCommand("INSERT INTO Digests (Name) values('" + textBox.Text + "')");
            AddDigest.Connection = sqlConnection2;
            AddDigest.ExecuteNonQuery();
        }

        private void DeleteDigest_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteDigest = new SqlCommand("DELETE FROM Digests WHERE ID = '" + reader["ID"] + "'");
            DeleteDigest.Connection = sqlConnection2;
            DeleteDigest.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }
    }
}
