using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model = nuce.web.model;

namespace Thi_SV
{
    public static class Utils
    {
        public static string session_kithi_lophoc_sinhvien = "session_kithi_lop_hoc_sinhvien";
        public static string session_sinhvien = "session_sinhvien";
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

                if (lsMatchs1.Count > 1)
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
    }
}