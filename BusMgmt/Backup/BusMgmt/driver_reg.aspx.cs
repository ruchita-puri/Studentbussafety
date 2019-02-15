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
    public partial class driver_reg : System.Web.UI.Page
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        MySqlDataAdapter da;
        MySqlDataReader dr;
        static string driver_id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.BindGrid();
                Loadbusno();
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
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_driver_mst"))
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


        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    //string vendid = Convert.ToString(e.CommandArgument.ToString());
        //    //Response.Write("Vendorid:" + vendid);
        //   // int driver_id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].values[0]);
        //  //  int driver_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //  //  int driver_id = int.Parse(((Label)GridView1.Rows[row.RowIndex].FindControl("Delete")).Text);
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_driver_mst WHERE driver_id = @driver_id"))
        //        {
        //            using (MySqlDataAdapter sda = new MySqlDataAdapter())
        //            {
                       
        //        //        cmd.Parameters.AddWithValue("@driver_id", driver_id);
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //    this.BindGrid();
        //}

        protected void onselectedindexchanged(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            //now get the labels
            Label _LabelId = row.FindControl("lbl_driver_id") as Label;
            Label _LabelTitle = row.FindControl("lbl_driver_name") as Label;
            Label _Labelmobile = row.FindControl("lbl_driver_mobile") as Label;
            Label _Labelbusnumber = row.FindControl("lbl_driver_allowtedbus") as Label;

            //get the values from labels and assign them to textboxes

            txt_drivername.Text = _LabelTitle.Text;
            txt_drivermobile.Text = _Labelmobile.Text;
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(_Labelbusnumber.Text));


        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "select")
        //    {
        //        // Get the currently selected row using the SelectedRow property.
        //        GridViewRow row = GridView1.SelectedRow;

        //        //now get the labels
        //        Label _LabelId = row.FindControl("lbl_driver_id") as Label;
        //        Label _LabelTitle = row.FindControl("lbl_driver_name") as Label;
        //        Label _Labelmobile = row.FindControl("lbl_driver_mobile") as Label;
        //        Label _Labelbusnumber = row.FindControl("driver_allowtedbus") as Label;

        //        //get the values from labels and assign them to textboxes

        //        txt_drivername.Text = _LabelTitle.Text;
        //        txt_drivermobile.Text = _Labelmobile.Text;
        //        DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(_Labelbusnumber.Text));
           

        //    }

        //    if (e.CommandName == "delete")
        //    {
               
        //        driver_id = (e.CommandArgument).ToString();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModaldelmodel();", true);
        //    }
        //}
      
      

//--------------------------------------------------insert details------------------------------------------------------------------------
/// <summary>
/// this is the code for insert drivers data 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            //Username doesn't exist.
            if (Button1.Text == "submit")
            {
                if (checkdrivername(txt_drivername.Text))
                {
                    Label10.Text = "Driver with this name already Exist";
                    return;
                }
               
            }
            //insert in to database code here
            con.Open();
            using (MySqlCommand cmdadd = new MySqlCommand("insert into tbl_driver_mst (driver_name,driver_mobile,driver_allowtedbus) values (@driver_name,@driver_mobile,@driver_allowtedbus)", con))
            {

                cmdadd.Parameters.AddWithValue("@driver_name", txt_drivername.Text);
                cmdadd.Parameters.AddWithValue("@driver_mobile", txt_drivermobile.Text);
                cmdadd.Parameters.AddWithValue("@driver_allowtedbus", DropDownList1.SelectedItem);
                cmdadd.ExecuteNonQuery();

                Label10.Text = "record inserted";

            }
            con.Close();
            Response.Redirect(Request.RawUrl);
       //     txt_driverbusno.Text = "";
            txt_drivermobile.Text = "";
            txt_drivername.Text = "";
           
        }
//------------------------------------------------------update details-------------------------------------------------------------------
/// <summary>
///  this is the code for update drivers data 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            con.Open();
            //update in to database code here
            using (MySqlCommand cmdupdate = new MySqlCommand("update tbl_driver_mst set driver_name=@driver_name,driver_mobile=@driver_mobile,driver_allowtedbus=@driver_allowtedbus where driver_name='" + txt_drivername.Text + "'", con))
            {

                cmdupdate.Parameters.AddWithValue("@driver_name", txt_drivername.Text);
                cmdupdate.Parameters.AddWithValue("@driver_mobile", txt_drivermobile.Text);
                cmdupdate.Parameters.AddWithValue("@driver_allowtedbus", DropDownList1.SelectedItem);
                cmdupdate.ExecuteNonQuery();

                Label10.Text = "record updated";


            }
            Response.Redirect(Request.RawUrl);
            txt_drivername.Text = "";
            txt_drivermobile.Text = "";
          //  txt_driverbusno.Text = "";
        }
