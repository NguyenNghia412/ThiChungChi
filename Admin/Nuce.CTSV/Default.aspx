<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Nuce.CTSV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Begin Page Content -->
    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800 text-center">HỆ THỐNG ĐĂNG KÝ THỦ TỤC HÀNH CHÍNH SINH VIÊN ONLINE
            </h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-body">
                <div class="card mb-3">
                    <div class="card-header">
                        Thông báo sinh viên
                   
                        <div class="d-inline-block float-right">
                            <button class="btn btn-primary">
                                <i class="fas fa-sync"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" id="divThongBaoSinhVien" runat="server">
                        <blockquote class="blockquote mb-0">
                            <div style="font-size: 1rem;">
                                <i class="fas fa-exclamation"></i>
                                <a href="#">Thông báo kiểm tra 1 - 22-07-2020</a>
                            </div>
                               <div style="font-size: 1rem;">
                                <i class="fas fa-exclamation"></i>
                                <a href="#">Thông báo kiểm tra 2 - 22-07-2020</a>
                            </div>
                        </blockquote>
                    </div>
                </div>
                <div class="card mb-3">
                    <div class="card-header">
                        Văn bản biểu mẫu
                   
                        <div class="d-inline-block float-right">
                            <button class="btn btn-primary">
                                <i class="fas fa-sync"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" id="divVanBan" runat="server">
                        <blockquote class="blockquote mb-0">
                            <div style="font-size: 1rem;">
                                <i class="fas fa-check"></i>
                                <a href="#">Quy chế miễn giảm học phí và hỗ trợ thực tập - 31-07-2020</a>
                            </div>

                        </blockquote>
                    </div>
                </div>
                <div class="card mb-3">
                    <div class="card-header">
                        Tuyển dụng
                   
                        <div class="d-inline-block float-right">
                            <button class="btn btn-primary">
                                <i class="fas fa-sync"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body" id="divTuyenDung" runat="server">
                        <blockquote class="blockquote mb-0">
                        </blockquote>
                    </div>
                </div>
                <div class="card mb-3">
                    <div class="card-header">
                        Học bổng
                   
                        <div class="d-inline-block float-right">
                            <button class="btn btn-primary">
                                <i class="fas fa-sync"></i>
                            </button>
                        </div>
                    </div>
                    <div class="card-body"  id="divHocBong" runat="server">
                        <blockquote class="blockquote mb-0">
                   
                        </blockquote>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->


</asp:Content>
