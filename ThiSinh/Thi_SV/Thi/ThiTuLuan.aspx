<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThiTuLuan.aspx.cs" Inherits="Thi_SV.Thi.ThiTuLuan" %>
<asp:Content ID="Style" ContentPlaceHolderID="MainStyle" runat="server">
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <style>
        html, body {
            width: 100%;
            height: 100%;
        }
        body {
            padding: 0;
        }
        .bg {
            background-image: url('../Images/Nuce/tuluan-bg.jpg');
            background-size: cover;
        }
    </style>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w-100 h-100 bg pt-5">
        <div class="row justify-content-center mx-0">
            <div class="col-sm-12 col-md-5">
                <div class="border rounded p-5">
                    <h4 class="text-danger" style="text-align: center">Tự luận</h4>
                    <h5 id="announcement" class="text-primary" style="text-align: center"></h5>
                    <div class="mt-4 row justify-content-between">
                        <input type="file" name="choose-file-btn" id="btn-choose-file"/>
                    </div>
                    <div class="mt-4 row justify-content-between">
                        <button type="button" class="btn btn-success btn-sm" onclick="ThiTuLuan.uploadFile()">Nộp bài</button>
                        <button type="button" class="btn btn-danger btn-sm ml-3" onclick="ThiTuLuan.roiPhong()">Rời phòng</button>
                    </div>  
                </div>
            </div>
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
                            window.location.href = "/Thi/DanhSachKiThi";
                        }
                        $(`#announcement`).html(res.msg);
                    },
                    error: function (err) {
                        console.log('error');
                    },
                });
            },
            roiPhong: function () {
                window.location.href = "/Thi/DanhSachKiThi"
            },
        };
    </script>
    <span runat="server" id="scrRun">

    </span>
</asp:Content>
