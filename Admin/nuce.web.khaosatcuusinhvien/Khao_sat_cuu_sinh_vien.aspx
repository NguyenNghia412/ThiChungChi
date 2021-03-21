<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Khao_sat_cuu_sinh_vien.aspx.cs" Inherits="nuce.web.Khao_sat_cuu_sinh_vien" %>

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

                <div class="body" runat="server" id="divBody">
                    <%--          @RenderBody()--%>
                    <div class="form_dk_1">
                        <div class="title" style="text-align: center; text-transform: uppercase; margin-bottom: 10px;">
                            Phiếu khảo sát tình hình việc làm của sinh viên sau khi tốt nghiệp
                        </div>
                        <div class="note" style="text-align: center;">
                            Tất cả thông tin cá nhân và các câu trả lời của anh/chị đều được bảo mật tuyệt đối. Nhà trường chỉ sử dụng kết quả thống kê, tổng hợp.<br />
                            Nội dung trả lời được hệ thống tự động lưu.
                        </div>
                    </div>
                    <div class="baithi2">
                        <h4 class="H3_CAPTION" style="text-align: center;">NỘI DUNG KHẢO SÁT</h4>
                        <div class="content" id="divContentCauHoi" runat="server">
                        </div>
                        <div class="clearfix"></div>
                        <div class="content">
                            <div class="block">
                                <div class="block-title" style="padding-bottom: 10px;">
                                    <span class="question-title">Anh/chị vui lòng cập nhật các thông tin dưới đây: 
                                    </span>
                                </div>
                            </div>
                            <div class="block">
                                <div class="block-title">
                                    <span class="question-title">Email:
                                    </span>
                                </div>
                                <div class="block-content">
                                    <ul>
                                        <div class="block - content">
                                            <ul>
                                                <li class="col-xs-12 item">
                                                    <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                                                </li>
                                                <div class="clear"></div>
                                            </ul>
                                        </div>
                                        <div class="clear"></div>
                                    </ul>
                                </div>
                            </div>
                            <div class="block">
                                <div class="block-title">
                                    <span class="question-title">Mobile:
                                    </span>
                                </div>
                                <div class="block-content">
                                    <ul>
                                        <div class="block - content">
                                            <ul>
                                                <li class="col-xs-12 item">
                                                    <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                                                </li>
                                                <div class="clear"></div>
                                            </ul>
                                        </div>
                                        <div class="clear"></div>
                                    </ul>
                                </div>
                            </div>
                            <div class="block">
                                <div class="block-title">
                                    <span class="question-title">Thẻ căn cước công dân/CMT:
                                    </span>
                                </div>
                                <div class="block-content">
                                    <ul>
                                        <div class="block - content">
                                            <ul>
                                                <li class="col-xs-12 item">
                                                    <asp:TextBox runat="server" ID="txtCMT"></asp:TextBox>
                                                </li>
                                                <div class="clear"></div>
                                            </ul>
                                        </div>
                                        <div class="clear"></div>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form_dk_2">
                        <div class="note" style="text-align: center;">
                            Để kết thúc bài khảo sát anh/chị vui lòng trả lời đầy đủ các câu hỏi có gắn dấu <span style="color: red;">(*)</span> và nhấn nút "Hoàn thành" dưới đây.
                                <br />
                            Sau khi nhấn nút "Hoàn thành", không thể sửa được nôi dung đã trả lời.
                        </div>
                        <div class="clear"></div>
                        <div id="_note" class="note" style="display: none; text-align: center;">
                            Chân thành cảm ơn và chúc anh/chị sức khỏe, thành công !
                        </div>
                        <div class="submit" style="text-align: center; margin: 0 auto;">
                            <div class="thongbao">
                                <div id="_thongbao" class="thongbao" style="display: none; color: red;">
                                    Anh/chị vui lòng trả lời đầy đủ các câu hỏi có gắn dấu (*)
                                    <span id="notAnswerQuestionIndex"></span>
                                </div>
                            </div>
                            <br />
                            <asp:Button runat="server" ID="btnNopBai" Text="Hoàn thành" OnClientClick=" return checkCollectAnswares();" OnClick="btnNopBai_Click" />
                        </div>
                        <div class="clear">
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

            $("#q_3267").hide();
            $("#q_3262").hide();
            $("#q_3263").hide();
            $("#q_3264").hide();
            $("#q_3265").hide();
            $("#q_3266").hide();
            $("#q_3322").hide();
            var m_strAnwares = '';
            var countSoCauHoi = 0;
            var checkKhongCoViec = 0;
            function checkCollectAnswares() {
                collectAnswares();
                if (((checkKhongCoViec == 0) && (countSoCauHoi < 5)) || ((checkKhongCoViec == 1) && (countSoCauHoi < 2)) || (m_index == '0')) {
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
                for (i = 0; i < radios.length; i++) {
                    var name = radios[i].name;
                    //alert(name);
                    if (name.indexOf("nCauHoi_") >= 0) {
                        var id = radios[i].id.replace('id_', '');
                        //id_{0}_{1}
                        countSoCauHoi++;
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
                m_TinhThanh = $('#cbTinhThanh').find('option:selected').val();
                m_strAnwares = m_strAnwares + "#####$$$$$@@@@@";
                m_strAnwares = m_strAnwares + m_index;
                m_strAnwares = m_strAnwares + "#####$$$$$@@@@@";
                m_strAnwares = m_strAnwares + m_TinhThanh;
                $("#<%=txtAnswares.ClientID%>").val(m_strAnwares);

                //alert(m_strAnwares);
                return true;
            };
            function checkDapAnMC(ID) {
                $(ID).prop('checked', true);
                // Kiem tra neu chon vao cau hoi la chua co viec lam thi mo ra cau hoi text tra loi.
                // Va đóng câu trả lời từ 2-6
                //$("#q_3262").show();
                if (ID == '#id_3261_4851') {
                    //$("#txtCauHoi_3267").removeAttr('disabled');
                    $("#q_3267").show();
                    $("#q_3262").hide();
                    $("#q_3263").hide();
                    $("#q_3264").hide();
                    $("#q_3265").hide();
                    $("#q_3266").hide();
                    $("#q_3322").hide();
                    checkKhongCoViec = 1;
                }
                else {
                    if (ID == '#id_3261_4850') {
                        $("#txtCauHoi_3267").val("");
                        $("#q_3267").hide();
                        $("#q_3262").show();
                        $("#q_3263").show();
                        $("#q_3264").show();
                        $("#q_3265").show();
                        $("#q_3266").show();
                        $("#q_3322").show();
                    }
                    //$("#txtCauHoi_3267").attr('disabled', 'true');
                }
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
                $.get("khao_sat_cuu_sinh_vien_luu_bai.aspx", { answare: $("#<%=txtAnswares.ClientID%>")[0].value });
            };

        </script>
        <div id="divInitData" runat="server"></div>

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
    </form>
</body>
</html>
