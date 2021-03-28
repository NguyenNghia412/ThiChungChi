<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QLPhongThi.ascx.cs" Inherits="nuce.ad.thichungchi.QLPhongThi" %>

<!DOCTYPE html>

<div class="table-responsive">
    <table class="table">
        <thead>
            <tr>
                <th>#</th>
                <th>Mã phòng</th>
                <th>Tên người</th>
                <th>Số người tối đa</th>
                <th style="width: 5%;"></th>
<%--                <th style="width: 5%;"></th>--%>
                <th style="width: 5%;"></th>
            </tr>
        </thead>
        <tbody id="tbContent">
            <tr>
                <td>1</td>
                <td>Anna</td>
                <td>Pitt</td>
                <td>
                    <button type="button" class="btn btn-info">Sửa</button>
                </td>
                <td>
                    <button type="button" class="btn btn-danger">Xóa</button>
                </td>
                <td>
                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Thêm mới</button>
                </td>
            </tr>
        </tbody>
    </table>
</div>

<!-- Modal them sua -->
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
                    <label for="Ma">Mã:</label>
                    <input type="text" class="form-control" id="Ma">
                </div>
                <div class="form-group">
                    <label for="Ten">Tên:</label>
                    <input type="text" class="form-control" id="Ten">
                </div>
                <div class="form-group">
                    <label for="SoNguoiToiDa">Số người tối đa:</label>
                    <input type="text" class="form-control" id="SoNguoiToiDa">
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Thoát</button>
                <button type="button" class="btn btn-default" id="btnCapNhat" onclick=" QuanLyPhongThi.update();">Cập nhật</button>
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
                <h4 class="modal-title">Bạn có chắc chắn muốn xóa ?</h4>
                <div id="edit_header_ThongBao1"></div>
            </div>
            <div class="modal-body" style="text-align: center;">
                <button type="button" class="btn btn-default" id="btnKhong" data-dismiss="modal">Không</button>
                <button type="button" class="btn btn-danger" id="btnXoa" onclick=" QuanLyPhongThi.delete();">Xóa</button>
            </div>
        </div>
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
    var QuanLyPhongThi = {
        ID: -1,
        Data: [],
        url: "/handler/nuce.ad.thichungchi/",
        bindData: function () {
            $('#tbContent').html("");
            $.getJSON(this.url + "ad_tcc_getphongthi.ashx", function (data) {
                //alert(data);
                QuanLyPhongThi.Data = data;
                var strHtml = "";
                $.each(data, function (i, item) {
                    strHtml += "<tr>";
                    strHtml += "<td>" + (i + 1) + "</td>";
                    strHtml += "<td>" + item.MaPhong + "</td>";
                    strHtml += "<td>" + item.TenPhong + "</td>";
                    strHtml += "<td>" + item.SoNguoiToiDa + "</td>";
                    strHtml += "<td><button type=\"button\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"QuanLyPhongThi.fillData(" + item.Id + ");\">Sửa</button></td>";
                    strHtml += "<td><button type=\"button\" class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#myModal1\" onclick=\"QuanLyPhongThi.initDelete(" + item.Id + ");\">Xóa</button></td>";
                    strHtml += "</tr>";

                });
                strHtml += "<tr>";
                strHtml += "<td colspan='6' style='text-align:right;'><button type=\"button\" class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#myModal\" onclick=\"QuanLyPhongThi.add();\">Thêm mới</button></td>";
                strHtml += "</tr>";
                $('#tbContent').html(strHtml);
            });
        },
        add: function () {
            QuanLyPhongThi.ID = -1;
            $("#edit_header").html("Thêm mới");
            $("#edit_header_ThongBao").hide();
            $("#Ma").val("");
            $("#Ten").val("");
            $("#SoNguoiToiDa").val("");
        },
        fillData: function (id) {
            QuanLyPhongThi.ID = id;
            $("#edit_header").html("Sửa thông tin");
            $("#edit_header_ThongBao").hide();

            $.getJSON(this.url + "ad_tcc_getphongthi.ashx?ID=" + id, function (data) {
                //alert(data[0].ID);
                $.each(data, function (i, item) {
                    $("#Ma").val(item.MaPhong);
                    $("#Ten").val(item.TenPhong);
                    $("#SoNguoiToiDa").val(item.SoNguoiToiDa);
                });
            });

        },
        update: function () {
            // Kiem tra ma trang
            strMa = $("#Ma").val().trim();
            strTen = $("#Ten").val().trim();
            strSoNguoiToiDa = $("#SoNguoiToiDa").val().trim();
            if (strMa == "") {
                $("#edit_header_ThongBao").show();
                $("#edit_header_ThongBao").html("Không được để mã trắng");
                return;
            }
            if (strTen == "") {
                $("#edit_header_ThongBao").show();
                $("#edit_header_ThongBao").html("Không được để tên trắng");
                return;
            }
            //Kiem tra co trung ma
            kiemtra = 0;
            $.each(this.Data, function (i, item) {
                if (item.Ma == strMa && (item.ID != QuanLyPhongThi.ID)) {

                    kiemtra = 1;
                    return;
                }
            });
            if (kiemtra == 1) {
                $("#edit_header_ThongBao").show();
                $("#edit_header_ThongBao").html("Không được để trùng mã: " + strMa);
                return;
            }
            if (QuanLyPhongThi.ID > 0) {
                //Update
                $.getJSON(this.url + "ad_tcc_updatephongthi.ashx?ID=" + QuanLyPhongThi.ID + "&&Ma=" + strMa + "&&Ten=" + strTen + "&&SoNguoiToiDa=" + strSoNguoiToiDa, function (data) {
                    if (data == 1) {
                        $("#edit_header_ThongBao").show();
                        $("#edit_header_ThongBao").html("Cập nhật thành công");
                        QuanLyPhongThi.bindData();
                    }
                    else {
                        $("#edit_header_ThongBao").show();
                        $("#edit_header_ThongBao").html("Lỗi hệ thống");
                    }
                });
            }
            else {
                $.getJSON(this.url + "ad_tcc_insertphongthi.ashx?Ma=" + strMa + "&&Ten=" + strTen + "&&SoNguoiToiDa=" + strSoNguoiToiDa, function (data) {
                    if (data == 1) {
                        $("#edit_header_ThongBao").show();
                        $("#edit_header_ThongBao").html("Cập nhật thành công");
                        QuanLyPhongThi.bindData();
                    }
                    else {
                        $("#edit_header_ThongBao").show();
                        $("#edit_header_ThongBao").html("Lỗi hệ thống");
                    }
                });
            }
            //alert(this.Data.length);
        },
        initDelete: function (id) {
            QuanLyPhongThi.ID = id;
            $("#edit_header_ThongBao1").hide();
            $('#btnXoa').show();
        },
        delete: function () {
            //Update
            $.getJSON(this.url + "ad_tcc_deletephongthi.ashx?ID=" + QuanLyPhongThi.ID, function (data) {
                if (data == 1) {
                    $("#edit_header_ThongBao1").show();
                    $("#edit_header_ThongBao1").html("Xóa thành công");
                    $('#btnKhong').text("Thoát");
                    $('#btnXoa').hide();
                    QuanLyPhongThi.bindData();
                }
                else {
                    $("#edit_header_ThongBao1").show();
                    $("#edit_header_ThongBao1").html("Lỗi hệ thống");
                }
            });
        }
    };
    QuanLyPhongThi.bindData();
</script>
