﻿using nuce.web.data;
using System.Data;
using System.Web;
using System.Web.Services;
namespace nuce.web.commons
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_getkythi : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
           // DataSet ds = data.dnn_NuceCommon_Khoa.getName(-1).DataSet;
            context.Response.ContentType = "text/plain";
            string search = context.Request["search"].ToString();
            string sql = string.Format(@"SELECT top 30 a.*,b.Ten as TenBoDe, b.LoaiDe, b.TuLuan_ThoiGianNopTruoc  FROM [dbo].[NuceThi_KiThi] a inner join [dbo].[NuceThi_BoDe] b on a.BoDeID = b.[BoDeID] where a.Status <> 4 order by UpdatedDate desc");
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];
            context.Response.Write(DataTableToJSONWithJavaScriptSerializer(dt));
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }
}
