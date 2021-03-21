using GemBox.Document;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace TH.NUCE.Web
{
    public partial class ExportDoc : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            int iType = int.Parse(Request.QueryString["type"]);
            switch (iType)
            {
                case 1:
                    string strMaSV = Request.QueryString["masv"];
                    ExportSV(strMaSV);
                    break;
            }
            base.OnInit(e);
        }
        public void ExportSV(string MaSV)
        {
            DataTable dt = nuce.web.data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.SearchSV(MaSV);
            if (dt != null && dt.Rows.Count > 0)
            {
                string strTen = dt.Rows[0]["tensinhvien"].ToString();
                string strLop = dt.Rows[0]["malop"].ToString();
                string strMaKhoa = dt.Rows[0]["makhoa"].ToString();
                string strNganh = dt.Rows[0]["tennganh"].ToString();
                string strEmail = dt.Rows[0]["email"].ToString();
                int iTrangThaiBaiKhaoSat = int.Parse(dt.Rows[0]["StatusBKS"].ToString());
                string strTrangThaiBaiKhaoSat = "";
                int iTrangThaiCapNhatEmail = int.Parse(dt.Rows[0]["status"].ToString());
                string strTrangThaiCapNhatEmail = "";
                if (iTrangThaiBaiKhaoSat.Equals(4))
                {
                    strTrangThaiBaiKhaoSat = "Đã hoàn thành";
                }
                else
                {
                    strTrangThaiBaiKhaoSat = "Chưa hoàn thành";
                }
                if (iTrangThaiCapNhatEmail.Equals(3))
                {
                    strTrangThaiCapNhatEmail = "Đã hoàn thành";
                }
                else
                {
                    strTrangThaiCapNhatEmail = "Chưa hoàn thành";
                }

                //public void ExportToExcel(string fileName,string sheetName,DataTable dt)
                //{
                //    using (XLWorkbook wb = new XLWorkbook())
                //    {
                //        wb.Worksheets.Add(dt, sheetName);

                //        Response.Clear();
                //        Response.Buffer = true;
                //        Response.Charset = "";
                //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //        Response.AddHeader("content-disposition", string.Format( "attachment;filename={0}.xlsx", fileName));
                //        using (MemoryStream MyMemoryStream = new MemoryStream())
                //        {
                //            wb.SaveAs(MyMemoryStream);
                //            MyMemoryStream.WriteTo(Response.OutputStream);
                //            Response.Flush();
                //            Response.End();
                //        }
                //    }
                //}
                if (iTrangThaiBaiKhaoSat.Equals(4) && iTrangThaiCapNhatEmail.Equals(3))
                {
                    ComponentInfo.SetLicense("DTZX-HTZ5-B7Q6-2GA6");
                    DocumentModel document = new DocumentModel();
                    document.DefaultCharacterFormat.Size = 12;
                    document.DefaultCharacterFormat.FontName = "Times New Roman";
                    Section section = new Section(document);

                    Paragraph paragraph = new Paragraph(document);
                    section.Blocks.Add(paragraph);
                    Run run = new Run(document, "TRƯỜNG ĐẠI HỌC XÂY DỰNG");
                    Run run0 = new Run(document, "        CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM")
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    };
                    Run run1 = new Run(document, "        Phòng KT&ĐBCLGD                                     Độc lập - Tự do - Hạnh phúc")
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    };
                    Run run2 = new Run(document, "                                    PHIẾU XÁC NHẬN HOÀN THÀNH KHẢO SÁT")
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    };
                    Run run3 = new Run(document, "Phòng KT&ĐBCLGD xác nhận sinh viên:");
                    Run run4 = new Run(document, @"   - Họ và tên: ");
                    Run run5 = new Run(document, strTen)
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    };
                    Run run6 = new Run(document, @"   - Mã số sinh viên: ");
                    Run run7 = new Run(document, MaSV)
                    {
                        CharacterFormat = new CharacterFormat()
                        {
                            Bold = true
                        }
                    };
                    Run run8 = new Run(document, @"Đã hoàn thành khảo sát phản hồi của sinh viên trước khi tốt nghiệp đợt tháng 3 năm 2018 về chương trình đào tạo. ");
                    Run run9 = new Run(document, @"                                                                                             Hà Nội, ngày 08 tháng 03 năm 2018");
                    Run run10 = new Run(document, @"                                                                                                   T/M Phòng KT&ĐBCLGD");

                    paragraph.Inlines.Add(run);
                    paragraph.Inlines.Add(run0);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run1);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run2);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));

                    paragraph.Inlines.Add(run3);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run4);
                    paragraph.Inlines.Add(run5);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run6);
                    paragraph.Inlines.Add(run7);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run8);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run9);
                    paragraph.Inlines.Add(new SpecialCharacter(document, SpecialCharacterType.LineBreak));
                    paragraph.Inlines.Add(run10);

                    section.PageSetup.Orientation = Orientation.Landscape;
                    section.PageSetup.PaperType = PaperType.A5;
                    document.Sections.Add(section);

                    //document.Print("test.doc");
                    document.Save(this.Response, string.Format("{0}_{1}.docx",strMaKhoa,MaSV));
                }
            }
        }
    }
}