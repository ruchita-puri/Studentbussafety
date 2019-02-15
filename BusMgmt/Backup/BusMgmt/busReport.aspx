<%@ Page Language="C#" AutoEventWireup="true" codefile="busReport.aspx.cs" Inherits="BusMgmt.busReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

 
</script>
<html xmlns="http://www.w3.org/1999/xhtml"/>

   <head id="Head1" runat="server">
   <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <title>AdminLTE 2 | General Form Elements</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.7 -->
  <link rel="stylesheet" href="../../bower_components/bootstrap/dist/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="../../bower_components/font-awesome/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="../../bower_components/Ionicons/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="../../dist/css/skins/_all-skins.min.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->

  <!-- Google Font -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic">

    <script language="javascript" type="text/javascript">
    </script>
</head>
<body class="hold-transition skin-blue sidebar-mini">

<div class="wrapper">
   <div class="content-wrapper">
    <section class="content">
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
           

                        <h2 class="title">Reports Form</h2>
    <form id="form1" runat="server">
  
     <asp:Panel ID="Panel1" runat="server" Visible="true">
     
     <asp:Label ID="Label1" runat="server" Text="Label">Enter bus no</asp:Label>
     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
     <asp:Button ID="Button2" runat="server" Text="Show report" onclick="Button2_Click"></asp:Button>
         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        
         <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
             AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" 
             ReportSourceID="CrystalReportSource3" ToolbarImagesFolderUrl="" 
             ToolPanelWidth="200px" Width="1104px" ToolPanelView="None" />
         <CR:CrystalReportSource ID="CrystalReportSource3" runat="server">
             <Report FileName="CrystalReport3.rpt">
             </Report>
         </CR:CrystalReportSource>
         <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
             <Report FileName="CrystalReport1.rpt">
             </Report>
         </CR:CrystalReportSource>
   

     </asp:Panel>    
                  
          </form>
              </div>
              </div>
              </div>
           </section>
           </div>
           </div>
           

</body>
</html>