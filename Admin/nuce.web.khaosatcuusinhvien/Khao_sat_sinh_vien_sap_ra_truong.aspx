<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Khao_sat_sinh_vien_sap_ra_truong.aspx.cs" Inherits="nuce.web.Khao_sat_sinh_vien_sap_ra_truong" %>

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
                        <li><a href="http://nuce.edu.vn/vi/thong-bao/ktdb-thong-bao-vv-trien-khai-cong-tac-lay-y-kien-phan-hoi-cua-sinh-vien-truoc-khi-tot-nghiep-dot-thang-62019-ve-chat-luong-dao-tao.html" target="_blank">Hướng dẫn</a> </li>
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
                            <b>PHIẾU KHẢO SÁT Ý KIẾN SINH VIÊN TRƯỚC KHI TỐT NGHIỆP</b>
                        </div>
                    </div>
                    <div class="baithi2">
                        <div class="note" style="text-align: left; font-weight: normal; padding-left: 3px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Những thông tin do anh/chị cung cấp dưới đây sẽ được sử dụng trong việc cải tiến chương trình, không ngừng nâng cao chất lượng đào tạo của Trường ĐHXD. Nhà trường bảo mật các thông tin cá nhân và chỉ công bố kết quả thống kê.
                        </div>
                        <h4 class="H3_CAPTION" style="text-align: center; font-weight: normal;"><b>NỘI DUNG KHẢO SÁT</b></h4>
                        <div class="note" style="text-align: left; padding-bottom: 5px; padding-left: 3px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Với những câu hỏi lựa chọn phương án trả lời theo thang đánh giá, sinh viên chọn 01 phương án phù hợp theo thang điểm từ 1 đến 5, trong đó:</br>
                            <div class="row" style="padding-left: 5px; padding-bottom: 3px; padding-top: 3px;">
                                <div class="col-sm-5 col-xs-12 item">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight: bold;">1.</span> Hoàn toàn <b>KHÔNG</b> đồng ý/Rất <b>KHÔNG</b> hài lòng
                                </div>
                                <div class="col-sm-4 col-xs-12 item">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>2. KHÔNG</b> đồng ý/<b>KHÔNG</b> hài lòng
                                </div>
                                <div class="col-sm-3 col-xs-12 item">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>3.	TẠM</b> chấp nhận/<b>TẠM</b> hài lòng
                                </div>
                            </div>
                            <div class="row" style="padding-left: 5px;">
                                <div class="col-sm-5 col-xs-12 item">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>4.	ĐỒNG Ý/HÀI LÒNG</b>
                                </div>
                                <div class="col-sm-4 col-xs-12 item">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>5.	HOÀN TOÀN ĐỒNG Ý/RẤT HÀI LÒNG</b>
                                </div>
                            </div>
                        </div>
                        <div class="content" id="divContentCauHoi" runat="server">
                            <div>
                                <h5 class="h5_groupcauhoi"></h5>
                                <div class="block">
                                    <div class="block-title">
                                        <span class="question-title">radio 1
                                        </span>
                                    </div>
                                    <div class="block-content">
                                        <ul>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_1" name="vcauhoi_1" value="123">
                                                <label>
                                                    cau tra loi 1
                                                </label>
                                            </li>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_2" name="vcauhoi_1" value="1234">
                                                <label>
                                                    cau tra loi 2
                                                </label>
                                            </li>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_3" name="vcauhoi_1" value="12345">
                                                <label>
                                                    cau tra loi 1
                                                </label>
                                            </li>
                                            <div class="clear"></div>
                                        </ul>
                                    </div>
                                </div>
                                <div class="block">
                                    <div class="block-title">
                                        <span class="question-title">radio 1
                                        </span>
                                    </div>
                                    <div class="block-content">
                                        <ul>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_4" name="vcauhoi_2" value="123" onclick="luuBai();">
                                                <label>
                                                    cau tra loi 1
                                                </label>
                                            </li>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_5" name="vcauhoi_2" value="1234">
                                                <label>
                                                    cau tra loi 2
                                                </label>
                                            </li>
                                            <li class="col-sm-6 col-xs-12 item">
                                                <input type="radio" id="id_6" name="vcauhoi_2" value="12345">
                                                <label>
                                                    cau tra loi 1
                                                </label>
                                            </li>
                                            <div class="clear"></div>
                                        </ul>
                                    </div>
                                </div>
                                <div class="block">
                                    <div class="block-title">
                                        <span class="question-title">xxxx
                                        </span>
                                    </div>
                                    <div class="block-content">
                                        <ul>
                                            <li class="col-xs-12 item">
                                                <textarea id="txtTest1"></textarea>
                                            </li>
                                            <div class="clear"></div>
                                        </ul>
                                    </div>
                                </div>
                                <div class="block">
                                    <div class="block-title">
                                        <span class="question-title">xxxx
                                        </span>
                                    </div>
                                    <div class="block-content">
                                        <ul>
                                            <li class="col-xs-12 item">
                                                <div class="rating_wrapper">
                                                    <div class="rating">
                                                        <input id="rating5" type="radio" name="rating" value="5" checked>
                                                        <label for="rating5" onclick="setRate(5);">5</label>
                                                        <input id="rating4" type="radio" name="rating" value="4">
                                                        <label for="rating4">4</label>
                                                        <input id="rating3" type="radio" name="rating" value="3">
                                                        <label for="rating3">3</label>
                                                        <input id="rating2" type="radio" name="rating" value="2">
                                                        <label for="rating2">2</label>
                                                        <input id="rating1" type="radio" name="rating" value="1">
                                                        <label for="rating1">1</label>
                                                    </div>
                                                </div>
                                            </li>
                                            <div class="clear"></div>
                                        </ul>
                                    </div>
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
            var m_strAnwares = '';
            var countSoCauHoi = 0;
            var checkKhongCoViec = 0;
            $("#q_3267").hide();
            $("#q_3262").hide();
            $("#q_3263").hide();
            $("#q_3264").hide();
            $("#q_3265").hide();
            $("#q_3266").hide();
            $("#q_3322").hide();
            function checkCollectAnswares() {
                collectAnswares();
                //if (((checkKhongCoViec == 0) && (countSoCauHoi < 5)) || ((checkKhongCoViec == 1) && (countSoCauHoi < 1)) || (m_index == '0')) {
                if (countSoCauHoi < 41) {
                    //if (((checkKhongCoViec == 0) && (countSoCauHoi < 43)) || ((checkKhongCoViec == 1) && (countSoCauHoi < 41)) ) {
                    $('#_thongbao').show();
                    return false;
                }
                else {
                    if ($("#id_3269_1111111111").length) {
                        if ((checkKhongCoViec == 0) && (countSoCauHoi < 43)) {
                            $('#_thongbao').show();
                            return false;
                        }
                        else
                            return true;
                    }
                    else {
                        return true;
                    }
                }
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
                if (ID == '#id_3310_5066') {
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
                    if (ID == '#id_3310_5065' || ID == '#id_3310_5064' || ID == '#id_3310_5063') {
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
            function checkDapAnMCInit(ID) {
                $(ID).prop('checked', true);
            };
            function setRate(index, idCauHoiRate) {
                m_index = index;
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
            function luuBai() {
                collectAnswares();
                $.get("Khao_sat_sinh_vien_sap_ra_truong_luu_bai.aspx", { answare: $("#<%=txtAnswares.ClientID%>")[0].value });
            };

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
