using System;
using System.Collections;
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
        SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlConnection sqlConnection5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand cmd = new SqlCommand("SELECT * FROM Articles");
        SqlCommand SelectDigest = new SqlCommand("SELECT * FROM Digests");
        SqlDataReader ReadDigest;
        SqlDataReader readAuthors;
        SqlCommand selectAuthors = new SqlCommand("SELECT a.*, CASE WHEN aa.ArticleID = '6d631377-b0d6-4006-954a-c04f02303cf7' THEN 1 ELSE 0 END AS 'IsCurrent' FROM Authors AS a LEFT OUTER JOIN ArticleAuthors AS aa ON aa.AuthorID = a.ID ORDER BY IsCurrent DESC"); 

        public MainWindow()
        {
            InitializeComponent();
            sqlConnection1.Open();
            sqlConnection2.Open();
            sqlConnection3.Open();
            sqlConnection4.Open();
            sqlConnection5.Open();
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            SelectDigest.Connection = sqlConnection3;
            ReadDigest = SelectDigest.ExecuteReader();
            selectAuthors.Connection = sqlConnection4;
           // readAuthors = selectAuthors.ExecuteReader();


            while ((ReadDigest.Read()) && (ReadDigest.HasRows))
            {
                ComboBoxItem cboxitem = new ComboBoxItem();
                cboxitem.Content = ReadDigest["Name"];
                cboxitem.Tag = ReadDigest["ID"];
                Digest.Items.Add(cboxitem);                         
            }            
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

            Authors.Items.Clear();
            selectAuthors.CommandText = "SELECT DISTINCT a.*, CASE WHEN aa.ArticleID = '" + reader["ID"] + "' THEN 1 ELSE 0 END AS 'IsCurrent' FROM Authors AS a LEFT OUTER JOIN ArticleAuthors AS aa ON aa.AuthorID = a.ID ORDER BY IsCurrent DESC";
            readAuthors = selectAuthors.ExecuteReader();
           
            while ((readAuthors.Read()) && (readAuthors.HasRows))
            {
                ListBoxItem lboxAuthor = new ListBoxItem();
                string a = readAuthors["FirstName"].ToString();
                string b = readAuthors["LastName"].ToString();

                lboxAuthor.Content = a + " " + b;
                lboxAuthor.Tag = readAuthors["ID"];
                Authors.Items.Add(lboxAuthor);

                if (readAuthors["IsCurrent"].ToString() == "1")
                {
                    lboxAuthor.IsSelected = true;
                }                            
            }
            
                        
            readAuthors.Close();

            foreach (object item in Digest.Items)
            {
                ComboBoxItem a = item as ComboBoxItem;
                if (a.Tag.ToString() == reader["DigestID"].ToString())
                {
                    a.IsSelected = true;
                }
            }                       
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
            ComboBoxItem selecteddigest = Digest.SelectedItem as ComboBoxItem;
            string c = selecteddigest.Tag.ToString();
            SqlCommand UpdateArticleContent = new SqlCommand("UPDATE Articles SET Language='" + textBox2.Text + "', Name='" + textBox3.Text + "', DigestID='" + c + "', Annotation='" + textBox4.Text + "' WHERE ID= '" + reader["ID"] + "'");
            UpdateArticleContent.Connection = sqlConnection2;
            UpdateArticleContent.ExecuteNonQuery();

            foreach (object lboxAuthorItem in Authors.Items)
            {
                ListBoxItem authorItem = lboxAuthorItem as ListBoxItem;
                SqlCommand CountArticleAuthorsLinked = new SqlCommand("SELECT COUNT(*) FROM ArticleAuthors WHERE ArticleID = '" + reader["ID"] + "' AND AuthorID = '" + authorItem.Tag + "'");
                CountArticleAuthorsLinked.Connection = sqlConnection5;

                int s = (int)CountArticleAuthorsLinked.ExecuteScalar();

                if ((s == 1)&&(authorItem.IsSelected == false))
                {
                    SqlCommand DeleteArticleAuthorLink = new SqlCommand("DELETE FROM ArticleAuthors WHERE ArticleID = '" + reader["ID"] + "' AND AuthorID = '" + authorItem.Tag + "'");
                    DeleteArticleAuthorLink.Connection = sqlConnection5;
                    DeleteArticleAuthorLink.ExecuteNonQuery();
                }

                if ((s != 1)&&(authorItem.IsSelected))
                {
                    SqlCommand InsertArticleAuthorLink = new SqlCommand("INSERT INTO ArticleAuthors (ArticleID, AuthorID) VALUES ('" + reader["ID"] + "' , '" + authorItem.Tag + "')");
                    InsertArticleAuthorLink.Connection = sqlConnection5;
                    InsertArticleAuthorLink.ExecuteNonQuery();
                }
            }
                                   
            //Guid.Parse(c);
            //SqlCommand SaveDigestID = new SqlCommand("UPDATE Articles SET DigestID = '" + c + "' WHERE ID = '" + reader["ID"] + "'");
            //SaveDigestID.Connection = sqlConnection2;
            //SaveDigestID.ExecuteNonQuery();
        }

        

       // ~MainWindow()
       //{
       //  reader.Close();
       //sqlConnection1.Close();
       //sqlConnection2.Close();
       //}

        

        private void ToAuthors_Click(object sender, RoutedEventArgs e)
        {
            Window Window1 = new Window1();
            Window1.Show();
        }

        private void ToDigests_Click(object sender, RoutedEventArgs e)
        {
            Window Window2 = new Window2();
            Window2.Show();

        }

        private void ToKeywords_Click(object sender, RoutedEventArgs e)
        {
            Window Window3 = new Window3();
            Window3.Show();
        }

        private void ToReferences_Click(object sender, RoutedEventArgs e)
        {
            Window Window4 = new Window4();
            Window4.Show();
        }

        private void ToCareerChanges_Click(object sender, RoutedEventArgs e)
        {
            Window Window5 = new Window5();
            Window5.Show();
        }

        
    }
    
    



}


