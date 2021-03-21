using GemBox.Document;
using GemBox.Document.Tables;
using GemBox.Spreadsheet;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nuce.Excels
{
    public partial class frmMain : Form
    {
        private DataTable dt;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //ExcelFile ef = ExcelFile.Load("TN10_2019.xls");
            ExcelFile ef = ExcelFile.Load("TN12_2020_mau_cu.xls");
            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["tong_hop"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                dt.Columns.Add(Converter.LocDau(cell.Value.ToString()));
            }
            int iColumn = 0;
            for (int i = 1; i < sheet.Rows.Count; i++)
            {
                iColumn = 0;
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {
                    dt.Rows.Add();
                    if (cell.Value != null)
                        //dt.Rows[i - 1][iColumn] = Converter.TCVN3ToUnicode(cell.Value.ToString());
                        dt.Rows[i - 1][iColumn] = cell.Value.ToString();
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            grvView.DataSource = dt;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            string dottotnghiep; dottotnghiep = "122020";
            string sovaoso; sovaoso = "bsdot4";
            string masv; masv = "";
            string noisiti; noisiti = "";
            string tbcht; tbcht = "";
            string xeploai; xeploai = "";
            string soqdtn; soqdtn = "";
            string sohieuba; sohieuba = "";
            string tinh; tinh = "";
            string truong; truong = "";
            string gioitinh; gioitinh = "";
            string ngaysinh; ngaysinh = "";
            string tkhau; tkhau = "";
            string lop12; lop12 = "";
            string namtn; namtn = "";
            string sobaodanh; sobaodanh = "";
            string tcong; tcong = "";
            string ghichu_thi; ghichu_thi = "";
            string lopqd; lopqd = "";
            string k; k = "";
            string dtoc; dtoc = "";
            string quoctich; quoctich = "";
            string bangclc; bangclc = "";
            string manganh; manganh = "";
            string tenchnga; tenchnga = "";
            string tennganh; tennganh = "";
            string hedaotao; hedaotao = "";
            string khoahoc; khoahoc = "";
            string tensinhvien; tensinhvien = "";
            string email; email = "";
            string email1; email1 = "";
            string email2; email2 = "";
            string mobile; mobile = "";
            string mobile1; mobile1 = "";
            string mobile2; mobile2 = "";
            string thongtinthem; thongtinthem = "";
            string thongtinthem1; thongtinthem1 = "";
            int dotkhoasat_id; dotkhoasat_id = 1;
            string psw = "123";
            int type; type = 1;
            int status; status = 1;
            string checksum = "";
            string ex_masv = "";
            string add0pass = "";
            string maKhoa = "";
            string maLop = "";
            int iSoBanGhiCapNhatDuoc = 0;
            for (int i = 0; i < (dt.Rows.Count > 2000 ? 2000 : dt.Rows.Count); i++)
            {
                try
                {
                    add0pass = "";
                    sovaoso = "";
                    tensinhvien = dt.Rows[i][2].ToString().Trim();
                    masv = dt.Rows[i][1].ToString().Trim();
                    if (masv.Equals(""))
                        break;
                    ex_masv = masv;
                    if (masv.Length < 7)
                    {
                        for (int j = 0; j < 7 - masv.Length; j++)
                        {
                            add0pass = add0pass + "0";
                        }
                    }
                    masv = string.Format("{0}{1}", add0pass, masv);
                    ngaysinh = dt.Rows[i][4].ToString().Trim();
                    gioitinh = dt.Rows[i][6].ToString().Trim();
                    manganh = "";
                    tennganh = dt.Rows[i][9].ToString().Trim();
                    tenchnga = "";
                    string lopqdnew = dt.Rows[i][3].ToString().Trim();
                    if (lopqdnew.Trim().Equals("-") || lopqdnew.Trim().Equals("_") || lopqdnew.Trim().Equals(""))
                    {
                        lopqdnew = lopqd;
                    }
                    lopqd = lopqdnew;
                    khoahoc = "";
                    xeploai = dt.Rows[i][8].ToString().Trim();
                    namtn = "2019";
                    soqdtn = "";
                    sohieuba = "";
                    hedaotao = dt.Rows[i][10].ToString().Trim();
                    maLop = lopqd;
                    maKhoa = dt.Rows[i][11].ToString().Trim();
                    // k = dt.Rows[i][3].ToString().Trim();
                    //checksum = Utils.RemoveUnicode(tensinhvien).Replace(" ", "").ToLower();
                    if (nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insert(dottotnghiep,
 sovaoso,
 masv,
 noisiti,
 tbcht,
 xeploai,
 soqdtn,
 sohieuba,
 tinh,
 truong,
 gioitinh,
 ngaysinh,
 tkhau,
 lop12,
 namtn,
 sobaodanh,
 tcong,
 ghichu_thi,
 lopqd,
 k,
 dtoc,
 quoctich,
 bangclc,
 manganh,
 tenchnga,
 tennganh,
 hedaotao,
 khoahoc,
 tensinhvien,
 email,
 email1,
 email2,
 mobile,
 mobile1,
 mobile2,
 thongtinthem,
 thongtinthem1,
 dotkhoasat_id, checksum, checksum, ex_masv,
 type,
 status, maKhoa, maLop

 ) > 0)
                    {
                        iSoBanGhiCapNhatDuoc++;
                    }
                    else
                    {
                        // MessageBox.Show(ex_masv);
                    }
                    ;
                }
                catch (Exception ex)
                {

                }
            }
            MessageBox.Show("Thanh Cong voi so ban ghi cap nhat duoc la: " + iSoBanGhiCapNhatDuoc.ToString());
        }

        private void btnExportSV_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            // Lấy danh sách khoa

            //DataTable dtKhoa = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.GetKhoa();
            //for (int i = 0; i < dtKhoa.Rows.Count; i++)
            //{
            //    string strMaKhoa = dtKhoa.Rows[i][0].ToString();

            //    ExcelFile ef = new ExcelFile();
            //    ExcelWorksheet ws = ef.Worksheets.Add(strMaKhoa);

            //    DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.GetByKhoa(strMaKhoa);

            //    // Insert DataTable into an Excel worksheet.
            //    ws.InsertDataTable(dt,
            //        new InsertDataTableOptions()
            //        {
            //            ColumnHeaders = true,
            //            StartRow = 0
            //        });

            //    ef.Save(strMaKhoa + ".xlsx");
            //}
            #region
            string strSql = string.Format(@"SELECT *
  FROM [NUCE_Khao_sat_sinh_vien_truoc_tot_nghiep].[dbo].[dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien]
  where dottotnghiep in ('102018','42019','62019','12019')
  order by dottotnghiep ");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("XL");

            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strSql).Tables[0];
            ws.InsertDataTable(dt,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true,
                        StartRow = 0
                    });

            ef.Save("xuat_du_lieu_cuu_sinh_vien.xlsx");
            #endregion
            MessageBox.Show("Xuất dữ liệu thành công !");
        }

        private void btnExportResult_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            // Lấy danh sách khoa

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("ket_qua");

            DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.GetKetQuaKhaoSat();

            // Insert DataTable into an Excel worksheet.
            ws.InsertDataTable(dt,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 0
                });

            ef.Save("ket_qua.xlsx");
            MessageBox.Show("Xuất dữ liệu thành công !");
        }

        private void btnExportByChuyenNganh_Click(object sender, EventArgs e)
        {
            DataSet ds = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.GetKetQuaKhaoSatExportTongHop();
            DataTable dtStudents = ds.Tables[0];
            DataTable dtQuestions = ds.Tables[2];
            DataTable dtPrograms = ds.Tables[1];
            DataTable dtKetQua = ds.Tables[3];

            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Báo cáo tổng thế toàn trường");

            ws = ExportReportLevel1_v1_ex00withHight(ws, 0, 0, 0, 1, true, 1, "Ngành/ chuyên ngành", 1500, 10000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 1, 1, 0, 1, true, 1, "Số phiếu phát ra", 1500, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 2, 2, 0, 1, true, 1, "Thu về", 1500, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 3, 3, 0, 1, true, 1, "Tỷ lệ tham gia khảo sát T3,5/2018", 1500, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 4, 4, 0, 1, true, 1, "Tỷ lệ kỳ vọng", 1500, 3000);
            int iCS = 5;
            int iCQ = 0;
            int iType = 0;
            string strNameQuestion = "";
            for (int i = 0; i < dtQuestions.Rows.Count; i++)
            {
                strNameQuestion = dtQuestions.Rows[i]["Name"].ToString();
                iCQ = int.Parse(dtQuestions.Rows[i]["NumberOfQuestions"].ToString());
                iType = int.Parse(dtQuestions.Rows[i]["Type"].ToString());
                if (iType.Equals(1))
                {
                    ws = ExportReportLevel1_v1_ex00withHight(ws, iCS, iCS + iCQ, 0, 0, true, 1, strNameQuestion, 1500, 10000);
                    for (int j = 1; j < (iCQ + 1); j++)
                    {
                        ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + j - 1, iCS + j - 1, 1, 1, true, 1, j.ToString(), 800, 10000 / (iCQ + 1));
                    }
                    ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + iCQ, iCS + iCQ, 1, 1, true, 1, "Điểm TB", 800, 10000 / (iCQ + 1));
                    iCS = iCS + iCQ + 1;
                }
            }
            // Chèn dữ liệu
            string NameProgram;
            string MaKhoa;
            int iRS = 2;
            int iTongSoPhieuPhatRa = 0;
            int iSoPhieuPhatRa = 0;
            int iTongSoPhieuThuVe = 0;
            int iSoPhieuThuVe = 0;
            double dTyle = 0;
            int iCot = 9;
            int iSoCauTraLoi = 0;
            int iDiemTrungBinh = 0;
            int iTongSoCauTraLoi = 0;

            int iTotalPrograms = dtPrograms.Rows.Count;
            for (int i = 0; i < iTotalPrograms; i++)
            {
                NameProgram = dtPrograms.Rows[i]["tenchnga"].ToString();
                MaKhoa = dtPrograms.Rows[i]["makhoa"].ToString();
                iSoPhieuPhatRa = getSoPhieuPhatRa(dtStudents, NameProgram, MaKhoa);
                iTongSoPhieuPhatRa = iTongSoPhieuPhatRa + iSoPhieuPhatRa;
                iSoPhieuThuVe = getSoPhieuPhatRa(dtKetQua, NameProgram, MaKhoa);
                iTongSoPhieuThuVe = iTongSoPhieuThuVe + iSoPhieuThuVe;
                dTyle = (double)iSoPhieuThuVe / iSoPhieuPhatRa;
                ws = ExportReportLevel1_v1_ex00withHight(ws, 0, 0, iRS + i, iRS + i, true, 4, NameProgram, 400, 10000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 1, 1, iRS + i, iRS + i, false, 3, iSoPhieuPhatRa.ToString(), 400, 3000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 2, 2, iRS + i, iRS + i, false, 3, iSoPhieuThuVe.ToString(), 400, 3000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 3, 3, iRS + i, iRS + i, false, 3, (100 * dTyle).ToString("N1") + "%", 400, 3000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 4, 4, iRS + i, iRS + i, false, 3, "80%", 400, 3000);

                iCS = 5;
                iCot = 9;


                for (int k = 0; k < dtQuestions.Rows.Count; k++)
                {
                    iCQ = int.Parse(dtQuestions.Rows[k]["NumberOfQuestions"].ToString());
                    iType = int.Parse(dtQuestions.Rows[k]["Type"].ToString());
                    iDiemTrungBinh = 0;
                    iTongSoCauTraLoi = 0;
                    if (iType.Equals(1))
                    {
                        for (int j = 1; j < (iCQ + 1); j++)
                        {
                            iSoCauTraLoi = getSoCauTraLoi(dtKetQua, iCot.ToString(), NameProgram, MaKhoa);
                            iTongSoCauTraLoi = iTongSoCauTraLoi + iSoCauTraLoi;
                            iDiemTrungBinh = iDiemTrungBinh + iSoCauTraLoi * j;
                            iCot++;
                            ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + j - 1, iCS + j - 1, iRS + i, iRS + i, false, 3, iSoCauTraLoi.ToString(), 800, 10000 / (iCQ + 1));
                        }
                        ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + iCQ, iCS + iCQ, iRS + i, iRS + i, false, 3, ((float)iDiemTrungBinh / iTongSoCauTraLoi).ToString("N1"), 800, 10000 / (iCQ + 1));
                        iCS = iCS + iCQ + 1;
                    }
                }
            }
            #region tong ket
            dTyle = (double)iTongSoPhieuThuVe / iTongSoPhieuPhatRa;
            ws = ExportReportLevel1_v1_ex00withHight(ws, 0, 0, iRS + iTotalPrograms, iRS + iTotalPrograms, true, 4, "Toàn trường", 400, 10000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 1, 1, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, iTongSoPhieuPhatRa.ToString(), 400, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 2, 2, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, iTongSoPhieuThuVe.ToString(), 400, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 3, 3, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, (100 * dTyle).ToString("N1") + "%", 400, 3000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 4, 4, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, "80%", 400, 3000);
            iCS = 5;
            iCot = 9;
            for (int k = 0; k < dtQuestions.Rows.Count; k++)
            {
                iCQ = int.Parse(dtQuestions.Rows[k]["NumberOfQuestions"].ToString());
                iType = int.Parse(dtQuestions.Rows[k]["Type"].ToString());
                iDiemTrungBinh = 0;
                iTongSoCauTraLoi = 0;
                if (iType.Equals(1))
                {
                    for (int j = 1; j < (iCQ + 1); j++)
                    {
                        iSoCauTraLoi = getSoCauTraLoi(dtKetQua, iCot.ToString());
                        iDiemTrungBinh = iDiemTrungBinh + iSoCauTraLoi * j;
                        iTongSoCauTraLoi = iTongSoCauTraLoi + iSoCauTraLoi;
                        iCot++;
                        ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + j - 1, iCS + j - 1, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, iSoCauTraLoi.ToString(), 800, 10000 / (iCQ + 1));
                    }
                    ws = ExportReportLevel1_v1_ex00withHight(ws, iCS + iCQ, iCS + iCQ, iRS + iTotalPrograms, iRS + iTotalPrograms, false, 3, ((float)iDiemTrungBinh / iTongSoCauTraLoi).ToString("N1"), 800, 10000 / (iCQ + 1));
                    iCS = iCS + iCQ + 1;
                }
            }

            #endregion
            var executablePath = AppDomain.CurrentDomain.BaseDirectory;
            var exportPath = string.Concat(executablePath, Path.DirectorySeparatorChar, string.Format("01_bao_cao_khao_sat_sinh_vien_truoc_khi_ra_truong_{0}.xls", DateTime.Now.ToFileTimeUtc()));
            ef.Save(exportPath);
            MessageBox.Show("OK");
        }

        private void btnExportTheoCauHoi_Click(object sender, EventArgs e)
        {

        }
        #region AddFunction
        public ExcelWorksheet ExportReportLevel1_v1_ex0(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, bool bold, string Name)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.Font.Name = "Times New Roman";
            mergedRange.Style.Font.Size = 13 * 20;
            mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
            mergedRange.Style.WrapText = true;
            if (bold)
                mergedRange.Style.Font.Weight = ExcelFont.BoldWeight;
            mergedRange.Value = Name;
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex0withHight(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, bool bold, string Name, int Hight)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.Font.Name = "Times New Roman";
            mergedRange.Style.Font.Size = 13 * 20;
            mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
            mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
            mergedRange.Style.WrapText = true;

            if (bold)
                mergedRange.Style.Font.Weight = ExcelFont.BoldWeight;
            mergedRange.Value = Name;

            ws.Rows[iRS].Height = Hight;
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex00(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, bool bold, int style, string Name)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.Font.Name = "Times New Roman";
            switch (style)
            {
                case 1:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 2:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 3:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                case 4:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                case 5:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 6:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                default: break;
            }


            mergedRange.Style.Borders.SetBorders(GemBox.Spreadsheet.MultipleBorders.Outside, SpreadsheetColor.FromArgb(0, 0, 0), LineStyle.Thin);

            if (bold)
                mergedRange.Style.Font.Weight = ExcelFont.BoldWeight;
            mergedRange.Value = Name;
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex00withHight(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, bool bold, int style, string Name, int Hight, int Width)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.Font.Name = "Times New Roman";
            mergedRange.Style.Font.Size = 12 * 20;
            switch (style)
            {
                case 1:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 2:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 3:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                case 4:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                case 5:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
                    break;
                case 6:
                    mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    mergedRange.Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                    break;
                default: break;
            }


            mergedRange.Style.Borders.SetBorders(GemBox.Spreadsheet.MultipleBorders.Outside, SpreadsheetColor.FromArgb(0, 0, 0), LineStyle.Thin);
            mergedRange.Style.WrapText = true;
            ws.Rows[iRS].Height = Hight;
            ws.Columns[iCS].Width = Width;
            if (bold)
                mergedRange.Style.Font.Weight = ExcelFont.BoldWeight;
            mergedRange.Value = Name;

            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex1(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, int Value, string Name)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
            mergedRange.Value = Name;
            ws.Cells[iRE, iCE + 1].Value = "System.Int32:";
            ws.Cells[iRE, iCE + 1].SetValue(Value);
            ws.Cells[iRE, iCE + 1].Style.NumberFormat = "#.##";
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex11(ExcelWorksheet ws, int iC, int iR, bool bold, int style, int Value)
        {
            ws.Cells[iR, iC].Value = "System.Int32:";
            ws.Cells[iR, iC].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            ws.Cells[iR, iC].SetValue(Value);
            ws.Cells[iR, iC].Style.NumberFormat = "#,##0";
            ws.Cells[iR, iC].Style.Borders.SetBorders(GemBox.Spreadsheet.MultipleBorders.Outside, SpreadsheetColor.FromArgb(0, 0, 0), LineStyle.Thin);
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex111(ExcelWorksheet ws, int iC, int iR, bool bold, int style, double Value)
        {
            ws.Cells[iR, iC].Value = "System.Double:";
            ws.Cells[iR, iC].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            ws.Cells[iR, iC].SetValue(Value);
            ws.Cells[iR, iC].Style.NumberFormat = "#0.##%";
            ws.Cells[iR, iC].Style.Borders.SetBorders(GemBox.Spreadsheet.MultipleBorders.Outside, SpreadsheetColor.FromArgb(0, 0, 0), LineStyle.Thin);
            return ws;
        }
        public ExcelWorksheet ExportReportLevel1_v1_ex2(ExcelWorksheet ws, int iCS, int iCE, int iRS, int iRE, int Value1, double Value2, string Name)
        {
            CellRange mergedRange = null;
            mergedRange = ws.Cells.GetSubrangeAbsolute(iRS, iCS, iRE, iCE);
            mergedRange.Merged = true;
            mergedRange.Style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
            mergedRange.Value = Name;
            ws.Cells[iRE, iCE + 1].Value = "System.Int32:";
            ws.Cells[iRE, iCE + 1].SetValue(Value1);
            ws.Cells[iRE, iCE + 1].Style.NumberFormat = "#,##0";

            ws.Cells[iRE, iCE + 2].Value = "System.Double:";
            ws.Cells[iRE, iCE + 2].SetValue(Value2);
            ws.Cells[iRE, iCE + 2].Style.NumberFormat = "#0.##%";
            return ws;
        }
        public static int getSoPhieuPhatRa(DataTable dt, string strTcnganh)
        {
            DataRow[] dr = dt.Select(string.Format("tenchnga= '{0}'", strTcnganh));
            return dr.Length;
        }
        public static int getSoPhieuPhatRa(DataTable dt, string strTcnganh, string MaKhoa)
        {
            DataRow[] dr = dt.Select(string.Format("tenchnga= '{0}' and makhoa='{1}'", strTcnganh, MaKhoa));
            return dr.Length;
        }
        public static int getSoCauTraLoi(DataTable dt, string cot, string strTcnganh)
        {
            DataRow[] dr = dt.Select(string.Format("tenchnga= '{0}' and n{1}='x'", strTcnganh, cot));
            return dr.Length;
        }
        public static int getSoCauTraLoi(DataTable dt, string cot, string strTcnganh, string MaKhoa)
        {
            DataRow[] dr = dt.Select(string.Format("tenchnga= '{0}' and makhoa='{1}' and n{2}='x'", strTcnganh, MaKhoa, cot));
            return dr.Length;
        }
        public static DataRow[] getCauTraLoi(DataTable dt, string strTcnganh, string MaKhoa)
        {
            DataRow[] dr = dt.Select(string.Format("tenchnga= '{0}' and makhoa='{1}'", strTcnganh, MaKhoa));
            return dr;
        }
        public static int getSoCauTraLoi(DataTable dt, string cot)
        {
            DataRow[] dr = dt.Select(string.Format("n{0}='x'", cot));
            return dr.Length;
        }
        #endregion

        private void btnViewFormDiemThi_Click(object sender, EventArgs e)
        {
            frmDiemThi frm = new frmDiemThi();
            frm.Show();
        }

        private void btnDocExportText_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below.
            DataSet ds = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.GetKetQuaKhaoSatExportTongHop();
            DataTable dtStudents = ds.Tables[0];
            DataTable dtQuestions = ds.Tables[2];
            DataTable dtPrograms = ds.Tables[1];
            DataTable dtKetQua = ds.Tables[3];
            ComponentInfo.SetLicense("DTZX-HTZ5-B7Q6-2GA6");
            DocumentModel document = new DocumentModel();
            document.DefaultCharacterFormat.Size = 13;
            document.DefaultCharacterFormat.FontName = "Times New Roman";
            Section[] sections = new Section[dtPrograms.Rows.Count];
            Section section;
            for (int i = 0; i < dtPrograms.Rows.Count; i++)
            {
                section = new Section(document);
                Paragraph paragraph = new Paragraph(document);
                section.Blocks.Add(paragraph);
                string strTenChuyenNganh = dtPrograms.Rows[i]["tenchnga"].ToString();
                string strKhoa = dtPrograms.Rows[i]["makhoa"].ToString();
                Run run = new Run(document, string.Format("{0}.{1}", i + 1, strTenChuyenNganh))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 14
                    }
                };

                paragraph.Inlines.Add(run);



                DataRow[] drs = getCauTraLoi(dtKetQua, strTenChuyenNganh, strKhoa);
                if (drs.Length > 0)
                {
                    Paragraph paragraph1 = new Paragraph(document);
                    section.Blocks.Add(paragraph1);
                    Run run1 = new Run(document, string.Format("a. {0}", " Ý kiến khác đóng góp cho việc cải tiến chương trình, nâng cao chất lượng đào tạo của Trường"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true,
                            Size = 13
                        }
                    };
                    paragraph1.Inlines.Add(run1);
                    for (int j = 0; j < drs.Length; j++)
                    {
                        string strn211 = drs[j]["n211"].ToString();
                        if (strn211 != "")
                        {
                            Paragraph paragraph2 = new Paragraph(document);
                            section.Blocks.Add(paragraph2);
                            Run run2 = new Run(document, string.Format("- {0}", strn211))
                            {
                                CharacterFormat = new CharacterFormat()
                                {
                                    Size = 13
                                }
                            };
                            paragraph2.Inlines.Add(run2);
                        }
                    }
                    ///
                    Paragraph paragraph3 = new Paragraph(document);
                    section.Blocks.Add(paragraph3);
                    Run run3 = new Run(document, string.Format("b. {0}", " Ý kiến khác đóng góp cho sự phát triển của Trường"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true,
                            Size = 13
                        }
                    };
                    paragraph3.Inlines.Add(run3);
                    for (int j = 0; j < drs.Length; j++)
                    {
                        string strn212 = drs[j]["n212"].ToString();
                        if (strn212 != "")
                        {
                            Paragraph paragraph4 = new Paragraph(document);
                            section.Blocks.Add(paragraph4);
                            Run run4 = new Run(document, string.Format("- {0}", strn212))
                            {
                                CharacterFormat = new CharacterFormat()
                                {
                                    Size = 13
                                }
                            };
                            paragraph4.Inlines.Add(run4);
                        }
                    }

                }

                sections[i] = section;
            }
            for (int i = 0; i < sections.Length; i++)
            {
                document.Sections.Add(sections[i]);
            }

            document.Save("doc_text.docx");
            MessageBox.Show("Thành công !");
        }

        private void btnGetDataCuuSinhVien_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("chinhquy_nam hoc_2016_2017_chuan.xls");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["chinhquy"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
            }
            int iColumn = 0;
            for (int i = 1; i < 3500; i++)
            {
                iColumn = 0;
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {
                    dt.Rows.Add();
                    if (cell.Value != null)
                        dt.Rows[i - 1][iColumn] = Converter.TCVN3ToUnicode(cell.Value.ToString());
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            grvView.DataSource = dt;
        }

        private void btnUpdateDataCuuSinhVien_Click(object sender, EventArgs e)
        {
            string dottotnghiep; dottotnghiep = "2017";
            string sovaoso; sovaoso = "";
            string masv; masv = "";
            string noisiti; noisiti = "";
            string tbcht; tbcht = "";
            string xeploai; xeploai = "";
            string soqdtn; soqdtn = "";
            string sohieuba; sohieuba = "";
            string tinh; tinh = "";
            string truong; truong = "";
            string gioitinh; gioitinh = "";
            string ngaysinh; ngaysinh = "";
            string tkhau; tkhau = "";
            string lop12; lop12 = "";
            string namtn; namtn = "";
            string sobaodanh; sobaodanh = "";
            string tcong; tcong = "";
            string ghichu_thi; ghichu_thi = "";
            string lopqd; lopqd = "";
            string k; k = "";
            string dtoc; dtoc = "";
            string quoctich; quoctich = "";
            string bangclc; bangclc = "";
            string manganh; manganh = "";
            string tenchnga; tenchnga = "";
            string tennganh; tennganh = "";
            string hedaotao; hedaotao = "";
            string khoahoc; khoahoc = "";
            string tensinhvien; tensinhvien = "";
            string email; email = "";
            string email1; email1 = "";
            string email2; email2 = "";
            string mobile; mobile = "";
            string mobile1; mobile1 = "";
            string mobile2; mobile2 = "";
            string thongtinthem; thongtinthem = "";
            string thongtinthem1; thongtinthem1 = "";
            int dotkhoasat_id; dotkhoasat_id = 2;
            string psw = "123";
            int type; type = 1;
            int status; status = 1;
            string checksum = "";
            string ex_masv = "";
            string add0pass = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    add0pass = "";
                    sovaoso = dt.Rows[i][1].ToString().Trim();
                    tensinhvien = dt.Rows[i][11].ToString().Trim();
                    masv = dt.Rows[i][2].ToString().Trim();
                    ex_masv = masv;
                    if (masv.Length < 7)
                    {
                        for (int j = 0; j < 7 - masv.Length; j++)
                        {
                            add0pass = add0pass + "0";
                        }
                    }
                    masv = string.Format("{0}{1}", add0pass, masv);
                    ngaysinh = dt.Rows[i][16].ToString().Trim();
                    gioitinh = dt.Rows[i][15].ToString().Trim();
                    manganh = dt.Rows[i][28].ToString().Trim();
                    tennganh = dt.Rows[i][29].ToString().Trim();
                    tenchnga = dt.Rows[i][31].ToString().Trim();
                    lopqd = dt.Rows[i][24].ToString().Trim();
                    khoahoc = dt.Rows[i][25].ToString().Trim();
                    xeploai = dt.Rows[i][5].ToString().Trim();
                    if (sovaoso.Contains("2016/"))
                    {
                        namtn = "2016";
                    }
                    else
                        namtn = "2017";
                    soqdtn = dt.Rows[i][6].ToString().Trim();
                    sohieuba = dt.Rows[i][7].ToString().Trim();
                    hedaotao = dt.Rows[i][33].ToString().Trim();

                    // k = m_DSDataImport.Tables[0].Rows[i][3].ToString().Trim();
                    checksum = Utils.RemoveUnicode(tensinhvien).Replace(" ", "").ToLower();
                    if (!masv.Equals("0000000"))
                        #region Insert
                        nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.insert(dottotnghiep,
    sovaoso,
    masv,
    noisiti,
    tbcht,
    xeploai,
    soqdtn,
    sohieuba,
    tinh,
    truong,
    gioitinh,
    ngaysinh,
    tkhau,
    lop12,
    namtn,
    sobaodanh,
    tcong,
    ghichu_thi,
    lopqd,
    k,
    dtoc,
    quoctich,
    bangclc,
    manganh,
    tenchnga,
    tennganh,
    hedaotao,
    khoahoc,
    tensinhvien,
    email,
    email1,
    email2,
    mobile,
    mobile1,
    mobile2,
    thongtinthem,
    thongtinthem1,
    dotkhoasat_id, checksum, checksum, ex_masv,
    type,
    status

    );
                }
                catch (Exception ex)
                {

                }
                #endregion
            }
            MessageBox.Show("Ok");
        }

        private void btnXuatSinhVienSauKhiTotNghiep_Click(object sender, EventArgs e)
        {
            //DataTable dtLop = nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.getTongHop().Tables[1];
            //string lopqd = "";
            //string maNganh = "";
            //for (int i = 108; i < 109; i++)
            ////for (int i = 0; i < 1; i++)
            //{
            //    lopqd = dtLop.Rows[i]["lopqd"].ToString();
            //    maNganh = dtLop.Rows[i]["manganh"].ToString();
            //    exportSVByLopQd1(lopqd, maNganh);
            //    System.Threading.Thread.Sleep(1000);
            //}
            //exportSVByLopQd("-1", "");
            //exportSVSauKhiSaoSatXong();
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            DataTable dtMaNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.GetConnection(), CommandType.Text, "  select distinct(n6) from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_KetQuaKhaoSat]").Tables[0];
            for (int i = 0; i < dtMaNganh.Rows.Count; i++)
            {
                string strMaNganh = dtMaNganh.Rows[i]["n6"].ToString();
                ExcelFile ef = new ExcelFile();
                string strSql = string.Format(@"SELECT ROW_NUMBER() OVER (ORDER BY n6,n1) AS [Số thứ tự],n6,n7,n1,n2,CASE
    WHEN n4='x' THEN N'Nam'
    Else N'Nữ'
	END AS n4, n14,n13,n15,[n18],[n19],[n20],[n21],[n22],[n23],[n24],[n25],[n26],[n27],[n28],[n29],[n30],[n31],[n32],[n33],[n34],[n35],[n36],
	CASE
    WHEN n37='1' THEN N'x'
    Else N''
	END AS n371
	,
	CASE
    WHEN n37='2' THEN N'x'
    Else N''
	END AS n372
	,
	CASE
    WHEN n37='3' THEN N'x'
    Else N''
	END AS n373
	,
	CASE
    WHEN n37='4' THEN N'x'
    Else N''
	END AS n374
	,
	CASE
    WHEN n37='5' THEN N'x'
    Else N''
	END AS n375
	,
	[n38],[n39],[n40],[n41],[n42],[n43],[n44],[n45],[n46],[n47]
  FROM [dbo].[dnn_Nuce_KS_SinhVienRaTruong_KetQuaKhaoSat]  where n6='{0}'", strMaNganh);
                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.GetConnection(), CommandType.Text, strSql).Tables[0];

                ExcelWorksheet ws = ef.Worksheets.Add(strMaNganh);
                ws.InsertDataTable(dt,
                   new InsertDataTableOptions()
                   {
                       ColumnHeaders = true,
                       StartRow = 0
                   });
                ef.Save(strMaNganh + "_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            }

            MessageBox.Show("Xuất dữ liệu thành công !");
        }
        private void exportSVSauKhiSaoSatXong()
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");

            DataSet dsTSCNganh = nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_TongHop.TSCNganh_GetData();
            DataTable dtMaKhoa = dsTSCNganh.Tables[0];
            DataTable dtTSCNganh = dsTSCNganh.Tables[1];
            for (int i = 0; i < dtMaKhoa.Rows.Count; i++)
            {
                string strMaKhoa = dtMaKhoa.Rows[i]["MaKhoa"].ToString();
                DataRow[] drTSCNganhs = getTSCNganhFromMaKhoa(strMaKhoa, dtTSCNganh);
                ExcelFile ef = new ExcelFile();
                for (int j = 0; j < drTSCNganhs.Length; j++)
                {
                    string strMaCNganh = drTSCNganhs[j]["MaCNganh"].ToString();
                    DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_TongHop.getXuatDuLieuSinhVienSauKhaoSatByMaCNganh(strMaCNganh);

                    ExcelWorksheet ws = ef.Worksheets.Add(strMaCNganh);
                    ws.InsertDataTable(dt,
                       new InsertDataTableOptions()
                       {
                           ColumnHeaders = true,
                           StartRow = 0
                       });
                }
                ef.Save(strMaKhoa + "_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            }




            // Insert DataTable into an Excel worksheet.

        }
        protected DataRow[] getTSCNganhFromMaKhoa(string makhoa, DataTable dt)
        {
            DataRow[] dr = dt.Select(string.Format("MaKhoa= '{0}'", makhoa));
            return dr;
        }
        private void exportSVByLopQd(string lopqd, string manganh)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add(lopqd);

            DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.getByLopQDAndDotTotNghiep(lopqd, 2);

            // Insert DataTable into an Excel worksheet.
            ws.InsertDataTable(dt,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 0
                });

            ef.Save(manganh + "_" + lopqd + ".xlsx");

        }
        private void exportSVByLopQd1(string lopqd, string manganh)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add(lopqd);

            DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.getByLopQDAndDotTotNghiep(lopqd, 2);

            //ws = ExportReportLevel1_v1_ex00withHight(ws,1, 6, 0, 0, true, 1, "DANH SÁCH SINH VIÊN TỐT NGHIỆP TỪ THÁNG 4/2016 ĐẾN THÁNG 7/2017", 400, 5000);
            ws = ExportReportLevel1_v1_ex0(ws, 1, 6, 0, 0, true, "DANH SÁCH SINH VIÊN TỐT NGHIỆP TỪ THÁNG 4/2016 ĐẾN THÁNG 7/2017");

            ws = ExportReportLevel1_v1_ex00withHight(ws, 0, 0, 2, 2, true, 3, "STT", 400, 2000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 1, 1, 2, 2, true, 3, "Lớp quản lý", 400, 5000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 2, 2, 2, 2, true, 3, "MSSV", 400, 5000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 3, 3, 2, 2, true, 3, "Họ và Tên", 400, 5000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 4, 4, 2, 2, true, 3, "Điện thoại", 400, 5000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 5, 5, 2, 2, true, 3, "Email", 400, 5000);
            ws = ExportReportLevel1_v1_ex00withHight(ws, 6, 6, 2, 2, true, 3, "Ghi chú", 400, 5000);
            // Insert DataTable into an Excel worksheet.
            int iStart = 2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ws = ExportReportLevel1_v1_ex00withHight(ws, 0, 0, 2 + i + 1, 2 + i + 1, false, 3, dt.Rows[i][0].ToString(), 400, 2000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 1, 1, 2 + i + 1, 2 + i + 1, false, 3, dt.Rows[i][1].ToString(), 400, 5000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 2, 2, 2 + i + 1, 2 + i + 1, false, 3, dt.Rows[i][2].ToString(), 400, 5000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 3, 3, 2 + i + 1, 2 + i + 1, false, 4, dt.Rows[i][3].ToString(), 400, 5000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 4, 4, 2 + i + 1, 2 + i + 1, false, 3, "", 400, 5000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 5, 5, 2 + i + 1, 2 + i + 1, false, 3, "", 400, 5000);
                ws = ExportReportLevel1_v1_ex00withHight(ws, 6, 6, 2 + i + 1, 2 + i + 1, false, 3, "", 400, 5000);
            }

            ef.Save(manganh + "_" + lopqd + ".xlsx");

        }
        private void btnDataUpdateEmail_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("7_10_update_email.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["Sheet1"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
            }
            int iColumn = 0;
            for (int i = 1; i < 3500; i++)
            {
                iColumn = 0;
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {
                    dt.Rows.Add();
                    if (cell.Value != null)
                        dt.Rows[i - 1][iColumn] = Converter.TCVN3ToUnicode(cell.Value.ToString());
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            grvView.DataSource = dt;
        }
        private void btnUpdateDataEmail_Click(object sender, EventArgs e)
        {
            string masv, email, sodienthoai;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                masv = dt.Rows[i][0].ToString();
                masv = masv.ToLower().Trim();
                email = dt.Rows[i][2].ToString();
                email = email.ToLower().Trim();
                sodienthoai = dt.Rows[i][1].ToString();
                sodienthoai = sodienthoai.ToLower().Trim();
                try
                {
                    if (masv != "")
                        nuce.web.data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.update1(masv, email, "", "", sodienthoai, "", "", "", "");
                }
                catch (Exception ex)
                { }
            }
            MessageBox.Show("thanh cong");
        }
        private void btnAnalytist2018ExportDoc127Subject_Click(object sender, EventArgs e)
        {
            // If using Professional version, put your serial key below.
            DataSet ds = nuce.ks.data.Nuce_KS_OutputText.getThongKe2018();
            DataTable dtSubjects = ds.Tables[0];
            DataTable dtOutputText = ds.Tables[1];

            DataSet ds1_k1_16_17 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k1_16_17, "spSurvey_reportAllTotalByClassRoom", 1, 3);
            DataSet ds2_k1_16_17 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k1_16_17, "spSurvey_statistic_getCommon");

            DataSet ds1_k2_16_17 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k2_16_17, "spSurvey_reportAllTotalByClassRoom", 1, 3);
            DataSet ds2_k2_16_17 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k2_16_17, "spSurvey_statistic_getCommon");

            DataSet ds1_k1_17_18 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k1_17_18, "spSurvey_reportAllTotalByClassRoom", 1, 3);
            DataSet ds2_k1_17_18 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k1_17_18, "spSurvey_statistic_getCommon");

            DataSet ds1_k2_17_18 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k2_17_18, "spSurvey_reportAllTotalByClassRoom", 1, 3);
            DataSet ds2_k2_17_18 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.ks.data.Nuce_Common.ConnectionString_k2_17_18, "spSurvey_statistic_getCommon");


            DataRow[] drTemps;
            int iCount;

            int iCo, iKCo, iKRo, iTong;
            double dTyleCo, dTyleKCo, dTyleKRo;
            int[] iCoFs = new int[23];
            int[] iKCoFs = new int[23];
            int[] iKRoFs = new int[23];


            ComponentInfo.SetLicense("DTZX-HTZ5-B7Q6-2GA6");
            DocumentModel document = new DocumentModel();
            document.DefaultCharacterFormat.Size = 13;
            document.DefaultCharacterFormat.FontName = "Times New Roman";
            Section[] sections = new Section[dtSubjects.Rows.Count];
            Section section;
            for (int i = 0; i < dtSubjects.Rows.Count; i++)
            {
                section = new Section(document);
                section.PageSetup.Orientation = GemBox.Document.Orientation.Landscape;
                section.PageSetup.PaperType = GemBox.Document.PaperType.A4;

                Paragraph paragraph = new Paragraph(document);
                section.Blocks.Add(paragraph);
                string strTenMon = dtSubjects.Rows[i]["Ten"].ToString();
                string strMaMon = dtSubjects.Rows[i]["Ma"].ToString();
                string strStt = dtSubjects.Rows[i]["STT"].ToString();
                Run run = new Run(document, string.Format("{0}. {1} ({2})", strStt, strTenMon, strMaMon))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 14
                    }
                };

                paragraph.Inlines.Add(run);

                #region 1
                Paragraph paragraph1 = new Paragraph(document);
                section.Blocks.Add(paragraph1);
                Run run1 = new Run(document, string.Format("{0}.1. {1}", strStt, "Kỳ 1 năm học 2016 - 2017"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph1.Inlines.Add(run1);
                #region bảng số liệu tổng hợp
                Paragraph paragraph1t = new Paragraph(document);
                section.Blocks.Add(paragraph1t);
                Run run1t = new Run(document, string.Format("Bảng số liệu tổng hợp "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph1t.Inlines.Add(run1t);

                #region So Lieu Tong Hop
                for (int j = 0; j < 23; j++)
                {
                    iCoFs[j] = 0;
                    iKCoFs[j] = 0;
                    iKRoFs[j] = 0;
                }
                for (int k1 = 0; k1 < 4; k1++)
                {
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = getCountItemFromQuestionAndAnsware(ds1_k1_16_17.Tables[1], ds2_k1_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 4, strMaMon);
                        iKCo = getCountItemFromQuestionAndAnsware(ds1_k1_16_17.Tables[1], ds2_k1_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 5, strMaMon);
                        iKRo = getCountItemFromQuestionAndAnsware(ds1_k1_16_17.Tables[1], ds2_k1_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 6, strMaMon);

                        iCoFs[k2] += iCo;
                        iKCoFs[k2] += iKCo;
                        iKRoFs[k2] += iKRo;
                    }
                }
                // Đẩy dữ liệu vào bảng
                Table[] tablesF2 = new Table[4];
                for (int k1 = 0; k1 < 4; k1++)
                {
                    #region header
                    tablesF2[k1] = new Table(document);
                    tablesF2[k1].TableFormat.AutomaticallyResizeToFitContents = false;
                    tablesF2[k1].TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;

                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 90 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    if (k1 < 3)
                    {
                        tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                        tablesF2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    }
                }

                for (int k1 = 0; k1 < 4; k1++)
                {
                    TableRow rowT1 = new TableRow(document);
                    TableRow rowT2 = new TableRow(document);
                    TableRow rowT3 = new TableRow(document);
                    TableRow rowT4 = new TableRow(document);
                    //TableRow rowT5 = new TableRow(document);
                    tablesF2[k1].Rows.Add(rowT1);
                    tablesF2[k1].Rows.Add(rowT2);
                    tablesF2[k1].Rows.Add(rowT3);
                    tablesF2[k1].Rows.Add(rowT4);
                    // tablesF2[k1].Rows.Add(rowT5);

                    rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Đáp án"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                            )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Center
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                            );

                    rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT3.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT4.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không rõ"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );
                    #endregion
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = iCoFs[k2];
                        iKCo = iKCoFs[k2];
                        iKRo = iKRoFs[k2];

                        iTong = iCo + iKCo + iKRo;
                        if (iTong > 0)
                        {
                            dTyleCo = 100 * ((double)iCo / (double)iTong);
                            dTyleKCo = 100 * ((double)iKCo / (double)iTong);
                            dTyleKRo = 100 * ((double)iKRo / (double)iTong);
                        }
                        else
                        {
                            dTyleCo = 0;
                            dTyleKCo = 0;
                            dTyleKRo = 0;
                        }
                        rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("Câu {0}", k2 + 1))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        })
                        {
                            ColumnSpan = 2,
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                    }
                }
                #endregion
                // them bang
                section.Blocks.Add(tablesF2[0]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesF2[1]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesF2[2]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesF2[3]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                #endregion
                #region 1a
                Paragraph paragraph1a = new Paragraph(document);
                section.Blocks.Add(paragraph1a);
                Run run1a = new Run(document, string.Format("a. Hãy nêu một điều bạn thích nhất về giảng viên của môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };



                paragraph1a.Inlines.Add(run1a);

                DataRow[] dr11 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2017_Q_40");
                for (int j = 0; j < dr11.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr11[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #region 1b
                Paragraph paragraph1b = new Paragraph(document);
                section.Blocks.Add(paragraph1b);
                Run run1b = new Run(document, string.Format("b. Hãy nêu một điều bạn không thích nhất về giảng viên môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph1b.Inlines.Add(run1b);
                DataRow[] dr12 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2017_Q_41");
                for (int j = 0; j < dr12.Length; j++)
                {
                    Paragraph paragraph12 = new Paragraph(document);
                    section.Blocks.Add(paragraph12);
                    string strContent = dr12[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run12 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph12.Inlines.Add(run12);
                }
                #endregion
                #region 1c
                Paragraph paragraph1c = new Paragraph(document);
                section.Blocks.Add(paragraph1c);
                Run run1c = new Run(document, string.Format("c. Ý kiến đóng góp để sinh viên tiếp thu môn học này tốt hơn"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph1c.Inlines.Add(run1c);
                DataRow[] dr13 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2017_Q_42");
                for (int j = 0; j < dr13.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr13[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion

                #endregion
                #region 2
                Paragraph paragraph2 = new Paragraph(document);
                section.Blocks.Add(paragraph2);
                Run run2 = new Run(document, string.Format("{0}.2. {1}", strStt, "Kỳ 2 năm học 2016 - 2017"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph2.Inlines.Add(run2);
                #region bảng số liệu tổng hợp 2
                Paragraph paragraph2t = new Paragraph(document);
                section.Blocks.Add(paragraph2t);
                Run run2t = new Run(document, string.Format("Bảng số liệu tổng hợp "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph2t.Inlines.Add(run2t);

                #region So Lieu Tong Hop 2
                for (int j = 0; j < 23; j++)
                {
                    iCoFs[j] = 0;
                    iKCoFs[j] = 0;
                    iKRoFs[j] = 0;
                }
                for (int k1 = 0; k1 < 4; k1++)
                {
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = getCountItemFromQuestionAndAnsware(ds1_k2_16_17.Tables[1], ds2_k2_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 4, strMaMon);
                        iKCo = getCountItemFromQuestionAndAnsware(ds1_k2_16_17.Tables[1], ds2_k2_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 5, strMaMon);
                        iKRo = getCountItemFromQuestionAndAnsware(ds1_k2_16_17.Tables[1], ds2_k2_16_17.Tables[7], 17 + k2, (17 + k2) * 3 + 6, strMaMon);

                        iCoFs[k2] += iCo;
                        iKCoFs[k2] += iKCo;
                        iKRoFs[k2] += iKRo;
                    }
                }
                // Đẩy dữ liệu vào bảng

                Table[] tablesB2 = new Table[4];
                #region Day du lieu vao bang
                for (int k1 = 0; k1 < 4; k1++)
                {
                    #region header
                    tablesB2[k1] = new Table(document);
                    tablesB2[k1].TableFormat.AutomaticallyResizeToFitContents = false;
                    tablesB2[k1].TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;

                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 90 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    if (k1 < 3)
                    {
                        tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                        tablesB2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    }
                }

                for (int k1 = 0; k1 < 4; k1++)
                {
                    TableRow rowT1 = new TableRow(document);
                    TableRow rowT2 = new TableRow(document);
                    TableRow rowT3 = new TableRow(document);
                    TableRow rowT4 = new TableRow(document);
                    //TableRow rowT5 = new TableRow(document);
                    tablesB2[k1].Rows.Add(rowT1);
                    tablesB2[k1].Rows.Add(rowT2);
                    tablesB2[k1].Rows.Add(rowT3);
                    tablesB2[k1].Rows.Add(rowT4);
                    // tablesB2[k1].Rows.Add(rowT5);

                    rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Đáp án"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                            )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Center
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                            );

                    rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT3.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT4.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không rõ"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );
                    #endregion
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = iCoFs[k2];
                        iKCo = iKCoFs[k2];
                        iKRo = iKRoFs[k2];

                        iTong = iCo + iKCo + iKRo;
                        if (iTong > 0)
                        {
                            dTyleCo = 100 * ((double)iCo / (double)iTong);
                            dTyleKCo = 100 * ((double)iKCo / (double)iTong);
                            dTyleKRo = 100 * ((double)iKRo / (double)iTong);
                        }
                        else
                        {
                            dTyleCo = 0;
                            dTyleKCo = 0;
                            dTyleKRo = 0;
                        }
                        rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("Câu {0}", k2 + 1))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        })
                        {
                            ColumnSpan = 2,
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                    }
                }
                #endregion
                // them bang
                section.Blocks.Add(tablesB2[0]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesB2[1]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesB2[2]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesB2[3]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                #endregion
                #endregion
                #region 2a
                Paragraph paragraph2a = new Paragraph(document);
                section.Blocks.Add(paragraph2a);
                Run run2a = new Run(document, string.Format("a. Hãy nêu một điều bạn thích nhất về giảng viên của môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph2a.Inlines.Add(run2a);
                DataRow[] dr21 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2017_Q_41");
                for (int j = 0; j < dr21.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr21[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #region 2b
                Paragraph paragraph2b = new Paragraph(document);
                section.Blocks.Add(paragraph2b);
                Run run2b = new Run(document, string.Format("b. Hãy nêu một điều bạn không thích nhất về giảng viên môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph2b.Inlines.Add(run2b);
                DataRow[] dr22 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2017_Q_42");
                for (int j = 0; j < dr22.Length; j++)
                {
                    Paragraph paragraph12 = new Paragraph(document);
                    section.Blocks.Add(paragraph12);
                    string strContent = dr22[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run12 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph12.Inlines.Add(run12);
                }
                #endregion
                #region 2c
                Paragraph paragraph2c = new Paragraph(document);
                section.Blocks.Add(paragraph2c);
                Run run2c = new Run(document, string.Format("c. Ý kiến đóng góp để sinh viên tiếp thu môn học này tốt hơn"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph2c.Inlines.Add(run2c);
                DataRow[] dr23 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2017_Q_43");
                for (int j = 0; j < dr23.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr23[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #endregion
                #region 3
                Paragraph paragraph3 = new Paragraph(document);
                section.Blocks.Add(paragraph3);
                Run run3 = new Run(document, string.Format("{0}.3. {1}", strStt, "Kỳ 1 năm học 2017 - 2018"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph3.Inlines.Add(run3);
                #region bảng số liệu tổng hợp 3
                Paragraph paragraph3t = new Paragraph(document);
                section.Blocks.Add(paragraph3t);
                Run run3t = new Run(document, string.Format("Bảng số liệu tổng hợp "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph3t.Inlines.Add(run3t);

                #region So Lieu Tong Hop 3
                for (int j = 0; j < 23; j++)
                {
                    iCoFs[j] = 0;
                    iKCoFs[j] = 0;
                    iKRoFs[j] = 0;
                }
                for (int k1 = 0; k1 < 4; k1++)
                {
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = getCountItemFromQuestionAndAnsware(ds1_k1_17_18.Tables[1], ds2_k1_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 4, strMaMon);
                        iKCo = getCountItemFromQuestionAndAnsware(ds1_k1_17_18.Tables[1], ds2_k1_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 5, strMaMon);
                        iKRo = getCountItemFromQuestionAndAnsware(ds1_k1_17_18.Tables[1], ds2_k1_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 6, strMaMon);

                        iCoFs[k2] += iCo;
                        iKCoFs[k2] += iKCo;
                        iKRoFs[k2] += iKRo;
                    }
                }
                // Đẩy dữ liệu vào bảng

                Table[] tablesC2 = new Table[4];
                #region Day du lieu vao bang
                for (int k1 = 0; k1 < 4; k1++)
                {
                    #region header
                    tablesC2[k1] = new Table(document);
                    tablesC2[k1].TableFormat.AutomaticallyResizeToFitContents = false;
                    tablesC2[k1].TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;

                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 90 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    if (k1 < 3)
                    {
                        tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                        tablesC2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    }
                }

                for (int k1 = 0; k1 < 4; k1++)
                {
                    TableRow rowT1 = new TableRow(document);
                    TableRow rowT2 = new TableRow(document);
                    TableRow rowT3 = new TableRow(document);
                    TableRow rowT4 = new TableRow(document);
                    //TableRow rowT5 = new TableRow(document);
                    tablesC2[k1].Rows.Add(rowT1);
                    tablesC2[k1].Rows.Add(rowT2);
                    tablesC2[k1].Rows.Add(rowT3);
                    tablesC2[k1].Rows.Add(rowT4);
                    // tablesC2[k1].Rows.Add(rowT5);

                    rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Đáp án"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                            )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Center
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                            );

                    rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT3.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT4.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không rõ"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );
                    #endregion
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = iCoFs[k2];
                        iKCo = iKCoFs[k2];
                        iKRo = iKRoFs[k2];

                        iTong = iCo + iKCo + iKRo;
                        if (iTong > 0)
                        {
                            dTyleCo = 100 * ((double)iCo / (double)iTong);
                            dTyleKCo = 100 * ((double)iKCo / (double)iTong);
                            dTyleKRo = 100 * ((double)iKRo / (double)iTong);
                        }
                        else
                        {
                            dTyleCo = 0;
                            dTyleKCo = 0;
                            dTyleKRo = 0;
                        }
                        rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("Câu {0}", k2 + 1))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        })
                        {
                            ColumnSpan = 2,
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                    }
                }
                #endregion
                // them bang
                section.Blocks.Add(tablesC2[0]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesC2[1]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesC2[2]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesC2[3]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                #endregion
                #endregion
                #region 3a
                Paragraph paragraph3a = new Paragraph(document);
                section.Blocks.Add(paragraph3a);
                Run run3a = new Run(document, string.Format("a. Hãy nêu một điều bạn thích nhất về giảng viên của môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph3a.Inlines.Add(run3a);
                DataRow[] dr31 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2018_Q_41");
                for (int j = 0; j < dr31.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr31[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #region 3b
                Paragraph paragraph3b = new Paragraph(document);
                section.Blocks.Add(paragraph3b);
                Run run3b = new Run(document, string.Format("b. Hãy nêu một điều bạn không thích nhất về giảng viên môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph3b.Inlines.Add(run3b);
                DataRow[] dr32 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2018_Q_42");
                for (int j = 0; j < dr32.Length; j++)
                {
                    Paragraph paragraph12 = new Paragraph(document);
                    section.Blocks.Add(paragraph12);
                    string strContent = dr32[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run12 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph12.Inlines.Add(run12);
                }
                #endregion
                #region 3c
                Paragraph paragraph3c = new Paragraph(document);
                section.Blocks.Add(paragraph3c);
                Run run3c = new Run(document, string.Format("c. Ý kiến đóng góp để sinh viên tiếp thu môn học này tốt hơn"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph3c.Inlines.Add(run3c);
                DataRow[] dr33 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_1_2018_Q_43");
                for (int j = 0; j < dr33.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr33[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #endregion
                #region 4
                Paragraph paragraph4 = new Paragraph(document);
                section.Blocks.Add(paragraph4);
                Run run4 = new Run(document, string.Format("{0}.4. {1}", strStt, "Kỳ 2 năm học 2017 - 2018"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph4.Inlines.Add(run4);
                #region bảng số liệu tổng hợp 3
                Paragraph paragraph4t = new Paragraph(document);
                section.Blocks.Add(paragraph4t);
                Run run4t = new Run(document, string.Format("Bảng số liệu tổng hợp "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph4t.Inlines.Add(run4t);

                #region So Lieu Tong Hop 4
                for (int j = 0; j < 23; j++)
                {
                    iCoFs[j] = 0;
                    iKCoFs[j] = 0;
                    iKRoFs[j] = 0;
                }
                for (int k1 = 0; k1 < 4; k1++)
                {
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = getCountItemFromQuestionAndAnsware(ds1_k2_17_18.Tables[1], ds2_k2_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 4, strMaMon);
                        iKCo = getCountItemFromQuestionAndAnsware(ds1_k2_17_18.Tables[1], ds2_k2_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 5, strMaMon);
                        iKRo = getCountItemFromQuestionAndAnsware(ds1_k2_17_18.Tables[1], ds2_k2_17_18.Tables[7], 17 + k2, (17 + k2) * 3 + 6, strMaMon);

                        iCoFs[k2] += iCo;
                        iKCoFs[k2] += iKCo;
                        iKRoFs[k2] += iKRo;
                    }
                }
                // Đẩy dữ liệu vào bảng

                Table[] tablesD2 = new Table[4];
                #region Day du lieu vao bang
                for (int k1 = 0; k1 < 4; k1++)
                {
                    #region header
                    tablesD2[k1] = new Table(document);
                    tablesD2[k1].TableFormat.AutomaticallyResizeToFitContents = false;
                    tablesD2[k1].TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;

                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 90 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    if (k1 < 3)
                    {
                        tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                        tablesD2[k1].Columns.Add(new TableColumn() { PreferredWidth = 55 });
                    }
                }

                for (int k1 = 0; k1 < 4; k1++)
                {
                    TableRow rowT1 = new TableRow(document);
                    TableRow rowT2 = new TableRow(document);
                    TableRow rowT3 = new TableRow(document);
                    TableRow rowT4 = new TableRow(document);
                    //TableRow rowT5 = new TableRow(document);
                    tablesD2[k1].Rows.Add(rowT1);
                    tablesD2[k1].Rows.Add(rowT2);
                    tablesD2[k1].Rows.Add(rowT3);
                    tablesD2[k1].Rows.Add(rowT4);
                    // tablesD2[k1].Rows.Add(rowT5);

                    rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Đáp án"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                            )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Center
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                            );

                    rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT3.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không có"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );

                    rowT4.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Không rõ"))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    }
                  )
                    {
                        ParagraphFormat = new ParagraphFormat()
                        {
                            Alignment = GemBox.Document.HorizontalAlignment.Left
                        }
                    })
                    {
                        CellFormat = new TableCellFormat()
                        {
                            VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                        }
                    }
                    );
                    #endregion
                    for (int k2 = k1 * 6; k2 < k1 * 6 + 6; k2++)
                    {
                        if (k2 >= 23)
                            break;

                        iCo = iCoFs[k2];
                        iKCo = iKCoFs[k2];
                        iKRo = iKRoFs[k2];

                        iTong = iCo + iKCo + iKRo;
                        if (iTong > 0)
                        {
                            dTyleCo = 100 * ((double)iCo / (double)iTong);
                            dTyleKCo = 100 * ((double)iKCo / (double)iTong);
                            dTyleKRo = 100 * ((double)iKRo / (double)iTong);
                        }
                        else
                        {
                            dTyleCo = 0;
                            dTyleKCo = 0;
                            dTyleKRo = 0;
                        }
                        rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("Câu {0}", k2 + 1))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        })
                        {
                            ColumnSpan = 2,
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT2.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT3.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKCo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N0}", iKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        rowT4.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0:N1}%", dTyleKRo))
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Right
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                            }
                        }
                        );

                    }
                }
                #endregion
                // them bang
                section.Blocks.Add(tablesD2[0]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesD2[1]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesD2[2]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                section.Blocks.Add(tablesD2[3]);
                section.Blocks.Add(new Paragraph(document, new Run(document, " ")));
                #endregion
                #endregion
                #region 4a
                Paragraph paragraph4a = new Paragraph(document);
                section.Blocks.Add(paragraph4a);
                Run run4a = new Run(document, string.Format("a. Hãy nêu một điều bạn thích nhất về giảng viên của môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph4a.Inlines.Add(run4a);
                DataRow[] dr41 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2018_Q_41");
                for (int j = 0; j < dr41.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr41[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #region 4b
                Paragraph paragraph4b = new Paragraph(document);
                section.Blocks.Add(paragraph4b);
                Run run4b = new Run(document, string.Format("b. Hãy nêu một điều bạn không thích nhất về giảng viên môn học này "))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph4b.Inlines.Add(run4b);
                DataRow[] dr42 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2018_Q_42");
                for (int j = 0; j < dr42.Length; j++)
                {
                    Paragraph paragraph12 = new Paragraph(document);
                    section.Blocks.Add(paragraph12);
                    string strContent = dr42[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run12 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph12.Inlines.Add(run12);
                }
                #endregion
                #region 4c
                Paragraph paragraph4c = new Paragraph(document);
                section.Blocks.Add(paragraph4c);
                Run run4c = new Run(document, string.Format("c. Ý kiến đóng góp để sinh viên tiếp thu môn học này tốt hơn"))
                {
                    CharacterFormat = new CharacterFormat()
                    {
                        Bold = true,
                        Size = 13
                    }
                };
                paragraph4c.Inlines.Add(run4c);
                DataRow[] dr43 = getDataBySubjectSurvey_2018(dtOutputText, strMaMon, "ki_2_2018_Q_43");
                for (int j = 0; j < dr43.Length; j++)
                {
                    Paragraph paragraph11 = new Paragraph(document);
                    section.Blocks.Add(paragraph11);
                    string strContent = dr43[j]["TextOld"].ToString();
                    strContent = strContent.Replace("\n", ";");
                    strContent = strContent.Replace("\r", ";");
                    strContent = strContent.Replace("\t", ";");
                    Run run11 = new Run(document, string.Format("- {0}", strContent))
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Size = 13
                        }
                    };
                    paragraph11.Inlines.Add(run11);
                }
                #endregion
                #endregion
                sections[i] = section;
            }
            for (int i = 0; i < sections.Length; i++)
            {
                document.Sections.Add(sections[i]);
            }

            document.Save(string.Format("doc_text_{0}.docx", DateTime.Now.ToFileTimeUtc().ToString()));
            MessageBox.Show("Thành công !");
        }
        #region add function
        public DataRow[] getDataBySubjectSurvey_2018(DataTable dt, string subject, string survey)
        {
            DataRow[] dr = dt.Select(string.Format("SubjectCode= '{0}' and Survey='{1}'", subject, survey));
            return dr;
        }
        public int getCountItemFromQuestionAndAnsware(DataTable dt, DataTable dtClassRooms, int QuestionId, int AnswerId, string subjectCode)
        {
            DataRow[] dr = dtClassRooms.Select(string.Format("SubjectCode='{0}'", subjectCode));
            int iReturn = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                iReturn += getCountItemFromQuestionAnswareAndClassRoomId(dt, QuestionId, AnswerId, int.Parse(dr[i]["ID"].ToString()));
            }
            return iReturn;
        }
        public int getCountItemFromQuestionAnswareAndClassRoomId(DataTable dt, int QuestionId, int AnswerId, int ClassRoomId)
        {
            DataRow[] dr = dt.Select(string.Format("questionId={0} and answerId={1} and ClassRoomId={2}", QuestionId, AnswerId, ClassRoomId));
            int iReturn = 0;
            for (int i = 0; i < dr.Length; i++)
            {
                iReturn += int.Parse(dr[i]["Total"].ToString());
            }
            return iReturn;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            string inputPassword = "THA@123";
            // var ef = ExcelFile.Load("AHAI_BM04.xlsx", new XlsxLoadOptions() { Password = inputPassword });
            var ef = ExcelFile.Load("AHAI_BM03.xlsx");
            StringBuilder sb = new StringBuilder();
            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["Sheet1"];
            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[3].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(cell.Value.ToString()));
            }
            int iColumn = 0;
            for (int i = 1; i < (sheet.Rows.Count > 1000000 ? 1000000 : sheet.Rows.Count); i++)
            {
                iColumn = 0;
                dt.Rows.Add();
                foreach (ExcelCell cell in sheet.Rows[i + 3].AllocatedCells)
                {
                    if (cell.Value != null)
                        dt.Rows[i - 1][iColumn] = cell.Value.ToString();
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            //MessageBox.Show(dt.Rows.Count.ToString());
            MessageBox.Show(dt.Rows.Count.ToString());
            //grvView.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //@tt int,@sodk varchar(50),@hvt nvarchar(200),@ns varchar(50),@cmt varchar(50),
                //@nc nvarchar(200), @ngc varchar(50), @ngadkltt varchar(50), @user varchar(50), @mchang varchar(50),
                //@huyen nvarchar(100), @hvt_chs varchar(100), @so_ten_trung int, @sodk_trung int, @file varchar(50), @note nvarchar(500)
                try
                {
                    int tt = int.Parse(dt.Rows[i][0].ToString().Trim());
                    string sodk = dt.Rows[i][1].ToString();
                    string hvt = dt.Rows[i][2].ToString();
                    //hvt = Converter.TCVN3ToUnicode(hvt);
                    string ns = dt.Rows[i][3].ToString();
                    string cmt = dt.Rows[i][4].ToString().Trim();
                    string nc = dt.Rows[i][5].ToString();
                    //nc = Converter.TCVN3ToUnicode(nc);
                    string ngc = dt.Rows[i][6].ToString();
                    string ngadkltt = dt.Rows[i][7].ToString();
                    string user = dt.Rows[i][8].ToString();
                    //string user = "";
                    string machang = dt.Rows[i][9].ToString();
                    //string machang = "";
                    //string tdccdvvt= dt.Rows[i][10].ToString();
                    string tdccdvvt = "";
                    //tdccdvvt = Converter.TCVN3ToUnicode(tdccdvvt);
                    string huyen = dt.Rows[i][10].ToString().Trim();
                    //string huyen = "";
                    //huyen = Converter.TCVN3ToUnicode(huyen);
                    string hvt_chs = Utils.RemoveUnicode(hvt).ToUpper().Replace(" ", "_");
                    string nc_chs = Utils.RemoveUnicode(nc).ToUpper().Replace(" ", "_");
                    if (nc_chs.Contains("THANH_HOA"))
                        nc_chs = "THANH_HOA";
                    int so_ten_trung = 0;
                    int sodk_trung = 0;
                    string file = "BM03_DS_t11_2018";
                    string note = "";
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "insert_tblDataTB", tt, sodk, hvt, ns, cmt, nc, ngc, ngadkltt, user, machang, tdccdvvt, huyen, hvt_chs, nc_chs, so_ten_trung, sodk_trung, file, note);
                }
                catch (Exception ex)
                {

                }

            }
            MessageBox.Show("Thanh cong !");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string strTest = "thanh cong !";

            string str3Trung = "CMTLonhon10";
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getCmtnhieulon", "BM04", 10).Tables[0];
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add(str3Trung);
            ws3.InsertDataTable(dt999,
               new InsertDataTableOptions()
               {
                   ColumnHeaders = true,
                   StartRow = 0
               });
            ef.Save("mau_4_" + str3Trung + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            /*
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            DataTable dtHuyen = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getHuyen").Tables[0];
            bool blCheck = true;
            for (int i = 0; i < dtHuyen.Rows.Count; i++)
            {
                string strHuyen = dtHuyen.Rows[i][0].ToString();
                string strHuyenKhongDau = Converter.LocDau(strHuyen);
                if (strHuyen.Trim() != "" && strHuyen.Trim() != "Thanh Hóa" && strHuyen.Trim() != "Thành phố")
                {
                    DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getDataByHuyenAndFile", strHuyen, "BM03_DS_t11_2018").Tables[0];
                    ExcelFile ef = new ExcelFile();
                    ExcelWorksheet ws3 = ef.Worksheets.Add(strHuyenKhongDau);
                    ws3.InsertDataTable(dtData,
                       new InsertDataTableOptions()
                       {
                           ColumnHeaders = true,
                           StartRow = 0
                       });
                    ef.Save("mau_3_" + strHuyenKhongDau + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

                    DataTable dtData4 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getDataByHuyenAndFile", strHuyen, "BM04_DS_t11_2018").Tables[0];
                    ExcelFile ef4 = new ExcelFile();
                    ExcelWorksheet ws4 = ef4.Worksheets.Add(strHuyenKhongDau);
                    ws4.InsertDataTable(dtData4,
                       new InsertDataTableOptions()
                       {
                           ColumnHeaders = true,
                           StartRow = 0
                       });
                    ef4.Save("mau_4_" + strHuyenKhongDau + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
                }
                else
                {
                    if(blCheck&&strHuyen.Trim()!="")
                    {
                        DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getDataByTPAndFile",  "BM03_DS_t11_2018").Tables[0];
                        ExcelFile ef = new ExcelFile();
                        ExcelWorksheet ws3 = ef.Worksheets.Add(strHuyenKhongDau);
                        ws3.InsertDataTable(dtData,
                           new InsertDataTableOptions()
                           {
                               ColumnHeaders = true,
                               StartRow = 0
                           });
                        ef.Save("mau_3_" + strHuyenKhongDau + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

                        DataTable dtData4 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getDataByTPAndFile", "BM04_DS_t11_2018").Tables[0];
                        ExcelFile ef4 = new ExcelFile();
                        ExcelWorksheet ws4 = ef4.Worksheets.Add(strHuyenKhongDau);
                        ws4.InsertDataTable(dtData4,
                           new InsertDataTableOptions()
                           {
                               ColumnHeaders = true,
                               StartRow = 0
                           });
                        ef4.Save("mau_4_" + strHuyenKhongDau + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
                        blCheck = false;
                    }
                }
            }*/
            #region tt
            /*
            DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "getCmtGreaterThanHvt");
            DataTable dt2 = ds.Tables[0];
            DataTable dt3 = ds.Tables[1];
            DataTable dt4 = ds.Tables[2];
            string str2 = "Mau_2_cmtgreaterhvt";
            string str3 = "Mau_3_cmtgreaterhvt";
            string str4 = "Mau_4_cmtgreaterhvt";
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws2 = ef.Worksheets.Add(str2);
            ws2.InsertDataTable(dt2,
               new InsertDataTableOptions()
               {
                   ColumnHeaders = true,
                   StartRow = 0
               });
            ExcelWorksheet ws3 = ef.Worksheets.Add(str3);
            ws3.InsertDataTable(dt3,
               new InsertDataTableOptions()
               {
                   ColumnHeaders = true,
                   StartRow = 0
               });
            ExcelWorksheet ws4 = ef.Worksheets.Add(str4);
            ws4.InsertDataTable(dt4,
               new InsertDataTableOptions()
               {
                   ColumnHeaders = true,
                   StartRow = 0
               });

            ef.Save("cmtgreaterhvt_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            */
            #endregion
            MessageBox.Show(strTest);
        }

        private void btnKSCSVKSOffline_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("khaosat_offline_cuusinhvien.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["Sheet1"];

            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(cell.Value.ToString()));
            }
            int iColumn = 0;
            for (int i = 1; i < 2500; i++)
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

        private void btnUpdateKSCSVKSOffline_Click(object sender, EventArgs e)
        {
            string n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20, n21, n22, n23, n24, n25, n26, n27, n28, n29, n30, n31, n32, n33, n34, n35, n36, n37, n38, n39;
            int stt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.TryParse(dt.Rows[i][0].ToString(), out stt))
                {
                    n1 = dt.Rows[i][1].ToString();
                    n2 = dt.Rows[i][2].ToString();
                    n3 = dt.Rows[i][3].ToString();
                    n4 = dt.Rows[i][4].ToString().Trim();
                    n5 = dt.Rows[i][5].ToString();
                    n6 = dt.Rows[i][6].ToString();
                    n7 = dt.Rows[i][7].ToString();
                    n8 = dt.Rows[i][8].ToString();
                    n9 = dt.Rows[i][9].ToString();
                    n10 = dt.Rows[i][10].ToString();
                    n11 = dt.Rows[i][11].ToString();
                    n12 = dt.Rows[i][12].ToString();
                    n13 = dt.Rows[i][13].ToString();
                    n14 = dt.Rows[i][14].ToString();
                    n15 = dt.Rows[i][15].ToString();
                    n16 = dt.Rows[i][16].ToString();
                    n17 = dt.Rows[i][17].ToString();
                    n18 = dt.Rows[i][18].ToString();
                    n19 = dt.Rows[i][19].ToString();
                    n20 = dt.Rows[i][20].ToString();
                    n21 = dt.Rows[i][21].ToString();
                    n22 = dt.Rows[i][22].ToString();
                    n23 = dt.Rows[i][23].ToString();
                    n24 = dt.Rows[i][24].ToString();
                    n25 = dt.Rows[i][25].ToString();
                    n26 = dt.Rows[i][26].ToString();
                    n27 = dt.Rows[i][27].ToString();
                    n28 = dt.Rows[i][28].ToString();
                    n29 = dt.Rows[i][29].ToString();
                    n30 = dt.Rows[i][30].ToString();
                    n31 = dt.Rows[i][31].ToString();
                    n32 = dt.Rows[i][32].ToString();
                    n33 = dt.Rows[i][33].ToString();
                    n34 = dt.Rows[i][34].ToString();
                    n35 = dt.Rows[i][35].ToString();
                    n36 = dt.Rows[i][36].ToString();
                    n37 = dt.Rows[i][37].ToString();

                    try
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "dnn_Nuce_KS_SinhVienRaTruong_KetQuaKhaoSat_Insert", "", n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20, n21, n22, n23, n24, n25, n26, n27, n28, n29, n30, n31, n32, n33, n34, n35, n36, n37, "");
                    }
                    catch
                    {
                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "dnn_Nuce_KS_SinhVienRaTruong_temp7_Insert", stt, n3);
                    }
                }
            }
            MessageBox.Show("Thanh cong");
        }

        private void btnUpdateKSCSVExprtExcelKetQua_Click(object sender, EventArgs e)
        {
            string strTest = "thanh cong !";

            string str3Trung = "ket_qua_khao_sat_cuu_sinh_vien";
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //            string strTongQuanTemp = string.Format(@"SELECT a.*,b.email,b.mobile
            //  FROM [NUCE_Khao_sat_sinh_vien_truoc_tot_nghiep].[dbo].[nuce_temp_45479] a
            //  left join [dbo].[dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien] b
            //on a.masv=b.ex_masv order by Count ;");

            //            string strTongQuanTemp = string.Format(@"SELECT a.*,b.email,b.mobile,c.ID
            //  FROM [NUCE_Khao_sat_sinh_vien_truoc_tot_nghiep].[dbo].[nuce_temp_16356] a
            //  inner join [dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien] c on a.masv=c.ex_masv

            //  left join [dbo].[dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien] b
            //on a.masv=b.ex_masv 

            //where c.ID not in (
            //select SinhVienID from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien]
            //where  Status=3 and [SinhVienRaTruong_BaiKhaoSatID]=4)

            //order by Count");
//            string strTongQuanTemp = string.Format(@"select c.count+1 as STT,c.masv, c.hoten, c.gioi,c.soqdtn,c.xeploai,c.lopqd,c.tennganh,c.tenchnga,c.nganh_CN,
//c.Ma_Khoa_QL,a.col7,a.col8,a.col9,col10,col11,
//col12,col13,col14,col15,col16,col17,col18,col19,col20,col21,col22,col23,col24,
//col25,col26,col27,col28,col29,col30,col31,col32,col33,col34,col35,col36,col37,
//col38,col39,col40,col41,col42,col43,col44 from [dbo].[nuce_temp_16356] c left join [dnn_Nuce_KS_SinhVienSapRaTruong_tonghopdulieu_on_off] a
//on a.col4=c.masv
//order by c.count+1
//");

            string strTongQuanTemp = string.Format(@"  select ex_masv, email,mobile from [dbo].[dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien]
  where ex_masv in (select ma_sinh_vien from [dbo].[nuce_temp_21927])
  order by email desc
");
            DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.GetConnection(), CommandType.Text, strTongQuanTemp).Tables[0];

            //DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "dnn_Nuce_KS_SinhVienRaTruong_KetQuaKhaoSat_get").Tables[0];
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add(str3Trung);
            ws3.InsertDataTable(dt999,
               new InsertDataTableOptions()
               {
                   ColumnHeaders = true,
                   StartRow = 0
               });
            ef.Save("2019_2020_tong_hop_ket_qua_email" + str3Trung + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show(strTest);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region doc WACC
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("tinh_thanh.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["Sheet1"];
            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(cell.Value.ToString()));
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
            MessageBox.Show(dt.Rows.Count.ToString());
            #endregion
            #region doc WACC
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //ExcelFile ef = ExcelFile.Load("WACC.xls");

            //StringBuilder sb = new StringBuilder();

            //// Iterate through all worksheets in an Excel workbook.
            //ExcelWorksheet sheet = ef.Worksheets["Sheet1"];
            ////    sb.AppendLine();
            ////sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            //// Iterate through all rows in an Excel worksheet.
            //dt = new DataTable();
            //foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            //{
            //    dt.Columns.Add(Converter.LocDau(cell.Value.ToString()));
            //}
            //int iColumn = 0;
            //for (int i = 1; i < sheet.Rows.Count; i++)
            //{
            //    iColumn = 0;
            //    foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
            //    {
            //        dt.Rows.Add();
            //        if (cell.Value != null)
            //            dt.Rows[i - 1][iColumn] = cell.Value.ToString();
            //        else
            //            dt.Rows[i - 1][iColumn] = "";
            //        iColumn++;
            //        if (iColumn >= dt.Columns.Count)
            //            break;
            //    }
            //}
            //grvView.DataSource = dt;
            //MessageBox.Show(dt.Rows.Count.ToString());
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region cu
            //string strErros = "";
            //for (int i = 0; i < 2100; i++)
            //{
            //    try
            //    {
            //        string Nganh = dt.Rows[i][0].ToString();
            //        string TenDoanhNghiep = dt.Rows[i][1].ToString();
            //        string MaDN = dt.Rows[i][2].ToString();
            //        string Nam = dt.Rows[i][4].ToString();
            //        float beta = -999;
            //        float n2 = -999;
            //        float n3 = -999;
            //        float n4 = -999;
            //        float n5 = -999;
            //        float n6 = -999;
            //        float n7 = -999;
            //        float n8 = -999;
            //        float n9 = -999;
            //        float n10 = -999;
            //        float n11 = -999;
            //        float n12 = -999;
            //        float n13 = -999;
            //        float n14 = -999;
            //        float n15 = -999;

            //        try { beta = float.Parse(dt.Rows[i][5].ToString()); } catch { }
            //        try { n2 = float.Parse(dt.Rows[i][6].ToString()); } catch { }
            //        try { n3 = float.Parse(dt.Rows[i][7].ToString()); } catch { }
            //        try { n4 = float.Parse(dt.Rows[i][8].ToString()); } catch { }
            //        try { n5 = float.Parse(dt.Rows[i][9].ToString()); } catch { }
            //        try { n6 = float.Parse(dt.Rows[i][10].ToString()); } catch { }
            //        try { n7 = float.Parse(dt.Rows[i][11].ToString()); } catch { }
            //        try { n8 = float.Parse(dt.Rows[i][12].ToString()); } catch { }
            //        try { n9 = float.Parse(dt.Rows[i][13].ToString()); } catch { }
            //        try { n10 = float.Parse(dt.Rows[i][14].ToString()); } catch { }
            //        try { n11 = float.Parse(dt.Rows[i][15].ToString()); } catch { }
            //        try { n12 = float.Parse(dt.Rows[i][16].ToString()); } catch { }
            //        try { n13 = float.Parse(dt.Rows[i][17].ToString()); } catch { }
            //        try { n14 = float.Parse(dt.Rows[i][18].ToString()); } catch { }
            //        try { n15 = float.Parse(dt.Rows[i][19].ToString()); } catch { }
            //        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "update_tblDuLieuDoanhNghiep",
            //            MaDN, Nam, beta, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15);
            //    }
            //    catch (Exception ex)
            //    {
            //        strErros += "-" + i.ToString();

            //    }

            //}
            #endregion
            #region New
            /*
            string strErros = "";
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    string Nam = dt.Rows[i][0].ToString();

                    float gdb = -999;
                    float cpi = -999;
                    float ir = -999;
                    float tr = -999;
                    float ex = -999;
                    float smd = -999;
                    float bd = -999;
                    float er = -999;
                    float iml_bds = -999;
                    float iml_cnghe = -999;
                    float iml_cnghiep = -999;
                    float iml_dich_vu = -999;
                    float iml_hang_td = -999;
                    float iml_nang_luong = -999;
                    float iml_nguyen_vl = -999;
                    float iml_nong_nghiep = -999;
                    float iml_vien_thong = -999;
                    float iml_yte = -999;

                    float img_bds = -999;
                    float img_cnghe = -999;
                    float img_cnghiep = -999;
                    float img_dich_vu = -999;
                    float img_hang_td = -999;
                    float img_nang_luong = -999;
                    float img_nguyen_vl = -999;
                    float img_nong_nghiep = -999;
                    float img_vien_thong = -999;
                    float img_yte = -999;


                    try { gdb = float.Parse(dt.Rows[i][1].ToString()); } catch { }
                    try { cpi = float.Parse(dt.Rows[i][2].ToString()); } catch { }
                    try { ir = float.Parse(dt.Rows[i][3].ToString()); } catch { }
                    try { tr = float.Parse(dt.Rows[i][4].ToString()); } catch { }
                    try { ex = float.Parse(dt.Rows[i][5].ToString()); } catch { }
                    try { smd = float.Parse(dt.Rows[i][6].ToString()); } catch { }
                    try { bd = float.Parse(dt.Rows[i][7].ToString()); } catch { }
                    try { er = float.Parse(dt.Rows[i][8].ToString()); } catch { }
                    try { iml_bds = float.Parse(dt.Rows[i][9].ToString()); } catch { }
                    try { iml_cnghe = float.Parse(dt.Rows[i][10].ToString()); } catch { }
                    try { iml_cnghiep = float.Parse(dt.Rows[i][11].ToString()); } catch { }
                    try { iml_dich_vu = float.Parse(dt.Rows[i][12].ToString()); } catch { }
                    try { iml_hang_td = float.Parse(dt.Rows[i][13].ToString()); } catch { }
                    try { iml_nang_luong = float.Parse(dt.Rows[i][14].ToString()); } catch { }
                    try { iml_nguyen_vl = float.Parse(dt.Rows[i][15].ToString()); } catch { }
                    try { iml_nong_nghiep = float.Parse(dt.Rows[i][16].ToString()); } catch { }
                    try { iml_vien_thong = float.Parse(dt.Rows[i][17].ToString()); } catch { }
                    try { iml_yte = float.Parse(dt.Rows[i][18].ToString()); } catch { }
                    try { img_bds = float.Parse(dt.Rows[i][19].ToString()); } catch { }
                    try { img_cnghe = float.Parse(dt.Rows[i][20].ToString()); } catch { }
                    try { img_cnghiep = float.Parse(dt.Rows[i][21].ToString()); } catch { }
                    try { img_dich_vu = float.Parse(dt.Rows[i][22].ToString()); } catch { }
                    try { img_hang_td = float.Parse(dt.Rows[i][23].ToString()); } catch { }
                    try { img_nang_luong = float.Parse(dt.Rows[i][24].ToString()); } catch { }
                    try { img_nguyen_vl = float.Parse(dt.Rows[i][25].ToString()); } catch { }
                    try { img_nong_nghiep = float.Parse(dt.Rows[i][26].ToString()); } catch { }
                    try { img_vien_thong = float.Parse(dt.Rows[i][27].ToString()); } catch { }
                    try { img_yte = float.Parse(dt.Rows[i][28].ToString()); } catch { }

                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "update_tblDuLieuDoanhNghiep1",
                         Nam, gdb, cpi, ir, tr, ex, smd, bd, er, iml_bds, iml_cnghe, iml_cnghiep, iml_dich_vu, iml_hang_td, iml_nang_luong, iml_nguyen_vl, iml_nong_nghiep, iml_vien_thong, iml_yte,
                          img_bds, img_cnghe, img_cnghiep, img_dich_vu, img_hang_td, img_nang_luong, img_nguyen_vl, img_nong_nghiep, img_vien_thong, img_yte
                         );
                }
                catch (Exception ex)
                {
                    strErros += "-" + i.ToString();

                }

            }
            */
            #endregion
            #region
            /*
            string strErros = "";
            for (int i = 0; i < 5000; i++)
            {
                try
                {
                    string MaDN = dt.Rows[i][0].ToString();
                    string Nam = dt.Rows[i][1].ToString();

                    float sow = -999;
                    float oc = -999;


                    try { sow = float.Parse(dt.Rows[i][2].ToString()); } catch { }
                    try { oc = float.Parse(dt.Rows[i][3].ToString()); } catch { }
                   
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "[update_tblDuLieuDoanhNghiep2]",
                         MaDN, Nam, sow,oc
                         );
                }
                catch (Exception ex)
                {
                    strErros += "-" + i.ToString();

                }

            }*/
            #endregion
            #region
            string strErros = "";
            for (int i = 0; i < 250; i++)
            {
                try
                {
                    string MaDN = dt.Rows[i][1].ToString().Trim();

                    string strTen = dt.Rows[i][2].ToString().Trim();
                    string strMaTinh = dt.Rows[i][3].ToString().Trim();


                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.ConnectionString, "[update_tblDuLieuDoanhNghiep3]",
                         MaDN, strTen, strMaTinh
                         );
                }
                catch (Exception ex)
                {
                    strErros += "-" + i.ToString();

                }

            }
            #endregion
            MessageBox.Show("Thanh cong !");
            MessageBox.Show(strErros);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region no_ngan_han_chia_tong_tai_san
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ExcelFile ef = new ExcelFile();
            DataTable dt999 = new DataTable();
            dt999.Columns.Add("Nganh");
            for (int i = 0; i < dtNam.Rows.Count; i++)
            {
                dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            }
            for (int i = 0; i < dtNganh.Rows.Count; i++)
            {
                DataRow dr = dt999.NewRow();
                string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
                string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
                dr[0] = strNganh;
                for (int j = 0; j < dtNam.Rows.Count; j++)
                {
                    string strNam = dtNam.Rows[j]["Nam"].ToString();
                    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_no_ngan_han_tong_tai_san", strNam, codeNganh).ToString();
                    dr[j + 1] = strData;
                }
                dt999.Rows.Add(dr);
            }
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dt999,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("no_ngan_han_chia_tong_tai_san" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region tong_no_chia_tong_tai_san
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_tong_no_chia_tong_tai_san", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("tong_no_chia_tong_tai_san" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion

            #region [Xuat du lieu theo chi so va nam]
            //string[] strNhanToViMos = new string[] { "GDP", "CPI", "IR", "TR", "EX", "SMD", "BD", "ER", "IML", "IMG", "TongNo", "NoNganHan", "NoDaiHan", "TongTaiSan", "DoanhThuThuan", "LoiNhuanSauThue", "VonChuSoHuu", "TaiSanCoDinhHuuHinh", "TangTruongDoanhNghiep", "TaiSanNganHan", "SO", "FO" };
            //string[] strs = new string[] { "TongNo", "NoNganHan", "NoDaiHan", "TongTaiSan", "DoanhThuThuan", "LoiNhuanSauThue", "TaiSanCoDinhHuuHinh", "TangTruongDoanhNghiep", "TaiSanNganHan", "SO", "FO" };

            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ////sql = "SELECT  distinct(MADN),TenNganh,San,TenTinh FROM [dbo].[tblDuLieuDoanhNghiep] order by San,TenNganh, MADN";
            ////sql = "SELECT  distinct(MADN),TenNganh,San,TenTinh FROM [dbo].[tblDuLieuDoanhNghiep] order by TenNganh, MADN";
            //sql = "SELECT  distinct(MADN),TenNganh,San,TenTinh FROM [dbo].[tblDuLieuDoanhNghiep] order by MADN";
            //DataTable dtDN = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //foreach (string strNhanToViMo in strNhanToViMos)
            //{
            //    DataTable dt999 = new DataTable();
            //    dt999.Columns.Add("STT");
            //    dt999.Columns.Add("MADN");
            //    dt999.Columns.Add("TenNganh");
            //    dt999.Columns.Add("San");
            //    dt999.Columns.Add("Tinh");
            //    for (int i = 0; i < dtNam.Rows.Count; i++)
            //    {
            //        dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //    }
            //    for (int i = 0; i < dtDN.Rows.Count; i++)
            //    {
            //        DataRow dr = dt999.NewRow();
            //        string MaDN = dtDN.Rows[i]["MADN"].ToString();
            //        string TenNganh = dtDN.Rows[i]["TenNganh"].ToString();
            //        string San = dtDN.Rows[i]["San"].ToString();
            //        string Tinh = dtDN.Rows[i]["TenTinh"].ToString();
            //        dr[0] = i + 1;
            //        dr[1] = MaDN;
            //        dr[2] = TenNganh;
            //        dr[3] = San;
            //        dr[4] = Tinh;
            //        for (int j = 0; j < dtNam.Rows.Count; j++)
            //        {
            //            string strNam = dtNam.Rows[j]["Nam"].ToString();
            //            sql = string.Format("select {2} from [dbo].[tblDuLieuDoanhNghiep] where Nam='{0}' and MaDN='{1}' ;", strNam, MaDN, strNhanToViMo);
            //            string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, CommandType.Text, sql).ToString();
            //            dr[j + 5] = strData;
            //        }
            //        dt999.Rows.Add(dr);
            //    }
            //    ExcelWorksheet ws3 = ef.Worksheets.Add(strNhanToViMo);
            //    ws3.InsertDataTable(dt999,
            //    new InsertDataTableOptions()
            //    {
            //        ColumnHeaders = true,
            //        StartRow = 0
            //    });
            //}
            //ef.Save("phuong_dau_vao" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region [phuong_get_tong_hop_bang2.33]
            ////GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ////string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            ////DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ////ExcelFile ef = new ExcelFile();
            ////DataTable dt999 = new DataTable();
            ////dt999.Columns.Add("TieuChi");
            ////for (int i = 0; i < dtNam.Rows.Count; i++)
            ////{
            ////    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            ////}
            ////#region 1
            ////DataRow dr1 = dt999.NewRow();
            ////dr1[0] = "CPVCSH";
            ////for (int j = 0; j < dtNam.Rows.Count; j++)
            ////{
            ////    string strNam = dtNam.Rows[j]["Nam"].ToString();
            ////    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_chi_phi_von_chu_so_huu_theonam", strNam).ToString();
            ////    dr1[j + 1] = strData;
            ////}
            ////dt999.Rows.Add(dr1);
            ////#endregion
            ////#region 2
            ////DataRow dr2 = dt999.NewRow();
            ////dr2[0] = "CP lãi vay";
            ////for (int j = 0; j < dtNam.Rows.Count; j++)
            ////{
            ////    string strNam = dtNam.Rows[j]["Nam"].ToString();
            ////    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_chi_phi_no_sau_thue_theonam", strNam).ToString();
            ////    dr2[j + 1] = strData;
            ////}
            ////dt999.Rows.Add(dr2);
            ////#endregion
            ////#region 3
            ////DataRow dr3 = dt999.NewRow();
            ////dr3[0] = "Tỷ trọng VCSH (%)";
            ////for (int j = 0; j < dtNam.Rows.Count; j++)
            ////{
            ////    string strNam = dtNam.Rows[j]["Nam"].ToString();
            ////    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_ty_trong_von_chu_so_huu_theonam", strNam).ToString();
            ////    dr3[j + 1] = strData;
            ////}
            ////dt999.Rows.Add(dr3);
            ////#endregion
            ////#region 4
            ////DataRow dr4 = dt999.NewRow();
            ////dr4[0] = "Tỷ trọng Nợ (%)";
            ////for (int j = 0; j < dtNam.Rows.Count; j++)
            ////{
            ////    string strNam = dtNam.Rows[j]["Nam"].ToString();
            ////    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_ty_trong_no_vay_theonam", strNam).ToString();
            ////    dr4[j + 1] = strData;
            ////}
            ////dt999.Rows.Add(dr4);
            ////#endregion
            ////#region 5
            ////DataRow dr5 = dt999.NewRow();
            ////dr5[0] = "WACC";
            ////for (int j = 0; j < dtNam.Rows.Count; j++)
            ////{
            ////    string strNam = dtNam.Rows[j]["Nam"].ToString();
            ////    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_wacc_theonam", strNam).ToString();
            ////    dr5[j + 1] = strData;
            ////}
            ////dt999.Rows.Add(dr5);
            ////#endregion
            ////ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ////ws3.InsertDataTable(dt999,
            ////new InsertDataTableOptions()
            ////{
            ////    ColumnHeaders = true,
            ////    StartRow = 0
            ////});
            ////ef.Save("phuong_get_tonghop232" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region [phuong_get_beta]
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_beta", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_get_beta" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region [phuong_get_wacc]
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_wacc", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_get_wacc" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region [phuong_get_chi_phi_von_chu_so_huu]
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_chi_phi_von_chu_so_huu", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_get_chi_phi_von_chu_so_huu" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region chi_phi_no_sau_thue
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_chi_phi_no_sau_thue", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_get_chi_phi_no_sau_thue" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region chiphilaivay_chiatongchiphi
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_chiphilaivay_chiatongchiphi", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_get_chiphilaivay_chiatongchiphi" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region taisancodinh_tongtaisan
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_taisancodinh_tongtaisan_theonameandnganh", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("taisancodinh_tongtaisan" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region vonchusohuuchianodaihan
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = " select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonameandnganh", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("vonchusohuuchianodaihan" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region Hệ số vốn chủ sở hữu/Tong No
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nam");
            //dt999.Columns.Add("TongCong");
            //dt999.Columns.Add("500");
            //dt999.Columns.Add("1000");
            //dt999.Columns.Add("5000");
            //dt999.Columns.Add("10000");
            //dt999.Columns.Add("10000_p");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}

            //for (int j = 0; j < dtNam.Rows.Count; j++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNam = dtNam.Rows[j]["Nam"].ToString();
            //    dr[0] = strNam;
            //    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongno_theonam", strNam, 0, 500000000000).ToString();
            //    float f1 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongno_theonam", strNam, 500000000000, 1000000000000).ToString();
            //    float f2 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongno_theonam", strNam, 1000000000000, 5000000000000).ToString();
            //    float f3 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongno_theonam", strNam, 5000000000000, 10000000000000).ToString();
            //    float f4 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongno_theonam", strNam, 10000000000000, 1000000000000000).ToString();
            //    float f5 = float.Parse(strData);
            //    dr[1] = (f1 + f2 + f3 + f4 + f5) / 5;
            //    dr[2] = f1;
            //    dr[3] = f2;
            //    dr[4] = f3;
            //    dr[5] = f4;
            //    dr[6] = f5;
            //    dt999.Rows.Add(dr);
            //}

            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_dldn_xuat_vonchusohuu_tongno_nam" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region Hệ số vốn chủ sở hữu/Nợ dài hạn
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] where Nam<>'2007' order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nam");
            //dt999.Columns.Add("TongCong");
            //dt999.Columns.Add("500");
            //dt999.Columns.Add("1000");
            //dt999.Columns.Add("5000");
            //dt999.Columns.Add("10000");
            //dt999.Columns.Add("10000_p");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}

            //for (int j = 0; j < dtNam.Rows.Count; j++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNam = dtNam.Rows[j]["Nam"].ToString();
            //    dr[0] = strNam;
            //    string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonam",strNam, 0, 500000000000).ToString();
            //    float f1 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonam", strNam, 500000000000, 1000000000000).ToString();
            //    float f2 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonam", strNam, 1000000000000, 5000000000000).ToString();
            //    float f3 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonam", strNam, 5000000000000, 10000000000000).ToString();
            //    float f4 = float.Parse(strData);
            //    strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_nodaihan_theonam", strNam, 10000000000000, 1000000000000000).ToString();
            //    float f5 = float.Parse(strData);
            //    dr[1] = (f1+f2+f3+f4+ f5)/5;
            //    dr[2] = f1;
            //    dr[3] = f2;
            //    dr[4] = f3;
            //    dr[5] = f4;
            //    dr[6] = f5;
            //    dt999.Rows.Add(dr);
            //}

            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_dldn_xuat_vonchusohuu_nodaihan_nam" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            #region No Dai han chia tong tai san
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //    DataRow dr = dt999.NewRow();
            //    string strNganh = dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_nodaihan_tongvon_theonameandnganh", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_dldn_xuat_nodaihan_tongtaisan_namnganh" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            // He so von chu so huu tren tong von trung binh theo nam va nganh
            #region
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //sql = "SELECT  distinct(CodeNganh),TenNganh FROM [dbo].[tblDuLieuDoanhNghiep] order by CodeNganh";
            //DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //DataTable dt999 = new DataTable();
            //dt999.Columns.Add("Nganh");
            //for (int i = 0; i < dtNam.Rows.Count; i++)
            //{
            //    dt999.Columns.Add(dtNam.Rows[i]["Nam"].ToString());
            //}
            //for (int i = 0; i < dtNganh.Rows.Count; i++)
            //{
            //   DataRow dr= dt999.NewRow();
            //    string strNganh= dtNganh.Rows[i]["TenNganh"].ToString();
            //    string codeNganh= dtNganh.Rows[i]["CodeNganh"].ToString();
            //    dr[0] = strNganh;
            //    for (int j = 0; j < dtNam.Rows.Count; j++)
            //    {
            //        string strNam = dtNam.Rows[j]["Nam"].ToString();
            //        string strData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(common.ConnectionString, "phuong_get_vonchusohuu_tongtaisan_theonameandnganh", strNam, codeNganh).ToString();
            //        dr[j + 1] = strData;
            //    }
            //    dt999.Rows.Add(dr);
            //}
            //ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            //ws3.InsertDataTable(dt999,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //ef.Save("phuong_dldn_xuat_hesovonchusohuu_chiatongvon_namnganh" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            // He so von chu so huu tren tong von trung binh theo nam
            #region
            //string strTest = "thanh cong !";
            //string str3Trung = "CMTLonhon10";
            //GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] order by Nam";
            //DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            //ExcelFile ef = new ExcelFile();
            //for (int i=0;i<dtNam.Rows.Count;i++)
            //{
            //    string strNam = dtNam.Rows[i]["Nam"].ToString();
            //    ExcelWorksheet ws3 = ef.Worksheets.Add(strNam);
            //    //sql = string.Format("  select * from [dbo].[tblDuLieuDoanhNghiep] where Nam='{0}' order by CodeNganh, San desc,STTDN", strNam);
            //    DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, "phuong_get_vonchusohuu_tongtaisan_theoname",strNam).Tables[0];
            //    ws3.InsertDataTable(dt999,
            //  new InsertDataTableOptions()
            //  {
            //      ColumnHeaders = true,
            //      StartRow = 0
            //  });
            //}
            //ef.Save("phuong_dldn_xuat_hesovonchusohuu_chiatongvon_nam"+ DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");

            #endregion
            //theo nam
            #region
            /*
            string strTest = "thanh cong !";
            string str3Trung = "CMTLonhon10";
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            string sql = "  select distinct(Nam)  FROM [stttt].[dbo].[tblDuLieuDoanhNghiep] order by Nam";
            DataTable dtNam = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ExcelFile ef = new ExcelFile();
            for (int i=0;i<dtNam.Rows.Count;i++)
            {
                string strNam = dtNam.Rows[i]["Nam"].ToString();
                ExcelWorksheet ws3 = ef.Worksheets.Add(strNam);
                sql = string.Format("  select * from [dbo].[tblDuLieuDoanhNghiep] where Nam='{0}' order by CodeNganh, San desc,STTDN", strNam);
                DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
                ws3.InsertDataTable(dt999,
              new InsertDataTableOptions()
              {
                  ColumnHeaders = true,
                  StartRow = 0
              });
            }
            ef.Save("phuong_dldn_xuat_theo_nam"+ DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            */
            #endregion
            #region Theo nganh
            /*
            string strTest = "thanh cong !";
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            string sql = "SELECT  distinct(CodeNganh) FROM [dbo].[tblDuLieuDoanhNghiep]";
            DataTable dtNganh = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ExcelFile ef = new ExcelFile();
            for (int i = 0; i < dtNganh.Rows.Count; i++)
            {
                string strNganh = dtNganh.Rows[i]["CodeNganh"].ToString();
                ExcelWorksheet ws3 = ef.Worksheets.Add(strNganh);
                sql = string.Format("select * from [dbo].[tblDuLieuDoanhNghiep] where CodeNganh='{0}' order by CodeNganh, San desc,STTDN,Nam", strNganh);
                DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
                ws3.InsertDataTable(dt999,
              new InsertDataTableOptions()
              {
                  ColumnHeaders = true,
                  StartRow = 0
              });
            }
            ef.Save("phuong_dldn_xuat_theo_nganh" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
           */
            #endregion
            #region theo san
            /*
            string strTest = "thanh cong !";
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            string sql = "SELECT  distinct(san) FROM [dbo].[tblDuLieuDoanhNghiep]";
            DataTable dtSan = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
            ExcelFile ef = new ExcelFile();
            for (int i = 0; i < dtSan.Rows.Count; i++)
            {
                string strSan = dtSan.Rows[i]["san"].ToString();
                ExcelWorksheet ws3 = ef.Worksheets.Add(strSan);
                sql = string.Format(" select * from [dbo].[tblDuLieuDoanhNghiep] where san='{0}' order by CodeNganh, San desc,STTDN,Nam", strSan);
                DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString, CommandType.Text, sql).Tables[0];
                ws3.InsertDataTable(dt999,
              new InsertDataTableOptions()
              {
                  ColumnHeaders = true,
                  StartRow = 0
              });
            }
            ef.Save("phuong_dldn_xuat_theo_san" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            */
            #endregion
            MessageBox.Show("Thanh cong");
        }

        private void btnXuat_du_lieu_athanh_Click(object sender, EventArgs e)
        {
            string sql = "select * from AS_Edu_Survey_Ext_BaiLam";
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            MessageBox.Show(dt.Rows.Count.ToString());
            a_thanh_data a_thanh_temp = new a_thanh_data();
            // Day du lieu vao trong list
            #region du lieu cua bang 1
            #region KhoiTao dt1
            Dictionary<string, a_thanh_data> dt1 = new Dictionary<string, a_thanh_data>();

            a_thanh_temp.CBQL1 = 0;
            a_thanh_temp.CBQL2 = 0;
            a_thanh_temp.CBQL3 = 0;
            a_thanh_temp.CBQL4 = 0;
            a_thanh_temp.CBQL5 = 0;
            a_thanh_temp.CBQL6 = 0;
            a_thanh_temp.CBQL7 = 0;

            a_thanh_temp.GV1 = 0;
            a_thanh_temp.GV2 = 0;
            a_thanh_temp.GV3 = 0;
            a_thanh_temp.GV4 = 0;
            a_thanh_temp.GV5 = 0;
            a_thanh_temp.GV6 = 0;
            a_thanh_temp.GV7 = 0;

            a_thanh_temp.NV1 = 0;
            a_thanh_temp.NV2 = 0;
            a_thanh_temp.NV3 = 0;
            a_thanh_temp.NV4 = 0;
            a_thanh_temp.NV5 = 0;
            a_thanh_temp.NV6 = 0;
            a_thanh_temp.NV7 = 0;

            a_thanh_temp.TONG1 = 0;
            a_thanh_temp.TONG2 = 0;
            a_thanh_temp.TONG3 = 0;
            a_thanh_temp.TONG4 = 0;
            a_thanh_temp.TONG5 = 0;
            a_thanh_temp.TONG6 = 0;
            a_thanh_temp.TONG7 = 0;

            for (int i = 1; i < 162; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i; dt1.Add("d1_" + i.ToString(), a_thanh_temp1);
            }
            #endregion
            #region khoi tao dt1_4
            Dictionary<string, a_thanh_data> dt1_4 = new Dictionary<string, a_thanh_data>();
            for (int i = 1; i < 162; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i; dt1_4.Add("d4_" + i.ToString() + "_1", a_thanh_temp1);

                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                a_thanh_temp2.stt = i; dt1_4.Add("d4_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region Khoi Tao dt1_5
            Dictionary<string, a_thanh_data> dt1_5 = new Dictionary<string, a_thanh_data>();
            #region 21
            for (int i = 1; i < 21; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                #region
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                #endregion
                a_thanh_temp1.stt = i; dt1_5.Add("d5_g1_" + i.ToString() + "_1", a_thanh_temp1);
                #region 
                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                #endregion
                a_thanh_temp2.stt = i; dt1_5.Add("d5_g1_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region 6
            for (int i = 1; i < 6; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                #region 
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                #endregion
                a_thanh_temp1.stt = i + 20; dt1_5.Add("d5_g2_" + i.ToString() + "_1", a_thanh_temp1);
                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                #region
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                #endregion
                a_thanh_temp2.stt = i + 20; dt1_5.Add("d5_g2_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region 5
            for (int i = 1; i < 5; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                #region
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                #endregion
                a_thanh_temp1.stt = i + 25; dt1_5.Add("d5_g3_" + i.ToString() + "_1", a_thanh_temp1);
                #region
                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                #endregion
                a_thanh_temp2.stt = i + 25; dt1_5.Add("d5_g3_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region 5
            for (int i = 1; i < 5; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i + 29; dt1_5.Add("d5_g4_" + i.ToString() + "_1", a_thanh_temp1);

                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                a_thanh_temp2.stt = i + 29; dt1_5.Add("d5_g4_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region 6
            for (int i = 1; i < 6; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i + 33; dt1_5.Add("d5_g5_" + i.ToString() + "_1", a_thanh_temp1);

                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                a_thanh_temp2.stt = i + 33; dt1_5.Add("d5_g5_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #region 5
            for (int i = 1; i < 5; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i + 38; dt1_5.Add("d5_g6_" + i.ToString() + "_1", a_thanh_temp1);

                a_thanh_data a_thanh_temp2 = new a_thanh_data();
                a_thanh_temp2.CBQL1 = 0;
                a_thanh_temp2.CBQL2 = 0;
                a_thanh_temp2.CBQL3 = 0;
                a_thanh_temp2.CBQL4 = 0;
                a_thanh_temp2.CBQL5 = 0;
                a_thanh_temp2.CBQL6 = 0;
                a_thanh_temp2.CBQL7 = 0;

                a_thanh_temp2.GV1 = 0;
                a_thanh_temp2.GV2 = 0;
                a_thanh_temp2.GV3 = 0;
                a_thanh_temp2.GV4 = 0;
                a_thanh_temp2.GV5 = 0;
                a_thanh_temp2.GV6 = 0;
                a_thanh_temp2.GV7 = 0;

                a_thanh_temp2.NV1 = 0;
                a_thanh_temp2.NV2 = 0;
                a_thanh_temp2.NV3 = 0;
                a_thanh_temp2.NV4 = 0;
                a_thanh_temp2.NV5 = 0;
                a_thanh_temp2.NV6 = 0;
                a_thanh_temp2.NV7 = 0;

                a_thanh_temp2.SDLD1 = 0;
                a_thanh_temp2.SDLD2 = 0;
                a_thanh_temp2.SDLD3 = 0;
                a_thanh_temp2.SDLD4 = 0;
                a_thanh_temp2.SDLD5 = 0;
                a_thanh_temp2.SDLD6 = 0;
                a_thanh_temp2.SDLD7 = 0;

                a_thanh_temp2.SV1 = 0;
                a_thanh_temp2.SV2 = 0;
                a_thanh_temp2.SV3 = 0;
                a_thanh_temp2.SV4 = 0;
                a_thanh_temp2.SV5 = 0;
                a_thanh_temp2.SV6 = 0;
                a_thanh_temp2.SV7 = 0;

                a_thanh_temp2.CUUSV1 = 0;
                a_thanh_temp2.CUUSV2 = 0;
                a_thanh_temp2.CUUSV3 = 0;
                a_thanh_temp2.CUUSV4 = 0;
                a_thanh_temp2.CUUSV5 = 0;
                a_thanh_temp2.CUUSV6 = 0;
                a_thanh_temp2.CUUSV7 = 0;

                a_thanh_temp2.TONG1 = 0;
                a_thanh_temp2.TONG2 = 0;
                a_thanh_temp2.TONG3 = 0;
                a_thanh_temp2.TONG4 = 0;
                a_thanh_temp2.TONG5 = 0;
                a_thanh_temp2.TONG6 = 0;
                a_thanh_temp2.TONG7 = 0;
                a_thanh_temp2.stt = i + 38; dt1_5.Add("d5_g6_" + i.ToString() + "_2", a_thanh_temp2);
            }
            #endregion
            #endregion
            #endregion
            #region du lieu cua bang 2
            Dictionary<string, a_thanh_data> dt2 = new Dictionary<string, a_thanh_data>();
            for (int i = 1; i < 116; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i; dt2.Add("d2_" + i.ToString(), a_thanh_temp1);
            }
            #endregion
            #region du lieu cua bang 3
            Dictionary<string, a_thanh_data> dt3 = new Dictionary<string, a_thanh_data>();
            for (int i = 1; i < 116; i++)
            {
                a_thanh_data a_thanh_temp1 = new a_thanh_data();
                a_thanh_temp1.CBQL1 = 0;
                a_thanh_temp1.CBQL2 = 0;
                a_thanh_temp1.CBQL3 = 0;
                a_thanh_temp1.CBQL4 = 0;
                a_thanh_temp1.CBQL5 = 0;
                a_thanh_temp1.CBQL6 = 0;
                a_thanh_temp1.CBQL7 = 0;

                a_thanh_temp1.GV1 = 0;
                a_thanh_temp1.GV2 = 0;
                a_thanh_temp1.GV3 = 0;
                a_thanh_temp1.GV4 = 0;
                a_thanh_temp1.GV5 = 0;
                a_thanh_temp1.GV6 = 0;
                a_thanh_temp1.GV7 = 0;

                a_thanh_temp1.NV1 = 0;
                a_thanh_temp1.NV2 = 0;
                a_thanh_temp1.NV3 = 0;
                a_thanh_temp1.NV4 = 0;
                a_thanh_temp1.NV5 = 0;
                a_thanh_temp1.NV6 = 0;
                a_thanh_temp1.NV7 = 0;

                a_thanh_temp1.SDLD1 = 0;
                a_thanh_temp1.SDLD2 = 0;
                a_thanh_temp1.SDLD3 = 0;
                a_thanh_temp1.SDLD4 = 0;
                a_thanh_temp1.SDLD5 = 0;
                a_thanh_temp1.SDLD6 = 0;
                a_thanh_temp1.SDLD7 = 0;

                a_thanh_temp1.SV1 = 0;
                a_thanh_temp1.SV2 = 0;
                a_thanh_temp1.SV3 = 0;
                a_thanh_temp1.SV4 = 0;
                a_thanh_temp1.SV5 = 0;
                a_thanh_temp1.SV6 = 0;
                a_thanh_temp1.SV7 = 0;

                a_thanh_temp1.CUUSV1 = 0;
                a_thanh_temp1.CUUSV2 = 0;
                a_thanh_temp1.CUUSV3 = 0;
                a_thanh_temp1.CUUSV4 = 0;
                a_thanh_temp1.CUUSV5 = 0;
                a_thanh_temp1.CUUSV6 = 0;
                a_thanh_temp1.CUUSV7 = 0;

                a_thanh_temp1.TONG1 = 0;
                a_thanh_temp1.TONG2 = 0;
                a_thanh_temp1.TONG3 = 0;
                a_thanh_temp1.TONG4 = 0;
                a_thanh_temp1.TONG5 = 0;
                a_thanh_temp1.TONG6 = 0;
                a_thanh_temp1.TONG7 = 0;
                a_thanh_temp1.stt = i; dt3.Add("d3_" + i.ToString(), a_thanh_temp1);
            }

            #endregion
            #region xu ly du lieu vao dictionary
            int iDemTest = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int iTemplate = int.Parse(dt.Rows[i]["Template"].ToString());
                string strDTTL = dt.Rows[i]["DoiTuongTraLoi"].ToString();
                bool bGioiTinh = bool.Parse(dt.Rows[i]["GioiTinh"].ToString());
                string strBaiLam = dt.Rows[i]["BaiLam"].ToString();
                string[] strBaiLamSplit = strBaiLam.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                switch (iTemplate)
                {
                    case 1:
                        #region Template 1
                        switch (strDTTL)
                        {
                            case "CBQL":
                                #region CBQL

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_CBQL = new a_thanh_data();
                                        if (dt1.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_CBQL))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_CBQL.CBQL1 = a_thanh_temp_CBQL.CBQL1 + 1;
                                                    a_thanh_temp_CBQL.TONG1 = a_thanh_temp_CBQL.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_CBQL.CBQL2 = a_thanh_temp_CBQL.CBQL2 + 1;
                                                    a_thanh_temp_CBQL.TONG2 = a_thanh_temp_CBQL.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_CBQL.CBQL3 = a_thanh_temp_CBQL.CBQL3 + 1;
                                                    a_thanh_temp_CBQL.TONG3 = a_thanh_temp_CBQL.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_CBQL.CBQL4 = a_thanh_temp_CBQL.CBQL4 + 1;
                                                    a_thanh_temp_CBQL.TONG4 = a_thanh_temp_CBQL.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_CBQL.CBQL5 = a_thanh_temp_CBQL.CBQL5 + 1;
                                                    a_thanh_temp_CBQL.TONG5 = a_thanh_temp_CBQL.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_CBQL.CBQL6 = a_thanh_temp_CBQL.CBQL6 + 1;
                                                    a_thanh_temp_CBQL.TONG6 = a_thanh_temp_CBQL.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_CBQL.CBQL7 = a_thanh_temp_CBQL.CBQL7 + 1;
                                                    a_thanh_temp_CBQL.TONG7 = a_thanh_temp_CBQL.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt1[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_CBQL;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {
                                                iDemTest++;
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.CBQL1 = a_thanh_temp_B41.CBQL1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;

                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.CBQL2 = a_thanh_temp_B41.CBQL2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.CBQL3 = a_thanh_temp_B41.CBQL3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.CBQL4 = a_thanh_temp_B42.CBQL4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.CBQL5 = a_thanh_temp_B42.CBQL5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.CBQL6 = a_thanh_temp_B42.CBQL6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.CBQL1 = a_thanh_temp_B51.CBQL1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.CBQL2 = a_thanh_temp_B51.CBQL2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.CBQL3 = a_thanh_temp_B51.CBQL3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.CBQL4 = a_thanh_temp_B52.CBQL4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.CBQL5 = a_thanh_temp_B52.CBQL5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.CBQL6 = a_thanh_temp_B52.CBQL6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case "NV":
                                #region NV

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_NV = new a_thanh_data();
                                        if (dt1.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_NV))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_NV.NV1 = a_thanh_temp_NV.NV1 + 1;
                                                    a_thanh_temp_NV.TONG1 = a_thanh_temp_NV.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_NV.NV2 = a_thanh_temp_NV.NV2 + 1;
                                                    a_thanh_temp_NV.TONG2 = a_thanh_temp_NV.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_NV.NV3 = a_thanh_temp_NV.NV3 + 1;
                                                    a_thanh_temp_NV.TONG3 = a_thanh_temp_NV.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_NV.NV4 = a_thanh_temp_NV.NV4 + 1;
                                                    a_thanh_temp_NV.TONG4 = a_thanh_temp_NV.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_NV.NV5 = a_thanh_temp_NV.NV5 + 1;
                                                    a_thanh_temp_NV.TONG5 = a_thanh_temp_NV.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_NV.NV6 = a_thanh_temp_NV.NV6 + 1;
                                                    a_thanh_temp_NV.TONG6 = a_thanh_temp_NV.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_NV.NV7 = a_thanh_temp_NV.NV7 + 1;
                                                    a_thanh_temp_NV.TONG7 = a_thanh_temp_NV.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt1[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_NV;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {

                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.NV1 = a_thanh_temp_B41.NV1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;
                                                        //iDemTest++;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.NV2 = a_thanh_temp_B41.NV2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.NV3 = a_thanh_temp_B41.NV3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.NV4 = a_thanh_temp_B42.NV4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.NV5 = a_thanh_temp_B42.NV5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.NV6 = a_thanh_temp_B42.NV6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.NV1 = a_thanh_temp_B51.NV1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.NV2 = a_thanh_temp_B51.NV2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.NV3 = a_thanh_temp_B51.NV3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.NV4 = a_thanh_temp_B52.NV4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.NV5 = a_thanh_temp_B52.NV5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.NV6 = a_thanh_temp_B52.NV6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case "GV":
                                #region GV

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_GV = new a_thanh_data();
                                        if (dt1.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_GV))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_GV.GV1 = a_thanh_temp_GV.GV1 + 1;
                                                    a_thanh_temp_GV.TONG1 = a_thanh_temp_GV.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_GV.GV2 = a_thanh_temp_GV.GV2 + 1;
                                                    a_thanh_temp_GV.TONG2 = a_thanh_temp_GV.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_GV.GV3 = a_thanh_temp_GV.GV3 + 1;
                                                    a_thanh_temp_GV.TONG3 = a_thanh_temp_GV.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_GV.GV4 = a_thanh_temp_GV.GV4 + 1;
                                                    a_thanh_temp_GV.TONG4 = a_thanh_temp_GV.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_GV.GV5 = a_thanh_temp_GV.GV5 + 1;
                                                    a_thanh_temp_GV.TONG5 = a_thanh_temp_GV.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_GV.GV6 = a_thanh_temp_GV.GV6 + 1;
                                                    a_thanh_temp_GV.TONG6 = a_thanh_temp_GV.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_GV.GV7 = a_thanh_temp_GV.GV7 + 1;
                                                    a_thanh_temp_GV.TONG7 = a_thanh_temp_GV.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt1[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_GV;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {

                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.GV1 = a_thanh_temp_B41.GV1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;
                                                        // iDemTest++;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.GV2 = a_thanh_temp_B41.GV2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.GV3 = a_thanh_temp_B41.GV3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.GV4 = a_thanh_temp_B42.GV4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.GV5 = a_thanh_temp_B42.GV5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.GV6 = a_thanh_temp_B42.GV6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.GV1 = a_thanh_temp_B51.GV1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.GV2 = a_thanh_temp_B51.GV2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.GV3 = a_thanh_temp_B51.GV3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.GV4 = a_thanh_temp_B52.GV4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.GV5 = a_thanh_temp_B52.GV5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.GV6 = a_thanh_temp_B52.GV6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            default: break;
                        }
                        #endregion
                        break;
                    case 2:
                        #region Template 2
                        switch (strDTTL)
                        {
                            case "BSDLD":
                                #region SDLD

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_SDLD = new a_thanh_data();
                                        strs1[0] = strs1[0].Replace("d3", "d2");
                                        if (dt2.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_SDLD))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_SDLD.SDLD1 = a_thanh_temp_SDLD.SDLD1 + 1;
                                                    a_thanh_temp_SDLD.TONG1 = a_thanh_temp_SDLD.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_SDLD.SDLD2 = a_thanh_temp_SDLD.SDLD2 + 1;
                                                    a_thanh_temp_SDLD.TONG2 = a_thanh_temp_SDLD.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_SDLD.SDLD3 = a_thanh_temp_SDLD.SDLD3 + 1;
                                                    a_thanh_temp_SDLD.TONG3 = a_thanh_temp_SDLD.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_SDLD.SDLD4 = a_thanh_temp_SDLD.SDLD4 + 1;
                                                    a_thanh_temp_SDLD.TONG4 = a_thanh_temp_SDLD.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_SDLD.SDLD5 = a_thanh_temp_SDLD.SDLD5 + 1;
                                                    a_thanh_temp_SDLD.TONG5 = a_thanh_temp_SDLD.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_SDLD.SDLD6 = a_thanh_temp_SDLD.SDLD6 + 1;
                                                    a_thanh_temp_SDLD.TONG6 = a_thanh_temp_SDLD.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_SDLD.SDLD7 = a_thanh_temp_SDLD.SDLD7 + 1;
                                                    a_thanh_temp_SDLD.TONG7 = a_thanh_temp_SDLD.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt2[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_SDLD;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {

                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.SDLD1 = a_thanh_temp_B41.SDLD1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;
                                                        // iDemTest++;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.SDLD2 = a_thanh_temp_B41.SDLD2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.SDLD3 = a_thanh_temp_B41.SDLD3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.SDLD4 = a_thanh_temp_B42.SDLD4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.SDLD5 = a_thanh_temp_B42.SDLD5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.SDLD6 = a_thanh_temp_B42.SDLD6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.SDLD1 = a_thanh_temp_B51.SDLD1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.SDLD2 = a_thanh_temp_B51.SDLD2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.SDLD3 = a_thanh_temp_B51.SDLD3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.SDLD4 = a_thanh_temp_B52.SDLD4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.SDLD5 = a_thanh_temp_B52.SDLD5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.SDLD6 = a_thanh_temp_B52.SDLD6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            default: break;
                        }
                        #endregion
                        break;
                    case 3:
                        #region Template 3
                        switch (strDTTL)
                        {
                            case "CSV":
                                #region CUUSV

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_CUUSV = new a_thanh_data();
                                        if (dt3.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_CUUSV))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_CUUSV.CUUSV1 = a_thanh_temp_CUUSV.CUUSV1 + 1;
                                                    a_thanh_temp_CUUSV.TONG1 = a_thanh_temp_CUUSV.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_CUUSV.CUUSV2 = a_thanh_temp_CUUSV.CUUSV2 + 1;
                                                    a_thanh_temp_CUUSV.TONG2 = a_thanh_temp_CUUSV.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_CUUSV.CUUSV3 = a_thanh_temp_CUUSV.CUUSV3 + 1;
                                                    a_thanh_temp_CUUSV.TONG3 = a_thanh_temp_CUUSV.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_CUUSV.CUUSV4 = a_thanh_temp_CUUSV.CUUSV4 + 1;
                                                    a_thanh_temp_CUUSV.TONG4 = a_thanh_temp_CUUSV.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_CUUSV.CUUSV5 = a_thanh_temp_CUUSV.CUUSV5 + 1;
                                                    a_thanh_temp_CUUSV.TONG5 = a_thanh_temp_CUUSV.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_CUUSV.CUUSV6 = a_thanh_temp_CUUSV.CUUSV6 + 1;
                                                    a_thanh_temp_CUUSV.TONG6 = a_thanh_temp_CUUSV.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_CUUSV.CUUSV7 = a_thanh_temp_CUUSV.CUUSV7 + 1;
                                                    a_thanh_temp_CUUSV.TONG7 = a_thanh_temp_CUUSV.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt3[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_CUUSV;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {

                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.CUUSV1 = a_thanh_temp_B41.CUUSV1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;
                                                        //iDemTest++;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.CUUSV2 = a_thanh_temp_B41.CUUSV2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.CUUSV3 = a_thanh_temp_B41.CUUSV3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.CUUSV4 = a_thanh_temp_B42.CUUSV4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.CUUSV5 = a_thanh_temp_B42.CUUSV5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.CUUSV6 = a_thanh_temp_B42.CUUSV6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.CUUSV1 = a_thanh_temp_B51.CUUSV1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.CUUSV2 = a_thanh_temp_B51.CUUSV2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.CUUSV3 = a_thanh_temp_B51.CUUSV3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.CUUSV4 = a_thanh_temp_B52.CUUSV4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.CUUSV5 = a_thanh_temp_B52.CUUSV5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.CUUSV6 = a_thanh_temp_B52.CUUSV6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            case "SVDH":
                                #region SV

                                foreach (string str1 in strBaiLamSplit)
                                {
                                    string[] strs1 = str1.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (strs1.Length.Equals(3))
                                    {
                                        a_thanh_data a_thanh_temp_SV = new a_thanh_data();
                                        if (dt3.TryGetValue(string.Format("{0}_{1}", strs1[0], strs1[1]), out a_thanh_temp_SV))
                                        {
                                            switch (strs1[2])
                                            {
                                                case "1":
                                                    a_thanh_temp_SV.SV1 = a_thanh_temp_SV.SV1 + 1;
                                                    a_thanh_temp_SV.TONG1 = a_thanh_temp_SV.TONG1 + 1;
                                                    break;
                                                case "2":
                                                    a_thanh_temp_SV.SV2 = a_thanh_temp_SV.SV2 + 1;
                                                    a_thanh_temp_SV.TONG2 = a_thanh_temp_SV.TONG2 + 1;
                                                    break;
                                                case "3":
                                                    a_thanh_temp_SV.SV3 = a_thanh_temp_SV.SV3 + 1;
                                                    a_thanh_temp_SV.TONG3 = a_thanh_temp_SV.TONG3 + 1;
                                                    break;
                                                case "4":
                                                    a_thanh_temp_SV.SV4 = a_thanh_temp_SV.SV4 + 1;
                                                    a_thanh_temp_SV.TONG4 = a_thanh_temp_SV.TONG4 + 1;
                                                    break;
                                                case "5":
                                                    a_thanh_temp_SV.SV5 = a_thanh_temp_SV.SV5 + 1;
                                                    a_thanh_temp_SV.TONG5 = a_thanh_temp_SV.TONG5 + 1;
                                                    break;
                                                case "6":
                                                    a_thanh_temp_SV.SV6 = a_thanh_temp_SV.SV6 + 1;
                                                    a_thanh_temp_SV.TONG6 = a_thanh_temp_SV.TONG6 + 1;
                                                    break;
                                                case "7":
                                                    a_thanh_temp_SV.SV7 = a_thanh_temp_SV.SV7 + 1;
                                                    a_thanh_temp_SV.TONG7 = a_thanh_temp_SV.TONG7 + 1;
                                                    break;
                                                default: break;
                                            }
                                            dt3[string.Format("{0}_{1}", strs1[0], strs1[1])] = a_thanh_temp_SV;
                                        }

                                    }
                                    else
                                    {
                                        if (strs1.Length.Equals(4))
                                        {
                                            // Xu ly bang 4
                                            a_thanh_data a_thanh_temp_B41 = new a_thanh_data();
                                            if (strs1[2].Equals("1") && dt1_4.TryGetValue(string.Format("{0}_{1}_1", strs1[0], strs1[1]), out a_thanh_temp_B41))
                                            {

                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B41.SV1 = a_thanh_temp_B41.SV1 + 1;
                                                        a_thanh_temp_B41.TONG1 = a_thanh_temp_B41.TONG1 + 1;
                                                        // iDemTest++;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B41.SV2 = a_thanh_temp_B41.SV2 + 1;
                                                        a_thanh_temp_B41.TONG2 = a_thanh_temp_B41.TONG2 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B41.SV3 = a_thanh_temp_B41.SV3 + 1;
                                                        a_thanh_temp_B41.TONG3 = a_thanh_temp_B41.TONG3 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_1", strs1[0], strs1[1])] = a_thanh_temp_B41;
                                            }
                                            a_thanh_data a_thanh_temp_B42 = new a_thanh_data();
                                            if (strs1[2].Equals("2") && dt1_4.TryGetValue(string.Format("{0}_{1}_2", strs1[0], strs1[1]), out a_thanh_temp_B42))
                                            {
                                                switch (strs1[3])
                                                {
                                                    case "1":
                                                        a_thanh_temp_B42.SV4 = a_thanh_temp_B42.SV4 + 1;
                                                        a_thanh_temp_B42.TONG4 = a_thanh_temp_B42.TONG4 + 1;
                                                        break;
                                                    case "2":
                                                        a_thanh_temp_B42.SV5 = a_thanh_temp_B42.SV5 + 1;
                                                        a_thanh_temp_B42.TONG5 = a_thanh_temp_B42.TONG5 + 1;
                                                        break;
                                                    case "3":
                                                        a_thanh_temp_B42.SV6 = a_thanh_temp_B42.SV6 + 1;
                                                        a_thanh_temp_B42.TONG6 = a_thanh_temp_B42.TONG6 + 1;
                                                        break;
                                                    default: break;
                                                }
                                                dt1_4[string.Format("{0}_{1}_2", strs1[0], strs1[1])] = a_thanh_temp_B42;
                                            }
                                        }
                                        else
                                        {
                                            if (strs1.Length.Equals(5))
                                            {
                                                // Xu ly bang 5
                                                a_thanh_data a_thanh_temp_B51 = new a_thanh_data();
                                                if (strs1[3].Equals("1") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B51))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B51.SV1 = a_thanh_temp_B51.SV1 + 1;
                                                            a_thanh_temp_B51.TONG1 = a_thanh_temp_B51.TONG1 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B51.SV2 = a_thanh_temp_B51.SV2 + 1;
                                                            a_thanh_temp_B51.TONG2 = a_thanh_temp_B51.TONG2 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B51.SV3 = a_thanh_temp_B51.SV3 + 1;
                                                            a_thanh_temp_B51.TONG3 = a_thanh_temp_B51.TONG3 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_1", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B51;
                                                }
                                                a_thanh_data a_thanh_temp_B52 = new a_thanh_data();
                                                if (strs1[3].Equals("2") && dt1_5.TryGetValue(string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2]), out a_thanh_temp_B52))
                                                {
                                                    switch (strs1[4])
                                                    {
                                                        case "1":
                                                            a_thanh_temp_B52.SV4 = a_thanh_temp_B52.SV4 + 1;
                                                            a_thanh_temp_B52.TONG4 = a_thanh_temp_B52.TONG4 + 1;
                                                            break;
                                                        case "2":
                                                            a_thanh_temp_B52.SV5 = a_thanh_temp_B52.SV5 + 1;
                                                            a_thanh_temp_B52.TONG5 = a_thanh_temp_B52.TONG5 + 1;
                                                            break;
                                                        case "3":
                                                            a_thanh_temp_B52.SV6 = a_thanh_temp_B52.SV6 + 1;
                                                            a_thanh_temp_B52.TONG6 = a_thanh_temp_B52.TONG6 + 1;
                                                            break;
                                                        default: break;
                                                    }
                                                    dt1_5[string.Format("{0}_{1}_{2}_2", strs1[0], strs1[1], strs1[2])] = a_thanh_temp_B52;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                                break;
                            default: break;
                        }
                        #endregion
                        break;
                    default: break;
                }
            }
            #endregion
            MessageBox.Show(iDemTest.ToString());
            #region Xu Ly Table
            #region Table1
            //  DataTable table1 = new DataTable();
            //  table1.Columns.Add("TT");
            //  table1.Columns.Add("NoiDung");
            //  table1.Columns.Add("CBQL1");
            //  table1.Columns.Add("CBQL2");
            //  table1.Columns.Add("CBQL3");
            //  table1.Columns.Add("CBQL4");
            //  table1.Columns.Add("CBQL5");
            //  table1.Columns.Add("CBQL6");
            //  table1.Columns.Add("CBQL7");

            //  table1.Columns.Add("GV1");
            //  table1.Columns.Add("GV2");
            //  table1.Columns.Add("GV3");
            //  table1.Columns.Add("GV4");
            //  table1.Columns.Add("GV5");
            //  table1.Columns.Add("GV6");
            //  table1.Columns.Add("GV7");

            //  table1.Columns.Add("NV1");
            //  table1.Columns.Add("NV2");
            //  table1.Columns.Add("NV3");
            //  table1.Columns.Add("NV4");
            //  table1.Columns.Add("NV5");
            //  table1.Columns.Add("NV6");
            //  table1.Columns.Add("NV7");

            //  table1.Columns.Add("TONG1");
            //  table1.Columns.Add("TONG2");
            //  table1.Columns.Add("TONG3");
            //  table1.Columns.Add("TONG4");
            //  table1.Columns.Add("TONG5");
            //  table1.Columns.Add("TONG6");
            //  table1.Columns.Add("TONG7");
            //  for (int i = 0; i < 161; i++)
            //  {
            //      DataRow dr = table1.NewRow();
            //      dr["TT"] = (i + 1).ToString();
            //      dr["NoiDung"] = string.Format("Câu {0}", i + 1);
            //      table1.Rows.Add(dr);
            //  }
            //  foreach (KeyValuePair<string, a_thanh_data> item in dt1)
            //  {
            //      int iIndexRow = item.Value.stt - 1;
            //      table1.Rows[iIndexRow]["CBQL1"] = item.Value.CBQL1;
            //      table1.Rows[iIndexRow]["CBQL2"] = item.Value.CBQL2;
            //      table1.Rows[iIndexRow]["CBQL3"] = item.Value.CBQL3;
            //      table1.Rows[iIndexRow]["CBQL4"] = item.Value.CBQL4;
            //      table1.Rows[iIndexRow]["CBQL5"] = item.Value.CBQL5;
            //      table1.Rows[iIndexRow]["CBQL6"] = item.Value.CBQL6;
            //      table1.Rows[iIndexRow]["CBQL7"] = item.Value.CBQL7;

            //      table1.Rows[iIndexRow]["GV1"] = item.Value.GV1;
            //      table1.Rows[iIndexRow]["GV2"] = item.Value.GV2;
            //      table1.Rows[iIndexRow]["GV3"] = item.Value.GV3;
            //      table1.Rows[iIndexRow]["GV4"] = item.Value.GV4;
            //      table1.Rows[iIndexRow]["GV5"] = item.Value.GV5;
            //      table1.Rows[iIndexRow]["GV6"] = item.Value.GV6;
            //      table1.Rows[iIndexRow]["GV7"] = item.Value.GV7;

            //      table1.Rows[iIndexRow]["NV1"] = item.Value.NV1;
            //      table1.Rows[iIndexRow]["NV2"] = item.Value.NV2;
            //      table1.Rows[iIndexRow]["NV3"] = item.Value.NV3;
            //      table1.Rows[iIndexRow]["NV4"] = item.Value.NV4;
            //      table1.Rows[iIndexRow]["NV5"] = item.Value.NV5;
            //      table1.Rows[iIndexRow]["NV6"] = item.Value.NV6;
            //      table1.Rows[iIndexRow]["NV7"] = item.Value.NV7;

            //      table1.Rows[iIndexRow]["TONG1"] = item.Value.TONG1;
            //      table1.Rows[iIndexRow]["TONG2"] = item.Value.TONG2;
            //      table1.Rows[iIndexRow]["TONG3"] = item.Value.TONG3;
            //      table1.Rows[iIndexRow]["TONG4"] = item.Value.TONG4;
            //      table1.Rows[iIndexRow]["TONG5"] = item.Value.TONG5;
            //      table1.Rows[iIndexRow]["TONG6"] = item.Value.TONG6;
            //      table1.Rows[iIndexRow]["TONG7"] = item.Value.TONG7;
            //  }
            //  // Xuat du lieu
            //  GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //  ExcelFile ef = new ExcelFile();

            //  ExcelWorksheet ws3 = ef.Worksheets.Add("1");
            //  ws3.InsertDataTable(table1,
            //new InsertDataTableOptions()
            //{
            //    ColumnHeaders = true,
            //    StartRow = 0
            //});
            //  ef.Save("xuat_du_lieu_a_thanh_1" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            //  MessageBox.Show("Thanh cong");
            #endregion
            #region Table2
            DataTable table2 = new DataTable();
            table2.Columns.Add("TT");
            table2.Columns.Add("NoiDung");
            table2.Columns.Add("SDLD1");
            table2.Columns.Add("SDLD2");
            table2.Columns.Add("SDLD3");
            table2.Columns.Add("SDLD4");
            table2.Columns.Add("SDLD5");
            table2.Columns.Add("SDLD6");
            table2.Columns.Add("SDLD7");

            for (int i = 0; i < 116; i++)
            {
                DataRow dr = table2.NewRow();
                dr["TT"] = (i + 1).ToString();
                dr["NoiDung"] = string.Format("Câu {0}", i + 1);
                table2.Rows.Add(dr);
            }
            foreach (KeyValuePair<string, a_thanh_data> item in dt2)
            {
                int iIndexRow = item.Value.stt - 1;
                table2.Rows[iIndexRow]["SDLD1"] = item.Value.SDLD1;
                table2.Rows[iIndexRow]["SDLD2"] = item.Value.SDLD2;
                table2.Rows[iIndexRow]["SDLD3"] = item.Value.SDLD3;
                table2.Rows[iIndexRow]["SDLD4"] = item.Value.SDLD4;
                table2.Rows[iIndexRow]["SDLD5"] = item.Value.SDLD5;
                table2.Rows[iIndexRow]["SDLD6"] = item.Value.SDLD6;
                table2.Rows[iIndexRow]["SDLD7"] = item.Value.SDLD7;

            }
            // Xuat du lieu
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();

            ExcelWorksheet ws3 = ef.Worksheets.Add("2");
            ws3.InsertDataTable(table2,
          new InsertDataTableOptions()
          {
              ColumnHeaders = true,
              StartRow = 0
          });
            ef.Save("xuat_du_lieu_a_thanh_1" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("Thanh cong");
            #endregion
            #region Table3
            /*
            DataTable Table3 = new DataTable();
            Table3.Columns.Add("TT");
            Table3.Columns.Add("NoiDung");
            Table3.Columns.Add("CUUSV1");
            Table3.Columns.Add("CUUSV2");
            Table3.Columns.Add("CUUSV3");
            Table3.Columns.Add("CUUSV4");
            Table3.Columns.Add("CUUSV5");
            Table3.Columns.Add("CUUSV6");
            Table3.Columns.Add("CUUSV7");

            Table3.Columns.Add("SV1");
            Table3.Columns.Add("SV2");
            Table3.Columns.Add("SV3");
            Table3.Columns.Add("SV4");
            Table3.Columns.Add("SV5");
            Table3.Columns.Add("SV6");
            Table3.Columns.Add("SV7");

           
            Table3.Columns.Add("TONG1");
            Table3.Columns.Add("TONG2");
            Table3.Columns.Add("TONG3");
            Table3.Columns.Add("TONG4");
            Table3.Columns.Add("TONG5");
            Table3.Columns.Add("TONG6");
            Table3.Columns.Add("TONG7");
            for (int i = 0; i < 161; i++)
            {
                DataRow dr = Table3.NewRow();
                dr["TT"] = (i + 1).ToString();
                dr["NoiDung"] = string.Format("Câu {0}", i + 1);
                Table3.Rows.Add(dr);
            }
            foreach (KeyValuePair<string, a_thanh_data> item in dt3)
            {
                int iIndexRow = item.Value.stt - 1;
                Table3.Rows[iIndexRow]["CUUSV1"] = item.Value.CUUSV1;
                Table3.Rows[iIndexRow]["CUUSV2"] = item.Value.CUUSV2;
                Table3.Rows[iIndexRow]["CUUSV3"] = item.Value.CUUSV3;
                Table3.Rows[iIndexRow]["CUUSV4"] = item.Value.CUUSV4;
                Table3.Rows[iIndexRow]["CUUSV5"] = item.Value.CUUSV5;
                Table3.Rows[iIndexRow]["CUUSV6"] = item.Value.CUUSV6;
                Table3.Rows[iIndexRow]["CUUSV7"] = item.Value.CUUSV7;

                Table3.Rows[iIndexRow]["SV1"] = item.Value.SV1;
                Table3.Rows[iIndexRow]["SV2"] = item.Value.SV2;
                Table3.Rows[iIndexRow]["SV3"] = item.Value.SV3;
                Table3.Rows[iIndexRow]["SV4"] = item.Value.SV4;
                Table3.Rows[iIndexRow]["SV5"] = item.Value.SV5;
                Table3.Rows[iIndexRow]["SV6"] = item.Value.SV6;
                Table3.Rows[iIndexRow]["SV7"] = item.Value.SV7;


                Table3.Rows[iIndexRow]["TONG1"] = item.Value.TONG1;
                Table3.Rows[iIndexRow]["TONG2"] = item.Value.TONG2;
                Table3.Rows[iIndexRow]["TONG3"] = item.Value.TONG3;
                Table3.Rows[iIndexRow]["TONG4"] = item.Value.TONG4;
                Table3.Rows[iIndexRow]["TONG5"] = item.Value.TONG5;
                Table3.Rows[iIndexRow]["TONG6"] = item.Value.TONG6;
                Table3.Rows[iIndexRow]["TONG7"] = item.Value.TONG7;
            }
            // Xuat du lieu
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();

            ExcelWorksheet ws3 = ef.Worksheets.Add("3");
            ws3.InsertDataTable(Table3,
          new InsertDataTableOptions()
          {
              ColumnHeaders = true,
              StartRow = 0
          });
            ef.Save("xuat_du_lieu_a_thanh_3" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("Thanh cong");
            */
            #endregion
            #region Table4
            /*
            DataTable Table4 = new DataTable();
            Table4.Columns.Add("TT");
            Table4.Columns.Add("NoiDung");
            Table4.Columns.Add("CBQL1");
            Table4.Columns.Add("CBQL2");
            Table4.Columns.Add("CBQL3");
            Table4.Columns.Add("CBQL4");
            Table4.Columns.Add("CBQL5");
            Table4.Columns.Add("CBQL6");

            Table4.Columns.Add("GV1");
            Table4.Columns.Add("GV2");
            Table4.Columns.Add("GV3");
            Table4.Columns.Add("GV4");
            Table4.Columns.Add("GV5");
            Table4.Columns.Add("GV6");

            Table4.Columns.Add("NV1");
            Table4.Columns.Add("NV2");
            Table4.Columns.Add("NV3");
            Table4.Columns.Add("NV4");
            Table4.Columns.Add("NV5");
            Table4.Columns.Add("NV6");

            Table4.Columns.Add("SDLD1");
            Table4.Columns.Add("SDLD2");
            Table4.Columns.Add("SDLD3");
            Table4.Columns.Add("SDLD4");
            Table4.Columns.Add("SDLD5");
            Table4.Columns.Add("SDLD6");

            Table4.Columns.Add("CUUSV1");
            Table4.Columns.Add("CUUSV2");
            Table4.Columns.Add("CUUSV3");
            Table4.Columns.Add("CUUSV4");
            Table4.Columns.Add("CUUSV5");
            Table4.Columns.Add("CUUSV6");

            Table4.Columns.Add("SV1");
            Table4.Columns.Add("SV2");
            Table4.Columns.Add("SV3");
            Table4.Columns.Add("SV4");
            Table4.Columns.Add("SV5");
            Table4.Columns.Add("SV6");

            Table4.Columns.Add("TONG1");
            Table4.Columns.Add("TONG2");
            Table4.Columns.Add("TONG3");
            Table4.Columns.Add("TONG4");
            Table4.Columns.Add("TONG5");
            Table4.Columns.Add("TONG6");

            for (int i = 0; i < 161; i++)
            {
                DataRow dr = Table4.NewRow();
                dr["TT"] = (i + 1).ToString();
                dr["NoiDung"] = string.Format("Câu {0}", i + 1);
                Table4.Rows.Add(dr);
            }
            foreach (KeyValuePair<string, a_thanh_data> item in dt1_4)
            {
                int iIndexRow = item.Value.stt - 1;
                if (item.Value.TONG1 + item.Value.TONG2 + item.Value.TONG3 > 0)
                {
                    Table4.Rows[iIndexRow]["CBQL1"] = item.Value.CBQL1;
                    Table4.Rows[iIndexRow]["CBQL2"] = item.Value.CBQL2;
                    Table4.Rows[iIndexRow]["CBQL3"] = item.Value.CBQL3;

                    Table4.Rows[iIndexRow]["GV1"] = item.Value.GV1;
                    Table4.Rows[iIndexRow]["GV2"] = item.Value.GV2;
                    Table4.Rows[iIndexRow]["GV3"] = item.Value.GV3;

                    Table4.Rows[iIndexRow]["NV1"] = item.Value.NV1;
                    Table4.Rows[iIndexRow]["NV2"] = item.Value.NV2;
                    Table4.Rows[iIndexRow]["NV3"] = item.Value.NV3;


                    Table4.Rows[iIndexRow]["SDLD1"] = item.Value.SDLD1;
                    Table4.Rows[iIndexRow]["SDLD2"] = item.Value.SDLD2;
                    Table4.Rows[iIndexRow]["SDLD3"] = item.Value.SDLD3;


                    Table4.Rows[iIndexRow]["CUUSV1"] = item.Value.CUUSV1;
                    Table4.Rows[iIndexRow]["CUUSV2"] = item.Value.CUUSV2;
                    Table4.Rows[iIndexRow]["CUUSV3"] = item.Value.CUUSV3;

                    Table4.Rows[iIndexRow]["SV1"] = item.Value.SV1;
                    Table4.Rows[iIndexRow]["SV2"] = item.Value.SV2;
                    Table4.Rows[iIndexRow]["SV3"] = item.Value.SV3;


                    Table4.Rows[iIndexRow]["TONG1"] = item.Value.TONG1;
                    Table4.Rows[iIndexRow]["TONG2"] = item.Value.TONG2;
                    Table4.Rows[iIndexRow]["TONG3"] = item.Value.TONG3;
                }
                else
                {
                    Table4.Rows[iIndexRow]["CBQL4"] = item.Value.CBQL4;
                    Table4.Rows[iIndexRow]["CBQL5"] = item.Value.CBQL5;
                    Table4.Rows[iIndexRow]["CBQL6"] = item.Value.CBQL6;

                    Table4.Rows[iIndexRow]["GV4"] = item.Value.GV4;
                    Table4.Rows[iIndexRow]["GV5"] = item.Value.GV5;
                    Table4.Rows[iIndexRow]["GV6"] = item.Value.GV6;

                    Table4.Rows[iIndexRow]["NV4"] = item.Value.NV4;
                    Table4.Rows[iIndexRow]["NV5"] = item.Value.NV5;
                    Table4.Rows[iIndexRow]["NV6"] = item.Value.NV6;

                    Table4.Rows[iIndexRow]["SDLD4"] = item.Value.SDLD4;
                    Table4.Rows[iIndexRow]["SDLD5"] = item.Value.SDLD5;
                    Table4.Rows[iIndexRow]["SDLD6"] = item.Value.SDLD6;

                    Table4.Rows[iIndexRow]["CUUSV4"] = item.Value.CUUSV4;
                    Table4.Rows[iIndexRow]["CUUSV5"] = item.Value.CUUSV5;
                    Table4.Rows[iIndexRow]["CUUSV6"] = item.Value.CUUSV6;

                    Table4.Rows[iIndexRow]["SV4"] = item.Value.SV4;
                    Table4.Rows[iIndexRow]["SV5"] = item.Value.SV5;
                    Table4.Rows[iIndexRow]["SV6"] = item.Value.SV6;


                    Table4.Rows[iIndexRow]["TONG4"] = item.Value.TONG4;
                    Table4.Rows[iIndexRow]["TONG5"] = item.Value.TONG5;
                    Table4.Rows[iIndexRow]["TONG6"] = item.Value.TONG6;
                }
            }
            // Xuat du lieu
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();

            ExcelWorksheet ws3 = ef.Worksheets.Add("4");
            ws3.InsertDataTable(Table4,
          new InsertDataTableOptions()
          {
              ColumnHeaders = true,
              StartRow = 0
          });
            ef.Save("xuat_du_lieu_a_thanh_t4" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("Thanh cong");
            */
            #endregion
            #region Table5
            /*
            DataTable Table5 = new DataTable();
            Table5.Columns.Add("TT");
            Table5.Columns.Add("NoiDung");
            Table5.Columns.Add("CBQL1");
            Table5.Columns.Add("CBQL2");
            Table5.Columns.Add("CBQL3");
            Table5.Columns.Add("CBQL4");
            Table5.Columns.Add("CBQL5");
            Table5.Columns.Add("CBQL6");

            Table5.Columns.Add("GV1");
            Table5.Columns.Add("GV2");
            Table5.Columns.Add("GV3");
            Table5.Columns.Add("GV4");
            Table5.Columns.Add("GV5");
            Table5.Columns.Add("GV6");

            Table5.Columns.Add("NV1");
            Table5.Columns.Add("NV2");
            Table5.Columns.Add("NV3");
            Table5.Columns.Add("NV4");
            Table5.Columns.Add("NV5");
            Table5.Columns.Add("NV6");

            Table5.Columns.Add("SDLD1");
            Table5.Columns.Add("SDLD2");
            Table5.Columns.Add("SDLD3");
            Table5.Columns.Add("SDLD4");
            Table5.Columns.Add("SDLD5");
            Table5.Columns.Add("SDLD6");

            Table5.Columns.Add("CUUSV1");
            Table5.Columns.Add("CUUSV2");
            Table5.Columns.Add("CUUSV3");
            Table5.Columns.Add("CUUSV4");
            Table5.Columns.Add("CUUSV5");
            Table5.Columns.Add("CUUSV6");

            Table5.Columns.Add("SV1");
            Table5.Columns.Add("SV2");
            Table5.Columns.Add("SV3");
            Table5.Columns.Add("SV4");
            Table5.Columns.Add("SV5");
            Table5.Columns.Add("SV6");

            Table5.Columns.Add("TONG1");
            Table5.Columns.Add("TONG2");
            Table5.Columns.Add("TONG3");
            Table5.Columns.Add("TONG4");
            Table5.Columns.Add("TONG5");
            Table5.Columns.Add("TONG6");

            for (int i = 0; i < 50; i++)
            {
                DataRow dr = Table5.NewRow();
                dr["TT"] = (i + 1).ToString();
                dr["NoiDung"] = string.Format("Câu {0}", i + 1);
                Table5.Rows.Add(dr);
            }
            foreach (KeyValuePair<string, a_thanh_data> item in dt1_5)
            {
                int iIndexRow = item.Value.stt - 1;
                if (item.Value.TONG1 + item.Value.TONG2 + item.Value.TONG3 > 0)
                {
                    Table5.Rows[iIndexRow]["CBQL1"] = item.Value.CBQL1;
                    Table5.Rows[iIndexRow]["CBQL2"] = item.Value.CBQL2;
                    Table5.Rows[iIndexRow]["CBQL3"] = item.Value.CBQL3;

                    Table5.Rows[iIndexRow]["GV1"] = item.Value.GV1;
                    Table5.Rows[iIndexRow]["GV2"] = item.Value.GV2;
                    Table5.Rows[iIndexRow]["GV3"] = item.Value.GV3;

                    Table5.Rows[iIndexRow]["NV1"] = item.Value.NV1;
                    Table5.Rows[iIndexRow]["NV2"] = item.Value.NV2;
                    Table5.Rows[iIndexRow]["NV3"] = item.Value.NV3;


                    Table5.Rows[iIndexRow]["SDLD1"] = item.Value.SDLD1;
                    Table5.Rows[iIndexRow]["SDLD2"] = item.Value.SDLD2;
                    Table5.Rows[iIndexRow]["SDLD3"] = item.Value.SDLD3;


                    Table5.Rows[iIndexRow]["CUUSV1"] = item.Value.CUUSV1;
                    Table5.Rows[iIndexRow]["CUUSV2"] = item.Value.CUUSV2;
                    Table5.Rows[iIndexRow]["CUUSV3"] = item.Value.CUUSV3;

                    Table5.Rows[iIndexRow]["SV1"] = item.Value.SV1;
                    Table5.Rows[iIndexRow]["SV2"] = item.Value.SV2;
                    Table5.Rows[iIndexRow]["SV3"] = item.Value.SV3;


                    Table5.Rows[iIndexRow]["TONG1"] = item.Value.TONG1;
                    Table5.Rows[iIndexRow]["TONG2"] = item.Value.TONG2;
                    Table5.Rows[iIndexRow]["TONG3"] = item.Value.TONG3;
                }
                else
                {
                    Table5.Rows[iIndexRow]["CBQL4"] = item.Value.CBQL4;
                    Table5.Rows[iIndexRow]["CBQL5"] = item.Value.CBQL5;
                    Table5.Rows[iIndexRow]["CBQL6"] = item.Value.CBQL6;

                    Table5.Rows[iIndexRow]["GV4"] = item.Value.GV4;
                    Table5.Rows[iIndexRow]["GV5"] = item.Value.GV5;
                    Table5.Rows[iIndexRow]["GV6"] = item.Value.GV6;

                    Table5.Rows[iIndexRow]["NV4"] = item.Value.NV4;
                    Table5.Rows[iIndexRow]["NV5"] = item.Value.NV5;
                    Table5.Rows[iIndexRow]["NV6"] = item.Value.NV6;

                    Table5.Rows[iIndexRow]["SDLD4"] = item.Value.SDLD4;
                    Table5.Rows[iIndexRow]["SDLD5"] = item.Value.SDLD5;
                    Table5.Rows[iIndexRow]["SDLD6"] = item.Value.SDLD6;

                    Table5.Rows[iIndexRow]["CUUSV4"] = item.Value.CUUSV4;
                    Table5.Rows[iIndexRow]["CUUSV5"] = item.Value.CUUSV5;
                    Table5.Rows[iIndexRow]["CUUSV6"] = item.Value.CUUSV6;

                    Table5.Rows[iIndexRow]["SV4"] = item.Value.SV4;
                    Table5.Rows[iIndexRow]["SV5"] = item.Value.SV5;
                    Table5.Rows[iIndexRow]["SV6"] = item.Value.SV6;


                    Table5.Rows[iIndexRow]["TONG4"] = item.Value.TONG4;
                    Table5.Rows[iIndexRow]["TONG5"] = item.Value.TONG5;
                    Table5.Rows[iIndexRow]["TONG6"] = item.Value.TONG6;
                }
            }
            // Xuat du lieu
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();

            ExcelWorksheet ws3 = ef.Worksheets.Add("5");
            ws3.InsertDataTable(Table5,
          new InsertDataTableOptions()
          {
              ColumnHeaders = true,
              StartRow = 0
          });
            ef.Save("xuat_du_lieu_a_thanh_t5" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("Thanh cong");
            */
            #endregion
            #endregion
        }
        #region add Function xu ly Xua du lieu danh gia giang vien
        private int DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(DataTable dt, string classroom, string answerId)
        {
            int iReturn = 0;
            DataRow[] drs = dt.Select(string.Format("ClassRoomId={0} and AnswerId={1}", classroom, answerId));
            if (drs != null && drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    iReturn += int.Parse(drs[i]["Total"].ToString());
                }
            }
            return iReturn;
        }
        private string DGGV_XuatDuLieu_GetValueByClassRoomAndQuestion(DataTable dt, string classroom, string questionId)
        {
            string strReturn = "";
            DataRow[] drs = dt.Select(string.Format("ClassRoomId={0} and QuestionId={1}", classroom, questionId));
            if (drs != null && drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    strReturn += drs[i]["Value"].ToString() + "; ";
                }
            }
            return strReturn;
        }
        #endregion
        private void btnDGGV_XuatDuLieu_MonLyThuyet_Click(object sender, EventArgs e)
        {
            int iMauDe = 1021;
            #region Chuan bi du lieu
            string sql = "spSurvey_statistic_getCommon";
            DataSet dsCommon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.StoredProcedure, sql);
            sql = @"SELECT [ID],[BaiKhaoSatID],[SinhVienID],[DeThiID],[LecturerCode],[LecturerName],[ClassRoomCode]
      ,[SubjectCode],[SubjectName],[SubjectType],[DepartmentCode],[Type],[Status]
        FROM [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID=" + iMauDe.ToString();
            //DataTable dtBaiKhaoSat_SinhVien = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            sql = @"SELECT [SemesterId]
      ,[CampaignId]
      ,[CampaignTemplateId]
      ,[ClassRoomId]
      ,[LecturerId]
      ,[QuestionType]
      ,[QuestionId]
      ,[QuestionIndex]
      ,[AnswerId]
      ,[Total]
      ,[Value]
  FROM [dbo].[AS_Edu_Survey_ReportTotal] where [CampaignTemplateId]=" + iMauDe.ToString();
            DataTable dtReportTotal = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            //MessageBox.Show(dtReportTotal.Rows.Count.ToString());
            #endregion
            DataTable dt999 = new DataTable();
            #region Xu ly cac cot.
            dt999.Columns.Add("Khoa");
            dt999.Columns.Add("BoMon");
            dt999.Columns.Add("so_sinh_vien_tham_gia_khao_sat");
            dt999.Columns.Add("so_sinh_vien_duoc_khao_sat");
            dt999.Columns.Add("so_phieu_thu_ve");
            dt999.Columns.Add("so_phieu_phat_ra");
            dt999.Columns.Add("so_giang_vien_da_duoc_khao_sat");
            dt999.Columns.Add("so_giang_vien_can_lay_y_kien_khao_sat");
            int iSoCauHoi = 32;
            for (int i = 1; i <= iSoCauHoi; i++)
            {
                dt999.Columns.Add("cau_" + i.ToString() + "_1");
                dt999.Columns.Add("cau_" + i.ToString() + "_2");
                dt999.Columns.Add("cau_" + i.ToString() + "_3");
              
                if (!i.Equals(29))
                {
                    dt999.Columns.Add("cau_" + i.ToString() + "_4");
               
                    if (!i.Equals(6))
                    {
                        dt999.Columns.Add("cau_" + i.ToString() + "_5");
                        dt999.Columns.Add("cau_" + i.ToString() + "_dtb");
                    }
                    else
                    {
                        dt999.Columns.Add("cau_" + i.ToString() + "_ykk");
                    }
                }
            }
            #endregion

            DataTable dtKhoa = dsCommon.Tables[0];
            DataTable dtBoMon = dsCommon.Tables[1];
            for (int i = 0; i < dsCommon.Tables[0].Rows.Count; i++)
            {

                int iKhoaID = int.Parse(dsCommon.Tables[0].Rows[i]["ID"].ToString());
                string strKhoaCode = dsCommon.Tables[0].Rows[i]["Code"].ToString();
                string strKhoaName = dsCommon.Tables[0].Rows[i]["Name"].ToString();
                // Lay danh sach bo mon tu khoa
                DataRow[] drBoMons = dtBoMon.Select(string.Format("FacultyCode='{0}'", strKhoaCode));
                if (drBoMons != null && drBoMons.Length > 0)
                {
                    for (int j = 0; j < drBoMons.Length; j++)
                    {
                        string strBoMonCode = drBoMons[j]["Code"].ToString();
                        string strBoMonName = drBoMons[j]["Name"].ToString();
                        DataRow dr1 = dt999.NewRow();
                        dr1[0] = strKhoaName == "" ? strKhoaCode : strKhoaName;
                        dr1[1] = strBoMonName;
                        string strTongQuanTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>''  and status=4;
		select distinct(b.ID) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] a inner join [dbo].[AS_Academy_ClassRoom] b
		on a.ClassRoomCode=b.Code where DeThiID={1} and [DepartmentCode]='{0}';
", strBoMonCode, iMauDe);
                        DataSet dsTongQuanTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTemp);
                        dr1[2] = dsTongQuanTemp.Tables[0].Rows[0][0].ToString();
                        dr1[3] = dsTongQuanTemp.Tables[1].Rows[0][0].ToString();
                        dr1[4] = dsTongQuanTemp.Tables[2].Rows[0][0].ToString();
                        dr1[5] = dsTongQuanTemp.Tables[3].Rows[0][0].ToString();
                        dr1[6] = dsTongQuanTemp.Tables[4].Rows[0][0].ToString();
                        dr1[7] = dsTongQuanTemp.Tables[5].Rows[0][0].ToString();
                        // Lay du lieu cac cot tiep theo
                        #region lay du lieu chinh cua bang
                        int iC11 = 0;
                        int iC12 = 0;
                        int iC13 = 0;
                        int iC14 = 0;
                        int iC15 = 0;
                        string strC15 = "";
                        float iC1tb = 0;
                        #region 1.Nội dung giảng dạy, mục tiêu của học phần, vị trí học phần trong chương trình đào tạo, đề cương chi tiết của học phần được giảng viên giới thiệu đầy đủ rõ ràng khi bắt đầu học phần.
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5075");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5076");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5077");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5078");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5079");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        int iColumnValue = 8;
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 2. Các quy định và kế hoạch kiểm tra, thực hiện đánh giá điểm quá trình được giảng viên phổ biến rõ ràng, đầy đủ khi bắt đầu học phần.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5080");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5081");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5082");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5083");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5084");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 3. Giáo trình chính thức và tài liệu tham khảo được giảng viên giời thiệu chi tiết, đầy đủ; giảng viên hỗ trợ sinh viên trong việc tìm tài liệu học tập một cách hiệu quả.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5085");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5086");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5087");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5088");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5089");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 4. Việc bổ sung các buổi ôn tập trước khi thi dành cho các học phần học online đem lại hiệu quả thiết thực. 
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6000");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6001");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6002");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6003");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6004");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 5. Giảng viên giới thiệu đầy đủ về bản thân (Họ và tên, học vị, phương thức liên lạc với giảng viên khi cần tư vấn học tập)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5202");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5203");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5204");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5205");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5206");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 6. Các hình thức giảng dạy mà giảng viên đang sử dụng là (có thể chọn nhiều phương án)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        strC15 = "";
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5090");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5091");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5092");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5093");
                            strC15 = strC15 + ";" + DGGV_XuatDuLieu_GetValueByClassRoomAndQuestion(dtReportTotal, strClassRoom, "3328").Trim();
                            //iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5094");
                        }
                        //iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        strC15 = strC15.Replace("   ", " ");
                        strC15 = strC15.Replace("  ", " ");
                        strC15 = strC15.Replace(";;", "");
                        strC15 = strC15.Replace("; ;", "");
                        dr1[iColumnValue++] = strC15;
                        //dr1[iColumnValue++] = "";
                        #endregion
                        #region 7.Hệ thống học tập trực tuyến CMS thực sự đã đem lại hiệu quả trong quá trình học online.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6005");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6006");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6007");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6008");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6009");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 8. Phần mềm học trực tuyến Zoom thuận tiện, dễ sử dụng, đem lại hiệu quả trong quá trình học online.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6010");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6011");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6012");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6013");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6014");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 9. Phương thức học trực tuyến đem lại hiệu quả cho sinh viên.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6015");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6016");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6017");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6018");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6019");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 10.Theo xu thế hiện nay, blended learning (học truyền thống + online) đang trở thành xu thế học tập mới của thế giời. Theo bạn, tỷ lệ học % là hợp lý?.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6020");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6021");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6022");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6023");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6024");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 11. Các hình thức giảng dạy mà giảng viên đã sử dụng như trên (Phấn bảng, máy chiếu,...) giúp sinh viên tiếp thu tốt bài giảng
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5094");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5095");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5096");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5097");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5098");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 12. Giảng viên truyền đạt rõ ràng, dễ hiểu, sinh động
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5099");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5100");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5101");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5102");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5103");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 13.Trong quá trình giảng dạy, giảng viên sẵn sàng ôn lại kiến thức, thường xuyên trao đổi, thảo luận và giải đáp thắc mắc cho sinh viên.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5104");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5105");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5106");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5107");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5108");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 14.Giảng viên có các hình thức khuyến khích sinh viên chủ động học tập (tích cực xây dựng bài trên lớp, chuẩn bị bài ở nhà, xung phong làm bài tập...)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5109");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5110");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5111");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5112");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5113");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 15.Những nội dung trọng tâm được giảng viên dành thời lượng phù hợp để giảng dạy.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5114");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5115");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5116");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5117");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5118");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 16.Giảng viên sẵn sàng giải đáp thắc mắc của sinh viên về nội dung học phần ngoài giờ học.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5119");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5120");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5121");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5122");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5123");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 17.Những phương pháp học được giảng viên hướng dẫn thực sự mang lại hiệu quả.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5124");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5125");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5126");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5127");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5128");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 18.Giảng viên tạo hứng thú học tập cho sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5129");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5130");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5131");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5132");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5133");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 19. Nội dung học phần đã được giảng dạy và hướng dẫn đầy đủ.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5134");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5135");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5136");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5137");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5138");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 20.Giảng viên thường xuyên minh họa nội dung bài giảng bằng các ví dụ thực tế và cập nhật các kiến thức, thông tin mới.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5139");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5140");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5141");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5142");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5143");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 21.Giảng viên thường xuyên liên hệ nội dung của các bài giảng với các học phần khác, giúp sinh viên tiếp thu bài giảng hiệu quả
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5144");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5145");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5146");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5147");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5148");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 22.Thời lượng hướng dẫn bài tập, bài tập lớn, tiểu luận đủ so với đề cương chi tiết học phần
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5149");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5150");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5151");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5152");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5153");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 23.Thời điểm giao bài tập, bài tập lớn, tiểu luận phù hợp để sinh viên hoàn thành nhiệm vụ
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5154");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5155");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5156");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5157");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5158");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 24.Giảng viên luôn vào lớp, nghỉ giải lao, kết thúc giờ học đúng giờ
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5159");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5160");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5161");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5162");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5163");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 25.Giảng viên có thái độ thân thiện, tôn trọng sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5164");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5165");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5166");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5167");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5168");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 26.Giảng viên có các hình thức quản lý lớp hiệu quả, tạo nên không khí học tập nghiêm túc.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5169");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5170");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5171");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5172");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5173");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 27.Giảng viên nhờ giảng viên khác dạy thay
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5178");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5177");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5176");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5175");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5174");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 28. Giảng viên dạy đủ số buổi theo thời khóa biểu
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5183");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5182");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5181");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5180");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5179");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 29 Điểm quá trình được công bố trước khi hết thúc học phần
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5184");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5185");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5186");
                            //iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5180");
                            //iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5179");
                        }
                        //iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        //dr1[iColumnValue++] = "";
                        // dr1[iColumnValue++] = "";
                        //  dr1[iColumnValue++] = "";
                        #endregion
                        #region 30 Kết quả đánh giá điểm quá trình rõ ràng, chính xác, công bằng.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5187");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5188");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5189");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5190");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5191");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 31 Điểm thi kết thúc học phần được đánh giá chính xác, công bằng
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5192");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5193");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5194");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5195");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5196");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region 32 Nội dung đề thi phù hợp với nội dung đã được giảng dạy, ôn tập
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5197");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5198");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5198");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5200");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5201");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #endregion
                        dt999.Rows.Add(dr1);
                    }
                    #region Khoa
                    string strTongQuanKhoaTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and LecturerCode<>'' and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and LecturerCode<>''  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
