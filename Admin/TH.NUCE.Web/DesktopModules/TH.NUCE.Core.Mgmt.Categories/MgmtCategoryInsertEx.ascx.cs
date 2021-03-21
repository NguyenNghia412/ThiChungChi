using System;
using System.Data;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

using DotNetNuke.Entities.Modules;
using System.IO;

namespace TH.NUCE.Web
{
    public partial class MgmtCategoryInsertEx : CoreModule, IActionable
    {
        static private int m_intCategoryId = -1;
        static private int m_typeId;
        static private int m_ReturnTabId;
        static private string m_typeInclude;
        static private string m_typeReturn;
        static private bool m_IsAllType;

        //Show Choices

        static private bool m_isShowDip1;
        static private bool m_isShowDip2;
        static private bool m_isShowDip3;
        static private bool m_isShowDip4;
        static private bool m_isShowDip5;

        //Alt Text
        static private string m_altSourceDip1;
        static private string m_altSourceDip2;
        static private string m_altSourceDip3;
        static private string m_altSourceDip4;
        static private string m_altSourceDip5;


        #region Initialization
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);

            m_intCategoryId = DataProcessingProvider.GetProcessedInt(Request.QueryString["CategoryId"]);
            int i;

            if (Settings[MgmtCategoryListSettings.TYPE_ID_KEY] == null || !int.TryParse(Settings[MgmtCategoryListSettings.TYPE_ID_KEY].ToString(), out i))
                m_typeId = MgmtCategoryListSettings.TYPE_ID;
            else
                m_typeId = int.Parse(Settings[MgmtCategoryListSettings.TYPE_ID_KEY].ToString());

            if (Request.QueryString["Type"] != null)
            {
                try
                {
                    m_typeId = int.Parse(Request.QueryString["Type"]);
                }
                catch
                { }
            }
            if (m_typeId == -1)
                m_IsAllType = true;
            else m_IsAllType = false;


            if (Settings[MgmtCategoryListSettings.TYPE_INCLUDE_KEY] == null)
                m_typeInclude = MgmtCategoryListSettings.TYPE_INCLUDE;
            else
                m_typeInclude = Settings[MgmtCategoryListSettings.TYPE_INCLUDE_KEY].ToString();

            if (Settings[MgmtCategoryListSettings.TYPE_RETURN_KEY] == null)
                m_typeReturn = MgmtCategoryListSettings.TYPE_RETURN;
            else
                m_typeReturn = Settings[MgmtCategoryListSettings.TYPE_RETURN_KEY].ToString();

            ////Load Show Choices
            //m_isShowDip1 = LoadBaseTrueSetting(UserMgmtCategorySettings.IS_SHOW_DIP1);
            //m_isShowDip2 = LoadBaseTrueSetting(UserMgmtCategorySettings.IS_SHOW_DIP2);
            //m_isShowDip3 = LoadBaseTrueSetting(UserMgmtCategorySettings.IS_SHOW_DIP3);
            //m_isShowDip4 = LoadBaseTrueSetting(UserMgmtCategorySettings.IS_SHOW_DIP4);
            //m_isShowDip5 = LoadBaseTrueSetting(UserMgmtCategorySettings.IS_SHOW_DIP5);

