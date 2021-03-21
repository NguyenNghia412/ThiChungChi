<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="D3.aspx.cs" Inherits="nuce.web.thanhnt.D3" %>

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
                <div class="body">
                    <div style="text-align: center; font-weight: bold; padding-top: 10px;">
                        PHIẾU THU THẬP THÔNG TIN PHỤC VỤ LUẬN ÁN TIẾN SĨ  
                    </div>
                    <div style="text-align: center; font-weight: bold;">
                        "QUẢN LÝ CHẤT LƯỢNG ĐÀO TẠO NGÀNH KIẾN TRÚC TRÌNH ĐỘ ĐẠI HỌC THEO TIẾP CẬN TQM"
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-bottom: 5px;">
                        Dành cho <a href="#" data-toggle="tooltip" title="Sinh viên bao gồm: Người học đang học và đã tốt nghiệp...">SINH VIÊN, CỰU SINH VIÊN</a>
                    </div>
                    <div>
                        <i>Để góp phần hoàn thành Luận án do NCS Nguyễn Trung Thành thực hiện, xin đề nghị Anh/Chị dành thời gian trả lời vào Phiếu thu thập ý kiến dưới đây. Quan điểm của Anh/Chị sẽ giúp ích rất nhiều cho sự thành công của Đề tài luận án. Xin trân trọng cảm ơn!</i>
                    </div>
                    <div style="text-align: left; padding-top: 5px; padding-left: 5px;">
                        Phiếu thu thập ý kiến gồm 03 nội dung:
                    </div>
                    <div style="text-align: left; font-weight: bold; padding-top: 2px; padding-left: 5px;">
                        1. Khảo sát thực trạng về Quản lý đào tạo ngành Kiến trúc trình độ đại học
                    </div>
                    <div style="text-align: left; font-weight: bold; padding-top: 2px; padding-left: 5px;">
                        2. Hệ thống TIÊU CHUẨN, TIÊU CHÍ và CHỈ BÁO thành công về Quản lý đào tạo ngành Kiến trúc trình độ đại học theo tiếp cận TQM
                    </div>
                    <div style="text-align: left; font-weight: bold; padding-top: 2px; padding-left: 5px;">
                        3. Các GIẢI PHÁP về Quản lý đào tạo ngành Kiến trúc trình độ đại học theo tiếp cận TQM
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-top: 5px;">
                        DANH MỤC CÁC CHỮ VIẾT TẮT
                    </div>
                    <div>
                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td style="width: 25%;">Chuẩn đầu ra : <b>CĐR</b></td>
                                    <td style="width: 25%;">Chương trình đào tạo đại học ngành Kiến trúc : <b>CTĐT</b></td>
                                    <td style="width: 25%;">Cán bộ quản lý : <b>CBQL</b></td>
                                    <td style="width: 25%;">Cơ sở đào tạo :	<b>CSĐT</b></td>
                                </tr>
                                <tr>
                                    <td>Đảm bảo chất lượng : <b>ĐBCL</b></td>
                                    <td>Giáo dục và đào tạo : <b>GD&ĐT</b></td>
                                    <td>Kinh tế - Xã hội : <b>KT-XH</b></td>
                                    <td>Sử dụng lao động : <b>SDLD</b></td>
                                </tr>
                                <tr>
                                    <td>Năng lực nâng cao chất lượng : <b>NLCL</b></td>
                                    <td>Lập kế hoạch – Thực hiện – Kiểm tra – Cải tiến : <b>P-D-C-A</b></td>
                                    <td>Cán bộ quản lý : <b>CBQL</b></td>
                                    <td>Cơ sở đào tạo :	<b>CSĐT</b></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-top: 5px;">
                        MỘT SỐ THÔNG TIN CÁ NHÂN
                    </div>
                    <div>
                        <div class="form-group">
                            <label for="txtHoTen">Họ và tên:</label>
                            <%--  <input class="form-control" id="HoTen">--%>
                            <asp:TextBox ID="txtHoTen" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtEmail">Email:</label>
                            <%--  <input class="form-control" id="HoTen">--%>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtTenCoQuan">Lớp đang học hoặc Đơn vị công tác:</label>
                            <asp:TextBox ID="txtTenCoQuan" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 60px; font-weight: bold;">Giới tính:</td>
                                    <td>
                                        <asp:RadioButtonList CellPadding="10" ID="rbGioiTinh" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellSpacing="10">
                                            <asp:ListItem Value="1">Nam</asp:ListItem>
                                            <asp:ListItem Value="0">Nữ</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                            </table>
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 200px; font-weight: bold;">Đối tượng trả lời <span style="color: red;">(bắt buộc)*</span> :</td>
                                    <td>
                                        <asp:RadioButtonList ID="rbDoiTuongTraLoi" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CellPadding="10">
                                            <asp:ListItem Value="SVDH" Selected="True">Sinh viên đang học</asp:ListItem>
                                            <asp:ListItem Value="CSV">Cựu sinh viên</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-top: 10px;">
                        NỘI DUNG 1: KHẢO SÁT THỰC TRẠNG VỀ QUẢN LÝ ĐÀO TẠO NGÀNH KIẾN TRÚC TRÌNH ĐỘ ĐẠI HỌC
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-bottom: 5px;">
                        <i>Xin đề nghị <b>Anh/Chị</b> cho ý kiến bằng cách <b><u>"lựa chọn" vào một trong các "chữ số" ở các cột bên phải</u></b> và/hoặc <b><u>điền thông tin vào các khoảng trống</u></b> mà Anh/Chị <b>cho là thích hợp</b> dưới đây, với ý nghĩa theo các mức của Thang đo/đánh giá dưới đây :</i>
                    </div>
                    <div>
                        <table class="table table-bordered">
                            <thead style="background-color: gold; text-align: center; vertical-align: top;">
                                <th style="width: 5%;">Mức</th>
                                <th>Đánh giá và yêu cầu</th>
                                <th>Mức độ đáp ứng về hoạt động ĐBCL/TQM</th>
                                <th>Mức độ đáp ứng về minh chứng </th>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>1</td>
                                    <td style="width: 25%;"><u>Không đáp ứng</u> yêu cầu của tiêu chí, cần thực hiện đánh giá toàn diện để cải tiến chất lượng ngay </td>
                                    <td style="width: 25%;">Không thực hiện ĐBCL để đáp ứng yêu cầu tiêu chí</td>
                                    <td style="width: 25%;">Không có các kế hoạch, tài liệu, minh chứng hoặc kết quả có sẵn</td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td style="width: 25%;"><u>Chưa đáp ứng</u> yêu cầu của tiêu chí, cần đánh giá toàn diện để cải tiến chất lượng </td>
                                    <td style="width: 25%;">ĐBCL còn ít được thực hiện hay hiệu quả kém hoặc ĐBCL đang ở giai đoạn lập kế hoạch <i>hoặc</i> không đáp ứng yêu cầu</td>
                                    <td style="width: 25%;">Có ít tài liệu hoặc minh chứng</td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td style="width: 25%;"><u>Chưa đáp ứng đầy đủ</u> yêu cầu của tiêu chí, chỉ cần đánh giá theo chuyên đề  cải tiến chất lượng </td>
                                    <td style="width: 25%;">Đã xác định và thực hiện ĐBCL để đáp ứng yêu cầu của tiêu chí, nhưng không nhất quán hoặc có kết quả hạn chế </td>
                                    <td style="width: 25%;">Có các tài liệu, nhưng không có các minh chứng rõ ràng chứng tỏ được sử dụng, triển khai đầy đủ</td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td style="width: 25%;"><u>Đáp ứng đầy đủ</u> yêu cầu của tiêu chí và tiếp tục cải tiến chất lượng theo kế hoạch</td>
                                    <td style="width: 25%;">Thực hiện đầy đủ hoạt động ĐBCL để đáp ứng yêu cầu của tiêu chí và đem lại kết quả như mong đợi</td>
                                    <td style="width: 25%;">Có các minh chứng chứng tỏ việc thực hiện được tiến hành đầy đủ</td>
                                </tr>
                                <tr>
                                    <td>5</td>
                                    <td style="width: 25%;"><u>Đáp ứng cao hơn yêu cầu</u> tiêu chí và tiếp tục cải tiến chất lượng theo kế hoạch</td>
                                    <td style="width: 25%;">Việc thực hiện ĐBCL đáp ứng tốt hơn so với yêu cầu của tiêu chí và cho thấy các kết quả tốt, thể hiện xu hướng cải tiến tích cực</td>
                                    <td style="width: 25%;">Có các minh chứng chứng tỏ việc thực hiện được tiến hành một cách hiệu quả</td>
                                </tr>
                                <tr>
                                    <td>6</td>
                                    <td style="width: 25%;"><u>Thực hiện tốt như một hình mẫu của quốc gia</u> và tiếp tục cải tiến chất lượng theo kế hoạch</td>
                                    <td style="width: 25%;">Việc thực hiện ĐBCL để đáp ứng yêu cầu của tiêu chí, cho các kết quả rất tốt, thể hiện xu hướng cải tiến rất tích cực và được xem là điển hình tốt nhất của quốc gia</td>
                                    <td style="width: 25%;">Có các minh chứng chứng tỏ việc thực hiện được tiến hành một cách hiệu quả và liên tục.</td>
                                </tr>
                                <tr>
                                    <td>7</td>
                                    <td style="width: 25%;"><u>Thực hiện xuất sắc, đạt mức của các CSĐT hàng đầu thế giới</u> và tiếp tục cải tiến chất lượng theo kế hoạch</td>
                                    <td style="width: 25%;">Việc thực hiện ĐBCL để đáp ứng yêu cầu của tiêu chí cho kết quả xuất sắc, thể hiện xu hướng cải tiến xuất sắc đạt trình độ của CSĐT hàng đầu thế giới hoặc là điển hình hàng đầu để các CSĐT khác trên thế giới học theo</td>
                                    <td style="width: 25%;">Có các minh chứng chứng tỏ việc thực hiện được tiến hành một cách hiệu quả, liên tục và sáng tạo</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: left; padding-top: 5px; padding-left: 5px;">
                        Thang đo sử dụng theo TT 768/QLCL-KĐCLGD V/v hướng dẫn đánh giá theo bộ tiêu chuẩn đánh giá chất lượng cơ sở GD đại học ngày 20/4/2018
                    </div>
                    <div style="text-align: left; padding-top: 3px; padding-left: 5px;"><b style="color: red;">ĐỂ THUẬN LỢI VÀ NHANH CHÓNG TRONG QUÁ TRÌNH TRẢ LỜI KHẢO SÁT, HỆ THỐNG SẼ <i><u>ĐỂ MẶC ĐỊNH</u></i> PHƯƠNG ÁN TRẢ LỜI Ở MỖI CÂU HỎI, ANH/CHỊ CÓ THỂ <i><u>THAY ĐỔI BẰNG CÁCH CHỌN PHƯƠNG ÁN KHÁC PHÙ HỢP</u></i> VỚI CÂU TRẢ LỜI CỦA MÌNH</b></div>
                    <div id="divContentCauHoi">
                        <table class="table table-bordered">
                            <tbody>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: central; font-weight: bold;">
                                    <td style="width: 5%; vertical-align: middle;" rowspan="2">TT
                                    </td>
                                    <td style="width: 60%; vertical-align: middle;" rowspan="2">Nội dung
                                    </td>
                                    <td colspan="7">Mức đánh giá
                                    </td>
                                </tr>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: top;">
                                    <td style="width: 5%">1
                                    </td>
                                    <td style="width: 5%">2
                                    </td>
                                    <td style="width: 5%">3
                                    </td>
                                    <td style="width: 5%">4
                                    </td>
                                    <td style="width: 5%">5
                                    </td>
                                    <td style="width: 5%">6
                                    </td>
                                    <td style="width: 5%">7
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>BỐI CẢNH TRONG VÀ NGOÀI: </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Sứ mạng, giá trị, chiến lược và mục tiêu phát triển CTĐT đại học ngành Kiến trúc:</b>
                                    </td>
                                </tr>

                                <tr>
                                    <td>1
                                    </td>
                                    <td>(<b>PDC</b>) <i>Hệ thống tổ chức xây dựng, thực hiện, giám sát</i> phát triển <u>sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_1" id="d3_1_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td>(<b>C</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>phù hợp</i> với định hướng phát triển KT-XH, GD&ĐT địa phương, quốc tế và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_2" id="d3_2_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td>(<b>C</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>đáp ứng được yêu cầu của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_3" id="d3_3_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td>(<b>DC</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> được <i>diễn đạt xúc tích, dễ hiểu và chia sẻ với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_4" id="d3_4_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>5
                                    </td>
                                    <td>(<b>D</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT<u /> <i>được văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_5" id="d3_5_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_1"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Văn hóa chất lượng::</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>6
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>VHCL tích cực của ĐBCL CTĐT</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_6" id="d3_6_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>7
                                    </td>
                                    <td>(<b>DC</b>) <i>Giá trị và niềm tin chung được chia sẻ</i> của <u>VHCL tích cực</u> được phát triển <i>phù hợp</i> cho việc thực hiện <u>ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_7" id="d3_7_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>8
                                    </td>
                                    <td>(<b>DC</b>) <i>Những đặc trưng tích cực</i> của <u>VHCL</u> (tiêu chuẩn hành vi, cách thức thực hiện, thái độ, quan hệ trong công việc...) được cụ thể hóa dựa trên các giá trị chia sẻ và niềm tin chung trên <i>phù hợp</i> với <u>ĐBCL CTĐT</u> <i>hàng ngày</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_8" id="d3_8_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>9
                                    </td>
                                    <td>(<b>DC</b>) Các đặc trưng của <u>VHCL tích cực</u> trên <i>được cụ thể hóa phù hợp</i> trong các chính sách, chiến lược, tiêu chí, quy trình... của hệ thống <u>ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_9" id="d3_9_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>10
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến nâng cao và củng cố</i> <u>VHCL tích cực của ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_10" id="d3_10_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>11
                                    </td>
                                    <td>(<b>D</b>) Các qui định về tổ chức phát triển <u>VHCL tích cực của ĐBCL CTĐT</u> trên được <i>văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_11" id="d3_11_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_2"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Hệ thống ĐBCL bên trong:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>12
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>cơ cấu tổ chức, cơ chế, chính sách, kế hoạch chiến lược, chỉ số và chỉ tiêu về ĐBCL CTĐT</u> <i>đảm bảo lôi cuốn được tham gia và phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_12" id="d3_12_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>13
                                    </td>
                                    <td>(<b>C</b>) <u>Cơ cấu tổ chức và đội ngũ nhân viên</u> về ĐBCL CTĐT <i>phù hợp</i> với qui mô đào tạo ngành Kiến trúc của nhà trường
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_13" id="d3_13_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>14
                                    </td>
                                    <td>(<b>C</b>) <i>Qui định</i> về <u>chức năng, nhiệm vụ gắn với quyền hạn, chịu trách nhiệm xã hội và quy trình “chủ trì - phối hợp”</u> đảm bảo được <i>quyền tự chủ và chịu trách nhiệm của sinh viên</i> tham gia vào ĐBCL CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_14" id="d3_14_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>15
                                    </td>
                                    <td>(<b>C</b>) <u>Chính sách và kế hoạch chiến lược</u> về ĐBCL CTĐT <i>rõ ràng và phù hợp</i> với định hướng phát triển nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_15" id="d3_15_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>16
                                    </td>
                                    <td>(<b>C</b>) <u>Các chỉ số thực hiện và các chỉ tiêu phấn đấu KPIs chính</u> để đo lường kết quả thực hiện ĐBCL CTĐT <i>rõ ràng và phù hợp</i> với chính sách và kế hoạch chiến lược trên
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_16" id="d3_16_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>17
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_17" id="d3_17_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>18
                                    </td>
                                    <td>(<b>D</b>) Các qui định về cơ cấu tổ chức, cơ chế, chính sách và kế hoạch chiến lược, chỉ số và chỉ tiêu về ĐBCL CTĐT trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_18" id="d3_18_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_3"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Tự đánh giá và hệ thống thông tin về ĐBCL CTĐT:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>19
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_19" id="d3_19_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>20
                                    </td>
                                    <td>(<b>C</b>) <u>Quy trình tự đánh giá</u> ĐBCL CTĐT <i>phù hợp</i> với chính sách và kế hoạch chiến lược liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_20" id="d3_20_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>21
                                    </td>
                                    <td>(<b>DC</b>) <u>Tự đánh giá</u> về ĐBCL CTĐT <i>được thực hiện thường xuyên</i> và <i>tổng thể sau khi kết thúc năm học</i> hoặc <i>đột xuất nếu cần thiết</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_21" id="d3_21_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>22
                                    </td>
                                    <td>(<b>C</b>) <u>Hệ thống thông tin</u> (thu thập, xử lý, báo cáo, nhận và chuyển thông tin từ các bên liên quan nhằm hỗ trợ hoạt động ĐBCL CTĐT, nghiên cứu khoa học và phục vụ cộng đồng...) về ĐBCL CTĐT <i>phù hợp, chính xác và sẵn có</i> để cung cấp kịp thời cho sinh viên quan để tham gia tự đánh giá
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_22" id="d3_22_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>23
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến nâng cao chất lượng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_23" id="d3_23_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>24
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT trên được <i>văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_24" id="d3_24_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_4"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Nâng cao chất lượng:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>25
                                    </td>
                                    <td>(<b>C</b>) Hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>chính sách, chiến lược, kế hoạch, hệ thống, quy trình, thủ tục và nguồn lực</u>... <i>phục vụ tốt nhất</i> hoạt động đào tạo, nghiên cứu khoa học và phục vụ cộng đồng của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_25" id="d3_25_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>26
                                    </td>
                                    <td>(<b>C</b>) <u>Các tiêu chí và quy trình lựa chọn đối tác, các thông tin so chuẩn và đối sánh</u> theo các nội dung trên <i>phù hợp để nâng cao chất lượng</i> hoạt động đào tạo, nghiên cứu khoa học và phục vụ cộng đồng của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_26" id="d3_26_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>27
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> thực hiện các nội dung trên <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_27" id="d3_27_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>28
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến nâng cao chất lượng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_28" id="d3_28_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>29
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>các tiêu chí và quy trình lựa chọn đối tác, các thông tin so chuẩn và đối sánh</u> trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_29" id="d3_29_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_5"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b><u>ĐBCL ĐẦU VÀO:</u></b></br>
		    <b>Tổ chức phát triển CĐR đại học ngành Kiến trúc:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>30
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CĐR của CTĐT và học phần</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_30" id="d3_30_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>31
                                    </td>
                                    <td>(<b>C</b>) <u>CĐR của CTĐT</u> đảm bảo <i>đáp ứng được</i> các yêu cầu học tập suốt đời của người học, <i>liên thông</i> với các cấp, bậc học của ngành nghề liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_31" id="d3_31_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>32
                                    </td>
                                    <td>(<b>C</b>) <u>CĐR của học phần</u> đảm bảo <i>gắn kết với nhau, được xây dựng dựa trên và đạt tới</i> CĐR của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_32" id="d3_32_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>33
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_33" id="d3_33_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>34
                                    </td>
                                    <td>(<b>D</b>) <u>CĐR của CTĐT và học phần</u> được <i>văn bản hóa và công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_34" id="d3_34_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_6"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>Tổ chức phát triển CTĐT đại học ngành Kiến trúc dựa vào CĐR:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>35
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CTĐT dựa trên CĐR</u> <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_35" id="d3_35_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>36
                                    </td>
                                    <td>(<b>C</b>) <u>CTĐT, đề cương các học phần, đồ án tốt nghiệp</u> <i>phù hợp</i> với sứ mạng, giá trị, tầm nhìn và mục tiêu phát triển của nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_36" id="d3_36_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>37
                                    </td>
                                    <td>(<b>C</b>) Tỷ lệ nội dung CTĐT <i>phù hợp giữa lý thuyết và thực hành, thực tập</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_37" id="d3_37_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>38
                                    </td>
                                    <td>(<b>C</b>) <u>CTĐT</u> được chi tiết <i>phù hợp</i> thành <u>đề cương các học phần, đồ án tốt nghiệp</u> và <u>kế hoạch đào tạo</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_38" id="d3_38_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>39
                                    </td>
                                    <td>(<b>C</b>) <u>Cấu trúc CTĐT và kế hoạch đào tạo</u> đảm bảo <i>kết nối chặt chẽ</i> giữa <u>đề cương các học phần, đồ án tốt nghiệp</u> để đạt tới CĐR
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_39" id="d3_39_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>40
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo khối lượng/tải trọng học tập của <u>CTĐT và kế hoạch đào</u> tạo <i>phù hợp</i> với ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_40" id="d3_40_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>41
                                    </td>
                                    <td>(<b>C</b>) <u>CTĐT, đề cương các học phần</u> <i>cho biết rõ cách áp dụng</i> phương pháp giảng dạy, học tập, thực hành, kiểm tra đánh giá, thi tốt nghiệp để đạt tới CĐR
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_41" id="d3_41_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>42
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_42" id="d3_42_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>43
                                    </td>
                                    <td>(<b>D</b>) <u>CTĐT, đề cương các học phần, đồ án tốt nghiệp, kế hoạch đào tạo</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_43" id="d3_43_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_7"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL tuyển sinh và nhập học:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>44
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>các qui định về tuyển sinh và nhập học</u> <i>đảm bảo lôi cuốn sự tham gia và phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_44" id="d3_44_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>45
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo các đối tượng liên quan cung cấp thông tin về nhu cần đào tạo của bản thân
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_45" id="d3_45_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>46
                                    </td>
                                    <td>(<b>C</b>) <u>Các qui định về tuyển sinh và nhập học</u> <i>rõ ràng, minh bạch, công bằng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_46" id="d3_46_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>47
                                    </td>
                                    <td>(<b>C</b>) <u>Các qui định về tuyển sinh và nhập học</u> <i>phù hợp</i> với CTĐT, đối tượng tuyển sinh và các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_47" id="d3_47_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>48
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_48" id="d3_48_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>49
                                    </td>
                                    <td>(<b>D</b>) <u>Các qui định về tuyển sinh và nhập học</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với đối tượng tuyển sinh và các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_49" id="d3_49_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>50
                                    </td>
                                    <td>(<b>DC</b>) Tổ chức và giám sát thực hiện <u>các qui định về tuyển sinh và nhập học</u> <i>phù hợp</i> với điều kiện tham dự của sinh viên
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_50" id="d3_50_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_8"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL đội ngũ CBQL, giảng viên và nhân viên: </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>51
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>quản lý đội ngũ</u> (CBQL, giảng viên và nhân viên) <u>dựa vào năng lực</u> <i>đảm bảo lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_51" id="d3_51_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>52
                                    </td>
                                    <td>(<b>C</b>) <u>Quy hoạch phát triển đội ngũ</u> (về số lượng, chất lượng và cơ cấu) <i>phù hợp</i> với chiến lược, mục tiêu phát triển CTĐT trong giai đoạn khác nhau
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_52" id="d3_52_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>53
                                    </td>
                                    <td>(<b>C</b>) <u>Các tiêu chuẩn về năng lực của CBQL, giảng viên và nhân viên</u> cần có đáp ứng vị trí việc làm <i>phù hợp</i> với yêu cầu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_53" id="d3_53_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>54
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>quản lý đội ngũ dựa vào năng lực</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_54" id="d3_54_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>55
                                    </td>
                                    <td>(<b>C</b>) <u>Tuyển chọn, sử dụng, luân chuyển và thăng tiến đội ngũ</u> <i>minh bạch, công bằng, dân chủ dựa trên các tiêu chuẩn/chí năng lực</i> cần có đáp ứng vị trí việc làm trong bối cảnh cụ thể
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_55" id="d3_55_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>56
                                    </td>
                                    <td>(<b>C</b>) <u>Hệ thống quản lý thực hiện đội ngũ dựa vào năng lực</u> <i>phù hợp</i> và <i>hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_56" id="d3_56_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>57
                                    </td>
                                    <td>(<b>C</b>) <u>Tổ chức phát triển nghề nghiệp cho đội ngũ dựa vào năng lực</u> <i>đáp ứng được nhu cầu</i> và <i>phù hợp</i> với chiến lược và mục tiêu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_57" id="d3_57_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>58
                                    </td>
                                    <td>(<b>C</b>) <u>Hệ thống đánh giá đội ngũ</u> <i>không chỉ kết quả thực hiện mà cả năng lực</i> (bao gồm người học tham gia đánh giá giảng dạy/đào tạo của giảng viên; giảng viên, nhân viên tham gia đánh giá CBQL...) <i>khách quan, công bằng, dân chủ và minh bạch</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_58" id="d3_58_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>59
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_59" id="d3_59_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_9"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL cơ sở vật chất, phương tiện giảng dạy/thực hành và tài chính:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>60
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, triển khai, kiểm toán</i> sử dụng hiệu quả và tăng cường <u>cơ sở vật chất, phương tiện giảng dạy/thực hành và các nguồn lực tài chính</u> đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_60" id="d3_60_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>61
                                    </td>
                                    <td>(<b>C</b>) <u>Hệ thống phòng học, giảng đường, phòng thí nghiệm, xưởng thực hành, phòng học chuyên môn</u>... <i>đáp ứng yêu cấu</i> thực hiện thành công CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_61" id="d3_61_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>62
                                    </td>
                                    <td>(<b>C</b>) <u>Thư viện có đủ số lượng, chủng loại giáo trình, sách báo, tạp chí, tài liệu chuyên môn, chuyên ngành</u>... được cập nhật <i>phù hợp</i> với CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_62" id="d3_62_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>63
                                    </td>
                                    <td>(<b>C</b>) <u>Hệ thống máy tính và mạng nội bộ (LAN)</u> được cập nhật <i>phù hợp</i> với CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_63" id="d3_63_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>64
                                    </td>
                                    <td>(<b>C</b>) <u>Phương tiện giảng dạy, thực hành, thực tập</u> hiện đại và phân bổ sử dụng hiệu quả <i>phù hợp</i> với CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_64" id="d3_64_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>65
                                    </td>
                                    <td>(<b>C</b>) <u>Hạ tầng, cơ sở vật chất và phương tiện giảng dạy, thực hành, thực tập</u> đáp ứng được các tiêu chí và qui định về mỹ thuật công nghiệp, thẩm mỹ nghề nghiệp, sư phạm cũng như môi trường, an toàn, y tế...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_65" id="d3_65_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>66
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_66" id="d3_66_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>67
                                    </td>
                                    <td>(<b>D</b>) Hệ thống lập và thực hiện kế  hoạch, triển khai, kiểm toán trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_67" id="d3_67_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_10"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b><u>ĐBCL QUÁ TRÌNH ĐÀO TẠO: </u></b></br>
                                        <b>Triết lý và chiến lược đào tạo/giảng dạy và học tập: </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>68
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức xây dựng, thực hiện, giám sát</i> <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT, đảm bảo <i>lôi cuốn được sự tham gia, phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_68" id="d3_68_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>69
                                    </td>
                                    <td>(<b>C</b>) <u>Triết lý và chiến lược đào tạo/giảng dạy và học tập</u> <i>lấy người học làm trọng tâm, đảm bảo học tập có chất lượng, học tập suốt đời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_69" id="d3_69_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>70
                                    </td>
                                    <td>(<b>C</b>) <u>Triết lý, chiến lược đào tạo/giảng dạy và học tập</u> trên giúp <i>người học nắm được và vận dụng kiến thức một cách khoa học vào thực tiễn</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_70" id="d3_70_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>71
                                    </td>
                                    <td>(<b>C</b>) <u>Triết lý, chiến lược đào tạo/giảng dạy và học tập</u> trên <i>tạo điều kiện thuận lợi cho cách học tập tương tác của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_71" id="d3_71_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>72
                                    </td>
                                    <td>(<b>C</b>) <u>Triết lý, chiến lược đào tạo/giảng dạy và học</u> tập trên <i>khuyến khích người học học cách học và hình thành năng lực tự học và học suốt đời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_72" id="d3_72_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>73
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_73" id="d3_73_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>74
                                    </td>
                                    <td>(<b>D</b>) Hệ thống phát triển <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_74" id="d3_74_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_11"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL tổ chức đào tạo/giảng dạy và học tập:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>75
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT, đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_75" id="d3_75_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>76
                                    </td>
                                    <td>(<b>DC</b>) <u>Tổ chức đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT đảm bảo <i>đào tạo/giảng dạy</i> và <i>học tập có chất lượng, học tập suốt đời của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_76" id="d3_76_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>77
                                    </td>
                                    <td>(<b>DC</b>) <u>Tổ chức các hình thức học tập</u> (dự án đào tạo, đào tạo thực hành, bài tập lớn, thực tập doanh nghiệp…) <i>đáp ứng được nhu/yêu cầu của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_77" id="d3_77_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>78
                                    </td>
                                    <td>(<b>C</b>) Các bên liên quan, đặc biệt là bên SDLĐ <u>tham gia hiệu quả vào quá trình đào tạo</u> (biên soạn tài liệu giảng dạy/đào tạo, dạy thực hành, soạn ngân hàng thi, cung cấp nơi thực tập, chấm thi tốt nghiệp...)
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_78" id="d3_78_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>79
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <i>tỷ lệ người dạy trên người học đúng qui định</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_79" id="d3_79_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>80
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_80" id="d3_80_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>81
                                    </td>
                                    <td>(<b>D</b>) Hệ thống thiết kế, thực hiện, giám sát tổ chức <u>đào tạo/giảng dạy và học tập</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_81" id="d3_81_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_12"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL tổ chức đào tạo/giảng dạy và học tập:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>82
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> lập kế hoạch, lựa chọn hình thức, phương pháp <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_82" id="d3_82_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>83
                                    </td>
                                    <td>(<b>C</b>) Hình thức, phương pháp <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> <i>phù hợp để đạt được CĐR của CTĐT và học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_83" id="d3_83_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>84
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <u>đánh giá tiến trình học tập của học người học</u> <i>bao gồm cả đánh giá kết quả nhập học, quá trình học tập và tốt nghiệp</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_84" id="d3_84_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>85
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <u>đánh giá theo dấu vết của người tốt nghiệp</u> (kết quả tìm được việc làm, mức độ đáp ứng yêu cầu vị trí việc làm của bên SDLĐ...) <i>được thực hiện định kỳ hàng năm</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_85" id="d3_85_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>86
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <u>tiêu chuẩn/chí đánh giá người học</u> được xây <i>dựng dựa trên và đạt tới CĐR và CTĐT, học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_86" id="d3_86_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>87
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <u>sử dụng kết hợp các phương pháp</u> khác nhau <i>phù hợp</i> để đánh giá người học và <i>bao phủ tất cả các mục tiêu của CTĐT, học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_87" id="d3_87_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>88
                                    </td>
                                    <td>(<b>C</b>) Đảm bảo <u>sinh viên được tạo cơ hội</u> <i>để nhận xét và/hay khiếu nại về kết quả đánh giá</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_88" id="d3_88_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>89
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_89" id="d3_89_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td>90
                                    </td>
                                    <td>(<b>D</b>) Hệ thống <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_3">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_4">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_5">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_6">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d3_90" id="d3_90_7">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <i>Khác (ghi cụ thể):</i>
                                        <textarea class="form-control" rows="2" id="d3_g_13"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <b>ĐBCL hoạt động phục vụ và hỗ trợ người học:</b>
                                    </td>
                                </tr>
                                <tr>
                                    <tr>
                                        <td>91
                                        </td>
                                        <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>hoạt động phục vụ và hỗ trợ người học</u> đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của sinh viên</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_91" id="d3_91_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>92
                                        </td>
                                        <td>(<b>C</b>) <u>Hoạt động phục vụ và hỗ trợ người học</u> <i>phù hợp để đạt được CĐR của CTĐT và học phần</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_92" id="d3_92_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>93
                                        </td>
                                        <td>(<b>C</b>) Đảm bảo hệ thống <u>kiểm soát tiến trình học tập của người học</u> (phần mềm quản lý; cơ sở dữ liệu đánh giá tiến trình học tập, kết quả học tập và nghiên cứu của người học; thanh tra đào tạo…) <i>phù hợp và hiệu quả</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_93" id="d3_93_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>94
                                        </td>
                                        <td>(<b>C</b>) Đảm bảo <i>người học được</i> <u>tư vấn, hỗ trợ và phản hồi thông tin về học thuật</u> <i>một cách hệ thống phù hợp với tiến trình học tập</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_94" id="d3_94_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>95
                                        </td>
                                        <td>(<b>C</b>) Đảm bảo <u>phù đạo cho người học</u> <i>có chất lượng, phù hợp và kịp thời</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_95" id="d3_95_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>96
                                        </td>
                                        <td>(<b>C</b>) Đảm bảo <u>môi trường học thuật, vật chất, xã hội và tâm lý</u> <i>tích cực và thỏa mãn người học</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_96" id="d3_96_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>97
                                        </td>
                                        <td>(<b>C</b>) Đảm bảo <u>người học được thường xuyên cung cấp thông tin</u> <i>về nghề nghiệp, thị trường lao động và việc làm</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_97" id="d3_97_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>98
                                        </td>
                                        <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_98" id="d3_98_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>99
                                        </td>
                                        <td>(<b>D</b>) Hệ thống <u>hoạt động phục vụ và hỗ trợ người học</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với sinh viên</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_99" id="d3_99_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <i>Khác (ghi cụ thể):</i>
                                            <textarea class="form-control" rows="2" id="d3_g_14"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <b>NĂNG LỰC NÂNG CAO CHẤT LƯỢNG và THAM GIA:</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>100
                                        </td>
                                        <td>(<b>P</b>) Có hệ thống chỉ đạo, điều hành, thực hiện, giám sát và rà soát các hoạt động <u>nâng cao NLCL</u> và <u>tham gia ĐBCL CTĐT</u> <i>phù hợp và nhất quán với nhau</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_100" id="d3_100_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>101
                                        </td>
                                        <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> hệ thống chỉ đạo, điều hành, thực hiện, giám sát và rà soát các hoạt động <u>nâng cao NLCL</u> và <u>tham gia ĐBCL CTĐT</u> đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực, có trách nhiệm của sinh viên</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_101" id="d3_101_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>102
                                        </td>
                                        <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>phát triển được các khung NLCL cần có cho từng vị trí việc làm</u> của hệ thống ĐBCL CTĐT <i>phù hợp và hiệu quả</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_102" id="d3_102_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>103
                                        </td>
                                        <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>nâng cao NLCL cho cá nhân và tập thể</u> <i>phù hợp và hiệu quả</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_103" id="d3_103_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>104
                                        </td>
                                        <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>tham gia của cá nhân và tập thể</u> vào quá trình ĐBCL CTĐT <i>phù hợp và hiệu quả</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_104" id="d3_104_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>105
                                        </td>
                                        <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên để tham gia cải tiến</i>
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_105" id="d3_105_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <i>Khác (ghi cụ thể):</i>
                                            <textarea class="form-control" rows="2" id="d3_g_15"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <b>KẾT QUẢ ĐẦU RA:</b></br>
                                            <b>Mức độ hài lòng của sinh viên:</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>106
                                        </td>
                                        <td>Sinh viên tốt nghiệp hài lòng với hoặc chấp nhận chất lượng của CTĐT
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_106" id="d3_106_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>107
                                        </td>
                                        <td>Sinh viên hài lòng với nội dung chương trình, phương pháp giảng dạy và cách thi, đánh giá
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_107" id="d3_107_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>108
                                        </td>
                                        <td>Năng lực của Sinh viên tốt nghiệp đáp ứng được yêu cầu vị trí việc làm của bên SDLĐ
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_108" id="d3_108_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <i>Khác (ghi cụ thể):</i>
                                            <textarea class="form-control" rows="2" id="d3_g_16"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <b>Hệ thống và công cụ ĐBCL quá trình đào tạo: </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>109
                                        </td>
                                        <td>Kết quả kiểm soát/giám sát chất lượng quá trình đào tạo được phản hồi kịp thời cho sinh viên để tham gia cải tiến liên tục và ngăn chặn sai sót trước khi xảy ra
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_109" id="d3_109_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>110
                                        </td>
                                        <td>Hướng dẫn, hỗ trợ và đào tạo/bồi dưỡng đáp ứng được nhu cầu của sinh viên tham gia thực hiện công tác kiểm soát quá trình đào tạo và đánh giá kết quả giáo dục
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_110" id="d3_110_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>111
                                        </td>
                                        <td>Bộ tiêu chuẩn, tiêu chí và chỉ số ĐBCL CTĐT được thiết kế phù hợp với phát triển nhà trường và ngành Kiến trúc
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_111" id="d3_111_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>112
                                        </td>
                                        <td>Quy trình tự đánh giá ĐBCL đào tạo được thiết kế phù hợp với phát triển nhà trường và ngành Kiến trúc
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_112" id="d3_112_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <i>Khác (ghi cụ thể):</i>
                                            <textarea class="form-control" rows="2" id="d3_g_17"></textarea>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <b>Phản hồi thông tin từ các bên liên quan: </b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>113
                                        </td>
                                        <td>Cấu trúc thông tin phản hồi phù hợp với các đặc trưng của thị trường lao động
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_113" id="d3_113_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>114
                                        </td>
                                        <td>Cấu trúc thông tin phản hồi phù hợp với các đặc trưng của người học và người tốt nghiệp
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_114" id="d3_114_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>115
                                        </td>
                                        <td>Các kết quả phản hồi thông tin từ sinh viên được sử dụng để cải tiến liên tục chất lượng đào tạo cũng như ngăn ngừa các sai sót trước khi xảy ra
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_1">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_2">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_3">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_4">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_5">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_6">
                                        </td>
                                        <td style="text-align: center;">
                                            <input type="radio" name="d3_115" id="d3_115_7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <i>Khác (ghi cụ thể):</i>
                                            <textarea class="form-control" rows="2" id="d3_g_18"></textarea>
                                        </td>
                                    </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-top: 15px;">
                        NỘI DUNG 2: HỆ THỐNG TIÊU CHUẨN, TIÊU CHÍ VÀ CHỈ BÁO THÀNH CÔNG VỀ QUẢN LÝ ĐÀO TẠO NGÀNH KIẾN TRÚC TRÌNH ĐỘ ĐẠI HỌC THEO TIẾP CẬN TQM
                    </div>
                    <div style="text-align: center; padding: 5px;">
                        <i>Xin đề nghị</i> <b><i>Anh/Chị cho ý kiến</i></b> về <b>"Tính CẦN THIẾT"</b> và <b>"Tính KHẢ THI"</b> của <b>Hệ thống TIÊU CHUẨN, TIÊU CHÍ và CHỈ BÁO thành công</b> về<b> Quản lý đào tạo ngành Kiến trúc trình độ đại học theo tiếp cận TQM </b>bằng cách "lựa chọn" <b>một trong ba cột</b> của cả Tính cần thiết và Tính khả thi mà <b>Anh/Chị cho là thích hợp</b> dưới đây:
                    </div>
                    <div style="text-align: center; padding: 3px; padding-left: 5px;"><b style="color: red;">ĐỂ THUẬN LỢI VÀ NHANH CHÓNG TRONG QUÁ TRÌNH TRẢ LỜI KHẢO SÁT, HỆ THỐNG SẼ <i><u>ĐỂ MẶC ĐỊNH</u></i> PHƯƠNG ÁN TRẢ LỜI Ở MỖI CÂU HỎI, ANH/CHỊ CÓ THỂ <i><u>THAY ĐỔI BẰNG CÁCH CHỌN PHƯƠNG ÁN KHÁC PHÙ HỢP</u></i> VỚI CÂU TRẢ LỜI CỦA MÌNH</b></div>
                    <div id="divContentCauHoi4">
                        <table class="table table-bordered">
                            <tbody>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: central; font-weight: bold;">
                                    <td style="width: 70%; vertical-align: middle;" rowspan="2" colspan="2">TÊN TIÊU CHUẨN, TIÊU CHÍ và CHỈ BÁO
                                    </td>
                                    <td style="width: 15%; border-right-width: 5px;" colspan="3">Tính cần thiết
                                    </td>
                                    <td style="width: 15%; border-left-width: 5px;" colspan="3">Tính khả thi
                                    </td>
                                </tr>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: central; font-weight: bold;">
                                    <td style="width: 5%;">Không cần thiết
                                    </td>
                                    <td style="width: 5%;">Cần thiết
                                    </td>
                                    <td style="width: 5%; border-right-width: 5px;">Rất cần thiết
                                    </td>
                                    <td style="width: 5%; border-left-width: 5px;">Không khả thi
                                    </td>
                                    <td style="width: 5%;">Khả thi
                                    </td>
                                    <td style="width: 5%;">Rất khả thi
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>Tiêu chuẩn 1: BỐI CẢNH TRONG VÀ NGOÀI: </u></b>
                                        <br />
                                        <b>Tiêu chí 1: Sứ mạng, giá trị, chiến lược và mục tiêu phát triển CTĐT đại học ngành Kiến trúc
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_1_1" id="d4_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_1_1" id="d4_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_1_1" id="d4_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_1_2" id="d4_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_1_2" id="d4_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_1_2" id="d4_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức xây dựng, thực hiện, giám sát</i> phát triển <u>sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> đảm bảo <i>lôi cuốn được sự tham gia, phản hồi tích cực, có trách nhiệm của tất cả bên liên quan</i> (Lãnh đạo, Quản lý các cấp, Giảng viên, Nhân viên, Sinh viên, Cựu sinh viên, Bên SDLĐ, Các CQ quản lý cấp trên)
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_2_1" id="d4_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_2_1" id="d4_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_2_1" id="d4_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_2_2" id="d4_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_2_2" id="d4_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_2_2" id="d4_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức phát triển, thực hiện, giám sát</i> đảm bảo <u>sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>phù hợp</i> với định hướng phát triển KT-XH, GD&ĐT địa phương, quốc tế và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_3_1" id="d4_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_3_1" id="d4_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_3_1" id="d4_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_3_2" id="d4_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_3_2" id="d4_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_3_2" id="d4_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức phát triển, thực hiện, giám sát</i> đảm bảo <u>sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> <i>đáp ứng được yêu cầu của các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_4_1" id="d4_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_4_1" id="d4_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_4_1" id="d4_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_4_2" id="d4_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_4_2" id="d4_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_4_2" id="d4_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>5
                                    </td>
                                    <td>(<b>D</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> được <i>diễn đạt xúc tích, dễ hiểu và chia sẻ với tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_5_1" id="d4_5_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_5_1" id="d4_5_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_5_1" id="d4_5_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_5_2" id="d4_5_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_5_2" id="d4_5_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_5_2" id="d4_5_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>6
                                    </td>
                                    <td>(<b>D</b>) <u>Sứ mạng, giá trị, chiến lược, mục tiêu phát triển CTĐT</u> được <i>văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_6_1" id="d4_6_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_6_1" id="d4_6_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_6_1" id="d4_6_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_6_2" id="d4_6_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_6_2" id="d4_6_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_6_2" id="d4_6_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>7
                                    </td>
                                    <td>(<b>CA</b>) <u>Chiến lược và mục tiêu phát triển CTĐT</u> được <i>tổ chức rà soát</i> và <i>điều chỉnh hàng năm</i> đảm bảo phù hợp và hiệu quả với tất cả các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_7_1" id="d4_7_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_7_1" id="d4_7_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_7_1" id="d4_7_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_7_2" id="d4_7_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_7_2" id="d4_7_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_7_2" id="d4_7_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 2: Văn hóa chất lượng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>8
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh, củng cố...) </u>VHCL tích cực của ĐBCL CTĐT</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_8_1" id="d4_8_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_8_1" id="d4_8_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_8_1" id="d4_8_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_8_2" id="d4_8_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_8_2" id="d4_8_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_8_2" id="d4_8_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>9
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển </u>VHCL tích cực của ĐBCL CTĐT</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_9_1" id="d4_9_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_9_1" id="d4_9_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_9_1" id="d4_9_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_9_2" id="d4_9_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_9_2" id="d4_9_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_9_2" id="d4_9_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>10
                                    </td>
                                    <td>(<b>PDC</b>) Lãnh đạo trường, CBQL các cấp, giảng viên và nhân viên không chỉ <i>cam kết</i> mà còn <i>tham gia tích cực, có trách nhiệm</i> vào <i>tổ chức thiết kế, thực hiện, giám sát</i> phát triển </u>VHCL tích cực của ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_10_1" id="d4_10_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_10_1" id="d4_10_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_10_1" id="d4_10_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_10_2" id="d4_10_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_10_2" id="d4_10_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_10_2" id="d4_10_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>11
                                    </td>
                                    <td>(<b>PDC</b>) Lãnh đạo (hiệu trưởng, hiệu phó...) <i>tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo phát triển được <i>những giá trị chia sẻ và niềm tin chung</i> của <u>VHCL tích cực</u> <i>phù hợp</i> cho việc thực hiện <u>ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_11_1" id="d4_11_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_11_1" id="d4_11_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_11_1" id="d4_11_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_11_2" id="d4_11_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_11_2" id="d4_11_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_11_2" id="d4_11_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>12
                                    </td>
                                    <td>(<b>PDC</b>) CBQL các cấp (phòng/ban, khoa...) <i>tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo sử dụng công cụ quản lý/trị phù hợp để <i>đưa vào thực tiễn và củng cố những đặc trưng tích cực của <u>VHCL</u></i> (tiêu chuẩn hành vi, cách thức thực hiện, thái độ, quan hệ trong công việc...) trong <u>ĐBCL CTĐT</u> <i>hàng ngày</i> dựa trên các giá trị chia sẻ và niềm tin chung trên
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_12_1" id="d4_12_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_12_1" id="d4_12_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_12_1" id="d4_12_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_12_2" id="d4_12_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_12_2" id="d4_12_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_12_2" id="d4_12_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>13
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo các đặc trưng của <u>VHCL tích cực</u> trên <i>được cụ thể hóa phù hợp</i> trong các chính sách, chiến lược, tiêu chí, quy trình... của hệ thống <u>ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_13_1" id="d4_13_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_13_1" id="d4_13_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_13_1" id="d4_13_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_13_2" id="d4_13_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_13_2" id="d4_13_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_13_2" id="d4_13_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>14
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo đội ngũ giảng viên, nhân viên... <i>thực hiện tốt</i> các quy định về <u>VHCL tích cực</u> trên, đi từ các phản xạ có điều kiện (do được yêu cầu, bị giám sát, gắn với các quy định về khen thưởng, kỷ luật) đến các phản xạ vô điều kiện
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_14_1" id="d4_14_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_14_1" id="d4_14_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_14_1" id="d4_14_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_14_2" id="d4_14_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_14_2" id="d4_14_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_14_2" id="d4_14_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>15
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo chính sách khen thưởng và công nhận <i>phù hợp, khuyến khích, thúc đẩy được</i> tất cả thành viên nhà trường và bên liên quan thực hiện, thay đổi, củng cố <u>VHCL tích cực</u> (thay đổi hành động, niềm tin, tập quán làm việc tốt hơn) của <u>ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_15_1" id="d4_15_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_15_1" id="d4_15_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_15_1" id="d4_15_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_15_2" id="d4_15_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_15_2" id="d4_15_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_15_2" id="d4_15_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>16
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến nâng cao và củng cố</i> <u>VHCL tích cực của ĐBCL CTĐT</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_16_1" id="d4_16_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_16_1" id="d4_16_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_16_1" id="d4_16_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_16_2" id="d4_16_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_16_2" id="d4_16_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_16_2" id="d4_16_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>17
                                    </td>
                                    <td>(<b>D</b>) Các qui định về tổ chức phát triển <u>VHCL tích cực của ĐBCL CTĐT</u> trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_17_1" id="d4_17_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_17_1" id="d4_17_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_17_1" id="d4_17_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_17_2" id="d4_17_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_17_2" id="d4_17_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_17_2" id="d4_17_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>18
                                    </td>
                                    <td>(<b>CA</b>) Các qui định về tổ chức phát triển <u>VHCL tích cực của ĐBCL CTĐT</u> trên được <i>tổ chức rà soát</i> và <i>điều chỉnh hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_18_1" id="d4_18_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_18_1" id="d4_18_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_18_1" id="d4_18_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_18_2" id="d4_18_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_18_2" id="d4_18_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_18_2" id="d4_18_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 3: Hệ thống ĐBCL bên trong</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>19
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>cơ cấu tổ chức, cơ chế, chính sách, kế hoạch chiến lược, chỉ số và chỉ tiêu</u> về ĐBCL CTĐT <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_19_1" id="d4_19_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_19_1" id="d4_19_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_19_1" id="d4_19_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_19_2" id="d4_19_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_19_2" id="d4_19_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_19_2" id="d4_19_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>20
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>cơ cấu tổ chức, cơ chế, chính sách, kế hoạch chiến lược, chỉ số và chỉ tiêu</u> về ĐBCL CTĐT <i>đảm bảo lôi cuốn được tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_20_1" id="d4_20_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_20_1" id="d4_20_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_20_1" id="d4_20_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_20_2" id="d4_20_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_20_2" id="d4_20_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_20_2" id="d4_20_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>21
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>cơ cấu tổ chức và đội ngũ nhân viên</u> về ĐBCL CTĐT <i>phù hợp</i> với qui mô đào tạo ngành Kiến trúc của nhà trường.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_21_1" id="d4_21_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_21_1" id="d4_21_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_21_1" id="d4_21_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_21_2" id="d4_21_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_21_2" id="d4_21_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_21_2" id="d4_21_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>22
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <i>qui định rõ ràng</i> chức năng, nhiệm vụ gắn với quyền hạn, chịu trách nhiệm xã hội và quy trình “chủ trì - phối hợp” theo hướng <i>đảm bảo quyền tự chủ và chịu trách nhiệm của các đơn vị, cá nhân</i> tham gia vào ĐBCL CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_22_1" id="d4_22_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_22_1" id="d4_22_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_22_1" id="d4_22_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_22_2" id="d4_22_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_22_2" id="d4_22_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_22_2" id="d4_22_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>23
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức phát triển, thực hiện, giám sát</i> đảm bảo <u>chính sách và kế hoạch chiến lược</u> về ĐBCL CTĐT <i>rõ ràng và phù hợp</i> với định hướng phát triển nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_23_1" id="d4_23_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_23_1" id="d4_23_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_23_1" id="d4_23_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_23_2" id="d4_23_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_23_2" id="d4_23_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_23_2" id="d4_23_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>24
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức quán triệt và chi tiết</i> <u>chính sách và kế hoạch chiến lược</u> về ĐBCL CTĐT thành các kế hoạch ngắn hạn <i>rõ ràng và phù hợp</i> để <i>thực hiện, giám sát</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_24_1" id="d4_24_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_24_1" id="d4_24_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_24_1" id="d4_24_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_24_2" id="d4_24_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_24_2" id="d4_24_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_24_2" id="d4_24_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>25
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức phát triển, thực hiện, giám sát</i> <u>các chỉ số thực hiện và các chỉ tiêu phấn đấu KPIs chính</u> để đo lường kết quả thực hiện ĐBCL CTĐT <i>rõ ràng, phù hợp</i> với chính sách, kế hoạch chiến lược trên
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_25_1" id="d4_25_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_25_1" id="d4_25_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_25_1" id="d4_25_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_25_2" id="d4_25_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_25_2" id="d4_25_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_25_2" id="d4_25_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>26
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_26_1" id="d4_26_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_26_1" id="d4_26_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_26_1" id="d4_26_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_26_2" id="d4_26_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_26_2" id="d4_26_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_26_2" id="d4_26_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>27
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>cơ cấu tổ chức, cơ chế, chính sách và kế hoạch chiến lược, chỉ số và chỉ tiêu</u> về ĐBCL CTĐT trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_27_1" id="d4_27_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_27_1" id="d4_27_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_27_1" id="d4_27_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_27_2" id="d4_27_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_27_2" id="d4_27_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_27_2" id="d4_27_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>28
                                    </td>
                                    <td>(<b>CA</b>) Các qui định về <u>cơ cấu tổ chức, cơ chế, kế hoạch chiến lược, chỉ số và chỉ tiêu</u> về ĐBCL CTĐT trên được <i>tổ chức rà soát</i> và <i>điều chỉnh hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_28_1" id="d4_28_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_28_1" id="d4_28_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_28_1" id="d4_28_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_28_2" id="d4_28_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_28_2" id="d4_28_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_28_2" id="d4_28_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 4: Tự đánh giá và hệ thống thông tin về ĐBCL CTĐT</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>29
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_29_1" id="d4_29_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_29_1" id="d4_29_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_29_1" id="d4_29_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_29_2" id="d4_29_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_29_2" id="d4_29_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_29_2" id="d4_29_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>30
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT đảm bảo <i>lôi cuốn được sự tham gia, phản hồi tích cực, có trách nhiệm của tất cả bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_30_1" id="d4_30_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_30_1" id="d4_30_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_30_1" id="d4_30_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_30_2" id="d4_30_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_30_2" id="d4_30_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_30_2" id="d4_30_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>31
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>quy trình tự đánh giá</u> ĐBCL CTĐT đảm bảo <i>phù hợp</i> với chính sách và kế hoạch chiến lược liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_31_1" id="d4_31_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_31_1" id="d4_31_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_31_1" id="d4_31_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_31_2" id="d4_31_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_31_2" id="d4_31_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_31_2" id="d4_31_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>32
                                    </td>
                                    <td>(<b>DC</b>) <i>Tổ chức thực hiện, giám sát</i> <u>tự đánh giá</u> về ĐBCL CTĐT <i>được thực hiện thường xuyên</i> và <i>tổng thể sau khi kết thúc năm học</i> hoặc <i>đột xuất nếu cần thiết</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_32_1" id="d4_32_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_32_1" id="d4_32_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_32_1" id="d4_32_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_32_2" id="d4_32_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_32_2" id="d4_32_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_32_2" id="d4_32_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>33
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>hệ thống thông tin</u> (thu thập, xử lý, báo cáo, nhận và chuyển thông tin từ các bên liên quan nhằm hỗ trợ hoạt động ĐBCL CTĐT, nghiên cứu khoa học và phục vụ cộng đồng...) về ĐBCL CTĐT đảm bảo <i>phù hợp, chính xác và sẵn có</i> để cung cấp kịp thời cho các bên liên quan để tự đánh giá
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_33_1" id="d4_33_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_33_1" id="d4_33_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_33_1" id="d4_33_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_33_2" id="d4_33_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_33_2" id="d4_33_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_33_2" id="d4_33_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>34
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến nâng cao chất lượng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_34_1" id="d4_34_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_34_1" id="d4_34_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_34_1" id="d4_34_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_34_2" id="d4_34_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_34_2" id="d4_34_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_34_2" id="d4_34_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>35
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_35_1" id="d4_35_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_35_1" id="d4_35_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_35_1" id="d4_35_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_35_2" id="d4_35_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_35_2" id="d4_35_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_35_2" id="d4_35_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>36
                                    </td>
                                    <td>(<b>CA</b>) Các qui định về <u>quy trình tự đánh giá và hệ thống thông tin</u> về ĐBCL CTĐT trên được <i>tổ chức rà soát và điều chỉnh hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_36_1" id="d4_36_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_36_1" id="d4_36_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_36_1" id="d4_36_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_36_2" id="d4_36_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_36_2" id="d4_36_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_36_2" id="d4_36_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 5: Nâng cao chất lượng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>37
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>chính sách, chiến lược, kế hoạch, hệ thống, quy trình, thủ tục và nguồn lực...</u> <i>phục vụ tốt nhất</i> hoạt động đào tạo, nghiên cứu khoa học và phục vụ cộng đồng của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_37_1" id="d4_37_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_37_1" id="d4_37_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_37_1" id="d4_37_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_37_2" id="d4_37_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_37_2" id="d4_37_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_37_2" id="d4_37_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>38
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>các tiêu chí và quy trình lựa chọn đối tác, các thông tin so chuẩn và đối sánh</u> theo các nội dung trên <i>phù hợp để nâng cao chất lượng</i> hoạt động đào tạo, nghiên cứu khoa học và phục vụ cộng đồng của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_38_1" id="d4_38_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_38_1" id="d4_38_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_38_1" id="d4_38_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_38_2" id="d4_38_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_38_2" id="d4_38_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_38_2" id="d4_38_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>39
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> thực hiện các nội dung trên <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_39_1" id="d4_39_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_39_1" id="d4_39_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_39_1" id="d4_39_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_39_2" id="d4_39_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_39_2" id="d4_39_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_39_2" id="d4_39_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>40
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến nâng cao chất lượng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_40_1" id="d4_40_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_40_1" id="d4_40_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_40_1" id="d4_40_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_40_2" id="d4_40_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_40_2" id="d4_40_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_40_2" id="d4_40_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>41
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>các tiêu chí và quy trình lựa chọn đối tác, các thông tin so chuẩn và đối sánh</u> trên <i>được văn bản hóa và công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_41_1" id="d4_41_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_41_1" id="d4_41_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_41_1" id="d4_41_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_41_2" id="d4_41_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_41_2" id="d4_41_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_41_2" id="d4_41_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>42
                                    </td>
                                    <td>(<b>CA</b>) Các qui định về <u>các tiêu chí và quy trình lựa chọn đối tác, các thông tin so chuẩn và đối sánh</u> trên được <i>tổ chức rà soát</i> và <i>điều chỉnh hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_42_1" id="d4_42_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_42_1" id="d4_42_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_42_1" id="d4_42_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_42_2" id="d4_42_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_42_2" id="d4_42_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_42_2" id="d4_42_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>Tiêu chuẩn 2: ĐBCL ĐẦU VÀO</u></b>
                                        <br />
                                        <b>Tiêu chí 6: Tổ chức phát triển CĐR đại học ngành Kiến trúc 
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>43
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>CĐR của CTĐT và học phần</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_43_1" id="d4_43_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_43_1" id="d4_43_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_43_1" id="d4_43_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_43_2" id="d4_43_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_43_2" id="d4_43_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_43_2" id="d4_43_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>44
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CĐR của CTĐT và học phần</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_44_1" id="d4_44_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_44_1" id="d4_44_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_44_1" id="d4_44_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_44_2" id="d4_44_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_44_2" id="d4_44_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_44_2" id="d4_44_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>45
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CĐR của CTĐT</u> đảm bảo <i>đáp ứng được</i> các yêu cầu của các bên liên quan, đặc biệt là bên SDLĐ, học tập suốt đời của người học, <i>liên thông</i> với các cấp, bậc học của ngành nghề liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_45_1" id="d4_45_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_45_1" id="d4_45_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_45_1" id="d4_45_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_45_2" id="d4_45_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_45_2" id="d4_45_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_45_2" id="d4_45_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>46
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CĐR của học phần</u> đảm bảo <i>gắn kết với nhau, được xây dựng dựa trên và đạt tới</i> CĐR của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_46_1" id="d4_46_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_46_1" id="d4_46_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_46_1" id="d4_46_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_46_2" id="d4_46_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_46_2" id="d4_46_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_46_2" id="d4_46_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>47
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_47_1" id="d4_47_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_47_1" id="d4_47_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_47_1" id="d4_47_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_47_2" id="d4_47_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_47_2" id="d4_47_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_47_2" id="d4_47_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>48
                                    </td>
                                    <td>(<b>D</b>) <u>CĐR của CTĐT và học phần</u> <i>được văn bản hóa và công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_48_1" id="d4_48_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_48_1" id="d4_48_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_48_1" id="d4_48_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_48_2" id="d4_48_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_48_2" id="d4_48_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_48_2" id="d4_48_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>49
                                    </td>
                                    <td>(<b>CA</b>) <u>CĐR của CTĐT và học phần</u> được <i>tổ chức rà soát, điều chỉnh định kỳ 3-5 năm một lần</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_49_1" id="d4_49_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_49_1" id="d4_49_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_49_1" id="d4_49_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_49_2" id="d4_49_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_49_2" id="d4_49_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_49_2" id="d4_49_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 7: Tổ chức phát triển CTĐT đại học ngành Kiến trúc dựa vào CĐR</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>50
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>CTĐT dựa trên CĐR</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_50_1" id="d4_50_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_50_1" id="d4_50_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_50_1" id="d4_50_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_50_2" id="d4_50_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_50_2" id="d4_50_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_50_2" id="d4_50_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>51
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CTĐT dựa trên CĐR</u> <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_51_1" id="d4_51_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_51_1" id="d4_51_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_51_1" id="d4_51_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_51_2" id="d4_51_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_51_2" id="d4_51_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_51_2" id="d4_51_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>52
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>CTĐT, đề cương các học phần, đồ án tốt nghiệp</u> <i>phù hợp</i> với sứ mạng, giá trị, tầm nhìn và mục tiêu phát triển của nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_52_1" id="d4_52_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_52_1" id="d4_52_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_52_1" id="d4_52_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_52_2" id="d4_52_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_52_2" id="d4_52_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_52_2" id="d4_52_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>53
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo tỷ lệ nội dung CTĐT <i>phù hợp giữa lý thuyết và thực hành, thực tập</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_53_1" id="d4_53_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_53_1" id="d4_53_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_53_1" id="d4_53_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_53_2" id="d4_53_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_53_2" id="d4_53_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_53_2" id="d4_53_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>54
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <i>phù hợp</i> để chi tiết <u>CTĐT</u> thành <u>đề cương các học phần, đồ án tốt nghiệp</u> và <u>kế hoạch đào tạo</u>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_54_1" id="d4_54_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_54_1" id="d4_54_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_54_1" id="d4_54_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_54_2" id="d4_54_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_54_2" id="d4_54_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_54_2" id="d4_54_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>55
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>cấu trúc CTĐT và kế hoạch đào tạo</u> <i>kết nối chặt chẽ</i> giữa <u>đề cương các học phần, đồ án tốt nghiệp</u> để đạt tới CĐR
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_55_1" id="d4_55_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_55_1" id="d4_55_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_55_1" id="d4_55_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_55_2" id="d4_55_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_55_2" id="d4_55_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_55_2" id="d4_55_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>56
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo khối lượng/tải trọng học tập của <u>CTĐT và kế hoạch đào tạo</u> <i>phù hợp</i> với ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_56_1" id="d4_56_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_56_1" id="d4_56_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_56_1" id="d4_56_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_56_2" id="d4_56_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_56_2" id="d4_56_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_56_2" id="d4_56_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>57
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>CTĐT, đề cương các học phần</u> <i>cho biết rõ cách áp dụng</i> phương pháp giảng dạy, học tập, thực hành, kiểm tra đánh giá, thi tốt nghiệp để đạt tới CĐR
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_57_1" id="d4_57_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_57_1" id="d4_57_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_57_1" id="d4_57_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_57_2" id="d4_57_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_57_2" id="d4_57_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_57_2" id="d4_57_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>58
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_58_1" id="d4_58_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_58_1" id="d4_58_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_58_1" id="d4_58_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_58_2" id="d4_58_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_58_2" id="d4_58_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_58_2" id="d4_58_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>59
                                    </td>
                                    <td>(<b>D</b>) <u>CTĐT, đề cương các học phần, đồ án tốt nghiệp, kế hoạch đào tạo</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_59_1" id="d4_59_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_59_1" id="d4_59_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_59_1" id="d4_59_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_59_2" id="d4_59_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_59_2" id="d4_59_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_59_2" id="d4_59_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>60
                                    </td>
                                    <td>(<b>CA</b>) <u>Nội dung CTĐT, đề cương các học phần, đồ án tốt nghiệp và kế hoạch đào tạo</u> được <i>tổ chức rà soát, điều chỉnh và cập nhật thường xuyên</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_60_1" id="d4_60_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_60_1" id="d4_60_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_60_1" id="d4_60_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_60_2" id="d4_60_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_60_2" id="d4_60_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_60_2" id="d4_60_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 8: ĐBCL tuyển sinh và nhập học</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>61
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) các <u>qui định về tuyển sinh và nhập học</u> (tiêu chí, chính sách, kế hoạch, truyền thông, giám sát...) <i>phù hợp với CTĐT và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_61_1" id="d4_61_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_61_1" id="d4_61_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_61_1" id="d4_61_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_61_2" id="d4_61_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_61_2" id="d4_61_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_61_2" id="d4_61_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>62
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> phát triển <u>các qui định về tuyển sinh và nhập học</u> <i>đảm bảo lôi cuốn sự tham gia và phản hồi tích cực, có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_62_1" id="d4_62_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_62_1" id="d4_62_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_62_1" id="d4_62_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_62_2" id="d4_62_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_62_2" id="d4_62_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_62_2" id="d4_62_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>63
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo các bên liên quan cung cấp thông tin về nhu cầu nhân lực/NNL cần đào tạo <i>toàn diện và kịp thời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_63_1" id="d4_63_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_63_1" id="d4_63_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_63_1" id="d4_63_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_63_2" id="d4_63_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_63_2" id="d4_63_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_63_2" id="d4_63_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>64
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>các qui định về tuyển sinh và nhập học</u> <i>rõ ràng, minh bạch, công bằng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_64_1" id="d4_64_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_64_1" id="d4_64_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_64_1" id="d4_64_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_64_2" id="d4_64_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_64_2" id="d4_64_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_64_2" id="d4_64_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>65
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>các qui định về tuyển sinh và nhập học</u> <i>phù hợp</i> với CTĐT, đối tượng tuyển sinh và các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_65_1" id="d4_65_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_65_1" id="d4_65_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_65_1" id="d4_65_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_65_2" id="d4_65_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_65_2" id="d4_65_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_65_2" id="d4_65_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>66
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_66_1" id="d4_66_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_66_1" id="d4_66_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_66_1" id="d4_66_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_66_2" id="d4_66_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_66_2" id="d4_66_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_66_2" id="d4_66_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>67
                                    </td>
                                    <td>(<b>D</b>) <u>Các qui định về tuyển sinh và nhập học</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với đối tượng tuyển sinh và các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_67_1" id="d4_67_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_67_1" id="d4_67_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_67_1" id="d4_67_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_67_2" id="d4_67_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_67_2" id="d4_67_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_67_2" id="d4_67_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>68
                                    </td>
                                    <td>(<b>DC</b>) Tổ chức và giám sát thực hiện <u>các qui định về tuyển sinh và nhập học</u> <i>phù hợp</i> với điều kiện tham dự của các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_68_1" id="d4_68_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_68_1" id="d4_68_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_68_1" id="d4_68_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_68_2" id="d4_68_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_68_2" id="d4_68_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_68_2" id="d4_68_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>69
                                    </td>
                                    <td>(<b>CA</b>) <u>Các qui định về tuyển sinh và nhập học</u> được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_69_1" id="d4_69_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_69_1" id="d4_69_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_69_1" id="d4_69_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_69_2" id="d4_69_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_69_2" id="d4_69_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_69_2" id="d4_69_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 9: ĐBCL đội ngũ CBQL, giảng viên và nhân viên</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>70
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống tổ chức phát triển (thiết kế, thẩm định, phê duyệt, ban hành, giám sát thực hiện, rà soát, điều chỉnh...) <u>quản lý đội ngũ</u> (CBQL, giảng viên và nhân viên) <u>dựa vào năng lực</u> <i>phù hợp với CTĐT</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_70_1" id="d4_70_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_70_1" id="d4_70_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_70_1" id="d4_70_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_70_2" id="d4_70_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_70_2" id="d4_70_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_70_2" id="d4_70_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>71
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>quản lý đội ngũ</u> (CBQL, giảng viên và nhân viên) <u>dựa vào năng lực</u> <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_71_1" id="d4_71_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_71_1" id="d4_71_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_71_1" id="d4_71_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_71_2" id="d4_71_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_71_2" id="d4_71_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_71_2" id="d4_71_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>72
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập, thực hiện, giám sát</i> đảm bảo có được <u>quy hoạch phát triển đội ngũ</u> (về số lượng, chất lượng và cơ cấu) <i>phù hợp</i> với chiến lược, mục tiêu phát triển CTĐT trong giai đoạn khác nhau
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_72_1" id="d4_72_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_72_1" id="d4_72_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_72_1" id="d4_72_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_72_2" id="d4_72_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_72_2" id="d4_72_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_72_2" id="d4_72_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>73
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo có được <u>các tiêu chuẩn về năng lực của CBQL, giảng viên và nhân viên</u> cần có đáp ứng vị trí việc làm <i>phù hợp</i> với yêu cầu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_73_1" id="d4_73_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_73_1" id="d4_73_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_73_1" id="d4_73_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_73_2" id="d4_73_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_73_2" id="d4_73_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_73_2" id="d4_73_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>74
                                    </td>
                                    <td>(<b>D</b>) Các qui định về <u>quản lý đội ngũ dựa vào năng lực</u> <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_74_1" id="d4_74_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_74_1" id="d4_74_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_74_1" id="d4_74_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_74_2" id="d4_74_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_74_2" id="d4_74_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_74_2" id="d4_74_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>75
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>tuyển chọn, sử dụng, luân chuyển và thăng tiến đội ngũ</u> <i>minh bạch, công bằng, dân chủ dựa trên các tiêu chuẩn/chí năng lực</i> cần có đáp ứng vị trí việc làm trong bối cảnh cụ thể
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_75_1" id="d4_75_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_75_1" id="d4_75_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_75_1" id="d4_75_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_75_2" id="d4_75_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_75_2" id="d4_75_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_75_2" id="d4_75_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>76
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập quy hoạch, thực hiện, giám sát</i> đảm bảo <u>đội ngũ CBQL, giảng viên và nhân viên</u> (thư viện, thí nghiệm, thực hành, hỗ trợ người học....) <i>đủ số lượng và năng lực</i> phục vụ thỏa mãn các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_76_1" id="d4_76_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_76_1" id="d4_76_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_76_1" id="d4_76_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_76_2" id="d4_76_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_76_2" id="d4_76_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_76_2" id="d4_76_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>77
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>hệ thống quản lý thực hiện đội ngũ dựa vào năng lực</u> <i>phù hợp và hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_77_1" id="d4_77_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_77_1" id="d4_77_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_77_1" id="d4_77_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_77_2" id="d4_77_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_77_2" id="d4_77_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_77_2" id="d4_77_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>78
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>các nhiệm vụ và tải trọng công việc</u> được phân bổ <i>phù hợp</i> với trình độ/bằng cấp, kinh nghiệm, năng lực chuyên môn và phẩm chất đạo đức nghề nghiệp của đội ngũ
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_78_1" id="d4_78_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_78_1" id="d4_78_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_78_1" id="d4_78_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_78_2" id="d4_78_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_78_2" id="d4_78_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_78_2" id="d4_78_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>79
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>phát triển nghề nghiệp cho đội ngũ dựa vào năng lực</u> <i>đáp ứng được nhu cầu</i> và <i>phù hợp</i> với chiến lược và mục tiêu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_79_1" id="d4_79_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_79_1" id="d4_79_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_79_1" id="d4_79_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_79_2" id="d4_79_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_79_2" id="d4_79_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_79_2" id="d4_79_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>80
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>chính sách, chế độ thu hút và duy trì đội ngũ</u> có trình độ cao <i>đáp ứng được với yêu cầu</i> chiến lược và mục tiêu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_80_1" id="d4_80_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_80_1" id="d4_80_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_80_1" id="d4_80_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_80_2" id="d4_80_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_80_2" id="d4_80_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_80_2" id="d4_80_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>81
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>hệ thống đánh giá đội ngũ</u> <i>không chỉ kết quả thực hiện mà cả năng lực</i> (bao gồm người học tham gia đánh giá giảng dạy/đào tạo của giảng viên; giảng viên, nhân viên tham gia đánh giá CBQL...) <i>khách quan, công bằng, dân chủ và minh bạch</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_81_1" id="d4_81_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_81_1" id="d4_81_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_81_1" id="d4_81_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_81_2" id="d4_81_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_81_2" id="d4_81_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_81_2" id="d4_81_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>82
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_82_1" id="d4_82_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_82_1" id="d4_82_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_82_1" id="d4_82_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_82_2" id="d4_82_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_82_2" id="d4_82_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_82_2" id="d4_82_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>83
                                    </td>
                                    <td>(<b>CA</b>) Các <u>qui định về quản lý đội ngũ dựa vào năng lực</u> được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_83_1" id="d4_83_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_83_1" id="d4_83_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_83_1" id="d4_83_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_83_2" id="d4_83_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_83_2" id="d4_83_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_83_2" id="d4_83_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 10: ĐBCL cơ sở vật chất, phương tiện giảng dạy/thực hành và tài chính</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>84
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống lập kế hoạch, triển khai, kiểm toán sử dụng hiệu quả và tăng cường <u>cơ sở vật chất, phương tiện giảng dạy/thực hành và các nguồn lực tài chính</u> đảm bảo <i>thực hiện thành công</i> sứ mạng, chiến lược, mục  tiêu phát triển CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_84_1" id="d4_84_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_84_1" id="d4_84_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_84_1" id="d4_84_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_84_2" id="d4_84_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_84_2" id="d4_84_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_84_2" id="d4_84_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>85
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, triển khai, kiểm toán</i> sử dụng hiệu quả và tăng cường <u>cơ sở vật chất, phương tiện giảng dạy/thực hành và các nguồn lực tài chính</u> đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_85_1" id="d4_85_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_85_1" id="d4_85_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_85_1" id="d4_85_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_85_2" id="d4_85_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_85_2" id="d4_85_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_85_2" id="d4_85_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>86
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>hệ thống phòng học, giảng đường, phòng thí nghiệm, xưởng thực hành, phòng học chuyên môn</u>... <i>đáp ứng yêu cấu</i> thực hiện thành công CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_86_1" id="d4_86_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_86_1" id="d4_86_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_86_1" id="d4_86_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_86_2" id="d4_86_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_86_2" id="d4_86_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_86_2" id="d4_86_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>87
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>thư viện có đủ số lượng, chủng loại giáo trình, sách báo, tạp chí, tài liệu chuyên môn, chuyên ngành</u>... được cập nhật <i>phù hợp</i> với CTĐT 
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_87_1" id="d4_87_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_87_1" id="d4_87_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_87_1" id="d4_87_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_87_2" id="d4_87_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_87_2" id="d4_87_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_87_2" id="d4_87_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>88
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>hệ thống máy tính và mạng nội bộ (LAN)</u> được cập nhập <i>phù hợp</i> với CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_88_1" id="d4_88_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_88_1" id="d4_88_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_88_1" id="d4_88_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_88_2" id="d4_88_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_88_2" id="d4_88_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_88_2" id="d4_88_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>89
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>phương tiện giảng dạy, thực hành, thực tập</u> hiện đại và phân bổ sử dụng hiệu quả <i>phù hợp</i> với CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_89_1" id="d4_89_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_89_1" id="d4_89_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_89_1" id="d4_89_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_89_2" id="d4_89_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_89_2" id="d4_89_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_89_2" id="d4_89_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>90
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện và giám sát</i> <u>hạ tầng, cơ sở vật chất và phương tiện giảng dạy, thực hành, thực tập</u> đáp ứng được các tiêu chí và qui định về mỹ thuật công nghiệp, thẩm mỹ nghề nghiệp, sư phạm cũng như môi trường, an toàn, y tế...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_90_1" id="d4_90_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_90_1" id="d4_90_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_90_1" id="d4_90_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_90_2" id="d4_90_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_90_2" id="d4_90_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_90_2" id="d4_90_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>91
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện và giám sát</i> <u>huy động đủ nguồn tài chính và sử dụng</u> đúng mục đích, qui định và hiệu quả <i>đáp ứng</i> được thực hiện thành công CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_91_1" id="d4_91_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_91_1" id="d4_91_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_91_1" id="d4_91_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_91_2" id="d4_91_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_91_2" id="d4_91_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_91_2" id="d4_91_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>92
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_92_1" id="d4_92_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_92_1" id="d4_92_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_92_1" id="d4_92_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_92_2" id="d4_92_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_92_2" id="d4_92_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_92_2" id="d4_92_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>93
                                    </td>
                                    <td>(<b>D</b>) Hệ thống lập và thực hiện kế hoạch, triển khai, kiểm toán trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_93_1" id="d4_93_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_93_1" id="d4_93_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_93_1" id="d4_93_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_93_2" id="d4_93_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_93_2" id="d4_93_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_93_2" id="d4_93_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>94
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống lập và thực hiện kế hoạch, triển khai, kiểm toán trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_94_1" id="d4_94_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_94_1" id="d4_94_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_94_1" id="d4_94_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_94_2" id="d4_94_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_94_2" id="d4_94_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_94_2" id="d4_94_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>Tiêu chuẩn 3: ĐBCL QUÁ TRÌNH ĐÀO TẠO </u></b>
                                        <br />
                                        <b>Tiêu chí 11: Triết lý và chiến lược đào tạo/giảng dạy và học tập 
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>95
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống phát triển <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_95_1" id="d4_95_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_95_1" id="d4_95_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_95_1" id="d4_95_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_95_2" id="d4_95_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_95_2" id="d4_95_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_95_2" id="d4_95_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>96
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức xây dựng, thực hiện, giám sát</i> <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT, đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_96_1" id="d4_96_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_96_1" id="d4_96_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_96_1" id="d4_96_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_96_2" id="d4_96_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_96_2" id="d4_96_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_96_2" id="d4_96_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>97
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức xây dựng, thực hiện, giám sát</i> đảm bảo có được <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> <i>lấy người học làm trọng tâm, đảm bảo học tập có chất lượng, học tập suốt đời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_97_1" id="d4_97_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_97_1" id="d4_97_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_97_1" id="d4_97_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_97_2" id="d4_97_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_97_2" id="d4_97_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_97_2" id="d4_97_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>98
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>triết lý, chiến lược đào tạo/giảng dạy và học tập</u> trên giúp <i>người học nắm được và vận dụng kiến thức một cách khoa học vào thực tiễn</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_98_1" id="d4_98_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_98_1" id="d4_98_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_98_1" id="d4_98_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_98_2" id="d4_98_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_98_2" id="d4_98_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_98_2" id="d4_98_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>99
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>triết lý, chiến lược đào tạo/giảng dạy và học tập</u> trên <i>tạo điều kiện thuận lợi cho cách học tập tương tác của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_99_1" id="d4_99_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_99_1" id="d4_99_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_99_1" id="d4_99_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_99_2" id="d4_99_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_99_2" id="d4_99_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_99_2" id="d4_99_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>100
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>triết lý, chiến lược đào tạo/giảng dạy và học tập</u> trên <i>khuyến khích người học học cách học và hình thành năng lực tự học và học suốt đời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_100_1" id="d4_100_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_100_1" id="d4_100_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_100_1" id="d4_100_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_100_2" id="d4_100_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_100_2" id="d4_100_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_100_2" id="d4_100_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>101
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_101_1" id="d4_101_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_101_1" id="d4_101_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_101_1" id="d4_101_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_101_2" id="d4_101_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_101_2" id="d4_101_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_101_2" id="d4_101_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>102
                                    </td>
                                    <td>(<b>D</b>) Hệ thống phát triển <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_102_1" id="d4_102_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_102_1" id="d4_102_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_102_1" id="d4_102_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_102_2" id="d4_102_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_102_2" id="d4_102_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_102_2" id="d4_102_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>103
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống phát triển <u>triết lý và chiến lược đào tạo/giảng dạy và học tập</u> trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_103_1" id="d4_103_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_103_1" id="d4_103_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_103_1" id="d4_103_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_103_2" id="d4_103_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_103_2" id="d4_103_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_103_2" id="d4_103_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 12: ĐBCL tổ chức đào tạo/giảng dạy và học tập</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>104
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT, đảm bảo <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực, có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_104_1" id="d4_104_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_104_1" id="d4_104_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_104_1" id="d4_104_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_104_2" id="d4_104_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_104_2" id="d4_104_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_104_2" id="d4_104_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>105
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> <u>đào tạo/giảng dạy và học tập</u> để đạt được CĐR của CTĐT, đảm bảo <i>đào tạo/giảng dạy và học tập có chất lượng, học tập suốt đời của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_105_1" id="d4_105_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_105_1" id="d4_105_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_105_1" id="d4_105_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_105_2" id="d4_105_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_105_2" id="d4_105_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_105_2" id="d4_105_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>106
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo đa dạng hóa <u>các hình thức học tập</u> (dự án đào tạo, đào tạo thực hành, bài tập lớn, thực tập doanh nghiệp…) <i>đáp ứng được nhu/yêu cầu của người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_106_1" id="d4_106_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_106_1" id="d4_106_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_106_1" id="d4_106_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_106_2" id="d4_106_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_106_2" id="d4_106_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_106_2" id="d4_106_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>107
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo các bên liên quan, đặc biệt là bên SDLĐ <u>tham gia hiệu quả vào quá trình đào tạo</u> (biên soạn tài liệu giảng dạy/đào tạo, dạy thực hành, soạn ngân hàng thi, cung cấp nơi thực tập, chấm thi tốt nghiệp...)
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_107_1" id="d4_107_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_107_1" id="d4_107_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_107_1" id="d4_107_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_107_2" id="d4_107_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_107_2" id="d4_107_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_107_2" id="d4_107_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>108
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <i>tỷ lệ người dạy trên người học đúng qui định</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_108_1" id="d4_108_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_108_1" id="d4_108_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_108_1" id="d4_108_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_108_2" id="d4_108_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_108_2" id="d4_108_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_108_2" id="d4_108_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>109
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_109_1" id="d4_109_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_109_1" id="d4_109_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_109_1" id="d4_109_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_109_2" id="d4_109_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_109_2" id="d4_109_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_109_2" id="d4_109_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>110
                                    </td>
                                    <td>(<b>D</b>) Hệ thống thiết kế, thực hiện, giám sát tổ chức <u>đào tạo/giảng dạy và học tập</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_110_1" id="d4_110_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_110_1" id="d4_110_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_110_1" id="d4_110_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_110_2" id="d4_110_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_110_2" id="d4_110_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_110_2" id="d4_110_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>111
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống thiết kế, thực hiện, giám sát tổ chức <u>đào tạo/giảng dạy và học tập</u> trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_111_1" id="d4_111_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_111_1" id="d4_111_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_111_1" id="d4_111_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_111_2" id="d4_111_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_111_2" id="d4_111_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_111_2" id="d4_111_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 13: ĐBCL đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>112
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> lập kế hoạch, lựa chọn hình thức, phương pháp <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> <i>lôi cuốn được sự tham gia</i> và <i>phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_112_1" id="d4_112_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_112_1" id="d4_112_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_112_1" id="d4_112_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_112_2" id="d4_112_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_112_2" id="d4_112_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_112_2" id="d4_112_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>113
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> lập kế hoạch, lựa chọn hình thức, phương pháp <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> <i>phù hợp để đạt được CĐR của CTĐT và học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_113_1" id="d4_113_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_113_1" id="d4_113_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_113_1" id="d4_113_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_113_2" id="d4_113_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_113_2" id="d4_113_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_113_2" id="d4_113_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>114
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>đánh giá tiến trình học tập của học người học</u> <i>bao gồm cả đánh giá kết quả nhập học, quá trình học tập và tốt nghiệp</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_114_1" id="d4_114_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_114_1" id="d4_114_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_114_1" id="d4_114_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_114_2" id="d4_114_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_114_2" id="d4_114_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_114_2" id="d4_114_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>115
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>đánh giá theo dấu vết của người tốt nghiệp</u> (kết quả tìm được việc làm, mức độ đáp ứng yêu cầu vị trí việc làm của bên SDLĐ...) <i>được thực hiện định kỳ hàng năm</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_115_1" id="d4_115_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_115_1" id="d4_115_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_115_1" id="d4_115_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_115_2" id="d4_115_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_115_2" id="d4_115_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_115_2" id="d4_115_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>116
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>tiêu chuẩn/chí đánh giá người học</u> được xây dựng <i>dựa trên và đạt tới CĐR và CTĐT, học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_116_1" id="d4_116_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_116_1" id="d4_116_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_116_1" id="d4_116_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_116_2" id="d4_116_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_116_2" id="d4_116_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_116_2" id="d4_116_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>117
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>sử dụng kết hợp các phương pháp</u> khác nhau <i>phù hợp</i> để đánh giá người học và <i>bao phủ tất cả các mục tiêu của CTĐT, học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_117_1" id="d4_117_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_117_1" id="d4_117_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_117_1" id="d4_117_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_117_2" id="d4_117_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_117_2" id="d4_117_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_117_2" id="d4_117_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>118
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>sinh viên được tạo cơ hội</u> <i>để nhận xét và/hay khiếu nại về kết quả đánh giá</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_118_1" id="d4_118_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_118_1" id="d4_118_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_118_1" id="d4_118_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_118_2" id="d4_118_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_118_2" id="d4_118_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_118_2" id="d4_118_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>119
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến sinh viên, giảng viên và các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_119_1" id="d4_119_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_119_1" id="d4_119_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_119_1" id="d4_119_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_119_2" id="d4_119_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_119_2" id="d4_119_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_119_2" id="d4_119_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>120
                                    </td>
                                    <td>(<b>D</b>) Hệ thống <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_120_1" id="d4_120_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_120_1" id="d4_120_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_120_1" id="d4_120_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_120_2" id="d4_120_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_120_2" id="d4_120_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_120_2" id="d4_120_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>121
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống <u>đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến</u> trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_121_1" id="d4_121_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_121_1" id="d4_121_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_121_1" id="d4_121_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_121_2" id="d4_121_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_121_2" id="d4_121_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_121_2" id="d4_121_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 14: ĐBCL hoạt động phục vụ và hỗ trợ người học</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>122
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>hoạt động phục vụ và hỗ trợ người học</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_122_1" id="d4_122_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_122_1" id="d4_122_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_122_1" id="d4_122_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_122_2" id="d4_122_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_122_2" id="d4_122_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_122_2" id="d4_122_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>123
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> <u>hoạt động phục vụ và hỗ trợ người học</u> <i>phù hợp để đạt được CĐR của CTĐT và học phần</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_123_1" id="d4_123_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_123_1" id="d4_123_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_123_1" id="d4_123_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_123_2" id="d4_123_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_123_2" id="d4_123_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_123_2" id="d4_123_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>124
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> (phần mềm quản lý; cơ sở dữ liệu đánh giá tiến trình học tập, kết quả học tập và nghiên cứu của người học; thanh tra đào tạo…) đảm bảo <u>hệ thống kiểm soát tiến trình học tập của người học</u> <i>phù hợp và hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_124_1" id="d4_124_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_124_1" id="d4_124_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_124_1" id="d4_124_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_124_2" id="d4_124_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_124_2" id="d4_124_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_124_2" id="d4_124_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>125
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>người học được tư vấn, hỗ trợ và phản hồi thông tin</u> <i>về học thuật một cách hệ thống phù hợp với tiến trình học tập</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_125_1" id="d4_125_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_125_1" id="d4_125_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_125_1" id="d4_125_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_125_2" id="d4_125_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_125_2" id="d4_125_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_125_2" id="d4_125_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>126
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>phù đạo cho người học</u> <i>có chất lượng, phù hợp và kịp thời</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_126_1" id="d4_126_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_126_1" id="d4_126_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_126_1" id="d4_126_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_126_2" id="d4_126_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_126_2" id="d4_126_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_126_2" id="d4_126_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>127
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức xây dựng, thực hiện, giám sát</i> đảm bảo <u>môi trường học thuật, vật chất, xã hội và tâm lý</u> <i>tích cực và thỏa mãn người học</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_127_1" id="d4_127_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_127_1" id="d4_127_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_127_1" id="d4_127_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_127_2" id="d4_127_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_127_2" id="d4_127_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_127_2" id="d4_127_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>128
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>người học được thường xuyên cung cấp thông tin</u> <i>về nghề nghiệp, thị trường lao động và việc làm</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_128_1" id="d4_128_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_128_1" id="d4_128_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_128_1" id="d4_128_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_128_2" id="d4_128_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_128_2" id="d4_128_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_128_2" id="d4_128_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>129
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến người học, giảng viên, nhân viên và các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_129_1" id="d4_129_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_129_1" id="d4_129_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_129_1" id="d4_129_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_129_2" id="d4_129_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_129_2" id="d4_129_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_129_2" id="d4_129_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>130
                                    </td>
                                    <td>(<b>D</b>) Hệ thống <u>hoạt động phục vụ và hỗ trợ người học</u> trên <i>đđược văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_130_1" id="d4_130_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_130_1" id="d4_130_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_130_1" id="d4_130_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_130_2" id="d4_130_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_130_2" id="d4_130_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_130_2" id="d4_130_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>131
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống hoạt động phục vụ và hỗ trợ người học trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo tính phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_131_1" id="d4_131_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_131_1" id="d4_131_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_131_1" id="d4_131_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_131_2" id="d4_131_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_131_2" id="d4_131_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_131_2" id="d4_131_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 15: ĐBCL Nghiên cứu khoa học và phục vụ cộng đồng</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>132
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống chỉ đạo, thực hiện, giám sát và rà soát các hoạt động nghiên cứu, chất lượng, đội ngũ, nguồn lực... <u>nghiên cứu khoa học, đặc biệt là nghiên ứng dụng phục vụ đào tạo và cộng đồng</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_132_1" id="d4_132_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_132_1" id="d4_132_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_132_1" id="d4_132_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_132_2" id="d4_132_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_132_2" id="d4_132_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_132_2" id="d4_132_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>133
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> hệ thống chỉ đạo, thực hiện, giám sát và rà soát các hoạt động nghiên cứu, chất lượng, đội ngũ, nguồn lực... <u>nghiên cứu khoa học, đặc biệt là nghiên ứng dụng  phục vụ đào tạo và cộng đồng</u> <i>đảm bảo lôi cuốn được sự tham gia và phản hồi tích cực và có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_133_1" id="d4_133_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_133_1" id="d4_133_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_133_1" id="d4_133_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_133_2" id="d4_133_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_133_2" id="d4_133_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_133_2" id="d4_133_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>134
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> ĐBCL các <u>hoạt động nghiên cứu</u> của đội ngũ, nguồn lực... nghiên cứu khoa học <i>phục vụ thực hiện thành công CTĐT</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_134_1" id="d4_134_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_134_1" id="d4_134_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_134_1" id="d4_134_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_134_2" id="d4_134_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_134_2" id="d4_134_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_134_2" id="d4_134_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>135
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> ĐBCL các <u>hoạt động nghiên cứu</u> của đội ngũ, nguồn lực... nghiên cứu khoa học <i>đáp ứng được nhu/yêu cộng đồng</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_135_1" id="d4_135_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_135_1" id="d4_135_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_135_1" id="d4_135_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_135_2" id="d4_135_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_135_2" id="d4_135_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_135_2" id="d4_135_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>136
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến người học, giảng viên, nhân viên và các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_136_1" id="d4_136_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_136_1" id="d4_136_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_136_1" id="d4_136_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_136_2" id="d4_136_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_136_2" id="d4_136_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_136_2" id="d4_136_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>137
                                    </td>
                                    <td>(<b>D</b>) Hệ thống <u>nghiên cứu khoa học phục vụ đào tạo và cộng đồng</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_137_1" id="d4_137_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_137_1" id="d4_137_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_137_1" id="d4_137_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_137_2" id="d4_137_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_137_2" id="d4_137_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_137_2" id="d4_137_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>138
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống <u>nghiên cứu khoa học phục vụ đào tạo và cộng đồng</u> trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo tính phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_138_1" id="d4_138_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_138_1" id="d4_138_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_138_1" id="d4_138_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_138_2" id="d4_138_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_138_2" id="d4_138_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_138_2" id="d4_138_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>Tiêu chuẩn 4: NĂNG LỰC NÂNG CAO CHẤT LƯỢNG và THAM GIA</u></b>
                                        <br />
                                        <b>Tiêu chí 16: Năng lực nâng cao chất lượng và tham gia
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>139
                                    </td>
                                    <td>(<b>P</b>) <i>Có</i> hệ thống chỉ đạo, điều hành, thực hiện, giám sát và rà soát các hoạt động <u>nâng cao NLCL</u> và <u>tham gia ĐBCL CTĐT</u> <i>phù hợp và nhất quán với nhau</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_139_1" id="d4_139_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_139_1" id="d4_139_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_139_1" id="d4_139_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_139_2" id="d4_139_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_139_2" id="d4_139_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_139_2" id="d4_139_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>140	
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> hệ thống chỉ đạo, điều hành, thực hiện, giám sát và rà soát các hoạt động <u>nâng cao NLCL</u> và <u>tham gia ĐBCL CTĐT</u> đảm bảo <i>lôi cuốn được sự tham gia và phản hồi tích cực, có trách nhiệm của tất cả các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_140_1" id="d4_140_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_140_1" id="d4_140_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_140_1" id="d4_140_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_140_2" id="d4_140_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_140_2" id="d4_140_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_140_2" id="d4_140_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>141
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức thiết kế, thực hiện, giám sát</i> đảm bảo <u>phát triển được các khung NLCL cần có</u> <i>cho từng vị trí việc làm</i> của hệ thống ĐBCL CTĐT <i>phù hợp và hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_141_1" id="d4_141_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_141_1" id="d4_141_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_141_1" id="d4_141_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_141_2" id="d4_141_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_141_2" id="d4_141_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_141_2" id="d4_141_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>142
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>nâng cao NLCL cho cá nhân và tập thể</u> <i>phù hợp và hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_142_1" id="d4_142_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_142_1" id="d4_142_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_142_1" id="d4_142_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_142_2" id="d4_142_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_142_2" id="d4_142_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_142_2" id="d4_142_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>143
                                    </td>
                                    <td>(<b>PDC</b>) <i>Tổ chức lập kế hoạch, thực hiện, giám sát</i> đảm bảo <u>tham gia của cá nhân và tập thể</u> vào quá trình ĐBCL CTĐT <i>phù hợp và hiệu quả</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_143_1" id="d4_143_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_143_1" id="d4_143_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_143_1" id="d4_143_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_143_2" id="d4_143_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_143_2" id="d4_143_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_143_2" id="d4_143_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>144
                                    </td>
                                    <td>(<b>A</b>) Thông tin giám sát trên được <i>phản hồi kịp thời đến các bên liên quan để cải tiến</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_144_1" id="d4_144_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_144_1" id="d4_144_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_144_1" id="d4_144_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_144_2" id="d4_144_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_144_2" id="d4_144_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_144_2" id="d4_144_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>145
                                    </td>
                                    <td>(<b>D</b>) Hệ thống <u>nâng cao NLCL và tham gia ĐBCL CTĐT</u> trên <i>được văn bản hóa</i> và <i>công bố công khai, dễ tiếp cận với các bên liên quan</i>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_145_1" id="d4_145_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_145_1" id="d4_145_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_145_1" id="d4_145_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_145_2" id="d4_145_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_145_2" id="d4_145_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_145_2" id="d4_145_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>146
                                    </td>
                                    <td>(<b>CA</b>) Hệ thống <u>nâng cao NLCL và tham gia ĐBCL CTĐT</u> trên được <i>tổ chức rà soát, điều chỉnh và cập nhật hàng năm</i> đảm bảo tính phù hợp và hiệu quả với các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_146_1" id="d4_146_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_146_1" id="d4_146_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_146_1" id="d4_146_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_146_2" id="d4_146_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_146_2" id="d4_146_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_146_2" id="d4_146_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>Tiêu chuẩn 5: KẾT QUẢ ĐẦU RA</u></b>
                                        <br />
                                        <b>Tiêu chí 17: Kết qủa đầu ra
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>147
                                    </td>
                                    <td>Tỷ lệ tốt nghiệp đáp ứng được chỉ tiêu đã đề ra và tỷ lệ bỏ học ở mức độ chấp nhận được
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_147_1" id="d4_147_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_147_1" id="d4_147_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_147_1" id="d4_147_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_147_2" id="d4_147_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_147_2" id="d4_147_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_147_2" id="d4_147_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>148
                                    </td>
                                    <td>Thời gian trung bình từ lúc bắt đầu học đến tốt nghiệp hợp lý
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_148_1" id="d4_148_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_148_1" id="d4_148_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_148_1" id="d4_148_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_148_2" id="d4_148_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_148_2" id="d4_148_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_148_2" id="d4_148_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>149
                                    </td>
                                    <td>Tỷ lệ người tốt nghiệp tìm được việc làm chấp nhận được
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_149_1" id="d4_149_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_149_1" id="d4_149_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_149_1" id="d4_149_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_149_2" id="d4_149_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_149_2" id="d4_149_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_149_2" id="d4_149_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>150
                                    </td>
                                    <td>Áp dụng kết quả nghiên cứu khoa học vào thực hiện CTĐT và phục vụ cộng đồng thỏa đáng
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_150_1" id="d4_150_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_150_1" id="d4_150_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_150_1" id="d4_150_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_150_2" id="d4_150_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_150_2" id="d4_150_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_150_2" id="d4_150_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 18: Mức độ hài lòng của các bên liên quan</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>151
                                    </td>
                                    <td>Các bên liên quan hài lòng với hoặc chấp nhận chất lượng của CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_151_1" id="d4_151_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_151_1" id="d4_151_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_151_1" id="d4_151_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_151_2" id="d4_151_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_151_2" id="d4_151_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_151_2" id="d4_151_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>152
                                    </td>
                                    <td>Người học hài lòng với nội dung chương trình, phương pháp giảng dạy và cách thi, đánh giá
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_152_1" id="d4_152_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_152_1" id="d4_152_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_152_1" id="d4_152_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_152_2" id="d4_152_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_152_2" id="d4_152_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_152_2" id="d4_152_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>153
                                    </td>
                                    <td>Năng lực của người tốt nghiệp đáp ứng được yêu cầu vị trí việc làm của bên SDLĐ
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_153_1" id="d4_153_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_153_1" id="d4_153_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_153_1" id="d4_153_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_153_2" id="d4_153_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_153_2" id="d4_153_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_153_2" id="d4_153_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 19: Hệ thống và công cụ ĐBCL quá trình đào tạo</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>154
                                    </td>
                                    <td>Kết quả kiểm soát/giám sát chất lượng quá trình đào tạo được phản hồi kịp thời cho các bên liên quan để cải tiến liên tục và ngăn chặn sai sót trước khi xảy ra
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_154_1" id="d4_154_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_154_1" id="d4_154_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_154_1" id="d4_154_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_154_2" id="d4_154_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_154_2" id="d4_154_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_154_2" id="d4_154_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>155
                                    </td>
                                    <td>Hướng dẫn, hỗ trợ và đào tạo/bồi dưỡng đáp ứng được nhu cầu của đội ngũ CBQL, giảng viên, nhân viên, thực hiện công tác kiểm soát quá trình đào tạo và đánh giá kết quả giáo dục
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_155_1" id="d4_155_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_155_1" id="d4_155_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_155_1" id="d4_155_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_155_2" id="d4_155_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_155_2" id="d4_155_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_155_2" id="d4_155_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>156
                                    </td>
                                    <td>Bộ tiêu chuẩn, tiêu chí và chỉ số ĐBCL CTĐT được thiết kế phù hợp với phát triển nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_156_1" id="d4_156_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_156_1" id="d4_156_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_156_1" id="d4_156_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_156_2" id="d4_156_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_156_2" id="d4_156_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_156_2" id="d4_156_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>157
                                    </td>
                                    <td>Quy trình tự đánh giá ĐBCL đào tạo được thiết kế phù hợp với phát triển nhà trường và ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_157_1" id="d4_157_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_157_1" id="d4_157_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_157_1" id="d4_157_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_157_2" id="d4_157_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_157_2" id="d4_157_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_157_2" id="d4_157_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chí 20: Phản hồi thông tin từ các bên liên quan</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>158
                                    </td>
                                    <td>Cấu trúc thông tin phản hồi phù hợp với các đặc trưng của thị trường lao động, đặc biệt là bên SDLĐ
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_158_1" id="d4_158_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_158_1" id="d4_158_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_158_1" id="d4_158_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_158_2" id="d4_158_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_158_2" id="d4_158_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_158_2" id="d4_158_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>159
                                    </td>
                                    <td>Cấu trúc thông tin phản hồi phù hợp với các đặc trưng của CBQL, giảng viên, nhân viên hỗ trợ
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_159_1" id="d4_159_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_159_1" id="d4_159_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_159_1" id="d4_159_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_159_2" id="d4_159_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_159_2" id="d4_159_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_159_2" id="d4_159_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>160
                                    </td>
                                    <td>Cấu trúc thông tin phản hồi phù hợp với các đặc trưng của người học và người tốt nghiệp
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_160_1" id="d4_160_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_160_1" id="d4_160_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_160_1" id="d4_160_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_160_2" id="d4_160_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_160_2" id="d4_160_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_160_2" id="d4_160_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>161
                                    </td>
                                    <td>Các kết quả phản hồi thông tin từ các bên liên quan được sử dụng để cải tiến liên tục chất lượng đào tạo cũng như ngăn ngừa các sai sót trước khi xảy ra
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_161_1" id="d4_161_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_161_1" id="d4_161_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d4_161_1" id="d4_161_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d4_161_2" id="d4_161_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_161_2" id="d4_161_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d4_161_2" id="d4_161_2_3">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: center; font-weight: bold; padding-top: 15px;">
                        NỘI DUNG 3: CÁC GIẢI PHÁP VỀ QUẢN LÝ ĐÀO TẠO NGÀNH KIẾN TRÚC TRÌNH ĐỘ ĐẠI HỌC THEO TIẾP CẬN TQM
                    </div>
                    <div style="text-align: center; padding: 5px;">
                        <i>Xin đề nghị</i> <b><i>Anh/chị cho ý kiến</i></b> về <b>"Tính CẦN THIẾT"</b> và <b>"Tính KHẢ THI"</b> của
    <b>các GIẢI PHÁP về Quản lý đào tạo ngành Kiến trúc trình độ đại học theo tiếp cận TQM</b></b> bằng cách <b>"lựa chọn" một trong ba cột</b> của cả Tính cần thiết và Tính khả thi mà <b>Anh/Chị cho là thích hợp</b> dưới đây:
                    </div>
                    <div style="text-align: center; padding: 3px; padding-left: 5px;"><b style="color: red;">ĐỂ THUẬN LỢI VÀ NHANH CHÓNG TRONG QUÁ TRÌNH TRẢ LỜI KHẢO SÁT, HỆ THỐNG SẼ <i><u>ĐỂ MẶC ĐỊNH</u></i> PHƯƠNG ÁN TRẢ LỜI Ở MỖI CÂU HỎI, ANH/CHỊ CÓ THỂ <i><u>THAY ĐỔI BẰNG CÁCH CHỌN PHƯƠNG ÁN KHÁC PHÙ HỢP</u></i> VỚI CÂU TRẢ LỜI CỦA MÌNH</b></div>
                    <div id="divContentCauHoi5">
                        <table class="table table-bordered">
                            <tbody>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: central; font-weight: bold;">
                                    <td style="width: 70%; vertical-align: middle;" rowspan="2" colspan="2">TÊN và NỘI DUNG GIẢI PHÁP
                                    </td>
                                    <td style="width: 15%; border-right-width: 5px;" colspan="3">Tính cần thiết
                                    </td>
                                    <td style="width: 15%; border-left-width: 5px;" colspan="3">Tính khả thi
                                    </td>
                                </tr>
                                <tr style="background-color: #fff82b; text-align: center; vertical-align: central; font-weight: bold;">
                                    <td style="width: 5%;">Không cần thiết
                                    </td>
                                    <td style="width: 5%;">Cần thiết
                                    </td>
                                    <td style="width: 5%; border-right-width: 5px;">Rất cần thiết
                                    </td>
                                    <td style="width: 5%; border-left-width: 5px;">Không khả thi
                                    </td>
                                    <td style="width: 5%;">Khả thi
                                    </td>
                                    <td style="width: 5%;">Rất khả thi
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b><u>GIẢI PHÁP 1:</u> Bộ 05 tiêu chuẩn, 20 tiêu chí đo/đánh giá quản lý đào tạo ngành Kiến trúc trình độ đại học theo tiếp cận TQM</b>
                                        </br>
                                        <b>Tiêu chuẩn 1: BỐI CẢNH TRONG VÀ NGOÀI 
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td>Tiêu chí 1: Sứ mạng, giá trị, chiến lược và mục tiêu phát triển CTĐT đại học ngành Kiến trúc
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_1_1" id="d5_g1_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_1_1" id="d5_g1_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_1_1" id="d5_g1_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_1_2" id="d5_g1_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_1_2" id="d5_g1_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_1_2" id="d5_g1_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td>Tiêu chí 2: Văn hóa chất lượng
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_2_1" id="d5_g1_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_2_1" id="d5_g1_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_2_1" id="d5_g1_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_2_2" id="d5_g1_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_2_2" id="d5_g1_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_2_2" id="d5_g1_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td>Tiêu chí 3: Hệ thống ĐBCL bên trong
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_3_1" id="d5_g1_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_3_1" id="d5_g1_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_3_1" id="d5_g1_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_3_2" id="d5_g1_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_3_2" id="d5_g1_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_3_2" id="d5_g1_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td>Tiêu chí 4: Tự đánh giá và hệ thống thông tin về ĐBCL CTĐT
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_4_1" id="d5_g1_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_4_1" id="d5_g1_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_4_1" id="d5_g1_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_4_2" id="d5_g1_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_4_2" id="d5_g1_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_4_2" id="d5_g1_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>5
                                    </td>
                                    <td>Tiêu chí 5: Nâng cao chất lượng
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_5_1" id="d5_g1_5_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_5_1" id="d5_g1_5_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_5_1" id="d5_g1_5_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_5_2" id="d5_g1_5_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_5_2" id="d5_g1_5_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_5_2" id="d5_g1_5_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chuẩn 2: ĐBCL ĐẦU VÀO
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>6
                                    </td>
                                    <td>Tiêu chí 6: Tổ chức phát triển CĐR đại học ngành Kiến trúc 
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_6_1" id="d5_g1_6_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_6_1" id="d5_g1_6_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_6_1" id="d5_g1_6_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_6_2" id="d5_g1_6_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_6_2" id="d5_g1_6_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_6_2" id="d5_g1_6_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>7
                                    </td>
                                    <td>Tiêu chí 7: Tổ chức phát triển CTĐT đại học ngành Kiến trúc dựa vào CĐR
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_7_1" id="d5_g1_7_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_7_1" id="d5_g1_7_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_7_1" id="d5_g1_7_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_7_2" id="d5_g1_7_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_7_2" id="d5_g1_7_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_7_2" id="d5_g1_7_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>8
                                    </td>
                                    <td>Tiêu chí 8: ĐBCL tuyển sinh và nhập học
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_8_1" id="d5_g1_8_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_8_1" id="d5_g1_8_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_8_1" id="d5_g1_8_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_8_2" id="d5_g1_8_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_8_2" id="d5_g1_8_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_8_2" id="d5_g1_8_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>9
                                    </td>
                                    <td>Tiêu chí 9: ĐBCL đội ngũ CBQL, giảng viên và nhân viên
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_9_1" id="d5_g1_9_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_9_1" id="d5_g1_9_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_9_1" id="d5_g1_9_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_9_2" id="d5_g1_9_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_9_2" id="d5_g1_9_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_9_2" id="d5_g1_9_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>10
                                    </td>
                                    <td>Tiêu chí 10: ĐBCL cơ sở vật chất, phương tiện giảng dạy/thực hành và tài chính
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_10_1" id="d5_g1_10_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_10_1" id="d5_g1_10_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_10_1" id="d5_g1_10_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_10_2" id="d5_g1_10_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_10_2" id="d5_g1_10_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_10_2" id="d5_g1_10_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chuẩn 3: ĐBCL QUÁ TRÌNH ĐÀO TẠO 
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>11
                                    </td>
                                    <td>Tiêu chí 11: Triết lý và chiến lược đào tạo/giảng dạy và học tập
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_11_1" id="d5_g1_11_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_11_1" id="d5_g1_11_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_11_1" id="d5_g1_11_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_11_2" id="d5_g1_11_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_11_2" id="d5_g1_11_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_11_2" id="d5_g1_11_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>12
                                    </td>
                                    <td>Tiêu chí 12: ĐBCL tổ chức đào tạo/giảng dạy và học tập
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_12_1" id="d5_g1_12_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_12_1" id="d5_g1_12_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_12_1" id="d5_g1_12_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_12_2" id="d5_g1_12_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_12_2" id="d5_g1_12_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_12_2" id="d5_g1_12_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>13
                                    </td>
                                    <td>Tiêu chí 13: ĐBCL đánh giá tiến trình học tập của người học và phản hồi thông tin để cải tiến
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_13_1" id="d5_g1_13_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_13_1" id="d5_g1_13_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_13_1" id="d5_g1_13_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_13_2" id="d5_g1_13_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_13_2" id="d5_g1_13_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_13_2" id="d5_g1_13_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>14
                                    </td>
                                    <td>Tiêu chí 14: ĐBCL hoạt động phục vụ và hỗ trợ người học
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_14_1" id="d5_g1_14_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_14_1" id="d5_g1_14_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_14_1" id="d5_g1_14_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_14_2" id="d5_g1_14_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_14_2" id="d5_g1_14_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_14_2" id="d5_g1_14_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>15
                                    </td>
                                    <td>Tiêu chí 15: ĐBCL Nghiên cứu khoa học và phục vụ cộng đồng
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_15_1" id="d5_g1_15_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_15_1" id="d5_g1_15_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_15_1" id="d5_g1_15_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_15_2" id="d5_g1_15_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_15_2" id="d5_g1_15_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_15_2" id="d5_g1_15_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chuẩn 4: NĂNG LỰC NÂNG CAO CHẤT LƯỢNG và THAM GIA
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>16
                                    </td>
                                    <td>Tiêu chí 16: Năng lực nâng cao chất lượng và tham gia
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_16_1" id="d5_g1_16_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_16_1" id="d5_g1_16_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_16_1" id="d5_g1_16_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_16_2" id="d5_g1_16_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_16_2" id="d5_g1_16_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_16_2" id="d5_g1_16_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>Tiêu chuẩn 5: KẾT QUẢ ĐẦU RA
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>17
                                    </td>
                                    <td>Tiêu chí 17: Kết quả đầu ra
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_17_1" id="d5_g1_17_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_17_1" id="d5_g1_17_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_17_1" id="d5_g1_17_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_17_2" id="d5_g1_17_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_17_2" id="d5_g1_17_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_17_2" id="d5_g1_17_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>18
                                    </td>
                                    <td>Tiêu chí 18: Mức độ hài lòng của các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_18_1" id="d5_g1_18_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_18_1" id="d5_g1_18_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_18_1" id="d5_g1_18_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_18_2" id="d5_g1_18_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_18_2" id="d5_g1_18_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_18_2" id="d5_g1_18_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>19
                                    </td>
                                    <td>Tiêu chí 19: Hệ thống và công cụ ĐBCL quá trình đào tạo
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_19_1" id="d5_g1_19_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_19_1" id="d5_g1_19_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_19_1" id="d5_g1_19_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_19_2" id="d5_g1_19_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_19_2" id="d5_g1_19_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_19_2" id="d5_g1_19_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>20
                                    </td>
                                    <td>Tiêu chí 20: Phản hồi thông tin từ các bên liên quan
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_20_1" id="d5_g1_20_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_20_1" id="d5_g1_20_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g1_20_1" id="d5_g1_20_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g1_20_2" id="d5_g1_20_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_20_2" id="d5_g1_20_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g1_20_2" id="d5_g1_20_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>GIẢI PHÁP 2: Phát triển văn hóa chất lượng thực hiện CTĐT đại học ngành Kiến trúc theo tiếp cận TQM 
                                        </b>
                                        </br>
                                    </td>
                                </tr>

                                <tr>
                                    <td>1
                                    </td>
                                    <td><b>Bước 1. Tổ chức xác lập chuẩn chất lượng</b> (chuẩn đầu ra, chuẩn GV), <b>bộ công cụ đánh giá</b> (đánh giá giảng viên, đánh giá môn học/học phần, đánh giá dịch vụ), <b>nội quy, quy chế về ĐBCL</b> đảm bảo đạt được sự đồng thuận của những bên liên quan và được cụ thể hóa thành nhiệm vụ của mỗi thành viên, đơn vị của nhà trường.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_1_1" id="d5_g2_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_1_1" id="d5_g2_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g2_1_1" id="d5_g2_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g2_1_2" id="d5_g2_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_1_2" id="d5_g2_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_1_2" id="d5_g2_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td><b>Bước 2. Tổ chức phổ biến, tuyên truyền các chủ trương, chính sách về ĐBCL</b> của nhà trường một cách sâu rộng, cụ thể đến mọi thành viên và đơn vị của nhà trường, bằng nhiều hình thức khác nhau.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_2_1" id="d5_g2_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_2_1" id="d5_g2_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g2_2_1" id="d5_g2_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g2_2_2" id="d5_g2_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_2_2" id="d5_g2_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_2_2" id="d5_g2_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td><b>Bước 3. Tổ chức triển khai thực hiện</b> các hoạt động ĐBCL đến toàn thể cán bộ, giảng viên, nhân viên, và người học; cần triển khai đồng bộ giữa các đơn vị, tổ chức, đoàn thể, cá nhân.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_3_1" id="d5_g2_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_3_1" id="d5_g2_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g2_3_1" id="d5_g2_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g2_3_2" id="d5_g2_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_3_2" id="d5_g2_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_3_2" id="d5_g2_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td><b>Bước 4. Kiểm tra, đánh giá kết quả thực hiện</b> và <b>phản hồi thông tin</b> đến các bên liên quan để <b>điểu chỉnh, cải tiến kịp thời</b>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_4_1" id="d5_g2_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_4_1" id="d5_g2_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g2_4_1" id="d5_g2_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g2_4_2" id="d5_g2_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_4_2" id="d5_g2_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_4_2" id="d5_g2_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>5
                                    </td>
                                    <td><b>Bước 5. Tổ chức xem xét và điều chỉnh, bổ sung định kỳ</b> các tiêu chuẩn chất lượng, bộ công cụ đánh giá, quy định... về ĐBCL của nhà trường.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_5_1" id="d5_g2_5_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_5_1" id="d5_g2_5_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g2_5_1" id="d5_g2_5_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g2_5_2" id="d5_g2_5_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_5_2" id="d5_g2_5_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g2_5_2" id="d5_g2_5_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>GIẢI PHÁP 3: Phát triển hệ thống BÊN TRONG về ĐBCL CTĐT đại học ngành Kiến trúc theo tiếp cận TQM
                                        </b>
                                        </br>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td><b>Bước 1. Tổ chức phát triển <u>CĐR</u> của CTĐT đại học ngành Kiến trúc</b> dựa trên phân tích vị trí việc làm của người tốt nghiệp, cũng như dựa trên sứ mạng, giá trị, tầm nhìn, chiến lược, mục tiêu và kế hoạch phát triển của nhà trường và CTĐT.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_1_1" id="d5_g3_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_1_1" id="d5_g3_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g3_1_1" id="d5_g3_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g3_1_2" id="d5_g3_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_1_2" id="d5_g3_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_1_2" id="d5_g3_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td><b>Bước 2. Quản lý phát triển <u>hệ thống kiểm soát chất lượng</u> CTĐT đại học ngành Kiến trúc theo tiếp cận TQM</b> đảm bảo kiểm soát được: Tiến triển học tập của sinh viên từ lúc nhập học, trong quá trình học tập đến thi tốt nghiệp; Các tỷ lệ đỗ tốt nghiệp và tỷ lệ bỏ học; Thông tin phản hồi từ các bên liên quan, đặc biệt là bên SDLĐ cũng như từ người tốt nghiệp...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_2_1" id="d5_g3_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_2_1" id="d5_g3_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g3_2_1" id="d5_g3_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g3_2_2" id="d5_g3_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_2_2" id="d5_g3_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_2_2" id="d5_g3_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td><b>Bước 3. Tổ chức phát triển <u>hệ thống đánh giá chất lượng</u> CTĐT đại học ngành Kiến trúc theo tiếp cận TQM</b>, bao gồm cả tự đánh giá tổng thể, tự đánh giá thường xuyên...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_3_1" id="d5_g3_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_3_1" id="d5_g3_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g3_3_1" id="d5_g3_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g3_3_2" id="d5_g3_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_3_2" id="d5_g3_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_3_2" id="d5_g3_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td><b>Bước 4. Quản lý phát triển hệ thống <u>cải tiến liên tục chất lượng</u> CTĐT đại học ngành Kiến trúc theo tiếp cận TQM</b> dựa vào chu trình PDCA.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_4_1" id="d5_g3_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_4_1" id="d5_g3_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g3_4_1" id="d5_g3_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g3_4_2" id="d5_g3_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_4_2" id="d5_g3_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g3_4_2" id="d5_g3_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>GIẢI PHÁP 4: Quy trình tự đánh giá và cải tiến liên tục ĐBCL CTĐT đại học ngành Kiến trúc theo tiếp cận TQM
                                        </b>
                                        </br>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td><b>Bước 1. Lập kế hoạch</b> tự đánh giá và cải tiến liên tục ĐBCL CTĐT đại học ngành Kiến trúc theo tiếp cận TQM.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_1_1" id="d5_g4_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_1_1" id="d5_g4_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g4_1_1" id="d5_g4_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g4_1_2" id="d5_g4_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_1_2" id="d5_g4_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_1_2" id="d5_g4_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td><b>Bước 2. Chỉ đạo, tổ chức thực hiện</b> tự đánh giá và cải tiến liên tục ĐBCL CTĐT đại học ngành Kiến trúc theo tiếp cận TQM.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_2_1" id="d5_g4_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_2_1" id="d5_g4_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g4_2_1" id="d5_g4_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g4_2_2" id="d5_g4_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_2_2" id="d5_g4_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_2_2" id="d5_g4_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td><b>Bước 3. Kiểm tra đánh giá kết quả</b> và <b>phản hồi thông tin để cải tiến liên tục</b> ĐBCL CTĐT đại học ngành Kiến trúc theo tiếp cận TQM.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_3_1" id="d5_g4_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_3_1" id="d5_g4_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g4_3_1" id="d5_g4_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g4_3_2" id="d5_g4_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_3_2" id="d5_g4_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_3_2" id="d5_g4_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td><b>Bước 4 - Hoàn thiện báo cáo tự đánh giá cuối cùng</b> và <b>phản hồi chính thức thông tin đánh giá</b>
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_4_1" id="d5_g4_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_4_1" id="d5_g4_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g4_4_1" id="d5_g4_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g4_4_2" id="d5_g4_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_4_2" id="d5_g4_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g4_4_2" id="d5_g4_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>GIẢI PHÁP 5: Phát triển hệ thống giao tiếp thông tin 02 chiều phục vụ cho quản lý CTĐT đại học ngành Kiến trúc theo tiếp cận TQM đảm bảo các nội dung sau:
                                        </b>
                                        </br>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td><b>- Tạo điều kiện thuận lợi cho giao tiếp hiệu quả theo <u>các đặc trưng chính</u>: Giao tiếp cởi mở và trung thực</b> để đảm bảo chấp nhận suy nghĩ và tình cảm của người khác, đồng thời phải chịu trách nhiệm với chính mình; <i>Giao tiếp đồng cảm</i> để có thể trải nghiệm quan điểm của người khác một cách công bằng mà không chỉ trích; <i>Giao tiếp thông cảm</i> để có thể luôn giao tiếp với thái độ thân thiện, không đe dọa hay chỉ trích; <i>Giao tiếp công bằng</i> để tạo điều kiện thuận lợi cho tất cả mọi người tham dự vào quá trình giao tiếp đều thấy có giá trị và đều được lắng nghe...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_1_1" id="d5_g5_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_1_1" id="d5_g5_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g5_1_1" id="d5_g5_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g5_1_2" id="d5_g5_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_1_2" id="d5_g5_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_1_2" id="d5_g5_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td><b>- Thiết lập quan hệ tin tưởng lẫn nhau</b> dựa trên: Tôn trọng và bảo vệ riêng tư của cá nhân; Luôn sẵn sàng lắng nghe và thực hiện lời hứa; Cư xử tôn trọng...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_2_1" id="d5_g5_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_2_1" id="d5_g5_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g5_2_1" id="d5_g5_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g5_2_2" id="d5_g5_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_2_2" id="d5_g5_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_2_2" id="d5_g5_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td><b>- Đảm bảo nhất trí về mục tiêu</b> của các bên liên quan theo triết lý cùng thắng lợi “Win-Win...” hay tất cả các bên tham gia cùng có lợi.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_3_1" id="d5_g5_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_3_1" id="d5_g5_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g5_3_1" id="d5_g5_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g5_3_2" id="d5_g5_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_3_2" id="d5_g5_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_3_2" id="d5_g5_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td><b>- Thiết lập các kênh giao tiếp thông tin hai chiều đa dạng</b> đảm bảo hệ thống giao tiếp không chỉ là mở, trung thực và 02 chiều, mà còn sử dụng được nhiều cách và phương tiện giao tiếp khác (thông báo, hội họp, các bản tin, điện thoại, thư điện tử, internet...) để tạo điều kiện thuận lợi cho các bên liên quan đều có đóng góp giá trị cho việc ra quyết định có ảnh hưởng tới việc thiết kế và vận hành hệ thống QLCL/ĐBCL đại học ngành Kiến trúc theo tiếp cận TQM... 
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_4_1" id="d5_g5_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_4_1" id="d5_g5_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g5_4_1" id="d5_g5_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g5_4_2" id="d5_g5_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_4_2" id="d5_g5_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_4_2" id="d5_g5_4_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>5
                                    </td>
                                    <td>- Để thiết lập và vận hành thành công hệ thống giao tiếp thông tin 02 chiều cần <b>đảm bảo các điều kiện</b> sau: Đảm bảo sự <i>cam kết</i> của lãnh đạo, quản lý các cấp của khoa/nhà trường, cũng như các bên liên quan trong việc thiết lập và vận hành hệ thống giao tiếp thông tin 02 chiều; Các thành viên của khoa/nhà trường và các bên liên quan được trang bị các kỹ năng giao tiếp...
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_5_1" id="d5_g5_5_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_5_1" id="d5_g5_5_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g5_5_1" id="d5_g5_5_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g5_5_2" id="d5_g5_5_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_5_2" id="d5_g5_5_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g5_5_2" id="d5_g5_5_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <b>GIẢI PHÁP 6: Tổ chức nâng cao năng lực ĐBCL CTĐT đại học ngành kiến trúc theo tiếp  cận TQM
                                        </b>
                                        </br>
                                    </td>
                                </tr>
                                <tr>
                                    <td>1
                                    </td>
                                    <td><b>Bước 1. Tổ chức phát triển khung năng lực</b> QLCL/ĐBCL CTĐT đại học ngành kiến trúc theo tiếp cận TQM của <i>cán bộ lãnh đạo, quản lý, giảng viên, nhân viên</i> và <i>các bên liên quan</i> của khoa/nhà trường.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_1_1" id="d5_g6_1_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_1_1" id="d5_g6_1_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g6_1_1" id="d5_g6_1_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g6_1_2" id="d5_g6_1_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_1_2" id="d5_g6_1_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_1_2" id="d5_g6_1_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>2
                                    </td>
                                    <td><b>Bước 2. Tổ chức đánh giá nhu cầu cần đào tạo, bồi dưỡng</b> về QLCL/ĐBCL CTĐT đại học ngành kiến trúc theo tiếp cận TQM của cán bộ lãnh đạo, quản lý, giảng viên, nhân viên và các bên liên quan của khoa/nhà trường dựa các khung năng lực trên.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_2_1" id="d5_g6_2_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_2_1" id="d5_g6_2_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g6_2_1" id="d5_g6_2_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g6_2_2" id="d5_g6_2_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_2_2" id="d5_g6_2_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_2_2" id="d5_g6_2_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>3
                                    </td>
                                    <td><b>Bước 3. Tổ chức bồi dưỡng</b> về QLCL/ĐBCL CTĐT đại học ngành kiến trúc theo tiếp cận TQM cho đội ngũ cán bộ lãnh đạo, quản lý, giảng viên, nhân viên và các bên liên quan của khoa/nhà trường dựa vào khung năng lực.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_3_1" id="d5_g6_3_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_3_1" id="d5_g6_3_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g6_3_1" id="d5_g6_3_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g6_3_2" id="d5_g6_3_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_3_2" id="d5_g6_3_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_3_2" id="d5_g6_3_2_3">
                                    </td>
                                </tr>
                                <tr>
                                    <td>4
                                    </td>
                                    <td><b>Bước 4 - Tổ chức đánh giá và cấp chứng chỉ</b>.
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_4_1" id="d5_g6_4_1_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_4_1" id="d5_g6_4_1_2">
                                    </td>
                                    <td style="text-align: center; border-right-width: 5px;">
                                        <input type="radio" name="d5_g6_4_1" id="d5_g6_4_1_3">
                                    </td>
                                    <td style="text-align: center; border-left-width: 5px;">
                                        <input type="radio" name="d5_g6_4_2" id="d5_g6_4_2_1">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_4_2" id="d5_g6_4_2_2">
                                    </td>
                                    <td style="text-align: center;">
                                        <input type="radio" name="d5_g6_4_2" id="d5_g6_4_2_3">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="text-align: center;">
                        <i>Xin trân trọng cảm ơn!</i>
                    </div>
                    <div style="text-align: center; padding-top: 10px;">
                        <asp:Button runat="server" ID="btnNopBai" Text="Hoàn thành" OnClientClick=" return checkCollectAnswares();" OnClick="btnNopBai_Click" />
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
            <div id="divScript" runat="server"></div>
            <script type="text/javascript">
                function validateEmail(email) {
                    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                    return re.test(email);
                };
                $(document).ready(function () {
                    $('[data-toggle="tooltip"]').tooltip();
                    // Xu ly gia tri mac dinh
                    var radios = $("#divContentCauHoi").find("input[type=radio]");
                    for (i = 0; i < radios.length; i++) {
                        var id = radios[i].id;
                        //alert(name);
                        if (id.substring(id.length - 1, id.length) == '3') {
                            //var id = radios[i].id.replace('id_', '');
                            $("#" + id).prop("checked", true);
                        }
                    };
                    // Xu ly gia tri mac dinh
                    radios = $("#divContentCauHoi4").find("input[type=radio]");
                    for (i = 0; i < radios.length; i++) {
                        var id = radios[i].id;
                        //alert(name);
                        if (id.substring(id.length - 1, id.length) == '3') {
                            //var id = radios[i].id.replace('id_', '');
                            $("#" + id).prop("checked", true);
                        }
                    };
                    // Xu ly gia tri mac dinh
                    radios = $("#divContentCauHoi5").find("input[type=radio]");
                    for (i = 0; i < radios.length; i++) {
                        var id = radios[i].id;
                        //alert(name);
                        if (id.substring(id.length - 1, id.length) == '3') {
                            //var id = radios[i].id.replace('id_', '');
                            $("#" + id).prop("checked", true);
                        }
                    };

                });
                window.onpageshow = function (event) {
                    if (event.persisted) {
                        //alert("From bfcache");
                    }
                };
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
                var m_strAnwares = '';
                var countSoCauHoi = 0;
                var checkKhongCoViec = 0;
                function checkCollectAnswares() {
                   <%-- if (validateEmail($("#<%=txtEmail.ClientID%>").val())) {--%>
                    collectAnswares();
                    //115+42x2+161x2
                    //if (countSoCauHoi < (115 + 42 * 2 + 161 * 2)) {
                    if (countSoCauHoi < 5) {
                        alert("Đề nghị bạn trả lời đúng câu hỏi");
                        return false;
                    }
                    else
                        return true;
                    //}
                    //else {
                    //    alert("Đề nghị bạn nhập đúng email");
                    //    return false;
                    //}
                }
                function collectAnswares() {
                    m_strAnwares = '';
                    countSoCauHoi = 0;
                    var radios = $("#divContentCauHoi").find("input:checked");
                    for (i = 0; i < radios.length; i++) {
                        var name = radios[i].name;
                        //alert(name);
                        if (name.indexOf("d") >= 0) {
                            //var id = radios[i].id.replace('id_', '');
                            var id = radios[i].id;
                            //id_{0}_{1}
                            countSoCauHoi++;
                            m_strAnwares = m_strAnwares + id + ";";
                        }
                    }
                    radios = $("#divContentCauHoi4").find("input:checked");
                    for (i = 0; i < radios.length; i++) {
                        var name = radios[i].name;
                        //alert(name);
                        if (name.indexOf("d") >= 0) {
                            //var id = radios[i].id.replace('id_', '');
                            var id = radios[i].id;
                            //id_{0}_{1}
                            countSoCauHoi++;
                            m_strAnwares = m_strAnwares + id + ";";
                        }
                    }
                    radios = $("#divContentCauHoi5").find("input:checked");
                    for (i = 0; i < radios.length; i++) {
                        var name = radios[i].name;
                        //alert(name);
                        if (name.indexOf("d") >= 0) {
                            //var id = radios[i].id.replace('id_', '');
                            var id = radios[i].id;
                            //id_{0}_{1}
                            countSoCauHoi++;
                            m_strAnwares = m_strAnwares + id + ";";
                        }
                    }
                    m_strAnwares = m_strAnwares + "#####$$$$$@@@@@"
                    $('textarea').each(function () {

                        if (this.id.indexOf("d") >= 0) {
                            var value = $(this).val();
                            //var id = this.id.replace('txtCauHoi_', '');
                            var id = this.id;
                            m_strAnwares = m_strAnwares + id + "!!!$$$" + value + "$#@$#@";
                        }
                        // get the value

                        // check the value with the regular expression here.
                        // send alert if failed etc...

                    });
                    $("#<%=txtAnswares.ClientID%>").val(m_strAnwares);

                    //alert(m_strAnwares);
                    return true;
                };
            </script>
    </form>
</body>
</html>
