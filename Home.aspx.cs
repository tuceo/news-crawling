using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Serilog;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"C:\Users\Tuceo\Desktop\WebBT\WebBT_Project\log.txt")
                .CreateLogger();

            var position = new { Latitude = 25, Longitude = 134 };
            var elapsedMs = 34;

            log.Information("Processed {@Position} in {Elapsed} ms.", position, elapsedMs);

            if (Session["load"] == null)
            {
                Response.Redirect("RSSparsing.aspx");
            }
            Log.CloseAndFlush();
        }
    }
}
