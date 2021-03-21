using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace nuce.web.khaosatcuusinhvien
{
    public partial class Khao_sat_sinh_vien_sap_ra_truong_tong_hop_ket_qua : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int value = int.Parse(Request.QueryString["v"].ToString());
            //data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.SinhVien_THANGHN_insert1(value, "Cap_nhat_tu_dong");
            string strContent = "";
            //divContent.InnerHtml = value.ToString();
            // Lấy giá trị của tất cả các sinh viên
            DataTable dt = data.dnn_Nuce_KS_SinhVienSapRaTruong_BaiKhaoSat_SinhVien1.getByStatus(4,1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int SinhVienRaTruong_BaiKhaoSat_SinhVienID = int.Parse(dt.Rows[i]["SinhVienSapRaTruong_BaiKhaoSat_SinhVienID"].ToString());
                int SinhVienRaTruong_BaiKhaoSatID = int.Parse(dt.Rows[i]["SinhVienSapRaTruong_BaiKhaoSatID"].ToString());
                int SinhVienID = int.Parse(dt.Rows[i]["SinhVienID"].ToString());
                string NoiDungDeThi = dt.Rows[i]["NoiDungDeThi"].ToString();
                string strAnswares = dt.Rows[i]["BaiLam"].ToString();
                List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(NoiDungDeThi);
                List<model.DapAn> lsDapAns = new List<model.DapAn>();
                List<model.DapAn> lsDapAnsText = new List<model.DapAn>();
                string strRate = "";
                string[] strAnswaresSplit = strAnswares.Split(new string[] { "#####$$$$$@@@@@" }, StringSplitOptions.RemoveEmptyEntries);
                if (strAnswaresSplit.Length >= 3)
                {
                    lsDapAns = Utils.convertListDapAnFromAnswares(strAnswaresSplit[0]);
                    lsDapAnsText = Utils.convertListDapAnFromAnswaresText(strAnswaresSplit[1]);
                    strRate = strAnswaresSplit[2];
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
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType,cauhoi.CauHoiID, int.Parse(cauhoi.M1), 1, "");
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
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID,int.Parse(cauhoi.M2), 0, "");
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
                                    case 5:
                                        if (strMatch.Contains(string.Format(";{0};", cauhoi.M5)))
                                        {
                                            // Cap nhat cau hoi duoc tra loi
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M5), 1, "");
                                        }
                                        else
                                        {
                                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, int.Parse(cauhoi.M5), 0, "");
                                        }
                                        break;
                                }
                                l1++;
                            }
                            break;
                        #endregion
                        #region cau hoi text
                        case "SA":
                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, - 1, 0, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                            break;
                        #endregion
                        #region cau hoi cam xuc
                        case "EQ":
                            data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVienRaTruong_BaiKhaoSat_SinhVienID, SinhVienRaTruong_BaiKhaoSatID, SinhVienID, strType, cauhoi.CauHoiID, - 1, 0, strRate);
                            break;
                        #endregion
                        default: break;
                    }
                }
                // Cap nhat dat xu ly
                data.dnn_Nuce_KS_SinhVienSapRaTruong_BaiKhaoSat_SinhVien1.update_Type(SinhVienRaTruong_BaiKhaoSat_SinhVienID, 2);
                strContent = strContent + string.Format("<div>{0} - {1}</div>",i, SinhVienID.ToString());

            }
            divContent.InnerHtml = strContent;
        }
    }
}