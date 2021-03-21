using nuce.web.commons;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    public class ad_tcc_delete_phong_ca : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string idPhongCa = context.Request.QueryString["id"];
            string msg = "";
            string sql = "";

            try
            {  
                sql = $@"select pc.id
                            from [NuceThi_PhongThi_CaThi] pc 
                            inner join [NuceThi_KiThi_LopHoc_SinhVien] kls on pc.id = kls.PhongThi_CaThi_ID
                            where pc.id = {idPhongCa}";
                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    msg = "Không thể xoá vì đã có thí sinh được đăng ký.";
                } else
                {
                    sql = $@"delete from [NuceThi_PhongThi_CaThi] where id = {idPhongCa}";
                    int iReturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
                    msg = iReturn.ToString();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }
}