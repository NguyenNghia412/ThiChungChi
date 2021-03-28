using nuce.web.commons;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
namespace nuce.web.Handler.nuce.ad.thichungchi
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    /// <summary>
    /// Summary description for ad_tcc_insertphongthi
    /// </summary>
    public class ad_tcc_insertphongthi : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string maPhong = context.Request.QueryString["Ma"];
            string tenPhong = context.Request.QueryString["Ten"];
            string soNguoi = context.Request.QueryString["SoNguoiToiDa"];
            context.Response.ContentType = "text/plain";
            string sql = $@"INSERT INTO [dbo].[NuceThi_PhongThi]([MaPhong],[TenPhong],[SoNguoiToiDa],[status])
                            values('{maPhong}', N'{tenPhong}', {soNguoi}, 1)";
            int dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
            context.Response.Write(dt.ToString());
        }
    }
}