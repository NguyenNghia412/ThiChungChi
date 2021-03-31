﻿<%@ control language="C#" autoeventwireup="true" codebehind="QLNguoiThi.ascx.cs" inherits="nuce.ad.thichungchi.QLNguoiThi" %>
<%@ register tagprefix="dnn" tagname="TextEditor" src="../../controls/TextEditor.ascx" %>
<%@ register tagprefix="dnn" tagname="URLControl" src="../../controls/URLControl.ascx" %>

<style>
    #myModalThongTinThiSinh p{
        margin-bottom: 0;
    }
    #myModalImportExcel .modal-dialog{
        min-width: 1100px !important;
    }
</style>

<span id="spThongBao" runat="server"></span>
<span id="spThamSo" runat="server"></span>
<div class="row" style="padding-top: 5px;">
    <div class="col-sm-4">
        <input class="form-control" id="myInput" type="text" placeholder="Tìm kiếm..">
    </div>
    <div class="col-sm-2">
        <input class="form-control" id="txtSearchNgaySinh" type="text" placeholder="Ngày sinh..">
    </div>
    <div class="col-sm-3">
        <select class="form-control" id="slDanhMucSearch" style="width: 200px;" onchange='QuanLyNguoiThi.changeSlDanhMucSearch(this.value)'>
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
        </select>
    </div>
    <div class="col-sm-3">
        <div class="d-flex flex-row">
            <button type="button" class="btn btn-success" onclick=" QuanLyNguoiThi.downloadPwList();">Ds mật khẩu</button>
            <button type="button" class="btn btn-default ml-2" 
                    data-toggle="modal" data-target="#myModalImportExcel"
                    onclick="QuanLyNguoiThi.resetExcelView()"
                    id="btnUpload">Import excel</button>
        </div>
    </div>
</div>

<div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>#</th>
                <th>Mã</th>
                <th>Họ và tên</th>
                <th>Ngày sinh</th>
                <th>Số điện thoại</th>
                <th>Danh mục</th>
                <th style="width: 5%;"></th>
                <th style="width: 5%;"></th>
                <th style="width: 5%;"></th>
                <th style="width: 5%;"></th>
            </tr>
        </thead>
        <tbody id="tbContent">
        </tbody>
    </table>
</div>

<!-- Modal them sua -->
<div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog" style="width: 760px;">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title" id="edit_header">Modal Header</h4>
                <div id="edit_header_ThongBao" style="color: red;"></div>
            </div>
            <div class="modal-body form-inline row table-responsive" style="padding-bottom: 0px;">
                <table class="table">
                    <tr>
                        <td style="border: none;">
                            <table class="table" style="border: none;">
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Danh mục: </td>
                                    <td style="border: none;">
                                        <asp:DropDownList ID="ddlDanhMuc" class="form-control" runat="server" Style="width: 200px;"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Mã: </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtMa" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Họ:</td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtHo" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Tên: </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtTen" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ngày sinh: </br>(dd/MM/yyyy) </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtNgaySinh" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Nơi sinh: </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtNoiSinh" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Giới tính: </td>
                                    <td style="border: none;">
                                        <asp:RadioButtonList ID="rblGioiTinh" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Nam</asp:ListItem>
                                            <asp:ListItem Value="Nu">Nữ</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Số CMND: </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtCMT" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ngày cấp: </br>(dd/MM/yyyy)</td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtNgayCap" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border: none;">
                            <table class="table" style="border: none;">
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Nơi cấp: </td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtNoiCap" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Số điện thoại:</td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtMobile" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Email:</td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Địa chỉ:</td>
                                    <td style="border: none;">
                                        <asp:TextBox ID="txtDiaChi" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ảnh:</td>
                                    <td style="border: none;">
                                        <img class="img-rounded" runat="server" id="imgAnh" width="200">
                                        <asp:FileUpload ID="FileUploadControl" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
                <asp:Button class="btn btn-default" ID="btnCapNhat" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
            </div>
        </div>
    </div>
