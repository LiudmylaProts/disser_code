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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppSocioQuery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM Articles");
        
        public MainWindow()
        {
            InitializeComponent();

            sqlConnection1.Open();
            sqlConnection2.Open();
            //sqlConnection3.Open();
            //sqlConnection4.Open();
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
        }

        void WriteTextBlockFromReader()
        {            
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["Language"].ToString();
                textBox3.Text = reader["Name"].ToString();
                textBox4.Text = reader["Annotation"].ToString();
                textBox5.Text = reader["DigestID"].ToString();
            }
            else
            {
                reader.Close();
                reader = cmd.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["Language"].ToString();
                    textBox3.Text = reader["Name"].ToString();
                    textBox4.Text = reader["Annotation"].ToString();
                    textBox5.Text = reader["DigestID"].ToString();
                }
            }
        } 

        private void query_Click(object sender, RoutedEventArgs e)
        {
            /*Button F;
            if (sender is Button)
            {
                F = (Button)sender;
            }

            Button D = sender as Button; преобразование типов*/


            WriteTextBlockFromReader();
             
        }
                                        
        private void AddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddArticle = new SqlCommand("INSERT INTO Articles(Language, Name, Annotation) values('ua', '"+ textBox.Text + "', 'blabla')");
            AddArticle.Connection = sqlConnection2;
            AddArticle.ExecuteNonQuery();
        }
                
        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteArticle = new SqlCommand("DELETE FROM Articles WHERE ID = '"+reader ["ID"]+"'");
            DeleteArticle.Connection = sqlConnection2;
            DeleteArticle.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }

        private void UpdateArticles_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand UpdateArticleContent = new SqlCommand("UPDATE Articles SET Language='" + textBox2.Text + "', Name='" + textBox3.Text + "', Annotation='" + textBox4.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateArticleContent.Connection = sqlConnection2;
            UpdateArticleContent.ExecuteNonQuery();
        }

        ~MainWindow()
        {
            sqlConnection1.Close();
        }

        
    }
    




}


