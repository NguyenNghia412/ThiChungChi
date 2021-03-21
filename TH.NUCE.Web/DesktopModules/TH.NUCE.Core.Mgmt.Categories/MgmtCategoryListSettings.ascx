<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MgmtCategoryListSettings.ascx.cs" Inherits="TH.NUCE.Web.MgmtCategoryListSettings" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
<table cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr><td colspan="2"><asp:Label style="font-family:Tahoma; font-size:11px; padding-bottom:5px;" id="lblNotice" runat="server" ResourceKey = "lblNotice.Text" CssClass="Normal"></asp:Label></td></tr>
    <!-- Type input. -->
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblType" runat="server" controlname="cboType" suffix=":"></dnn:label></td>
		<td width="70%"><asp:DropDownList id="cboType" runat="server" CssClass="Normal"></asp:DropDownList></td>
	</tr>
	<!-- TypeInclude. -->
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblTypeInclude" runat="server" controlname="cboType" suffix=":"></dnn:label></td>
		<td width="70%"><asp:TextBox ID="txtTypeInclude" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
			<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblTypeReturn" runat="server" controlname="cboType" suffix=":"></dnn:label></td>
		<td width="70%"><asp:TextBox ID="txtTypeReturn" runat="server"></asp:TextBox></td>
	</tr>
	 <!-- Category - Recycle Bin Settings. -->
	<tr>
		<td>&nbsp;<dnn:label CssClass="SubHead" id="lblRecycleBin" runat="server" controlname="cboRecycleBin" suffix=":"></dnn:label></td>
		<td><asp:DropDownList id="cboRecycleBin" runat="server" CssClass="Normal"></asp:DropDownList></td>
	</tr>
	<!-- Category - Related Settings. -->
    <tr>
		<td>&nbsp;<dnn:label CssClass="SubHead" id="lblRelated" runat="server" controlname="cboRelated" suffix=":"></dnn:label></td>
		<td><asp:DropDownList id="cboRelated" runat="server" CssClass="Normal"></asp:DropDownList></td>
	</tr>
	<!-- Category - Tag Group Settings. -->
	<tr>
		<td>&nbsp;<dnn:label CssClass="SubHead" id="lblTypeGroup" runat="server" controlname="cboTypeGroup" suffix=":"></dnn:label></td>
		<td><asp:DropDownList id="cboTypeGroup" runat="server" CssClass="Normal"></asp:DropDownList></td>
	</tr>
	<!-- Thiet lap cac truong an hien -->
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblDip1" runat="server" controlname="chkDip1" suffix=":"></dnn:label></td>
		<td width="70%"><asp:CheckBox ID="chkDip1" runat="server"/>&nbsp;Name<asp:TextBox ID="txtDip1" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblDip2" runat="server" controlname="chkDip2" suffix=":"></dnn:label></td>
		<td width="70%"><asp:CheckBox ID="chkDip2" runat="server"/>&nbsp;Name<asp:TextBox ID="txtDip2" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblDip3" runat="server" controlname="chkDip3" suffix=":"></dnn:label></td>
		<td width="70%"><asp:CheckBox ID="chkDip3" runat="server"/>&nbsp;Name<asp:TextBox ID="txtDip3" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblDip4" runat="server" controlname="chkDip4" suffix=":"></dnn:label></td>
		<td width="70%"><asp:CheckBox ID="chkDip4" runat="server"/>&nbsp;Name<asp:TextBox ID="txtDip4" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td width="30%">&nbsp;<dnn:label CssClass="SubHead" id="lblDip5" runat="server" controlname="chkDip5" suffix=":"></dnn:label></td>
		<td width="70%"><asp:CheckBox ID="chkDip5" runat="server"/>&nbsp;Name<asp:TextBox ID="txtDip5" runat="server"></asp:TextBox></td>
	</tr>
</table>