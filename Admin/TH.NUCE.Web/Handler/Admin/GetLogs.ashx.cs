using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Services;
namespace TH.NUCE.Web
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetLogs : CoreHandlerEcommerce
    {
        public override void WriteData(HttpContext context)
        {
            string strData = "";
            if ((context.Request["CategoryId"] != null)  && (context.Request["Keyword"] != null) && (context.Request["StartDate"] != "") 
                && (context.Request["EndDate"] != "") && (context.Request["TypeId"] != "") && (context.Request["PortalId"] != "") && (context.Request["Account"] != ""))
            {
                string CategoryId = context.Request["CategoryId"];
                string Keyword = context.Request["Keyword"];
                string StartDate = context.Request["StartDate"];
                string EndDate = context.Request["EndDate"];
                string TypeId = context.Request["TypeId"];
                string PortalId = context.Request["PortalId"];
                string Account = context.Request["Account"];

                DateTime dtStartDate;
                DateTime dtEndDate;
                //StartDate
                CultureInfo provider = CultureInfo.InvariantCulture;
                try
                {
                    dtStartDate = DateTime.ParseExact(StartDate, "dd/MM/yyyy", provider);
                }
                catch
                {
                    dtStartDate = DateTime.Today.AddMonths(-12); ;
                }
                //EndDate
                try
                {
                    dtEndDate = DateTime.ParseExact(EndDate, "dd/MM/yyyy", provider);
                }
                catch
                {
                    dtEndDate = DateTime.Today.AddMonths(12);
                }

                int iTypeId = -1;
                int iPortalId = -1;
                if (int.TryParse(TypeId, out iTypeId)&& int.TryParse(PortalId, out iPortalId))
                {
                    strData = DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_LM_Getlogs", CategoryId,Keyword, dtStartDate, dtEndDate, iTypeId, iPortalId, Account).GetXml();
                    //strData = JsonConvert.SerializeObject(objDSDetail, Formatting.Indented);
                }
            }
            context.Response.ContentType = "text/xml";
            context.Response.Write(strData);
            context.Response.End();
        }
    }
}
