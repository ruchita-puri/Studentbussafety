using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using QRCoder;

namespace BusMgmt
{
    public partial class barcode : System.Web.UI.Page
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

        protected void btnQRCode_Click(object sender, EventArgs e)
        {
            string code = txt_stud.Text;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                plBarCode.Controls.Add(imgBarCode);
            }
        }

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
            Label _Labelclass = row.FindControl("lblclass") as Label;
            Label _Labeldiv = row.FindControl("lbldiv") as Label;
            Label _Labelmobile = row.FindControl("lblmobile") as Label;
            Label _Labelemail = row.FindControl("lblemail") as Label;
            Label _Labeladdress = row.FindControl("lbladdress") as Label;
            Label _Labelarea = row.FindControl("lblarea") as Label;
            Label _Labelgender = row.FindControl("lblgender") as Label;
            Label _Labelrollno = row.FindControl("lblrollno") as Label;
            Label _Labeldob = row.FindControl("lbldob") as Label;
            //get the values from labels and assign them to textboxes
            txt_stud.Text = _LabelId.Text;
           

        }

    }
}