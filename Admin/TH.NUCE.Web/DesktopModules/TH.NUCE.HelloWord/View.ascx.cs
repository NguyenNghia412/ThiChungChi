using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Entities.Modules;
using System.Threading;
using Microsoft.Web.Administration;
namespace TH.NUCE.Web.HelloWord
{
    public partial class View : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string strName="thang" + "hoang"+this.PortalAlias.ToString();
                //txtName.Text = Request.ServerVariables["APP_POOL_ID"];
                //try
                //{
                //    // Create An instance of the Process class responsible for starting the newly process.
                //    System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                //    // Set the filename name of the file you want to execute/open
                //    process1.StartInfo.FileName = (@"c:\Windows\System32\inetsrv\appcmd recycle apppool " + appPool);
                //    process1.StartInfo.Arguments = "args";

                //    // Start the process without blocking the current thread
                //    process1.Start();
                //    // you may wait until finish that executable
                //    process1.WaitForExit();
                //    //or you can wait for a certain time interval 
                //    Thread.Sleep(20000);//Assume within 20 seconds it will finish processing. 
                //    process1.Close();
                //}
                //catch (Exception ex)
                //{
                //} 
            }
        }
        protected void ResetCache_Click(object sender, EventArgs e)
        {
            try
            {
                ServerManager serverManager = new ServerManager();
                ApplicationPoolCollection appPools = serverManager.ApplicationPools;
                foreach (ApplicationPool ap in appPools)
                {
                    ap.Recycle();
                }
                divAnnounce.InnerText = "Success";
            }
            catch (Exception ex)
            {
                divAnnounce.InnerText = ex.ToString();
            }
        }
    }
}