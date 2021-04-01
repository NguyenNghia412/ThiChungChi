<%@ Page Title="Chi tiết bài thi" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietBaiThi.aspx.cs" Inherits="Thi_SV.ChiTietBaiThi" %>
<asp:Content ID="Style" ContentPlaceHolderID="MainStyle" runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divInitData" runat="server"></div>
    <div class="menu-frame" runat="server" id="divMenu" style="display: none;">
        <div style="width: 100%; text-align: center; padding-bottom: 10px; padding-top: 10px;" id="divMenuCauHoi" runat="server">
        </div>
    </div>
    <div class="content-frame">
         <table>
                <tr>
                    <td style="padding: 3px;">
                        <span style="font-weight: bold;">Thời gian nộp bài: </span>
                    </td>
                    <td style="padding: 3px;">
                        <span id="spanThoiGianNopBai" class="text-primary" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 3px;">
                        <span style="font-weight: bold;">Điểm thi: </span>
                    </td>
                    <td style="padding: 3px;">
                        <span id="spanDiemThi" class="text-primary" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding: 3px;">
                        <div style="color: red; cursor: pointer;" onclick="javascript:window.history.back();">Quay trở lại</div>
                    </td>
                </tr>
            </table>
        <%--<div style="width: 100%;" runat="server" id="divContent">
        </div>--%>
        <%--<div style="padding-bottom:200px; padding-top:50px;  color: red;">
            <table>
                <tr">
                    <td width="200px">Chữ ký giám thị 1</td>
                    <td width="200px">Chữ ký giám thị 2</td>
                    <td>Chữ ký thí sinh</td>
                </tr>
            </table>
        </div>--%>
        <%--<div style="color: red; cursor: pointer;" onclick="javascript:window.history.back();">Quay trở lại</div>--%>
    </div>
    <div id="divProcessData" runat="server"></div>
    <script>
        function gotocauhoi(thu_i) {
            $(document).scrollTop($("#divCauHoi_" + thu_i).offset().top - 50);
        };
        window.setTimeout("InitData();", 1000);
    </script>
</asp:Content>
