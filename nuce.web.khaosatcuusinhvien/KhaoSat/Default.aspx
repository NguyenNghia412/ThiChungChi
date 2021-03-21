<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nuce.web.khaosatcuusinhvien.KhaoSat.Default" %>

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
                    <div class="logo">
                        <p>
                            <img src="/upload/image/tonghop/header_home.png" alt="">
                        </p>
                    </div>
                    <div class="logo-mobile">
                        <p>
                            <img src="/upload/image/tonghop/logo-mobile.png" alt="">
                        </p>
                    </div>
                    <ul class="menuheader">
                        <li><a href="/Default.aspx" class="home">Home</a> </li>
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
                    <div class="col-md-4 col-xs-12">
                        <div class="form_home" style="background-color: #0f297e;">
                            <a style="color: yellow; text-align: center; cursor: none; font-weight: bold; font-size: large" href="/KSHDGD/login_sinh_vien.aspx">
                                <p style="text-align: center; text-transform: uppercase;">
                                    Khảo sát phản hồi của SV về hoạt động giảng dạy của GV
                                </p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="form_home" style="background-color: floralwhite;">
                            <a style="color: #0f297e; cursor: pointer; font-weight: bold; font-size: large" href="/login_sinh_vien_sap_ra_truong.aspx">
                                <p style="text-align: center; text-transform: uppercase;">
                                    Khảo sát phản hồi của SV về chất lượng đào tạo trước tốt nghiệp
                                </p>
                            </a>
                        </div>
                    </div>
                    <div class="col-md-4 col-xs-12">
                        <div class="form_home" style="background-color: #ead7af;">
                            <a style="color: #0f297e; cursor: pointer; font-weight: bold; font-size: large" href="/login_cuu_sinh_vien.aspx">
                                <p style="text-align: center; text-transform: uppercase;">
                                    Khảo sát tình hình việc làm SV sau tốt nghiệp
                                </p>
                            </a>
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
</body>
</html>

