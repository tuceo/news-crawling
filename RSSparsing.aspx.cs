using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class RSSparsing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["load"] = "YES";

            List<News> news = parseRSS();
            SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["db"].ConnectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO News (Title, Description, Category, Author, PubDate, ImageUrl) VALUES (@Title, @Description, @Category, @Author, @PubDate, @ImageUrl)", conn);

                cmd.Parameters.Add("@Title", SqlDbType.NChar, 100);
                cmd.Parameters.Add("@Description", SqlDbType.NChar, 3500);
                cmd.Parameters.Add("@Category", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@Author", SqlDbType.NChar, 20);
                cmd.Parameters.Add("@PubDate", SqlDbType.NChar, 10);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NChar, 200);

                for (int i = 0; i < news.Count; i++)
                {
                    cmd.Parameters["@Title"].Value = news[i].Title;
                    cmd.Parameters["@Description"].Value = news[i].Description;
                    cmd.Parameters["@Category"].Value = news[i].Category;
                    cmd.Parameters["@Author"].Value = news[i].Author;
                    cmd.Parameters["@PubDate"].Value = news[i].PubDate;
                    cmd.Parameters["@ImageUrl"].Value = news[i].ImageUrl;
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                Label1.Text = "Veri tabanı bağlantısı hatalı!";
            }
            finally
            {
                conn.Close();
                Response.Redirect("Home.aspx");
            }
           
        }

        public List<News> parseRSS()
        {
            List<News> newsList = new List<News>();

            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("http://ajans.dha.com.tr/dha_public_rss.php");
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            int id = 1;
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string Title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string Description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("category");
                string Category = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("author");
                string Author = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("pubDate");
                string PubDate = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("image");
                string imgUrl = rssSubNode != null ? rssSubNode.InnerText : "";

                News news = new News(id, Title, Description, Category, Author, PubDate, imgUrl);
                newsList.Add(news);
                id++;
            }
            return newsList;
        }
    }
}