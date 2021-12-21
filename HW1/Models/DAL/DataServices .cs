using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace HW1.Models.DAL
{
    public class DataServices
    {
        static List<Article> articleList; 
        static List<Review> reviewList;

        //all article function

        public int Insert(Article article)
        {
            if (articleList == null)
                articleList = new List<Article>();
            articleList.Add(article);


            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");
                // C - Create Command
                SqlCommand command = CreateInsert(article, con);
                // E - Execute
                int affected = command.ExecuteNonQuery();

                return affected;
            }
            catch (Exception ex)
            {
                // write to log file
                throw new Exception("Failed in Insert of article", ex);
            }
            finally
            {
                // C - Close Connection
                con.Close();
            }

        }


        // Create an Insert command
        SqlCommand CreateInsert(Article article, SqlConnection con)
        {
            article.Body = article.Body.Replace("'", "''");
            article.Head = article.Head.Replace("'", "''");
            article.Source = article.Source.Replace("'", "''");
            article.SeriesName = article.SeriesName.Replace("'", "''");

            // INSERT INTO [Articles_2022_B]([id_artical], [seriesName],[head],[body],[source],[publishDateTime],[image],[link]) VALUES()
            string insertStr = "INSERT INTO [Articles_2022_B]([id_artical], [seriesName],[head],[body],[source],[publishDateTime],[image],[link]) ";
            insertStr += "VALUES('" + article.Id + "','" + article.SeriesName + "','" + article.Head + "','" + article.Body + "','" + article.Source + "','" + article.PublishDateTime + "','" + article.Image + "','" + article.Link +"')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;
        }

        // Opens a new DB connection
        SqlConnection Connect(string connectionStringName)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            return con;
        }

        public List<string> ReadAllArticleNames()
        {
            List<string> articleNamesList = new List<string>();
            foreach (Article item in articleList)
                articleNamesList.Add(item.SeriesName);
            List<string> uniqueNamesList = articleNamesList.Distinct().ToList(); // מניעת כפילויות עובד??
            return uniqueNamesList;
        }

        public List<Article> ReadByName(string name)
        {
            List<Article> articalsByName = new List<Article>();
            foreach (Article item in articleList)
                if (item.SeriesName == name) articalsByName.Add(item);
            return articalsByName;
        }

        //all review function
        public int Insert(Review review)
        {
            if (reviewList == null)
                reviewList = new List<Review>();
            reviewList.Add(review);

            SqlConnection con = null;
            try
            {
                // C - Connect
                con = Connect("webOsDB");
                // C - Create Command
                SqlCommand command = CreateInsert(review, con);
                // E - Execute
                int affected = command.ExecuteNonQuery();

                return affected;
            }
            catch (Exception ex)
            {
                // write to log file
                throw new Exception("Failed in Insert of review", ex);
            }
            finally
            {
                // C - Close Connection
                con.Close();
            }
        }

        // Create an Insert command
        SqlCommand CreateInsert(Review review, SqlConnection con)
        {
            string insertStr = "INSERT INTO [Reviews_2022_B]([criticName],[email],[contents],[reviewDateTime],[rating],[id_artical]) ";
            insertStr += "VALUES('" + review.CriticName + "','" + review.Email + "','" + review.Contents + "','" + review.ReviewDateTime + "'," + review.Rating +",'" + review.Id + "')";
            SqlCommand command = new SqlCommand(insertStr, con);
            // TBC - Type and Timeout
            command.CommandType = System.Data.CommandType.Text;
            command.CommandTimeout = 30;
            return command;
        }

        public List<Review> ReadReview()
        {
            return reviewList;
        }

    }
}