</div>
<div id="myModalThongTinThiSinh" class="modal fade" role="dialog">
    <div class="modal-dialog" style="width: 760px;">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Thông tin thí sinh</h4>
            </div>
            <div class="modal-body form-inline row table-responsive" style="padding-bottom: 0px;">
                <table class="table">
                    <tr>
                        <td style="border: none;">
                            <table class="table" style="border: none;">
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Danh mục: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtDanhMuc"></p>
                                        <%--<asp:DropDownList ID="DropDownList1" class="form-control" runat="server" Style="width: 200px;"></asp:DropDownList>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Mã: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtMaThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Họ:</td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtHoThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox2" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Tên: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtTenThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox3" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ngày sinh: </br>(dd/MM/yyyy) </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtNgaySinhThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox4" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Nơi sinh: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtNoiSinhThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox5" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Giới tính: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtGioiTinh"></p>
                                        <%--<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Nam</asp:ListItem>
                                            <asp:ListItem Value="Nu">Nữ</asp:ListItem>
                                        </asp:RadioButtonList>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Số CMND: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtCmnd"></p>
                                        <%--<asp:TextBox ID="TextBox6" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ngày cấp: </br>(dd/MM/yyyy)</td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtNgayCapCmnd"></p>
                                        <%--<asp:TextBox ID="TextBox7" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border: none;">
                            <table class="table" style="border: none;">
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Nơi cấp: </td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtNoiCapCmnd"></p>
                                        <%--<asp:TextBox ID="TextBox8" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Số điện thoại:</td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtSdt"></p>
                                        <%--<asp:TextBox ID="TextBox9" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Email:</td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtMail"></p>
                                        <%--<asp:TextBox ID="TextBox10" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Địa chỉ:</td>
                                    <td style="border: none;">
                                        <p runat="server" id="txtDiaChiThiSinh"></p>
                                        <%--<asp:TextBox ID="TextBox11" runat="server" class="form-control" Style="width: 200px;"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr style="border: none;">
                                    <td style="font-weight: bold; width: 35%; border: none;">Ảnh:</td>
                                    <td style="border: none;">
                                        <img src="''" class="img-rounded" runat="server" id="imgThiSinh" width="200" />
                                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
                <asp:Button class="btn btn-default" ID="Button1" runat="server" Text="Cập nhật" OnClick="btnCapNhat_Click" />
            </div>
        </div>
    </div>
</div>
<!-- Modal import excel -->
<div id="myModalImportExcel" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Import excel</h4>
            </div>
            <div class="modal-body" style="text-align: center;">
                <div class="row">
                    <div class="col-sm-2">
                        <input type="file" name="choose-file-btn" id="btn-choose-file"/>
                    </div>
                    <div class="col-sm-3">
                        Chọn file: <button type="button" onclick="QuanLyNguoiThi.uploadFile()">Upload file</button>
                    </div>
                    <div class="col-sm-6" style="text-align: right;">
                        <button type="button" class="btn btn-success btn-sm" onclick="QuanLyNguoiThi.postExcelData()">Lưu</button>
                    </div>
                </div>
                <div style="text-align: center;" id="divInportExcel_Upload">
                    <div>Nội dung file excel</div>
                    <div style="text-align: center;" id="div-excel-content"></div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Modal Confirm xoá -->
<div id="myModal1" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Bạn có chắc chắn muốn xóa ?</h4>
                <div id="edit_header_ThongBao1"></div>
            </div>
            <div class="modal-body" style="text-align: center;">
                <button type="button" class="btn btn-default" id="btnKhong" data-dismiss="modal">Không</button>
                <button type="button" class="btn btn-danger" id="btnXoa" onclick=" QuanLyNguoiThi.delete();">Xóa</button>
            </div>
        </div>
    </div>
