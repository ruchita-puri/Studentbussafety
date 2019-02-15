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
    public partial class bus_reg : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlDataAdapter da;
        MySqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.BindGrid();
                Loadarealist();
            }
            else
            {
            }
        }
 //--------------------------------------------------Grid view----------------------------------------------
        private void BindGrid()
        {
            con.Open();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_busno"))
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

        protected void onselectedindexchanged(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            //now get the labels
            Label _LabelId = row.FindControl("lbl_bus_id") as Label;
            Label _Labelnumber = row.FindControl("lbl_bus_number") as Label;
            Label _Labelarea = row.FindControl("lbl_bus_area") as Label;


            //get the values from labels and assign them to textboxes

            txt_Busno.Text = _Labelnumber.Text;
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(_Labelarea.Text));


        }

//--------------------------------------------------------insert code-------------------------------
/// <summary>
/// this is the code for inserting bus details into table 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Username doesn't exist.
            if (Button1.Text == "submit")
            {
                if (checkbusno(txt_Busno.Text))
                {
                    Label10.Text = "BUS with this number already Exist";
                    return;
                }

            }
            //insert in to database code here
            con.Open();
            using (MySqlCommand cmdadd = new MySqlCommand("insert into tbl_busno (bus_number,bus_area) values (@bus_number,@bus_area)", con))
            {

                cmdadd.Parameters.AddWithValue("@bus_number", txt_Busno.Text);
                cmdadd.Parameters.AddWithValue("@bus_area", DropDownList1.SelectedItem);
               
                cmdadd.ExecuteNonQuery();

                Label10.Text = "record inserted";

            }
            con.Close();
            Response.Redirect(Request.RawUrl);
            txt_Busno.Text = "";
       
           


        }
//---------------------------------------------------------update code-------------------------------
/// <summary>
/// this is the code for update 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            //update in to database code here
            using (MySqlCommand cmdupdate = new MySqlCommand("update tbl_busno set bus_number=@bus_number,bus_area=@bus_area where bus_number ='" + txt_Busno.Text + "'", con))
            {
                cmdupdate.Parameters.AddWithValue("@bus_number", txt_Busno.Text);
                cmdupdate.Parameters.AddWithValue("@bus_area", DropDownList1.SelectedItem);
                cmdupdate.ExecuteNonQuery();

                Label10.Text = "record updated";
                //  GridView1.DataBind();
            }
            Response.Redirect(Request.RawUrl);
            txt_Busno.Text = "";
        }
//---------------------------------------------------------search code-------------------------------
/// <summary>
/// this is the code for search
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txt_Busno.Text != null)
            {
                Label10.Text = "Enter Bus no for search";
            }

            con.Open();
            using (MySqlCommand cmdGET = new MySqlCommand("select * from tbl_busno where bus_number = '" + txt_Busno.Text + "'", con))
            {
                using (dr = cmdGET.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt_Busno.Text = dr["bus_number"].ToString();
                            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(dr["bus_area"].ToString()));

                            Label10.Text = "record Selected";

                        }
                    }
                }
            }
        }
//----------------------------------------------------------clear inputs------------------------------
/// <summary>
/// this is the cod efor clear 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            txt_Busno.Text = "";
            DropDownList1.SelectedIndex = 0;
        }
//------------------------------------------------------delete code ----------------------------------
/// <summary>
/// this is the cod efor delete 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txt_Busno.Text != null)
            {
             using (MySqlCommand command = new MySqlCommand("DELETE FROM tbl_busno WHERE bus_number = '" + txt_Busno.Text + "'", con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    txt_Busno.Text="";
                    Label10.Text = "";
                    DropDownList1.SelectedIndex = 0;
                }
              

                Label10.Text = "record deleted";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label10.Text = "insert roll no";
            }
        
        }
///-------------------------------------- used functions code here ------------------------
/// </summary>
/// <param name="driver_name"></param>
/// <returns></returns>
/// function for check student name existed
        private Boolean checkbusno(string driver_name)
        {
            using (con)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (MySqlCommand cmdselect = new MySqlCommand("select bus_number from tbl_busno where bus_number=@bus_number", con))
                {
                    cmdselect.Parameters.AddWithValue("@bus_number", driver_name);
                    using (dr = cmdselect.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
 

      public void Loadarealist()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_arealist"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            DropDownList1.DataSource = ds;
                            DropDownList1.DataTextField = "area_name";
                            DropDownList1.DataValueField = "area_id";
                            DropDownList1.DataBind();
                        }
                        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
        }
    }
}