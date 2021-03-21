<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeThiViewFull.aspx.cs" Inherits="nuce.web.khaosatsinhvien.ad.DeThiViewFull" %>

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
                        <li><a href="/Default.aspx" class="home">Home</a> </li>
                        <li><a href="/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx">Khảo sát</a> </li>
                        <li><a href="http://nuce.edu.vn/vi/thong-bao/ktdb-thong-bao-vv-trien-khai-cong-tac-lay-y-kien-phan-hoi-cua-sinh-vien-ve-hoat-dong-giang-day-cua-giang-vien-hoc-ky-ii-nam-hoc-2018-2019.html" target="_blank">Hướng dẫn</a> </li>
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
                </div>

                <div id="footer">
                    <p><strong>TRƯỜNG ĐẠI HỌC XÂY DỰNG</strong></p>
                    <p>Địa chỉ: Số 55 đường Giải Phóng, quận Hai Bà Trưng, Hà Nội</p>
                </div>

                <a href="javascript:" id="toTop"></a>
            </div>
        </div>


        <div style="display: none;">
            <asp:TextBox runat="server" ID="txtAnswares"></asp:TextBox>
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
        <script>
            var m_strAnwares = '';
            var countSoCauHoi = 0;
            var checkKhongCoViec = 0;
            function checkCollectAnswares() {
                collectAnswares();
                //if (((checkKhongCoViec == 0) && (countSoCauHoi < 5)) || ((checkKhongCoViec == 1) && (countSoCauHoi < 1)) || (m_index == '0')) {
                if ((countSoCauHoi < 27 && BaiKhaoSatID == 1)||
                    (countSoCauHoi < 33 && BaiKhaoSatID == 2)||
                    (countSoCauHoi < 9 && BaiKhaoSatID == 3)) {
                    //alert(countSoCauHoi);
                    $('#_thongbao').show();
                    return false;
                }
                else
                    return true;
            }
            function collectAnswares() {
                m_strAnwares = '';
                countSoCauHoi = 0;
                var radios = $("#divContentCauHoi").find("input:checked");
                var checkMP = 0;
                for (i = 0; i < radios.length; i++) {
                    var name = radios[i].name;
                    //alert(name);
                    if (name.indexOf("nCauHoi_") >= 0) {
                        var id = radios[i].id.replace('id_', '');
                        //id_{0}_{1}
                        //id_3328_5090
                        if (id.indexOf("3328_") >= 0)
                        {
                            if (checkMP == 0)
                            {
                                countSoCauHoi++;
                                checkMP = 1;
                            }
                        }
                        else
                        {
                            countSoCauHoi++;
                        }
                        m_strAnwares = m_strAnwares + id + ";";
                    }
                }
                m_strAnwares = m_strAnwares + "#####$$$$$@@@@@"
                $('textarea').each(function () {

                    if (this.id.indexOf("txtCauHoi_") >= 0) {
                        var value = $(this).val();
                        var id = this.id.replace('txtCauHoi_', '');
                        m_strAnwares = m_strAnwares + id + "!!!$$$" + value + "$#@$#@";
                    }
                    // get the value

                    // check the value with the regular expression here.
                    // send alert if failed etc...

                });
                m_strAnwares = m_strAnwares + "#####$$$$$@@@@@";
                m_strAnwares = m_strAnwares + m_index;
                $("#<%=txtAnswares.ClientID%>").val(m_strAnwares);

                //alert(m_strAnwares);
                return true;
            };
            function checkDapAnMC(ID) {
                $(ID).prop('checked', true);
                luuBai();
            };
            //Danh cho checkbox
            function checkDapAnMC1(ID) {
                if ($(ID).is(":checked"))
                    $(ID).prop('checked', false);
                else
                    $(ID).prop('checked', true);
                luuBai();
            };
            function checkDapAnMC2(ID) {
                luuBai();
            };
            function checkDapAnMCInit(ID) {
                $(ID).prop('checked', true);
            };
            function setRate(index, idCauHoiRate) {
                m_index = index;
                luuBai();
            };
            function luuBai() {
                collectAnswares();
            };

        </script>
        <div id="divInitData" runat="server"></div>

        <script>
            //alert(BaiKhaoSatID);
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-96251558-1', 'auto');
            ga('send', 'pageview');

        </script>
    </form>
</body>
</html>