</div>
<!-- Modal thông tin mật khẩu -->
<div id="myModal2" class="modal fade" role="dialog">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Thông tin mật khẩu</h4>
                <div class="row">
                    <div class="col-sm-4" style="background-color: lavender;">Mật khẩu</div>
                    <div class="col-sm-8" style="background-color: lavenderblush;" id="divMatKhau"></div>
                </div>
                <div id="edit_header_ThongBao2" style="color: red; font-weight: bold;"></div>
            </div>
            <div class="modal-body" style="text-align: center;">
                <button type="button" class="btn btn-default" id="btnResetMatKhau" onclick=" QuanLyNguoiThi.resetMatKhau();">Reset Mật khẩu</button>
                <button type="button" class="btn btn-default" id="btnKhoaTaiKhoan" onclick=" QuanLyNguoiThi.khoaTaiKhoan();">Khóa tài khoản</button>
                <button type="button" class="btn btn-default" id="btnThoat" data-dismiss="modal">Thoát</button>
            </div>
        </div>
    </div>
</div>
<div style="display: none;">
    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
     <asp:TextBox ID="txtLinkUpload" runat="server"></asp:TextBox>
</div>
<link rel="stylesheet" href="/Scripts/bootstrap-datepicker-1.9.0/css/bootstrap-datepicker.min.css" />
<script src="/Scripts/bootstrap-datepicker-1.9.0/js/bootstrap-datepicker.min.js"></script>
<script>
    (function ($) {
        $.fn.serializeAny = function () {
            var ret = [];
            $.each($(this).find(':input'), function () {
                if (this.name != "")
                    ret.push(encodeURIComponent(this.name) + "=" + encodeURIComponent($(this).val()));
            });

            return ret.join("&").replace(/%20/g, "+");
        }
    })(jQuery);
    var QuanLyNguoiThi = {
        ID: -1,
        Data: [],
        saveExcelData: [],
        DataDanhMuc: [],
        DatePickerID: ['txtSearchNgaySinh'],
        url: "/handler/nuce.ad.thichungchi/",
        initDatePicker() {
            this.DatePickerID.forEach(id => {
                $(`#${id}`).datepicker({
                    format: 'dd/mm/yyyy'
                });
            });
            this.setSearchNgaySinhEvent();
        },
        setSearchNgaySinhEvent: function() {
            $(`#txtSearchNgaySinh`).keyup(event => {
                console.log(event);
                if (event.keyCode === 13) {
                    QuanLyNguoiThi.bindData1();
                }
            });
        },
        resetMatKhau: function () {
            $.getJSON(this.url + "ad_tcc_resetmatkhau.ashx?ID=" + QuanLyNguoiThi.ID, function (data) {
                if (data == 1) {
                    QuanLyNguoiThi.bindData1();
                    setTimeout(QuanLyNguoiThi.initBaoMat1, 500);
                    $("#edit_header_ThongBao2").show();
                    $("#edit_header_ThongBao2").html("Đổi mật khẩu thành công");
                }
                else {
                    $("#edit_header_ThongBao2").show();
                    $("#edit_header_ThongBao2").html("Lỗi hệ thống");
                }
            });
        },
        khoaTaiKhoan: function () {
            $.getJSON(this.url + "ad_tcc_khoataikhoan.ashx?ID=" + QuanLyNguoiThi.ID, function (data) {
                if (data == 1) {
                    QuanLyNguoiThi.bindData1();
                    setTimeout(QuanLyNguoiThi.initBaoMat1, 500);
                    $("#edit_header_ThongBao2").show();
                    $("#edit_header_ThongBao2").html("Chuyển trạng thái thành công");
                }
                else {
                    $("#edit_header_ThongBao2").show();
                    $("#edit_header_ThongBao2").html("Lỗi hệ thống");
                }
            });
        },
        init: function () {
            $.getJSON(this.url + "ad_tcc_getdanhmuc.ashx", function (data) {
                QuanLyNguoiThi.DataDanhMuc = data;
                var strHtml = "";
                var strHtmlSearch = "<option value=\"-1\">Lựa chọn Danh mục</option>";
                $.each(data, function (i, item) {
                    strHtml += "<option value=\"" + item.ID + "\">" + item.Ten + "</option>";
                    strHtmlSearch += "<option value=\"" + item.ID + "\">" + item.Ten + "</option>";
                });
                //$("#" + strCtl + "slDanhMuc").html(strHtml);
                $("#slDanhMucSearch").html(strHtmlSearch);
            });
            QuanLyNguoiThi.bindData('', '-1', '');
            QuanLyNguoiThi.initDatePicker();
        },
        changeSlDanhMucSearch: function (giatri) {
            QuanLyNguoiThi.bindData($('#myInput').val(), giatri);
        },
        changeSearchNgaySinh: function () {
            QuanLyNguoiThi.bindData1();
        },
        bindData1: function () {
            QuanLyNguoiThi.bindData($('#myInput').val(), $('#slDanhMucSearch').val(), $('#txtSearchNgaySinh').val());
        },
        bindData: function (text, giatridanhmuc, ngaySinh) {
            $('#tbContent').html("");
            $.getJSON(this.url + "ad_tcc_getnguoithi.ashx?search=" + text + "&&danhmuc=" + giatridanhmuc + "&&ngaysinh="+ ngaySinh + "&&nocache='" + (new Date()).getTime(), function (data) {
                //alert(data);
                QuanLyNguoiThi.Data = data;
                var strHtml = "";
                var count = 1;
                $.each(data, function (i, item) {
                    strHtml += "<tr>";
                    strHtml += "<td>" + count + "</td>";
                    strHtml += "<td>" + item.Ma + "</td>";
                    strHtml += "<td>" + item.Ho + " " + item.Ten + "</td>";
                    strHtml += "<td>" + item.NgaySinhVN + "</td>";
                    strHtml += "<td>" + item.Mobile + "</td>";
                    strHtml += "<td>" + item.DanhMuc + "</td>";
                    strHtml += "<td><button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#myModal2\" onclick=\"QuanLyNguoiThi.initBaoMat(" + item.ID + ");\">Mật khẩu</button></td>";
                    if (item.Type == 1) {
                        strHtml += "<td><button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"QuanLyNguoiThi.update(" + item.ID + ");\">Sửa</button></td>";
                        strHtml += "<td><button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal1\" onclick=\"QuanLyNguoiThi.view(" + item.ID + ");\">Thông tin</button></td>";
                        //strHtml += "<td><button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"QuanLyNguoiThi.add();\">Thêm mới</button></td>";
                        strHtml += "<td><button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#myModal1\" onclick=\"QuanLyNguoiThi.initDelete(" + item.ID + ");\">Xóa</button></td>";
                    }
                    else {
                        strHtml += "<td colspan='2' style='text-align: center;font-weight: bold;'>Tài khoản bị khóa</td>";
                    }
                    strHtml += "</tr>";
                    count++;
                });
                strHtml += "<tr>";
                strHtml += "<td colspan='9' style='text-align:right;'><button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"QuanLyNguoiThi.add();\">Thêm mới</button></td>";
                strHtml += "</tr>";
                $('#tbContent').html(strHtml);
            });
        },
        add: function () {
            QuanLyNguoiThi.ID = -1;
            $("#edit_header").html("Thêm mới");
            $("#edit_header_ThongBao").hide();
            $("#" + strCtl + "txtMa").val("");
            $("#" + strCtl + "txtHo").val("");
            $("#" + strCtl + "txtTen").val("");
            $("#" + strCtl + "txtCMT").val("");
            $("#" + strCtl + "txtNgaySinh").val("");
            $("#" + strCtl + "txtNoiSinh").val("");
            $("#" + strCtl + "txtMobile").val("");
            $("#" + strCtl + "txtEmail").val("");
            $("#" + strCtl + "txtDiaChi").val("");
            $("#" + strCtl + "txtNgayCap").val("");
            $("#" + strCtl + "txtID").val("-1");
            $("#" + strCtl + "imgAnh").attr("src", "");

        },
        update: function (id) {
            window.location.href = link_root + "?ID=" + id;
        },
        view: function (id) {
            window.location.href = `${link_root}?ID=${id}&mode=view`;
        },
        uploadFile: function () {
            const url = `${this.url}ad_tcc_read_excel_thisinh.ashx`;
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
                    $(`#div-excel-content`).html(res.view);
                    QuanLyNguoiThi.saveExcelData = JSON.parse(res.data);
                },
                error: function (err) {
                    console.log('error');
                },
            });
        },
        postExcelData: function () {
            const data = JSON.stringify(QuanLyNguoiThi.saveExcelData);
            const url = `${this.url}ad_tcc_save_import_excel_thisinh.ashx`;
            console.log(data);
            $.ajax({
                type: 'POST',
                url: url,
                data: data,
                success: function (res) {
                    $('#myModalImportExcel').modal('hide');
                    QuanLyNguoiThi.bindData1();
                },
                error: function (err) {
                    console.log(err);
                },
            });
        },
        resetExcelView: function () {
            $(`#div-excel-content`).html('');
        },
        downloadPwList: function () {
            const searchText = $('#myInput').val() || '';
            const danhmuc = $(`#slDanhMucSearch`).val() || '';
            console.log(searchText, danhmuc);
            const url = `/ExportExcel.aspx?type=8&&search=${searchText}&&danhmuc=${danhmuc}`;
            window.open(url);
        },
        initBaoMat: function (id) {
            QuanLyNguoiThi.ID = id;
            $("#edit_header_ThongBao2").hide();
            $.each(QuanLyNguoiThi.Data, function (i, item) {
                if (item.ID == id) {
                    divMatKhau.innerText = item.MatKhau;
                    if (item.Type == 2) {
                        $('#btnKhoaTaiKhoan').text("Mở tài khoản");
                    }
                }
            });
        },
        initBaoMat1: function () {
            $.each(QuanLyNguoiThi.Data, function (i, item) {
                if (item.ID == QuanLyNguoiThi.ID) {
                    divMatKhau.innerText = item.MatKhau;
                    if (item.Type == 2) {
                        $('#btnKhoaTaiKhoan').text("Mở tài khoản");
                    }
                    else
                        $('#btnKhoaTaiKhoan').text("Đóng tài khoản");
                }
            });
        }
        ,
        initDelete: function (id) {
            QuanLyNguoiThi.ID = id;
            $("#edit_header_ThongBao1").hide();
            $('#btnXoa').show();
        },
        delete: function () {
            //Update
            $.getJSON(this.url + "ad_tcc_deletenguoithi.ashx?ID=" + QuanLyNguoiThi.ID, function (data) {
                if (data == 1) {
                    $("#edit_header_ThongBao1").show();
                    $("#edit_header_ThongBao1").html("Xóa thành công");
                    $('#btnKhong').text("Thoát");
                    $('#btnXoa').hide();
                    QuanLyNguoiThi.bindData1();
                }
                else {
                    $("#edit_header_ThongBao1").show();
                    $("#edit_header_ThongBao1").html("Lỗi hệ thống");
                }
            });
        },
        message: function (id, header, message) {
            $('#' + id).modal('show');
            $("#edit_header").html(header);
            $("#edit_header_ThongBao").show();
            $("#edit_header_ThongBao").html(message);
        },
        openModal: function (id) {
            $('#' + id).modal('show');
        },
        upload:function()
        {
            var url = $("#" + strCtl + "txtLinkUpload").val() +"/"+ $('#slDanhMucSearch').val();
            window.location.href = url;
        }
    };
    QuanLyNguoiThi.init();

</script>
<span id="spScript" runat="server"></span>
<script>
    $(document).ready(function () {
        $(document).keypress(function (event) {

            var keycode = (event.keyCode ? event.keyCode : event.which);
            if (keycode == '13') {
                var search = $('#myInput').val();
                QuanLyNguoiThi.bindData1();
                event.preventDefault();
            }

        });
    });
</script>