", strKhoaCode, iMauDe);
                    DataSet dsTongQuanKhoaTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanKhoaTemp);
                    DataRow dr2 = dt999.NewRow();
                    dr2[0] = string.Format("{0} ({1})", strKhoaName, strKhoaCode);
                    dr2[1] = "";
                    dr2[2] = dsTongQuanKhoaTemp.Tables[0].Rows[0][0].ToString();
                    dr2[3] = dsTongQuanKhoaTemp.Tables[1].Rows[0][0].ToString();
                    dr2[4] = dsTongQuanKhoaTemp.Tables[2].Rows[0][0].ToString();
                    dr2[5] = dsTongQuanKhoaTemp.Tables[3].Rows[0][0].ToString();
                    dr2[6] = dsTongQuanKhoaTemp.Tables[4].Rows[0][0].ToString();
                    dr2[7] = dsTongQuanKhoaTemp.Tables[5].Rows[0][0].ToString();
                    dt999.Rows.Add(dr2);
                    #endregion
                }

            }
            #region Truong
            string strTongQuanTruongTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0};
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} ;
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and LecturerCode<>''  and status=4;
", iMauDe);
            DataSet dsTongQuanTruongTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTruongTemp);
            DataRow dr3 = dt999.NewRow();
            dr3[0] = string.Format("{0}", "Toàn trường");
            dr3[1] = "";
            dr3[2] = dsTongQuanTruongTemp.Tables[0].Rows[0][0].ToString();
            dr3[3] = dsTongQuanTruongTemp.Tables[1].Rows[0][0].ToString();
            dr3[4] = dsTongQuanTruongTemp.Tables[2].Rows[0][0].ToString();
            dr3[5] = dsTongQuanTruongTemp.Tables[3].Rows[0][0].ToString();
            dr3[6] = dsTongQuanTruongTemp.Tables[4].Rows[0][0].ToString();
            dr3[7] = dsTongQuanTruongTemp.Tables[5].Rows[0][0].ToString();
            dt999.Rows.Add(dr3);
            #endregion
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dt999,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("ly_thuyet" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("xuat du lieu thanh cong");
        }

        private void btnDGGV_XuatDuLieu_MonLyThuyetThucHanh_Click(object sender, EventArgs e)
        {
            int iMauDe = 1022;
            #region Chuan bi du lieu
            string sql = "spSurvey_statistic_getCommon";
            DataSet dsCommon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.StoredProcedure, sql);
            sql = @"SELECT [ID],[BaiKhaoSatID],[SinhVienID],[DeThiID],[LecturerCode],[LecturerName],[ClassRoomCode]
      ,[SubjectCode],[SubjectName],[SubjectType],[DepartmentCode],[Type],[Status]
        FROM [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID=" + iMauDe.ToString();
            //DataTable dtBaiKhaoSat_SinhVien = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            sql = @"SELECT [SemesterId]
      ,[CampaignId]
      ,[CampaignTemplateId]
      ,[ClassRoomId]
      ,[LecturerId]
      ,[QuestionType]
      ,[QuestionId]
      ,[QuestionIndex]
      ,[AnswerId]
      ,[Total]
      ,[Value]
  FROM [dbo].[AS_Edu_Survey_ReportTotal] where [CampaignTemplateId]=" + iMauDe.ToString();
            DataTable dtReportTotal = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            //MessageBox.Show(dtReportTotal.Rows.Count.ToString());
            #endregion
            DataTable dt999 = new DataTable();
            #region Xu ly cac cot.
            dt999.Columns.Add("Khoa");
            dt999.Columns.Add("BoMon");
            dt999.Columns.Add("so_sinh_vien_tham_gia_khao_sat");
            dt999.Columns.Add("so_sinh_vien_duoc_khao_sat");
            dt999.Columns.Add("so_phieu_thu_ve");
            dt999.Columns.Add("so_phieu_phat_ra");
            dt999.Columns.Add("so_giang_vien_da_duoc_khao_sat");
            dt999.Columns.Add("so_giang_vien_can_lay_y_kien_khao_sat");
            int iSoCauHoi = 39;
            for (int i = 1; i <= iSoCauHoi; i++)
            {
                dt999.Columns.Add("cau_" + i.ToString() + "_1");
                dt999.Columns.Add("cau_" + i.ToString() + "_2");
                dt999.Columns.Add("cau_" + i.ToString() + "_3");
                if (!i.Equals(36))
                {
                    dt999.Columns.Add("cau_" + i.ToString() + "_4");
                    dt999.Columns.Add("cau_" + i.ToString() + "_5");
                    if (!i.Equals(6))
                        dt999.Columns.Add("cau_" + i.ToString() + "_dtb");
                }
            }
            #endregion

            DataTable dtKhoa = dsCommon.Tables[0];
            DataTable dtBoMon = dsCommon.Tables[1];
            for (int i = 0; i < dsCommon.Tables[0].Rows.Count; i++)
            {

                int iKhoaID = int.Parse(dsCommon.Tables[0].Rows[i]["ID"].ToString());
                string strKhoaCode = dsCommon.Tables[0].Rows[i]["Code"].ToString();
                string strKhoaName = dsCommon.Tables[0].Rows[i]["Name"].ToString();
                // Lay danh sach bo mon tu khoa
                DataRow[] drBoMons = dtBoMon.Select(string.Format("FacultyCode='{0}'", strKhoaCode));
                if (drBoMons != null && drBoMons.Length > 0)
                {
                    for (int j = 0; j < drBoMons.Length; j++)
                    {
                        string strBoMonCode = drBoMons[j]["Code"].ToString();
                        string strBoMonName = drBoMons[j]["Name"].ToString();
                        DataRow dr1 = dt999.NewRow();
                        dr1[0] = strKhoaName == "" ? strKhoaCode : strKhoaName;
                        dr1[1] = strBoMonName;
                        string strTongQuanTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>''  and status=4;
		select distinct(b.ID) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] a inner join [dbo].[AS_Academy_ClassRoom] b
		on a.ClassRoomCode=b.Code where DeThiID={1} and [DepartmentCode]='{0}';
", strBoMonCode, iMauDe);
                        DataSet dsTongQuanTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTemp);
                        dr1[2] = dsTongQuanTemp.Tables[0].Rows[0][0].ToString();
                        dr1[3] = dsTongQuanTemp.Tables[1].Rows[0][0].ToString();
                        dr1[4] = dsTongQuanTemp.Tables[2].Rows[0][0].ToString();
                        dr1[5] = dsTongQuanTemp.Tables[3].Rows[0][0].ToString();
                        dr1[6] = dsTongQuanTemp.Tables[4].Rows[0][0].ToString();
                        dr1[7] = dsTongQuanTemp.Tables[5].Rows[0][0].ToString();
                        // Lay du lieu cac cot tiep theo
                        #region lay du lieu chinh cua bang
                        int iC11 = 0;
                        int iC12 = 0;
                        int iC13 = 0;
                        int iC14 = 0;
                        int iC15 = 0;
                        string strC15 = "";
                        float iC1tb = 0;
                        #region cau 1 Nội dung giảng dạy, mục tiêu của học phần, vị trí học phần trong chương trình đào tạo, đề cương chi tiết của học phần được giảng viên giới thiệu đầy đủ rõ ràng khi bắt đầu học phần.
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5075");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5076");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5077");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5078");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5079");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        int iColumnValue = 8;
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 2 Các quy định và kế hoạch kiểm tra, thực hiện đánh giá điểm quá trình được giảng viên phổ biến rõ ràng, đầy đủ khi bắt đầu học phần.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5080");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5081");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5082");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5083");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5084");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 3 Giáo trình chính thức và tài liệu tham khảo được giảng viên giời thiệu chi tiết, đầy đủ; giảng viên hỗ trợ sinh viên trong việc tìm tài liệu học tập một cách hiệu quả.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5085");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5086");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5087");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5088");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5089");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        //	Việc bổ sung các buổi ôn tập trước khi thi dành cho các học phần học online đem lại hiệu quả thiết thực.
                        #region cau 4 Việc bổ sung các buổi ôn tập trước khi thi dành cho các học phần học online đem lại hiệu quả thiết thực.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6000");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6001");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6002");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6003");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6004");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 5 Giảng viên giới thiệu đầy đủ về bản thân (Họ và tên, học vị, phương thức liên lạc với giảng viên khi cần tư vấn học tập)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5202");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5203");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5204");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5205");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5206");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 6 Các hình thức giảng dạy mà giảng viên đang sử dụng là (có thể chọn nhiều phương án)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        strC15 = "";
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5090");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5091");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5092");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5093");
                            strC15 = strC15 + ";" + DGGV_XuatDuLieu_GetValueByClassRoomAndQuestion(dtReportTotal, strClassRoom, "3328");
                            //iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5094");
                        }
                        //iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        strC15 = strC15.Replace("   ", " ");
                        strC15 = strC15.Replace("  ", " ");
                        strC15 = strC15.Replace(";;", "");
                        strC15 = strC15.Replace("; ;", "");
                        dr1[iColumnValue++] = strC15;
                        //dr1[iColumnValue++] = "";
                        #endregion
                        #region cau 7 Hệ thống học tập trực tuyến CMS thực sự đã đem lại hiệu quả trong quá trình học online.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6005");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6006");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6007");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6008");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6009");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 8 Phần mềm học trực tuyến Zoom thuận tiện, dễ sử dụng, đem lại hiệu quả trong quá trình học online.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6010");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6011");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6012");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6013");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6014");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 9  Phương thức học trực tuyến đem lại hiệu quả cho sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6015");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6016");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6017");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6018");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6019");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 10 Theo xu thế hiện nay, blended learning (học truyền thống + online) đang trở thành xu thế học tập mới của thế giời.Theo bạn, tỷ lệ học % là hợp lý?
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6020");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6021");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6022");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6023");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6024");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 11 Các hình thức giảng dạy mà giảng viên đã sử dụng như trên (Phấn bảng, máy chiếu,...) giúp sinh viên tiếp thu tốt bài giảng
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5094");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5095");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5096");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5097");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5098");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 12 Giảng viên truyền đạt rõ ràng, dễ hiểu, sinh động
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5099");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5100");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5101");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5102");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5103");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 13 Trong quá trình giảng dạy, giảng viên sẵn sàng ôn lại kiến thức, thường xuyên trao đổi, thảo luận và giải đáp thắc mắc cho sinh viên.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5104");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5105");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5106");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5107");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5108");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 14 Giảng viên có các hình thức khuyến khích sinh viên chủ động học tập (tích cực xây dựng bài trên lớp, chuẩn bị bài ở nhà, xung phong làm bài tập...)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5109");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5110");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5111");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5112");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5113");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 15 Những nội dung trọng tâm được giảng viên dành thời lượng phù hợp để giảng dạy.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5114");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5115");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5116");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5117");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5118");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 16 	Giảng viên sẵn sàng giải đáp thắc mắc của sinh viên về nội dung học phần ngoài giờ học.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5119");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5120");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5121");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5122");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5123");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 17 Những phương pháp học được giảng viên hướng dẫn thực sự mang lại hiệu quả.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5124");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5125");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5126");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5127");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5128");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 18 Giảng viên tạo hứng thú học tập cho sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5129");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5130");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5131");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5132");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5133");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 19 Nội dung học phần đã được giảng dạy và hướng dẫn đầy đủ.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5134");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5135");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5136");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5137");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5138");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 20 Giảng viên thường xuyên minh họa nội dung bài giảng bằng các ví dụ thực tế và cập nhật các kiến thức, thông tin mới.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5139");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5140");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5141");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5142");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5143");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 21 Giảng viên thường xuyên liên hệ nội dung của các bài giảng với các học phần khác, giúp sinh viên tiếp thu bài giảng hiệu quả
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5144");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5145");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5146");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5147");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5148");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 22 Thời lượng hướng dẫn bài tập, bài tập lớn, tiểu luận đủ so với đề cương chi tiết học phần
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5149");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5150");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5151");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5152");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5153");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 23 Thời điểm giao bài tập, bài tập lớn, tiểu luận phù hợp để sinh viên hoàn thành nhiệm vụ
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5154");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5155");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5156");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5157");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5158");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 24 Giảng viên luôn vào lớp, nghỉ giải lao, kết thúc giờ học đúng giờ
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5159");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5160");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5161");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5162");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5163");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 25 	Giảng viên có thái độ thân thiện, tôn trọng sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5164");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5165");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5166");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5167");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5168");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 26 Giảng viên có các hình thức quản lý lớp hiệu quả, tạo nên không khí học tập nghiêm túc.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5169");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5170");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5171");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5172");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5173");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 27 Giảng viên nhờ giảng viên khác dạy thay
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5178");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5177");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5176");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5175");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5174");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 28 Giảng viên dạy đủ số buổi theo thời khóa biểu
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5183");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5182");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5181");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5180");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5179");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 29 Hệ thống học tập trực tuyến CMS thực sự đã đem lại hiệu quả trong quá trình học online.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6005");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6006");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6007");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6008");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6009");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 30 	Lịch thực hiện các bài thí nghiệm được bố trí hợp lý
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5207");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5208");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5209");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5210");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5211");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 31 Cán bộ hướng dẫn phổ biến nội quy phòng thực hành/thí nghiệm, quy định về an toàn lao động.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5212");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5213");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5214");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5215");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5216");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 32 Cán bộ hướng dẫn chuẩn bị kỹ lưỡng cho các buổi thực hành/thí nghiệm (dụng cụ, thiết bị, tài liệu hướng dẫn…)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5217");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5218");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5219");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5220");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5221");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 33 Cán bộ hướng dẫn giới thiệu rõ ràng, đầy đủ về nội dung bài thực hành/thí nghiệm (nội dung, yêu cầu, quy trình), thao tác mẫu
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5222");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5223");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5224");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5225");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5226");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 34 Cán bộ hướng dẫn có thái độ cư xử đúng mực, tôn trọng và sẵn sàng hỗ trợ sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5227");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5228");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5229");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5230");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5231");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 35 Số lượng sinh viên trong một nhóm phù hợp để từng sinh viên có thể nắm vững nội dung và thực hiện được bài thực hành/thí nghiệm
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5232");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5233");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5234");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5235");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5236");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 36 	Điểm quá trình được công bố trước khi hết thúc học phần
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5184");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5185");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5186");
                            //iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5180");
                            //iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5179");
                        }
                        //iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        //dr1[iColumnValue++] = "";
                        //dr1[iColumnValue++] = "";
                        //dr1[iColumnValue++] = "";
                        #endregion
                        #region cau 37 Kết quả đánh giá điểm quá trình rõ ràng, chính xác, công bằng.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5187");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5188");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5189");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5190");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5191");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 38 Điểm thi kết thúc học phần được đánh giá chính xác, công bằng
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5192");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5193");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5194");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5195");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5196");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 39 Nội dung đề thi phù hợp với nội dung đã được giảng dạy, ôn tập
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5197");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5198");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5198");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5200");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5201");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #endregion
                        dt999.Rows.Add(dr1);
                    }
                    #region Khoa
                    string strTongQuanKhoaTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and LecturerCode<>'' and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and LecturerCode<>''  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
