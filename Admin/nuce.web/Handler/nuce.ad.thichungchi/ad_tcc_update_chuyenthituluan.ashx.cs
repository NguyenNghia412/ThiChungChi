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
    /// <summary>
    /// Summary description for ad_tcc_update_chuyenthituluan
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_update_chuyenthituluan : CoreHandlerCommonAdminThiChungChi
    {

        public override void WriteData(HttpContext context)
        {
            string strID = context.Request["ID"].ToString();
            context.Response.ContentType = "text/plain";
            string sql = string.Format($@"
                          declare @thoigianthi int = 0;
                          declare @now datetime = getdate();
                          select @thoigianthi = b.thoigianthi * 60
                          from nucethi_kithi a
                          left join nucethi_bode b on a.bodeid = b.BoDeID
                          where [KiThiID] = {strID};
                            UPDATE [dbo].[NuceThi_KiThi_LopHoc_SinhVien]
                            SET [NgayGioBatDau] = @now
                                ,[NgayGioNopBai] = dateadd(ss, @thoigianthi, @now)
                                ,[TongThoiGianThi] = @thoigianthi
                                ,[TongThoiGianConLai] = @thoigianthi
                            WHERE [KiThi_LopHocID]={strID};
                            UPDATE [dbo].[NuceThi_KiThi]
                            SET [Status] = 2
                            WHERE [KiThiID]={strID};");
            int iReturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
            context.Response.Write(iReturn.ToString());
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }
}