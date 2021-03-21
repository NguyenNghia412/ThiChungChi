<%@ Page Title="Hồ sơ sinh viên" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HoSoSinhVien.aspx.cs" Inherits="Nuce.CTSV.HoSoSinhVien" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <!-- Page Heading -->
        <h1 class="h1 mb-2 text-gray-800 text-center mb-3">Thông tin sinh viên</h1>

        <nav>
            <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                <a class="nav-item nav-link active" id="nav-personal-tab" data-toggle="tab" href="#nav-personal" role="tab" aria-controls="nav-personal" aria-selected="true">Thông tin cá nhân</a>
                <a class="nav-item nav-link " id="nav-family-tab" data-toggle="tab" href="#nav-family" role="tab" aria-controls="nav-family" aria-selected="false">Thông tin gia đình</a>
            </div>
        </nav>


        <div class="tab-content" id="nav-tabContent">
            <div class="tab-pane fade show active" id="nav-personal" role="tabpanel" aria-labelledby="nav-personal-tab">
                <div class="card shadow mb-4">
                    <h3 class="d-flex justify-content-center mt-2 font-weight-bold">Thông tin cá nhân</h3>
                    <div class="d-flex">
                        <div class="container">
                            <div class="row">
                                <div class="col-12 col-sm-4 mt-2">
                                    <div>
                                        <img class="img-rounded" runat="server" id="imgAnh" height="180" style="width: 50%; display: flex; margin: auto; padding-bottom: 15px;">
                                    </div>
                                </div>
                                <div class="col-12 col-sm-8 d-flex justify-content-center" style="flex-direction: column;">
                                    <div>
                                        <h2 id="hovaten" runat="server">Phạm Văn Ninh</h2>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-12 col-sm-6">
                                    <table style="line-height: 2rem; margin-left: 2%;">
                                        <tr>
                                            <td class="font-weight-bold">Tài khoản:</td>
                                            <td runat="server" id="masosv">125960</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Năm sinh:</td>
                                            <td runat="server" id="namsinh">22-06-1995</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Nơi sinh:</td>
                                            <td runat="server" id="noisinh">Xã Hoằng Vinh-Huyện Hoằng Hóa-Tỉnh Thanh Hóa</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Dân tộc:</td>
                                            <td runat="server" id="dantoc">Kinh</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Tôn giáo:</td>
                                            <td runat="server" id="tongiao">Không</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Hộ khẩu thường trú:</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Số nhà:</td>
                                            <td id="hktt_sonha" runat="server">12</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Phố/Thôn:</td>
                                            <td id="hktt_phothon" runat="server">Vọng</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Phường/Xã:</td>
                                            <td runat="server" id="hktt_phuongxa">Đồng Tâm</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Quận/Huyện:</td>
                                            <td runat="server" id="hktt_quanhuyen">Hai Bà Trưng</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Thành phố/Tỉnh:</td>
                                            <td runat="server" id="hktt_thanhpho">Hà Nội</td>
                                        </tr>


                                    </table>
                                </div>
                                <div class="col-12 col-sm-6">
                                    <table style="line-height: 2rem; margin-left: 2%;">
                                        <tr>
                                            <td class="font-weight-bold">Số CMT:</td>
                                            <td runat="server" id="socmt">123456789012</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Ngày cấp:</td>
                                            <td runat="server" id="cmtngaycap">22-07-2016</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Nơi cấp:</td>
                                            <td runat="server" id="cmtnoicap">Cục quản lý cư dân quốc gia</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Ngày vào Đoàn:</td>
                                            <td runat="server" id="ngayvaodoan">22-07-2018</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Ngày vào Đảng:</td>
                                            <td runat="server" id="ngayvaodang">22-07-2019</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Tốt nghiệp THPT (BTVH) năm:</td>
                                            <td runat="server" id="namtotnghiepthpt">2013</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Điểm thi PTTH Quốc gia:</td>
                                            <td runat="server" id="diemthithptqg">20</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Hộ khẩu thường trú thuộc khu vực:</td>
                                            <td runat="server" id="hktttkv">2NT</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Đối tượng ưu tiên:</td>
                                            <td runat="server" id="dtut">Không</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Mobile:</td>
                                            <td runat="server" id="mobile">0912987567</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Email:</td>
                                            <td runat="server" id="email">namthangbk@gmail.com</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>


                    </div>
                    <hr style="width: 95%; margin-left: 2.5%" />
                    <div style="width: 100%">
                        <p style="margin-left: 2%" class="font-weight-bold">Quá trình học tập <span style="font-style: italic;">(Ghi rõ thời gian/ trường học PTTH)</span></p>
                        <div class="card-body">
                            <div class="table-responsive">
                                <table
                                    class="table table-bordered"
                                    width="100%"
                                    cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th class="font-weight-bold">Thời gian</th>
                                            <th class="font-weight-bold">Trường</th>
                                        </tr>
                                    </thead>
                                    <tbody runat="server" id="tbQTHT">
                                        <tr>
                                            <td>Tháng 01-2014 đến tháng 03-2016</td>
                                            <td>Giao thủy</td>
                                        </tr>
                                        <tr>
                                            <td>Thấng 04-2016 đến tháng 10/2020</td>
                                            <td>Thành phố Nam Định</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; margin-top: -2rem;">
                        <div class="card-body">
                            <div class="table-responsive">
                                <table
                                    class="table table-bordered"
                                    width="100%"
                                    cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th class="font-weight-bold">Tên hoạt động</th>
                                            <th class="font-weight-bold">Tham gia (Có / Không)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Đã từng làm cán bộ lớp</td>
                                            <td runat="server" id="datunglamcanbolop">Có</td>
                                        </tr>
                                        <tr>
                                            <td>Đã từng làm cán bộ đoàn</td>
                                            <td runat="server" id="datunglamcanbodoan">Có</td>
                                        </tr>
                                        <tr>
                                            <td>Đã tham gia đội tuyển thi HSG</td>
                                            <td runat="server" id="dathamgiadoituyenthihsg">Có</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div style="width: 100%; margin-top: -2rem;">
                        <div class="card-body">
                            <div class="table-responsive">
                                <table
                                    class="table table-bordered"
                                    width="100%"
                                    cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th class="font-weight-bold">Cấp thi</th>
                                            <th class="font-weight-bold">Môn thi</th>
                                            <th class="font-weight-bold">Đạt giải</th>
                                        </tr>
                                    </thead>
                                    <tbody runat="server" id="tbthihsg">
                                        <tr>
                                            <td>Cấp 1</td>
                                            <td>Toán</td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- break here -->
            <div class="tab-pane fade show" id="nav-family" role="tabpanel" aria-labelledby="nav-family-tab">
                <div class="card shadow mb-4">
                    <h3 class="d-flex justify-content-center mt-2 font-weight-bold">Thông tin gia đình</h3>
                    <div class="d-flex" style="width: 100%">
                        <div class="container">
                            <div class="row">
                                <div class="col-12 col-sm-6">
                                    <table style="line-height: 2rem; margin-left: 2%;">
                                        <tbody id="tbttgd" runat="server"></tbody>
                                    </table>
                                </div>
                                <div class="col-12 col-sm-6">
                                    <table style="line-height: 2rem; margin-left: 2%;">
                                        <tr>
                                            <td colspan="2" class="font-weight-bold" style="font-style: italic;">Địa chỉ báo tin cho Bố, Mẹ hoặc Người nuôi dưỡng khi cần:</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Họ tên người nhận:</td>
                                            <td runat="server" id="baotinhovaten">Nguyễn Văn A</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Địa chỉ người nhận:</td>
                                            <td runat="server" id="baotindiachinguoinhan"></td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Số điện thoại người nhận:	</td>
                                            <td runat="server" id="baotinsodienthoainguoinhan"></td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Có ở nội trú không:</td>
                                            <td runat="server" id="coonoitrukhong">Có</td>
                                        </tr>
                                        <tr>
                                            <td class="font-weight-bold">Địa chỉ nơi ở cụ thể:</td>
                                            <td runat="server" id="diachicuthe">Phòng 101</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>




                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- End of Main Content -->


</asp:Content>
