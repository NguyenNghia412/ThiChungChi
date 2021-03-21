<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="TH.NUCE.Web.WatermarkPhoto.View" %>

<h3>Upload Image with Watermark Image(Logo)</h3>
<table width="100%">
    <tr>
        <td>Select Image : </td>
        <td>
            <asp:FileUpload ID="FU1" runat="server" /></td>
        <td>MaxWidth</td>
        <td>
            <asp:TextBox ID="txtMaxWidthImage" runat="server" value="1000" Width="50"></asp:TextBox>
        </td>
        <td>  MaxHight <asp:TextBox ID="txtMaxHightImage" runat="server" value="1000" Width="50"></asp:TextBox></td>
         <td>
         
        </td>
    </tr>
    <tr>
        <td>Watermark Logo : </td>
        <td>
            <asp:FileUpload ID="FULogo" runat="server" /></td>
         <td>MaxWidth</td>
         <td>
            <asp:TextBox ID="txtMaxWidthWatermark" runat="server" value="50" Width="50"></asp:TextBox>
        </td>
        <td> MaxHight <asp:TextBox ID="txtMaxHightWatermark" runat="server" value="50" Width="50"></asp:TextBox></td>
         <td>
          
        </td>
    </tr>
    <tr>
        <td>Thư mục upload:</td>
        <td colspan="2">
            <asp:DropDownList ID="ddlFoldes" runat="server" Width="300"></asp:DropDownList>
        </td>
        <td>Tên mới (Để trắng sẽ lấy mặc định)</td>
        <td>
              <asp:TextBox ID="txtName" runat="server"  Width="300"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
    </tr>
    <tr>
        <td align="center" colspan="6">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
<asp:Image ID="Image1" runat="server" />
