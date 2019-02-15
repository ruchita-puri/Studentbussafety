<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bus_reg.aspx.cs" Inherits="BusMgmt.bus_reg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
   <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
 <title>BUS management</title>
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
<header class="main-header">

    <!-- Logo -->
    <a href="stud_registration.aspx" class="logo">
      <!-- mini logo for sidebar mini 50x50 pixels -->
      <span class="logo-mini"><b></b></span>
      <!-- logo for regular state and mobile devices -->
      <span class="logo-lg">School Safety Enhancement</span>
    </a>

    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top">
      <!-- Sidebar toggle button-->
      <a href="#" class="sidebar-toggle" data-toggle="push-menu" role="button">
        <span class="sr-only">Toggle navigation</span>
      </a>
      <!-- Navbar Right Menu -->
      <div class="navbar-custom-menu">
        <ul class="nav navbar-nav">
        
         
          
         
        </ul>
      </div>

    </nav>
  </header>
  <!-- Left side column. contains the logo and sidebar -->
  <aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <!-- Sidebar user panel --
      <!-- search form -->
      <!-- /.search form -->
      <!-- sidebar menu: : style can be found in sidebar.less -->
      <ul class="sidebar-menu" data-widget="tree">
        <li class="header">MAIN NAVIGATION</li>
        <li class="active treeview menu-open">
          <a href="#">
            <i class="fa fa-dashboard"></i> <span>Dashboard</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="../../stud_registration.aspx"><i class="fa fa-circle-o"></i> Student registration</a></li>
            <li><a href="../../bus_reg.aspx"><i class="fa fa-circle-o"></i> BUS registration</a></li>
             <li><a href="../../driver_reg.aspx"><i class="fa fa-circle-o"></i> Driver registration</a></li>
               <!--<li><a href="../../frm_GanareteRFID.aspx"><i class="fa fa-circle-o"></i> Ganarete RFID </a></li>-->
                <li><a href="../../barcode.aspx"><i class="fa fa-circle-o"></i> Ganarete QR code </a></li>
          </ul>
        </li>
  <li class="active treeview menu-open">
          <a href="#">
            <i class="fa fa-dashboard"></i> <span>Reports</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="../../Reoprts.aspx"><i class="fa fa-circle-o"></i> Student report</a></li>
            <li><a href="../../busReport.aspx"><i class="fa fa-circle-o"></i> BUS report</a></li>
             <li><a href="../../DriveReport.aspx"><i class="fa fa-circle-o"></i> Driver report</a></li>
               
          </ul>
        </li>
    
    
        
       
    </section>
    <!-- /.sidebar -->
  </aside>
  <div class="content-wrapper">

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-primary">
            <div class="box-header with-border">
            </div>

                        <h2 class="title">Bus Registration Form</h2>
    <form id="form1" runat="server">
    <asp:Label ID="Label10" runat="server" Text="Label" BorderColor="Red" 
               BorderStyle="Double">  </asp:Label>
              <div class="box-body">
                                <div class="form-group">
   
                                <asp:Label ID="Label1" runat="server" Text="Label">Bus Number</asp:Label>
                                 <asp:TextBox ID="txt_Busno"  class="form-control" runat="server" placeholder="enter Bus no" AutoComplete="off" ></asp:TextBox>
                                </div>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup='valGroup1' runat="server" ErrorMessage="Please enter Bus number" style="color:Red;" ControlToValidate="txt_Busno"></asp:RequiredFieldValidator>
                             <div class="form-group" >
 
                                 <div class="form-group">
        <asp:Label ID="Label9" runat="server" Text="Label">area</asp:Label>
     
<asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
</asp:DropDownList>

   <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup='valGroup1' ErrorMessage="Please enter area" style="color:Red;" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
    </div>
 
    
       <div>
      <asp:Button ID="Button1" ValidationGroup='valGroup1' class="btn btn-primary" runat="server" Text="submit" onclick="Button1_Click" />
        <asp:Button ID="Button2"  class="btn btn-primary" runat="server" Text="update" onclick="Button2_Click" />
         <asp:Button ID="Button3"  class="btn btn-primary" runat="server" Text="Search" onclick="Button3_Click" />
          <asp:Button ID="Button4" class="btn btn-primary" runat="server" Text="clear" onclick="Button4_Click" />
            <asp:Button ID="Button5" class="btn btn-primary" runat="server" Text="Delete" onclick="Button5_Click" />

    
   
     </div>
     </br>

               
 <asp:GridView ID="GridView1" runat="server" PageSize="3" AutoGenerateColumns="false" AllowPaging="true" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4"  OnSelectedIndexChanged="onselectedindexchanged">  
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />  
                    <RowStyle BackColor="White" ForeColor="#330099" />  
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />  
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />  
                    <HeaderStyle BackColor="#298089" Font-Bold="True" ForeColor="#FFFFCC" /> 
