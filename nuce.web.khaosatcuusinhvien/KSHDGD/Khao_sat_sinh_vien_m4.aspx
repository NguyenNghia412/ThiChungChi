<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Khao_sat_sinh_vien_m4.aspx.cs" Inherits="nuce.web.Khao_sat_sinh_vien_m4" %>

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
                        <div class="title" style="text-align: center; text-transform: uppercase; margin-bottom: 10px;">
                            <b>PHIẾU KHẢO SÁT Ý KIẾN PHẢN HỒI TỪ NGƯỜI HỌC VỀ HOẠT ĐỘNG GIẢNG DẠY CỦA GIẢNG VIÊN</b>
                        </div>
                        <div class="title1" style="text-align: left; margin-bottom: 10px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Những thông tin do anh/chị cung cấp dưới đây sẽ được sử dụng trong việc cải tiến chương trình, không ngừng nâng cao chất lượng đào tạo của Trường ĐHXD. Nhà trường bảo mật các thông tin cá nhân và chỉ công bố kết quả thống kê.
                        </div>
                        <div>
                            <h4 class="H3_CAPTION" style="text-align: left; font-weight: normal; padding-left: 3px;"><b>I. THÔNG TIN CHUNG</b></h4>
                            <div class="content">
                                <table class="table" style="margin:0px;">
                                    <tbody runat="server" id="tbPhan1Content">
                                        <tr>
                                            <td>Năm học khảo sát:</td>
                                            <td id="tdNamHoc" runat="server">2019 - 2020</td>
                                        </tr>
                                        <tr>
                                            <td>Đợt khảo sát:</td>
                                            <td id="tdHocKi" runat="server">Kì I</td>
                                        </tr>
                                        <tr>
                                            <td>Lớp môn học:</td>
                                            <td id="tdLopMonHoc" runat="server">62KDF</td>
                                        </tr>
                                        <tr>
                                            <td>Giảng viên:</td>
                                            <%--<td id="tdTenGiangVien" runat="server">Hoàng Nam Thắng</td>--%>
                                            <td>
                                                <asp:DropDownList ID="ddlGiangVien" runat="server" AutoPostBack="true"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Sinh viên:</td>
                                            <td id="tdHoTenSinhVien" runat="server">Nguyễn Văn A (000001)</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="baithi2">
                        <h4 class="H3_CAPTION" style="text-align: left; font-weight: normal; padding-left: 3px;"><b>II. NỘI DUNG KHẢO SÁT</b></h4>
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
            function checkCollectAnswares() {
                collectAnswares();
                
                if (countSoCauHoi < 10) {
                    //alert(countSoCauHoi);
                    $('#_thongbao').show();
                    return false;
                }
                else
                {
                    if($("#ddlGiangVien").val() == 'Chưa có giảng viên')
                    {
                        alert("Anh/Chị vui lòng chon giảng viên");
                        return false;
                    }
                    else
                        return true;
                }
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
                $.get("/KSHDGD/Khao_sat_sinh_vien_luu_bai.aspx", { answare: $("#<%=txtAnswares.ClientID%>")[0].value, id: KiThi_LopHoc_SinhVienID });
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
