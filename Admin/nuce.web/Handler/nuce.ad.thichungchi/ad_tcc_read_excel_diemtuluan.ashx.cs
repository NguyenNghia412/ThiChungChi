using ClosedXML.Excel;
using Newtonsoft.Json;
using nuce.web.commons;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace nuce.web.Handler.nuce.ad.thichungchi
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_read_excel_diemtuluan : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            int status = 0;
            string msg = "Thành công";
            try
            {
                var files = context.Request.Files;
                var file = files[0];
                string strMoRongFile = System.IO.Path.GetExtension(file.FileName);
                string filename = file.FileName;
                string strTenCu = filename;
                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Second, 0, 0, Utils.RemoveUnicode(filename).Replace(" ", "_"));

                string path = HttpContext.Current.Server.MapPath("~/NuceDataUpload/cauhoi/" + strTenMoi);
                string strLinkFile = path;

                file.SaveAs(strLinkFile);
                string CryptKey = ConfigurationManager.AppSettings["CryptKey"];
                //Open the Excel file using ClosedXML.
                string sql = "";
                using (XLWorkbook workBook = new XLWorkbook(strLinkFile))
                {
                    string strHtml = "";
                    IXLWorksheet workSheet = workBook.Worksheet(1);
                    sql = strHtml;

                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {
                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            firstRow = false;
                        }
                        else
                        {
                            string Diem = row.Cell(9).Value.ToString();
                            string EncryptedCode = row.Cell(1).Value.ToString();
                            string MaBaiLam = StringCipher.Decrypt(EncryptedCode, CryptKey);
                            sql += $@"update [NuceThi_KiThi_LopHoc_SinhVien]
                                        set [Diem] = {Diem}
                                        where [KiThi_LopHoc_SinhVienID] = {MaBaiLam};";
                        }
                    }
                }
                int result = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
                if (result < 1)
                {
                    status = 2;
                    msg = "Có lỗi khi cập nhật điểm";
                }
                string json = JsonConvert.SerializeObject(new { status, msg });
                context.Response.Write(json);
                HttpContext.Current.Response.Flush();

                File.Delete(strLinkFile);
            }
            catch (Exception ex)
            {
                string json = JsonConvert.SerializeObject(new { status = 1, msg = ex.Message });
                context.Response.Write(json);
            }
        }
    }
}