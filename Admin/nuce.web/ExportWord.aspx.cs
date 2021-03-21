using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using TableCell = DocumentFormat.OpenXml.Wordprocessing.TableCell;
using TableRow = DocumentFormat.OpenXml.Wordprocessing.TableRow;

namespace nuce.web
{
    public partial class ExportWord : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            int iType = int.Parse(Request.QueryString["type"]);
            switch (iType)
            {
                case 1:
                    ProcessBangDiem();
                    break;
            }
            base.OnInit(e);
        }

        private void ProcessBangDiem()
        {
            string idPhongCaNgay = Request["IDPhongCaNgay"]?.ToString();
            string idKiThi = Request["IDKiThi"]?.ToString();
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

            sql = $@"SELECT nt.ma, nt.ho + ' '+ nt.ten as hoten, convert(varchar, nt.ngaysinh, 103) as ngaysinh, 
		                    nt.cmt, nt.noisinh, nt.gioitinh,
		                    kls.made, cast(kls.diem as numeric(3,2)) as diem
                    FROM [Nuce_thi_chung_chi].[dbo].[NuceThi_KiThi_LopHoc_SinhVien] kls
                    left join Nuce_thichungchi_nguoithi nt on kls.sinhvienid = nt.id
                    where kls.phongthi_cathi_id = {idPhongCaNgay} and kls.[KiThi_LopHocID] = {idKiThi}";
            dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];

            string path = HttpContext.Current.Server.MapPath("~/NuceDataUpload/Templates/Bang-diem-vien-tin-hoc.docx");
            string destinationPath = HttpContext.Current.Server.MapPath($"~/NuceDataUpload/Templates/Bang-diem-vien-tin-hoc-{DateTime.Now.ToFileTime()}.docx");

            byte[] templateBytes = File.ReadAllBytes(path);
            using (MemoryStream templateStream = new MemoryStream())
            {
                templateStream.Write(templateBytes, 0, templateBytes.Length);
                using (WordprocessingDocument doc = WordprocessingDocument.Open(templateStream, true))
                {
                    doc.ChangeDocumentType(WordprocessingDocumentType.Document);
                    var mainPart = doc.MainDocumentPart;
                    #region handle text
                    var textList = mainPart.Document.Descendants<Text>().ToList();
                    foreach (var text in textList)
                    {
                        replaceTextTemplate(text, "<ngay_thi>", NgayThi);
                        replaceTextTemplate(text, "<phong_thi>", PhongThi);
                        replaceTextTemplate(text, "<ca_thi>", CaThi);
                    }
                    var tableList = mainPart.Document.Descendants<Table>()
                                            .Where(tbl => tbl.GetFirstChild<TableRow>().Descendants<TableCell>().Count() == 8)
                                            .ToList();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        var row = dt.Rows[i];
                        string ThiSinhMa = row["ma"]?.ToString();
                        string ThiSinhNgaySinh = row["ngaysinh"]?.ToString();
                        string ThiSinhHoTen = row["hoten"]?.ToString();
                        string ThiSinhCmt = row["cmt"]?.ToString();
                        string ThiSinhNoiSinh = row["noisinh"]?.ToString();
                        string ThiSinhGioiTinh = row["gioitinh"]?.ToString();
                        string ThiSinhMaDe = row["made"]?.ToString();
                        string ThiSinhDiem = row["diem"]?.ToString();
                        if (ThiSinhGioiTinh == "Nu")
                        {
                            ThiSinhGioiTinh = "Nữ";
                        }

                        tableList[0].Append(new TableRow(new TableCell(new Paragraph(new Run(new Text($"{i + 1}")))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhMa)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhHoTen)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhNgaySinh)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhMaDe)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhDiem)))),
                            new TableCell(new Paragraph(new Run(new Text("")))),
                            new TableCell(new Paragraph(new Run(new Text(""))))
                        ));

                        tableList[1].Append(new TableRow(new TableCell(new Paragraph(new Run(new Text($"{i + 1}")))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhMa)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhHoTen)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhNgaySinh)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhGioiTinh)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhNoiSinh)))),
                            new TableCell(new Paragraph(new Run(new Text(ThiSinhCmt)))),
                            new TableCell(new Paragraph(new Run(new Text(""))))
                        ));
                    }

                    #endregion
                    mainPart.Document.Save();
                }
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("content-disposition", $"attachment; filename=Bang-diem-{DateTime.Now.ToFileTime()}.docx");
                Response.BinaryWrite(templateStream.ToArray());
            }
            Response.End();
        }

        private void replaceTextTemplate(Text model, string oldValue, string newValue)
        {
            if (oldValue == null)
            {
                oldValue = "";
            }
            if (newValue == null)
            {
                newValue = "";
            }
            if (!model.Text.Contains(oldValue)) return;
            if (!newValue.Contains('\r'))
            {
                model.Text = model.Text.Replace(oldValue, newValue);
            }
            else
            {
                var arr = newValue.Split('\r');
                for (int i = 0; i < arr.Count(); i++)
                {
                    string replaceText = arr[i];
                    if (i == 0)
                    {
                        model.Text = model.Text.Replace(oldValue, replaceText);
                        continue;
                    }
                    model.Parent.Append(new Break());
                    model.Parent.Append(new Text(replaceText));
                }
            }
        }
    }
}