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
    public class RequestServices_UpdateStatus : CoreAdminAspx
    {
        public override void WriteData(HttpContext context)
        {
            string strData = "-1";
            if ((context.Request["RequestServicesID"] != null)  && (context.Request["Status"] != ""))
            {
                string strRequestServicesID = context.Request["RequestServicesID"];
                int iRequestServicesID = -1;
                int iStatus = int.Parse(context.Request["Status"]);
                if (int.TryParse(strRequestServicesID, out iRequestServicesID))
                {
                    RequestServices.UpdateStatus(iRequestServicesID, iStatus);
                    //strData = "1";
                }
            }
           
        }
    }
}
