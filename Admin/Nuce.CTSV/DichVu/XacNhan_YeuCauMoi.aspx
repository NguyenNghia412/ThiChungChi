<%@ Page Title="Dịch vụ sinh viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XacNhan_YeuCauMoi.aspx.cs" Inherits="Nuce.CTSV.XacNhan_YeuCauMoi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
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
    <div class="container-fluid">
        <div class="row row-no-gutters">
            <div class="col-sm-12">
                <ul class="breadcrumb">
                    <li><a href="/dichvusinhvien">Dịch Vụ</a></li>
                    <li><a href="/dichvu/xacnhan">Xác nhận</a></li>
                    <li>Yêu cầu mới</li>
                </ul>
            </div>
        </div>
        <div class="card shadow mb-4">
            <div style="width: 70%;">
                <div class="col-sm-12">
                    <div style="padding-top: 5px; text-align: center; font-weight: bold; color: red;" runat="server" id="divThongBao">
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="form-group">
                        <label for="slXacNhan">Lý do xác nhận:</label>
                        <select class="form-control" id="slLyDo" name="slLyDo" onchange="xacnhan_yeucaumoi.setValueLyDo(this);">
                            <option value="Xin đăng ký tạm trú, tạm vắng">1. Xin đăng ký tạm trú, tạm vắng</option>
                            <option value="Xin tạm hoãn nghĩa vụ quân sự">2. Xin tạm hoãn nghĩa vụ quân sự</option>
                            <option value="Xin xác nhận để người nhà thi vào bộ đội, công an.">3. Xin xác nhận để người nhà thi vào bộ đội, công an</option>
                            <option value="Xin xác nhận để người nhà kết hôn với người trong lực lượng vũ trang: bộ đội, công an">4. Xin xác nhận để người nhà kết hôn với người trong lực lượng vũ trang: bộ đội, công an</option>
                            <option value="Xin xác nhận để thuê nhà ở sinh viên tại làng sinh viên Hacinco">5. Xin xác nhận để thuê nhà ở sinh viên tại làng sinh viên Hacinco</option>
                            <option value="Xin xác nhận để làm hồ sơ đi du học">6. Xin xác nhận để làm hồ sơ đi du học</option>
                            <option value="Xác nhận để làm visa đi du lịch nước ngoài">7. Xác nhận để làm visa đi du lịch nước ngoài</option>
                            <option value="Xác nhận để được hưởng học bổng khuyến học địa phương">8. Xác nhận để được hưởng học bổng khuyến học địa phương</option>
                            <option value="Xin miễn giảm thuế thu nhập cá nhân cho người thân">9. Xin miễn giảm thuế thu nhập cá nhân cho người thân</option>
                            <option value="-1">10. Khác</option>
                        </select>
                    </div>
                    <div class="form-group" id="frmXacNhan" style="display:none;">
                        <asp:TextBox ID="txtLyDoXacNhan" runat="server" class="form-control" TextMode="MultiLine" placeholder="Bạn hãy nhập lý do khác" Text="Xin đăng ký tạm trú, tạm vắng"></asp:TextBox>
                    </div>
                    <%-- <div class="form-group">
                        <label for="Image2">Captcha:</label>
                        <asp:Image ID="Image2" runat="server" Height="55px" ImageUrl="/Extent/Captcha.aspx" Width="186px" />
                    </div>--%>
                    <%--<div class="form-group">
                        <label for="captcha">Nhập mã captcha:</label>
                        <asp:TextBox ID="txtCaptcha" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>--%>
                    <div class='g-recaptcha' data-sitekey='6Lf3Lc8ZAAAAANyHCgqSpM_NDwBTJQZIsEnUQJ1s'></div>
                    <div class="form-group">
                        <button type="button" id="btnModalUpdate" class="btn btn-primary mt-2" data-toggle="modal" data-target="#myModalUpdate">Gửi yêu cầu</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="display: none;">
        <asp:Button class="btn btn-primary" ID="btnCapNhat" runat="server" Text="Gửi yêu cầu" OnClick="btnCapNhat_Click" />
    </div>
    <div
        class="modal fade"
        id="myModalUpdate"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Bạn có chắc chắn muốn gửi yêu cầu tới Nhà trường ?</h5>
                    <button
                        class="close"
                        type="button"
                        data-dismiss="modal"
                        aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    Nhấn nút xác nhận nếu bạn chắc chắn muốn gửi yêu cầu.
                </div>
                <div class="modal-footer">
                    <button
                        class="btn btn-secondary"
                        type="button"
                        data-dismiss="modal">
                        Thoát
           
                    </button>
                    <button type="button" class="btn btn-primary" id="btnCapNhat1" onclick="xacnhan_yeucaumoi.update();">Xác nhận</button>
                </div>
            </div>
        </div>
    </div>
    <div
        class="modal fade"
        id="myModalThongBao"
        tabindex="-1"
        role="dialog"
        aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Thông báo</h5>
                    <button
                        class="close"
                        type="button"
                        data-dismiss="modal"
                        aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body" id="divThongBaoCapNhat" runat="server">
                    Nhấn nút xác nhận nếu bạn chắc chắn muốn gửi yêu cầu.
                </div>
                <div class="modal-footer">
                    <button
                        class="btn btn-secondary"
                        type="button"
                        data-dismiss="modal">
                        Thoát
           
                    </button>
                    <button type="button" class="btn btn-primary" id="btnVeDanhSach" onclick="xacnhan_yeucaumoi.vedanhsach();">Quay lại danh sách</button>
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
        var xacnhan_yeucaumoi = {
            update: function () {
                document.getElementById("<%=btnCapNhat.ClientID %>").click();
                //alert($("#" + "<%=txtLyDoXacNhan.ClientID %>").val());
            },
            vedanhsach: function () {
                window.location.href = "/dichvu/XacNhan";
            },
            setValueLyDo: function (obj)
            {
                //alert(obj.value);
                if (obj.value == "-1") {
                    $("#" + "<%=txtLyDoXacNhan.ClientID %>").val("");
                    $("#frmXacNhan").show();
                }
                else {
                    $("#frmXacNhan").hide();
                    $("#" + "<%=txtLyDoXacNhan.ClientID %>").val(obj.value);
                }
            }
        };
        $(document).ready(function () {
            
        });
    </script>
    <span runat="server" id="spScript"></span>
</asp:Content>
