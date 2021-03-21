using GemBox.Spreadsheet;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppConnectDaoTao
{
    public partial class frmMain : Form
    {
        private DataTable dt;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCheckValue_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            //int iCountNganh = sv.countNganh();
            //int iCountKhoa = sv.countKhoa();
            //int iCountBoMon = sv.countBoMon();
            //int iCountMonHoc = sv.countMonHoc();
            //int iCountLop = sv.countLop();
            //int iCountSV = sv.countSinhVien();
            //int iCountToDK1 = sv.countToDK1();
            //int iCountKqdk1 = sv.countKqdk1();
            //int iCountKqdk1ExistSV = sv.countKqdk1ExistSV();
            //int iCountTkb1 = sv.countTkb1();
            //int iCountCB = sv.countCanBo();

//            DataTable dtTKB = sv.getTKB1("m");

//            string strMessage = string.Format(@"So nganh:{0}; so khoa:{1};so bo mon: {2}; so mon hoc: {3}; So Lop: {4}; So Sinh vien:{5}; So ToDK1:{6}; So Kqdk1:{7}; So Kqdk1ExistSV:{8};So TKb1:{9};So can bo:{10};", iCountNganh, iCountKhoa, iCountBoMon, iCountMonHoc, iCountLop, iCountSV, iCountToDK1, iCountKqdk1,
//iCountKqdk1ExistSV, iCountToDK1, iCountCB);
//            string strTest = "";
//            for (int i = 0; i < dtTKB.Rows.Count; i++)
//            {
//                if (dtTKB.Rows[i]["MaDK"].ToString().Contains("IT3"))
//                {
//                    strTest = "1";
//                }
//            }
//            MessageBox.Show(strMessage);

            DataTable table = new DataTable("TKB");
            table.Columns.Add(new DataColumn("STT"));
            table.Columns.Add(new DataColumn("LOP"));
            table.Columns.Add(new DataColumn("MONHOC"));
            table.Columns.Add(new DataColumn("THU"));
            table.Columns.Add(new DataColumn("NGAY"));
            table.Columns.Add(new DataColumn("Phong"));
            table.Columns.Add(new DataColumn("CA"));
            table.Columns.Add(new DataColumn("TietBD"));

            int hockyid = -1;
            int namhocid = -1;
            // Lay nam hoc
            DataTable dtNamHoc = nuce.web.data.dnn_NuceCommon_NamHoc1.getByStatus(1);
            DateTime dtNgayBatDau = DateTime.Parse(dtNamHoc.Rows[0]["NgayBatDau"].ToString());
            // Lấy tất cả danh sách phòng máy
            DataTable dtTKB = sv.getTKB("May");
            // Lay To Dang ki
            DataTable dtToDK = sv.getToDK("May");
            // Lay tong so sinh vien dang ki
            DataTable dtTongSoSVDK = sv.getTongSoSVDK("May");
            // Lay tat ca log de check
            DataTable dtLog = nuce.web.data.dnn_NuceQLPM_Log_Syn1.getByType(1, 3);
            // Lay ta ca cac du lieu ve can bo
            DataTable dtCanBo = sv.getCanBo("May");
            // Lay danh sach phòng máy
            DataTable dtPhongMay = nuce.web.data.dnn_NuceCommon_PhongHoc1.get(-1);
            // Lay ca hoc
            DataTable dtCaHoc = nuce.web.data.dnn_NuceCommon_CaHoc1.get(-1);
            // Duyệt qua tất cả các danh sách
            // Get Mon học
            DataTable dtMonHoc = sv.getMonHoc();
            string MaDK;
            string MaCB;
            string HoVaTenCB;
            string Lop;
            string MonHoc;
            string Thu;
            int iThu;
            string TietBD;
            string SoTiet;
            string MaPH;
            int PhongHocID;
            int BuoiHoc;
            string TuanHoc;
            DateTime Ngay;
            int CahocID;
            int HocKyID;
            int NamHocID;
            int SoSinhVien;
            string TTThemCB;
            string MoTa;
            string GhiChu;
            string Key;
            DataRow drThongTinLop;
            string[] tuans;
            int iCount = 0;

            for (int i = 0; i < dtTKB.Rows.Count; i++)
            {
                Key = dtTKB.Rows[i]["keytohop"].ToString();
                if (!checkExists(dtLog, Key))
                {
                    MaDK = dtTKB.Rows[i]["MaDK"].ToString();
                    MaCB = dtTKB.Rows[i]["MaCB"].ToString();
                    HoVaTenCB = getHoVaTenCB(dtCanBo, MaCB);
                    drThongTinLop = getThongTinLopHoc(dtToDK, MaDK);
                    if (drThongTinLop != null)
                    {
                        Lop = drThongTinLop["MaNh"].ToString();
                        MonHoc = drThongTinLop["TenMH"].ToString();
                    }
                    else
                    {
                        Lop = "";
                        MonHoc = "";
                    }
                    Thu = dtTKB.Rows[i]["Thu"].ToString();
                    iThu = int.Parse(Thu.Trim());
                    TietBD = dtTKB.Rows[i]["TietBD"].ToString();
                    SoTiet = dtTKB.Rows[i]["SoTiet"].ToString();
                    MaPH = dtTKB.Rows[i]["MaPH"].ToString();
                    PhongHocID = getPhong(dtPhongMay, MaPH);
                    BuoiHoc = int.Parse(dtTKB.Rows[i]["BuoiHoc"].ToString());
                    TuanHoc = dtTKB.Rows[i]["TuanHoc"].ToString();
                    #region Xu ly tuan hoc

                    #endregion
                    CahocID = getCaHoc(dtCaHoc, TietBD);
                    SoSinhVien = getSoSinhVien(dtTongSoSVDK, MaDK);
                    TTThemCB = "";
                    MoTa = "";
                    GhiChu = "---Dong bo " + MaDK + "-" + Lop + "-" + MonHoc + "-" + HoVaTenCB + "---";
                    // Insert vao bang dang ki va danh dau log
                    for (int j = 0; j < TuanHoc.Length; j++)
                    {
                        if (TuanHoc[j].ToString().Trim().Replace(" ", "") != "")
                        {
                            if(Lop.Contains("62TH2"))
                            {
                                int ttt = 1;
                            }
                            Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 19) * 7);
                            try
                            {
                                //if (Ngay >= DateTime.Now.AddDays(2))
                                if(Ngay.Day.Equals(20)&&Ngay.Month.Equals(1))
                                {
                                    iCount++;
                                    table.Rows.Add(iCount.ToString(), Lop, MonHoc, Thu, Ngay, MaPH,CahocID, TietBD);
                                    //nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                    // Danh dau da duyet
                    try
                    {
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
            grvView.DataSource = table;
        }


        private void btnDongBo_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            int hockyid = -1;
            int namhocid = -1;
            // Lay nam hoc
            DataTable dtNamHoc = nuce.web.data.dnn_NuceCommon_NamHoc1.getByStatus(1);
            DateTime dtNgayBatDau = DateTime.Parse(dtNamHoc.Rows[0]["NgayBatDau"].ToString());
            // Lấy tất cả danh sách phòng máy
            DataTable dtTKB = sv.getTKB("May");
            //DataTable dtTKB = sv.getTKB_bangkytruoc("May");
            // Lay To Dang ki
             DataTable dtToDK = sv.getToDK("May");
            //DataTable dtToDK = sv.getToDK_bangkytruoc("May");
            // Lay tong so sinh vien dang ki
            DataTable dtTongSoSVDK = sv.getTongSoSVDK("May");
            //DataTable dtTongSoSVDK = sv.getTongSoSVDK_bangkytruoc("May");
            // Lay tat ca log de check
            DataTable dtLog = nuce.web.data.dnn_NuceQLPM_Log_Syn1.getByType(1, 3);
            // Lay ta ca cac du lieu ve can bo
            DataTable dtCanBo = sv.getCanBo("May");
            // Lay danh sach phòng máy
            DataTable dtPhongMay = nuce.web.data.dnn_NuceCommon_PhongHoc1.get(-1);
            // Lay ca hoc
            DataTable dtCaHoc = nuce.web.data.dnn_NuceCommon_CaHoc1.get(-1);
            // Duyệt qua tất cả các danh sách
            // Get Mon học
            DataTable dtMonHoc = sv.getMonHoc();
            string MaDK;
            string MaCB;
            string HoVaTenCB;
            string Lop;
            string MonHoc;
            string Thu;
            int iThu;
            string TietBD;
            string SoTiet;
            string MaPH;
            int PhongHocID;
            int BuoiHoc;
            string TuanHoc;
            DateTime Ngay;
            int CahocID;
            int HocKyID;
            int NamHocID;
            int SoSinhVien;
            string TTThemCB;
            string MoTa;
            string GhiChu;
            string Key;
            DataRow drThongTinLop;
            string[] tuans;

            for (int i = 0; i < dtTKB.Rows.Count; i++)
            {
                Key = dtTKB.Rows[i]["keytohop"].ToString();
                if (!checkExists(dtLog, Key))
                {
                    MaDK = dtTKB.Rows[i]["MaDK"].ToString();
                    MaCB = dtTKB.Rows[i]["MaCB"].ToString();
                    HoVaTenCB = getHoVaTenCB(dtCanBo, MaCB);
                    drThongTinLop = getThongTinLopHoc(dtToDK, MaDK);
                    if (drThongTinLop != null)
                    {
                        Lop = drThongTinLop["MaNh"].ToString();
                        MonHoc = drThongTinLop["TenMH"].ToString();
                    }
                    else
                    {
                        Lop = "";
                        MonHoc = "";
                    }
                    Thu = dtTKB.Rows[i]["Thu"].ToString();
                    iThu = int.Parse(Thu.Trim());
                    TietBD = dtTKB.Rows[i]["TietBD"].ToString();
                    SoTiet = dtTKB.Rows[i]["SoTiet"].ToString();
                    MaPH = dtTKB.Rows[i]["MaPH"].ToString();
                    PhongHocID = getPhong(dtPhongMay, MaPH);
                    BuoiHoc = int.Parse(dtTKB.Rows[i]["BuoiHoc"].ToString());
                    TuanHoc = dtTKB.Rows[i]["TuanHoc"].ToString();
                    #region Xu ly tuan hoc

                    #endregion
                    CahocID = getCaHoc(dtCaHoc, TietBD);
                    SoSinhVien = getSoSinhVien(dtTongSoSVDK, MaDK);
                    TTThemCB = "";
                    MoTa = "";
                    GhiChu = "---Dong bo " + MaDK + "-" + Lop + "-" + MonHoc + "-" + HoVaTenCB + "---";
                    // Insert vao bang dang ki va danh dau log
                    for (int j = 0; j < TuanHoc.Length; j++)
                    {
                        if (TuanHoc[j].ToString().Trim().Replace(" ", "") != "")
                        {

                            // Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 20) * 7);
                            Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 19) * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + j * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 39) * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 45) * 7);
                            if (MaCB.Equals("8683"))
                            {
                                int test000 = 000;
                            }

                            if (Ngay > DateTime.Now && Ngay < DateTime.Now.AddDays(7))
                            {
                                int test = 1;
                            }
                            // Cap nhat vao csdl
                            try
                            {
                                if (Ngay >= DateTime.Now.AddDays(-3))
                                {
                                    DataTable dtTest = nuce.web.data.dnn_NuceQLPM_LichPhongMay1.getByNgayCaPhong(Ngay, CahocID, PhongHocID);
                                    if (dtTest != null)
                                    {
                                        if (dtTest.Rows.Count > 0)
                                        {
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.deleteByNgayCaPhong(Ngay, CahocID, PhongHocID);
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }

                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                    // Danh dau da duyet
                    try
                    {
                        //nuce.web.data.dnn_NuceQLPM_Log_Syn1.Insert(Key, 3, Utils.synTypeLichHoc, "Dong bo thanh cong lich hoc");
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }

            MessageBox.Show("Thanh cong");
        }
        private bool checkExists(DataTable dt, string key)
        {
            DataRow[] drs = dt.Select(string.Format("[KeyCheck]='{0}'", key));
            if (drs.Length > 0)
                return true;
            else
                return false;
        }
        private string getHoVaTenCB(DataTable dt, string MaCB)
        {
            DataRow[] drs = dt.Select(string.Format("[MaCB]='{0}'", MaCB));
            if (drs.Length > 0)
                return drs[0]["TenCB"].ToString() + "-" + drs[0]["MaBM"].ToString();
            else
                return "";
        }
        private int getPhong(DataTable dt, string MaPhong)
        {
            string MP = "";
            for (int i = 1; i < 6; i++)
            {
                if (MaPhong.Contains(i.ToString()))
                    MP = "P.MAY " + i.ToString();
            }

            DataRow[] drs = dt.Select(string.Format("[Ip2]='{0}'", MP));
            if (drs.Length > 0)
                return int.Parse(drs[0]["PhongHocID"].ToString());
            else
                return -1;
        }
        private int getCaHoc(DataTable dt, string TBD)
        {
            int TietBatDau = int.Parse(TBD);
            int iTietBatDau = 1;
            int iTietKetThuc = 3;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                iTietBatDau = int.Parse(dt.Rows[i]["TietBatDau"].ToString());
                iTietKetThuc = int.Parse(dt.Rows[i]["TietKetThuc"].ToString());

                if (TietBatDau >= iTietBatDau && TietBatDau <= iTietKetThuc)
                {
                    return int.Parse(dt.Rows[i]["CaHocID"].ToString());
                }
            }
            return -1;
        }
        private int getSoSinhVien(DataTable dt, string MaDK)
        {
            DataRow[] drs = dt.Select(string.Format("[MaDK]='{0}'", MaDK));
            if (drs.Length > 0)
                return int.Parse(drs[0]["SoSV"].ToString());
            else
                return -1;
        }
        private DataRow getThongTinLopHoc(DataTable dt, string MaDK)
        {
            DataRow[] drs = dt.Select(string.Format("[MaDK]='{0}'", MaDK));
            if (drs.Length > 0)
                return drs[0];
            else
                return null;
        }
        private string getMonHoc(DataTable dt, string MaMH)
        {
            DataRow[] drs = dt.Select(string.Format("[MaNh]='{0}'", MaMH));
            if (drs.Length > 0)
                return drs[0]["TenMH"].ToString();
            else
                return "";
        }
        private string getMonHocByTableMonHoc(DataTable dt, string MaMH)
        {
            DataRow[] drs = dt.Select(string.Format("[MaMH]='{0}'", MaMH));
            if (drs.Length > 0)
                return drs[0]["TenMH"].ToString();
            else
                return "";
        }

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            string strTen = "1512660";
            string strMatKhau = "24680";
            int iReturn = sv.authen(strTen, strMatKhau);
            MessageBox.Show(iReturn.ToString());
        }

        private void btnSynDGGV_dong_bo_lop_mon_hoc_giang_vien_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtTkb1JoinToDk1 = sv.getAllTKB1JoinToDk1();
            //Duyet qua tung ban ghi
            #region Xu ly chuan hoa du lieu 
            DataTable dtTkb1JoinToDk1V1 = new DataTable();
            dtTkb1JoinToDk1V1.Columns.Add("MaDK");
            dtTkb1JoinToDk1V1.Columns.Add("MaCB");
            dtTkb1JoinToDk1V1.Columns.Add("Thu");
            dtTkb1JoinToDk1V1.Columns.Add("TietDB");
            dtTkb1JoinToDk1V1.Columns.Add("SoTiet");
            dtTkb1JoinToDk1V1.Columns.Add("MaPH");
            dtTkb1JoinToDk1V1.Columns.Add("TuanHoc");
            dtTkb1JoinToDk1V1.Columns.Add("MaMH");
            for (int i = 0; i < dtTkb1JoinToDk1.Rows.Count; i++)
            {
                DataRow dr = dtTkb1JoinToDk1V1.NewRow();
                dr["MaDK"] = dtTkb1JoinToDk1.Rows[i]["MaDK"].ToString().Trim();
                dr["MaCB"] = dtTkb1JoinToDk1.Rows[i]["MaCB"].ToString().Trim();
                string Thu = dtTkb1JoinToDk1.Rows[i]["Thu"].ToString();
                dr["TietDB"] = dtTkb1JoinToDk1.Rows[i]["TietDB"].ToString().Trim();
                dr["SoTiet"] = dtTkb1JoinToDk1.Rows[i]["SoTiet"].ToString().Trim();
                dr["MaMH"] = dtTkb1JoinToDk1.Rows[i]["MaMH"].ToString().Trim();


                if (!string.IsNullOrWhiteSpace(Thu))
                    Thu = Thu.Trim();
                dr["Thu"] = Thu;
                string TuanHoc = dtTkb1JoinToDk1.Rows[i]["TuanHoc"].ToString();
                if (!string.IsNullOrWhiteSpace(TuanHoc))
                    TuanHoc = TuanHoc.Trim();
                dr["TuanHoc"] = TuanHoc;
                string MaPH = dtTkb1JoinToDk1.Rows[i]["MaPH"].ToString();
                if (!string.IsNullOrWhiteSpace(MaPH))
                {
                    MaPH = MaPH.Trim();
                    if (!MaPH.Equals("XMH"))
                    {
                        string[] roomArr = new string[2];

                        if (MaPH.Contains(" "))
                            roomArr = MaPH.Split(' ').ToArray();
                        else if (MaPH.Contains("."))
                            roomArr = MaPH.Split('.').ToArray();
                        else if (MaPH.Contains("-"))
                            roomArr = MaPH.Split('-').ToArray();
                        else if (MaPH.Contains("_"))
                            roomArr = MaPH.Split('_').ToArray();
                        else
                        {
                            roomArr[0] = MaPH;
                            roomArr[1] = "";
                        }
                        //throw new ArgumentException("TKB chứa ký tự không hợp lệ : " + JsonConvert.SerializeObject(sched));

                        if (!roomArr[0].All(Char.IsDigit)) // VD H1.101
                        {
                            MaPH = string.Concat(roomArr[1], ".", roomArr[0]); // => 101.H1
                        }
                    }
                }
                dr["MaPH"] = MaPH;
                dtTkb1JoinToDk1V1.Rows.Add(dr);
            }
            #endregion
            #region Xu ly chuan hoa du lieu dien thong tin them vao giang vien
            DataTable dtTkb1JoinToDk1V2 = new DataTable();
            dtTkb1JoinToDk1V2.Columns.Add("MaDK");
            dtTkb1JoinToDk1V2.Columns.Add("MaCB");
            dtTkb1JoinToDk1V2.Columns.Add("Thu");
            dtTkb1JoinToDk1V2.Columns.Add("TietDB");
            dtTkb1JoinToDk1V2.Columns.Add("SoTiet");
            dtTkb1JoinToDk1V2.Columns.Add("MaPH");
            dtTkb1JoinToDk1V2.Columns.Add("TuanHoc");
            dtTkb1JoinToDk1V2.Columns.Add("MaMH");
            for (int i = 0; i < dtTkb1JoinToDk1V1.Rows.Count; i++)
            {
                DataRow dr = dtTkb1JoinToDk1V2.NewRow();
                dr["MaDK"] = dtTkb1JoinToDk1V1.Rows[i]["MaDK"].ToString();
                string Thu = dtTkb1JoinToDk1V1.Rows[i]["Thu"].ToString();
                dr["Thu"] = Thu;
                string TietDB = dtTkb1JoinToDk1V1.Rows[i]["TietDB"].ToString();
                dr["TietDB"] = TietDB;
                dr["SoTiet"] = dtTkb1JoinToDk1V1.Rows[i]["SoTiet"].ToString();
                string MaPH = dtTkb1JoinToDk1V1.Rows[i]["MaPH"].ToString();
                dr["MaPH"] = MaPH;
                string TuanHoc = dtTkb1JoinToDk1V1.Rows[i]["TuanHoc"].ToString();
                dr["TuanHoc"] = TuanHoc;
                string MaMH = dtTkb1JoinToDk1V1.Rows[i]["MaMH"].ToString();
                dr["MaMH"] = MaMH;
                //dr["MaCB"] = dtTkb1JoinToDk1V1.Rows[i]["MaCB"].ToString();
                string strMaCB = dtTkb1JoinToDk1V1.Rows[i]["MaCB"].ToString();
                if (string.IsNullOrWhiteSpace(strMaCB))
                {
                    //Xu ly tim can bo tuong ung va co ma can bo khac trang
                    dr["MaCB"] = getCanBoTrongLopGhepTuongUng(dtTkb1JoinToDk1V1, MaMH,
                        Thu, TietDB, MaPH, TuanHoc);
                }
                else
                    dr["MaCB"] = strMaCB;
                dtTkb1JoinToDk1V2.Rows.Add(dr);
            }
            #endregion
            #region xu ly chen vao csdl
            for (int i = 0; i < dtTkb1JoinToDk1V2.Rows.Count; i++)
            {
                string strMaDK = dtTkb1JoinToDk1V2.Rows[i]["MaDK"].ToString();
                strMaDK = strMaDK.Replace(" ", "");
                string strMaCB = dtTkb1JoinToDk1V2.Rows[i]["MaCB"].ToString();
                if (!string.IsNullOrWhiteSpace(strMaDK) &&
                    !string.IsNullOrWhiteSpace(strMaCB))
                {
                    nuce.web.data.Nuce_Survey.InsertAcademy_Lecturer_ClassRoom(strMaDK, strMaCB, 1);
                }
            }
            #endregion
            MessageBox.Show("So ban ghi lay thu tu webservice" + dtTkb1JoinToDk1V1.Rows.Count.ToString());
            //DataTable dtTemp = nuce.web.data.Nuce_Survey.getAcademy_Class();
            //MessageBox.Show("So ban ghi lay thu Database Survey" + dtTemp.Rows.Count.ToString());
        }
        #region tim can bo co ma tuong ung trong lop ghep 
        public string getCanBoTrongLopGhepTuongUng(DataTable dt, string MaMH, string Thu, string TietDB,
            string MaPH, string TuanHoc)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MaMH"].Equals(MaMH)
                  && dt.Rows[i]["Thu"].Equals(Thu)
                  && dt.Rows[i]["TietDB"].Equals(TietDB)
                  && dt.Rows[i]["MaPH"].Equals(MaPH)
                  && dt.Rows[i]["TuanHoc"].Equals(TuanHoc)
                  && !string.IsNullOrWhiteSpace(dt.Rows[i]["MaCB"].ToString()))
                {
                    return dt.Rows[i]["MaCB"].ToString().Trim();
                }
            }
            return "";
        }
        #endregion
        private void btn_Doc_Du_Lieu_Mon_Hoc_GetData_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("ver1_da_ra_soat_15_1.xls");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["tong_hop"];

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(cell.Value.ToString());
            }
            int iColumn = 0;
            for (int i = 1; i < sheet.Rows.Count; i++)
            {
                iColumn = 0;
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {
                    dt.Rows.Add();
                    if (cell.Value != null)
                        dt.Rows[i - 1][iColumn] = cell.Value.ToString();
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            grvView.DataSource = dt;
        }

        private void btn_Doc_Du_Lieu_Mon_Hoc_CapNhat_Click(object sender, EventArgs e)
        {
            int iLength = 1000;
            if (dt.Rows.Count < iLength)
            {
                iLength = dt.Rows.Count;
            }
            for (int i = 0; i < iLength; i++)
            {
                string strCode = dt.Rows[i][0].ToString().Trim();
                string strName = dt.Rows[i][1].ToString().Trim();
                int iType = 1;
                if (strCode != "" && strCode.Length > 2)
                {
                    if (dt.Rows[i][3].ToString().Trim().Equals("x"))
                    {
                        iType = 1;
                    }
                    else
                    {
                        if (dt.Rows[i][4].ToString().Trim().Equals("x"))
                        {
                            iType = 2;
                        }
                        else
                        {
                            if (dt.Rows[i][5].ToString().Trim().Equals("x"))
                            {
                                iType = 3;
                            }
                            else
                            {
                                if (dt.Rows[i][6].ToString().Trim().Equals("x"))
                                {
                                    iType = 4;
                                }
                                else
                                {
                                    if (dt.Rows[i][7].ToString().Trim().Equals("x"))
                                    {
                                        iType = 5;
                                    }
                                    else
                                    {
                                        if (dt.Rows[i][8].ToString().Trim().Equals("x"))
                                        {
                                            iType = 6;
                                        }
                                        else
                                            iType = 7;
                                    }
                                }
                            }
                        }
                    }
                    //Insert du lieu
                    nuce.web.data.Nuce_Survey.InsertAS_Academy_Subject_Extent(strCode, strName, iType);
                }
            }
            MessageBox.Show("Thanh cong!");
        }

        private void btnSynDGGV_dong_bo_lop_mon_hoc_hien_tai_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtToDK = sv.getAllToDK1();
            // string strSql = "TRUNCATE TABLE AS_Academy_C_ClassRoom;";
            //string strSql = "TRUNCATE TABLE AS_Academy_ClassRoom;";
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            for (int i = 0; i < dtToDK.Rows.Count; i++)
            {
                string subjectCode = dtToDK.Rows[i]["MaMH"].ToString().Trim();
                string Code = dtToDK.Rows[i]["MaDK"].ToString().Trim();
                string GroupCode = dtToDK.Rows[i]["MaNh"].ToString().Trim();
                string ClassCode = dtToDK.Rows[i]["Malop"].ToString().Trim();
                string ExamAttemptDate = dtToDK.Rows[i]["Malop"].ToString().Trim();
                //nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_C_ClassRoom(1, Code, GroupCode, ClassCode, subjectCode, ExamAttemptDate);
                nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_ClassRoom(1, Code, GroupCode, ClassCode, subjectCode, ExamAttemptDate);
            }
            MessageBox.Show("OK");
        }

        private void btnSynDGGV_dong_bo_sinh_vien_lop_hoc_hien_tai_Click(object sender, EventArgs e)
        {
            //string strSql = "TRUNCATE TABLE [AS_Academy_C_Student_ClassRoom];";
            //string strSql = "TRUNCATE TABLE [AS_Academy_Student_ClassRoom];";
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            int page = 0;
            int pageSize = 1000;
            string strText = "";
            while (true)
            {
                DataTable dtKQDK = sv.getKQDK(page * pageSize + 1, (page + 1) * pageSize);
                if (dtKQDK.Rows.Count > 0)
                {
                    strText = strText + string.Format("---{0}---{1}", page, dtKQDK.Rows.Count);
                    for (int i = 0; i < dtKQDK.Rows.Count; i++)
                    {
                        string strMaSV = dtKQDK.Rows[i]["MaSV"].ToString().Trim();
                        string strMaDK = dtKQDK.Rows[i]["MaDK"].ToString().Trim();
                        // nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_C_Student_ClassRoom(1, strMaSV, strMaDK);
                        nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_Student_ClassRoom(1, strMaSV, strMaDK);
                    }
                    page++;
                }
                else
                    break;
            }
            MessageBox.Show(strText);

        }

        private void btnCap_nhat_lop_hoc_giang_vien_hien_tai_Click(object sender, EventArgs e)
        {
            frmLecturerClassRoom frm = new frmLecturerClassRoom();
            frm.Show();
        }

        private void btnDong_bo_cap_nhat_lop_mon_hoc_hien_tai_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtTKB = sv.getAllTKB1JoinToDk();
            DateTime dtNgayBatDau = DateTime.Parse("2019-08-05");
            // Quet tat ca ngay thang
            for (int i = 0; i < dtTKB.Rows.Count; i++)
            {
                string strMaKD = dtTKB.Rows[i]["MaDK"].ToString();
                string TuanHoc = dtTKB.Rows[i]["TuanHoc"].ToString();
                DateTime Ngaytg = DateTime.Now.AddYears(1);
                DateTime NgayBD = DateTime.Now.AddYears(1);
                DateTime NgayKT = DateTime.Now.AddYears(-1);
                for (int j = 0; j < TuanHoc.Length; j++)
                {
                    if (TuanHoc[j].ToString().Trim().Replace(" ", "") != "")
                    {
                        //Ngaytg = dtNgayBatDau.AddDays((j + 20) * 7);
                        Ngaytg = dtNgayBatDau.AddDays(j * 7);
                        if (Ngaytg < NgayBD)
                            NgayBD = Ngaytg;
                            NgayKT = Ngaytg;
                    }
                }
                nuce.web.data.Nuce_DanhGiaGiangVien.UpdateAcademy_C_ClassRoom_FEDate(strMaKD, NgayBD, NgayKT);
            }
            MessageBox.Show("OK");
        }

        private void btnCap_nhat_Tuan_lop_mon_hoc_hien_tai_Click(object sender, EventArgs e)
        {
            string strSql = "TRUNCATE TABLE [AS_Edu_QA_Week];";
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            //GetDuLieuCua LopMonHoc
            DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getAS_Academy_C_ClassRoomWithFromDateNotNull();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int iID = int.Parse(dt.Rows[i]["ID"].ToString());
                DateTime FromDate = DateTime.Parse(dt.Rows[i]["FromDate"].ToString());
                DateTime EndDate = DateTime.Parse(dt.Rows[i]["EndDate"].ToString());
                int count = 0;
                int total = ((EndDate - FromDate).Days / 7) + 1;
                for (int j = 1; j < total + 1; j++)
                {
                    nuce.web.data.Nuce_DanhGiaGiangVien.UpdateAS_Edu_QA_Week(iID, j, total, FromDate, FromDate.AddDays(7));
                    FromDate = FromDate.AddDays(7);
                }
            }
            MessageBox.Show("thanh cong");
        }

        private void btnCapNhatTenKSATHANH_Click(object sender, EventArgs e)
        {
            using (SqlConnection objConnection = nuce.web.data.Nuce_Survey.GetConnection())
            {
                if (objConnection == null)
                    MessageBox.Show("khong ton tai ket noi");
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"select * from AS_Edu_Survey_Ext_BaiLam");
                    DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, CommandType.Text, strSql).Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string name = dt.Rows[i]["Name"].ToString();
                        string ID = dt.Rows[i]["ID"].ToString();
                        string ten = "xxxxxx";
                        name = name.Trim();
                        if (name != "")
                        {
                            string[] strSplits = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (strSplits.Length > 0)
                            {
                                ten = strSplits[strSplits.Length - 1];
                            }
                        }
                        //Cap nhat
                        strSql = string.Format(@"update AS_Edu_Survey_Ext_BaiLam SET Ten = N'{0}' where [ID]={1}", ten, ID);
                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, CommandType.Text, strSql);
                    }
                    MessageBox.Show("Thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnKiemTraChiTiet_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            #region Lich thi

            // Dong bo lich thi
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("fr-FR");
            string dtformat = "dd/MM/yyyy";
            DataTable dtLichThi = sv.getLichThi("PM");
            for (int i = 0; i < dtLichThi.Rows.Count; i++)
            {
                // Insert vao bang dang ki va danh dau log

                DateTime Ngay = DateTime.ParseExact(dtLichThi.Rows[i]["NgayThi"].ToString(), dtformat, provider);
                if (Ngay > DateTime.Now.AddDays(2) && Ngay < DateTime.Now.AddDays(4))
                {
                    int test = 1;
                }
                // }

            }
            DataTable dtTKB = sv.getTKB("May");
            for (int i = 0; i < dtTKB.Rows.Count; i++)
            {
                // Insert vao bang dang ki va danh dau log

                DateTime Ngay = DateTime.ParseExact(dtLichThi.Rows[i]["NgayThi"].ToString(), dtformat, provider);
                if (Ngay > DateTime.Now.AddDays(-2) && Ngay < DateTime.Now.AddDays(2))
                {
                    int test = 1;
                }
                // }

            }
            #endregion
            MessageBox.Show("Thanh cong");
        }

        private void btn_svtruockhitotnghiep_capnhatmatkhau_Click(object sender, EventArgs e)
        {
            // Lay du lieu cac sinh vien dinh cap nhat

            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    MessageBox.Show("khong ton tai ket noi");
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"select ex_masv from  [dbo].[dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien]
where dottotnghiep='62019'");

                    DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, CommandType.Text, strSql).Tables[0];
                    string strInput = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strInput = strInput + "'" + dt.Rows[i]["ex_masv"].ToString() + "',";
                    }
                    strInput = strInput + "'xxxxxx'";
                    vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
                    DataTable dtTKB = sv.getAllTKB1JoinToDk();
                    DataTable dtSource = sv.getMatKhauNguoiDung(strInput);
                    strSql = "";
                    for (int i = 0; i < dtSource.Rows.Count; i++)
                    {
                        strSql = strSql + string.Format(@"UPDATE [dbo].[dnn_Nuce_Eduweb_sv_pass]
   SET pass = '{1}'
 WHERE masv = '{0}' ;", dtSource.Rows[i]["MaND"].ToString(), dtSource.Rows[i]["MatKhau"].ToString());
                    }
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, CommandType.Text, strSql);
                    MessageBox.Show(strSql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void btn_dong_bo_bo_mon_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtBoMon = sv.getBoMon();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Faculty;";
            DataTable dtKhoa = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            MessageBox.Show(dtKhoa.Rows.Count.ToString());
            MessageBox.Show(dtBoMon.Rows.Count.ToString());
            strSql = "TRUNCATE TABLE AS_Academy_Department;";
            string strCode = "";
            string strName = "";
            string strTruongBM = "";
            int KhoaID = -1;
            string strMaKhoa = "";

            for (int i = 0; i < dtBoMon.Rows.Count; i++)
            {
                //Lay tung bo mon
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtBoMon.Rows[i]["MaBM"].ToString(); strName = dtBoMon.Rows[i]["TenBM"].ToString();
                strTruongBM = dtBoMon.Rows[i]["TruongBM"].ToString(); strMaKhoa = dtBoMon.Rows[i]["MaKH"].ToString(); KhoaID = -1;
                for (int j = 0; j < dtKhoa.Rows.Count; j++)
                {
                    if (dtKhoa.Rows[j]["Code"].ToString().Equals(strMaKhoa))
                    {
                        KhoaID = int.Parse(dtKhoa.Rows[j]["ID"].ToString());
                    }
                }
                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Department]
                                           ([SemesterID],[Code],[Name],[FacultyID],[FacultyCode],[ChefsDepartmentCode])VALUES
                                           (1,'{0}',N'{1}',{2},'{3}','{4}');", strCode, strName, KhoaID, strMaKhoa, strTruongBM);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDongBoMonHoc_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtMonHoc = sv.getMonHoc();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Department;";
            DataTable dtBoMon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            strSql = "TRUNCATE TABLE AS_Academy_Subject;";
            string strCode = "";
            string strName = "";
            int BoMonID = -1;
            string strMaBoMon = "";
            for (int i = 0; i < dtMonHoc.Rows.Count; i++)
            {
                //Lay tung mon hoc
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtMonHoc.Rows[i]["MaMH"].ToString(); strName = dtMonHoc.Rows[i]["TenMH"].ToString().Replace("'","");
                strMaBoMon = dtMonHoc.Rows[i]["MaBM"].ToString(); BoMonID = -1;
                for (int j = 0; j < dtBoMon.Rows.Count; j++)
                {
                    if (dtBoMon.Rows[j]["Code"].ToString().Equals(strMaBoMon))
                    {
                        BoMonID = int.Parse(dtBoMon.Rows[j]["ID"].ToString());
                    }
                }
                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Subject] ([SemesterID],[Code],[Name],[DepartmentID],[DepartmentCode]) VALUES (1,'{0}',N'{1}',{2},'{3}');", strCode, strName, BoMonID, strMaBoMon);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDong_bo_nganh_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtNganh = sv.getNganh();
            //Lay du lieu cua bang
            string strSql = "";
            strSql = "TRUNCATE TABLE AS_Academy_Academics;";
            string strCode = "";
            string strName = "";
            for (int i = 0; i < dtNganh.Rows.Count; i++)
            {
                //Lay tung nganh
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtNganh.Rows[i]["MaNg"].ToString(); strName = dtNganh.Rows[i]["TenNg"].ToString().Replace("'", "");
                
                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Academics]([SemesterID],[Code],[Name]) VALUES (1,'{0}',N'{1}');", strCode, strName);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDong_bo_lop_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtLop = sv.getLop();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Academics;";
            DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
             strSql = "select * from AS_Academy_Faculty;";
            DataTable dtKhoa = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            strSql = "TRUNCATE TABLE AS_Academy_Class;";
            string strCode = "";
            string strName = "";
            string strNienKhoa = "";
            int KhoaID = -1;
            string strMaKhoa = "";
            int NganhID = -1;
            string strMaNganh = "";

            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                //Lay tung lop
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtLop.Rows[i]["MaLop"].ToString(); strName = dtLop.Rows[i]["TenLop"].ToString();
                strNienKhoa = dtLop.Rows[i]["NienKhoa"].ToString(); strMaKhoa = dtLop.Rows[i]["MaKH"].ToString(); KhoaID = -1;
                strMaNganh = dtLop.Rows[i]["MaNg"].ToString();NganhID = -1;
                for (int j = 0; j < dtKhoa.Rows.Count; j++)
                {
                    if (dtKhoa.Rows[j]["Code"].ToString().Equals(strMaKhoa))
                    {
                        KhoaID = int.Parse(dtKhoa.Rows[j]["ID"].ToString());
                    }
                }
                for (int j = 0; j < dtNganh.Rows.Count; j++)
                {
                    if (dtNganh.Rows[j]["Code"].ToString().Equals(strMaNganh))
                    {
                        NganhID = int.Parse(dtNganh.Rows[j]["ID"].ToString());
                    }
                }
                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Class]([Code],[Name],[FacultyID],[FacultyCode],[AcademicsID],[AcademicsCode],[SchoolYear]) VALUES (
'{0}',N'{1}',{2},'{3}',{4},'{5}','{6}') ;", strCode, strName, KhoaID, strMaKhoa, NganhID,strMaNganh,strNienKhoa);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDong_bo_giang_vien_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtCanBo = sv.getAllCanBo();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Department;";
            DataTable dtBoMon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            strSql = "TRUNCATE TABLE AS_Academy_Lecturer;";
            string strCode = "";
            string strName = "";
            int BoMonID = -1;
            string strMaBoMon = "";
            for (int i = 0; i < dtCanBo.Rows.Count; i++)
            {
                //Lay tung mon hoc
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtCanBo.Rows[i]["MaCB"].ToString(); strName = dtCanBo.Rows[i]["TenCB"].ToString().Replace("'", "");
                strMaBoMon = dtCanBo.Rows[i]["MaBM"].ToString(); BoMonID = -1;
                for (int j = 0; j < dtBoMon.Rows.Count; j++)
                {
                    if (dtBoMon.Rows[j]["Code"].ToString().Equals(strMaBoMon))
                    {
                        BoMonID = int.Parse(dtBoMon.Rows[j]["ID"].ToString());
                    }
                }
                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Lecturer]
           ([Code]
           ,[FullName]
           ,[DepartmentID]
           ,[DepartmentCode]
           ,[DateOfBirth]
           ,[NameOrder]
           ,[Email])
             VALUES ('{0}',N'{1}',{2},'{3}','1/1/1990',1,' ');", strCode, strName, BoMonID, strMaBoMon);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDong_bo_sinh_vien_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtSV = sv.getSinhVien();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Class;";
            DataTable dtLop = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            strSql = "TRUNCATE TABLE AS_Academy_Student;";
            string strCode = "";
            string strName = "";
            int LopID = -1;
            string strMaLop = "";
            string DateOfBirth = "";
            string BirthPlace = "";
            string Email = "";
            string Mobile = "";
            for (int i = 0; i < dtSV.Rows.Count; i++)
            {
                //Lay tung mon hoc
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtSV.Rows[i]["MaSV"].ToString(); strName = dtSV.Rows[i]["HoTenSV"].ToString().Replace("'", "");
                strMaLop = dtSV.Rows[i]["Malop"].ToString(); LopID = -1;
                for (int j = 0; j < dtLop.Rows.Count; j++)
                {
                    if (dtLop.Rows[j]["Code"].ToString().Equals(strMaLop))
                    {
                        LopID = int.Parse(dtLop.Rows[j]["ID"].ToString());
                    }
                }
                DateOfBirth = dtSV.Rows[i]["NgaySinh"].ToString().Replace("'", ""); ;
                BirthPlace = dtSV.Rows[i]["noisinh"].ToString().Replace("'", "");
                Email = dtSV.Rows[i]["EmailSV1"].ToString().Replace("'", "");
                Mobile = dtSV.Rows[i]["TelSV2"].ToString().Replace("'", "");

                strSql += string.Format(@"INSERT INTO [dbo].[AS_Academy_Student]
           ([Code]
           ,[FulName]
           ,[ClassID]
           ,[ClassCode]
           ,[DateOfBirth]
           ,[BirthPlace]
           ,[Email]
           ,[Mobile]
           ,[keyAuthorize]
           ,[status])
     VALUES ('{0}',N'{1}',{2},N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',{9});", strCode, strName, LopID, strMaLop, DateOfBirth, BirthPlace, Email,Mobile,Guid.NewGuid(),1);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnDong_bo_lop_mon_hoc_giang_vien_hien_tai_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtTkb1JoinToDk1 = sv.getAllTKB1JoinToDk();
            //Duyet qua tung ban ghi
            #region Xu ly chuan hoa du lieu 
            DataTable dtTkb1JoinToDk1V1 = new DataTable();
            dtTkb1JoinToDk1V1.Columns.Add("MaDK");
            dtTkb1JoinToDk1V1.Columns.Add("MaCB");
            dtTkb1JoinToDk1V1.Columns.Add("Thu");
            dtTkb1JoinToDk1V1.Columns.Add("TietDB");
            dtTkb1JoinToDk1V1.Columns.Add("SoTiet");
            dtTkb1JoinToDk1V1.Columns.Add("MaPH");
            dtTkb1JoinToDk1V1.Columns.Add("TuanHoc");
            dtTkb1JoinToDk1V1.Columns.Add("MaMH");
            for (int i = 0; i < dtTkb1JoinToDk1.Rows.Count; i++)
            {
                DataRow dr = dtTkb1JoinToDk1V1.NewRow();
                dr["MaDK"] = dtTkb1JoinToDk1.Rows[i]["MaDK"].ToString().Trim();
                dr["MaCB"] = dtTkb1JoinToDk1.Rows[i]["MaCB"].ToString().Trim();
                string Thu = dtTkb1JoinToDk1.Rows[i]["Thu"].ToString();
                dr["TietDB"] = dtTkb1JoinToDk1.Rows[i]["TietDB"].ToString().Trim();
                dr["SoTiet"] = dtTkb1JoinToDk1.Rows[i]["SoTiet"].ToString().Trim();
                dr["MaMH"] = dtTkb1JoinToDk1.Rows[i]["MaMH"].ToString().Trim();


                if (!string.IsNullOrWhiteSpace(Thu))
                    Thu = Thu.Trim();
                dr["Thu"] = Thu;
                string TuanHoc = dtTkb1JoinToDk1.Rows[i]["TuanHoc"].ToString();
                if (!string.IsNullOrWhiteSpace(TuanHoc))
                    TuanHoc = TuanHoc.Trim();
                dr["TuanHoc"] = TuanHoc;
                string MaPH = dtTkb1JoinToDk1.Rows[i]["MaPH"].ToString();
                if (!string.IsNullOrWhiteSpace(MaPH))
                {
                    MaPH = MaPH.Trim();
                    if (!MaPH.Equals("XMH"))
                    {
                        string[] roomArr = new string[2];

                        if (MaPH.Contains(" "))
                            roomArr = MaPH.Split(' ').ToArray();
                        else if (MaPH.Contains("."))
                            roomArr = MaPH.Split('.').ToArray();
                        else if (MaPH.Contains("-"))
                            roomArr = MaPH.Split('-').ToArray();
                        else if (MaPH.Contains("_"))
                            roomArr = MaPH.Split('_').ToArray();
                        else
                        {
                            roomArr[0] = MaPH;
                            roomArr[1] = "";
                        }
                        //throw new ArgumentException("TKB chứa ký tự không hợp lệ : " + JsonConvert.SerializeObject(sched));

                        if (!roomArr[0].All(Char.IsDigit)) // VD H1.101
                        {
                            MaPH = string.Concat(roomArr[1], ".", roomArr[0]); // => 101.H1
                        }
                    }
                }
                dr["MaPH"] = MaPH;
                dtTkb1JoinToDk1V1.Rows.Add(dr);
            }
            #endregion
            #region Xu ly chuan hoa du lieu dien thong tin them vao giang vien
            DataTable dtTkb1JoinToDk1V2 = new DataTable();
            dtTkb1JoinToDk1V2.Columns.Add("MaDK");
            dtTkb1JoinToDk1V2.Columns.Add("MaCB");
            dtTkb1JoinToDk1V2.Columns.Add("Thu");
            dtTkb1JoinToDk1V2.Columns.Add("TietDB");
            dtTkb1JoinToDk1V2.Columns.Add("SoTiet");
            dtTkb1JoinToDk1V2.Columns.Add("MaPH");
            dtTkb1JoinToDk1V2.Columns.Add("TuanHoc");
            dtTkb1JoinToDk1V2.Columns.Add("MaMH");
            for (int i = 0; i < dtTkb1JoinToDk1V1.Rows.Count; i++)
            {
                DataRow dr = dtTkb1JoinToDk1V2.NewRow();
                dr["MaDK"] = dtTkb1JoinToDk1V1.Rows[i]["MaDK"].ToString();
                string Thu = dtTkb1JoinToDk1V1.Rows[i]["Thu"].ToString();
                dr["Thu"] = Thu;
                string TietDB = dtTkb1JoinToDk1V1.Rows[i]["TietDB"].ToString();
                dr["TietDB"] = TietDB;
                dr["SoTiet"] = dtTkb1JoinToDk1V1.Rows[i]["SoTiet"].ToString();
                string MaPH = dtTkb1JoinToDk1V1.Rows[i]["MaPH"].ToString();
                dr["MaPH"] = MaPH;
                string TuanHoc = dtTkb1JoinToDk1V1.Rows[i]["TuanHoc"].ToString();
                dr["TuanHoc"] = TuanHoc;
                string MaMH = dtTkb1JoinToDk1V1.Rows[i]["MaMH"].ToString();
                dr["MaMH"] = MaMH;
                //dr["MaCB"] = dtTkb1JoinToDk1V1.Rows[i]["MaCB"].ToString();
                string strMaCB = dtTkb1JoinToDk1V1.Rows[i]["MaCB"].ToString();
                if (string.IsNullOrWhiteSpace(strMaCB))
                {
                    //Xu ly tim can bo tuong ung va co ma can bo khac trang
                    dr["MaCB"] = getCanBoTrongLopGhepTuongUng(dtTkb1JoinToDk1V1, MaMH,
                        Thu, TietDB, MaPH, TuanHoc);
                }
                else
                    dr["MaCB"] = strMaCB;
                dtTkb1JoinToDk1V2.Rows.Add(dr);
            }
            #endregion
            #region xu ly chen vao csdl
            //string strSql = "TRUNCATE TABLE AS_Academy_C_Lecturer_ClassRoom;";
            //Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            for (int i = 0; i < dtTkb1JoinToDk1V2.Rows.Count; i++)
            {
                string strMaDK = dtTkb1JoinToDk1V2.Rows[i]["MaDK"].ToString();
                string strMaCB = dtTkb1JoinToDk1V2.Rows[i]["MaCB"].ToString();
                if (!string.IsNullOrWhiteSpace(strMaDK) &&
                    !string.IsNullOrWhiteSpace(strMaCB))
                {
                    //nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_C_Lecturer_ClassRoom(strMaDK, strMaCB, 1);
                    nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_Lecturer_ClassRoom(strMaDK, strMaCB, 1);
                }
            }
            #endregion
            MessageBox.Show("So ban ghi lay thu tu webservice" + dtTkb1JoinToDk1V1.Rows.Count.ToString());
            //DataTable dtTemp = nuce.web.data.Nuce_Survey.getAcademy_Class();
            //MessageBox.Show("So ban ghi lay thu Database Survey" + dtTemp.Rows.Count.ToString());
        }

        private void btnLichPhongMay_DongBoLichThi_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            int hockyid = -1;
            int namhocid = -1;
            DataTable dtNamHoc = nuce.web.data.dnn_NuceCommon_NamHoc1.getByStatus(1);
            DateTime dtNgayBatDau = DateTime.Parse(dtNamHoc.Rows[0]["NgayBatDau"].ToString());
            // Lay tat ca log de check
            DataTable dtLog = nuce.web.data.dnn_NuceQLPM_Log_Syn1.getByType(1, 3);
            // Lay ta ca cac du lieu ve can bo
            DataTable dtCanBo = sv.getCanBo("May");
            // Lay danh sach phòng máy
            DataTable dtPhongMay = nuce.web.data.dnn_NuceCommon_PhongHoc1.get(-1);
            // Lay ca hoc
            DataTable dtCaHoc = nuce.web.data.dnn_NuceCommon_CaHoc1.get(-1);
            // Duyệt qua tất cả các danh sách
            // Get Mon học
            DataTable dtMonHoc = sv.getMonHoc();
            string MaDK;
            string MaCB;
            string HoVaTenCB;
            string Lop;
            string MonHoc;
            string Thu;
            int iThu;
            string TietBD;
            string SoTiet;
            string MaPH;
            int PhongHocID;
            int BuoiHoc;
            string TuanHoc;
            DateTime Ngay;
            int CahocID;
            int HocKyID;
            int NamHocID;
            int SoSinhVien;
            string TTThemCB;
            string MoTa;
            string GhiChu;
            string Key;
            DataRow drThongTinLop;
            string[] tuans;

            #region Lich thi

            // Dong bo lich thi
            CultureInfo provider = CultureInfo.InvariantCulture;
            provider = new CultureInfo("fr-FR");
            string dtformat = "dd/MM/yyyy";
            DataTable dtLichThi = sv.getLichThi("PM");
            DataTable dtLogThi = nuce.web.data.dnn_NuceQLPM_Log_Syn1.getByType(2, 3);
            for (int i = 0; i < dtLichThi.Rows.Count; i++)
            {
                Key = dtLichThi.Rows[i]["KeyThi"].ToString();
                // if (!checkExists(dtLogThi, Key))
                // {
                MaDK = dtLichThi.Rows[i]["KeyThi"].ToString().Replace(" ", "");
                MaCB = "";
                HoVaTenCB = "";

                Lop = dtLichThi.Rows[i]["GhepThi"].ToString().Replace(" ", "");
                MonHoc = getMonHocByTableMonHoc(dtMonHoc, dtLichThi.Rows[i]["MaMH"].ToString().Replace(" ", ""));


                Thu = "";
                //iThu = int.Parse(Thu.Trim());
                TietBD = dtLichThi.Rows[i]["TietBD"].ToString();
                SoTiet = dtLichThi.Rows[i]["SoTiet"].ToString();
                MaPH = dtLichThi.Rows[i]["MaPh"].ToString();
                PhongHocID = getPhong(dtPhongMay, MaPH);
                BuoiHoc = int.Parse(dtLichThi.Rows[i]["DotThi"].ToString());
                TuanHoc = "";
                #region Xu ly tuan hoc

                #endregion
                CahocID = getCaHoc(dtCaHoc, TietBD);
                SoSinhVien = int.Parse(dtLichThi.Rows[i]["SoLuong"].ToString());
                TTThemCB = "";
                MoTa = "";
                GhiChu = "---Dong bo lich thi" + MaDK + "-" + Lop + "-" + MonHoc + "-" + HoVaTenCB + "---";
                // Insert vao bang dang ki va danh dau log

                Ngay = DateTime.ParseExact(dtLichThi.Rows[i]["NgayThi"].ToString(), dtformat, provider);
                if (Ngay > DateTime.Now.AddDays(-3))
                {
                    // Cap nhat vao csdl
                    Thu = ((int)Ngay.DayOfWeek + 1).ToString();

                    DataTable dtTest = nuce.web.data.dnn_NuceQLPM_LichPhongMay1.getByNgayCaPhong(Ngay, CahocID, PhongHocID);
                    if (dtTest != null)
                    {
                        if (dtTest.Rows.Count > 0)
                        {
                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.deleteByNgayCaPhong(Ngay, CahocID, PhongHocID);
                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, 2, 1);
                        }
                        else
                        {
                            try
                            {
                                nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, 2, 1);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, 2, 1);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    try
                    {
                        // nuce.web.data.dnn_NuceQLPM_LichPhongMay1.NuceQLPM_LichPhongMay_UpdateDangKi(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc,Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichThi, 1);
                    }
                    catch (Exception ex)
                    {

                    }

                    // Danh dau da duyet
                    try
                    {
                        // nuce.web.data.dnn_NuceQLPM_Log_Syn1.Insert(Key, 3, Utils.synTypeLichThi, "Dong bo thanh cong lich thi");
                    }
                    catch (Exception ex)
                    {

                    }
                }
                // }

            }

            #endregion
            MessageBox.Show("Thanh cong");
        }

        private void btnDongBoLichKyNay_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            int hockyid = -1;
            int namhocid = -1;
            // Lay nam hoc
            DataTable dtNamHoc = nuce.web.data.dnn_NuceCommon_NamHoc1.getByStatus(1);
            DateTime dtNgayBatDau = DateTime.Parse(dtNamHoc.Rows[0]["NgayBatDau"].ToString());
            // Lấy tất cả danh sách phòng máy
            DataTable dtTKB = sv.getTKB("May");
            //DataTable dtTKB = sv.getTKB_bangkytruoc("May");
            // Lay To Dang ki
            DataTable dtToDK = sv.getToDK("May");
            //DataTable dtToDK = sv.getToDK_bangkytruoc("May");
            // Lay tong so sinh vien dang ki
            DataTable dtTongSoSVDK = sv.getTongSoSVDK("May");
            //DataTable dtTongSoSVDK = sv.getTongSoSVDK_bangkytruoc("May");
            // Lay tat ca log de check
            DataTable dtLog = nuce.web.data.dnn_NuceQLPM_Log_Syn1.getByType(1, 3);
            // Lay ta ca cac du lieu ve can bo
            DataTable dtCanBo = sv.getCanBo("May");
            // Lay danh sach phòng máy
            DataTable dtPhongMay = nuce.web.data.dnn_NuceCommon_PhongHoc1.get(-1);
            // Lay ca hoc
            DataTable dtCaHoc = nuce.web.data.dnn_NuceCommon_CaHoc1.get(-1);
            // Duyệt qua tất cả các danh sách
            // Get Mon học
            DataTable dtMonHoc = sv.getMonHoc();
            string MaDK;
            string MaCB;
            string HoVaTenCB;
            string Lop;
            string MonHoc;
            string Thu;
            int iThu;
            string TietBD;
            string SoTiet;
            string MaPH;
            int PhongHocID;
            int BuoiHoc;
            string TuanHoc;
            DateTime Ngay;
            int CahocID;
            int HocKyID;
            int NamHocID;
            int SoSinhVien;
            string TTThemCB;
            string MoTa;
            string GhiChu;
            string Key;
            DataRow drThongTinLop;
            string[] tuans;

            for (int i = 0; i < dtTKB.Rows.Count; i++)
            {
                Key = dtTKB.Rows[i]["keytohop"].ToString();
                if (!checkExists(dtLog, Key))
                {
                    MaDK = dtTKB.Rows[i]["MaDK"].ToString();
                    MaCB = dtTKB.Rows[i]["MaCB"].ToString();
                    HoVaTenCB = getHoVaTenCB(dtCanBo, MaCB);
                    drThongTinLop = getThongTinLopHoc(dtToDK, MaDK);
                    if (drThongTinLop != null)
                    {
                        Lop = drThongTinLop["MaNh"].ToString();
                        MonHoc = drThongTinLop["TenMH"].ToString();
                    }
                    else
                    {
                        Lop = "";
                        MonHoc = "";
                    }
                    Thu = dtTKB.Rows[i]["Thu"].ToString();
                    iThu = int.Parse(Thu.Trim());
                    TietBD = dtTKB.Rows[i]["TietBD"].ToString();
                    SoTiet = dtTKB.Rows[i]["SoTiet"].ToString();
                    MaPH = dtTKB.Rows[i]["MaPH"].ToString();
                    PhongHocID = getPhong(dtPhongMay, MaPH);
                    BuoiHoc = int.Parse(dtTKB.Rows[i]["BuoiHoc"].ToString());
                    TuanHoc = dtTKB.Rows[i]["TuanHoc"].ToString();
                    #region Xu ly tuan hoc

                    #endregion
                    CahocID = getCaHoc(dtCaHoc, TietBD);
                    SoSinhVien = getSoSinhVien(dtTongSoSVDK, MaDK);
                    TTThemCB = "";
                    MoTa = "";
                    GhiChu = "---Dong bo " + MaDK + "-" + Lop + "-" + MonHoc + "-" + HoVaTenCB + "---";
                    // Insert vao bang dang ki va danh dau log
                    for (int j = 0; j < TuanHoc.Length; j++)
                    {
                        if (TuanHoc[j].ToString().Trim().Replace(" ", "") != "")
                        {

                            Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 19) * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + j * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 39) * 7);
                            //Ngay = dtNgayBatDau.AddDays(iThu - 2 + (j + 45) * 7);
                            if (MaCB.Equals("8683"))
                            {
                                int test000 = 000;
                            }

                            if (Ngay > DateTime.Now && Ngay < DateTime.Now.AddDays(7))
                            {
                                int test = 1;
                            }
                            // Cap nhat vao csdl
                            try
                            {
                                if (Ngay >= DateTime.Now.AddDays(-1))
                                {
                                    DataTable dtTest = nuce.web.data.dnn_NuceQLPM_LichPhongMay1.getByNgayCaPhong(Ngay, CahocID, PhongHocID);
                                    if (dtTest != null)
                                    {
                                        if (dtTest.Rows.Count > 0)
                                        {
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.deleteByNgayCaPhong(Ngay, CahocID, PhongHocID);
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                            }
                                            catch (Exception ex)
                                            {

                                            }
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            nuce.web.data.dnn_NuceQLPM_LichPhongMay1.Insert(MaDK, MaCB, HoVaTenCB, Lop, MonHoc, Thu, TietBD, SoTiet, MaPH, PhongHocID, BuoiHoc, TuanHoc, Ngay, CahocID, hockyid, namhocid, SoSinhVien, TTThemCB, MoTa, GhiChu, Utils.synTypeLichHoc, 1);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }

                                }

                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                    // Danh dau da duyet
                    try
                    {
                        //nuce.web.data.dnn_NuceQLPM_Log_Syn1.Insert(Key, 3, Utils.synTypeLichHoc, "Dong bo thanh cong lich hoc");
                    }
                    catch (Exception ex)
                    {

                    }
                }

            }
        }

        private void btnCapNhatNganh_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtNganh = sv.getNganh();
            //Lay du lieu cua bang
            string strSql = "";
            //strSql = "TRUNCATE TABLE AS_Academy_Academics;";
            string strCode = "";
            string strName = "";
            for (int i = 0; i < dtNganh.Rows.Count; i++)
            {
                //Lay tung nganh
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtNganh.Rows[i]["MaNg"].ToString(); strName = dtNganh.Rows[i]["TenNg"].ToString().Replace("'", "");

                strSql += string.Format(@"if(not exists(select code from dbo.AS_Academy_Academics where code='{0}'))
Begin
INSERT INTO [dbo].[AS_Academy_Academics]([SemesterID],[Code],[Name]) VALUES (1,'{0}',N'{1}')
End
else
Begin
update 
	[dbo].[AS_Academy_Academics]
	set [Name]=N'{1}'
	where code='{0}'
End;", strCode, strName);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnCapNhatLop_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtLop = sv.getLop();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Academics;";
            DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            strSql = "select * from AS_Academy_Faculty;";
            DataTable dtKhoa = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            //strSql = "TRUNCATE TABLE AS_Academy_Class;";
            string strCode = "";
            string strName = "";
            string strNienKhoa = "";
            int KhoaID = -1;
            string strMaKhoa = "";
            int NganhID = -1;
            string strMaNganh = "";

            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                //Lay tung lop
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtLop.Rows[i]["MaLop"].ToString(); strName = dtLop.Rows[i]["TenLop"].ToString();
                strNienKhoa = dtLop.Rows[i]["NienKhoa"].ToString(); strMaKhoa = dtLop.Rows[i]["MaKH"].ToString(); KhoaID = -1;
                strMaNganh = dtLop.Rows[i]["MaNg"].ToString(); NganhID = -1;
                for (int j = 0; j < dtKhoa.Rows.Count; j++)
                {
                    if (dtKhoa.Rows[j]["Code"].ToString().Equals(strMaKhoa))
                    {
                        KhoaID = int.Parse(dtKhoa.Rows[j]["ID"].ToString());
                    }
                }
                for (int j = 0; j < dtNganh.Rows.Count; j++)
                {
                    if (dtNganh.Rows[j]["Code"].ToString().Equals(strMaNganh))
                    {
                        NganhID = int.Parse(dtNganh.Rows[j]["ID"].ToString());
                    }
                }
                strSql += string.Format(@"if(not exists(select code from [dbo].[AS_Academy_Class] where Code='{0}')) begin INSERT INTO [dbo].[AS_Academy_Class]([Code],[Name],[FacultyID],[FacultyCode],[AcademicsID],[AcademicsCode],[SchoolYear]) VALUES (
'{0}',N'{1}',{2},'{3}',{4},'{5}','{6}')  end; ", strCode, strName, KhoaID, strMaKhoa, NganhID, strMaNganh, strNienKhoa);
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
        }

        private void btnCapNhatSinhVien_Click(object sender, EventArgs e)
        {
            vn.edu.nuce.ktmt.Service sv = new vn.edu.nuce.ktmt.Service();
            DataTable dtSV = sv.getSinhVien();
            //Lay du lieu cua bang
            string strSql = "select * from AS_Academy_Class;";
            DataTable dtLop = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];

            strSql = "select Code from [dbo].[AS_Academy_Student]";

            DataTable dtSinhVien = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql).Tables[0];
            //strSql = "TRUNCATE TABLE AS_Academy_Student;";
            strSql = "";
            string strCode = "";
            string strName = "";
            int LopID = -1;
            string strMaLop = "";
            string DateOfBirth = "";
            string BirthPlace = "";
            string Email = "";
            string Mobile = "";
            string strEmailNhaTruong = "";
            string[] strSplitName;
            for (int i = 0; i < dtSV.Rows.Count; i++)
            //for (int i = 0; i < 10; i++)
            {
                //Lay tung mon hoc
                //Xu ly ghep cau insert
                //Thuc hien day du lieu vo csdl
                strCode = dtSV.Rows[i]["MaSV"].ToString();

                if (!checkExistsSV(dtSinhVien, strCode))
                {
                    strName = dtSV.Rows[i]["HoTenSV"].ToString().Replace("'", "");
                    strSplitName = strName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    strMaLop = dtSV.Rows[i]["Malop"].ToString(); LopID = -1;
                    for (int j = 0; j < dtLop.Rows.Count; j++)
                    {
                        if (dtLop.Rows[j]["Code"].ToString().Equals(strMaLop))
                        {
                            LopID = int.Parse(dtLop.Rows[j]["ID"].ToString());
                        }
                    }
                    DateOfBirth = dtSV.Rows[i]["NgaySinh"].ToString().Replace("'", ""); ;
                    BirthPlace = dtSV.Rows[i]["noisinh"].ToString().Replace("'", "");
                    Email = dtSV.Rows[i]["EmailSV1"].ToString().Replace("'", "");
                    Mobile = dtSV.Rows[i]["TelSV2"].ToString().Replace("'", "");
                    strEmailNhaTruong = string.Format("{0}{1}@nuce.edu.vn", Utils.RemoveUnicode(strSplitName[strSplitName.Length - 1].Trim()).ToLower(), strCode);

                    strSql += string.Format(@"if(not exists(select code from [dbo].[AS_Academy_Student] where Code='{0}')) Begin INSERT INTO [dbo].[AS_Academy_Student]
           ([Code]
           ,[FulName]
           ,[ClassID]
           ,[ClassCode]
           ,[DateOfBirth]
           ,[BirthPlace]
           ,[Email]
           ,[Mobile]
           ,[keyAuthorize]
           ,[status], EmailNhaTruong,DaXacThucEmailNhaTruong)
     VALUES ('{0}',N'{1}',{2},N'{3}',N'{4}',N'{5}',N'{6}',N'{7}',N'{8}',{9},N'{10}',1) End; ", strCode, strName, LopID, strMaLop, DateOfBirth, BirthPlace, Email, Mobile, Guid.NewGuid(), 1, strEmailNhaTruong);
                }
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_DanhGiaGiangVien.GetConnection(), CommandType.Text, strSql);
            MessageBox.Show("Thanh Cong !");
           // MessageBox.Show(strSql);
        }
        private bool checkExistsSV(DataTable dt,string strCode)
        {
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if (dt.Rows[i]["Code"].ToString() == strCode)
                    return true;
            }
            return false;
        }
    }

   
}
