<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoInsert.ascx.cs"
    Inherits="TH.NUCE.Web.VideoInsert" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="../../controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URLControl" Src="../../controls/URLControl.ascx" %>
<%@ Reference Control="~/DesktopModules/TH.NUCE.Gallery.Video.Mgmt/VideoInsertSettings.ascx" %>
<style type="text/css">
    td > .dnnTooltip label {
        text-align: left;
    }
</style>
<p align="center" class="Normal" style="color: Red;">
    <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
</p>
<table width="100%">
    <!-- Input Title  -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblTitle" runat="server" ControlName="txtTitle" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2" width="85%">
            <asp:TextBox ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <!-- Input Summary -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblSummary" runat="server" ControlName="txtSummary" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtSummary" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input VideoFile -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblVideoFile" runat="server" ControlName="txtVideoFile" Suffix=":"></dnn:Label>
        </td>
        <td>
            <input id="txtVideoFile" type="file" name="txtVideoFile" runat="server" />
        </td>
        <td>
            <asp:CheckBox ID="chIsUrlWeb" runat="server" Text="IsUrlWeb" />
            <span id="spVideoFileOld" runat="server"></span>
        </td>
    </tr>
    <!-- Input Avatar -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAvatar" runat="server" ControlName="txtAvatar" Suffix=":"></dnn:Label>
        </td>
        <td>
            <input id="txtAvatar" type="file" name="txtAvatar" runat="server" visible="False"/>
            <dnn:URLControl ID="urlAvatar" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
            <input id="File1" type="file" name="urlAvatar" runat="server" visible="False" />
        </td>
        <td>
            <img runat="server" id="imgAvatar" width="200" />
            ( Ảnh Cũ: <span id="spAvatar" runat="server"></span>)
               <%-- <img  id="imgAvatar" runat="server" width="200px;"/> ( Ảnh Cũ: <span id="spAvatar" runat="server"></span> )--%>
        </td>
    </tr>
    <!-- Input LengthVideo -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblLengthVideo" runat="server" ControlName="txtLengthVideo" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtLengthVideo" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <!-- Input Content -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblContent" runat="server" ControlName="htmlContent" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <dnn:TextEditor ID="htmlContent" runat="server" Mode="Rich" Width="85%" Height="400"></dnn:TextEditor>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblExpiredDate" runat="server" ControlName="txtExpiredDate" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtExpiredDate" runat="server" Width="100px"></asp:TextBox>
            <asp:HyperLink ID="lnkExpiredDate" runat="server">
                <asp:Image ID="imgExpiredDate" runat="server" resourceKey="CalendarAlt.Text" />
            </asp:HyperLink>
        </td>
        <td align="left">
            <asp:Label ID="lblFormatterDateE" ForeColor="red" runat="server">(dd/mm/yyyy)</asp:Label>
            &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblDisplayDate" runat="server" ControlName="txtImageNote" Suffix=":"></dnn:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDisplayDate" runat="server" Width="100px"></asp:TextBox>
            <asp:HyperLink ID="lnkDisplayDate" runat="server">
                <asp:Image ID="imgDisplayDate" runat="server" resourceKey="CalendarAlt.Text" />
            </asp:HyperLink>
        </td>
        <td style="text-align: left;">
            <asp:Label ID="lblFormatterDateF" ForeColor="red" runat="server">(dd/mm/yyyy)</asp:Label>
        </td>
    </tr>
    <!-- Input IsHot -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblIsHot" runat="server" ControlName="chkIsHot" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <span style="display: none;">
                <asp:CheckBox ID="chkIsHot" runat="server" />
                <asp:TextBox ID="txtHotPeriod" runat="server" Text="0"></asp:TextBox>
                <asp:Label ID="lblDays" runat="server" ResourceKey="lblDays.Text"></asp:Label>
            </span>
        </td>
    </tr>
    <!-- Input ChkCategories -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblCategories" runat="server" ControlName="chkCategoryList" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:CheckBoxList ID="chkCategoryList" runat="server" CssClass="Normal" RepeatColumns="2">
            </asp:CheckBoxList>
        </td>
    </tr>
    <!-- Input Order -->
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblOrder" runat="server" ControlName="txtOrder" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtOrder" runat="server" Width="20%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo1" runat="server" ControlName="txtAddInfo1" Text="AddInfo1" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtAddInfo1" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo2" runat="server" ControlName="txtAddInfo2" Text="AddInfo2" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtAddInfo2" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo3" runat="server" ControlName="txtAddInfo3" Text="AddInfo3" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtAddInfo3" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo4" runat="server" ControlName="txtAddInfo4" Text="AddInfo4" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtAddInfo4" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="SubHead">
            <dnn:Label ID="lblAddInfo5" runat="server" ControlName="txtAddInfo5" Text="AddInfo5" Suffix=":"></dnn:Label>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtAddInfo5" runat="server" Width="100%"></asp:TextBox>
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
<asp:TextBox ID="txtTitleOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtVideoFileOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtAvatarOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtCreatedDateOld" runat="server" Visible="false"></asp:TextBox>
