<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_sinh_vien.aspx.cs" Inherits="nuce.web.login_sinh_vien" %>

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
    <script src='https://www.google.com/recaptcha/api.js'></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row ">
                <div id="header">
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
                        <li><a href="/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx">Khảo sát</a> </li>
                        <li><a href="http://nuce.edu.vn/vi/thong-bao/ktdb-thong-bao-vv-trien-khai-cong-tac-lay-y-kien-phan-hoi-cua-sinh-vien-ve-hoat-dong-giang-day-cua-giang-vien-hoc-ky-ii-nam-hoc-2019-2020.html" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                        <a href="javascript:showmenu()">Menu </a>
                        <select>
                            <option value="/Default.aspx">Lựa chọn</option>
                            <option value="/Default.aspx">Home</option>
                        </select>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body">
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk" style="min-height: 315px;">
                            <div class="title">
                                ĐĂNG NHẬP
                            </div>
                            <div class="text col-xs-12 col-md-4" style="text-align: left;">
                                Mã số sinh viên
                            </div>
                            <div class="input col-xs-12 col-md-8" style="text-align: center;">
                                <asp:TextBox runat="server" ID="txtMaDangNhap"></asp:TextBox>
                            </div>
                            <div class="text col-xs-12 col-md-4" style="text-align: left;">
                                Mật khẩu
                            </div>
                            <div class="input col-xs-12 col-md-8" style="text-align: center;">
                                <asp:TextBox runat="server" ID="txtMatKhau" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="text col-xs-12 col-md-8" style="text-align: left;">
                                <div class='g-recaptcha' data-sitekey='6Lcw_MYZAAAAAHDRbaVcJpBUSHY2EEp0IkMnbcVS'></div>
                            </div>
                            <div class="input col-xs-12 col-md-4" style="text-align: right;">
                            </div>
                            <%--  <div class="text col-xs-12 col-md-4">
                            </div>--%>
                            <div class="submit col-xs-12 col-md-18" style="text-align: left; padding-bottom: 5px; padding-top: 60px;">
                                <asp:Button runat="server" ID="btnDangNhap" Text="Đăng nhập" OnClick="btnDangNhap_Click" />
                            </div>
                            <div class="input col-xs-12 col-md-4" style="text-align: right;">
                            </div>
                            <div class="text col-xs-12 col-md-12" style="text-align: center;">
                                <span class="error" id="spThongBao" runat="server"></span>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                    </div>
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk" style="min-height: 315px;">
                            <div class="title">
                                CHÚ Ý
                            </div>
                            <div class="text col-xs-12 col-md-12" style="text-align: left; padding-top: 1px; padding-right: 1px;">
                                <b>Khảo sát lấy ý kiến phản hồi của sinh viên về hoạt động giảng dạy của giảng viên học kỳ II năm học 2019-2020.</b> </br></br>
                             <b>*</b> Mật khẩu là mật khẩu được sử dụng để đăng nhập hệ thống http://daotao.nuce.edu.vn.</br></br>
                             <%--<i style="color:red;">Nếu anh/chị đã đổi mật khẩu sau ngày 9/6/2018 thì vui lòng đăng nhập với mật khẩu trước khi thay đổi.</i></br>--%>
                                <b>*</b> Khi có thắc mắc, vui lòng liên hệ Phòng KTĐB qua hotline 0912.987.567 hoặc qua email:ks.ktdb@nuce.edu.vn</br></br>
                             <b>*</b>Thời gian thực hiện: Khảo sát từ 12h00 ngày 25/08/2020 đến <b>24h00 ngày 6/9/2020.</b>
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

        <script src="/Scripts/jquery-1.10.2.min.js"></script>
        <script src="/Scripts/bootstrap.min.js"></script>
        <div id="divScript" runat="server"></div>
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
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-138241215-1');
    </script>
</body>
</html>
