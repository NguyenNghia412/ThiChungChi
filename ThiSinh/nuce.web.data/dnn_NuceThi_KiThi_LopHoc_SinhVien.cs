using System;
using System.Data;
using System.Data.SqlClient;

namespace nuce.web.data
{
    public static class dnn_NuceThi_KiThi_LopHoc_SinhVien
    {
        public static DataTable getBySinhVien(int SinhVienID)
        {
            SqlParameter[] param = {
                new SqlParameter("@SinhVienID", SinhVienID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_getBySinhVien", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_KiThi_LopHoc_SinhVien_getBySinhVien", SinhVienID).Tables[0];
        }
        public static DataTable get(int KiThi_LopHoc_SinhVienID)
        {
            SqlParameter[] param = {
                new SqlParameter("@KiThi_LopHoc_SinhVienID", KiThi_LopHoc_SinhVienID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_get", param).Tables[0];
        }
        public static void updateMoTa(int iID,  string mota)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@mota", mota),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_mota", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_mota", iID, mota);
        }
        public static void update_dethi(int iID, int DeThiID,string NoiDungDeThi,string DapAn,int TongThoiGianThi,int TongThoiGianConLai,string MaDe,string LogIP,int Status)
        {
            SqlParameter[] param = {
                new SqlParameter("@KiThi_LopHoc_SinhVienID", iID),
                new SqlParameter("@DeThiID", DeThiID),
                new SqlParameter("@NoiDungDeThi", NoiDungDeThi),
                new SqlParameter("@DapAn", DapAn),
                new SqlParameter("@TongThoiGianThi", TongThoiGianThi),
                new SqlParameter("@TongThoiGianConLai", TongThoiGianConLai),
                new SqlParameter("@MaDe", MaDe),
                new SqlParameter("@LogIP", LogIP),
                new SqlParameter("@Status", Status),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_dethi", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_dethi", iID, DeThiID, NoiDungDeThi, DapAn, TongThoiGianThi, TongThoiGianConLai, MaDe,LogIP,Status);
        }
        public static void update_bailam(int iID, string BaiLam, DateTime NgayGioBatDau, DateTime NgayGioNopBai, int TongThoiGianConLai,  string LogIP, int Status)
        {
            SqlParameter[] param = {
                new SqlParameter("@KiThi_LopHoc_SinhVienID", iID),
                new SqlParameter("@BaiLam", BaiLam),
                new SqlParameter("@NgayGioBatDau", NgayGioBatDau),
                new SqlParameter("@NgayGioNopBai", NgayGioNopBai),
                new SqlParameter("@TongThoiGianConLai", TongThoiGianConLai),
                new SqlParameter("@LogIP", LogIP),
                new SqlParameter("@Status", Status),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_bailam", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_bailam", iID, BaiLam, NgayGioBatDau,NgayGioNopBai, TongThoiGianConLai, LogIP, Status);
        }
        public static void update_bailam1(int iID, string BaiLam,float Diem, DateTime NgayGioBatDau, DateTime NgayGioNopBai, int TongThoiGianConLai, string LogIP, int Status)
        {
            SqlParameter[] param = {
                new SqlParameter("@KiThi_LopHoc_SinhVienID", iID),
                new SqlParameter("@BaiLam", BaiLam),
                new SqlParameter("@Diem", Diem),
                new SqlParameter("@NgayGioBatDau", NgayGioBatDau),
                new SqlParameter("@NgayGioNopBai", NgayGioNopBai),
                new SqlParameter("@TongThoiGianConLai", TongThoiGianConLai),
                new SqlParameter("@LogIP", LogIP),
                new SqlParameter("@Status", Status),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_bailam1", param);
        }
        public static void updateStatus(int iID, int status)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@status", status),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_status", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_mota", iID, mota);
        }
        public static void updateThoiGianConLai(int iID, int TongThoiGianConLai, DateTime NgayGioBatDau, DateTime NgayGioNopBai)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@TongThoiGianConLai", TongThoiGianConLai),
                new SqlParameter("@NgayGioNopBai", NgayGioNopBai),
                new SqlParameter("@NgayGioBatDau", NgayGioBatDau)
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_thoigianconlai", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_mota", iID, mota);
        }
        public static void updateThoiGianThiSinhThi(int iID, DateTime NgayGioBatDau, DateTime NgayGioNopBai)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@NgayGioNopBai", NgayGioNopBai),
                new SqlParameter("@NgayGioBatDau", NgayGioBatDau)
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_thoigian", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_KiThi_LopHoc_SinhVien_update_mota", iID, mota);
        }
        public static void updateNopBaiTuLuan(int iID, string BaiLam, string MaDe)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@BaiLam", BaiLam),
                new SqlParameter("@MaDe", MaDe)
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_KiThi_LopHoc_SinhVien_update_nopbaituluan", param);
        }
    }
}