            ////Load Alt Text
            //m_altSourceDip1 = LoadStringSetting(UserMgmtCategorySettings.ALT_SOURCE_DIP1, UserMgmtCategorySettings.ALT_SOURCE_DIP1);
            //m_altSourceDip2 = LoadStringSetting(UserMgmtCategorySettings.ALT_SOURCE_DIP2, UserMgmtCategorySettings.ALT_SOURCE_DIP2);
            //m_altSourceDip3 = LoadStringSetting(UserMgmtCategorySettings.ALT_SOURCE_DIP3, UserMgmtCategorySettings.ALT_SOURCE_DIP3);
            //m_altSourceDip4 = LoadStringSetting(UserMgmtCategorySettings.ALT_SOURCE_DIP4, UserMgmtCategorySettings.ALT_SOURCE_DIP4);
            //m_altSourceDip5 = LoadStringSetting(UserMgmtCategorySettings.ALT_SOURCE_DIP5, UserMgmtCategorySettings.ALT_SOURCE_DIP5);
            /*
            if (!m_isShowDip1) { lblDip1.Visible = false; chbDip1.Visible = false; }
            if (!m_isShowDip2) { lblDip2.Visible = false; chbDip2.Visible = false; }
            if (!m_isShowDip3) { lblDip3.Visible = false; chbDip3.Visible = false; }
            if (!m_isShowDip4) { lblDip4.Visible = false; chbDip4.Visible = false; }
            if (!m_isShowDip5) { lblDip5.Visible = false; chbDip5.Visible = false; }
            */
            DotNetNuke.UI.Skins.Skin objParentSkin = DotNetNuke.UI.Skins.Skin.GetParentSkin(this);
            if (objParentSkin != null)
            {
                objParentSkin.RegisterModuleActionEvent(this.ModuleId, new ActionEventHandler(ModuleAction_Click));
            }
        }
        private void InitializeComponent()
        {

            this.Load += new System.EventHandler(this.Page_Load);
            // DotNetNuke.Services.Localization.LocaleController.Instance.GetCurrentLocale(this.PortalId).

        }

        #endregion

        #region Page Load & Data Binding

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_ReturnTabId = this.TabId;
                if (Request.QueryString["PreTab"] != null)
                {
                    try
                    {
                        m_ReturnTabId = int.Parse(Request.QueryString["PreTab"]);
                    }
                    catch
                    { }
                }

                #region Apply Core Type

                if (m_typeId == -1)
                {
                    CboType();
                    BindCboFolder();
                }
                else
                {
                    BindCboExcludedCategories();
                    cboType.Visible = false;
                    CoreType objCoreType = GetCoreType(m_typeId);

                    if (!objCoreType.IsUseXSL)
                    {
                        this.lblIsDefaultXSL.Visible = false;
                        this.chkIsDefaultXSL.Visible = false;
                        this.urlXslFile.Visible = false;
                    }
                    if (!objCoreType.IsUseToolTip)
                    {
                        this.lblToolTip.Visible = false;
                        this.txtToolTip.Visible = false;
                    }
                    if (!objCoreType.IsUseApprove)
                    {
                        this.lblIsNeedApprove.Visible = false;
                        this.chkIsNeedApprove.Visible = false;
                    }

                    if (!objCoreType.IsUseFolder)
                    {
                        this.lblDefaultFolder.Visible = false;
                        this.cbDefaultFolder.Visible = false;
                    }
                    else
                    {
                        BindCboFolder();
                    }
                    if (!objCoreType.IsUseIcon)
                    {
                        this.lblIcon.Visible = false;
                        this.urlIcon.Visible = false;
                    }
                    if (!objCoreType.IsUsePublic)
                    {
                        this.lblIsNeedPublic.Visible = false;
                        this.chkIsNeedPublic.Visible = false;
                    }
                }
                #endregion

                if (m_intCategoryId != -1)
                {
                    BindData();
                    lblError.Text = "Cập nhật chuyên mục";
                }
                else
                {
                    this.cbCategories.SelectedIndex = 0;
                }
            }
        }

        protected void BindCboExcludedCategories()
        {
            try
            {
                this.cbCategories.Items.Clear();
                this.cbCategories.DataSource = DataProcessingProvider.ProcessDataTable(CategoryProvider.GetExcludedCategories(this.PortalId, m_intCategoryId, m_typeId), 1, 2);
                this.cbCategories.DataValueField = "CategoryId";
                this.cbCategories.DataTextField = "Name";
                this.cbCategories.DataBind();
                this.cbCategories.Items.Insert(0, Localization.GetString("mssNoParent.Text", this.LocalResourceFile));
                this.cbCategories.Items[0].Value = "-1";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }
        protected void BindCboExcludedCategories(int TypeId)
        {
            try
            {
                this.cbCategories.Items.Clear();
                this.cbCategories.DataSource = DataProcessingProvider.ProcessDataTable(CategoryProvider.GetExcludedCategories(this.PortalId, m_intCategoryId, TypeId), 1, 2);
                this.cbCategories.DataValueField = "CategoryId";
                this.cbCategories.DataTextField = "Name";
                this.cbCategories.DataBind();
                this.cbCategories.Items.Insert(0, Localization.GetString("mssNoParent.Text", this.LocalResourceFile));
                this.cbCategories.Items[0].Value = "-1";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }
        protected void CboType()
        {
            cboType.Items.Clear();
            DataTable objTableType = UtilityProvider.GetCoreType();
        xxxxxx:
            for (int i = 0; i < objTableType.Rows.Count; i++)
            {
                string strType = objTableType.Rows[i]["TypeId"].ToString();
                if (m_typeInclude.Contains("," + strType + ","))
                {
                    switch (strType)
                    {
                        case "1": strType = Localization.GetString("Article.Text", LocalResourceFile);
                            break;
                        case "2": strType = Localization.GetString("LegalDocument.Text", LocalResourceFile);// "Văn bản pháp luật";
                            break;
                        case "3": strType = Localization.GetString("Product.Text", LocalResourceFile);//"Sản phẩm";
                            break;
                        case "4": strType = Localization.GetString("ImageGallery.Text", LocalResourceFile);//"Ảnh";
                            break;
                        case "5": strType = Localization.GetString("VideoGallery.Text", LocalResourceFile);//"Video";
                            break;
                        case "6": strType = Localization.GetString("Link.Text", LocalResourceFile);//"Liên kết, Quảng cáo";
                            break;
                        case "7": strType = Localization.GetString("TextHtml.Text", LocalResourceFile);//"Text/Html";
                            break;
                        case "8": strType = Localization.GetString("Config.Text", LocalResourceFile);//"Thiết Lập";
                            break;
                        case "9": strType = "Menu";
                            break;
                        case "10": strType = "Dịch vụ";
                            break;
                        case "11": strType = "Hỏi đáp (Q/A)";
                            break;
                        case "12": strType = "Phản hồi (FAQ)";
                            break;
                        case "13": strType = "Yều cầu dịch vụ";
                            break;
                        default: break;
                    }
                    objTableType.Rows[i]["TypeName"] = strType;
                }
                else
                {
                    objTableType.Rows.RemoveAt(i);
                    goto xxxxxx;
                }
            }
            cboType.DataSource = objTableType;
            cboType.DataTextField = "TypeName";
            cboType.DataValueField = "TypeId";
            cboType.DataBind();
            BindCboExcludedCategories(int.Parse(objTableType.Rows[0]["TypeId"].ToString()));
        }
        protected void BindCboFolder()
        {
            try
            {
                this.cbDefaultFolder.Items.Clear();
                this.cbDefaultFolder = UIProvider.GetFolderBindedComboBox(this.cbDefaultFolder, this.PortalId);
                this.cbDefaultFolder.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }

        protected void BindData()
        {
            try
            {
                CategoryEx item = new CategoryEx(m_intCategoryId);
                this.txtName.Text = item.Name;
                this.txtToolTip.Text = item.ToolTip;
                this.htmlDescription.Text = item.Description;
                if (item.ParentId == -1)
                {
                    this.cbCategories.SelectedIndex = 0;
                }
                else
                {
                    //ListItem lst = new ListItem(CategoryProvider.GetCategoryName(item.ParentId), item.ParentId.ToString());
                    //if (cbCategories.Items.Contains(lst))
                    //{
                    this.cbCategories.SelectedValue = item.ParentId.ToString();
                    //}
                    //else
                    //{
                    //    this.cbCategories.SelectedIndex = 0;
                    //}
                }
                m_typeId = item.TypeId;
                this.cboType.SelectedValue = m_typeId.ToString();
                this.cbDefaultFolder.SelectedValue = item.DefaultFolder;
                this.urlIcon.Url = item.Icon;
                this.urlXslFile.Url = item.XSLFile;
                this.chkIsDefaultXSL.Checked = item.IsDefaultXSL;
                this.chkIsNeedApprove.Checked = item.IsNeedApprove;
                this.chkIsNeedPublic.Checked = item.IsNeedPublic;
                this.txtExtended.Text = item.ExtendedSettings;
                this.txtOrder.Text = item.Order.ToString();
                this.chbDip1.Checked = item.Dip1;
                this.chbDip2.Checked = item.Dip2;
                this.chbDip3.Checked = item.Dip3;
                this.chbDip4.Checked = item.Dip4;
                this.chbDip5.Checked = item.Dip5;
                this.txtAddInfo1.Text = item.AddInfo1;
                this.txtAddInfo2.Text = item.AddInfo2;
                this.txtAddInfo3.Text = item.AddInfo3;
                this.txtAddInfo4.Text = item.AddInfo4;
                this.txtAddInfo5.Text = item.AddInfo5;
                //this.lblError.Visible = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }
        #endregion

        #region IActionable Members

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection objActions = new ModuleActionCollection();

                objActions.Add(this.GetNextActionID(),
                        Localization.GetString("btnSave.Text", this.LocalResourceFile),
                        ModuleActionType.AddContent, "Update", "", "", "",
                        true, DotNetNuke.Security.SecurityAccessLevel.Edit, true, true);

                objActions.Add(this.GetNextActionID(),
                        Localization.GetString("btnReturn.Text", this.LocalResourceFile),
                        ModuleActionType.AddContent, "Return", "", "", "",
                        true, DotNetNuke.Security.SecurityAccessLevel.Edit, true, true);
                return objActions;
            }
        }

        private void ModuleAction_Click(object sender, ActionEventArgs e)
        {
            switch (e.Action.CommandArgument)
            {

                case "Return":
                    {
                        JumpBack();
                        return;
                    }
                case "Update":
                    {
                        UpdateData();
                        return;
                    }
            }

        }
        #endregion

        private void UpdateData()
        {
            try
            {
                int portalId;
                portalId = this.PortalId;

                if (txtName.Text == "")
                {
                    lblError.Text = Localization.GetString("errEmptyName.text", this.LocalResourceFile);
                    lblError.Visible = true;
                    return;
                }
                m_typeId = int.Parse(cboType.SelectedValue);
                int iLanguageId = DotNetNuke.Services.Localization.LocaleController.Instance.GetCurrentLocale(this.PortalId).LanguageId;
                string strCutureCode = DotNetNuke.Services.Localization.LocaleController.Instance.GetCurrentLocale(this.PortalId).Code;

                CategoryEx ObjItem = new CategoryEx(m_intCategoryId, this.txtName.Text, this.htmlDescription.Text,
                                    this.txtToolTip.Text, int.Parse(this.cbCategories.SelectedValue), portalId,
                                    false, this.cbDefaultFolder.SelectedValue, this.chkIsDefaultXSL.Checked,
                                    DNNRelatedProvider.GetFilePath(this.urlXslFile.Url, this.PortalId), DNNRelatedProvider.GetFilePath(this.urlIcon.Url, this.PortalId), m_typeId, this.chkIsNeedApprove.Checked, this.chkIsNeedPublic.Checked, this.txtExtended.Text, int.Parse(this.txtOrder.Text), iLanguageId, strCutureCode, this.chbDip1.Checked, this.chbDip2.Checked, this.chbDip3.Checked, this.chbDip4.Checked, this.chbDip5.Checked, this.txtAddInfo1.Text, this.txtAddInfo2.Text, this.txtAddInfo3.Text, this.txtAddInfo4.Text, this.txtAddInfo5.Text);
                int result;

                if (m_intCategoryId == -1)
                {
                    result = ObjItem.Insert(this.UserId);

                    if (result > 0)
                    {
                        JumpBack();
                    }
                    else if (result == -1)
                    {
                        this.lblError.Text = Localization.GetString("errExistedName.text", this.LocalResourceFile);
                        this.lblError.Visible = true;
                    }
                    else if (result == -2)
                    {
                        this.lblError.Text = Localization.GetString("errParentNotFound.text", this.LocalResourceFile);
                        this.lblError.Visible = true;
                    }

                }
                else
                {
                    result = ObjItem.Update(this.UserId);

                    if (result > 0)
                    {
                        #region danh dau them moi


                        try
                        {
                            File.WriteAllText(Server.MapPath("/DesktopModules/TH.NUCE.Utils/Configuration/ResetCache.txt"), "1");
                            File.WriteAllText(Server.MapPath("/DesktopModules/TH.NUCE.Utils/Configuration/ResetCache_" + this.PortalId + ".txt"), "1");
                        }
                        catch (Exception ex)
                        {

                        }


                        #endregion

                        JumpBack();
                    }
                    else if (result == -1)
                    {
                        this.lblError.Text = Localization.GetString("errCategoryNotFound.text", this.LocalResourceFile);
                        this.lblError.Visible = true;
                    }
                    else if (result == -2)
                    {
                        this.lblError.Text = Localization.GetString("errExistedName.text", this.LocalResourceFile);
                        this.lblError.Visible = true;
                    }
                    else if (result == -3)
                    {
                        this.lblError.Text = Localization.GetString("errParentNotFound.text", this.LocalResourceFile);
                        this.lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            JumpBack();
        }
        private void JumpBack()
        {
            // Nêu là tất cả các type
            try
            {
                if (m_IsAllType)
                {
                    string[] arrStrTypeReturn = m_typeReturn.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arrStrTypeReturn.Length; i++)
                    {
                        string[] arrStrTypeReturnItem = arrStrTypeReturn[i].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                        if (arrStrTypeReturnItem.Length > 0 && arrStrTypeReturnItem[0].Trim().Equals(cboType.SelectedValue))
                        {
                            m_ReturnTabId = int.Parse(arrStrTypeReturnItem[1]);
                        }

                    }
                }
            }
            catch
            { }
            Response.Redirect(Globals.NavigateURL(m_ReturnTabId));
        }
        protected void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_typeId = int.Parse(cboType.SelectedValue.ToString());
            BindCboExcludedCategories();
        }
    }
}