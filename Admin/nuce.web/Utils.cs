using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace nuce.web
{
    public static class Utils
    {
        public static int tabCheckCommon = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TABCOMMON"]);
        public static int moduleCheckCommon = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["MODCOMMON"]);

        public static int tabCheckQlpm = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TABQLPM"]);
        public static int moduleCheckQlpm = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["MODQLPM"]);

        #region Syn phong Dao Tao
        /*
        1. Dong bo lich hoc
        2. Dong bo lich thi
        3. Lich hoc dong bo bi thay doi
        4. Lich thi dong bo bi thay doi
        5. Lich hoc dang ki
        6. Lich thi dang ki
        */
        public static int synTypeLichHoc = 1;
        public static int synTypeLichThi = 2;
        public static int synTypeLichHocThayDoi = 3;
        public static int synTypeLichThiThayDoi = 4;
        public static int synTypeLichHocTuDangKi = 5;
        public static int synTypeLichThiTuDangKi = 6;
        public static int synTypeGVLichHocTuDangKi = 7;
        public static int synTypeGVLichThiTuDangKi = 8;
        #endregion
        #region khaosat
        public static string session_cuusinhvien = "session_cuusinhvien";
        public static string session_kithi_lophoc_cuusinhvien = "session_kithi_lop_hoc_cuusinhvien";
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        #endregion
        public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }
        public static string getNgayFromDate(DateTime dtInput)
        {
            string[] thu = new string[] { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
            DateTime d = new DateTime(2010, 11, 22);
            int i = (int)dtInput.DayOfWeek;
            return thu[i];
        }
        public static string code_diem_danh = "DIEM_DANH";
        public static string session_sinhvien = "session_sinhvien";
        public static string session_kithi_lophoc_sinhvien = "session_kithi_lop_hoc_sinhvien";
        public static string session_ca_lophoc_sinhvien = "session_ca_lop_hoc_sinhvien";
        public static int tab_login_sinhvien = 120;
        public static int tab_changepassword_sinhvien = 121;
        public static int tab_trangchu_sinhvien = 119;
        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
        public static void thongKe()
        {
            DataTable dt = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.get();
            string strDapAn = "";
            string strAnswares = "";
            int iKiThiLopHocSinhVien = -1;
            List<model.DapAn> lsDapAns;
            List<model.DapAn> lsAnswares;
            List<int> lsDapAnIDs;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strDapAn = dt.Rows[i]["DapAn"].ToString();
                strAnswares = dt.Rows[i]["BaiLam"].ToString();
                try
                {
                    iKiThiLopHocSinhVien = int.Parse(dt.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                    lsAnswares = convertListDapAnFromAnswares(strAnswares, out lsDapAnIDs);
                    lsDapAns = JsonConvert.DeserializeObject<List<model.DapAn>>(strDapAn);

                    foreach (int iID in lsDapAnIDs)
                    {
                        model.DapAn DapAnTemp = lsDapAns.Find(x => x.CauHoiID.Equals(iID));
                        string strMatchTemp = DapAnTemp.Match;
                        List<model.DapAn> lsMatchs1 = new List<model.DapAn>();
                        string[] strSplitTemp = strMatchTemp.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in strSplitTemp)
                        {
                            model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = iID, Match = str };
                            lsMatchs1.Add(DapAnTemp1);
                        }
                        List<model.DapAn> lsMatchs2 = lsAnswares.FindAll(x => x.CauHoiID.Equals(iID));

                        lsMatchs1.Sort(delegate (model.DapAn x, model.DapAn y)
                        {
                            if (x.Match == null && y.Match == null) return 0;
                            else if (x.Match == null) return -1;
                            else if (y.Match == null) return 1;
                            else return x.Match.CompareTo(y.Match);
                        });

                        lsMatchs2.Sort(delegate (model.DapAn x, model.DapAn y)
                        {
                            if (x.Match == null && y.Match == null) return 0;
                            else if (x.Match == null) return -1;
                            else if (y.Match == null) return 1;
                            else return x.Match.CompareTo(y.Match);
                        });

                        if (lsMatchs1.SequenceEqual(lsMatchs2))
                        {
                            // Cap nhat vao bang thong ke
                            data.dnn_NuceThi_CauHoi_ThongKe.insert(iID, iKiThiLopHocSinhVien, true);
                        }
                        else
                        {
                            // Cap nhat vao bang thong ke
                            data.dnn_NuceThi_CauHoi_ThongKe.insert(iID, iKiThiLopHocSinhVien, false);
                        }
                    }
                }
                catch
                {

                }
            }

        }
        public static model.KiThiLopHocSinhVien chamBai(model.KiThiLopHocSinhVien KiThiLopHocSinhVien, string Answares)
        {
            float fTongDiem = 0;
            float fTongDiemToiDa = 0;
            List<model.DapAn> lsDapAns = JsonConvert.DeserializeObject<List<model.DapAn>>(KiThiLopHocSinhVien.DapAn);
            List<model.DapAn> lsAnswares;
            List<int> lsDapAnIDs;

            // Tinh tong diem toi da
            foreach (model.DapAn DapAnTemp in lsDapAns)
            {
                if (!DapAnTemp.Type.Equals("TL"))
                    fTongDiemToiDa += DapAnTemp.Mark;
            }
            lsAnswares = convertListDapAnFromAnswares(Answares, out lsDapAnIDs);
            /*
            // Xu ly chuoi Answare thanh list dap an
            string[] strAnswareSplits = Answares.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Answare in strAnswareSplits)
            {
                string[] strSplitTemp = Answare.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                int iIDTemp = -1;
                if (strSplitTemp.Length > 1 && int.TryParse(strSplitTemp[0].Trim(), out iIDTemp))
                {
                    model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = int.Parse(strSplitTemp[0].Trim()), Match = strSplitTemp[1].Trim() };
                    lsAnswares.Add(DapAnTemp1);
                    if (!lsDapAnIDs.Contains(iIDTemp))
                    {
                        lsDapAnIDs.Add(iIDTemp);
                    }
                }
            }*/
            // Xu ly cham diem
            foreach (int iID in lsDapAnIDs)
            {
                model.DapAn DapAnTemp = lsDapAns.Find(x => x.CauHoiID.Equals(iID));
                string strMatchTemp = DapAnTemp.Match;
                List<model.DapAn> lsMatchs1 = new List<model.DapAn>();
                string[] strSplitTemp = strMatchTemp.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string str in strSplitTemp)
                {
                    model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = iID, Match = str };
                    lsMatchs1.Add(DapAnTemp1);
                }
                List<model.DapAn> lsMatchs2 = lsAnswares.FindAll(x => x.CauHoiID.Equals(iID));

                lsMatchs1.Sort(delegate (model.DapAn x, model.DapAn y)
                {
                    if (x.Match == null && y.Match == null) return 0;
                    else if (x.Match == null) return -1;
                    else if (y.Match == null) return 1;
                    else return x.Match.CompareTo(y.Match);
                });

                lsMatchs2.Sort(delegate (model.DapAn x, model.DapAn y)
                {
                    if (x.Match == null && y.Match == null) return 0;
                    else if (x.Match == null) return -1;
                    else if (y.Match == null) return 1;
                    else return x.Match.CompareTo(y.Match);
                });

                if(lsMatchs1.Count>1)
                {
                    int test = lsMatchs2.Count;
                }
                if (lsMatchs1.SequenceEqual(lsMatchs2))
                    fTongDiem += DapAnTemp.Mark;
            }
            KiThiLopHocSinhVien.Diem = (fTongDiem / fTongDiemToiDa) * 10;
            KiThiLopHocSinhVien.Mota = string.Format("Bài thi được {0:N1} điểm trên tổng số {1:N1} (Quy ra được {2:N2} điểm trên thang điểm 10) ", fTongDiem, fTongDiemToiDa, KiThiLopHocSinhVien.Diem);
            //KiThiLopHocSinhVien.Mota = string.Format("<div style='text-align: center;font-weight: bold;font-size: 20px;color: red;padding-top: 20px;'>{0}</div>", KiThiLopHocSinhVien.Mota);

            DateTime dtNopBai = DateTime.Now;
            TimeSpan ts = dtNopBai.Subtract(KiThiLopHocSinhVien.NgayGioBatDau);
            int iTongThoiGianConLai = KiThiLopHocSinhVien.TongThoiGianConLai - (ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds);
            KiThiLopHocSinhVien.Status = 4;
            KiThiLopHocSinhVien.BaiLam = Answares;
            KiThiLopHocSinhVien.TongThoiGianConLai = iTongThoiGianConLai > 0 ? iTongThoiGianConLai : 0;
            return KiThiLopHocSinhVien;
        }

        public static List<model.DapAn> convertListDapAnFromAnswares(string Answares, out List<int> lsDapAnIDs)
        {
            lsDapAnIDs = new List<int>();
            List<model.DapAn> lsAnswares = new List<model.DapAn>();
            string[] strAnswareSplits = Answares.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Answare in strAnswareSplits)
            {
                string[] strSplitTemp = Answare.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                int iIDTemp = -1;
                if (strSplitTemp.Length > 1 && int.TryParse(strSplitTemp[0].Trim(), out iIDTemp))
                {
                    model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = int.Parse(strSplitTemp[0].Trim()), Match = strSplitTemp[1].Trim() };
                    lsAnswares.Add(DapAnTemp1);
                    if (!lsDapAnIDs.Contains(iIDTemp))
                    {
                        lsDapAnIDs.Add(iIDTemp);
                    }
                }
            }
            return lsAnswares;
        }
        public static List<model.DapAn> convertListDapAnFromAnswares(string Answares)
        {
            List<model.DapAn> lsAnswares = new List<model.DapAn>();
            try
            {

                string[] strAnswareSplits = Answares.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string Answare in strAnswareSplits)
                {
                    string[] strSplitTemp = Answare.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                    int iIDTemp = -1;
                    if (strSplitTemp.Length > 1 && int.TryParse(strSplitTemp[0].Trim(), out iIDTemp))
                    {
                        model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = int.Parse(strSplitTemp[0].Trim()), Match = strSplitTemp[1].Trim() };
                        lsAnswares.Add(DapAnTemp1);
                    }
                }

            }
            catch
            {

            }
            return lsAnswares;
        }
        public static List<model.DapAn> convertListDapAnFromAnswaresText(string Answares)
        {
            List<model.DapAn> lsAnswares = new List<model.DapAn>();
            try
            {
                string[] strAnswareSplits = Answares.Split(new string[] { "$#@$#@" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string Answare in strAnswareSplits)
                {
                    string[] strSplitTemp = Answare.Split(new string[] { "!!!$$$" }, StringSplitOptions.RemoveEmptyEntries);
                    int iIDTemp = -1;
                    if (strSplitTemp.Length > 1 && int.TryParse(strSplitTemp[0].Trim(), out iIDTemp))
                    {
                        model.DapAn DapAnTemp1 = new model.DapAn() { CauHoiID = int.Parse(strSplitTemp[0].Trim()), Match = strSplitTemp[1].Trim() };
                        lsAnswares.Add(DapAnTemp1);
                    }
                }

            }
            catch
            {

            }
            return lsAnswares;
        }
        public static string getValueTextFromDapAn(List<model.DapAn> lsDapAnsText, int idCauHoi)
        {
            try
            {
                foreach (model.DapAn dapAnTemp in lsDapAnsText)
                {
                    if (dapAnTemp.CauHoiID.Equals(idCauHoi))
                        return dapAnTemp.Match;
                }
            }
            catch
            {

            }
            return "";
        }

        public static String StripUnicodeCharactersFromString(string inputValue)
        {
            return Regex.Replace(inputValue, @"[^\u0000-\u007F]", String.Empty);
        }
        public static void chuyenThi(int KiThiID)
        {
            DataTable dtKiThiLopHoc = data.dnn_NuceThi_KiThi_LopHoc.getByKiThi1(KiThiID);
            DataTable dtKiThiLopHocSinhVien;
            model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
            int iStatus = -1;
            int iKiThi_LopHoc_SinhVienID = -1;
            if (dtKiThiLopHoc != null && dtKiThiLopHoc.Rows.Count > 0)
            {
                for (int j = 0; j < dtKiThiLopHoc.Rows.Count; j++)
                {
                    dtKiThiLopHocSinhVien = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.getByKiThi_LopHoc1(int.Parse(dtKiThiLopHoc.Rows[j]["KiThi_LopHocID"].ToString()));
                    if (dtKiThiLopHocSinhVien != null && dtKiThiLopHocSinhVien.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtKiThiLopHocSinhVien.Rows.Count; i++)
                        {
                            iStatus = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                            iKiThi_LopHoc_SinhVienID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                            if (iStatus.Equals(1))
                            {
                                data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(iKiThi_LopHoc_SinhVienID, 9, "", 0);
                            }
                        }
                    }
                }
            }
        }
        public static void ketThucKiThi(int KiThiID)
        {
            // Lấy 
            DataTable dtKiThiLopHoc = data.dnn_NuceThi_KiThi_LopHoc.getByKiThi1(KiThiID);
            DataTable dtKiThiLopHocSinhVien;
            model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
            int iStatus = -1;
            int iKiThi_LopHoc_SinhVienID = -1;
            if (dtKiThiLopHoc != null && dtKiThiLopHoc.Rows.Count > 0)
            {
                for (int j = 0; j < dtKiThiLopHoc.Rows.Count; j++)
                {
                    dtKiThiLopHocSinhVien = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.getByKiThi_LopHoc1(int.Parse(dtKiThiLopHoc.Rows[j]["KiThi_LopHocID"].ToString()));
                    if (dtKiThiLopHocSinhVien != null && dtKiThiLopHocSinhVien.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtKiThiLopHocSinhVien.Rows.Count; i++)
                        {
                            iStatus = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                            iKiThi_LopHoc_SinhVienID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                            if (iStatus.Equals(3) || iStatus.Equals(5) || iStatus.Equals(6))
                            {
                                KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
                                //KiThiLopHocSinhVien.BoDeID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["BoDeID"].ToString());
                                //KiThiLopHocSinhVien.DeThiID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["DeThiID"].ToString());
                                KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien = iKiThi_LopHoc_SinhVienID;
                                KiThiLopHocSinhVien.Status = iStatus;
                                //KiThiLopHocSinhVien.TenBlockHoc = dtKiThiLopHocSinhVien.Rows[i]["TenBlockHoc"].ToString();
                                //KiThiLopHocSinhVien.TenKiThi = dtKiThiLopHocSinhVien.Rows[i]["TenKiThi"].ToString();
                                //KiThiLopHocSinhVien.TenMonHoc = dtKiThiLopHocSinhVien.Rows[i]["TenMonHoc"].ToString();
                                KiThiLopHocSinhVien.NoiDungDeThi = dtKiThiLopHocSinhVien.Rows[i]["NoiDungDeThi"].ToString();
                                KiThiLopHocSinhVien.DapAn = dtKiThiLopHocSinhVien.Rows[i]["DapAn"].ToString();
                                KiThiLopHocSinhVien.Diem = float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString());
                                KiThiLopHocSinhVien.BaiLam = dtKiThiLopHocSinhVien.Rows[i]["BaiLam"].ToString();
                                KiThiLopHocSinhVien.MaDe = dtKiThiLopHocSinhVien.Rows[i].IsNull("MaDe") ? "" : dtKiThiLopHocSinhVien.Rows[i]["MaDe"].ToString();
                                KiThiLopHocSinhVien.NgayGioBatDau = dtKiThiLopHocSinhVien.Rows[i].IsNull("NgayGioBatDau") ? DateTime.Now : DateTime.Parse(dtKiThiLopHocSinhVien.Rows[i]["NgayGioBatDau"].ToString());
                                KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianConLai"].ToString());
                                KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianThi"].ToString());

                                KiThiLopHocSinhVien = Utils.chamBai(KiThiLopHocSinhVien, KiThiLopHocSinhVien.BaiLam);
                                data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, 4, KiThiLopHocSinhVien.BaiLam, KiThiLopHocSinhVien.Diem);
                            }
                            else
                            {
                                if (iStatus.Equals(1) || iStatus.Equals(2))
                                {
                                    data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(iKiThi_LopHoc_SinhVienID, 8, "", 0);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void chuyenThiVoiLopHoc(int KiThi_LopHocID)
        {
            DataTable dtKiThiLopHocSinhVien;
            model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
            int iStatus = -1;
            int iKiThi_LopHoc_SinhVienID = -1;

            dtKiThiLopHocSinhVien = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.getByKiThi_LopHoc1(KiThi_LopHocID);
            if (dtKiThiLopHocSinhVien != null && dtKiThiLopHocSinhVien.Rows.Count > 0)
            {
                for (int i = 0; i < dtKiThiLopHocSinhVien.Rows.Count; i++)
                {
                    iStatus = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                    iKiThi_LopHoc_SinhVienID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                    if (iStatus.Equals(1))
                    {
                        data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(iKiThi_LopHoc_SinhVienID, 9, "", 0);
                    }
                }
            }
        }
        public static void ketThucKiThiVoiLopHoc(int KiThi_LopHocID)
        {
            // Lấy 
            DataTable dtKiThiLopHocSinhVien;
            model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
            int iStatus = -1;
            int iKiThi_LopHoc_SinhVienID = -1;

            dtKiThiLopHocSinhVien = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.getByKiThi_LopHoc1(KiThi_LopHocID);
            if (dtKiThiLopHocSinhVien != null && dtKiThiLopHocSinhVien.Rows.Count > 0)
            {
                for (int i = 0; i < dtKiThiLopHocSinhVien.Rows.Count; i++)
                {
                    iStatus = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                    iKiThi_LopHoc_SinhVienID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                    if (iStatus.Equals(3) || iStatus.Equals(5) || iStatus.Equals(6))
                    {
                        KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
                        //KiThiLopHocSinhVien.BoDeID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["BoDeID"].ToString());
                        //KiThiLopHocSinhVien.DeThiID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["DeThiID"].ToString());
                        KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien = iKiThi_LopHoc_SinhVienID;
                        KiThiLopHocSinhVien.Status = iStatus;
                        //KiThiLopHocSinhVien.TenBlockHoc = dtKiThiLopHocSinhVien.Rows[i]["TenBlockHoc"].ToString();
                        //KiThiLopHocSinhVien.TenKiThi = dtKiThiLopHocSinhVien.Rows[i]["TenKiThi"].ToString();
                        //KiThiLopHocSinhVien.TenMonHoc = dtKiThiLopHocSinhVien.Rows[i]["TenMonHoc"].ToString();
                        KiThiLopHocSinhVien.NoiDungDeThi = dtKiThiLopHocSinhVien.Rows[i]["NoiDungDeThi"].ToString();
                        KiThiLopHocSinhVien.DapAn = dtKiThiLopHocSinhVien.Rows[i]["DapAn"].ToString();
                        KiThiLopHocSinhVien.Diem = float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString());
                        KiThiLopHocSinhVien.BaiLam = dtKiThiLopHocSinhVien.Rows[i]["BaiLam"].ToString();
                        KiThiLopHocSinhVien.MaDe = dtKiThiLopHocSinhVien.Rows[i].IsNull("MaDe") ? "" : dtKiThiLopHocSinhVien.Rows[i]["MaDe"].ToString();
                        KiThiLopHocSinhVien.NgayGioBatDau = dtKiThiLopHocSinhVien.Rows[i].IsNull("NgayGioBatDau") ? DateTime.Now : DateTime.Parse(dtKiThiLopHocSinhVien.Rows[i]["NgayGioBatDau"].ToString());
                        KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianConLai"].ToString());
                        KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianThi"].ToString());

                        KiThiLopHocSinhVien = Utils.chamBai(KiThiLopHocSinhVien, KiThiLopHocSinhVien.BaiLam);
                        data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, 4, KiThiLopHocSinhVien.BaiLam, KiThiLopHocSinhVien.Diem);
                    }
                    else
                    {
                        if (iStatus.Equals(1) || iStatus.Equals(2))
                        {
                            data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(iKiThi_LopHoc_SinhVienID, 8, "", 0);
                        }
                    }
                }
            }

        }

        #region Role
        public static string role_Admin = "Administrators";
        public static string role_QuanTriThongTinChung = "Quản trị thông tin chung";
        public static string role_QuanTriPhongMay = "Quản trị phòng máy";
        public static string role_GiangVien = "Giảng viên";
        public static string role_GiangVien_DangKiLichPhongMay = "GV_DKLPM";
        #endregion
        #region Random
        public static int getRandom(int begin, int end)
        {
            Random rnd = new Random();
            return rnd.Next(begin, end); //
        }
        #endregion
        #region excel
        public static DataTable getTableFromWorkSheet(IXLWorksheet workSheet)
        {
            DataTable dt = new DataTable();
            //Loop through the Worksheet rows.
            bool firstRow = true;
            int colNum = 0;
            foreach (IXLRow row in workSheet.Rows())
            {
                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        dt.Columns.Add(Utils.StripUnicodeCharactersFromString(cell.Value.ToString()).Replace(" ", "_"));
                        colNum++;
                    }
                    firstRow = false;
                }
                else
                {
                    //Add rows to DataTable.
                    dt.Rows.Add();
                    int i = 0;
                    foreach (IXLCell cell in row.Cells(1, colNum))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                        i++;
                    }
                }

                //GridView1.DataSource = dt;
                //GridView1.DataBind();
            }
            return dt;
        }
        public static string getHtmlFromWorkSheet(IXLWorksheet workSheet)
        {
            //Building an HTML string.
            StringBuilder html = new StringBuilder();
            html.Append("<table border = '1' style='width:100%;'>");
            //Loop through the Worksheet rows.
            bool firstRow = true;
            int colNum = 0;
            foreach (IXLRow row in workSheet.Rows())
            {
                html.Append("<tr>");
                //Use the first row to add columns to DataTable.
                if (firstRow)
                {
                    foreach (IXLCell cell in row.Cells())
                    {
                        html.Append($"<th>{Utils.StripUnicodeCharactersFromString(cell.Value.ToString()).Replace(" ", "_")}</th>");
                        colNum++;
                    }
                    firstRow = false;
                }
                else
                {
                    int i = 0;
                    foreach (IXLCell cell in row.Cells(1, colNum))
                    {
                        html.Append($"<td>{cell.Value}</td>");
                        i++;
                    }
                }
                html.Append("</tr>");
            }
            html.Append("</table>");
            return html.ToString();
        }
        public static string getHtmlFromDataTable(DataTable dt)
        {
            //Building an HTML string.
            StringBuilder html = new StringBuilder();
            //Table start.
            html.Append("<table border = '1' style='width:100%;'>");

            //Building the Header row.
            html.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>");
                html.Append(column.ColumnName);
                html.Append("</th>");
            }
            html.Append("</tr>");

            //Building the Data rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>");
                    html.Append(row[column.ColumnName]);
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            //Table end.
            html.Append("</table>");
            return html.ToString();
        }
        #endregion
        public static string RandomString(int size, bool lowerCase, Random random = null)
        {
            StringBuilder builder = new StringBuilder();
            if (random == null)
            {
                random = new Random();
            }
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        #region ma hoa
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }


        #endregion
    }

    public static class UtilsDisplayDe
    {
        // Dung cho giao vien
        static string getCauHoiHtml(model.CauHoi cauhoi, model.DapAn dapAnTemp, string l, int PortalID)
        {
            int iCount = cauhoi.SoCauTraLoi;
            string strHtmlItem = "<table>";
            strHtmlItem += string.Format("<tr><td style ='font-weight:bold;'>Câu hỏi {0} - {1} ({2:N2} điểm)</td></tr>", l, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.Mark);
            if (!(cauhoi.Image.ToUpper().Equals("") || cauhoi.Image.ToUpper().Equals("NULL")))
            {
                strHtmlItem += string.Format("<tr><td style='text-align:center'><image src='/Portals/{0}/{1}' hight='100px;'></image></td></tr>", PortalID, cauhoi.Image);
            }
            int i = 1;
            string strLaDapAn = "là đáp án";
            while (i < (iCount + 1))
            {
                switch (i)
                {
                    case 1:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A1), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A1));
                        break;
                    case 2:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M2))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A2), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A2));
                        break;
                    case 3:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M3))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A3), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A3));
                        break;
                    case 4:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M4))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A4), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A4));
                        break;
                    case 5:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M5))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A5), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A5));
                        break;
                    case 6:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M6))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A6), strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), HttpUtility.HtmlDecode(cauhoi.A6));
                        break;
                    case 7:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                        break;
                    case 8:
                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                        else
                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                        break;
                    case 9:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A9);
                        break;
                    case 10:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A10);
                        break;
                    case 11:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A11);
                        break;
                    case 12:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A12);
                        break;
                    case 13:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A13);
                        break;
                    case 14:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A14);
                        break;
                    case 15:
                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A15);
                        break;
                }
                i++;
            }
            strHtmlItem += "</table>";
            return strHtmlItem;
        }
        public static string displayDe(string DeThiID, string strMaDe, int PortalID)
        {
            //Lấy dữ liệu
            DataTable dt = data.dnn_NuceThi_DeThi.get(int.Parse(DeThiID));
            if (dt.Rows.Count > 0)
            {
                string strNoiDung = dt.Rows[0]["NoiDungDeThi"].ToString();
                string strDapAn = dt.Rows[0]["DapAn"].ToString();
                List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(strNoiDung);
                List<model.DapAn> lsDapAns = JsonConvert.DeserializeObject<List<model.DapAn>>(strDapAn);
                float fDiemToiDa = 0;
                foreach (model.CauHoi cauhoi in lsCauHois)
                {
                    fDiemToiDa += cauhoi.Mark;
                }
                string strHtml = "<table style='width:100%;'>";
                strHtml += string.Format("<tr><td colspan='2' style='text-align:center;color:blue;'>Chi tiết đề có mã {0}</td></tr>", strMaDe);// ddlMaDe.SelectedValue
                strHtml += string.Format("<tr><td colspan='2' style='text-align:center;color:blue;'>Có tất cả {0} câu hỏi và điểm tối đa cho mỗi đề là {1:N2}</td></tr>", lsCauHois.Count, fDiemToiDa);
                int l = 0;
                int l1 = 0;
                foreach (model.CauHoi cauhoi in lsCauHois)
                {
                    model.DapAn dapAnTemp = lsDapAns.Find(x => x.CauHoiID == cauhoi.CauHoiID);
                    //model.DapAn dapAnTemp = lsDapAns[l];
                    l++;
                    string strHtmlItem = "";
                    int iCount = cauhoi.SoCauTraLoi;
                    string strType = cauhoi.Type;

                    switch (strType)
                    {
                        case "SC":
                        case "MC":
                        case "TQ":
                        case "FQ":
                            strHtmlItem += getCauHoiHtml(cauhoi, dapAnTemp, l.ToString(), PortalID);
                            #region loai binh thuong
                            /*
                            strHtmlItem = "<table>";
                            strHtmlItem += string.Format("<tr><td style ='font-weight:bold;'>Câu hỏi {0} - {1} ({2:N2} điểm)</td></tr>", l, cauhoi.Content, cauhoi.Mark);
                            int i = 1;
                            string strLaDapAn = "là đáp án";
                            while (i < (iCount + 1))
                            {
                                switch (i)
                                {
                                    case 1:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                                        break;
                                    case 2:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M2))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A2, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A2);
                                        break;
                                    case 3:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M3))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A3, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A3);
                                        break;
                                    case 4:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M4))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A4, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A4);
                                        break;
                                    case 5:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M5))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A5, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A5);
                                        break;
                                    case 6:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                                        break;
                                    case 7:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                                        break;
                                    case 8:
                                        if (dapAnTemp.Match.Contains(";" + cauhoi.M1))
                                            strHtmlItem += string.Format("<tr><td style='color:red;'>{0} - {1} ({2})</td></tr>", getLetterByIndex(i), cauhoi.A1, strLaDapAn);
                                        else
                                            strHtmlItem += string.Format("<tr><td>{0} - {1}</td></tr>", getLetterByIndex(i), cauhoi.A1);
                                        break;
                                    case 9:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A9);
                                        break;
                                    case 10:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A10);
                                        break;
                                    case 11:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A11);
                                        break;
                                    case 12:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A12);
                                        break;
                                    case 13:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A13);
                                        break;
                                    case 14:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A14);
                                        break;
                                    case 15:
                                        strHtmlItem += string.Format("<tr><td>{0}</td></tr>", cauhoi.A15);
                                        break;
                                }
                                i++;
                            }
                            strHtmlItem += "</table>";
                            */
                            #endregion
                            break;
                        case "TL":
                            strHtmlItem += "<table>";
                            strHtmlItem += string.Format("<tr><td style ='font-weight:bold;'>Câu hỏi {0} - {1} </td></tr>", l, HttpUtility.HtmlDecode(cauhoi.Content));
                            if (!(cauhoi.Image.ToUpper().Equals("") || cauhoi.Image.ToUpper().Equals("NULL")))
                            {
                                strHtmlItem += string.Format("<tr><td style='text-align:center'><image src='/Portals/{0}/{1}' hight='100px;'></image></td></tr>", PortalID, cauhoi.Image);
                            }
                            if (cauhoi.ChildCauHois != null && cauhoi.ChildCauHois.Count > 0)
                            {
                                l1 = 0;
                                foreach (model.CauHoi cauhoi1 in cauhoi.ChildCauHois)
                                {
                                    l1++;
                                    strHtmlItem += "<tr><td><div style='padding-left:15px;'>";
                                    dapAnTemp = lsDapAns.Find(x => x.CauHoiID == cauhoi1.CauHoiID);
                                    strHtmlItem += getCauHoiHtml(cauhoi1, dapAnTemp, string.Format("{0}.{1}", l, l1), PortalID);
                                    strHtmlItem += "</div></td></tr>";
                                }
                            }
                            strHtmlItem += "</table>";
                            break;
                        case "EQ":
                        case "SA":
                        case "GQ":
                        case "EX":
                            strHtmlItem += "<table>";
                            strHtmlItem += string.Format("<tr><td style ='font-weight:bold;'>Câu hỏi {0} - {1} </td></tr>", l, HttpUtility.HtmlDecode(cauhoi.Content));
                            strHtmlItem += "</table>";
                            break;
                    }
                    strHtml += string.Format("<tr><td colspan='2' style='text-align:left'>{0}</td></tr>", strHtmlItem);
                }
                strHtml += "</table>";
                //divContent.InnerHtml = strHtml;
                return strHtml;
            }
            else
            {
                //divContent.InnerHtml = string.Format("Không tồn tại đề thi");
                return string.Format("Không tồn tại đề thi");
            }
        }
        static string getLetterByIndex(int i)
        {
            switch (i)
            {
                case 1: return "a";
                case 2: return "b";
                case 3: return "c";
                case 4: return "d";
                case 5: return "e";
                case 6: return "f";
                case 7: return "g";
                case 8: return "h";
            }
            return "";
        }
    }

    #region Encrypt & Decrypt
    public static class StringCipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
    #endregion
}