<Columns>
<asp:TemplateField HeaderText="Bus id" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lbl_bus_id" runat="server" Text='<%# Eval("bus_id") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txt_bus_id" runat="server" Text='<%# Eval("bus_id") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Bus_number" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lbl_bus_number" runat="server" Text='<%# Eval("bus_number") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txt_bus_number" runat="server" Text='<%# Eval("bus_number") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Bus area" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lbl_bus_area" runat="server" Text='<%# Eval("bus_area") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txt_bus_area" runat="server" Text='<%# Eval("bus_area") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
   

     <asp:TemplateField HeaderText=" Select" ItemStyle-Width="150">
     <ItemTemplate> <asp:Button ID="selectButton" runat="server" CommandName="Select" Text="Select" /></ItemTemplate>
    </asp:TemplateField>


   
</Columns>
</asp:GridView>


                  </div>
                  
          </form>
              </div>

              </br>
              </br>
              </br>
              </br>


<!-- jQuery 3 -->
<script src="../../bower_components/jquery/dist/jquery.min.js"></script>
<!-- Bootstrap 3.3.7 -->
<script src="../../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
<!-- Select2 -->
<script src="../../bower_components/select2/dist/js/select2.full.min.js"></script>
<!-- InputMask -->
<script src="../../plugins/input-mask/jquery.inputmask.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
<script src="../../plugins/input-mask/jquery.inputmask.extensions.js"></script>
<!-- date-range-picker -->
<script src="../../bower_components/moment/min/moment.min.js"></script>
<script src="../../bower_components/bootstrap-daterangepicker/daterangepicker.js"></script>
<!-- bootstrap datepicker -->
<script src="../../bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js"></script>
<!-- bootstrap color picker -->
<script src="../../bower_components/bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
<!-- bootstrap time picker -->
<script src="../../plugins/timepicker/bootstrap-timepicker.min.js"></script>
<!-- SlimScroll -->
<script src="../../bower_components/jquery-slimscroll/jquery.slimscroll.min.js"></script>
<!-- iCheck 1.0.1 -->
<script src="../../plugins/iCheck/icheck.min.js"></script>
<!-- FastClick -->
<script src="../../bower_components/fastclick/lib/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="../../dist/js/adminlte.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="../../dist/js/demo.js"></script>
<!-- Page script -->
<script>
    $(function () {
        //Initialize Select2 Elements
        $('.select2').select2()
        $('.datepicker').datepicker({
            dateFormat: 'dd-mm-yy'
        });
        //Datemask dd/mm/yyyy
        $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
        //Datemask2 mm/dd/yyyy
        $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })
        //Money Euro
        $('[data-mask]').inputmask()

        //Date range picker
        $('#reservation').daterangepicker()
        //Date range picker with time picker
        $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' })
        //Date range as a button
        $('#daterange-btn').daterangepicker(
      {
          ranges: {
              'Today': [moment(), moment()],
              'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
              'Last 7 Days': [moment().subtract(6, 'days'), moment()],
              'Last 30 Days': [moment().subtract(29, 'days'), moment()],
              'This Month': [moment().startOf('month'), moment().endOf('month')],
              'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
          },
          startDate: moment().subtract(29, 'days'),
          endDate: moment()
      },
      function (start, end) {
          $('#daterange-btn span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'))
      }
    )

        //Date picker
        $('#datepicker').datepicker({
            autoclose: true,
            dateFormat: 'dd-mm-yy'
        })

        //iCheck for checkbox and radio inputs
        $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
            checkboxClass: 'icheckbox_minimal-blue',
            radioClass: 'iradio_minimal-blue'
        })
        //Red color scheme for iCheck
        $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
            checkboxClass: 'icheckbox_minimal-red',
            radioClass: 'iradio_minimal-red'
        })
        //Flat red color scheme for iCheck
        $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        })

        //Colorpicker
        $('.my-colorpicker1').colorpicker()
        //color picker with addon
        $('.my-colorpicker2').colorpicker()

        //Timepicker
        $('.timepicker').timepicker({
            showInputs: false
        })
    })
</script>

</html>

