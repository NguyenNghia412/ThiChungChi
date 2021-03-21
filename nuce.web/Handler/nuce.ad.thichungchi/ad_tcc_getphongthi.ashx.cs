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
    /// Summary description for ad_tcc_getcathi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_getphongthi : CoreHandlerCommonAdminThiChungChi
    {

        public override void WriteData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sql = "select * from [NuceThi_PhongThi]";
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];
            context.Response.Write(DataTableToJSONWithJavaScriptSerializer(dt));
        }

    }
}