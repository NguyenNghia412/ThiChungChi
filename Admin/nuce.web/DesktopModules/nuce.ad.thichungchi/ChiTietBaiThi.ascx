<%@ control language="C#" autoeventwireup="true" codebehind="ChiTietBaiThi.ascx.cs" inherits="nuce.ad.thichungchi.ChiTietBaiThi" %>
<style type="text/css" media="print">
    @page 
    {
        size:  auto;   /* auto is the initial value */
        margin: 0mm;  /* this affects the margin in the printer settings */
    }

    html
    {
        background-color: #FFFFFF; 
        margin: 0px;  /* this affects the margin on the html before sending to printer */
    }

    body
    {
        margin: 10mm 15mm 10mm 15mm; /* margin you want for the content */
    }
    </style>
<div id="divInitData" runat="server"></div>
<div class="menu-frame" runat="server" id="divMenu" style="display: none;">
    <div style="width: 100%; text-align: center; padding-bottom: 10px; padding-top: 10px;" id="divMenuCauHoi" runat="server">
    </div>
</div>
<div class="content-frame" id="PrintDoc">
    <div style="width: 100%;" runat="server" id="divContent">
    </div>
    <div style="padding-bottom:200px; padding-top:50px;  color: red;">
        <table>
            <tr">
                <td width="200px">Chữ ký giám thị 1</td>
                <td width="300px">Chữ ký giám thị 2</td>
                <td>Chữ ký thí sinh</td>
            </tr>
        </table>
    </div>
    <div id="divProcessData" runat="server"></div>
</div>
<%--<div style="color: red; cursor: pointer;" onclick="javascript:window.history.back();">Quay trở lại</div>--%>
<%--<div style="color: red; cursor: pointer;" onclick="inPhieu();">In Phiếu</div>--%>

<script>
    function gotocauhoi(thu_i) {
        $(document).scrollTop($("#divCauHoi_" + thu_i).offset().top - 50);
    };
    window.setTimeout("InitData();", 1000);
    function inPhieu() {

        var divToPrint1 = $('#PrintDoc').html();
        var newWin = window.open('Share Certificate #001', '', 'width=1000px,height=700px');
        newWin.document.open();
        newWin.document.write('<html><body onload="window.print();">' + divToPrint1 + '</body></html>');
        newWin.document.close();
    }
</script>

