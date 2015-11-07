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
        
        SqlCommand selectArticlesCmd = new SqlCommand("SELECT * FROM Articles");
        SqlCommand selectDigestsCmd = new SqlCommand("SELECT * FROM Digests");              
        SqlCommand selectAuthorsCmd = new SqlCommand("SELECT a.*, CASE WHEN aa.ArticleID = '6d631377-b0d6-4006-954a-c04f02303cf7' THEN 1 ELSE 0 END AS 'IsCurrent' FROM Authors AS a LEFT OUTER JOIN ArticleAuthors AS aa ON aa.AuthorID = a.ID ORDER BY IsCurrent DESC");
        DataSet articlesSet = new DataSet();
        public DataSet digestsSet = new DataSet();
        DataSet authorsSet = new DataSet();
        DataSet referencesSet = new DataSet();
        
        void RefreshArticles()
        {
            articlesSet.Clear();
            selectArticlesCmd.Connection = sqlConnection1;
            SqlDataAdapter articlesAdapter = new SqlDataAdapter(selectArticlesCmd);
            articlesAdapter.Fill(articlesSet, "Articles");
            ArticlesListbox.Items.Clear();

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

        void RefreshReferences(string selectedArticleID)
        {
            SqlCommand selectReferencesCmd = new SqlCommand("");
            selectReferencesCmd.Connection = sqlConnection1;
            SqlDataAdapter referencesAdapter = new SqlDataAdapter(selectReferencesCmd);
            referencesSet.Clear();
            referencesAdapter.Fill(referencesSet, "Bibliography");
            ReferencesLBox.Items.Clear();

            foreach (DataRow referencesRow in referencesSet.Tables[0].Rows)
            {
                ListBoxItem lboxReferencesItem = new ListBoxItem();                
                lboxReferencesItem.Content = referencesRow["ArticleRefName"]; 
                lboxReferencesItem.Tag = referencesRow["ID"];

                ReferencesLBox.Items.Add(lboxReferencesItem);
            }

        }
        public ArticlesWindow()
        {
            InitializeComponent();
            sqlConnection1.Open();
           
            RefreshArticles();
            RefreshDigests();            
        }                 
                    
        private void query_Click(object sender, RoutedEventArgs e)
        {
                      
        }
                                        
        private void AddNewArticle_Click(object sender, RoutedEventArgs e)
        {
            Guid newArticleId = Guid.NewGuid();
            SqlCommand AddArticle = new SqlCommand("INSERT INTO Articles(ID, Language, Name, Annotation) values('" + newArticleId.ToString() +"', '', '', '')");
            AddArticle.Connection = sqlConnection1;
            AddArticle.ExecuteNonQuery();
            RefreshArticles();
           
            ArticlesListbox.SelectedItem = ArticlesListbox.Items.Cast<ListBoxItem>().First(lbi => lbi.Tag.ToString() == newArticleId.ToString());

        }
                
        private void DeleteArticle_Click(object sender, RoutedEventArgs e)
        {
             ListBoxItem selectedArticle = ArticlesListbox.SelectedItem as ListBoxItem;
             string selectedArticleID = selectedArticle.Tag.ToString();
             SqlCommand DeleteArticle = new SqlCommand("DELETE FROM ArticleAuthors WHERE ArticleID = '" + selectedArticleID +"'; DELETE FROM Articles WHERE ID = '"+ selectedArticleID +"'");

             DeleteArticle.Connection = sqlConnection1;
             DeleteArticle.ExecuteNonQuery();
             RefreshArticles();                               
        }

        private void UpdateArticles_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selecteddigest = Digest.SelectedItem as ComboBoxItem;
            string selectedDigestID = selecteddigest.Tag.ToString();
            ListBoxItem selectedArticle = (ListBoxItem)ArticlesListbox.SelectedItem;
            string selectedArticleID = selectedArticle.Tag.ToString();
            SqlCommand UpdateArticleContent = new SqlCommand("UPDATE Articles SET Language='" + textBoxLanguage.Text + "', Name='" + textBoxName.Text + "', DigestID='" + selectedDigestID + "', Annotation='" + textBoxAnnotation.Text + "' WHERE ID= '" + selectedArticleID + "'");
            UpdateArticleContent.Connection = sqlConnection1;
            UpdateArticleContent.ExecuteNonQuery();

            foreach (object lboxAuthorItem in Authors.Items)
            {
                ListBoxItem authorItem = lboxAuthorItem as ListBoxItem;
                SqlCommand CountArticleAuthorsLinked = new SqlCommand("SELECT COUNT(*) FROM ArticleAuthors WHERE ArticleID = '" + selectedArticleID + "' AND AuthorID = '" + authorItem.Tag + "'");
                CountArticleAuthorsLinked.Connection = sqlConnection1;

                int count = (int)CountArticleAuthorsLinked.ExecuteScalar();

                if ((count == 1)&&(authorItem.IsSelected == false))
                {
                    SqlCommand DeleteArticleAuthorLink = new SqlCommand("DELETE FROM ArticleAuthors WHERE ArticleID = '" + selectedArticleID + "' AND AuthorID = '" + authorItem.Tag + "'");
                    DeleteArticleAuthorLink.Connection = sqlConnection1;
                    DeleteArticleAuthorLink.ExecuteNonQuery();
                }

                if ((count != 1)&&(authorItem.IsSelected))
                {
                    SqlCommand InsertArticleAuthorLink = new SqlCommand("INSERT INTO ArticleAuthors (ArticleID, AuthorID) VALUES ('" + selectedArticleID + "' , '" + authorItem.Tag + "')");
                    InsertArticleAuthorLink.Connection = sqlConnection1;
                    InsertArticleAuthorLink.ExecuteNonQuery();
                }               
            }                
                RefreshArticles();
                foreach(ListBoxItem lboxArticlesItem in ArticlesListbox.Items)
                {
                    if (lboxArticlesItem.Tag.ToString() == selectedArticleID)
                    {
                        lboxArticlesItem.IsSelected = true;
                    }
                }                   
           }

        private void ArticlesListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                textBoxID.Text = "";
                textBoxLanguage.Text = "";
                textBoxName.Text = "";
                textBoxAnnotation.Text = "";
                textBoxDigestID.Text = "";

                Digest.SelectedItem = null;
                Authors.SelectedItems.Clear();
                ReferencesLBox.SelectedItems.Clear();
                UpdateArticles.IsEnabled = false;
                DeleteArticle.IsEnabled = false;
                AddReference.IsEnabled = false;
                DeleteReference.IsEnabled = false;
            }
            else
            {
                ListBoxItem selectedArticle = (ListBoxItem)e.AddedItems[0];
                string selectedArticleID = selectedArticle.Tag.ToString();

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

                RefreshAuthors(selectedArticleID);
                RefreshReferences(selectedArticleID);
                UpdateArticles.IsEnabled = true;
                DeleteArticle.IsEnabled = true;
                AddReference.IsEnabled = true;
                DeleteReference.IsEnabled = true;
            }
        }

        private void ToAuthors_Click(object sender, RoutedEventArgs e)
        {
            Window authorsWindow = new AuthorsWindow();
            authorsWindow.Show();
        }

        private void ToDigests_Click(object sender, RoutedEventArgs e)
        {
            Window digestsWindow = new DigestsWindow();
            digestsWindow.Show();

        }

        private void ToKeywords_Click(object sender, RoutedEventArgs e)
        {
            Window keywordsWindow = new KeywordsWindow();
            keywordsWindow.Show();
        }

        private void ToReferences_Click(object sender, RoutedEventArgs e)
        {
            Window referencesWindow = new ReferencesWindow();
            referencesWindow.Show();
        }

        private void ToCareerChanges_Click(object sender, RoutedEventArgs e)
        {
            Window careerChanges = new CareerChanges();
            careerChanges.Show();
        }

       

    }
    



}


