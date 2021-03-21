<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateZip.aspx.cs" Inherits="test_zip.CreateZip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<h3 style="color: #0000FF; font-style: italic"> Create Zip in ASP.NET</h3>
    <div style="height: 121px">
        <asp:FileUpload ID="FileUpload" runat="server" />
        <br />
        <br />
        <asp:Button ID="bttnupload" runat="server" Text="Upload File" Font-Bold="True" 
            onclick="bttnupload_Click" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bttnzip" runat="server" Text="Create Zip" Font-Bold="True" 
            onclick="bttnzip_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="lbltxt" runat="server" ForeColor="#CC0000"></asp:Label>
    </div>
    </form>
    </body>
</html>