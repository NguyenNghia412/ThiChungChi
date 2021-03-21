using Newtonsoft.Json;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Services;
namespace nuce.web.commons
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_insertkithi : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string body = new StreamReader(context.Request.InputStream).ReadToEnd();
            var listBoDeIds = JsonConvert.DeserializeObject<List<string>>(body);

            string strTen = context.Request["Ten"].ToString();
            string strMoTa = context.Request["MoTa"].ToString();
            string strPhongThi = context.Request["PhongThi"].ToString();
            context.Response.ContentType = "text/plain";
            string sql = "";
            string guid = Guid.NewGuid().ToString();

            foreach (var bodeId in listBoDeIds)
            {
                sql += string.Format(@"INSERT INTO [dbo].[NuceThi_KiThi]
               ([MonHocID],[BlockHocID],[BoDeID],[Ten],[MoTa],[InsertedDate],[UpdatedDate],[Type],[Status],[PhongThi],[GroupKiThiKey])
                VALUES
               (-1,-1,{0},N'{1}',N'{2}',getDate(),getDate(),1,1,'{3}', '{4}');", bodeId, strTen, strMoTa, strPhongThi, guid);
            }
            string msg = "";
            try
            {
                int iReturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
                msg = "1";
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
            }
            context.Response.Write(msg);
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }
}
