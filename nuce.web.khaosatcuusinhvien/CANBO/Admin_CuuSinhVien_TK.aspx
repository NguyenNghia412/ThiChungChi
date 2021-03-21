﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_CuuSinhVien_TK.aspx.cs" Inherits="nuce.web.Admin_CuuSinhVien_TK" %>

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
                        <li><a href="/canbo/default.aspx" class="home">Cán bộ</a> </li>
                        <li><a href="/canbo/canbo_doimatkhau.aspx">Đổi mật khẩu</a> </li>
                        <li><a href="http://nuce.edu.vn/" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                        <a href="javascript:showmenu()">Menu </a>
                        <select>
                            <option value="/Default.aspx">Cán bộ</option>
                        </select>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body">
                    <div class="col-md-12 col-xs-12">
                        <div class="form_dk">
                            <div class="text col-xs-12 col-md-12" style="text-align: center; padding-top: 5px; padding-right: 45px;">
                                <span class="error" id="spThongBao" runat="server"></span>
                            </div>
                            <div class="clearfix"></div>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead>
                                        <tr style="vertical-align: top; text-align: center;">
                                            <th style='text-align: center; width:5%;vertical-align: top;'>STT</th>
                                            <th style='text-align: center;vertical-align: top;'>Mã ngành</th>
                                            <th style='text-align: center;vertical-align: top;'>Tên ngành đào tạo</th>
                                            <th style='text-align: center;vertical-align: top;'>Chuyên ngành</th>
                                            <th style='text-align: center;width:6%;vertical-align: top;'>Tổng số SV tốt nghiệp</th>
                                            <th style='text-align: center;width:6%;vertical-align: top;'>Ngưỡng tối thiểu phải đạt (theo CV 2919)</th>
                                            <th style='text-align: center;width:6%;vertical-align: top;'>Cựu SV đã tham gia khảo sát</th>
                                            <th style='text-align: center;width:6%;vertical-align: top;'>Số liệu còn thiếu</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbContent" runat="server">
                                    </tbody>
                                </table>
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
        <div id="divIn" style="display: none;" runat="server"></div>
        <script src="/Scripts/jquery-1.10.2.min.js"></script>
        <script src="/Scripts/bootstrap.min.js"></script>
        <div id="divScript" runat="server"></div>
        <script type="text/javascript">

            function PrintElem(elem) {
                var mywindow = window.open('', 'PRINT', 'height=400,width=600');

                mywindow.document.write('<html><head><title></title>');
                mywindow.document.write('</head><body >');
                mywindow.document.write(document.getElementById(elem).innerHTML);
                mywindow.document.write('</body></html>');

                mywindow.document.close(); // necessary for IE >= 10
                mywindow.focus(); // necessary for IE >= 10*/

                mywindow.print();
                mywindow.close();

                return true;
            }
            function exportDoc(url) {
                window.open(url, '_blank');
            }
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