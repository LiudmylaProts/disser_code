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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand SelectAllReferences = new SqlCommand("SELECT * FROM Bibliography");
        SqlDataReader readArticles;
        SqlCommand SelectArticles = new SqlCommand("SELECT * FROM Articles");
        SqlDataReader readRefAuthor;
        SqlCommand SelectRefAuthors = new SqlCommand("SELECT * FROM Authors");

        public Window4()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            sqlConnection3.Open();
            sqlConnection4.Open();
            SelectAllReferences.Connection = sqlConnection1;
            reader = SelectAllReferences.ExecuteReader();
            SelectArticles.Connection = sqlConnection2;
            readArticles = SelectArticles.ExecuteReader();
            SelectRefAuthors.Connection = sqlConnection3;
            readRefAuthor = SelectRefAuthors.ExecuteReader();

            while ((readArticles.Read())&&(readArticles.HasRows))
            {
                ComboBoxItem cboxArticle = new ComboBoxItem();
                cboxArticle.Content = readArticles["Name"];
                cboxArticle.Tag = readArticles["ID"];
                Articles.Items.Add(cboxArticle);
                
                ComboBoxItem cboxRefArticle = new ComboBoxItem();
                cboxRefArticle.Content = readArticles["Name"];
                cboxRefArticle.Tag = readArticles["ID"];
                RefArticle.Items.Add(cboxRefArticle);
            }

            while ((readRefAuthor.Read())&&(readRefAuthor.HasRows))
            {
                ComboBoxItem cboxAuthor = new ComboBoxItem();
                string a = readRefAuthor["FirstName"].ToString();
                string b = readRefAuthor["LastName"].ToString();
                cboxAuthor.Content = a + " " + b;
                cboxAuthor.Tag = readRefAuthor["ID"];
                RefAuthor.Items.Add(cboxAuthor);
            }
        }
        
        void WriteTextBlockFromReader()
        {
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["ArticleID"].ToString();
                textBox3.Text = reader["ArticleRefID"].ToString();
                textBox4.Text = reader["ArticleRefName"].ToString();
                textBox5.Text = reader["ArticleRefAuthorID"].ToString();
                textBox6.Text = reader["ArticleRefSource"].ToString();
                textBox7.Text = reader["ArticleRefYear"].ToString();                
            }
            else
            {
                reader.Close();
                reader = SelectAllReferences.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["ArticleID"].ToString();
                    textBox3.Text = reader["ArticleRefID"].ToString();
                    textBox4.Text = reader["ArticleRefName"].ToString();
                    textBox5.Text = reader["ArticleRefAuthorID"].ToString();
                    textBox6.Text = reader["ArticleRefSource"].ToString();
                    textBox7.Text = reader["ArticleRefYear"].ToString();
                }
            }
        }
        private void NextReference_Click(object sender, RoutedEventArgs e)
        {
            WriteTextBlockFromReader();

            foreach (object articleItem in Articles.Items)
            {
                ComboBoxItem currentArticle = articleItem as ComboBoxItem;
                if (currentArticle.Tag.ToString() == textBox2.Text)
                {
                    currentArticle.IsSelected = true;
                }
            }

            foreach (object refArticleItem in RefArticle.Items)
            {
                ComboBoxItem currentRefArticle = refArticleItem as ComboBoxItem;
                if (currentRefArticle.Tag.ToString()==textBox3.Text)
                {
                    currentRefArticle.IsSelected = true;
                }
            }

            foreach (object refAuthor in RefAuthor.Items)
            {
                ComboBoxItem currentRefAuthor = refAuthor as ComboBoxItem;
                if (currentRefAuthor.Tag.ToString() == textBox5.Text)
                {
                    currentRefAuthor.IsSelected = true;
                }
            }
        }

        private void UpdateReference_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedArticle = Articles.SelectedItem as ComboBoxItem;
            string c = selectedArticle.Tag.ToString();
            ComboBoxItem selectedRefArticle = RefArticle.SelectedItem as ComboBoxItem;
            string d = selectedRefArticle.Tag.ToString();
            ComboBoxItem selectedRefAuthor = RefAuthor.SelectedItem as ComboBoxItem;
            string f = selectedRefAuthor.Tag.ToString();

            SqlCommand UpdateReferenceContent = new SqlCommand("UPDATE Authors SET ArticleID='" + c + "', ArticleRefID='" + d + "', ArticleRefName='" + textBox4.Text + "', ArticleRefAuthorID='" + f + "', ArticleRefSource='" + textBox6.Text + "', ArticleRefYear='" + textBox7.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateReferenceContent.Connection = sqlConnection4;
            UpdateReferenceContent.ExecuteNonQuery();
        }

        private void AddNewReference_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddReference = new SqlCommand("INSERT INTO References (ArticleRefName) values('" + textBox.Text + "')");
            AddReference.Connection = sqlConnection4;
            AddReference.ExecuteNonQuery();
        }

        private void DeleteReference_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteReference = new SqlCommand("DELETE FROM References WHERE ID = '" + reader["ID"] + "'");
            DeleteReference.Connection = sqlConnection4;
            DeleteReference.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }
    }
}
