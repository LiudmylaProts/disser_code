using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppSocioQuery
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class ArticlesWindow : Window
    {
        SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection2 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        //SqlConnection sqlConnection5 = new SqlConnection(@"Data Source=.\SQLEXPRESS;User ID=sa;Password=badazok0;Initial Catalog=Sociobase");
        SqlDataReader reader;
        SqlCommand selectArticlesCmd = new SqlCommand("SELECT * FROM Articles");
        SqlCommand selectDigestsCmd = new SqlCommand("SELECT * FROM Digests");
        SqlDataReader ReadDigest;
        SqlDataReader readAuthors;
        SqlCommand selectAuthorsCmd = new SqlCommand("SELECT a.*, CASE WHEN aa.ArticleID = '6d631377-b0d6-4006-954a-c04f02303cf7' THEN 1 ELSE 0 END AS 'IsCurrent' FROM Authors AS a LEFT OUTER JOIN ArticleAuthors AS aa ON aa.AuthorID = a.ID ORDER BY IsCurrent DESC");
        DataSet articlesSet = new DataSet();
        DataSet digestsSet = new DataSet();
        DataSet authorsSet = new DataSet();
        
        void RefreshArticles()
        {
            selectArticlesCmd.Connection = sqlConnection1;
            SqlDataAdapter articlesAdapter = new SqlDataAdapter(selectArticlesCmd);
            articlesAdapter.Fill(articlesSet, "Articles");
                        
            foreach (DataRow articlesRow in articlesSet.Tables[0].Rows)
            {
                ListBoxItem lboxArticle = new ListBoxItem();
                
                lboxArticle.Content = articlesRow["Name"];
                lboxArticle.Tag = articlesRow["ID"];
                ArticlesListbox.Items.Add(lboxArticle);
            }

        }

        void RefreshDigests()
        {
            selectDigestsCmd.Connection = sqlConnection1;
            SqlDataAdapter digestsAdapter = new SqlDataAdapter(selectDigestsCmd);
            digestsAdapter.Fill(digestsSet, "Digests");

            foreach (DataRow digestsRow in digestsSet.Tables[0].Rows)
            {
                ComboBoxItem cboxDigest = new ComboBoxItem();
                cboxDigest.Content = digestsRow["Name"];
                cboxDigest.Tag = digestsRow["ID"];
                Digest.Items.Add(cboxDigest);                                 
            }

        }

        void RefreshAuthors(string selectedArticleID)
        {
            SqlCommand selectAuthorsCmd = new SqlCommand("SELECT a.ID, a.FirstName, a.LastName, COUNT(aa.ArticleID) AS 'IsCurrent' FROM Authors a LEFT OUTER JOIN ArticleAuthors aa ON aa.AuthorID = a.ID AND aa.ArticleID = '" + selectedArticleID + "' GROUP BY a.ID, a.FirstName, a.LastName ORDER BY IsCurrent DESC");
            selectAuthorsCmd.Connection = sqlConnection1;
            SqlDataAdapter authorsAdapter = new SqlDataAdapter(selectAuthorsCmd);
            authorsSet.Clear(); 
            authorsAdapter.Fill(authorsSet, "Authors");
            Authors.Items.Clear();
            foreach (DataRow authorsRow in authorsSet.Tables[0].Rows)
            {
                ListBoxItem lboxAuthor = new ListBoxItem();
                string a = authorsRow["FirstName"].ToString();
                string b = authorsRow["LastName"].ToString();
                lboxAuthor.Content = a + " " + b; ;
                lboxAuthor.Tag = authorsRow["ID"];                
                if (authorsRow["IsCurrent"].ToString() == "1")
                    lboxAuthor.IsSelected = true;
                Authors.Items.Add(lboxAuthor);
            }
                          
        }

        public ArticlesWindow()
        {
            InitializeComponent();
            //sqlConnection1.Open();
            //sqlConnection2.Open();
            //sqlConnection3.Open();
            //sqlConnection4.Open();
            //sqlConnection5.Open();
            //selectArticlesCmd.Connection = sqlConnection1;
            //reader = selectArticlesCmd.ExecuteReader();
            //SelectDigest.Connection = sqlConnection3;
            //ReadDigest = SelectDigest.ExecuteReader();
            //selectAuthors.Connection = sqlConnection4;
            //readAuthors = selectAuthors.ExecuteReader();


            //while ((ReadDigest.Read()) && (ReadDigest.HasRows))
            //{
            //    ComboBoxItem cboxitem = new ComboBoxItem();
            //    cboxitem.Content = ReadDigest["Name"];
            //    cboxitem.Tag = ReadDigest["ID"];
            //    Digest.Items.Add(cboxitem);                         
            //}            

            RefreshArticles();
            RefreshDigests();
            
        }                 
                    
        void WriteTextBlockFromReader()
        {            
            if ((reader.Read()) && (reader.HasRows))
            {
                textBoxID.Text = reader["ID"].ToString();
                textBoxLanguage.Text = reader["Language"].ToString();
                textBoxName.Text = reader["Name"].ToString();
                textBoxAnnotation.Text = reader["Annotation"].ToString();
                textBoxDigestID.Text = reader["DigestID"].ToString();
            }
            else
            {
                reader.Close();
                reader = selectArticlesCmd.ExecuteReader();

                if ((reader.Read()) && (reader.HasRows))
                {
                    textBoxID.Text = reader["ID"].ToString();
                    textBoxLanguage.Text = reader["Language"].ToString();
                    textBoxName.Text = reader["Name"].ToString();
                    textBoxAnnotation.Text = reader["Annotation"].ToString();
                    textBoxDigestID.Text = reader["DigestID"].ToString();
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
            selectAuthorsCmd.CommandText = "SELECT a.ID, a.FirstName, a.LastName, COUNT(aa.ArticleID) AS 'IsCurrent' FROM Authors a LEFT OUTER JOIN ArticleAuthors aa ON aa.AuthorID = a.ID AND aa.ArticleID = '" + reader["ID"] + "' GROUP BY a.ID, a.FirstName, a.LastName ORDER BY IsCurrent DESC";
            readAuthors = selectAuthorsCmd.ExecuteReader();
           
            //while ((readAuthors.Read()) && (readAuthors.HasRows))
            //{
            //    ListBoxItem lboxAuthor = new ListBoxItem();
            //    string a = readAuthors["FirstName"].ToString();
            //    string b = readAuthors["LastName"].ToString();

            //    lboxAuthor.Content = a + " " + b;
            //    lboxAuthor.Tag = readAuthors["ID"];
            //    Authors.Items.Add(lboxAuthor);

            //           
            //}
            
                        
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
                                        
        //private void AddNewArticle_Click(object sender, RoutedEventArgs e)
        //{
        //    SqlCommand AddArticle = new SqlCommand("INSERT INTO Articles(Language, Name, Annotation) values('ua', '"+ textBox.Text + "', 'blabla')");
        //    AddArticle.Connection = sqlConnection2;
        //    AddArticle.ExecuteNonQuery();
        //}
                
        //private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        //{
        //    SqlCommand DeleteArticle = new SqlCommand("DELETE FROM Articles WHERE ID = '"+reader ["ID"]+"'");
        //    DeleteArticle.Connection = sqlConnection2;
        //    DeleteArticle.ExecuteNonQuery();
        //    WriteTextBlockFromReader();
        //}


        private void UpdateArticles_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selecteddigest = Digest.SelectedItem as ComboBoxItem;
            string c = selecteddigest.Tag.ToString();
            SqlCommand UpdateArticleContent = new SqlCommand("UPDATE Articles SET Language='" + textBoxLanguage.Text + "', Name='" + textBoxName.Text + "', DigestID='" + c + "', Annotation='" + textBoxAnnotation.Text + "' WHERE ID= '" + reader["ID"] + "'");
            UpdateArticleContent.Connection = sqlConnection1;
            UpdateArticleContent.ExecuteNonQuery();

            foreach (object lboxAuthorItem in Authors.Items)
            {
                ListBoxItem authorItem = lboxAuthorItem as ListBoxItem;
                SqlCommand CountArticleAuthorsLinked = new SqlCommand("SELECT COUNT(*) FROM ArticleAuthors WHERE ArticleID = '" + reader["ID"] + "' AND AuthorID = '" + authorItem.Tag + "'");
                CountArticleAuthorsLinked.Connection = sqlConnection1;

                int s = (int)CountArticleAuthorsLinked.ExecuteScalar();

                if ((s == 1)&&(authorItem.IsSelected == false))
                {
                    SqlCommand DeleteArticleAuthorLink = new SqlCommand("DELETE FROM ArticleAuthors WHERE ArticleID = '" + reader["ID"] + "' AND AuthorID = '" + authorItem.Tag + "'");
                    DeleteArticleAuthorLink.Connection = sqlConnection1;
                    DeleteArticleAuthorLink.ExecuteNonQuery();
                }

                if ((s != 1)&&(authorItem.IsSelected))
                {
                    SqlCommand InsertArticleAuthorLink = new SqlCommand("INSERT INTO ArticleAuthors (ArticleID, AuthorID) VALUES ('" + reader["ID"] + "' , '" + authorItem.Tag + "')");
                    InsertArticleAuthorLink.Connection = sqlConnection1;
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

       
        private void ArticlesListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedArticle = (ListBoxItem)e.AddedItems[0];
            string s = selectedArticle.Tag.ToString();
            foreach (DataRow articlesRow in articlesSet.Tables[0].Rows)
            {
                if (articlesRow["ID"].ToString() == selectedArticle.Tag.ToString())
                {
                    textBoxID.Text = articlesRow["ID"].ToString();
                    textBoxLanguage.Text = articlesRow["Language"].ToString();
                    textBoxName.Text = articlesRow["Name"].ToString();
                    textBoxAnnotation.Text = articlesRow["Annotation"].ToString();
                    textBoxDigestID.Text = articlesRow["DigestID"].ToString();

                foreach (ComboBoxItem currentDigestItem in Digest.Items)
                {
                   if (currentDigestItem.Tag.ToString() == articlesRow["DigestID"].ToString())
                            currentDigestItem.IsSelected = true;
                   else
                            currentDigestItem.IsSelected = false;
                        
                }
                }
            }
            RefreshAuthors(s);
            
        }
    }
    



}


