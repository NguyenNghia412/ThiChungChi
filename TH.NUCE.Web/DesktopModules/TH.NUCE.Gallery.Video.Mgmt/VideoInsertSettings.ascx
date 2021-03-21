<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoInsertSettings.ascx.cs"
    Inherits="TH.NUCE.Web.VideoInsertSettings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<table cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
        <td colspan="2" align="left">
            <asp:Label class="Normal" ID="lblNoticeArticle" runat="server" ResourceKey="lblNotice.Text"></asp:Label>
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td width="30%" align="left" class="SubHead">
            <dnn:Label ID="lblFolders" runat="server" ControlName="cboFolders" Suffix=":"></dnn:Label>
        </td>
        <td width="70%">
            <asp:DropDownList ID="cboFolders" runat="server" class="Normal">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="30%" align="left" class="SubHead">
            <dnn:Label ID="lblExtension" runat="server" ControlName="txtExtension" Suffix=":"></dnn:Label>
        </td>
        <td width="70%">
            <asp:TextBox ID="txtExtension" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
        </td>
    </tr>
</table>
