using System;

namespace nuce.web.model
{
   public class CaLopHocSinhVien
    {
        public int Ca_LopHoc_SinhVienID { get; set; }
        public int Ca_LopHocID { get; set; }
        public int SinhVienID { get; set; }
        public string Mac { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string TenMonHoc { get; set; }
        public string MaMonHoc { get; set; }
        public string TenCa { get; set; }
        public DateTime Ngay { get; set; }
        public int GioBatDau { get; set; }
        public int GioKetThuc { get; set; }
        public int PhutBatDau { get; set; }
        public int PhutKetThuc { get; set; }
    }

    public class UpdateStatusThiModel
    {
        public int id { get; set; }
        public int status { get; set; }
    }

    public class TemporaryTimeModel
    {
        public int KiThiID { get; set; }
        public int TongThoiGianConLai { get; set; }
        public DateTime NgayGioBatDau { get; set; }
        public DateTime NgayGioNopBai { get; set; }
    }
}
