<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="danhSach_BaiKhaoSat_SinhVien.aspx.cs" Inherits="nuce.web.khaosatcuusinhvien.danhSach_BaiKhaoSat_SinhVien" %>

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
                        <li><a href="/Default.aspx" class="home">Home</a> </li>
                        <li><a href="/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx">Khảo sát</a> </li>
                        <li><a href="http://www.nuce.edu.vn/vi/thong-bao/ktdb-thong-bao-vv-trien-khai-cong-tac-lay-y-kien-phan-hoi-cua-sinh-vien-ve-hoat-dong-giang-day-cua-giang-vien-hoc-ky-i-nam-hoc-2019-2020.html" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body" runat="server" id="divBody">
                    <%--          @RenderBody()--%>
                    <div class="form_dsbks">
                        <div class="title" style="text-align: center; margin-bottom: 10px;">
                            <b style="text-align: center;">PHIẾU KHẢO SÁT Ý KIẾN PHẢN HỒI CỦA NGƯỜI HỌC VỀ HOẠT ĐỘNG GIẢNG DẠY CỦA GIẢNG VIÊN HỌC KỲ I NĂM HỌC 2019-2020</b>
                        </div>
                        <div class="title1" style="text-align: left; margin-bottom: 10px;">
                            Phiếu khảo sát này áp dụng cho toàn bộ sinh viên vừa kết thúc học kỳ 2 năm 2019-2020. Mỗi môn học sẽ có một bài khảo sát tương ứng nhằm mục đích nâng cao chất lượng giảng dạy. Đề nghị anh/chị trả lời đầy đủ các nội dung của tất cả các bài khảo sát một cách khách quan nhất. Tất cả thông tin cá nhân và ý kiến phản hồi của anh/chị đều được bảo mật. Nhà trường chỉ tổng hợp kết quả.
Thời gian thực hiện khảo sát từ 0h00 ngày 19/01/2020 đến 24h00 ngày 15/02/2020</span>
                        </div>
                        <div class="baithi2">
                            <table class="table table-bordered" style="font-size: 12px;">
                                <thead>
                                    <tr>
                                        <th style="text-align: center;">Tên môn học</th>
                                        <th style="text-align: center;">Tên giảng viên</th>
                                        <th style="text-align: center;">trạng thái</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody runat="server" id="tbContent">
                                </tbody>
                            </table>
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
        <div id="divInitData" runat="server"></div>
        <!-- Global site tag (gtag.js) - Google Analytics -->
        <script async src="https://www.googletagmanager.com/gtag/js?id=UA-138241215-1"></script>
        <script>
            window.dataLayer = window.dataLayer || [];
            function gtag() { dataLayer.push(arguments); }
            gtag('js', new Date());

            gtag('config', 'UA-138241215-1');
        </script>
    </form>
</body>
</html>
