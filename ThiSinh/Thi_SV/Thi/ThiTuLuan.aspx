<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThiTuLuan.aspx.cs" Inherits="Thi_SV.Thi.ThiTuLuan" %>
<asp:Content ID="Style" ContentPlaceHolderID="MainStyle" runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-row justity-content-center">
        <div>
            <input type="file" name="choose-file-btn" id="btn-choose-file"/>
        </div>
        <div>
            Chọn file: <button type="button" onclick="ThiTuLuan.uploadFile()">Upload file</button>
        </div>  
    </div> 
</asp:Content>
<asp:Content ID="Script" ContentPlaceHolderID="MainScript" runat="server">
    <script>
        let ThiTuLuan = {
            ID: -1,
            url: "/handler/nuce.thichungchi/",
            uploadFile: function () {
                const url = `${this.url}tcc_upload_thituluan.ashx?ID=${ThiTuLuan.ID}`;
                console.log(url);
                const fileInput = document.getElementById('btn-choose-file');
                const file = fileInput.files[0];
                const formData = new FormData();
                formData.append('file', file);
                $.ajax({
                    type: "POST",
                    url: url,
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (res) {
                        res = JSON.parse(res);
                        if (res.status === 0) {
                            console.log('success');
                            window.location.href = "/Thi/DanhSachKiThi";
                        } else {
                            console.log(res.msg);
                        }
                    },
                    error: function (err) {
                        console.log('error');
                    },
                });
            },
        };
    </script>
    <span runat="server" id="scrRun">

    </span>
</asp:Content>
