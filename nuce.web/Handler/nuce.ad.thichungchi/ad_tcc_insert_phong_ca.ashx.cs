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
    public class ad_tcc_insert_phong_ca : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string idKiThi = context.Request.QueryString["idKiThi"];
            string idPhong = context.Request.QueryString["phong"];
            string idCa = context.Request.QueryString["ca"];
            string ngayThi = context.Request.QueryString["ngay"];

            string msg = "";

            try
            {
                var d = DateTime.ParseExact(ngayThi, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ngayThi = d.ToString("yyyy-MM-dd");
                string now = DateTime.Now.ToString();

                string sql = $@"insert into [dbo].[NuceThi_PhongThi_Cathi]([PhongThiID], [CaThiID], [NgayThi], [EntryTime], [UpdatedTime], [KithiId]) values 
                            ({idPhong}, {idCa}, '{ngayThi}', '{now}', '{now}', {idKiThi});
                            SELECT SCOPE_IDENTITY();";
                int ireturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
                msg = ireturn.ToString();
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