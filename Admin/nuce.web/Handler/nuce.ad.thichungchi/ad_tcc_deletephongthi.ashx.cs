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
    /// Summary description for ad_tcc_deletephongthi
    /// </summary>
    public class ad_tcc_deletephongthi : CoreHandlerCommonAdminThiChungChi
    {

        public override void WriteData(HttpContext context)
        {
            string id = context.Request.QueryString["ID"];
            context.Response.ContentType = "text/plain";
            string sql = $"update [NuceThi_PhongThi] set status = 4 where id = {id}";
            int dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
            context.Response.Write(dt.ToString());
        }
    }
}