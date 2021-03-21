using System;
using System.Data;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;

namespace TH.NUCE.Web
{
    public partial class ImageInsert : CoreModule, IActionable
    {
        #region private item
        private string m_strCategories;
        private string m_strFolderName;
        private int m_ImageId;
        private int m_preTabId;
        private string m_strExtension;
        private string m_linkUpload;
        private bool m_isPassOnce;
        Role m_objRole;
        #endregion

        #region Initialization
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            #region Request
            m_ImageId = DataProcessingProvider.GetProcessedInt(Request.QueryString["ImageId"]);
            m_preTabId = DataProcessingProvider.GetProcessedInt(Request.QueryString["PreTabId"]);
            if (m_ImageId == -1)
            {
                m_strCategories = DataProcessingProvider.GetProcessedString(Request.QueryString["Categories"]);
                if (m_strCategories == "")
                    m_strCategories = ",-1,";
                else
                    m_strCategories = DataProcessingProvider.GetProcessedBatchString(m_strCategories);
            }
            else
                m_strCategories = CategoryProvider.GetItemCategoryString(m_ImageId, ImageProvider.TypeId);

            #endregion

            #region Settings
            //Load Folder
            m_strFolderName = CategoryProvider.GetDefaultFolderPath(m_strCategories, this.PortalId);
            if (m_strFolderName == "")
            {

                m_strFolderName = (string)Settings[ImageInsertSettings.FOLDER_IMAGE_KEY];
                if (m_strFolderName == null || m_strFolderName.Length == 0)
                    m_strFolderName = ImageInsertSettings.FOLDER_IMAGE_DEFAULT;
            }
            string strFolderPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, m_strFolderName);
            if (!System.IO.Directory.Exists(strFolderPath))
                m_strFolderName = ImageInsertSettings.FOLDER_IMAGE_DEFAULT;

            m_strExtension = LoadStringSetting(ImageInsertSettings.EXTENSTION_KEY, ImageInsertSettings.EXTENSTION_VALUE_DEFAULT);
            m_linkUpload = LoadStringSetting(ImageInsertSettings.LINKUPLOAD_KEY, ImageInsertSettings.LINKUPLOAD_VALUE_DEFAULT);
            #endregion

            #region Datetime

            lnkExpiredDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiredDate).Replace("M/d/yyyy", "MM/dd/yyyy").Replace("d/MM/yyyy", "dd/MM/yyyy").Replace("MM/dd/yyyy", "dd/MM/yyyy");
            //Điền dữ liệu vào các control
            imgExpiredDate.ImageUrl = string.Format("{0}/images/calendar.png", this.ModulePath);

            lnkDisplayDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtDisplayDate).Replace("M/d/yyyy", "MM/dd/yyyy").Replace("d/MM/yyyy", "dd/MM/yyyy").Replace("MM/dd/yyyy", "dd/MM/yyyy");
            //Điền dữ liệu vào các control
            imgDisplayDate.ImageUrl = string.Format("{0}/images/calendar.png", this.ModulePath);
            #endregion

            #region Register

            DotNetNuke.UI.Skins.Skin objParentSkin = DotNetNuke.UI.Skins.Skin.GetParentSkin(this);
            if (objParentSkin != null)
            {
                objParentSkin.RegisterModuleActionEvent(this.ModuleId, new ActionEventHandler(ModuleAction_Click));
            }
            if (m_ImageId == -1)
                m_objRole = new Role(this.UserId, GetSuperMode(), this.PortalId, ImageProvider.TypeId);
            else
                m_objRole = new Role(this.UserId, m_ImageId, GetSuperMode(), this.PortalId, ImageProvider.TypeId);
            #endregion

        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
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
                        true, DotNetNuke.Security.SecurityAccessLevel.View, true, true);

                objActions.Add(this.GetNextActionID(),
                        Localization.GetString("btnReturn.Text", this.LocalResourceFile),
                        ModuleActionType.AddContent, "Return", "", "", "",
                        true, DotNetNuke.Security.SecurityAccessLevel.View, true, true);


                return objActions;
            }
        }

        private void ModuleAction_Click(object sender, ActionEventArgs e)
        {
            switch (e.Action.CommandArgument)
            {

                case "Return":
                    {
                        JumpBack(false, -1);
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

        #region Page Load & Data Binding

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (m_isPassOnce)
                        return;
                    aLinkUpload.HRef = m_linkUpload;

                    //Set DisplayDate to Today, Set ExpiredDate to ten years after.
                    this.txtDisplayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.txtExpiredDate.Text = DateTime.Now.AddYears(10).ToString("dd/MM/yyyy");

                    //Load Categories
                    //if (m_ImageId == -1)
                    //{
                    this.chkCategoryList.DataSource = DataProcessingProvider.ProcessDataTable(CategoryProvider.GetExcludedCategories(this.PortalId, -1, ImageProvider.TypeId), 1, 2);
                    this.chkCategoryList.DataTextField = "Name";
                    this.chkCategoryList.DataValueField = "CategoryId";
                    this.chkCategoryList.DataBind();
                    UIProvider.BindListBox(chkCategoryList, m_strCategories);
                    //}
                    //else
                    //{
                    //    TH.Core.Providers.Utilities.UIProvider.PopulateCategories(this.chkCategoryList, m_strCategories, ImageProvider.TypeId, this.UserId, GetSuperMode(), true, m_ImageId);

                    //}
                    //Bind Data
                    if (m_ImageId != -1)
                    {
                        ImageBinding();

                    }


                    m_isPassOnce = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
        }

        public void ImageBinding()
        {
            DataTable objTableData = ImageProvider.GetImage(m_ImageId);
            if (objTableData.Rows.Count > 0)
            {
                lblError.Text = "Cập nhật hình ảnh";
                this.txtTitle.Text = txtTitleOld.Text = objTableData.Rows[0]["Title"].ToString();
                this.txtSummary.Text = objTableData.Rows[0]["Summary"].ToString();
                this.htmlContent.Text = objTableData.Rows[0]["Content"].ToString();
                string strAvatar = objTableData.Rows[0]["Avatar"].ToString();
                this.txtAvatarOld.Text = strAvatar;
                this.spAvatar.InnerHtml = strAvatar;
                if (strAvatar.Contains("Portals"))
                    this.imgAvatar.Src = strAvatar;
                else
                    this.imgAvatar.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strAvatar);

                //this.imgAvatar.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strAvatar);
                urlAvatar.Url = strAvatar;
                string strImageFile = objTableData.Rows[0]["ImageFile"].ToString();
                this.txtImageFileOld.Text = strImageFile;
                this.spImageFile.InnerHtml = strImageFile;
                if (strImageFile.Contains("Portals"))
                    this.imgImageFile.Src = strImageFile;
                else
                    this.imgImageFile.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strImageFile);
                //this.imgImageFile.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strImageFile);
                urlImageFile.Url = strImageFile;
                this.chIsUrlWeb.Checked = bool.Parse(objTableData.Rows[0]["IsUrlWeb"].ToString());
                txtCreatedDateOld.Text = objTableData.Rows[0]["CreatedDate"].ToString();
                txtOrder.Text = objTableData.Rows[0]["Order"].ToString();
                this.txtDisplayDate.Text = DateTime.Parse(objTableData.Rows[0]["DisplayDate"].ToString()).ToString("dd/MM/yyyy");
                txtExpiredDate.Text = DateTime.Parse(objTableData.Rows[0]["ExpiredDate"].ToString()).ToString("dd/MM/yyyy");

                txtAddInfo1.Text = objTableData.Rows[0]["AddInfo1"] == null ? "" : objTableData.Rows[0]["AddInfo1"].ToString();
                txtAddInfo2.Text = objTableData.Rows[0]["AddInfo2"] == null ? "" : objTableData.Rows[0]["AddInfo2"].ToString();
                txtAddInfo3.Text = objTableData.Rows[0]["AddInfo3"] == null ? "" : objTableData.Rows[0]["AddInfo3"].ToString();
                txtAddInfo4.Text = objTableData.Rows[0]["AddInfo4"] == null ? "" : objTableData.Rows[0]["AddInfo4"].ToString();
                txtAddInfo5.Text = objTableData.Rows[0]["AddInfo5"] == null ? "" : objTableData.Rows[0]["AddInfo5"].ToString();

                if (objTableData.Rows[0]["IsHot"].ToString() == "False")
                {
                    this.chkIsHot.Checked = false;
                }
                else
                {
                    this.chkIsHot.Checked = true;
                }
                this.txtHotPeriod.Text = objTableData.Rows[0]["HotPeriod"].ToString();
            }
        }
        #endregion

        protected void JumpBack(bool isStay, int ImageId)
        {
            string strCategoryUrl = "-1";
            string[] strCategoriesUrl = DataProcessingProvider.GetProcessedString(Request.QueryString["Categories"]).Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (strCategoriesUrl != null && strCategoriesUrl.Length > 0)
            {
                strCategoryUrl = strCategoriesUrl[0];
            }
            else
            {
                strCategoriesUrl = m_strCategories.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                strCategoryUrl = strCategoriesUrl[0];
            }
            if (strCategoryUrl.Equals("-1"))
                Response.Redirect(Globals.NavigateURL(m_preTabId));
            else
            {
                if (!Globals.NavigateURL(m_preTabId).Contains("?"))
                    Response.Redirect(Globals.NavigateURL(m_preTabId) + "?CategoryId=" + strCategoryUrl);
                else
                    Response.Redirect(Globals.NavigateURL(m_preTabId) + "&&CategoryId=" + strCategoryUrl);
            }
        }
        protected void UpdateData()
        {
            try
            {
                //Detect Empty Text
                if (this.txtTitle.Text == "")
                {
                    this.lblError.Text = Localization.GetString("errEmptyName.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }

                string strSummary = txtSummary.Text;



                string strContent = DataProcessingProvider.RemoveTags(this.htmlContent.Text);
                bool blIsOpenNewTab = chIsUrlWeb.Checked;
                //Detect Role 

                if (!((m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.Create) && m_ImageId == -1) || ((m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.EditAfter) || m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.EditAll)) && m_ImageId != -1)))
                {
                    this.lblError.Text = Localization.GetString("errNoRole.Text", this.LocalResourceFile);
                    //this.lblError.Text = m_objRole.HasRole((int)THCore.CoreRole.Create).ToString();
                    this.lblError.Visible = true;
                    return;
                }

                string strImageFile = "";
                string strAvatar = "";

                string strFolderName = m_strCategories;
                strFolderName = CategoryProvider.GetDefaultFolderPath(UIProvider.GetListBoxSelectedItems(",", chkCategoryList), this.PortalId);
                if (strFolderName == "" || strFolderName == null || strFolderName.Length == 0)
                {
                    strFolderName = "Folder";
                }
                string strFolderPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                if (!System.IO.Directory.Exists(strFolderPath))
                    strFolderName = m_strFolderName;
                /*
                if (txtImageFile.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtImageFile.PostedFile.FileName.Substring(txtImageFile.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strImageFile = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileProvider.Upload(this.PortalId, strFolderName, strFileName,
                        txtImageFile.PostedFile.InputStream);
                    //FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtImageFile.PostedFile, false);
                }*/
                strImageFile = DNNRelatedProvider.GetFilePath(urlImageFile.Url, this.PortalId);
                if (strImageFile == "")
                    strImageFile = txtImageFileOld.Text;
                /*
                if (txtAvatar.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtAvatar.PostedFile.FileName.Substring(txtAvatar.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strAvatar = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileProvider.Upload(this.PortalId, strFolderName, strFileName,
                        txtAvatar.PostedFile.InputStream);
                   // FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtAvatar.PostedFile, false);
                }*/
                strAvatar = DNNRelatedProvider.GetFilePath(urlAvatar.Url, this.PortalId); 
                if (strAvatar == "")
                    strAvatar = txtAvatarOld.Text;

                int iOrder = -1;
                string strOrder = txtOrder.Text;
                if (!int.TryParse(strOrder, out iOrder))
                {
                    this.lblError.Text = Localization.GetString("errFormatOrder.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }

                DateTime ExpiredDate;
                ExpiredDate = DateTime.ParseExact(txtExpiredDate.Text, "dd/MM/yyyy", null);


                DateTime DisplayDate;
                if (txtDisplayDate.Text == "")
                    DisplayDate = DateTime.Today;
                else
                    DisplayDate = DateTime.ParseExact(txtDisplayDate.Text, "dd/MM/yyyy", null);


                DisplayDate.AddHours(DateTime.Now.Hour);
                DisplayDate.AddMinutes(DateTime.Now.Minute);
                DisplayDate.AddSeconds(DateTime.Now.Second);



                // Get Hot Period
                int intPeriod;
                if (!int.TryParse(this.txtHotPeriod.Text, out intPeriod))
                    intPeriod = 0;

                m_strCategories = UIProvider.GetListBoxSelectedItems(",", chkCategoryList);
                if (m_strCategories.Equals(""))
                {
                    this.lblError.Text = "Chưa chọn chuyên mục";
                    this.lblError.Visible = true;
                    return;
                }

                string strAddInfo1 = txtAddInfo1.Text;
                string strAddInfo2 = txtAddInfo2.Text;
                string strAddInfo3 = txtAddInfo3.Text;
                string strAddInfo4 = txtAddInfo4.Text;
                string strAddInfo5 = txtAddInfo5.Text;
                //Going into action.
                int result = 1;

                if (m_ImageId == -1)
                {
                    string realTitle = "";
                    realTitle = DataProcessingProvider.RemoveTags(this.txtTitle.Text);
                    result = ImageProvider.InsertImage(realTitle, strSummary, strImageFile, strAvatar, blIsOpenNewTab, strContent, DateTime.Now, ExpiredDate, DisplayDate, DateTime.Now, this.UserId, chkIsHot.Checked, intPeriod, this.PortalId, false, iOrder, m_strCategories, strAddInfo1, strAddInfo2, strAddInfo3, strAddInfo4, strAddInfo5);
                    if (result > 0)
                    {
                        LogProvider.InsertLogAction(result, ImageProvider.TypeId, "", this.PortalId, (int)Connection.UtilsProvider.LogAction.Create, this.UserInfo.Username, this.UserId, realTitle, true, m_strCategories);
                    }

                }
                else
                {
                    string realTitle = "";
                    realTitle = DataProcessingProvider.RemoveTags(this.txtTitle.Text);
                    DateTime CreateDate = DateTime.Parse(txtCreatedDateOld.Text);
                    //ImageProvider.UpdateImage(m_ImageId, txtTitleOld.Text, strSummary, strImageFile, strAvatar, blIsOpenNewTab, strContent, CreateDate, ExpiredDate, DisplayDate, DateTime.Now, this.UserId, chkIsHot.Checked, intPeriod, this.PortalId, false, iOrder, TH.Utils.UIProvider.GetListBoxSelectedItems(",", chkCategoryList));
                    ImageProvider.UpdateImage(m_ImageId, realTitle, strSummary, strImageFile, strAvatar, blIsOpenNewTab, strContent, CreateDate, ExpiredDate, DisplayDate, DateTime.Now, this.UserId, chkIsHot.Checked, intPeriod, this.PortalId, false, iOrder, m_strCategories, strAddInfo1, strAddInfo2, strAddInfo3, strAddInfo4, strAddInfo5);
                    result = m_ImageId;
                    if (result > 0)
                    {
                        LogProvider.InsertLogAction(result, ImageProvider.TypeId, "", this.PortalId, (int)Connection.UtilsProvider.LogAction.Update, this.UserInfo.Username, this.UserId, this.txtTitleOld.Text, true, m_strCategories);
                    }
                }


                if (result == -2)
                {
                    this.lblError.Text = Localization.GetString("errSameName.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                }
                else if (result <= 0)
                {
                    this.lblError.Text = Localization.GetString("errSomeError.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                }
                else
                    JumpBack(false, result);

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.GetType().ToString();
                this.lblError.Visible = true;
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            JumpBack(false, -1);
        }
    }
}

