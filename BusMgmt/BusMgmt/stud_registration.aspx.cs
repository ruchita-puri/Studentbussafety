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
    public partial class stud_registration : System.Web.UI.Page
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

        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int stud_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand("DELETE FROM tbl_stud_mst WHERE stud_id = @stud_id"))
        //        {
        //            using (MySqlDataAdapter sda = new MySqlDataAdapter())
        //            {
        //                cmd.Parameters.AddWithValue("@stud_id", stud_id);
        //                cmd.Connection = con;
        //                con.Open();
        //                cmd.ExecuteNonQuery();
        //                con.Close();
        //            }
        //        }
        //    }
        //    this.BindGrid();
        //}

        protected void onselect(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            //now get the labels
            Label _LabelId = row.FindControl("lblid") as Label;
            Label _LabelTitle = row.FindControl("lblName") as Label;
            Label _Labelclass = row.FindControl("lblclass") as Label;
            Label _Labeldiv = row.FindControl("lbldiv") as Label;
            Label _Labelmobile = row.FindControl("lblmobile") as Label;
            Label _Labelemail = row.FindControl("lblemail") as Label;
            Label _Labeladdress= row.FindControl("lbladdress") as Label;
            Label _Labelarea = row.FindControl("lblarea") as Label;
            Label _Labelgender = row.FindControl("lblgender") as Label;
            Label _Labelrollno = row.FindControl("lblrollno") as Label;
            Label _Labeldob = row.FindControl("lbldob") as Label;
            //get the values from labels and assign them to textboxes
            txt_studname.Text = _LabelTitle.Text;
            txt_studclass.Text = _Labelclass.Text;
            txt_studdiv.Text = _Labeldiv.Text;
            txt_studemailid.Text = _Labelemail.Text;
            txt_studmobileno.Text = _Labelmobile.Text;
            datepicker.Text = _Labeldob.Text;
            txt_studaddress.Text = _Labeladdress.Text;
            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(_Labelarea.Text));
            Label12.Text = _Labelgender.Text;
            if (Label12.Text == RadioButton1.Text)
            {
                RadioButton1.Checked = true;
            }
            if (Label12.Text == RadioButton2.Text)
            {
                RadioButton2.Checked = true;
            }
            txt_studrollno.Text = _Labelrollno.Text;
        
        }

