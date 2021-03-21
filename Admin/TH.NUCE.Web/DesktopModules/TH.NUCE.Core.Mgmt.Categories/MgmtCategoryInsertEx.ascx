<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MgmtCategoryInsertEx.ascx.cs"
    Inherits="TH.NUCE.Web.MgmtCategoryInsertEx" %>
<%@ Reference Control="~/DesktopModules/TH.NUCE.Core.Mgmt.Categories/MgmtCategoryListSettings.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URLControl" Src="../../controls/URLControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="../../controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<style type="text/css">
    td > .dnnTooltip label {
        text-align: left;
    }
</style>
<p align="center" class="Normal" style="color: Red;">
    <asp:Label ID="lblError" runat="server" Visible="true">Thêm mới danh mục</asp:Label>
</p>
<table width="100%">
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblType" runat="server" ControlName="cboType" Suffix=":"></dnn:Label>
        </td>
        <td width="85%">
            <asp:DropDownList ID="cboType" runat="server" Width="100%" OnSelectedIndexChanged="cboType_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td width="150px" class="SubHead">
            <dnn:Label ID="lblName" runat="server" ControlName="txtName" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblCategories" runat="server" ControlName="cbCategories" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:DropDownList ID="cbCategories" runat="server" Width="100%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDescription" runat="server" ControlName="htmlDescription" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="htmlDescription" runat="server" Height="200px" Width="100%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDefaultFolder" runat="server" ControlName="cbDefaultFolder" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:DropDownList ID="cbDefaultFolder" runat="server" Width="100%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr style="display: none;">
        <td class="SubHead">
            <dnn:Label ID="lblIsNeedApprove" runat="server" ControlName="chkIsNeedApprove" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsNeedApprove" runat="server" />
        </td>
    </tr>
    <tr style="display: none;">
        <td class="SubHead">
            <dnn:Label ID="lblIsNeedPublic" runat="server" ControlName="chkIsNeedPublic" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsNeedPublic" runat="server" />
        </td>
    </tr>
    <tr style="display: none;">
        <td class="SubHead">
            <dnn:Label ID="lblIsDefaultXSL" runat="server" ControlName="chkIsDefaultXSL" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chkIsDefaultXSL" runat="server" Checked="true" />
        </td>
    </tr>
    <tr style="display: none;">
        <td class="SubHead">
            <dnn:Label ID="lblXslFile" runat="server" ControlName="urlXslFile" Suffix=":"></dnn:Label>
        </td>
        <td>
            <dnn:URLControl ID="urlXslFile" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="xsl,xslt" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="true" ShowUsers="false" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblIcon" runat="server" ControlName="urlIcon" Suffix=":"></dnn:Label>
        </td>
        <td>
            <dnn:URLControl ID="urlIcon" ShowFiles="true" ShowLog="False" ShowTrack="False" FileFilter="jpg,jpeg,gif,png"
                ShowUrls="False" ShowTabs="False" Required="false" runat="server" ShowNone="false"
                ShowSecure="true" ShowUpLoad="true" ShowUsers="false" />
        </td>
    </tr>
    <tr style="display: none;">
        <td class="SubHead">
            <dnn:Label ID="lblExtended" runat="server" ControlName="txtExtended" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtExtended" runat="server" Width="100%" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblToolTip" runat="server" ControlName="txtToolTip" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtToolTip" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblOrder" runat="server" ControlName="txtOrder" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtOrder" runat="server" Width="10%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDip1" runat="server" ControlName="chbDip1" Suffix=":" Text="Dip1"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chbDip1" runat="server" Width="10%" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDip2" runat="server" ControlName="chbDip2" Suffix=":" Text="Dip2"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chbDip2" runat="server" Width="10%" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDip3" runat="server" ControlName="chbDip3" Suffix=":" Text="Dip3"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chbDip3" runat="server" Width="10%" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDip4" runat="server" ControlName="chbDip4" Suffix=":" Text="Dip4"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chbDip4" runat="server" Width="10%" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDip5" runat="server" ControlName="chbDip5" Suffix=":" Text="Dip5"></dnn:Label>
        </td>
        <td>
            <asp:CheckBox ID="chbDip5" runat="server" Width="10%" />
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo1" runat="server" ControlName="txtAddInfo1" Suffix=":" Text="AddInfo1"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddInfo1" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo2" runat="server" ControlName="txtAddInfo2" Suffix=":" Text="AddInfo2"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddInfo2" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo3" runat="server" ControlName="txtAddInfo3" Suffix=":" Text="AddInfo3"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtAddInfo3" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo4" runat="server" ControlName="txtAddInfo4" Suffix=":" Text="AddInfo4"></dnn:Label>
        </td>
        <td>
            <dnn:TextEditor ID="txtAddInfo4" runat="server" Mode="Rich" Width="100%" Height="400"></dnn:TextEditor>
            <%-- <asp:TextBox ID="txtAddInfo4" runat="server" Width="100%"></asp:TextBox>--%>
        </td>
    </tr>
    <tr>
        <td class="SubHead">

            <dnn:Label ID="lblAddInfo5" runat="server" ControlName="txtAddInfo5" Suffix=":" Text="AddInfo5"></dnn:Label>
        </td>
        <td>
            <%-- <asp:TextBox ID="txtAddInfo5" runat="server" Width="100%"></asp:TextBox>--%>
            <dnn:TextEditor ID="txtAddInfo5" runat="server" Mode="Rich" Width="100%" Height="400"></dnn:TextEditor>
        </td>
    </tr>

    <tr>
        <td></td>
        <td colspan="2">
            <asp:Button runat="server" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
            <asp:Button runat="server" Text="Rerturn" ID="btnReturn" OnClick="btnReturn_Click" />
        </td>
    </tr>
</table>
