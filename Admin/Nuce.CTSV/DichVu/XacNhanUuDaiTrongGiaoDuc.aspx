<%@ Page Title="Dịch vụ sinh viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XacNhanUuDaiTrongGiaoDuc.aspx.cs" Inherits="Nuce.CTSV.XacNhanUuDaiTrongGiaoDuc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        ul.breadcrumb {
            padding: 10px 16px;
            list-style: none;
            background-color: #fafafd;
        }

            ul.breadcrumb li {
                display: inline;
                font-size: 14px;
            }

                ul.breadcrumb li + li:before {
                    padding: 8px;
                    color: black;
                    content: "/\00a0";
                }

                ul.breadcrumb li a {
                    color: #0275d8;
                    text-decoration: none;
                }

                    ul.breadcrumb li a:hover {
                        color: #01447e;
                        text-decoration: underline;
                    }
    </style>

    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="edit_header">Modal Header</h4>
                    <div id="edit_header_ThongBao" style="color: red;"></div>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="TrangThai">Nhập mã:</label>
                        <input type="text" class="form-control" id="txtMa">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
                    <button type="button" class="btn btn-default" id="btnXacNhanUuDaiTrongGiaoDucXa" onclick=" XacNhanUuDaiTrongGiaoDuc.update();">Xác nhận mã</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Modal xoa -->
    <div id="myModal1" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="lblThongBaoXoa">Bạn có chắc chắn muốn thực hiện ?</h4>
                    <div id="edit_header_ThongBao1"></div>
                </div>
                <div class="modal-body" style="text-align: center;">
                    <button type="button" class="btn btn-default" id="btnKhong" data-dismiss="modal">Không</button>
                    <button type="button" class="btn btn-danger" id="btnXoa" onclick=" XacNhanUuDaiTrongGiaoDuc.delete();">Thực hiện</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal Hoan thanh -->
    <div id="myModal2" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="lblThongHoanThanh">Bạn có chắc chắn muốn thực hiện ?</h4>
                    <div id="edit_header_ThongBao2"></div>
                </div>
                <div class="modal-body" style="text-align: center;">
                    <button type="button" class="btn btn-default" id="btnKhong2" data-dismiss="modal">Không</button>
                    <button type="button" class="btn btn-danger" id="btnHoanThanh" onclick=" XacNhanUuDaiTrongGiaoDuc.complete();">Thực hiện</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row row-no-gutters">
            <div class="col-sm-8">
                <ul class="breadcrumb">
                    <li><a href="/dichvusinhvien">Dịch Vụ</a></li>
                    <li>Xác nhận ưu đãi trong giáo dục</li>
                </ul>
            </div>
            <div class="col-sm-4" style="text-align: right;">
                <button type="button" class="btn btn-primary" onclick="XacNhanUuDaiTrongGiaoDuc.ThemMoi();">Thêm mới</button>
            </div>
        </div>
        <div class="card shadow mb-4 d-flex">
            <div class="table-responsive">
                <table class="table table-bordered" width="100%" cellspacing="0">
                    <thead>
                        <tr>
                            <th style="text-align: center;">STT</th>
                            <th style="text-align: center;">Ngày tạo</th>
                            <th style="text-align: center;">Lý do</th>
                            <th style="text-align: center;">Trạng thái</th>
                        </tr>
                    </thead>
                    <tbody runat="server" id="tbContent">
                    </tbody>
                </table>
            </div>
        </div>
        <div class="row row-no-gutters">
        </div>
    </div>
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
        var XacNhanUuDaiTrongGiaoDuc = {
            ID: -1,
            Status: 1,
            Type: 4,
            Data: [],
            url: "/Handler/",
            initData: function () {
            },
            fillData: function (id) {
                XacNhanUuDaiTrongGiaoDuc.ID = id;
                $("#edit_header").html("Nhập mã xác nhận");
                $("#edit_header_ThongBao").hide();
            },
            update: function () {
                // Kiem tra ma trang
                var strMa = $("#txtMa").val().trim();

                if (strMa == "") {
                    $("#edit_header_ThongBao").show();
                    $("#edit_header_ThongBao").html("Bạn hãy nhập mã");
                    return;
                }

                if (XacNhanUuDaiTrongGiaoDuc.ID > 0) {
                    try {
                        //Update
                        $.getJSON(this.url + "CapNhatMaYeuCauDichVu.aspx?ID=" + XacNhanUuDaiTrongGiaoDuc.ID + "&&Ma=" + strMa + "&&Type=" + XacNhanUuDaiTrongGiaoDuc.Type, function (data) {
                            $("#edit_header_ThongBao").show();
                            if (data == 1) {
                                $("#edit_header_ThongBao").html("Cập nhật thành công");
                                setTimeout(function () {
                                    window.location.href = "/dichvu/XacNhanUuDaiTrongGiaoDuc";
                                }, 2000)
                            }
                            else {
                                if (data == -1) {
                                    $("#edit_header_ThongBao").html("Bạn nhập sai mã xác thực");
                                }
                                else {
                                    $("#edit_header_ThongBao").html(data);
                                }
                            }
                        });
                    }
                    catch (ex) {
                        $("#edit_header_ThongBao").show();
                        $("#edit_header_ThongBao").html(ex);
                    }
                }
            },
            initDelete: function (id, message) {
                XacNhanUuDaiTrongGiaoDuc.ID = id;
                $("#lblThongBaoXoa").html(message);
                $("#edit_header_ThongBao1").hide();
                $('#btnXoa').show();
                //$("#btnXoa").on("click", XacNhanUuDaiTrongGiaoDuc.delete);
            },
            delete: function () {
                //Update
                $("#edit_header_ThongBao1").show();
                try {
                    $.getJSON(this.url + "HuyDichVu.aspx?ID=" + XacNhanUuDaiTrongGiaoDuc.ID + "&&Type=" + XacNhanUuDaiTrongGiaoDuc.Type, function (data) {
                        if (data == 1) {

                            $("#edit_header_ThongBao1").html("Thực hiện thành công");
                            $('#btnKhong').text("Thoát");
                            $('#btnXoa').hide();
                            setTimeout(function () {
                                window.location.href = "/dichvu/XacNhanUuDaiTrongGiaoDuc";
                            }, 2000)
                        }
                        else {
                            if (data == -1) {
                                $("#edit_header_ThongBao1").html("Lỗi hệ thống");
                            }
                            else {
                                $("#edit_header_ThongBao1").html(data);
                            }
                        }
                    });
                }
                catch (ex) {
                    $("#edit_header_ThongBao1").html(ex);
                }
            },
            initComplete: function (id, message) {
                XacNhanUuDaiTrongGiaoDuc.ID = id;
                $("#lblThongHoanThanh").html(message);
                $("#edit_header_ThongBao2").hide();
                $('#btnHoanThanh').show();
                //$("#btnXoa").on("click", XacNhanUuDaiTrongGiaoDuc.delete);
            },
            complete: function () {
                //Update
                $("#edit_header_ThongBao2").show();
                try {
                    $.getJSON(this.url + "HoanThanhDichVu.aspx?ID=" + XacNhanUuDaiTrongGiaoDuc.ID + "&&Type=" + XacNhanUuDaiTrongGiaoDuc.Type, function (data) {
                        if (data == 1) {

                            $("#edit_header_ThongBao2").html("Thực hiện thành công");
                            $('#btnKhong2').text("Thoát");
                            $('#btnHoanThanh').hide();
                            setTimeout(function () {
                                window.location.href = "/dichvu/XacNhanUuDaiTrongGiaoDuc";
                            }, 2000)
                        }
                        else {
                            if (data == -1) {
                                $("#edit_header_ThongBao2").html("Lỗi hệ thống");
                            }
                            else {
                                $("#edit_header_ThongBao2").html(data);
                            }
                        }
                    });
                }
                catch (ex) {
                    $("#edit_header_ThongBao2").html(ex);
                }
            },
            ThemMoi: function () {
                window.location.href = "/dichvu/XacNhanUuDaiTrongGiaoDuc_yeucaumoi";
            }
        };
    </script>
</asp:Content>
