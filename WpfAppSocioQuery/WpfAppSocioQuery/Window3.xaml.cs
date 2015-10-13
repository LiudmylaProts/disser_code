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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand SelectAllKeywords = new SqlCommand("SELECT * FROM Keywords");

        SqlCommand SelectArticles = new SqlCommand("SELECT * FROM Articles");
        SqlDataReader readArticle;

        
        public Window3()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            sqlConnection3.Open();

            SelectAllKeywords.Connection = sqlConnection1;
            reader = SelectAllKeywords.ExecuteReader();
            SelectArticles.Connection = sqlConnection3;
            readArticle = SelectArticles.ExecuteReader();

            while ((readArticle.Read()) && (readArticle.HasRows))
            {
                ComboBoxItem cboxarticle = new ComboBoxItem();
                cboxarticle.Content = readArticle["Name"];
                cboxarticle.Tag = readArticle["ID"];
                Articles.Items.Add(cboxarticle);
            }
        }

        void WriteTextBlockFromReader()
        {
            if ((reader.Read()) && (reader.HasRows))
            {
                textBox1.Text = reader["ID"].ToString();
                textBox2.Text = reader["ArticleID"].ToString();
                textBox3.Text = reader["Word"].ToString();
               
            }
            else
            {
                reader.Close();
                reader = SelectAllKeywords.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBox1.Text = reader["ID"].ToString();
                    textBox2.Text = reader["ArticleID"].ToString();
                    textBox3.Text = reader["Word"].ToString();
                }
            }
        }

        private void NextKeyword_Click(object sender, RoutedEventArgs e)
        {
            WriteTextBlockFromReader();
            foreach (object item in Articles.Items)
            {
                ComboBoxItem currentarticle = item as ComboBoxItem;
                if (currentarticle.Tag.ToString() == textBox2.Text)
                {
                    currentarticle.IsSelected = true;
                }
            }
        }

        private void UpdateKeyword_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectArticle = Articles.SelectedItem as ComboBoxItem;
            string a = selectArticle.Tag.ToString();

            SqlCommand UpdateKeywordContent = new SqlCommand("UPDATE Keywords SET ArticleID='" + a + "', Word='" + textBox3.Text + "' WHERE ID='" + reader["ID"] + "'");
            UpdateKeywordContent.Connection = sqlConnection2;
            UpdateKeywordContent.ExecuteNonQuery();
        }

        private void AddNewKeyword_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand AddKeyword = new SqlCommand("INSERT INTO Keywords (Word) values('" + textBox.Text + "')");
            AddKeyword.Connection = sqlConnection2;
            AddKeyword.ExecuteNonQuery();
        }

        private void DeleteKeyword_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand DeleteKeyword = new SqlCommand("DELETE FROM Keywords WHERE ID = '" + reader["ID"] + "'");
            DeleteKeyword.Connection = sqlConnection2;
            DeleteKeyword.ExecuteNonQuery();
            WriteTextBlockFromReader();
        }
    }
}
