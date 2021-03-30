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
        .pt-5{
            padding-top: 5rem;
        }
        .p-5{
            padding: 5rem;
        }
        .mt-4{
            margin-top: 5rem;
        }
        .justify-content-center {
            display: flex;
            justify-content: center;
        }
        .justify-content-between {
            display: flex;
            justify-content: space-between !important;
        }
        .w-100 {
            width: 100% !important;
        }
        .h-100 {
            height: 100% !important;
        }
        .border {
            border: 1px solid #dee2e6!important;
        }
        .rounded {
            border-radius: 1.25rem!important;
        }
        .mx-0 {
            margin-left: 0;
            margin-right: 0
        }
        .mr-3 {
            margin-right: 3rem;
        }
        .text-danger {
            color: #dc3545!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w-100 h-100 bg pt-5">
        <div class="row justify-content-center mx-0">
            <div class="col-sm-12 col-md-5">
                <div class="border rounded p-5">
                    <div class="justify-content-between">
                        <div>
                            <h3 class="text-primary" style="text-align: center; font-weight: bold;">Tự luận</h3>
                        </div>
                        <div style="text-align: center;">
                            <h3 style="text-align: center; font-weight: bold; color: rgb(255, 0, 0);">
                                <span id="spMinutes"></span>
                                <span style="font-weight: bold;">Phút : </span>
                                <span id="spSeconds"></span>
                                <span style="font-weight: bold;">Giây </span>
                            </h3>
                        </div>
                    </div>
                    <h5 id="announcement" class="text-primary" style="text-align: center"></h5>
                    <div class="mt-4 row">
                        <input type="file" name="choose-file-btn" id="btn-choose-file"/>
                    </div>
                    <div class="mt-4 row">
                        <button type="button" class="btn btn-success" onclick="ThiTuLuan.uploadFile()">Nộp bài</button>
                        <button type="button" class="btn btn-danger" onclick="ThiTuLuan.roiPhong()">Rời phòng</button>
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
        let TimeThiTuLuan = {
            totalTime: 0,
            init: function (total) {
                this.totalTime = total;
                const minutes = Math.floor(this.totalTime / 60);
                const seconds = Math.floor(this.totalTime - (minutes * 60));
                //const seconds = this.totalTime % 60;
                //const minutes = (this.totalTime - seconds) / 60;
                
                $('#spMinutes').html(minutes);
                $('#spSeconds').html(seconds);
                setTimeout(() => {
                    TimeThiTuLuan.updateTime();
                }, 1000);
            },
            updateTime: function() {
                this.totalTime -= 1;
                if (this.totalTime > -1) {
                    //const seconds = this.totalTime % 60;
                    //const minutes = (this.totalTime - seconds) / 60;
                    const minutes = Math.floor(this.totalTime / 60);
                    const seconds = Math.floor(this.totalTime - (minutes * 60));
                    $('#spMinutes').html(minutes);
                    $('#spSeconds').html(seconds);
                    setTimeout(() => {
                        TimeThiTuLuan.updateTime();
                    }, 1000);
                    //if ((totalTime + 10) % 300 == 0) {
                    //    window.setTimeout("doPostBackAnswares2();", 5000);
                    //}
                }
                else {
                    //doPostBackAnswares();
                    //location.reload(true);
                }
            },
        };
    </script>
    <span runat="server" id="scrRun">

    </span>
</asp:Content>
