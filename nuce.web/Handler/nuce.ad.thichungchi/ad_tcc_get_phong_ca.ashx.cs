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
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_get_phong_ca : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string idKiThi = context.Request.QueryString["idKiThi"];
            context.Response.ContentType = "text/plain";
            string sql = $@"SELECT pc.*, convert(varchar, pc.Ngaythi, 103) as NgayThiFormatted, p.TenPhong, c.TenCa
                          from [NuceThi_PhongThi_CaThi] pc
                          left join [Nuce_thi_chung_chi].[dbo].[NuceThi_PhongThi] p on pc.phongthiid = p.id
                          left join [Nuce_thi_chung_chi].[dbo].[NuceThi_CaThi] c on pc.cathiid = c.id
                          where pc.kithiid = {idKiThi}";
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];
            context.Response.Write(DataTableToJSONWithJavaScriptSerializer(dt));
        }
    }
}
