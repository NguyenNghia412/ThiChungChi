using nuce.web.data;
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
    public class ad_tcc_updatekithi : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string strID = context.Request["ID"].ToString();
            string strTen = context.Request["Ten"].ToString();
            string strMoTa = context.Request["MoTa"].ToString();
            string strBoDe = context.Request["BoDe"].ToString();
            string strPhongThi = context.Request["PhongThi"].ToString();
            context.Response.ContentType = "text/plain";
            string sql = string.Format(@"declare @status int;
                                            declare @groupkey varchar(250);
                                         select @status=[Status], @groupkey=[GroupKiThiKey] from [NuceThi_KiThi] where KiThiID={4};
                                         if(@status>1)
                                            Begin
                                                    UPDATE [dbo].[NuceThi_KiThi]
                                                       SET 
                                                          [MoTa] =N'{2}'
                                                          ,[PhongThi]='{3}'
                                                     WHERE KiThiID={4};
                                                    update [dbo].[NuceThi_KiThi]
                                                       set [Ten] =N'{1}'
                                                        where GroupKiThiKey = @groupkey
                                            End
                                            else
                                            Begin
                                                     UPDATE [dbo].[NuceThi_KiThi]
                                                       SET [BoDeID] = {0}
                                                          ,[MoTa] =N'{2}'
                                                          ,[PhongThi]='{3}'
                                                     WHERE KiThiID={4};
                                                    update [dbo].[NuceThi_KiThi]
                                                       set [Ten] =N'{1}'
                                                        where GroupKiThiKey = @groupkey
                                            End
", strBoDe, strTen,strMoTa,strPhongThi,strID);
            int iReturn = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.Text, sql);
            context.Response.Write(iReturn.ToString());
            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            HttpContext.Current.ApplicationInstance.CompleteRequest(); // Causes ASP.NET to bypass all events and filtering i
        }
    }
}
