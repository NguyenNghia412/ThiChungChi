using ClosedXML.Excel;
using Ionic.Zip;
using nuce.web.data;
using nuce.web.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web
{
    public partial class ExportZip : Page
    {
        protected override void OnInit(EventArgs e)
        {
            int iType = int.Parse(Request.QueryString["type"]);
            switch (iType)
            {
                case 1:
                    ProcessBaiTuLuan();
                    break;
            }
            base.OnInit(e);
        }
        private void ProcessBaiTuLuan()
        {
            string idPhongCaNgay = Request["IDPhongCaNgay"]?.ToString();
            string idKiThi = Request["IDKiThi"]?.ToString();
            string loaiDe = Convert.ToInt32(LoaiDe.TuLuan).ToString();
            #region lay thong tin phong thi, ca thi, ngay thi
            string sql = $@"SELECT pc.*, convert(varchar, pc.Ngaythi, 103) as NgayThiFormatted, p.TenPhong as PhongThi, c.TenCa as CaThi
                          from [NuceThi_PhongThi_CaThi] pc
                          left join [Nuce_thi_chung_chi].[dbo].[NuceThi_PhongThi] p on pc.phongthiid = p.id
                          left join [Nuce_thi_chung_chi].[dbo].[NuceThi_CaThi] c on pc.cathiid = c.id

                          where pc.id = {idPhongCaNgay}";
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];
            string NgayThi = dt.Rows[0]["NgayThiFormatted"]?.ToString();
            string PhongThi = dt.Rows[0]["PhongThi"]?.ToString();
            string CaThi = dt.Rows[0]["CaThi"]?.ToString();
            #endregion

            sql = $@"SELECT nt.ma, nt.Ho + ' ' + nt.Ten as HoTen, nt.CMT, nt.NoiSinh, convert(varchar, nt.ngaysinh, 103) as NgaySinh, nt.Mobile,
                            kls.made, kls.bailam, kls.KiThi_LopHoc_SinhVienID
                    FROM [Nuce_thi_chung_chi].[dbo].[NuceThi_KiThi_LopHoc_SinhVien] kls
                    left join Nuce_thichungchi_nguoithi nt on kls.sinhvienid = nt.id
                    left join nucethi_kithi kt on kt.KiThiID = kls.KiThi_LopHocID
                    left join nucethi_bode bd on kt.BoDeID = bd.BoDeID
                    where kls.phongthi_cathi_id = {idPhongCaNgay} and kls.[KiThi_LopHocID] = {idKiThi} and bd.LoaiDe = {loaiDe}";
            dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];

            if (dt.Rows.Count == 0)
            {
                Response.ContentType = "text/plain";
                Response.Write("Không có thí sinh nào.");
                return;
            }

            string UploadsFolder = ConfigurationManager.AppSettings["UploadsFolder"];
            List<string> dirs = new List<string>();
            Dictionary<string, string> ThiSinhMaDe = new Dictionary<string, string>();
            Dictionary<string, string> ThiSinhHash = new Dictionary<string, string>();
            Dictionary<string, string> ThiSinhMaBaiLam = new Dictionary<string, string>();
            Dictionary<string, ThiSinh> ThiSinhInfo = new Dictionary<string, ThiSinh>();
            // Bai Lam
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                string MaThiSinh = row["ma"]?.ToString();
                string MaDe = row["made"]?.ToString();
                string BaiLam = row["bailam"]?.ToString();
                string MaBaiLam = row["KiThi_LopHoc_SinhVienID"]?.ToString();
                string HoTen = row["HoTen"]?.ToString();
                string NgaySinh = row["NgaySinh"]?.ToString();
                string NoiSinh = row["NoiSinh"]?.ToString();
                string Mobile = row["Mobile"]?.ToString();
                string Cmt = row["CMT"]?.ToString();

                var tmpThiSinh = new ThiSinh()
                {
                    Ma = MaThiSinh,
                    HoTen = HoTen,
                    NgaySinh = NgaySinh,
                    NoiSinh = NoiSinh,
                    CMT = Cmt,
                    Mobile = Mobile,
                };

                if (!string.IsNullOrEmpty(BaiLam))
                {
                    BaiLam = Path.Combine(UploadsFolder, BaiLam);
                    dirs.Add(BaiLam);
                }

                ThiSinhMaDe.Add(MaThiSinh, MaDe);
                ThiSinhMaBaiLam.Add(MaThiSinh, MaBaiLam);
                ThiSinhInfo.Add(MaThiSinh, tmpThiSinh);
            }
            // File Thi sinh ma de
            string DanhSachMaDeThiSinhFileName = Path.Combine(UploadsFolder, $"DanhSachThiSinhMaDe-{Guid.NewGuid()}.xlsx");
            string CryptKey = ConfigurationManager.AppSettings["CryptKey"];
            using (XLWorkbook wb = new XLWorkbook())
            {
                IXLWorksheet ws = wb.Worksheets.Add("DanhSachThiSinhMaDe");
                ws.Cell(1, 1).Value = "Mã";
                ws.Cell(1, 2).Value = "Mã đề";
                int i = 1;
                foreach (var item in ThiSinhMaDe)
                {
                    i++;
                    string MaBaiLam = ThiSinhMaBaiLam[item.Key];
                    var cryptCode = StringCipher.Encrypt(MaBaiLam, CryptKey);
                    ws.Cell(i, 1).Value = cryptCode;
                    ws.Cell(i, 2).Value = item.Value;
                    ThiSinhHash.Add(item.Key, cryptCode);
                }
                wb.SaveAs(DanhSachMaDeThiSinhFileName);
            }
            dirs.Add(DanhSachMaDeThiSinhFileName);
            // File Thi sinh mã hoá
            string DanhSachThiSinhFileName = Path.Combine(UploadsFolder, $"MaHoa-{Guid.NewGuid()}.xlsx");

            using (XLWorkbook wb = new XLWorkbook())
            {
                IXLWorksheet ws = wb.Worksheets.Add("MaHoa");
                ws.Cell(1, 1).Value = "Mã";
                ws.Cell(1, 2).Value = "Mã đề";
                ws.Cell(1, 3).Value = "Mã thí sinh";
                ws.Cell(1, 4).Value = "Họ tên";
                ws.Cell(1, 5).Value = "Ngày sinh";
                ws.Cell(1, 6).Value = "Nơi sinh";
                ws.Cell(1, 7).Value = "CMND";
                ws.Cell(1, 8).Value = "SĐT";
                ws.Cell(1, 9).Value = "Điểm";
                int i = 1;
                foreach (var item in ThiSinhHash)
                {
                    i++;
                    string made = ThiSinhMaDe[item.Key];
                    ws.Cell(i, 1).Value = item.Value;
                    ws.Cell(i, 2).Value = made;
                    ws.Cell(i, 2).SetDataType(XLCellValues.Text);
                    ws.Cell(i, 3).Value = $"'{item.Key}";
                    ws.Cell(i, 4).Value = ThiSinhInfo[item.Key].HoTen;
                    ws.Cell(i, 5).Value = ThiSinhInfo[item.Key].NgaySinh;
                    ws.Cell(i, 6).Value = ThiSinhInfo[item.Key].NoiSinh;
                    ws.Cell(i, 7).Value = ThiSinhInfo[item.Key].CMT;
                    ws.Cell(i, 8).Value = ThiSinhInfo[item.Key].Mobile;
                }
                wb.SaveAs(DanhSachThiSinhFileName);
            }
            dirs.Add(DanhSachThiSinhFileName);
            // zip
            string zipname = Path.Combine(UploadsFolder, $"{Guid.NewGuid()}.zip");
            try
            {
                using (ZipFile zipFile = new ZipFile())
                {
                    zipFile.AddFiles(dirs, false, "");
                    zipFile.Save(zipname);
                }
            }
            catch (Exception ex)
            {
                Response.ContentType = "text/plain";
                Response.Write(ex.Message + "\n " + String.Join(",", dirs));
                return;
            }
            
            Response.Clear();
            Response.Buffer = true;
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            Response.AddHeader("content-disposition", $"attachment; filename={PhongThi}-{CaThi}-{NgayThi}.zip");
            Response.WriteFile(zipname);
            Response.Flush();
            Response.Close();

            File.Delete(zipname);
            File.Delete(DanhSachThiSinhFileName);
            File.Delete(DanhSachMaDeThiSinhFileName);
        }
    }
}