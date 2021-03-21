<%@ Page Title="Chi tiết bài tin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietBaiTin.aspx.cs" Inherits="Nuce.CTSV.ChiTietBaiTin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800 text-center" runat="server" id="div_title">Hệ thống thông tin sinh viên
            </h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-body">
                <div class="content-box-large">
                    <div class="row" runat="server" id="div_description" style="font-weight: bold; padding: 5px;">
                    </div>
                    <div class="row" runat="server" id="div_new_content">
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
