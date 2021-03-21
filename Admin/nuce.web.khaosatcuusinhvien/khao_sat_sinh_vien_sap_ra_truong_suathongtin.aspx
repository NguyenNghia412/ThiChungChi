<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="khao_sat_sinh_vien_sap_ra_truong_suathongtin.aspx.cs" Inherits="nuce.web.khao_sat_sinh_vien_sap_ra_truong_suathongtin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Trường đại học xây dựng</title>

    <link href="/Styles/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="/Content/plugins/angular-busy-master/dist/angular-busy.min.css" rel="stylesheet" />
    <script src="/Scripts/modernizr-2.6.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row ">
                <div id="header">
                    <span runat="server" id="spLogin"></span>
                    <%-- @if (!ApplicationContext.IsLogged())
                {
                    <a href="/user/login" class="btn_dangnhap_header">Đăng nhập</a>
                    }
                else
                {
                    <a href="/user/logout" class="btn_dangnhap_header">Đăng xuất</a>
                    }--%>
                    <div class="logo">
                        <p>
                            <img src="/upload/image/tonghop/header.jpg" alt="">
                        </p>
                    </div>
                    <div class="logo-mobile">
                        <p>
                            <img src="/upload/image/tonghop/logo-mobile.png" alt="">
                        </p>
                    </div>
                    <ul class="menuheader">
                        <li><a href="/Default.aspx" class="home">Home</a> </li>
                        <li><a href="/Khao_sat_sinh_vien_sap_ra_truong.aspx">Khảo sát</a> </li>
                        <li><a href="/khao_sat_sinh_vien_sap_ra_truong_suathongtin.aspx">Xác thực hoàn thành khảo sát</a> </li>
                        <li><a href="http://nuce.edu.vn/vi/thong-bao/ktdb-thong-bao-vv-trien-khai-cong-tac-lay-y-kien-phan-hoi-cua-sinh-vien-truoc-khi-tot-nghiep-dot-thang-4-nam-2019-ve-chat-luong-dao-tao.html" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body" runat="server" id="divBody">
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk3">
                            <div class="title">
                                Xác thực hoàn thành khảo sát
                            </div>
                            <div class="text col-xs-12 col-md-12" style="height: 10px; text-align: left; padding-top: 1px; padding-right: 1px; margin-bottom: 30px;">
                                <span id="spTrangThai" runat="server" style="color:red;font-weight:bold;">Hiện tại anh/chị chưa xác thực email.</span></br>
                            </div>
                            <div class="text col-xs-12 col-md-4" style="margin-bottom: 0px;">
                                Mã sinh viên:
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <span id="spMaSV" runat="server"></span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4" style="margin-bottom: 0px;">
                                Tên sinh viên:
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <span id="spTenSinhVien" runat="server"></span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4" style="margin-bottom: 0px;">
                                Email:
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4" style="margin-bottom: 0px;">
                                Mobile:
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4" style="margin-bottom: 0px;">
                                CMT (CCCD):
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <asp:TextBox runat="server" ID="txtCMT"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4">
                            </div>
                            <div class="submit col-xs-12 col-md-8">
                                <asp:Button runat="server" ID="btnCapNhat" Text="Cập nhật" OnClick="btnCapNhat_Click" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-12" style="text-align: center; padding-top: 5px; padding-right: 45px;">
                                <span class="error" id="spThongBao" runat="server"></span>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk3">
                            <div class="title">
                                Chú ý
                            </div>
                            <div class="text col-xs-12 col-md-12" style="height: 10px; text-align: left; padding-top: 1px; padding-right: 1px; margin-bottom: 30px;">
                                <b>CMT</b>: Chứng Minh Thư  
                                <b>CCCD</b>: Căn cước công dân</br>
                                Sau khi cập nhật địa chỉ email, hệ thống sẽ gửi một email yêu cầu xác thực. Các anh/ chị vui vòng xác thực. Xin chân thành cảm ơn !</br>
                                <b style="color:red;" runat="server" id="bThongBao"></b>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <div id="footer">
                    <p><strong>TRƯỜNG ĐẠI HỌC XÂY DỰNG</strong></p>
                    <p>Địa chỉ: Số 55 đường Giải Phóng, quận Hai Bà Trưng, Hà Nội</p>
                </div>

                <a href="javascript:" id="toTop"></a>
            </div>
        </div>

        <div id="divProcessData" runat="server"></div>
        <script src="/Scripts/jquery-1.10.2.min.js"></script>
        <script src="/Scripts/bootstrap.min.js"></script>
        <script type="text/javascript">

            window.onpageshow = function (event) {
                if (event.persisted) {
                    //alert("From bfcache");
                }
            };

            function showmenu() {
                $(".menuheader1 select").toggleClass("selectshow");
            }
            $(document).ready(function () {
                $(".menuheader1 select").change(function () {
                    window.location = $(this).val();
                });
            });

            $(function () {
                $(window).scroll(function () {
                    if ($(this).scrollTop() != 0) {
                        $('#toTop').fadeIn();
                    } else {
                        $('#toTop').fadeOut();
                    }
                });

                $('#toTop').click(function () {
                    $('body,html').animate({ scrollTop: 0 }, 800);
                });
            });
        </script>

    </form>

<!-- Global site tag (gtag.js) - Google Analytics -->
<script async src="https://www.googletagmanager.com/gtag/js?id=UA-138241215-1"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());

  gtag('config', 'UA-138241215-1');
</script>
</body>
</html>