//------------------------------------------select details----------------------------------------------------------
/// <summary>
/// this is the code for select value 
/// </summary>
/// <param name="sender">pooja</param>
/// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txt_drivername.Text != null)
            {
                Label10.Text = "Enter Driver name for search";
            }
            con.Open();
            using (MySqlCommand cmdGET = new MySqlCommand("select * from tbl_driver_mst where driver_name ='" + txt_drivername.Text + "'", con))
            {
                using (dr = cmdGET.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt_drivername.Text = dr["driver_name"].ToString();
                            txt_drivermobile.Text = dr["driver_mobile"].ToString();
                          //  txt_driverbusno.Text = dr["driver_allowtedbus"].ToString();
                            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(dr["driver_allowtedbus"].ToString()));

                            Label10.Text = "record Selected";
                        }
                    }
                }
            }
            con.Close();
        }
//------------------------------------------------------clear the inputs --------------------------------------------------------------
/// <summary>
/// this is the code for clear values
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>

        protected void Button4_Click(object sender, EventArgs e)
        {
          //  txt_driverbusno.Text = "";
            txt_drivermobile.Text = "";
            txt_drivername.Text = "";
            DropDownList1.SelectedIndex = 0;
            Label10.Text = "";
        }
//---------------------------------------delete details----------------------------------------------------
 /// <summary>
 /// this is the code for delete the record
 /// </summary>
 /// <param name="sender">pooja</param>
 /// <param name="e"></param>
     
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (txt_drivername.Text != null)
            {

                using (MySqlCommand command = new MySqlCommand("DELETE from tbl_driver_mst where driver_name ='" + txt_drivername.Text + "'", con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                   // txt_driverbusno.Text = "";
                    txt_drivermobile.Text = "";
                    txt_drivername.Text = "";
                    DropDownList1.SelectedIndex = 0;
                    Label10.Text = "";
                   
                }


                Label10.Text = "record deleted";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label10.Text = "insert roll no";
            }
        }

    /// <summary>
///-------------------------------------- used functions code here ------------------------
/// </summary>
/// <param name="driver_name"></param>
/// <returns></returns>
/// function for check student name existed
        private Boolean checkdrivername(string driver_name)
        {
            using (con)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (MySqlCommand cmdselect = new MySqlCommand("select driver_name from tbl_driver_mst where driver_name=@driver_name", con))
                {
                    cmdselect.Parameters.AddWithValue("@driver_name", driver_name);
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

        //retrive all boynames from tbl_boys 
/// <summary>
/// function for get bus numbers from table tbl_busno
/// </summary>
/// <param name="prefixText"></param>
/// <param name="count"></param>
/// <returns></returns>

        public void Loadbusno()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tbl_busno"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;

                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            DropDownList1.DataSource = ds;
                            DropDownList1.DataTextField = "bus_number";
                            DropDownList1.DataValueField = "bus_id";
                            DropDownList1.DataBind();
                        }
                        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
        }

///// <summary>
///// 
///// </summary>
///// <param name="stud_rollno"></param>
///// <returns></returns>
///// function for check student roll no existed 
      
//        private Boolean checkstudrollno(string stud_rollno)
//        {
//            using (con)
//            {
//                if (con.State == ConnectionState.Closed)
//                {
//                    con.Open();
//                }
//                using (MySqlCommand cmdselect = new MySqlCommand("select stud_rollno from tbl_stud_mst where stud_rollno=@stud_rollno", con))
//                {
//                    cmdselect.Parameters.AddWithValue("@stud_rollno",stud_rollno);
//                    using (dr = cmdselect.ExecuteReader())
//                    {
//                        if (dr.HasRows)
//                        {
//                            return true;
//                        }
//                        else
//                        {
//                            return false;
//                        }
//                    }
//                }
//            }
//        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
}
}