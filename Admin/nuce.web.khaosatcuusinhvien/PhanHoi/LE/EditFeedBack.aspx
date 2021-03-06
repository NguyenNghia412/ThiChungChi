<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFeedBack.aspx.cs" Inherits="nuce.web.phanhoi.le.EditFeedBack" %>

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
                            <img src="/upload/image/tonghop/header_st.jpg" alt="">
                        </p>
                    </div>
                    <div class="logo-mobile">
                        <p>
                            <img src="/upload/image/tonghop/logo-mobile.png" alt="">
                        </p>
                    </div>
                    <ul class="menuheader">
                       <li><a href="/phanhoi/le/Default.aspx">Trang chủ</a> </li>
                        <li><a href="/phanhoi/le/NotRead.aspx">Phản hồi chưa đọc</a> </li>
                        <li><a href="/phanhoi/le/Message.aspx">Thông báo</a> </li>
                        <li><a href="/phanhoi/le/AddMessage.aspx">Thêm Thông báo</a> </li>
                        <li><a href="http://nuce.edu.vn" target="_blank">Hướng dẫn</a> </li>
                    </ul>
                    <div class="clear">
                    </div>
                    <div class="menuheader1" runat="server" id="mo_menuheader">
                        <a href="javascript:showmenu()">Menu </a>
                        <select>
                            <option value="/phanhoi/le/Default.aspx">Home</option>
                        </select>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="clearfix">
                    </div>
                </div>

                <div class="body">
                    <div class="col-md-12 col-xs-12">
                        <div style="border: 1px solid #ccc; padding: 10px 10px; margin-bottom: 10px; min-height: 245px;">
                            <div class="form-group">
                                <label>Chủ đề phản hồi:</label>
                                <span id="spType" runat="server"></span>
                            </div>
                            <div style="border: 1px solid #ccc; padding: 10px 10px; margin-bottom: 10px;">
                                <div class="form-group">
                                    <label>Phản hồi:</label>
                                    <span class="form-control" id="spQuestion" runat="server"></span>
                                </div>
                                <div class="form-group">
                                    <label>File Đính kèm:</label>
                                    <span id="spFileDinhKem" runat="server"></span>
                                </div>
                            </div>
                            <div style="border: 1px solid #ccc; padding: 10px 10px; margin-bottom: 10px;">
                                <div class="form-group">
                                    <label>Hồi đáp của giảng viên:</label>
                                    <asp:TextBox class="form-control" runat="server" ID="txtAnswer" TextMode="MultiLine" Widtd="100%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>File Đính kèm:</label>
                                    <span id="spFileDinhKemLec" runat="server"></span>
                                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                                </div>
                            </div>
                            <asp:Button runat="server" Text="Gửi" class="btn btn-default" ID="btnUpdate" OnClick="btnUpdate_Click" />
                            <asp:Button runat="server" Text="Lưu tạm" class="btn btn-default" ID="btnArchive" OnClick="btnArchive_Click" />
                            <asp:Button runat="server" Text="Quay lại" class="btn btn-default" ID="btnCancel" OnClick="btnCancel_Click" />
                            <div runat="server" id="spThongBao" style="color: red;">
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <div id="footer">
                    <p><strong>TRƯỜNG ĐẠI HỌC XÂY DỰNG</strong></p>
                    <p>Địa chỉ: Số 55 đường Giải Phóng, quận Hai Bà Trưng, Hà Nội</p>
                </div>
                <asp:TextBox Enabled="false" class="form-control" runat="server" ID="txtSinhVien" TextMode="MultiLine" Widtd="100%" Visible="false"></asp:TextBox>
                <a href="javascript:" id="toTop"></a>


            </div>
        </div>
        <div id="divIn" style="display: none;" runat="server"></div>
        <div style="display: none;">
            <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtLecClass" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtType" runat="server"></asp:TextBox>
        </div>
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
