using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Services;

namespace BusMgmt
{
    public partial class frm_GanareteRFID : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlDataAdapter da;
        MySqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();

            }
            else
            {
            }
        }
        //-----------------------------------------------Grid view--------------------------------
        private void BindGrid()
        {
            con.Open();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_stud_mst"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            con.Close();
        }


        protected void onselect(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            //now get the labels
            Label _LabelId = row.FindControl("lblid") as Label;
            Label _LabelTitle = row.FindControl("lblName") as Label;
            Label _LabelRFID = row.FindControl("lblRFID") as Label;
    
            //get the values from labels and assign them to textboxes
            inptsearch.Text = _LabelTitle.Text;
            txt_rfid.Text=_LabelRFID.Text;
        }
//------------------------------------------------------------------------------------------------------
        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            //insert in to database code here
            using (MySqlCommand cmdadd = new MySqlCommand("update tbl_stud_mst set RFID=@RFID where stud_name='" + inptsearch.Text + "'", con))
            {
                cmdadd.Parameters.AddWithValue("@RFID", txt_rfid.Text);
                
                cmdadd.ExecuteNonQuery();

                Label10.Text = "record inserted";
                // GridView1.DataBind();

            }
            con.Close();
            Response.Redirect(Request.RawUrl);

        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetCompletionList(string prefixText, int count)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                using (MySqlCommand com = new MySqlCommand())
                {
                    com.CommandText = "select docname from tbl_doctor where docname like '%' @Search  '%' limit 10";

                    com.Parameters.AddWithValue("@Search", prefixText);
                    com.Connection = con;
                    con.Open();
                    List<string> countryNames = new List<string>();
                    using (MySqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            countryNames.Add(sdr["docname"].ToString());
                        }
                    }
                    con.Close();
                    return countryNames;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            con.Open();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_stud_mst where stud_name='" + inptsearch.Text+ "'"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            con.Close();
                
        }
}
}