", strKhoaCode, iMauDe);
                    DataSet dsTongQuanKhoaTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanKhoaTemp);
                    DataRow dr2 = dt999.NewRow();
                    dr2[0] = string.Format("{0} ({1})", strKhoaName, strKhoaCode);
                    dr2[1] = "";
                    dr2[2] = dsTongQuanKhoaTemp.Tables[0].Rows[0][0].ToString();
                    dr2[3] = dsTongQuanKhoaTemp.Tables[1].Rows[0][0].ToString();
                    dr2[4] = dsTongQuanKhoaTemp.Tables[2].Rows[0][0].ToString();
                    dr2[5] = dsTongQuanKhoaTemp.Tables[3].Rows[0][0].ToString();
                    dr2[6] = dsTongQuanKhoaTemp.Tables[4].Rows[0][0].ToString();
                    dr2[7] = dsTongQuanKhoaTemp.Tables[5].Rows[0][0].ToString();
                    dt999.Rows.Add(dr2);
                    #endregion
                }

            }
            #region Truong
            string strTongQuanTruongTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0};
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} ;
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and LecturerCode<>''  and status=4;
", iMauDe);
            DataSet dsTongQuanTruongTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTruongTemp);
            DataRow dr3 = dt999.NewRow();
            dr3[0] = string.Format("{0}", "Toàn trường");
            dr3[1] = "";
            dr3[2] = dsTongQuanTruongTemp.Tables[0].Rows[0][0].ToString();
            dr3[3] = dsTongQuanTruongTemp.Tables[1].Rows[0][0].ToString();
            dr3[4] = dsTongQuanTruongTemp.Tables[2].Rows[0][0].ToString();
            dr3[5] = dsTongQuanTruongTemp.Tables[3].Rows[0][0].ToString();
            dr3[6] = dsTongQuanTruongTemp.Tables[4].Rows[0][0].ToString();
            dr3[7] = dsTongQuanTruongTemp.Tables[5].Rows[0][0].ToString();
            dt999.Rows.Add(dr3);
            #endregion
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dt999,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("ly_thuyet_thuc_hanh" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("xuat du lieu thanh cong");
        }

        private void btnDGGV_XuatDuLieu_MonThucHanh_Click(object sender, EventArgs e)
        {
            int iMauDe = 1023;
            #region Chuan bi du lieu
            string sql = "spSurvey_statistic_getCommon";
            DataSet dsCommon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.StoredProcedure, sql);
            sql = @"SELECT [ID],[BaiKhaoSatID],[SinhVienID],[DeThiID],[LecturerCode],[LecturerName],[ClassRoomCode]
      ,[SubjectCode],[SubjectName],[SubjectType],[DepartmentCode],[Type],[Status]
        FROM [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID=" + iMauDe.ToString();
            //DataTable dtBaiKhaoSat_SinhVien = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            sql = @"SELECT [SemesterId]
      ,[CampaignId]
      ,[CampaignTemplateId]
      ,[ClassRoomId]
      ,[LecturerId]
      ,[QuestionType]
      ,[QuestionId]
      ,[QuestionIndex]
      ,[AnswerId]
      ,[Total]
      ,[Value]
  FROM [dbo].[AS_Edu_Survey_ReportTotal] where [CampaignTemplateId]=" + iMauDe.ToString();
            DataTable dtReportTotal = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            //MessageBox.Show(dtReportTotal.Rows.Count.ToString());
            #endregion
            DataTable dt999 = new DataTable();
            #region Xu ly cac cot.
            dt999.Columns.Add("Khoa");
            dt999.Columns.Add("BoMon");
            dt999.Columns.Add("so_sinh_vien_tham_gia_khao_sat");
            dt999.Columns.Add("so_sinh_vien_duoc_khao_sat");
            dt999.Columns.Add("so_phieu_thu_ve");
            dt999.Columns.Add("so_phieu_phat_ra");
            dt999.Columns.Add("so_giang_vien_da_duoc_khao_sat");
            dt999.Columns.Add("so_giang_vien_can_lay_y_kien_khao_sat");
            int iSoCauHoi = 10;
            for (int i = 1; i <= iSoCauHoi; i++)
            {
                dt999.Columns.Add("cau_" + i.ToString() + "_1");
                dt999.Columns.Add("cau_" + i.ToString() + "_2");
                dt999.Columns.Add("cau_" + i.ToString() + "_3");
                dt999.Columns.Add("cau_" + i.ToString() + "_4");
                dt999.Columns.Add("cau_" + i.ToString() + "_5");
                dt999.Columns.Add("cau_" + i.ToString() + "_dtb");
            }
            #endregion

            DataTable dtKhoa = dsCommon.Tables[0];
            DataTable dtBoMon = dsCommon.Tables[1];
            for (int i = 0; i < dsCommon.Tables[0].Rows.Count; i++)
            {

                int iKhoaID = int.Parse(dsCommon.Tables[0].Rows[i]["ID"].ToString());
                string strKhoaCode = dsCommon.Tables[0].Rows[i]["Code"].ToString();
                string strKhoaName = dsCommon.Tables[0].Rows[i]["Name"].ToString();
                // Lay danh sach bo mon tu khoa
                DataRow[] drBoMons = dtBoMon.Select(string.Format("FacultyCode='{0}'", strKhoaCode));
                if (drBoMons != null && drBoMons.Length > 0)
                {
                    for (int j = 0; j < drBoMons.Length; j++)
                    {
                        string strBoMonCode = drBoMons[j]["Code"].ToString();
                        string strBoMonName = drBoMons[j]["Name"].ToString();
                        DataRow dr1 = dt999.NewRow();
                        dr1[0] = strKhoaName == "" ? strKhoaCode : strKhoaName;
                        dr1[1] = strBoMonName;
                        string strTongQuanTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>''  and status=4;
		select distinct(b.ID) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] a inner join [dbo].[AS_Academy_ClassRoom] b
		on a.ClassRoomCode=b.Code where DeThiID={1} and [DepartmentCode]='{0}';
", strBoMonCode, iMauDe);
                        DataSet dsTongQuanTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTemp);
                        dr1[2] = dsTongQuanTemp.Tables[0].Rows[0][0].ToString();
                        dr1[3] = dsTongQuanTemp.Tables[1].Rows[0][0].ToString();
                        dr1[4] = dsTongQuanTemp.Tables[2].Rows[0][0].ToString();
                        dr1[5] = dsTongQuanTemp.Tables[3].Rows[0][0].ToString();
                        dr1[6] = dsTongQuanTemp.Tables[4].Rows[0][0].ToString();
                        dr1[7] = dsTongQuanTemp.Tables[5].Rows[0][0].ToString();
                        // Lay du lieu cac cot tiep theo
                        #region lay du lieu chinh cua bang
                        int iC11 = 0;
                        int iC12 = 0;
                        int iC13 = 0;
                        int iC14 = 0;
                        int iC15 = 0;
                        //string strC15 = "";
                        float iC1tb = 0;
                        #region cau 1 Lịch thực hiện các bài thực hành/thí nghiệm/thực tập được bố trí hợp lý
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5237");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5238");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5239");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5240");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5241");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        int iColumnValue = 8;
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 2 Giảng viên thông báo chi tiết về cách thức và tiêu chí đánh giá
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5242");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5243");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5244");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5245");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5246");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 3 Các quy định phòng thực hành/thí nghiệm/nơi thực tập, quy định về an toàn lao động được cán bộ hướng dẫn phổ biến một cách đầy đủ, chi tiết.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5247");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5248");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5249");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5250");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5251");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 4 Cán bộ hướng dẫn chuẩn bị cho các buổi thực hành/thí nghiệm/thực tập một cách kỹ lưỡng (dụng cụ, thiết bị, tài liệu hướng dẫn)
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5252");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5253");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5254");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5255");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5256");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 5 Cán bộ hướng dẫn giới thiệu rõ ràng, đầy đủ về nội dung bài thực hành/thí nghiệm (nội dung, yêu cầu, quy trình thực hiện) và thao tác mẫu
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5257");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5258");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5259");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5260");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5261");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 6 Cán bộ hướng dẫn có thái độ thân thiện, tôn trọng và sẵn sàng hỗ trợ sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5262");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5263");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5264");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5265");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5266");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 7 Số lượng sinh viên trong một nhóm phù hợp để từng sinh viên có thể nắm vững nội dung và thực hiện được bài thực hành/thí nghiệm
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5267");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5268");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5269");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5270");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5271");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 8 Việc thực tập online mang lại hiệu quả
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6035");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6036");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6037");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6038");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6039");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 9 Điểm các bài thực hành/thí nghiệm/thực tập được đánh giá chính xác, công bằng
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5272");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5273");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5274");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5275");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5276");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 10 	Điểm các bài thực hành/thí nghiệm/thực tập được công bố cho sinh viên kịp thời
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5277");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5278");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5279");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5280");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5281");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #endregion
                        dt999.Rows.Add(dr1);
                    }
                    #region Khoa
                    string strTongQuanKhoaTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and LecturerCode<>'' and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and LecturerCode<>''  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
