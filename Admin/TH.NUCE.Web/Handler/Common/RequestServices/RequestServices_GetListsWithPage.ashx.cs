using Newtonsoft.Json;
using System.Data;
using System.Web;
using System.Web.Services;
namespace TH.NUCE.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class RequestServices_GetListsWithPage : CoreHandlerEcommerce
    {
        public override void WriteData(HttpContext context)
        {
            string strData = "";
            if ((context.Request["Categories"] != null) && (context.Request["PortalId"] != null) && (context.Request["Status"] != ""))
            {
                string strCategories = context.Request["Categories"];
                int iFirstRow = 0;
                int iLastRow = 36;
                try
                {
                    iFirstRow = int.Parse(context.Request["FirstRow"]);
                    iLastRow = int.Parse(context.Request["LastRow"]);
                }
                catch
                {
                }
                string strPortalId = context.Request["PortalId"];
                int iPortalId = -1;
                int iStatus = int.Parse(context.Request["Status"]);
                if (int.TryParse(strPortalId, out iPortalId))
                {
                    DataSet objDSDetail = RequestServices.GetListsWithPage(strCategories, iPortalId, iStatus,
                        1, iFirstRow, iLastRow);
                    //strData = JsonConvert.SerializeObject(objDSDetail, Formatting.Indented);
                    strData = objDSDetail.GetXml();
                }
            }
            context.Response.ContentType = "text/xml";
            context.Response.Write(strData);
            context.Response.End();
        }
    }
}
