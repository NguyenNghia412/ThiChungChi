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
using ClosedXML.Excel;

namespace TH.NUCE.Web
{
    public partial class ExportExcel : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            int iType = int.Parse(Request.QueryString["type"]);
            switch(iType)
            {
                case 1:
                    ProcessDanhSachKhachHangDangKiEmail();
                    break;
            }
            base.OnInit(e);
        }
        public void ProcessDanhSachKhachHangDangKiEmail()
        {
            string constr = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [Status],[Subject],[SenderEmail],[Message] ,[Comment],CreatedOnDate FROM [dbo].[dnn_THCommon_RequestServices] where CategoryId=343 and status<>4 order by CreatedOnDate desc"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ExportToExcel(string.Format("DanhSachKhachHangDangKiEmail_{0}", DateTime.Now.ToFileTimeUtc()), "DanhSachKhachHangDangKiEmail", dt);
                        }
                    }
                }
            }
        }
        public void ExportToExcel(string fileName,string sheetName,DataTable dt)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, sheetName);

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", string.Format( "attachment;filename={0}.xlsx", fileName));
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        public void ExportToExcel(ref string html, string fileName)
        {
            //html = html.Replace("&gt;", ">");
            //html = html.Replace("&lt;", "<");
            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + fileName + "_" + DateTime.Now.ToString("M_dd_yyyy_H_M_s") + ".xls");
            //HttpContext.Current.Response.ContentType = "application/xls";
            //HttpContext.Current.Response.Write(html);
            //HttpContext.Current.Response.End();



            string constr = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dnn_Users"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Customers");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}