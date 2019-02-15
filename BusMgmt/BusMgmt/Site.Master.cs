using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusMgmt
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label1.Visible = false;
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((this.txt_user.Text == "admin") && (this.txt_pass.Text == "pass123"))
            {
                Label1.Text = "";
                Response.Redirect("stud_registration.aspx");

            }
            else {
                Label1.Visible = true;
                Label1.Text = "enter valid username or password";
            }
            
        }
}
}