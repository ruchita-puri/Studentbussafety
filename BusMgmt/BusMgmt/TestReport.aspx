<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestReport.aspx.cs" Inherits="BusMgmt.TestReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport4.rpt">
            </Report>
        </CR:CrystalReportSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="BusMgmt.newDataset1TableAdapters.tbl_driver_mstTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="p1" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="p1" Type="String" />
                <asp:Parameter Name="p2" Type="String" />
                <asp:Parameter Name="p3" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="p1" Type="String" />
                <asp:Parameter Name="p2" Type="String" />
                <asp:Parameter Name="p3" Type="String" />
                <asp:Parameter Name="p4" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
