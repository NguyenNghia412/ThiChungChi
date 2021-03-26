<%@ Page Title="Danh sách kỳ thi" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="DanhSachKiThi.aspx.cs" Inherits="Thi_SV.DanhSachKiThi" %>
<asp:Content ContentPlaceHolderID="MainStyle" runat="server">
    <style>
        #wrapper {
            width: 80%;
            margin: 50px auto;
        }
    </style>
    <webopt:bundlereference runat="server" path="~/Content/css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 80%; margin: 5px auto; background-color: white; text-align: right;">
        <div class="btn-group">
            <button type="button" class="btn btn btn-success dropdown-toggle" id="User" data-toggle="dropdown"></button>
            <ul class="dropdown-menu" role="menu">
                <li><a href="javascript:DanhSachKiThi.logout();">Logout</a></li>
            </ul>
        </div>
    </div>
    <div id="wrapper">
        <table class="table table-bordered">
            <thead>
                <tr style="color: black; text-align: center;">
                    <th style="width: 5%; text-align: center;">#</th>
                    <th style="text-align: center;">Tên kì thi</th>
                    <th style="text-align: center;">Tên bộ đề</th>
                    <th style="width: 25%; text-align: center;">Môn thi</th>
                    <th style="width: 15%; text-align: center;">Trạng thái</th>
                    <th style="width: 10%; text-align: center;"></th>
                </tr>
            </thead>
            <tbody id="tbContent">
            </tbody>
        </table>
    </div>
    <div id="ContentPane" runat="server"></div>
    <div id="dnn_ContentPane" class="cb DNNEmptyPane"></div>

    <!-- Modal xoa -->
    <div id="myModal1" class="modal fade" role="dialog" style="width:100%;">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" id="lblThongBaoXoa">Chi tiết bài thi.</h4>
                    <div id="edit_header_ThongBao1"></div>
                </div>
                <div class="modal-body" style="text-align: center;">
                    <button type="button" class="btn btn-default" id="btnThoat" data-dismiss="modal">Thoát</button>
                </div>
            </div>
        </div>
    </div><script>
              var DanhSachKiThi = {
                  ID: -1,
                  Data: [],
                  url: "/handler/nuce.thichungchi/",
                  init: function () {
                      $.getJSON(DanhSachKiThi.url + "tcc_check/", function (data) {
                          if (data == -1) {
                              window.location.href = "/Thi/DangNhap";
                          }
                          else {
                              $.getJSON(DanhSachKiThi.url + "tcc_getUser/", function (data1) {
                                  $('#User').html('Xin chào ' + data1.Ho + ' ' + data1.Ten);
                              });
                              //Lay danh sach ki thi
                              $.getJSON(DanhSachKiThi.url + "tcc_getDanhSachBaiThi/", function (data1) {
                                  DanhSachKiThi.Data = data1;
                                  var strHtml = "";
                                  var index = 1;
                                  $.each(data1, function (i, item) {
                                      strHtml += "<tr>";
                                      strHtml += "<td>" + index + "</td>";
                                      strHtml += "<td>" + item.TenKiThi + "</td>";
                                      strHtml += "<td>" + item.TenBoDe + "</td>";
                                      strHtml += "<td>" + item.TenMonHoc + "</td>";
                                      var trangthai = item.Status;
                                      var trangthaikithi = item.StatusKiThi;
                                      var strTrangThai = "";
                                      if (trangthaikithi == 1) {
                                          strHtml += "<td>Kì thi chưa bắt đầu, vui lòng chờ đợi</td>";
                                          strHtml += "<td></td>";
                                      }
                                      else if (trangthaikithi == 2) {
                                          switch (trangthai) {
                                              case 1: strTrangThai = "Chuẩn bị thi";
                                                  strHtml += "<td>" + strTrangThai + "</td>";
                                                  strHtml += "<td><button type=\"button\" class=\"btn btn-info\" onclick=\"DanhSachKiThi.VaoThi(" + item.KiThi_LopHoc_SinhVien + ", " + item.LoaiDe + ");\">Vào thi</button></td>";
                                                  break;
                                              case 2: strTrangThai = "Đang thi";
                                                  strHtml += "<td>" + strTrangThai + "</td>";
                                                  strHtml += "<td><button type=\"button\" class=\"btn btn-info\" onclick=\"DanhSachKiThi.VaoThi(" + item.KiThi_LopHoc_SinhVien + ", " + item.LoaiDe + ");\">Thi tiếp</button></td>";
                                                  //strHtml += "<td></td>";
                                                  break;
                                              case 3: strTrangThai = "Đang tạm dừng";
                                                  strHtml += "<td>" + strTrangThai + "</td>";
                                                  strHtml += "<td><button type=\"button\" class=\"btn btn-info\" onclick=\"DanhSachKiThi.VaoThi(" + item.KiThi_LopHoc_SinhVien + ", " + item.LoaiDe + ");\">Thi tiếp</button></td>";
                                                  break;
                                              case 4: strTrangThai = "Đã thi xong";
                                                  strHtml += "<td style='color:blue;'>" + strTrangThai + "</td>";
                                                  strHtml += "<td><button type=\"button\" onclick=\"DanhSachKiThi.chitietbaithi(" + item.KiThi_LopHoc_SinhVien + ", " + item.LoaiDe + ");\" class=\"btn btn-info\">Chi tiết</button></td>";
                                                  break;
                                              case 5: strTrangThai = "Hủy thi";
                                                  strHtml += "<td style='color:red;'>" + strTrangThai + "</td>";
                                                  strHtml += "<td></td>";
                                                  break;
                                              case 6: strTrangThai = "Thi lại";
                                                  strHtml += "<td>" + strTrangThai + "</td>";
                                                  strHtml += "<td><button type=\"button\" class=\"btn btn-info\" onclick=\"DanhSachKiThi.VaoThi(" + item.KiThi_LopHoc_SinhVien + ", " + item.LoaiDe + ");\">Vào thi</button></td>";
                                                  break;
                                              default: break;
                                          }
                                      }
                                      else {
                                          strHtml += "<td style='color:blue;'>Kì thi đã kết thúc</td>";
                                          strHtml += "<td><button type=\"button\" onclick=\"DanhSachKiThi.chitietbaithi(" + item.KiThi_LopHoc_SinhVien + ");\" class=\"btn btn-info\" data-toggle=\"modal\" data-target=\"#myModal1\";\">Chi tiết</button></td>";
                                      }
                                      strHtml += "</tr>";
                                      index++;
                                  });
                                  $('#tbContent').html(strHtml);
                              });
                          }
                      });
                  },
                  logout: function () {
                      $.getJSON(DanhSachKiThi.url + "tcc_logout/", function (data) {
                          if (data == 1) {
                              window.location.href = "/Thi/DangNhap";
                          }
                      });
                  },
                  VaoThi: function (id, loaiDe = 1) {
                      if (loaiDe === 2) {
                          window.location.href = "/Thi/ThiTuLuan?kithilophocsinhvien=" + id;
                          return;
                      }
                      window.location.href = "/Thi/LamBaiThi?kithilophocsinhvien=" + id;
                  },
                  chitietbaithi: function (id, loaiDe = 1) {
                      if (loaiDe === 2) {

                      }
                      window.location.href = "/Thi/ChiTietBaiThi?kithilophocsinhvien=" + id;
                  }
              };
              DanhSachKiThi.init();
    </script>
</asp:Content>