//----------------------------------------------submit button code here--------------------------
        protected void Button1_Click(object sender, EventArgs e)
        {
           // string gender;
            //Username doesn't exist.
             if (Button1.Text == "submit")
                {
                    if (checkstudname(txt_studname.Text))
                    {
                       Label10.Text = "student with this name already Exist";
                        return;
                    }
                    if (checkstudrollno(txt_studrollno.Text))
                    {
                        Label10.Text = "student with this rollno already Exist";
                        return;
                    }
             }

             if (RadioButton1.Checked == true)
             {
                 Label12.Text = RadioButton1.Text.ToString();
                          
             }
             if (RadioButton2.Checked == true)
             {
                 Label12.Text = RadioButton2.Text.ToString();
             
             }
            // Label12.Text = gender.ToString();
                    con.Open();   
                //insert in to database code here
                using (MySqlCommand cmdadd = new MySqlCommand("insert into tbl_stud_mst (stud_rollno,stud_name,stud_class,stud_div,stud_mobile,stud_email,stud_address,stud_area,stud_dob,stud_gender) values (@stud_rollno,@stud_name,@stud_class,@stud_div,@stud_mobile,@stud_email,@stud_address,@stud_area,@stud_dob,@stud_gender)", con))
                {
                    cmdadd.Parameters.AddWithValue("@stud_rollno", txt_studrollno.Text);
                    cmdadd.Parameters.AddWithValue("@stud_name", txt_studname.Text);
                    cmdadd.Parameters.AddWithValue("@stud_class", txt_studclass.Text);
                    cmdadd.Parameters.AddWithValue("@stud_div", txt_studdiv.Text);
                    cmdadd.Parameters.AddWithValue("@stud_mobile", txt_studmobileno.Text);
                    cmdadd.Parameters.AddWithValue("@stud_email", txt_studemailid.Text);
                    cmdadd.Parameters.AddWithValue("@stud_address", txt_studaddress.Text);
                    cmdadd.Parameters.AddWithValue("@stud_area", DropDownList1.SelectedItem);
                    cmdadd.Parameters.AddWithValue("@stud_dob", datepicker.Text);
                    cmdadd.Parameters.AddWithValue("@stud_gender", Label12.Text);
                    cmdadd.ExecuteNonQuery();

                
                   // GridView1.DataBind();

                }
                con.Close();
                Response.Redirect(Request.RawUrl);
                Label10.Text = "record inserted";
                txt_studrollno.Text = "";
                txt_studaddress.Text = "";
           //     txt_studarea.Text = "";
                txt_studclass.Text = "";
                txt_studdiv.Text = "";
                txt_studrollno.Text = "";
                txt_studemailid.Text = "";
              //  txt_studgender.Text = "";
                txt_studmobileno.Text = "";
                txt_studname.Text = "";
                DropDownList1.SelectedIndex = 0;
              
               
            }


     //-------------------------------------Update button code here-------------------------------------------             


        protected void Button2_Click1(object sender, EventArgs e)
        {
            //string gender;
            con.Open();
            //update in to database code here
            using (MySqlCommand cmdupdate = new MySqlCommand("update tbl_stud_mst set stud_rollno=@stud_rollno,stud_name=@stud_name,stud_class=@stud_class,stud_div=@stud_div,stud_mobile=@stud_mobile,stud_email=@stud_email,stud_address=@stud_address,stud_area=@stud_area,stud_dob=@stud_dob,stud_gender=@stud_gender where stud_rollno='" + txt_studrollno.Text + "'", con))
            {
                if (RadioButton1.Checked == true)
                {
                    Label12.Text = RadioButton1.Text.ToString();

                }
                if (RadioButton2.Checked == true)
                {
                    Label12.Text = RadioButton2.Text.ToString();

                }
              //  Label12.Text = gender.ToString();
                cmdupdate.Parameters.AddWithValue("@stud_rollno", txt_studrollno.Text);
                cmdupdate.Parameters.AddWithValue("@stud_name", txt_studname.Text);
                cmdupdate.Parameters.AddWithValue("@stud_class", txt_studclass.Text);
                cmdupdate.Parameters.AddWithValue("@stud_div", txt_studdiv.Text);
                cmdupdate.Parameters.AddWithValue("@stud_mobile", txt_studmobileno.Text);
                cmdupdate.Parameters.AddWithValue("@stud_email", txt_studemailid.Text);
                cmdupdate.Parameters.AddWithValue("@stud_address", txt_studaddress.Text);
                cmdupdate.Parameters.AddWithValue("@stud_area", DropDownList1.SelectedItem);
                cmdupdate.Parameters.AddWithValue("@stud_dob", txt_studrollno.Text);
                cmdupdate.Parameters.AddWithValue("@stud_gender", Label12.Text);
                cmdupdate.ExecuteNonQuery();
                Label12.Text = "";
                Label10.Text = "record updated";
              //  GridView1.DataBind();
            }
            Response.Redirect(Request.RawUrl);
            txt_studrollno.Text = "";
            txt_studaddress.Text = "";
          //  txt_studarea.Text = "";
            txt_studclass.Text = "";
            txt_studdiv.Text = "";
            txt_studrollno.Text = "";
            txt_studemailid.Text = "";
           // txt_studgender.Text = "";
            txt_studmobileno.Text = "";
            txt_studname.Text = "";
            DropDownList1.SelectedIndex = 0;
          
        }

