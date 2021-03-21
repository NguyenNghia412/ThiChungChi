using System;
using System.Data;
namespace TH.NUCE.Web
{
    public partial class RequestServices_SendMail : CoreAdminAspx
    {
        public override void WriteData()
        {
            string strData = "FALSE";
            try
            {
                // Gui Mail
                string strSubject = Request.QueryString["Subject"];
                string strMessage = Request.QueryString["Message"];
                string strEmailTo = Request.QueryString["EmailTo"];
                DataSet dsConfig = new DataSet();
                dsConfig.ReadXml(this.MapPath("/Handler/Common/RequestServices/Config/Email.xml"));
                DataTable dtConfig = dsConfig.Tables[0];
                string strEmailSend = dtConfig.Rows[0]["Email"].ToString();
                string strSmpt = dtConfig.Rows[0]["Smpt"].ToString();
                int iPort = int.Parse(dtConfig.Rows[0]["Port"].ToString());
                int iIsSSL = int.Parse(dtConfig.Rows[0]["IsSSL"].ToString());
                bool isSSL = (iIsSSL.Equals(1)) ? true : false;
                string strUserNameSend = dtConfig.Rows[0]["UserName"].ToString();
                string strPasswordSend = dtConfig.Rows[0]["Password"].ToString();
                strData = MailProvider.Send_Email(strEmailSend, strEmailTo, strSubject, strMessage, strSmpt, iPort, isSSL, strUserNameSend, strPasswordSend);
            }
            catch (Exception ex)
            {
                strData = ex.ToString();
            }
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write(strData);
        }
    }
}
