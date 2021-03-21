using System.Web;
namespace TH.NUCE.Web
{
    public class CoreHandlerEcommerce : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            WriteData(context);
        }

        public virtual void WriteData(HttpContext context)
        {
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}