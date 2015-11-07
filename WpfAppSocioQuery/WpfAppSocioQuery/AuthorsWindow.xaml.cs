using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AuthorsWindow : Window
    {

        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand SelectAllAutors = new SqlCommand("SELECT * FROM Authors");

        public AuthorsWindow()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            SelectAllAutors.Connection = sqlConnection1;
            reader = SelectAllAutors.ExecuteReader();
        }

        void WriteTextBlockFromReader()
        {
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["FirstName"].ToString();
                textBox3.Text = reader["FirstNameRu"].ToString();
                textBox4.Text = reader["FirstNameEn"].ToString();
                textBox5.Text = reader["MiddleName"].ToString();
                textBox6.Text = reader["MiddleNameRu"].ToString();
                textBox7.Text = reader["MiddleNameEn"].ToString();
                textBox8.Text = reader["LastName"].ToString();
                textBox9.Text = reader["LastNameRu"].ToString();
                textBox10.Text = reader["LastNameEn"].ToString();
            }
            else
            {
                reader.Close();
                reader = SelectAllAutors.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["FirstName"].ToString();
                    textBox3.Text = reader["FirstNameRu"].ToString();
                    textBox4.Text = reader["FirstNameEn"].ToString();
                    textBox5.Text = reader["MiddleName"].ToString();
                    textBox6.Text = reader["MiddleNameRu"].ToString();
                    textBox7.Text = reader["MiddleNameEn"].ToString();
                    textBox8.Text = reader["LastName"].ToString();
                    textBox9.Text = reader["LastNameRu"].ToString();
                    textBox10.Text = reader["LastNameEn"].ToString();
                }
            }
        }

        private void NextAuthor_Click(object sender, RoutedEventArgs e)
        {
            WriteTextBlockFromReader();
        }

        private void UpdateAuthor_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand UpdateAuthorContent = new SqlCommand("UPDATE Authors SET FirstName='" + textBox2.Text + "', FirstNameRu='" + textBox3.Text + "', FirstNameEn='" + textBox4.Text + "', MiddleName='" + textBox5.Text + "', MiddleNameRu='" + textBox6.Text + "', MiddleNameEn='" + textBox7.Text + "', LastName='" + textBox8.Text + "', LastNameRu='" + textBox9.Text + "', LastNameEn='" + textBox10.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateAuthorContent.Connection = sqlConnection2;
            UpdateAuthorContent.ExecuteNonQuery();
        }

        private void AddNewAuthor_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddAuthor = new SqlCommand("INSERT INTO Authors (FirstName) values('" + textBox.Text + "')");
            AddAuthor.Connection = sqlConnection2;
            AddAuthor.ExecuteNonQuery();
        }

        private void DeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteAuthor = new SqlCommand("DELETE FROM Authors WHERE ID = '" + reader["ID"] + "'");
            DeleteAuthor.Connection = sqlConnection2;
            DeleteAuthor.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }

        
    }
}
