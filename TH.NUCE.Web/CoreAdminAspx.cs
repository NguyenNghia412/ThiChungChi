using System;
namespace TH.NUCE.Web
{
    public class CoreAdminAspx : System.Web.UI.Page
    {
        protected DotNetNuke.Entities.Modules.ModuleInfo objModuleInfo;
        protected DotNetNuke.Entities.Users.UserInfo objUserInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region ViewPermission
            // Truyen vao tabid va mid de he thong kiem tra
            // Neu User dang truy cap co quyen thi he thong tra ra du lieu
            // Neu user khong co quyen he thong se thong bao not define
            try
            {

                DotNetNuke.Entities.Portals.PortalSettings portalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings();
                if (((Request.QueryString["tabid"] == null && Request.Form["tabid"] == null) || (Request.QueryString["mid"] == null && Request.Form["mid"] == null)) || !(Request.IsAuthenticated))
                {
                    WriteDataError("NotAuthenticated");
                    return;
                }
                // get TabId
                int TabId = -1;
                if ((Request.QueryString["tabid"] != null))
                {
                    TabId = Int32.Parse(Request.QueryString["tabid"]);
                }
                else if ((Request.Form["tabid"] != null))
                {
                    TabId = Int32.Parse(Request.Form["tabid"]);
                }

                // get ModuleId
                int ModuleId = -1;
                if ((Request.QueryString["mid"] != null))
                {
                    ModuleId = Int32.Parse(Request.QueryString["mid"]);
                }
                else if ((Request.Form["mid"] != null))
                {
                    ModuleId = Int32.Parse(Request.Form["mid"]);
                }
                objUserInfo = DotNetNuke.Entities.Users.UserController.GetCurrentUserInfo();
                DotNetNuke.Entities.Modules.ModuleController mc = new DotNetNuke.Entities.Modules.ModuleController();
                System.Collections.Hashtable settings = mc.GetModuleSettings(ModuleId);
                objModuleInfo = new DotNetNuke.Entities.Modules.ModuleController().GetModule(ModuleId, TabId);

                if (DotNetNuke.Security.Permissions.ModulePermissionController.CanViewModule(objModuleInfo))
                {
                    try
                    {
                        WriteData();
                    }
                    catch (Exception ex)
                    {
                        WriteDataError(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteDataError(ex.Message);
            }
            #endregion
            base.OnInit(e);
        }
        public virtual void WriteData()
        {
        }
        public virtual void WriteDataError(string strData)
        {
            Response.Clear();
            Response.Write(strData);
        }
    }
}