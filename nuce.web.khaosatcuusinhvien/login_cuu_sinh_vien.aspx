<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login_cuu_sinh_vien.aspx.cs" Inherits="nuce.web.login_cuu_sinh_vien" %>

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
                        <li><a href="/Default.aspx">Khảo sát</a> </li>
                        <li><a href="/khao_sat_cuu_sinh_vien_suathongtin.aspx">Cập nhật thông tin cá nhân</a> </li>
                        <li><a href="http://nuce.edu.vn/vi/thong-bao/thong-bao-vv-trien-khai-khao-sat-tinh-hinh-viec-lam-cua-cuu-sinh-vien-tot-nghiep-nam-hoc-2018-2019.html" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                        <a href="javascript:showmenu()">Menu </a>
                        <select>
                            <option value="/Default.aspx">Lựa chọn</option>
                            <option value="/Default.aspx">Home</option>
                            <option value="/khao_sat_cuu_sinh_vien_suathongtin.aspx">Cập nhật thông tin cá nhân</option>
                        </select>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body">
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk">
                            <div class="title">
                                ĐĂNG NHẬP
                            </div>
                            <div class="text col-xs-12 col-md-4">
                                Mã số sinh viên
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <asp:TextBox runat="server" ID="txtMaDangNhap"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4">
                                Mật khẩu
                            </div>
                            <div class="input col-xs-12 col-md-8">
                                <asp:TextBox runat="server" ID="txtMatKhau" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-4">
                            </div>
                            <div class="submit col-xs-12 col-md-8">
                                <asp:Button runat="server" ID="btnDangNhap" Text="Đăng nhập" OnClick="btnDangNhap_Click" />
                            </div>
                            <div class="clearfix"></div>
                            <div class="text col-xs-12 col-md-12" style="text-align: center; padding-top: 5px; padding-right: 45px;">
                                <span class="error" id="spThongBao" runat="server"></span>
                            </div>
                            <div class="clearfix"></div>

                        </div>
                    </div>
                    <div class="col-md-6 col-xs-12">
                        <div class="form_dk">
                            <div class="title">
                                CHÚ Ý
                            </div>
                            <div class="text col-xs-12 col-md-12" style="text-align: left; padding-top: 1px; padding-right: 1px;">
                                * Tên đăng nhập là mã số sinh viên. Nếu mã số sinh viên có ít hơn 7 kí tự thì bổ sung các số 0 phía trước để mã số sinh viên có đủ 7 kí tự. </br>
                             <i>Ví dụ: mã số sinh viên là "123" thì tên đăng nhập là "0000123"</i></br>
                             * Mật khẩu là họ tên đầy đủ không dấu, không viết hoa, không dấu cách.</br>
                             <i>Ví dụ: Họ và tên là "Nguyễn Văn A" thì mật khẩu là "nguyenvana"</i></br>
                             * Trường hợp anh/chị không nhớ chính xác mã số sinh viên vui lòng gửi email tới địa chỉ ks.ktdb@nuce.edu.vn</br>
                             * Khi cần hỗ trợ vui lòng liên hệ theo hotline 0912987567 hoặc qua email ks.ktdb@nuce.edu.vn
                   <%--         <b>Nhằm bảo mật thông tin cá nhân, hệ thống sẽ tự động ẩn đi nội dung bài khảo sát đã hoàn thành.</b></br>
                            <b>Anh/chị có thể cập nhật thông tin liên lạc qua thẻ "CẬP NHẬT THÔNG TIN CÁ NHÂN".</b></br>--%>
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

        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Thông báo</h4>
                    </div>
                    <div class="modal-body">
                        <p>
                            Anh/chị đã hoàn thành bài khảo sát. Nhằm bảo mật thông tin cá nhân, hệ thống không cho phép đăng nhập lại.
Trân trọng cảm ơn và chúc anh/chị sức khỏe!
                        </p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

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
