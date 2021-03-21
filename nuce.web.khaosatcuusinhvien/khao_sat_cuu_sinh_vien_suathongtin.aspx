﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="khao_sat_cuu_sinh_vien_suathongtin.aspx.cs" Inherits="nuce.web.khao_sat_cuu_sinh_vien_suathongtin" %>

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
    <meta name="description" content="HỆ THỐNG KHẢO SÁT ONLINE" />
    <meta name="author" content="HỆ THỐNG KHẢO SÁT ONLINE" />
    <meta property="og:image" content="/images/favicon-96x96.png" />
    <link rel="icon" href="/images/favicon-96x96.png">

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
                        <li><a href="/Khao_sat_cuu_sinh_vien.aspx" class="home">Home</a> </li>
                        <li><a href="/Khao_sat_cuu_sinh_vien.aspx">Khảo sát</a> </li>
                        <li><a href="/khao_sat_cuu_sinh_vien_suathongtin.aspx">Cập nhật thông tin cá nhân</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body">
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk" style="min-height: 250px;">

                            <div class="title">
                                SỬA THÔNG TIN CÁ NHÂN
                            </div>
                            <%-- <div class="text col-xs-12 col-md-12" style="height:150px; text-align: left; padding-top: 1px; padding-right: 1px; margin-bottom:30px;">
                               Cảm ơn anh/chị đã đăng nhập. </br>
                               Hiện tại Nhà trường đã chuyển hình thức khảo sát từ online sang phỏng vấn qua điện thoại. Anh/chị vui lòng cập nhật số điện thoại và email để Nhà trường có thể liên hệ phỏng vấn trực tiếp về tình hình việc sau khi tốt nghiệp cũng như cung cấp thông tin về cơ hội việc làm trong tương lai.</br>
                               Chúc anh/chị sức khỏe và thành công.
                            </div>--%>
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
                        <div class="form_dk" style="min-height: 250px;">
                            <div class="title">
                                GHI CHÚ
                            </div>
                            <div class="text col-xs-12 col-md-12" style="text-align: left; padding-top: 1px; padding-right: 1px;">
                                Anh/chị vui lòng cập nhật số điện thoại và email để Nhà trường có thể liên hệ phỏng vấn trực tiếp về tình hình việc sau khi tốt nghiệp cũng như cung cấp thông tin về cơ hội việc làm trong tương lai.</br>
                               Chúc anh/chị sức khỏe và thành công.
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

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-96251558-1', 'auto');
        ga('send', 'pageview');

    </script>
</body>
</html>
