using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Globalization;
using System.Data;
namespace BusMgmt
{
    public partial class TestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               

            }
            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(Server.MapPath("~/CrystalReport4.rpt"));

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
            MySqlCommand cmd = new MySqlCommand("select * from tbl_busno ", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tbl_busno");
            cryRpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryRpt;  
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}