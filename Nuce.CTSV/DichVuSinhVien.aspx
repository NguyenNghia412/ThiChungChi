<%@ Page Title="Dịch vụ sinh viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DichVuSinhVien.aspx.cs" Inherits="Nuce.CTSV.DichVuSinhVien" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Begin Page Content -->
    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800 text-center">
            <div style="color: RGB(45,62,153); font-weight: bold;">THỦ TỤC HÀNH CHÍNH</div>
        </h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4 d-flex">
            <div class="row">
                <div class="col-sm-3 ml-5 mb-2">
                    <a href="/dichvu/xacnhan.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">Giấy xác nhận</div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/giay-xac-nhan.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>
                <div class="col-sm-3 ml-5 mb-2">
                    <a href="/dichvu/GioiThieu.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Giấy giới thiệu
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/Giay-Gioi-Thieu-Max-Quality.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>
         <%--       <div class="col-sm-4 ml-5 mb-2">
                    <a href="/dichvu/CapLaiTheSinhVien.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Cấp lại thẻ sinh viên
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/the-sinh-vien-Max-Quality.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>--%>
            </div>
         <%--   <div class="row">
                <div class="col-sm-3 ml-5 mb-2">
                    <a href="/dichvu/XacNhanUuDaiTrongGiaoDuc.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Ưu đãi trong giáo dục
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/Uu-dai-giao-duc-Max-Quality.jpg"
                                style="max-width: 90%;" />

                        </div>
                    </a>
                </div>
                <div class="col-sm-3 ml-5 mb-2">
                    <a href="/dichvu/MuonHocBaGoc.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Mượn học bạ gốc
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/muon-hoc-ba-Max-Quality.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>
                <div class="col-sm-4 ml-5 mb-2">
                    <a href="/DichVuSinhVien.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Thuê KTX Pháp Vân - Tứ Hiệp
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/KTX.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>
            </div>
            <div class="row" style="padding-bottom: 10px;">
                <div class="col-sm-3 ml-5 mb-2">
                    <a href="/DichVuSinhVien.aspx" style="cursor: pointer">
                        <div style="text-align: center; font-weight: bold; padding-top: 15px; padding-bottom: 10px;">
                            Vay vốn ngân hàng
                        </div>
                        <div style="text-align: center;">
                            <img
                                width="200px"
                                src="/Data/icons/VAY_VON.jpg"
                                style="max-width: 90%;" />
                        </div>
                    </a>
                </div>
            </div>--%>
        </div>
    </div>
    <!-- /.container-fluid -->
</asp:Content>