", strKhoaCode, iMauDe);
                    DataSet dsTongQuanKhoaTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanKhoaTemp);
                    DataRow dr2 = dt999.NewRow();
                    dr2[0] = string.Format("{0} ({1})", strKhoaName, strKhoaCode);
                    dr2[1] = "";
                    dr2[2] = dsTongQuanKhoaTemp.Tables[0].Rows[0][0].ToString();
                    dr2[3] = dsTongQuanKhoaTemp.Tables[1].Rows[0][0].ToString();
                    dr2[4] = dsTongQuanKhoaTemp.Tables[2].Rows[0][0].ToString();
                    dr2[5] = dsTongQuanKhoaTemp.Tables[3].Rows[0][0].ToString();
                    dr2[6] = dsTongQuanKhoaTemp.Tables[4].Rows[0][0].ToString();
                    dr2[7] = dsTongQuanKhoaTemp.Tables[5].Rows[0][0].ToString();
                    dt999.Rows.Add(dr2);
                    #endregion
                }

            }
            #region Truong
            string strTongQuanTruongTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0};
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} ;
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and LecturerCode<>''  and status=4;
", iMauDe);
            DataSet dsTongQuanTruongTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTruongTemp);
            DataRow dr3 = dt999.NewRow();
            dr3[0] = string.Format("{0}", "Toàn trường");
            dr3[1] = "";
            dr3[2] = dsTongQuanTruongTemp.Tables[0].Rows[0][0].ToString();
            dr3[3] = dsTongQuanTruongTemp.Tables[1].Rows[0][0].ToString();
            dr3[4] = dsTongQuanTruongTemp.Tables[2].Rows[0][0].ToString();
            dr3[5] = dsTongQuanTruongTemp.Tables[3].Rows[0][0].ToString();
            dr3[6] = dsTongQuanTruongTemp.Tables[4].Rows[0][0].ToString();
            dr3[7] = dsTongQuanTruongTemp.Tables[5].Rows[0][0].ToString();
            dt999.Rows.Add(dr3);
            #endregion
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dt999,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("thuc_hanh" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("xuat du lieu thanh cong");
        }

        private void btnDGGV_XuatDuLieu_MonDoAn_Click(object sender, EventArgs e)
        {
            int iMauDe = 1024;
            #region Chuan bi du lieu
            string sql = "spSurvey_statistic_getCommon";
            DataSet dsCommon = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.StoredProcedure, sql);
            sql = @"SELECT [ID],[BaiKhaoSatID],[SinhVienID],[DeThiID],[LecturerCode],[LecturerName],[ClassRoomCode]
      ,[SubjectCode],[SubjectName],[SubjectType],[DepartmentCode],[Type],[Status]
        FROM [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID=" + iMauDe.ToString();
            //DataTable dtBaiKhaoSat_SinhVien = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            sql = @"SELECT [SemesterId]
      ,[CampaignId]
      ,[CampaignTemplateId]
      ,[ClassRoomId]
      ,[LecturerId]
      ,[QuestionType]
      ,[QuestionId]
      ,[QuestionIndex]
      ,[AnswerId]
      ,[Total]
      ,[Value]
  FROM [dbo].[AS_Edu_Survey_ReportTotal] where [CampaignTemplateId]=" + iMauDe.ToString();
            DataTable dtReportTotal = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql).Tables[0];
            //MessageBox.Show(dtReportTotal.Rows.Count.ToString());
            #endregion
            DataTable dt999 = new DataTable();
            #region Xu ly cac cot.
            dt999.Columns.Add("Khoa");
            dt999.Columns.Add("BoMon");
            dt999.Columns.Add("so_sinh_vien_tham_gia_khao_sat");
            dt999.Columns.Add("so_sinh_vien_duoc_khao_sat");
            dt999.Columns.Add("so_phieu_thu_ve");
            dt999.Columns.Add("so_phieu_phat_ra");
            dt999.Columns.Add("so_giang_vien_da_duoc_khao_sat");
            dt999.Columns.Add("so_giang_vien_can_lay_y_kien_khao_sat");
            int iSoCauHoi = 11;
            for (int i = 1; i <= iSoCauHoi; i++)
            {
                dt999.Columns.Add("cau_" + i.ToString() + "_1");
                dt999.Columns.Add("cau_" + i.ToString() + "_2");
                dt999.Columns.Add("cau_" + i.ToString() + "_3");
                dt999.Columns.Add("cau_" + i.ToString() + "_4");
                dt999.Columns.Add("cau_" + i.ToString() + "_5");
                dt999.Columns.Add("cau_" + i.ToString() + "_dtb");
            }
            #endregion

            DataTable dtKhoa = dsCommon.Tables[0];
            DataTable dtBoMon = dsCommon.Tables[1];
            for (int i = 0; i < dsCommon.Tables[0].Rows.Count; i++)
            {

                int iKhoaID = int.Parse(dsCommon.Tables[0].Rows[i]["ID"].ToString());
                string strKhoaCode = dsCommon.Tables[0].Rows[i]["Code"].ToString();
                string strKhoaName = dsCommon.Tables[0].Rows[i]["Name"].ToString();
                // Lay danh sach bo mon tu khoa
                DataRow[] drBoMons = dtBoMon.Select(string.Format("FacultyCode='{0}'", strKhoaCode));
                if (drBoMons != null && drBoMons.Length > 0)
                {
                    for (int j = 0; j < drBoMons.Length; j++)
                    {
                        string strBoMonCode = drBoMons[j]["Code"].ToString();
                        string strBoMonName = drBoMons[j]["Name"].ToString();
                        DataRow dr1 = dt999.NewRow();
                        dr1[0] = strKhoaName == "" ? strKhoaCode : strKhoaName;
                        dr1[1] = strBoMonName;
                        string strTongQuanTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and status=4;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode]='{0}' and LecturerCode<>''  and status=4;
		select distinct(b.ID) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] a inner join [dbo].[AS_Academy_ClassRoom] b
		on a.ClassRoomCode=b.Code where DeThiID={1} and [DepartmentCode]='{0}';
", strBoMonCode, iMauDe);
                        DataSet dsTongQuanTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTemp);
                        dr1[2] = dsTongQuanTemp.Tables[0].Rows[0][0].ToString();
                        dr1[3] = dsTongQuanTemp.Tables[1].Rows[0][0].ToString();
                        dr1[4] = dsTongQuanTemp.Tables[2].Rows[0][0].ToString();
                        dr1[5] = dsTongQuanTemp.Tables[3].Rows[0][0].ToString();
                        dr1[6] = dsTongQuanTemp.Tables[4].Rows[0][0].ToString();
                        dr1[7] = dsTongQuanTemp.Tables[5].Rows[0][0].ToString();
                        // Lay du lieu cac cot tiep theo
                        #region lay du lieu chinh cua bang
                        int iC11 = 0;
                        int iC12 = 0;
                        int iC13 = 0;
                        int iC14 = 0;
                        int iC15 = 0;
                        float iC1tb = 0;
                        #region cau 1 Giáo trình, tài liệu tham khảo phục vụ cho việc làm đồ án được giảng viên giới thiệu, cung cấp kịp thời
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5282");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5283");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5284");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5285");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5286");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        int iColumnValue = 8;
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 2 Quy định về công tác đánh giá điểm quá trình, điểm kết thúc học phần đồ án được giảng viên hướng dẫn phổ biến đầy đủ đến sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5287");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5288");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5289");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5290");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5291");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 3 Lịch hướng dẫn, thông qua đồ án được phổ biến rõ ràng đến sinh viên
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5292");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5293");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5294");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5295");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5296");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 4 	Giảng viên thực hiện đầy đủ số buổi hướng dẫn, thông qua theo lịch đã thông báo
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5297");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5298");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5299");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5300");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5301");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 5 Thời điểm giao nhiệm vụ đồ án phù hợp, đảm bảo cho sinh viên có đủ thời gian thực hiện
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5302");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5303");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5304");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5305");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5306");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 6 Giảng viên nhất quán trong quá trình hướng dẫn thực hiện
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5307");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5308");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5309");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5310");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5311");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 7 Giảng viên hướng dẫn đầy đủ về cách thức thực hiện (nội dung, hình thức) của đồ án
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5312");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5313");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5314");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5315");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5316");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 8 Giảng viên có thái độ thân thiện và nhiệt tình trong việc hướng dẫn thực hiện đồ án
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5317");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5318");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5319");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5320");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5321");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 9 Việc hướng dẫn đồ án online có đem lại hiệu quả.
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6030");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6031");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6032");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6033");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "6034");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 10 	Điểm quá trình học phần đồ án được đánh giá công bằng,chính xác
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5322");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5323");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5324");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5325");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5326");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #region cau 11 	Điểm bảo vệ đồ án được đánh giá công bằng, chính xác
                        iC11 = 0;
                        iC12 = 0;
                        iC13 = 0;
                        iC14 = 0;
                        iC15 = 0;
                        iC1tb = 0;
                        for (int k = 0; k < dsTongQuanTemp.Tables[6].Rows.Count; k++)
                        {
                            string strClassRoom = dsTongQuanTemp.Tables[6].Rows[k][0].ToString();
                            iC11 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5327");
                            iC12 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5328");
                            iC13 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5329");
                            iC14 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5330");
                            iC15 += DGGV_XuatDuLieu_GetValueByClassRoomAndAnsware(dtReportTotal, strClassRoom, "5331");
                        }
                        iC1tb = (iC11 + iC12 + iC13 + iC14 + iC15) == 0 ? 0 : (float)(iC11 + iC12 * 2 + iC13 * 3 + iC14 * 4 + iC15 * 5) / (iC11 + iC12 + iC13 + iC14 + iC15);
                        dr1[iColumnValue++] = iC11;
                        dr1[iColumnValue++] = iC12;
                        dr1[iColumnValue++] = iC13;
                        dr1[iColumnValue++] = iC14;
                        dr1[iColumnValue++] = iC15;
                        dr1[iColumnValue++] = iC1tb.ToString("N1");
                        #endregion
                        #endregion
                        dt999.Rows.Add(dr1);
                    }
                    #region Khoa
                    string strTongQuanKhoaTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1} and LecturerCode<>'' and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={1}  and LecturerCode<>''  and status=4 and [DepartmentCode] in (select code from [dbo].[AS_Academy_Department] where FacultyCode='{0}');
