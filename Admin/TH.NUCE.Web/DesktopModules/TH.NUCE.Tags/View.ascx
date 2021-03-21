<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="TH.NUCE.Web.Tags.View" %>

<table>
    <tr>
        <td colspan="2">
            <div runat="server" id="divAnnouce"></div>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <div runat="server" id="divConent"></div>
        </td>
    </tr>
    <tr style="display: none;">
        <td>
            <asp:Label ID="lblGroup" runat="server" Text="tagGroup"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblName" runat="server" Text="Tên"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td> <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click" /></td>
        <td>
            <asp:Button ID="btnQuayLai" runat="server" Text="Quay lại" OnClick="btnQuayLai_Click"/>
        </td>
    </tr>
</table>
