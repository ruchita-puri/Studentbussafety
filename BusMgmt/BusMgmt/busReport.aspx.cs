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
    public partial class busReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                reportbuild();

            }
            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(Server.MapPath("~/CrystalReport3.rpt"));

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
            MySqlCommand cmd = new MySqlCommand("select * from tbl_busno ", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tbl_busno");
            cryRpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryRpt;  

        }
        void reportbuild()
        {
            ReportDocument cryRpt = new ReportDocument();
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            cryRpt.Load(Server.MapPath("~/CrystalReport3.rpt"));

            crConnectionInfo.ServerName = "localhost";
            crConnectionInfo.DatabaseName = "db_busmgmt";
            crConnectionInfo.UserID = "root";
            crConnectionInfo.Password = "";
            crConnectionInfo.IntegratedSecurity = true;

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            CrystalReportViewer1.ReportSource = cryRpt;
            CrystalReportViewer1.RefreshReport();

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(Server.MapPath("~/CrystalReport3.rpt"));

            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString.ToString());
            MySqlCommand cmd = new MySqlCommand("select * from tbl_busno where bus_number='" + TextBox1.Text + "'", con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds, "tbl_busno");
            cryRpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = cryRpt; 
        }
    }
}