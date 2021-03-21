using Newtonsoft.Json;
using nuce.web.commons;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace nuce.web.Handler.nuce.ad.thichungchi
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_save_import_excel_thisinh : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string body = new StreamReader(context.Request.InputStream).ReadToEnd();
            var thiSinhList = JsonConvert.DeserializeObject<List<ThiSinhImportExcelModel>>(body);
            string sql = "declare @s int = 0;";
            Random random = new Random();
            foreach (var thiSinh in thiSinhList)
            {
                string matkhau = Utils.RandomString(6, true, random);
                sql += string.Format($@"
                set @s = (select id from [Nuce_ThiChungChi_DanhMuc] where ma = '{thiSinh.MaDanhMuc}');
                INSERT INTO [dbo].[NUCE_ThiChungChi_NguoiThi]
               ([Ma],[MatKhau],[Ho],[Ten],[NgaySinh],[NoiSinh],[GioiTinh],[CMT],[NgayCap]
               ,[NoiCap],[Mobile],[Email],[DiaChi],[Anh],[Type],[Status],[UpdatedDate],[DanhMucID])
                values('{thiSinh.MaThiSinh}', '{matkhau}', N'{thiSinh.Ho}', N'{thiSinh.Ten}', '{thiSinh.Ngay_Sinh}', N'{thiSinh.Noi_Sinh}',
                        '{thiSinh.GioiTinh}', '{thiSinh.CMT}', '{thiSinh.NgayCap}', N'{thiSinh.Noi_Cap}', '{thiSinh.DienThoai}',
                        '{thiSinh.Email}', '{thiSinh.DiaChi}', '', 1, 1, '{DateTime.Now}', @s)");
            }
            int iReturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
            context.Response.Write(iReturn.ToString());
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }

    public class ThiSinhImportExcelModel
    {
        public string MaThiSinh { get; set; }
        public string MaDanhMuc { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Ngay_Sinh { get; set; }
        public string Noi_Sinh { get; set; }
        public string GioiTinh { get; set; }
        public string CMT { get; set; }
        public string NgayCap { get; set; }
        public string Noi_Cap { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }

}