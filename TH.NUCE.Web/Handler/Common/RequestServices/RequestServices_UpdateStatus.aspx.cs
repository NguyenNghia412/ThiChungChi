using System;
namespace TH.NUCE.Web
{
    public partial class RequestServices_UpdateStatus : CoreAdminAspx
    {
        public override void WriteData()
        {
            string strData = "-1";
            if ((Request.QueryString["RequestServicesID"] != null) && (Request.QueryString["Status"] != ""))
            {
                string strRequestServicesID = Request.QueryString["RequestServicesID"];
                int iRequestServicesID = -1;
                int iStatus = int.Parse(Request.QueryString["Status"]);
                if (int.TryParse(strRequestServicesID, out iRequestServicesID))
                {
                    RequestServices.UpdateStatus(iRequestServicesID, iStatus);
                    strData = "1";
                }
            }
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write(strData);
        }
    }
}
