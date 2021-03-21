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
    public class RequestServices_GetDetail : CoreHandlerEcommerce
    {
        public override void WriteData(HttpContext context)
        {
            string strData = "";
            if ((context.Request["RequestServicesID"] != null)  && (context.Request["Status"] != ""))
            {
                string strRequestServicesID = context.Request["RequestServicesID"];
                int iRequestServicesID = -1;
                int iStatus = int.Parse(context.Request["Status"]);
                if (int.TryParse(strRequestServicesID, out iRequestServicesID))
                {
                    DataTable objDSDetail = RequestServices.GetDetail(iRequestServicesID, iStatus);
                    //strData = JsonConvert.SerializeObject(objDSDetail, Formatting.Indented);
                    strData = objDSDetail.DataSet.GetXml();
                }
            }
            context.Response.ContentType = "text/xml";
            context.Response.Write(strData);
            context.Response.End();
        }
    }
}