//---------------------------------search button code here -----------------------------------------
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (txt_studrollno.Text != null)
            {
                Label10.Text = "Enter roll no for search" ;
            }
                
            con.Open();
            using (MySqlCommand cmdGET = new MySqlCommand("select * from tbl_stud_mst where stud_rollno = '" + txt_studrollno.Text + "' OR stud_name='" + txt_studname.Text + "'", con))
            {
                using (dr = cmdGET.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txt_studrollno.Text = dr["stud_rollno"].ToString();
                            txt_studname.Text = dr["stud_name"].ToString();
                            txt_studclass.Text = dr["stud_class"].ToString();
                            txt_studdiv.Text = dr["stud_div"].ToString();
                            txt_studmobileno.Text = dr["stud_mobile"].ToString();
                            txt_studemailid.Text = dr["stud_email"].ToString();
                            txt_studaddress.Text = dr["stud_address"].ToString();
                            DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(dr["stud_area"].ToString()));
                            // DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(dr["stud_area"].ToString());
                           // DropDownList1.SelectedValue =DropDownList1.DataValueField = dr["stud_area"].ToString();
                            datepicker.Text = dr["stud_dob"].ToString();
                             Label12.Text = dr["stud_gender"].ToString();

                             if (Label12.Text == RadioButton1.Text)
                             {
                                 RadioButton1.Checked = true;
                             }
                             if (Label12.Text == RadioButton2.Text)
                             {
                                 RadioButton2.Checked = true;
                             }
                            Label10.Text = "record Selected";
                            
                        }
                    }
                }
            }
           
        }

//------------------------------clear button code here--------------------------------------------------------------
        protected void Button4_Click(object sender, EventArgs e)
        {
            txt_studrollno.Text = "";
            txt_studaddress.Text = "";
       //     txt_studarea.Text = "";
            txt_studclass.Text = "";
            txt_studdiv.Text = "";
            txt_studrollno.Text = "";
            txt_studemailid.Text = "";
         //   txt_studgender.Text = "";
            txt_studmobileno.Text = "";
            txt_studname.Text = "";
            DropDownList1.SelectedIndex = 0;
            Label10.Text = "";
        }
//------------------delete button code here-------------------------------------------------------------------------
        protected void Button5_Click(object sender, EventArgs e)
        {

            if (txt_studrollno.Text != null)
            {
                
                using (MySqlCommand command = new MySqlCommand("DELETE FROM tbl_stud_mst  where stud_rollno = '" + txt_studrollno.Text + "'", con))
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    txt_studrollno.Text = "";
                    txt_studaddress.Text = "";
                    //     txt_studarea.Text = "";
                    txt_studclass.Text = "";
                    txt_studdiv.Text = "";
                    txt_studrollno.Text = "";
                    txt_studemailid.Text = "";
                   // txt_studgender.Text = "";
                    txt_studmobileno.Text = "";
                    txt_studname.Text = "";
                    Label10.Text = "";
                    datepicker.Text = "";
                }
              

                Label10.Text = "record deleted";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label10.Text = "insert roll no";
            }
        }

//---------------------------Grid view code here-------------------------------------------------------------

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

/// <summary>
///-------------------------------------- used functions code here ------------------------
/// </summary>
/// <param name="stud_name"></param>
/// <returns></returns>
/// function for check student name existed
        private Boolean checkstudname(string stud_name)
        {
            using (con)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (MySqlCommand cmdselect = new MySqlCommand("select stud_name from tbl_stud_mst where stud_name=@stud_name", con))
                {
                    cmdselect.Parameters.AddWithValue("@stud_name", stud_name);
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
/// <summary>
/// ///  function for check student roll no existed 
/// </summary>
/// <param name="stud_rollno"></param>
/// <returns></returns>
///
      
        private Boolean checkstudrollno(string stud_rollno)
        {
            using (con)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (MySqlCommand cmdselect = new MySqlCommand("select stud_rollno from tbl_stud_mst where stud_rollno=@stud_rollno", con))
                {
                    cmdselect.Parameters.AddWithValue("@stud_rollno",stud_rollno);
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

        /// <summary>
        /// ///  function for dropdown list for area 
        /// </summary>
        /// <param name="stud_rollno"></param>
        /// <returns></returns>
        ///

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