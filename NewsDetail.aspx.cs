using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["load"] == null)
            {
                Response.Redirect("RSSparsing.aspx");
            }
            else
            {
                int id = int.Parse(Request.QueryString["NewsID"]);
                SqlConnection conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["db"].ConnectionString);
                conn.Open();
                var category = new SqlCommand("SELECT Category FROM News WHERE NewsID=" + id, conn);
                var title = new SqlCommand("SELECT Title FROM News WHERE NewsID=" + id, conn);
                var image = new SqlCommand("SELECT ImageUrl FROM News WHERE NewsID=" + id, conn);
                var pubdate = new SqlCommand("SELECT PubDate FROM News WHERE NewsID=" + id, conn);
                var description = new SqlCommand("SELECT Description FROM News WHERE NewsID=" + id, conn);
                using (SqlDataReader dr = category.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Category.Text = dr.GetString(dr.GetOrdinal("Category")).ToString();
                    }
                }
                using (SqlDataReader dr = title.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Title.Text = dr.GetString(dr.GetOrdinal("Title")).ToString();
                    }
                }
                using (SqlDataReader dr = image.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Image.ImageUrl = dr.GetString(dr.GetOrdinal("ImageUrl")).ToString();
                    }
                }
                using (SqlDataReader dr = pubdate.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        PubDate.Text = dr.GetString(dr.GetOrdinal("PubDate")).ToString();
                    }
                }
                using (SqlDataReader dr = description.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        Description.Text = dr.GetString(dr.GetOrdinal("Description")).ToString();
                    }
                }
            }
        }
    }
}