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
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class CareerChanges : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand SelectAllCareers = new SqlCommand("SELECT * FROM CareerChanges");

        SqlCommand SelectAllAutors = new SqlCommand("SELECT * FROM Authors");
        SqlDataReader readAuthor; 

        

        public CareerChanges()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            sqlConnection3.Open();
            SelectAllCareers.Connection = sqlConnection1;
            reader = SelectAllCareers.ExecuteReader();
            SelectAllAutors.Connection = sqlConnection3;
            readAuthor = SelectAllAutors.ExecuteReader();

            while ((readAuthor.Read())&&(readAuthor.HasRows))
            {
                ComboBoxItem cboxauthor = new ComboBoxItem();
                string q = readAuthor["FirstName"].ToString();
                string w = readAuthor["Lastname"].ToString();

                cboxauthor.Content = q + " " + w;
                cboxauthor.Tag = readAuthor["ID"];
                Author.Items.Add(cboxauthor);
                 
            }
        }

        void WriteTextBlockFromReader()
        {
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["AuthorID"].ToString();
                textBox3.Text = reader["Degree"].ToString();
                textBox4.Text = reader["Position"].ToString();
                textBox5.Text = reader["IsCurrent"].ToString();
                textBox6.Text = reader["ChangeYear"].ToString();                
            }

            else
            {
                reader.Close();
                reader = SelectAllCareers.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["AuthorID"].ToString();
                    textBox3.Text = reader["Degree"].ToString();
                    textBox4.Text = reader["Position"].ToString();
                    textBox5.Text = reader["IsCurrent"].ToString();
                    textBox6.Text = reader["ChangeYear"].ToString();
                }
            }
        }

        private void NextCareerChange_Click(object sender, RoutedEventArgs e)
        {
            WriteTextBlockFromReader();
            foreach (object authorItem in Author.Items)
            {
                ComboBoxItem currentAuthor = authorItem as ComboBoxItem;
                if (currentAuthor.Tag.ToString() == textBox2.Text)
                {
                    currentAuthor.IsSelected = true;
                }
            }
        }

        private void UpdateCareer_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectAuthor = Author.SelectedItem as ComboBoxItem;
            string selectedAuthor = selectAuthor.Tag.ToString();

            SqlCommand UpdateCareerContent = new SqlCommand("UPDATE CereerChanges SET AuthorID='" + selectedAuthor + "', Degree='" + textBox3.Text + "', Position='" + textBox4.Text + "', IsCurrent='" + textBox5.Text + "', ChangeYear='" + textBox6.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateCareerContent.Connection = sqlConnection2;
            UpdateCareerContent.ExecuteNonQuery();
        }

        private void AddNewCareer_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddCareer = new SqlCommand("INSERT INTO CareerChanges (Degree) values('" + textBox.Text + "')");
            AddCareer.Connection = sqlConnection2;
            AddCareer.ExecuteNonQuery();
        }

        private void DeleteCareer_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteCareer = new SqlCommand("DELETE FROM CareerChanges WHERE ID = '" + reader["ID"] + "'");
            DeleteCareer.Connection = sqlConnection2;
            DeleteCareer.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }
    }
}
