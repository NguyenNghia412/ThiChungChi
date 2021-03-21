using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
namespace TH.NUCE.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class SearchProducts : CoreHandlerEcommerce
    {

        public override void WriteData(HttpContext context)
        {
            string strData = "";
            if ((context.Request["Code"] != null)&&(context.Request["Text"] != null) && (context.Request["PortalId"] != null) && (context.Request["PortalId"] != ""))
            {
                string strText = context.Request["Text"];
                string strCode= context.Request["Code"];

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
                if (int.TryParse(strPortalId, out iPortalId))
                {
                    DataSet objDSDetail = ProductProvider.PD_GetProducts_SearchProducts1(strCode,true, strText, strText, strText, "", iPortalId, iFirstRow, iLastRow);
                    strData = objDSDetail.GetXml();
                }
            }

            context.Response.ContentType = "text/xml";
            context.Response.Write(strData);
            context.Response.End();
        }
    }
}
