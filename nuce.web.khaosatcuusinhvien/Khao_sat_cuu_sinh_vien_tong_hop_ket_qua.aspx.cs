using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace nuce.web.khaosatcuusinhvien
{
    public partial class Khao_sat_cuu_sinh_vien_tong_hop_ket_qua : Page
    {
        public Dictionary<int, string> m_TinhThanhs;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region TinhThanh
            m_TinhThanhs = new Dictionary<int, string>();
            m_TinhThanhs.Add(1, "Hà Nội");
            m_TinhThanhs.Add(2, "TP HCM");
            m_TinhThanhs.Add(3, "Hải Phòng");
            m_TinhThanhs.Add(4, "Đà Nẵng");
            m_TinhThanhs.Add(5, "Cần Thơ");
            m_TinhThanhs.Add(6, "An Giang");
            m_TinhThanhs.Add(7, "Bà Rịa - Vũng Tàu");
            m_TinhThanhs.Add(8, "Bắc Giang");
            m_TinhThanhs.Add(9, "Bắc Kạn");
            m_TinhThanhs.Add(10, "Bạc Liêu");
            m_TinhThanhs.Add(11, "Bắc Ninh");
            m_TinhThanhs.Add(12, "Bến Tre");
            m_TinhThanhs.Add(13, "Bình Định");
            m_TinhThanhs.Add(14, "Bình Dương");
            m_TinhThanhs.Add(15, "Bình Phước");
            m_TinhThanhs.Add(16, "Bình Thuận");
            m_TinhThanhs.Add(17, "Cà Mau");
            m_TinhThanhs.Add(18, "Cao Bằng");
            m_TinhThanhs.Add(19, "Đắk Lắk");
            m_TinhThanhs.Add(20, "Đắk Nông");
            m_TinhThanhs.Add(21, "Điện Biên");
            m_TinhThanhs.Add(22, "Đồng Nai");
            m_TinhThanhs.Add(23, "Đồng Tháp");
            m_TinhThanhs.Add(24, "Gia Lai");
            m_TinhThanhs.Add(25, "Hà Giang");
            m_TinhThanhs.Add(26, "Hà Nam");
            m_TinhThanhs.Add(27, "Hà Tĩnh");
            m_TinhThanhs.Add(28, "Hải Dương");
            m_TinhThanhs.Add(29, "Hậu Giang");
            m_TinhThanhs.Add(30, "Hòa Bình");
            m_TinhThanhs.Add(31, "Hưng Yên");
            m_TinhThanhs.Add(32, "Khánh Hòa");
            m_TinhThanhs.Add(33, "Kiên Giang");
            m_TinhThanhs.Add(34, "Kon Tum");
            m_TinhThanhs.Add(35, "Lai Châu");
            m_TinhThanhs.Add(36, "Lâm Đồng");
            m_TinhThanhs.Add(37, "Lạng Sơn");
            m_TinhThanhs.Add(38, "Lào Cai");
            m_TinhThanhs.Add(39, "Long An");
            m_TinhThanhs.Add(40, "Nam Định");
            m_TinhThanhs.Add(41, "Nghệ An");
            m_TinhThanhs.Add(42, "Ninh Bình");
            m_TinhThanhs.Add(43, "Ninh Thuận");
            m_TinhThanhs.Add(44, "Phú Thọ");
            m_TinhThanhs.Add(45, "Quảng Bình");
            m_TinhThanhs.Add(46, "Quảng Nam");
            m_TinhThanhs.Add(47, "Quảng Ngãi");
            m_TinhThanhs.Add(48, "Quảng Ninh");
            m_TinhThanhs.Add(49, "Quảng Trị");
            m_TinhThanhs.Add(50, "Sóc Trăng");
            m_TinhThanhs.Add(51, "Sơn La");
            m_TinhThanhs.Add(52, "Tây Ninh");
            m_TinhThanhs.Add(53, "Thái Bình");
            m_TinhThanhs.Add(54, "Thái Nguyên");
            m_TinhThanhs.Add(55, "Thanh Hóa");
            m_TinhThanhs.Add(56, "Thừa Thiên Huế");
            m_TinhThanhs.Add(57, "Tiền Giang");
            m_TinhThanhs.Add(58, "Trà Vinh");
            m_TinhThanhs.Add(59, "Tuyên Quang");
            m_TinhThanhs.Add(60, "Vĩnh Long");
            m_TinhThanhs.Add(61, "Vĩnh Phúc");
            m_TinhThanhs.Add(62, "Yên Bái");
            m_TinhThanhs.Add(63, "Phú Yên");
            #endregion
            //int value = int.Parse(Request.QueryString["v"].ToString());
            //data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.SinhVien_THANGHN_insert1(value, "Cap_nhat_tu_dong");

            //divContent.InnerHtml = value.ToString();
            // Lấy giá trị của tất cả các sinh viên
            DataTable dt = data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.getByStatus(3, 1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int SinhVienRaTruong_BaiKhaoSat_SinhVienID = int.Parse(dt.Rows[i]["SinhVienRaTruong_BaiKhaoSat_SinhVienID"].ToString());
                int SinhVienRaTruong_BaiKhaoSatID = int.Parse(dt.Rows[i]["SinhVienRaTruong_BaiKhaoSatID"].ToString());
                int SinhVienID = int.Parse(dt.Rows[i]["SinhVienID"].ToString());
                string NoiDungDeThi = dt.Rows[i]["NoiDungDeThi"].ToString();
                string strAnswares = dt.Rows[i]["BaiLam"].ToString();
                List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(NoiDungDeThi);
                List<model.DapAn> lsDapAns = new List<model.DapAn>();
                List<model.DapAn> lsDapAnsText = new List<model.DapAn>();
                string strRate = "";
                int iTinhThanhID = 1;
                string strTinhThanh = "";
                string[] strAnswaresSplit = strAnswares.Split(new string[] { "#####$$$$$@@@@@" }, StringSplitOptions.RemoveEmptyEntries);
                if (strAnswaresSplit.Length >= 4)
                {
                    lsDapAns = Utils.convertListDapAnFromAnswares(strAnswaresSplit[0]);
                    lsDapAnsText = Utils.convertListDapAnFromAnswaresText(strAnswaresSplit[1]);
                    strRate = strAnswaresSplit[2];
                    iTinhThanhID = int.Parse(strAnswaresSplit[3].Trim());
                    strTinhThanh = m_TinhThanhs[iTinhThanhID];
                }
                //data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID,SinhVienRaTruong_BaiKhaoSatID,SinhVienID,)
                string strMatch = "";
                if (lsDapAns != null)
                {
                    //string strMatch = dapAn != null ? dapAn.Match : "";
                    foreach (model.DapAn dapAnTemp in lsDapAns)
                        strMatch += ";" + dapAnTemp.Match + ";";
                }
                // Chi so cau hoi
                int l = 0;
                int l1 = 0;
                string strType;
                int iSoCauTraLoi = -1;
                string strIDMC = "";
                foreach (model.CauHoi cauhoi in lsCauHois)
                {
                    l++;
                    strType = cauhoi.Type;
                    switch (strType)
                    {
                        #region cau hoi lua chon
                        case "SC":
                        case "MC":
                        case "TQ":
                        case "FQ":
                            iSoCauTraLoi = cauhoi.SoCauTraLoi;
                            l1 = 1;
                            while (l1 < (iSoCauTraLoi + 1))
                            {
                                strIDMC = "";
                                switch (l1)
                                {
                                    case 1:
                                        if (strMatch.Contains(string.Format(";{0};", cauhoi.M1)))
                                        {
                                            // Cap nhat cau hoi duoc tra loi
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M1), 1, "");
                                        }
                                        else
                                        {
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M1), 0, "");
                                        }
                                        break;
                                    case 2:
                                        if (strMatch.Contains(string.Format(";{0};", cauhoi.M2)))
                                        {
                                            // Cap nhat cau hoi duoc tra loi
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M2), 1, "");
                                        }
                                        else
                                        {
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M2), 0, "");
                                        }
                                        break;
                                    case 3:
                                        if (strMatch.Contains(string.Format(";{0};", cauhoi.M3)))
                                        {
                                            // Cap nhat cau hoi duoc tra loi
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M3), 1, "");
                                        }
                                        else
                                        {
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M3), 0, "");
                                        }
                                        break;
                                    case 4:
                                        if (strMatch.Contains(string.Format(";{0};", cauhoi.M4)))
                                        {
                                            // Cap nhat cau hoi duoc tra loi
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M4), 1, "");
                                        }
                                        else
                                        {
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M4), 0, "");
                                        }
                                        break;
                                }
                                l1++;
                            }
                            break;
                        #endregion
                        #region cau hoi text
                        case "SA":
                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, -1, 0, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                            if (cauhoi.CauHoiID.Equals(3269))
                            {
                                // Xu ly insert cac noi dung cau hoi duoc check
                                if (strMatch.Contains(string.Format(";{0};", "1111111111")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 11111111, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 11111111, 0, "");
                                }
                                if (strMatch.Contains(string.Format(";{0};", "2222222222")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 22222222, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 22222222, 0, "");
                                }
                                if (strMatch.Contains(string.Format(";{0};", "3333333333")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 33333333, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 33333333, 0, "");
                                }
                                if (strMatch.Contains(string.Format(";{0};", "4444444444")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 44444444, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 44444444, 0, "");
                                }
                                if (strMatch.Contains(string.Format(";{0};", "5555555555")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 55555555, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 55555555, 0, "");
                                }
                                if (strMatch.Contains(string.Format(";{0};", "6666666666")))
                                {
                                    // Cap nhat cau hoi duoc tra loi
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 666666666, 1, "");
                                }
                                else
                                {
                                    data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, 666666666, 0, "");
                                }
                            }
                            break;
                        #endregion
                        #region cau hoi cam xuc
                        case "EQ":
                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, -1, 0, strRate);
                            break;
                        #endregion
                        #region Cau hoi mo rong EX
                        case "EX":
                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, -1, 0, strTinhThanh);
                            break;
                        #endregion
                        default: break;
                    }
                }
                // Cap nhat dat xu ly
                data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.update_Type(SinhVienRaTruong_BaiKhaoSat_SinhVienID, 2);
                divContent.InnerText = "Thanh cong";
            }
        }
    }
}