", strKhoaCode, iMauDe);
                    DataSet dsTongQuanKhoaTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanKhoaTemp);
                    DataRow dr2 = dt999.NewRow();
                    dr2[0] = string.Format("{0} ({1})", strKhoaName, strKhoaCode);
                    dr2[1] = "";
                    dr2[2] = dsTongQuanKhoaTemp.Tables[0].Rows[0][0].ToString();
                    dr2[3] = dsTongQuanKhoaTemp.Tables[1].Rows[0][0].ToString();
                    dr2[4] = dsTongQuanKhoaTemp.Tables[2].Rows[0][0].ToString();
                    dr2[5] = dsTongQuanKhoaTemp.Tables[3].Rows[0][0].ToString();
                    dr2[6] = dsTongQuanKhoaTemp.Tables[4].Rows[0][0].ToString();
                    dr2[7] = dsTongQuanKhoaTemp.Tables[5].Rows[0][0].ToString();
                    dt999.Rows.Add(dr2);
                    #endregion
                }

            }
            #region Truong
            string strTongQuanTruongTemp = string.Format(@"select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0};
		select count(distinct(sinhvienID)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and status=4 ;
		select count(1) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} ;
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0} and LecturerCode<>'';
		select count(distinct(LecturerCode)) from [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where DeThiID={0}  and LecturerCode<>''  and status=4;
", iMauDe);
            DataSet dsTongQuanTruongTemp = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, strTongQuanTruongTemp);
            DataRow dr3 = dt999.NewRow();
            dr3[0] = string.Format("{0}", "Toàn trường");
            dr3[1] = "";
            dr3[2] = dsTongQuanTruongTemp.Tables[0].Rows[0][0].ToString();
            dr3[3] = dsTongQuanTruongTemp.Tables[1].Rows[0][0].ToString();
            dr3[4] = dsTongQuanTruongTemp.Tables[2].Rows[0][0].ToString();
            dr3[5] = dsTongQuanTruongTemp.Tables[3].Rows[0][0].ToString();
            dr3[6] = dsTongQuanTruongTemp.Tables[4].Rows[0][0].ToString();
            dr3[7] = dsTongQuanTruongTemp.Tables[5].Rows[0][0].ToString();
            dt999.Rows.Add(dr3);
            #endregion
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dt999,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("do_an" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("xuat du lieu thanh cong");
        }

        private void btnDGGV_XuatDuLieu_FileDocComment_Click(object sender, EventArgs e)
        {
            ComponentInfo.SetLicense("DTZX-HTZ5-B7Q6-2GA6");
            #region bien
            Section[] sections;
            Section section;
            Section section1;
            Section section2;
            Section section3;
            Section section4;
            Section section5;
            Section section6;
            Section section7;
            Section section8;
            Section section9;
            Section sectionFaculty;
            Section sectionFaculty1;
            Section sectionFaculty2;
            Section sectionFaculty3;
            Section sectionFaculty4;
            Section sectionFaculty5;
            Section sectionFaculty6;
            Section sectionFaculty7;
            Section sectionFaculty8;
            Section sectionFaculty9;
            Section[] sectionFacultys = new Section[10];
            string[] sDepartments = new string[15];
            int iCountFaculty;

            string strNameFaculty = "";
            string strCodeFaculty = "";
            string strNameDepartment = "";
            string strCodeDepartment = "";
            int iDepartmentId;
            int iClassRoomId;
            DataRow[] drTemps;
            DataRow drClassRoom;
            int iCount;
            string strUuDiem = "";
            string strNhuocDiem = "";
            string strThichGiangDay = "";
            string strThichKetQuaHocTap = "";
            string strThichHoTroSinhVienHocTap = "";

            string strKoThichGiangDay = "";
            string strKoThichKetQuaHocTap = "";
            string strKoThichHoTroSinhVienHocTap = "";

            string strDongGhopNoiDung = "";
            string strDongGhopCongTacGiangDay = "";
            string strDongGhopDanhGiaKetQuaHocTap = "";
            string strDongGopVeCongTacHoTroSinhVien = "";
            bool isCheck, isCheck1;
            #endregion
            // Lay du lieu cua khoa
            string sql = string.Format(@"Select *,(Code+'-'+Name) as Name1 from [dbo].[AS_Academy_Faculty] where Code in (Select distinct(FacultyCode) from [dbo].[AS_Academy_Department] 
                                        where Code in (select distinct(DepartmentCode) from [dbo].[AS_Academy_Lecturer])) and Code not in ('*') order by c_Order;
                                         select * from [dbo].[AS_Academy_Department] order by Code;
                                         SELECT * FROM [dbo].[AS_Edu_Survey_ReportTotal] where  value<>'' and QuestionID in (3356 ,3357,3358,3359,3360,3361,3362,3364,3365,3366,3367);");
            DataSet ds1 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                DocumentModel document = new DocumentModel();
                document.DefaultCharacterFormat.Size = 13;
                document.DefaultCharacterFormat.FontName = "Times New Roman";
                strNameFaculty = ds1.Tables[0].Rows[i]["Name"].ToString();
                strCodeFaculty = ds1.Tables[0].Rows[i]["Code"].ToString();

                drTemps = common.getDeparmentFromFacultyCode(ds1.Tables[1], strCodeFaculty);
                iCount = 0;
                sections = new Section[drTemps.Length];
                sDepartments = new string[drTemps.Length];
                isCheck = true;
                for (int j = 0; j < drTemps.Length; j++)
                {
                    strNameDepartment = drTemps[j]["Name"].ToString();
                    strCodeDepartment = drTemps[j]["Code"].ToString();
                    iDepartmentId = int.Parse(drTemps[j]["ID"].ToString());
                    sql = string.Format(@" select * from [dbo].[AS_Academy_Lecturer] where ID in (select distinct([LecturerID]) from [dbo].[AS_Academy_Lecturer_ClassRoom] ) and ID>0 and DepartmentCode='{0}' order by NameOrder ;
SELECT distinct(LecturerCode) FROM [dbo].[AS_Edu_Survey_BaiKhaoSat_SinhVien] where LecturerCode in (select Code from [dbo].[AS_Academy_Lecturer] where ID in (select distinct([LecturerID]) from [dbo].[AS_Academy_Lecturer_ClassRoom] ) and ID>0 and DepartmentCode='{0}') and Status=4 and BaiKhaoSatID<5;
", strCodeDepartment);
                    DataSet ds2 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql);
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        int iIDLecurerTempD = 0;
                        string strLecturerCode = "";
                        int iTotalLecturerInCampagneD = ds2.Tables[0].Rows.Count;
                        int iTotalLecturerBeSurvedD = 0;
                        sDepartments[iCount] = strNameDepartment;
                        iCount++;

                        // Chi tiết 1 bộ môn

                        #region Bang Giang Vien
                        Table tableD = new Table(document);
                        tableD.TableFormat.PreferredWidth = new TableWidth(69, TableWidthUnit.Percentage);
                        tableD.TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;

                        TableRow row = new TableRow(document);
                        TableCell cell;
                        tableD.Rows.Add(row);
                        row.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "STT"))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );
                        row.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Tên giảng viên"))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        }
                        )
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );
                        row.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Đã được khảo sát"))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        })
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        }
                       )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                       );
                        row.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Chưa được khảo sát"))
                        {
                            CharacterFormat = new CharacterFormat()
                            {
                                Bold = true
                            }
                        })
                        {
                            ParagraphFormat = new ParagraphFormat()
                            {
                                Alignment = GemBox.Document.HorizontalAlignment.Center
                            }
                        }
                        )
                        {
                            CellFormat = new TableCellFormat()
                            {
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                        );

                        for (int k = 0; k < iTotalLecturerInCampagneD; k++)
                        {
                            row = new TableRow(document);
                            tableD.Rows.Add(row);
                            row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", k + 1))
                            {
                                ParagraphFormat = new ParagraphFormat()
                                {
                                    Alignment = GemBox.Document.HorizontalAlignment.Center
                                }
                            }
                            )
                            {
                                CellFormat = new TableCellFormat()
                                {
                                    VerticalAlignment = VerticalAlignment.Center
                                }
                            }
                            );

                            iIDLecurerTempD = int.Parse(ds2.Tables[0].Rows[k]["ID"].ToString());
                            strLecturerCode = ds2.Tables[0].Rows[k]["Code"].ToString();
                            //paraD = new Paragraph(document, string.Format("{0}", ds3.Tables[5].Rows[k]["FullName"].ToString()));


                            row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", ds2.Tables[0].Rows[k]["FullName"].ToString()))
                            {
                                ParagraphFormat = new ParagraphFormat()
                                {
                                    Alignment = GemBox.Document.HorizontalAlignment.Left
                                }
                            }
                            )
                            {
                                CellFormat = new TableCellFormat()
                                {
                                    VerticalAlignment = VerticalAlignment.Center
                                }
                            }
                            );


                            if (common.checkLecturerBeSurvedByDepartement(ds2.Tables[1], strLecturerCode))
                            {
                                row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", "x"))
                                {
                                    ParagraphFormat = new ParagraphFormat()
                                    {
                                        Alignment = GemBox.Document.HorizontalAlignment.Center
                                    }
                                }
                                )
                                {
                                    CellFormat = new TableCellFormat()
                                    {
                                        VerticalAlignment = VerticalAlignment.Center
                                    }
                                }
                                );
                                row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", " "))
                                {
                                    ParagraphFormat = new ParagraphFormat()
                                    {
                                        Alignment = GemBox.Document.HorizontalAlignment.Center
                                    }
                                }
                                )
                                {
                                    CellFormat = new TableCellFormat()
                                    {
                                        VerticalAlignment = VerticalAlignment.Center
                                    }
                                }
                                );


                                iTotalLecturerBeSurvedD++;
                            }
                            else
                            {
                                row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", " "))
                                {
                                    ParagraphFormat = new ParagraphFormat()
                                    {
                                        Alignment = GemBox.Document.HorizontalAlignment.Center
                                    }
                                }
                                )
                                {
                                    CellFormat = new TableCellFormat()
                                    {
                                        VerticalAlignment = VerticalAlignment.Center
                                    }
                                }
                                );
                                row.Cells.Add(new TableCell(document, new Paragraph(document, string.Format("{0}", "x"))
                                {
                                    ParagraphFormat = new ParagraphFormat()
                                    {
                                        Alignment = GemBox.Document.HorizontalAlignment.Center
                                    }
                                }
                                )
                                {
                                    CellFormat = new TableCellFormat()
                                    {
                                        VerticalAlignment = VerticalAlignment.Center
                                    }
                                }
                                );
                            }

                        }
                        #endregion

                        #region Thong tin tieu de va add bang giang vien
                        if (isCheck)
                        {
                            section = new Section(document,
                                         new Paragraph(document,

                                                       new Run(document, string.Format("PHỤ LỤC {0} ", (i + 1)))
                                                       {
                                                           CharacterFormat = new CharacterFormat()
                                                           {
                                                               Bold = true,
                                                               Size = 14
                                                           }

                                                       },
                                                       new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, string.Format("Thống kê chi tiết giảng viên trong khoa ", strNameFaculty))
                                                       {
                                                           CharacterFormat = new CharacterFormat()
                                                           {
                                                               Bold = true,
                                                               Size = 13
                                                           }

                                                       },
                                                       new SpecialCharacter(document, SpecialCharacterType.LineBreak)
                                                   )
                                         {
                                             ParagraphFormat = new ParagraphFormat
                                             {
                                                 Alignment = GemBox.Document.HorizontalAlignment.Center,
                                             }
                                         },
                                         new Paragraph(document,
                                                      new Run(document, string.Format("{0}. Bộ môn {1}", iCount, strNameDepartment))
                                                      {
                                                          CharacterFormat = new CharacterFormat()
                                                          {
                                                              Bold = true
                                                          }

                                                      }
                                                      ),
                                         new Paragraph(document,
                                                       new Run(document, string.Format("Danh sách giảng viên trong đợt lấy ý kiến"))
                                                       {
                                                           CharacterFormat = new CharacterFormat()
                                                           {
                                                               Bold = true
                                                           }

                                                       }
                                                    )
                                         {
                                             ParagraphFormat = new ParagraphFormat
                                             {
                                                 Alignment = GemBox.Document.HorizontalAlignment.Center,
                                             }
                                         }
                                         ,
                                         tableD
                                     );
                            section.PageSetup.Orientation = GemBox.Document.Orientation.Landscape;
                            section.PageSetup.PaperType = GemBox.Document.PaperType.A4;
                            document.Sections.Add(section);
                            isCheck = false;
                        }
                        else
                        {
                            section = new Section(document,
                                        new Paragraph(document,
                                                     new Run(document, string.Format("{0}. Bộ môn {1} ", iCount, strNameDepartment))
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     }
                                                     ),
                                        new Paragraph(document,
                                                      new Run(document, string.Format("Danh sách giảng viên trong đợt lấy ý kiến"))
                                                      {
                                                          CharacterFormat = new CharacterFormat()
                                                          {
                                                              Bold = true
                                                          }

                                                      }
                                                   )
                                        {
                                            ParagraphFormat = new ParagraphFormat
                                            {
                                                Alignment = GemBox.Document.HorizontalAlignment.Center,
                                            }
                                        },
                                        tableD
                                    );
                            section.PageSetup.Orientation = GemBox.Document.Orientation.Landscape;
                            section.PageSetup.PaperType = GemBox.Document.PaperType.A4;
                            document.Sections.Add(section);
                        }
                        #endregion

                        #region Chi tiet giang vien
                        for (int k = 0; k < iTotalLecturerInCampagneD; k++)
                        {
                            /*
                            Mau 1: 
                            Thich nhat:
                                Giang day: 3356
                                Ket qua hoc tap: 3357
                                Ho tro sinh vien hoc tap: 3358
                            Khong thich nhat:
                                Giang day: 3360
                                Ket qua hoc tap: 3361
                                Ho tro sinh vien hoc tap: 3362
                            Mau 2: 
                            Thich nhat:
                                Giang day: 3356
                                Ket qua hoc tap: 3357
                                Ho tro sinh vien hoc tap: 3358
                            Khong thich nhat:
                                Giang day: 3360
                                Ket qua hoc tap: 3361
                                Ho tro sinh vien hoc tap: 3362
                            Đóng góp ý kiến cho học phần này
                                Về nội dung: 3364
                                Về công tác giảng dạy:3365
                                Về đánh giá kết quả học tập: 3366
                                Về công tác hỗ trợ sinh viên học tập: 3367
                            */
                            strLecturerCode = ds2.Tables[0].Rows[k]["Code"].ToString();
                            iIDLecurerTempD = int.Parse(ds2.Tables[0].Rows[k]["ID"].ToString());
                            strUuDiem = "";
                            strNhuocDiem = "";
                            strThichGiangDay = "";
                            strThichKetQuaHocTap = "";
                            strThichHoTroSinhVienHocTap = "";

                            strKoThichGiangDay = "";
                            strKoThichKetQuaHocTap = "";
                            strKoThichHoTroSinhVienHocTap = "";

                            strDongGhopNoiDung = "";
                            strDongGhopCongTacGiangDay = "";
                            strDongGhopDanhGiaKetQuaHocTap = "";
                            strDongGopVeCongTacHoTroSinhVien = "";
                            #region 

                            #endregion
                            if (common.checkLecturerBeSurvedByDepartement(ds2.Tables[1], strLecturerCode))
                            {
                                //
                                // Xây dựng chi tiết giảng viên
                                // Lấy danh sách từng môn giảng dạy của giảng viên

                                strThichGiangDay += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3356, iIDLecurerTempD);
                                strThichGiangDay = Regex.Replace(strThichGiangDay, @"\t|\n|\r", " ");
                                strThichKetQuaHocTap += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3357, iIDLecurerTempD);
                                strThichKetQuaHocTap = Regex.Replace(strThichKetQuaHocTap, @"\t|\n|\r", " ");
                                strThichHoTroSinhVienHocTap += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3358, iIDLecurerTempD);
                                strThichHoTroSinhVienHocTap = Regex.Replace(strThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");
                                //DIeuBanthichNhat ve giang vien 25
                                strKoThichGiangDay += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3360, iIDLecurerTempD);
                                strKoThichGiangDay = Regex.Replace(strKoThichGiangDay, @"\t|\n|\r", " ");
                                strKoThichKetQuaHocTap += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3361, iIDLecurerTempD);
                                strKoThichKetQuaHocTap = Regex.Replace(strKoThichKetQuaHocTap, @"\t|\n|\r", " ");
                                strKoThichHoTroSinhVienHocTap += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3362, iIDLecurerTempD);
                                strKoThichHoTroSinhVienHocTap = Regex.Replace(strKoThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");

                                strDongGhopNoiDung += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3364, iIDLecurerTempD);
                                strDongGhopNoiDung = Regex.Replace(strKoThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");
                                strDongGhopCongTacGiangDay += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3365, iIDLecurerTempD);
                                strDongGhopCongTacGiangDay = Regex.Replace(strDongGhopCongTacGiangDay, @"\t|\n|\r", " ");
                                strDongGhopDanhGiaKetQuaHocTap += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3366, iIDLecurerTempD);
                                strDongGhopDanhGiaKetQuaHocTap = Regex.Replace(strDongGhopDanhGiaKetQuaHocTap, @"\t|\n|\r", " ");
                                strDongGopVeCongTacHoTroSinhVien += common.getTextFromQuestionAndLecturer(ds1.Tables[2], 3367, iIDLecurerTempD);
                                strDongGopVeCongTacHoTroSinhVien = Regex.Replace(strDongGopVeCongTacHoTroSinhVien, @"\t|\n|\r", " ");
                                #region 
                                section = new Section(document,
                                                    new Paragraph(document,
                                                     new Run(document, string.Format("{0}.{1}. Giảng viên {2}", iCount, k + 1, ds2.Tables[0].Rows[k]["FullName"].ToString()))
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                        new Run(document, string.Format("{0}.{1}.1 {2} ", iCount, k + 1, "Những điều thích về giảng viên"))
                                                        {
                                                            CharacterFormat = new CharacterFormat()
                                                            {
                                                                Bold = true
                                                            }

                                                        },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về công tác giảng dạy")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strThichGiangDay),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về đánh giá kết quả học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strThichKetQuaHocTap),
                                                    new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về đánh giá hỗ trợ sinh viên học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strThichHoTroSinhVienHocTap),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                        new Run(document, string.Format("{0}.{1}.2 {2} ", iCount, k + 1, "Những điều không thích về giảng viên"))
                                                        {
                                                            CharacterFormat = new CharacterFormat()
                                                            {
                                                                Bold = true
                                                            }

                                                        },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về công tác giảng dạy")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strKoThichGiangDay),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về đánh giá kết quả học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strKoThichKetQuaHocTap),
                                                    new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về đánh giá hỗ trợ sinh viên học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strKoThichHoTroSinhVienHocTap),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                        new Run(document, string.Format("{0}.{1}.3 {2} ", iCount, k + 1, " Đóng góp ý kiến "))
                                                        {
                                                            CharacterFormat = new CharacterFormat()
                                                            {
                                                                Bold = true
                                                            }

                                                        },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về nội dung")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, strDongGhopNoiDung),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về công tác giảng dạy")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strDongGhopCongTacGiangDay),
                                                      new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về đánh giá kết quả học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strDongGhopDanhGiaKetQuaHocTap),
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                     new Run(document, "- Về công tác hỗ trợ sinh viên học tập")
                                                     {
                                                         CharacterFormat = new CharacterFormat()
                                                         {
                                                             Bold = true
                                                         }

                                                     },
                                                     new SpecialCharacter(document, SpecialCharacterType.LineBreak),
                                                       new Run(document, strDongGopVeCongTacHoTroSinhVien)
                                                     )
                                                );
                                section.PageSetup.Orientation = GemBox.Document.Orientation.Landscape;
                                section.PageSetup.PaperType = GemBox.Document.PaperType.A4;
                                document.Sections.Add(section);
                                #endregion
                            }
                            else
                            {
                                #region 
                                //paraD = new Paragraph(document, string.Format("{0}", ds3.Tables[5].Rows[k]["FullName"].ToString()));
                                section = new Section(document,
                                                        new Paragraph(document,
                                                         new Run(document, string.Format("{0}.{1}. Giảng viên {2}", iCount, k + 1, ds2.Tables[0].Rows[k]["FullName"].ToString()))
                                                         {
                                                             CharacterFormat = new CharacterFormat()
                                                             {
                                                                 Bold = true
                                                             }

                                                         }
                                                         ),
                                                          new Paragraph(document,
                                                                        new Run(document, string.Format("Giảng viên chưa được khảo sát"))
                                                                        {
                                                                            CharacterFormat = new CharacterFormat()
                                                                            {
                                                                                Bold = true
                                                                            }

                                                                        }
                                                                     )
                                                          {
                                                              ParagraphFormat = new ParagraphFormat
                                                              {
                                                                  Alignment = GemBox.Document.HorizontalAlignment.Center,
                                                              }
                                                          }
                                                    );
                                section.PageSetup.Orientation = GemBox.Document.Orientation.Landscape;
                                section.PageSetup.PaperType = GemBox.Document.PaperType.A4;
                                document.Sections.Add(section);
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
                document.Save(string.Format("Phu_luc_{0}_{1}_{2}.docx", i + 1, strNameFaculty, DateTime.Now.ToFileTimeUtc()));

            }
            MessageBox.Show("Thanh cong !!!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Xay dung file excel
            // Lay khoa -> bo mon -> hoc phan -> cau tra loi
            #region KhaiBao
            DataTable dtData = new DataTable();
            dtData.Columns.Add("Khoa");
            dtData.Columns.Add("BoMon");
            dtData.Columns.Add("GiangVien");
            dtData.Columns.Add("HocPhan");
            dtData.Columns.Add("LopMonHoc");
            dtData.Columns.Add("Thich_nhat_giang_day");
            dtData.Columns.Add("Thich_nhat_danh_gia_ket_qua_hoc_tap");
            dtData.Columns.Add("Thich_nhat_cong_tac_ho_tro_sinh_vien");
            dtData.Columns.Add("khong_Thich_nhat_giang_day");
            dtData.Columns.Add("khong_Thich_nhat_danh_gia_ket_qua_hoc_tap");
            dtData.Columns.Add("khong_Thich_nhat_cong_tac_ho_tro_sinh_vien");
            dtData.Columns.Add("dong_gop_y_kien_ve_noi_dung");
            dtData.Columns.Add("dong_gop_y_kien_ve_giang_day");
            dtData.Columns.Add("dong_gop_y_kien_ve_ket_qua_hoc_tap");
            dtData.Columns.Add("dong_gop_y_kien_ve_cong_tac_ho_tro_sinh_vien_hoc_tap");
            dtData.Columns.Add("LoaiHocPhan");
            string strNameFaculty = "";
            string strCodeFaculty = "";
            string strNameDepartment = "";
            string strCodeDepartment = "";
            int iDepartmentId;
            int iClassRoomId;
            DataRow[] drTemps;
            DataRow[] drTemp1s;
            DataRow drClassRoom;
            int iCount;
            string strUuDiem = "";
            string strNhuocDiem = "";
            string strThichGiangDay = "";
            string strThichKetQuaHocTap = "";
            string strThichHoTroSinhVienHocTap = "";

            string strKoThichGiangDay = "";
            string strKoThichKetQuaHocTap = "";
            string strKoThichHoTroSinhVienHocTap = "";

            string strDongGhopNoiDung = "";
            string strDongGhopCongTacGiangDay = "";
            string strDongGhopDanhGiaKetQuaHocTap = "";
            string strDongGopVeCongTacHoTroSinhVien = "";
            bool isCheck, isCheck1;
            #endregion
            #region NoiDung
            string sql = string.Format(@"Select *,(Code+'-'+Name) as Name1 from [dbo].[AS_Academy_Faculty] where Code in (Select distinct(FacultyCode) from [dbo].[AS_Academy_Department] where Code in (select distinct(DepartmentCode) from [dbo].[AS_Academy_Lecturer])) and Code not in ('*') order by c_Order;
                                         select * from [dbo].[AS_Academy_Department] order by Code;
                                         SELECT * FROM [dbo].[AS_Edu_Survey_ReportTotal] where  value<>'' and QuestionID in (3356 ,3357,3358,3359,3360,3361,3362,3364,3365,3366,3367);
                                         SELECT b.ID,a.LecturerCode,a.LecturerID,b.GroupCode,c.Name,d.Type FROM [dbo].[AS_Academy_Lecturer_ClassRoom] a inner join [dbo].[AS_Academy_ClassRoom] b on a.ClassRoomID=b.ID inner join [dbo].[AS_Academy_Subject] c on b.SubjectID=c.ID inner join [dbo].[AS_Academy_Subject_Extent] d on c.Code=d.Code;");
            DataSet ds1 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                strNameFaculty = ds1.Tables[0].Rows[i]["Name"].ToString();
                strCodeFaculty = ds1.Tables[0].Rows[i]["Code"].ToString();

                drTemps = common.getDeparmentFromFacultyCode(ds1.Tables[1], strCodeFaculty);

                for (int j = 0; j < drTemps.Length; j++)
                {
                    strNameDepartment = drTemps[j]["Name"].ToString();
                    strCodeDepartment = drTemps[j]["Code"].ToString();
                    iDepartmentId = int.Parse(drTemps[j]["ID"].ToString());
                    sql = string.Format(@" select * from [dbo].[AS_Academy_Lecturer] where ID in (select distinct([LecturerID]) from [dbo].[AS_Academy_Lecturer_ClassRoom] ) and ID>0 and DepartmentCode='{0}' order by NameOrder ;", strCodeDepartment);
                    DataSet ds2 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(common.ConnectionString1, CommandType.Text, sql);

                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                        {
                            int iIDLecurerTempD = 0;
                            string strLecturerCode = "";
                            string strLecturerName = "";
                            iIDLecurerTempD = int.Parse(ds2.Tables[0].Rows[k]["ID"].ToString());
                            strLecturerCode = ds2.Tables[0].Rows[k]["Code"].ToString();
                            strLecturerName = ds2.Tables[0].Rows[k]["FullName"].ToString();
                            // Lay thong tin tung hoc phan cua tung giang vien
                            drTemp1s = ds1.Tables[3].Select("LecturerID=" + iIDLecurerTempD.ToString());
                            for (int l = 0; l < drTemp1s.Length; l++)
                            {
                                DataRow drTemp = dtData.NewRow();
                                drTemp[0] = strNameFaculty;
                                drTemp[1] = strNameDepartment;
                                drTemp[2] = strLecturerName;
                                drTemp[3] = drTemp1s[l]["Name"].ToString();
                                drTemp[4] = drTemp1s[l]["GroupCode"].ToString();
                                int iClassRoom = int.Parse(drTemp1s[l]["ID"].ToString());

                                // Lay du lieu cac tham so de dua vao
                                strUuDiem = "";
                                strNhuocDiem = "";
                                strThichGiangDay = "";
                                strThichKetQuaHocTap = "";
                                strThichHoTroSinhVienHocTap = "";

                                strKoThichGiangDay = "";
                                strKoThichKetQuaHocTap = "";
                                strKoThichHoTroSinhVienHocTap = "";

                                strDongGhopNoiDung = "";
                                strDongGhopCongTacGiangDay = "";
                                strDongGhopDanhGiaKetQuaHocTap = "";
                                strDongGopVeCongTacHoTroSinhVien = "";
                                strThichGiangDay += common.getTextFromClassroom(ds1.Tables[2], 3356, iClassRoom);
                                strThichGiangDay = Regex.Replace(strThichGiangDay, @"\t|\n|\r", " ");
                                drTemp[5] = strThichGiangDay;
                                strThichKetQuaHocTap += common.getTextFromClassroom(ds1.Tables[2], 3357, iClassRoom);
                                strThichKetQuaHocTap = Regex.Replace(strThichKetQuaHocTap, @"\t|\n|\r", " ");
                                drTemp[6] = strThichKetQuaHocTap;
                                strThichHoTroSinhVienHocTap += common.getTextFromClassroom(ds1.Tables[2], 3358, iClassRoom);
                                strThichHoTroSinhVienHocTap = Regex.Replace(strThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");
                                drTemp[7] = strThichHoTroSinhVienHocTap;
                                //DIeuBanthichNhat ve giang vien 25
                                strKoThichGiangDay += common.getTextFromClassroom(ds1.Tables[2], 3360, iClassRoom);
                                strKoThichGiangDay = Regex.Replace(strKoThichGiangDay, @"\t|\n|\r", " ");
                                drTemp[8] = strKoThichGiangDay;
                                strKoThichKetQuaHocTap += common.getTextFromClassroom(ds1.Tables[2], 3361, iClassRoom);
                                strKoThichKetQuaHocTap = Regex.Replace(strKoThichKetQuaHocTap, @"\t|\n|\r", " ");
                                drTemp[9] = strKoThichKetQuaHocTap;
                                strKoThichHoTroSinhVienHocTap += common.getTextFromClassroom(ds1.Tables[2], 3362, iClassRoom);
                                strKoThichHoTroSinhVienHocTap = Regex.Replace(strKoThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");
                                drTemp[10] = strDongGhopNoiDung;
                                strDongGhopNoiDung += common.getTextFromClassroom(ds1.Tables[2], 3364, iClassRoom);
                                strDongGhopNoiDung = Regex.Replace(strKoThichHoTroSinhVienHocTap, @"\t|\n|\r", " ");
                                drTemp[11] = strDongGhopNoiDung;
                                strDongGhopCongTacGiangDay += common.getTextFromClassroom(ds1.Tables[2], 3365, iClassRoom);
                                strDongGhopCongTacGiangDay = Regex.Replace(strDongGhopCongTacGiangDay, @"\t|\n|\r", " ");
                                drTemp[12] = strDongGhopCongTacGiangDay;
                                strDongGhopDanhGiaKetQuaHocTap += common.getTextFromClassroom(ds1.Tables[2], 3366, iClassRoom);
                                strDongGhopDanhGiaKetQuaHocTap = Regex.Replace(strDongGhopDanhGiaKetQuaHocTap, @"\t|\n|\r", " ");
                                drTemp[13] = strDongGhopDanhGiaKetQuaHocTap;
                                strDongGopVeCongTacHoTroSinhVien += common.getTextFromClassroom(ds1.Tables[2], 3367, iClassRoom);
                                strDongGopVeCongTacHoTroSinhVien = Regex.Replace(strDongGopVeCongTacHoTroSinhVien, @"\t|\n|\r", " ");
                                drTemp[14] = strDongGopVeCongTacHoTroSinhVien;
                                drTemp[15] = drTemp1s[l]["Type"].ToString(); ;
                                dtData.Rows.Add(drTemp);
                            }
                        }
                        // Chi tiết 1 bộ môn
                    }
                }
            }
            #endregion

            #region Xuat File
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws3 = ef.Worksheets.Add("Data");
            ws3.InsertDataTable(dtData,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 0
            });
            ef.Save("cau_hoi_mo_" + DateTime.Now.ToFileTimeUtc().ToString() + ".xlsx");
            MessageBox.Show("Thanh cong !!!");
            #endregion
        }

        private void btnTaoBangDongTuExcel_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("check_email_anh_ha.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["tong_hop"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(cell.Value.ToString()).Replace(" ", "_"));
            }
            int iColumn = 0;
            for (int i = 1; i < 2000; i++)
            {
                iColumn = 0;
                dt.Rows.Add();
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {

                    if (cell.Value != null)
                        dt.Rows[i - 1][iColumn] = cell.Value.ToString();
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }
            Random rnd = new Random();
            int iRandom = rnd.Next(100, 100000);
            string strSQL = string.Format(@" CREATE TABLE [dbo].[nuce_temp_{0}]( ", iRandom);
            string strInsertH = string.Format("INSERT INTO [dbo].[nuce_temp_{0}](", iRandom);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                strSQL += dt.Columns[i].ColumnName + "[nvarchar](1000) NULL,";
                strInsertH += dt.Columns[i].ColumnName + ",";
            }
            strSQL += @"
	[count]
        [int] NULL
) ON[PRIMARY];";
            strInsertH += "[count])VALUES(";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!dt.Rows[i][0].ToString().Trim().Equals(""))
                {
                    strSQL += strInsertH;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        //strSQL += string.Format("N'{0}',", Converter.TCVN3ToUnicode(dt.Rows[i][j].ToString()));
                        strSQL += string.Format("N'{0}',", dt.Rows[i][j].ToString());
                    }
                    strSQL += i.ToString() + ");";
                }
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(nuce.web.data.Nuce_Common.GetConnection(), CommandType.Text, strSQL);
            grvView.DataSource = dt;
        }

        private void btnSVTKTNExportSVMR_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            // Lấy danh sách khoa
            DataTable dtLop = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, "select distinct(lopqd) from [nuce_temp_98315] order by lopqd;").Tables[0];
            for (int i = 0; i < dtLop.Rows.Count; i++)
            {
                string lop = dtLop.Rows[i][0].ToString();

                ExcelFile ef = new ExcelFile();
                ExcelWorksheet ws = ef.Worksheets.Add(lop);

                DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, "select ROW_NUMBER() OVER (ORDER BY masv) AS stt,masv,hoten,gioi,nsinh,tenchnga,tennganh,lopqd,email,mobile from  [nuce_temp_98315] where lopqd='" + lop + "';").Tables[0];

                // Insert DataTable into an Excel worksheet.
                ws.InsertDataTable(dtData,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true,
                        StartRow = 0
                    });

                ef.Save(lop + ".xlsx");
            }
            MessageBox.Show("Xuất dữ liệu thành công !");
        }

        private void btnSVTKTNExportSVCHUAKHAOSATTHEOKHOA_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            // Lấy danh sách khoa
            string strGetKhoa = @"select distinct(Khoa_Quan_ly),MAKHOA from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_SV_2018] a left join 
[dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien] b on a.masv=b.ex_masv
where b.id not in (select SinhVienID from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien]
where Status=3) 
";
            DataTable dtKhoa = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strGetKhoa).Tables[0];
            for (int i = 0; i < dtKhoa.Rows.Count; i++)
            {
                string MAKHOA = dtKhoa.Rows[i]["MAKHOA"].ToString();
                string Khoa_Quan_ly = dtKhoa.Rows[i]["Khoa_Quan_ly"].ToString();
                ExcelFile ef = new ExcelFile();
                ExcelWorksheet ws = ef.Worksheets.Add(MAKHOA);
                strGetKhoa = string.Format(@"select ROW_NUMBER() OVER (ORDER BY a.lopqd,a.count) AS stt, a.tenchnga,a.tennganh,a.masv,a.hoten,a.gioi,b.mobile,b.email,a.lopqd from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_SV_2018] a left join 
[dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien] b on a.masv=b.ex_masv
where a.MAKHOA='{0}' and b.id not in (select SinhVienID from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien]
where Status=3) 
order by a.lopqd,a.count", MAKHOA);
                DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strGetKhoa).Tables[0];

                // Insert DataTable into an Excel worksheet.
                ws.InsertDataTable(dtData,
                    new InsertDataTableOptions()
                    {
                        ColumnHeaders = true,
                        StartRow = 0
                    });

                ef.Save(MAKHOA + "_" + Khoa_Quan_ly + ".xlsx");
            }
            MessageBox.Show("Xuất dữ liệu thành công !");
        }

        private void btnTestForm_Click(object sender, EventArgs e)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            DocumentModel document = new DocumentModel();

            document.DefaultCharacterFormat.Size = 12;
            document.DefaultCharacterFormat.FontName = "Times New Roman";

            Section section;
            section = new Section(document);
            var pageSetup = section.PageSetup;
        
            #region Cộng hòa xã hội chủ nghĩa việt nam
            Table table = new Table(document);
            table.TableFormat.PreferredWidth = new TableWidth(100, TableWidthUnit.Percentage);
            table.TableFormat.Alignment = GemBox.Document.HorizontalAlignment.Center;
            var tableBorders = table.TableFormat.Borders;
            tableBorders.SetBorders(MultipleBorderTypes.All, GemBox.Document.BorderStyle.None, Color.Empty, 0);
            table.Columns.Add(new TableColumn() { PreferredWidth = 35 });
            table.Columns.Add(new TableColumn() { PreferredWidth = 65 });
            TableRow rowT1 = new TableRow(document);
            table.Rows.Add(rowT1);

            rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "BỘ GIÁO DỤC VÀ ĐÀO TẠO"))
            {
                CharacterFormat = new CharacterFormat()
                {
                    Size = 12
                }
            }
            )
            {
                ParagraphFormat = new ParagraphFormat()
                {
                    Alignment = GemBox.Document.HorizontalAlignment.Center
                }
            })
            {
                CellFormat = new TableCellFormat()
                {
                    VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                }
            }
            );
            rowT1.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM"))
            {
                CharacterFormat = new CharacterFormat()
                {
                    Bold = true,
                    Size = 12
                }
            }
           )
            {
                ParagraphFormat = new ParagraphFormat()
                {
                    Alignment = GemBox.Document.HorizontalAlignment.Center
                }
            })
            {
                CellFormat = new TableCellFormat()
                {
                    VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                }
            }
           );
            TableRow rowT2 = new TableRow(document);
            table.Rows.Add(rowT2);

            rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "TRƯỜNG ĐẠI HỌC XÂY DỰNG"))
            {
                CharacterFormat = new CharacterFormat()
                {
                    Bold = true,
                    Size = 12
                }
            }
            )
            {
                ParagraphFormat = new ParagraphFormat()
                {
                    Alignment = GemBox.Document.HorizontalAlignment.Center
                }
            })
            {
                CellFormat = new TableCellFormat()
                {
                    VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                }
            }
            );
            rowT2.Cells.Add(new TableCell(document, new Paragraph(document, new Run(document, string.Format("{0}", "Độc lập – Tự do – Hạnh phúc"))
            {
                CharacterFormat = new CharacterFormat()
                {
                    Bold = true,
                    Size = 12
                }
            }
           )
            {
                ParagraphFormat = new ParagraphFormat()
                {
                    Alignment = GemBox.Document.HorizontalAlignment.Center
                }
            })
            {
                CellFormat = new TableCellFormat()
                {
                    VerticalAlignment = GemBox.Document.VerticalAlignment.Center
                }
            }
           );
            var paragraph = new Paragraph(document);
      
            //var horizontalLine1 = new Shape(document, ShapeType.Line, GemBox.Document.Layout.Floating(
            //     new HorizontalPosition(1, GemBox.Document.LengthUnit.Centimeter, HorizontalPositionAnchor.Margin),
            //    new VerticalPosition(3.5, GemBox.Document.LengthUnit.Centimeter, VerticalPositionAnchor.InsideMargin),
            //    new Size(125, 0)));
            //horizontalLine1.Outline.Width = 1;
            //horizontalLine1.Outline.Fill.SetSolid(Color.Black);
            //paragraph.Inlines.Add(horizontalLine1);

            //var horizontalLine2 = new Shape(document, ShapeType.Line, GemBox.Document.Layout.Floating(
            //    new HorizontalPosition(8.78, GemBox.Document.LengthUnit.Centimeter, HorizontalPositionAnchor.Margin),
            //   new VerticalPosition(3.5, GemBox.Document.LengthUnit.Centimeter, VerticalPositionAnchor.InsideMargin),
            //   new Size(151, 0)));
            //horizontalLine2.Outline.Width = 1;
            //horizontalLine2.Outline.Fill.SetSolid(Color.Black);
            //paragraph.Inlines.Add(horizontalLine2);

            section.Blocks.Add(table);
            section.Blocks.Add(paragraph);
            #endregion
            document.Sections.Add(section);
            document.Save(String.Format("doc_text_{0}.docx", DateTime.Now.ToFileTimeUtc()));
            MessageBox.Show("Thành công !");
        }

        private void btnSVTTN_ReUpdateData_Click(object sender, EventArgs e)
        {
            string strSQL = string.Format(@"select * from [dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien] where dotkhoasat_id=4 ;");
            DataTable dt999 = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.GetConnection(), CommandType.Text, strSQL).Tables[0];
            string masv = "";
            string ex_masv = "";
            string add0pass = "";
            string checksum = "";
            string tensinhvien = "";
            strSQL = "";
            for (int i=0;i<dt999.Rows.Count;i++)
            {
                //ex_masv
                masv = dt999.Rows[i]["ex_masv"].ToString().Trim();
                ex_masv = masv;
                add0pass = "";
                if (masv.Length < 7)
                {
                    for (int j = 0; j < 7 - masv.Length; j++)
                    {
                        add0pass = add0pass + "0";
                    }
                }
                masv = string.Format("{0}{1}", add0pass, masv);
                tensinhvien= dt999.Rows[i]["tensinhvien"].ToString().Trim();
                checksum = Utils.RemoveUnicode(tensinhvien).Replace(" ", "").ToLower();
                strSQL += string.Format(@"UPDATE [dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien] SET 
                              [masv]='{0}', [psw]='{1}',[checksum]='{1}' 
                                where ID={2} ;", masv, checksum, dt999.Rows[i]["ID"].ToString());
            }
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(nuce.web.data.Nuce_Common.GetConnection(), CommandType.Text, strSQL);
            MessageBox.Show("Thành công!!!");
        }
    }
    public class a_thanh_data
    {
        //CBQL
        private int m_STT;
        public int stt { get { return m_STT; } set { m_STT = value; } }
        #region CBQL
        private int m_CBQL1;
        public int CBQL1 { get { return m_CBQL1; } set { m_CBQL1 = value; } }
        private int m_CBQL2;
        public int CBQL2 { get { return m_CBQL2; } set { m_CBQL2 = value; } }
        private int m_CBQL3;
        public int CBQL3 { get { return m_CBQL3; } set { m_CBQL3 = value; } }
        private int m_CBQL4;
        public int CBQL4 { get { return m_CBQL4; } set { m_CBQL4 = value; } }
        private int m_CBQL5;
        public int CBQL5 { get { return m_CBQL5; } set { m_CBQL5 = value; } }
        private int m_CBQL6;
        public int CBQL6 { get { return m_CBQL6; } set { m_CBQL6 = value; } }
        private int m_CBQL7;
        public int CBQL7 { get { return m_CBQL7; } set { m_CBQL7 = value; } }
        #endregion
        #region GV
        private int m_GV1;
        public int GV1 { get { return m_GV1; } set { m_GV1 = value; } }
        private int m_GV2;
        public int GV2 { get { return m_GV2; } set { m_GV2 = value; } }
        private int m_GV3;
        public int GV3 { get { return m_GV3; } set { m_GV3 = value; } }
        private int m_GV4;
        public int GV4 { get { return m_GV4; } set { m_GV4 = value; } }
        private int m_GV5;
        public int GV5 { get { return m_GV5; } set { m_GV5 = value; } }
        private int m_GV6;
        public int GV6 { get { return m_GV6; } set { m_GV6 = value; } }
        private int m_GV7;
        public int GV7 { get { return m_GV7; } set { m_GV7 = value; } }
        #endregion
        #region NV
        private int m_NV1;
        public int NV1 { get { return m_NV1; } set { m_NV1 = value; } }
        private int m_NV2;
        public int NV2 { get { return m_NV2; } set { m_NV2 = value; } }
        private int m_NV3;
        public int NV3 { get { return m_NV3; } set { m_NV3 = value; } }
        private int m_NV4;
        public int NV4 { get { return m_NV4; } set { m_NV4 = value; } }
        private int m_NV5;
        public int NV5 { get { return m_NV5; } set { m_NV5 = value; } }
        private int m_NV6;
        public int NV6 { get { return m_NV6; } set { m_NV6 = value; } }
        private int m_NV7;
        public int NV7 { get { return m_NV7; } set { m_NV7 = value; } }
        #endregion
        #region SDLD
        private int m_SDLD1;
        public int SDLD1 { get { return m_SDLD1; } set { m_SDLD1 = value; } }
        private int m_SDLD2;
        public int SDLD2 { get { return m_SDLD2; } set { m_SDLD2 = value; } }
        private int m_SDLD3;
        public int SDLD3 { get { return m_SDLD3; } set { m_SDLD3 = value; } }
        private int m_SDLD4;
        public int SDLD4 { get { return m_SDLD4; } set { m_SDLD4 = value; } }
        private int m_SDLD5;
        public int SDLD5 { get { return m_SDLD5; } set { m_SDLD5 = value; } }
        private int m_SDLD6;
        public int SDLD6 { get { return m_SDLD6; } set { m_SDLD6 = value; } }
        private int m_SDLD7;
        public int SDLD7 { get { return m_SDLD7; } set { m_SDLD7 = value; } }
        #endregion
        #region CUUSV
        private int m_CUUSV1;
        public int CUUSV1 { get { return m_CUUSV1; } set { m_CUUSV1 = value; } }
        private int m_CUUSV2;
        public int CUUSV2 { get { return m_CUUSV2; } set { m_CUUSV2 = value; } }
        private int m_CUUSV3;
        public int CUUSV3 { get { return m_CUUSV3; } set { m_CUUSV3 = value; } }
        private int m_CUUSV4;
        public int CUUSV4 { get { return m_CUUSV4; } set { m_CUUSV4 = value; } }
        private int m_CUUSV5;
        public int CUUSV5 { get { return m_CUUSV5; } set { m_CUUSV5 = value; } }
        private int m_CUUSV6;
        public int CUUSV6 { get { return m_CUUSV6; } set { m_CUUSV6 = value; } }
        private int m_CUUSV7;
        public int CUUSV7 { get { return m_CUUSV7; } set { m_CUUSV7 = value; } }
        #endregion
        #region SV
        private int m_SV1;
        public int SV1 { get { return m_SV1; } set { m_SV1 = value; } }
        private int m_SV2;
        public int SV2 { get { return m_SV2; } set { m_SV2 = value; } }
        private int m_SV3;
        public int SV3 { get { return m_SV3; } set { m_SV3 = value; } }
        private int m_SV4;
        public int SV4 { get { return m_SV4; } set { m_SV4 = value; } }
        private int m_SV5;
        public int SV5 { get { return m_SV5; } set { m_SV5 = value; } }
        private int m_SV6;
        public int SV6 { get { return m_SV6; } set { m_SV6 = value; } }
        private int m_SV7;
        public int SV7 { get { return m_SV7; } set { m_SV7 = value; } }
        #endregion
        #region TONG
        private int m_TONG1;
        public int TONG1 { get { return m_TONG1; } set { m_TONG1 = value; } }
        private int m_TONG2;
        public int TONG2 { get { return m_TONG2; } set { m_TONG2 = value; } }
        private int m_TONG3;
        public int TONG3 { get { return m_TONG3; } set { m_TONG3 = value; } }
        private int m_TONG4;
        public int TONG4 { get { return m_TONG4; } set { m_TONG4 = value; } }
        private int m_TONG5;
        public int TONG5 { get { return m_TONG5; } set { m_TONG5 = value; } }
        private int m_TONG6;
        public int TONG6 { get { return m_TONG6; } set { m_TONG6 = value; } }
        private int m_TONG7;
        public int TONG7 { get { return m_TONG7; } set { m_TONG7 = value; } }
        #endregion
    }
}
