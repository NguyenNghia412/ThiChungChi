using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Common;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;
using System.IO;

namespace TH.NUCE.Web
{
    public partial class ProductInsert : CoreModule, IActionable
    {
        #region private item
        private string m_strCategories;
        private string m_strTags;
        private string m_strFolderName;
        private int m_ProductId;
        private int m_preTabId;
        private string m_strExtension;
        Role m_objRole;
        private bool m_isPassOnce;

        DataTable dtConfig;
        DataTable dtValue;

        #endregion
        #region Initialization
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
            #region Request
            m_ProductId = DataProcessingProvider.GetProcessedInt(Request.QueryString["ProductId"]);
            m_preTabId = DataProcessingProvider.GetProcessedInt(Request.QueryString["PreTabId"]);
            m_strTags = ",";
            if (m_ProductId == -1)
            {
                m_strCategories = DataProcessingProvider.GetProcessedString(Request.QueryString["Categories"]);
                if (m_strCategories == "")
                    m_strCategories = ",-1,";
                else
                    m_strCategories = DataProcessingProvider.GetProcessedBatchString(m_strCategories);
            }
            else
            {

                DataTable dtTags = DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_CM_GetItemTags", m_ProductId, ProductProvider.TypeId).Tables[0];
                if (dtTags.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTags.Rows.Count; i++)
                        m_strTags = m_strTags + dtTags.Rows[i][0].ToString() + ",";
                }
                m_strCategories = CategoryProvider.GetItemCategoryString(m_ProductId, ProductProvider.TypeId);
            }
            //Dynamic Form
            string[] arrCategories = m_strCategories.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            int iCategory = -1;
            int.TryParse(arrCategories[0].Trim(), out iCategory);

            m_strExtension = LoadStringSetting(ProductInsertSettings.EXTENSTION_KEY, ProductInsertSettings.EXTENSTION_VALUE_DEFAULT);
            //string strExtendedSettings = CategoryProvider.GetExtendedSettings(iCategory);
            string strExtendedSettings = m_strExtension;

            dtConfig = new DataTable();
            dtConfig = XMLProvider.XmlString2DataTable(strExtendedSettings);
            try
            {
                if (dtConfig != null && dtConfig.Rows.Count > 0)
                    CreateDynamicForm(dtConfig);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                this.lblError.Visible = true;
            }
            #endregion
            #region Settings
            //Load Folder
            m_strFolderName = CategoryProvider.GetDefaultFolderPath(m_strCategories, this.PortalId);
            if (m_strFolderName == "")
            {
                m_strFolderName = (string)Settings[ProductInsertSettings.FOLDER_IMAGE_KEY];
                if (m_strFolderName == null || m_strFolderName.Length == 0)
                    m_strFolderName = ProductInsertSettings.FOLDER_IMAGE_DEFAULT;
            }
            string strFolderPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, m_strFolderName);
            if (!System.IO.Directory.Exists(strFolderPath))
                m_strFolderName = ProductInsertSettings.FOLDER_IMAGE_DEFAULT;


            #endregion
            #region Datetime
            lnkExpiredDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtExpiredDate).Replace("M/d/yyyy", "MM/dd/yyyy").Replace("d/MM/yyyy", "dd/MM/yyyy").Replace("MM/dd/yyyy", "dd/MM/yyyy");
            //Điền dữ liệu vào các control
            imgExpiredDate.ImageUrl = string.Format("{0}/images/calendar.png", this.ModulePath);

            lnkProducedDate.NavigateUrl = DotNetNuke.Common.Utilities.Calendar.InvokePopupCal(txtProducedDate).Replace("M/d/yyyy", "MM/dd/yyyy").Replace("d/MM/yyyy", "dd/MM/yyyy").Replace("MM/dd/yyyy", "dd/MM/yyyy");
            //Điền dữ liệu vào các control
            imgProducedDate.ImageUrl = string.Format("{0}/images/calendar.png", this.ModulePath);

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
            if (m_ProductId == -1)
                m_objRole = new Role(this.UserId, GetSuperMode(), this.PortalId, ProductProvider.TypeId);
            else
                m_objRole = new Role(this.UserId, m_ProductId, GetSuperMode(), this.PortalId, ProductProvider.TypeId);
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

                    //Set DisplayDate to Today, Set ExpiredDate to ten years after.
                    this.txtDisplayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.txtExpiredDate.Text = DateTime.Now.AddYears(10).ToString("dd/MM/yyyy");

                    this.txtProducedDate.Text = DateTime.Now.AddYears(10).ToString("dd/MM/yyyy");


                    txtWeight.Text = "0";
                    txtPrice.Text = "0";
                    txtPriceOld.Text = "0";
                    txtOrder.Text = "100";

                    //Load Categories
                    //if (m_ProductId == -1)
                    //{
                    this.chkCategoryList.DataSource = DataProcessingProvider.ProcessDataTable(CategoryProvider.GetExcludedCategories(this.PortalId, -1, ProductProvider.TypeId), 1, 2);
                    this.chkCategoryList.DataTextField = "Name";
                    this.chkCategoryList.DataValueField = "CategoryId";
                    this.chkCategoryList.DataBind();
                    UIProvider.BindListBox(chkCategoryList, m_strCategories);

                    //Tag
                    this.chkTags.DataSource = DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_CM_GetTags", this.PortalId, 3).Tables[0];
                    this.chkTags.DataTextField = "Name";
                    this.chkTags.DataValueField = "TagID";
                    this.chkTags.DataBind();
                    UIProvider.BindListBox(chkTags, m_strTags);

                    //}
                    //else
                    //{
                    //    TH.Core.Providers.Utilities.UIProvider.PopulateCategories(this.chkCategoryList, m_strCategories, ProductProvider.TypeId, this.UserId, GetSuperMode(), true, m_ProductId);

                    //}
                    //Bind Data
                    if (m_ProductId != -1)
                    {
                        ProductBinding();

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
        public void ProductBinding()
        {
            DataTable objTableData = ProductProvider.GetProduct(m_ProductId);
            if (objTableData.Rows.Count > 0)
            {
                lblError.Text = "Cập nhật sản phẩm";
                this.txtProductName.Text = txtProductNameOld.Text = objTableData.Rows[0]["ProductName"].ToString();
                this.txtCode.Text = txtProductNameOld.Text = objTableData.Rows[0]["Code"].ToString();
                string strImageAdd1 = objTableData.Rows[0]["ImageAdd1"].ToString();
                string strImageAdd2 = objTableData.Rows[0]["ImageAdd2"].ToString();
                string strImageAdd3 = objTableData.Rows[0]["ImageAdd3"].ToString();
                urlSmallImageImgAdd1.Url = strImageAdd1;
                urlSmallImageImgAdd2.Url = strImageAdd2;
                urlSmallImageImgAdd3.Url = strImageAdd3;
                txtImageAdd1Old.Text = strImageAdd1;
                txtImageAdd2Old.Text = strImageAdd2;
                txtImageAdd3Old.Text = strImageAdd3;
                string strSmallImage = objTableData.Rows[0]["Smallimage"].ToString();
                txtSmallimageOld.Text = strSmallImage;
                urlSmallImage.Url = strSmallImage;
                string strLargeimage = objTableData.Rows[0]["Largeimage"].ToString();
                txtLargeimageOld.Text = strLargeimage;
                urlLargeImage.Url = strLargeimage;
                txtCreatedDateOld.Text = objTableData.Rows[0]["CreatedDate"].ToString();

                //this.imgImageFile.Src = string.Format("/Portals/{0}/{1}", this.PortalId, m_strOldImagePath);
                //spImageFile.InnerHtml = m_strOldImagePath;
                if (strImageAdd1.Contains("Portals"))
                    this.imgAdd1.Src = strImageAdd1;
                else
                    this.imgAdd1.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strImageAdd1);
                if (strImageAdd2.Contains("Portals"))
                    this.imgAdd2.Src = strImageAdd2;
                else
                    this.imgAdd2.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strImageAdd2);
                if (strImageAdd3.Contains("Portals"))
                    this.imgAdd3.Src = strImageAdd3;
                else
                    this.imgAdd3.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strImageAdd3);
                this.spImgAdd1.InnerHtml = strImageAdd1;
                this.spImgAdd2.InnerHtml = strImageAdd2;
                this.spImgAdd3.InnerHtml = strImageAdd3;
                if (strSmallImage.Contains("Portals"))
                    this.imgSmallImage.Src = strSmallImage;
                else
                    this.imgSmallImage.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strSmallImage);
                this.spSmallImage.InnerHtml = strSmallImage;
                if (strLargeimage.Contains("Portals"))
                    this.imgLargeimage.Src = strLargeimage;
                else
                    this.imgLargeimage.Src = string.Format("/Portals/{0}/{1}", this.PortalId, strLargeimage);
                spLargeimage.InnerHtml = strLargeimage;

                txtLead.Text = objTableData.Rows[0]["Lead"].ToString();

                txtSummary.Text = objTableData.Rows[0]["Summary"].ToString();
                txtWeight.Text = objTableData.Rows[0]["Weight"].ToString();
                txtPrice.Text = objTableData.Rows[0]["Price"].ToString();
                txtPriceOld.Text = objTableData.Rows[0]["PriceOld"].ToString();
                txtStatusProduct.Text = objTableData.Rows[0]["StatusProduct"].ToString();
                txtaddInfo1.Text = objTableData.Rows[0]["AddInfo1"].ToString();
                txtaddInfo2.Text = objTableData.Rows[0]["AddInfo2"].ToString();
                txtaddInfo3.Text = objTableData.Rows[0]["AddInfo3"].ToString();

                txtaddInfo4.Text = objTableData.Rows[0]["AddInfo4"].ToString();
                txtaddInfo5.Text = objTableData.Rows[0]["AddInfo5"].ToString();
                txtaddInfo6.Text = objTableData.Rows[0]["AddInfo6"].ToString();

                txtaddRichInfo1.Text = objTableData.Rows[0]["AddRichInfo1"].ToString();
                txtaddRichInfo2.Text = objTableData.Rows[0]["AddRichInfo2"].ToString();
                txtaddRichInfo3.Text = objTableData.Rows[0]["AddRichInfo3"].ToString();

                txtOrder.Text = objTableData.Rows[0]["Order"].ToString();
                this.txtProducedDate.Text = DateTime.Parse(objTableData.Rows[0]["ProducedDate"].ToString()).ToString("dd/MM/yyyy");
                this.txtDisplayDate.Text = DateTime.Parse(objTableData.Rows[0]["DisplayDate"].ToString()).ToString("dd/MM/yyyy");
                txtExpiredDate.Text = DateTime.Parse(objTableData.Rows[0]["ExpiredDate"].ToString()).ToString("dd/MM/yyyy");

                if (objTableData.Rows[0]["IsHot"].ToString() == "False")
                {
                    this.chkIsHot.Checked = false;
                }
                else
                {
                    this.chkIsHot.Checked = true;
                }
                this.txtHotPeriod.Text = objTableData.Rows[0]["HotPeriod"].ToString();
                //Bind Dynamic Form
                string strExtendedSettings = objTableData.Rows[0]["ExtendedSettings"].ToString();
                dtValue = new DataTable();
                dtValue = XMLProvider.XmlString2DataTable(strExtendedSettings);
                try
                {
                    if (dtValue != null && dtValue.Rows.Count > 0)
                        BindingDynamicForm(dtValue);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                    this.lblError.Visible = true;
                }
            }
        }
        protected void CreateDynamicForm(DataTable ObjTableDynamic)
        {
            try
            {
                HtmlTable objTable = new HtmlTable();
                for (int i = 0; i < dtConfig.Rows.Count; i++)
                {
                    string strName = ObjTableDynamic.Rows[i]["Name"].ToString();
                    string strTitle = ObjTableDynamic.Rows[i]["Title"].ToString();
                    string strType = ObjTableDynamic.Rows[i]["Type"].ToString().ToUpper();
                    string strWidth = ObjTableDynamic.Rows[i]["Width"].ToString();
                    // Tao ra dong va control moi
                    switch (strType)
                    {
                        case "STRING":
                            HtmlTableRow sobjRowTg = new HtmlTableRow();
                            HtmlTableCell sobjCellTgTitle = new HtmlTableCell();
                            sobjCellTgTitle.InnerText = strTitle;
                            HtmlTableCell sobjCellTgControl = new HtmlTableCell();
                            TextBox sobjTxtTg = new TextBox();
                            int siWidth = 100;
                            int.TryParse(strWidth, out siWidth);
                            sobjTxtTg.Width = new Unit(siWidth);
                            sobjTxtTg.ID = strName;
                            sobjCellTgControl.Controls.Add(sobjTxtTg);
                            sobjRowTg.Cells.Add(sobjCellTgTitle);
                            sobjRowTg.Cells.Add(sobjCellTgControl);
                            objTable.Rows.Add(sobjRowTg);
                            break;
                        case "RICHTEXT":
                            HtmlTableRow rtobjRowTg = new HtmlTableRow();
                            HtmlTableCell rtobjCellTgTitle = new HtmlTableCell();
                            rtobjCellTgTitle.InnerText = strTitle;
                            HtmlTableCell rtobjCellTgControl = new HtmlTableCell();

                            DotNetNuke.UI.WebControls.DNNRichTextEditControl rtobjTxtTg = new DotNetNuke.UI.WebControls.DNNRichTextEditControl();
                            int rtiWidth = 100;
                            int.TryParse(strWidth, out rtiWidth);

                            rtobjTxtTg.Width = new Unit(700);
                            rtobjTxtTg.ID = strName;
                            rtobjCellTgControl.Controls.Add(rtobjTxtTg);
                            rtobjRowTg.Cells.Add(rtobjCellTgTitle);
                            rtobjRowTg.Cells.Add(rtobjCellTgControl);
                            objTable.Rows.Add(rtobjRowTg);
                            break;
                        case "IMAGE":
                            HtmlTableRow iobjRowTg = new HtmlTableRow();
                            HtmlTableCell iobjCellTgTitle = new HtmlTableCell();
                            iobjCellTgTitle.InnerText = strTitle;
                            HtmlTableCell iobjCellTgControl = new HtmlTableCell();
                            HtmlInputFile iobjTxtFile = new HtmlInputFile();
                            iobjTxtFile.ID = strName;
                            iobjCellTgControl.Controls.Add(iobjTxtFile);
                            iobjRowTg.Cells.Add(iobjCellTgTitle);
                            iobjRowTg.Cells.Add(iobjCellTgControl);
                            objTable.Rows.Add(iobjRowTg);

                            // Control An
                            TextBox iobjTxtTg = new TextBox();
                            iobjTxtTg.ID = strName + "_HIDE";
                            iobjTxtTg.Visible = false;
                            phDynamicHide.Controls.Add(iobjTxtTg);
                            break;
                        default: break;
                    }
                }
                phDynamic.Controls.Add(objTable);
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.GetType().ToString();
                this.lblError.Visible = true;
            }
        }
        protected void BindingDynamicForm(DataTable ObjTableDynamicValue)
        {
            try
            {
                for (int i = 0; i < ObjTableDynamicValue.Rows.Count; i++)
                {
                    string strName = ObjTableDynamicValue.Rows[i]["Name"].ToString();
                    string strValue = ObjTableDynamicValue.Rows[i]["Value"].ToString();
                    string strType = ObjTableDynamicValue.Rows[i]["Type"].ToString().ToUpper();
                    switch (strType)
                    {
                        case "STRING":
                            TextBox sobjTxtTg = new TextBox();
                            sobjTxtTg = (TextBox)this.FindControl(strName);
                            sobjTxtTg.Text = strValue;
                            break;
                        case "RICHTEXT":
                            DotNetNuke.UI.WebControls.DNNRichTextEditControl rtobjTxtTg = new DotNetNuke.UI.WebControls.DNNRichTextEditControl();
                            rtobjTxtTg = (DotNetNuke.UI.WebControls.DNNRichTextEditControl)this.FindControl(strName);
                            rtobjTxtTg.Value = strValue;
                            break;
                        case "IMAGE":
                            TextBox iobjTxtTg = new TextBox();
                            iobjTxtTg = (TextBox)this.FindControl(strName + "_HIDE");
                            iobjTxtTg.Text = strValue;
                            break;
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.GetType().ToString();
                this.lblError.Visible = true;
            }
        }
        #endregion
        protected void JumpBack(bool isStay, int ProductId)
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
                if (this.txtProductName.Text == "")
                {
                    this.lblError.Text = Localization.GetString("errEmptyName.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }

                string strLead = txtLead.Text;
                string strCode = txtCode.Text;
                string strSummary = txtSummary.Text;
                string straddRichInfo1 = txtaddRichInfo1.Text;
                string straddRichInfo2 = txtaddRichInfo2.Text;
                string straddRichInfo3 = txtaddRichInfo3.Text;
                string strWeight = txtWeight.Text;
                double fWeight = -1;
                if (!double.TryParse(strWeight, out fWeight))
                {
                    this.lblError.Text = Localization.GetString("errFormatWeight.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }
                int iPrice = -1;
                string strPrice = txtPrice.Text;
                if (!int.TryParse(strPrice, out iPrice))
                {
                    this.lblError.Text = Localization.GetString("errFormatPrice.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }
                int iPriceOld = -1;
                string strPriceOld = txtPriceOld.Text;
                if (!int.TryParse(strPriceOld, out iPriceOld))
                {
                    this.lblError.Text = Localization.GetString("errFormatPriceOld.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }
                int iOrder = -1;
                string strOrder = txtOrder.Text;
                if (!int.TryParse(strOrder, out iOrder))
                {
                    this.lblError.Text = Localization.GetString("errFormatOrder.Text", this.LocalResourceFile);
                    this.lblError.Visible = true;
                    return;
                }

                string strStatusProduct = txtStatusProduct.Text;
                string straddInfo1 = txtaddInfo1.Text;
                string straddInfo2 = txtaddInfo2.Text;
                string straddInfo3 = txtaddInfo3.Text;
                string straddInfo4 = txtaddInfo4.Text;
                string straddInfo5 = txtaddInfo5.Text;
                string straddInfo6 = txtaddInfo6.Text;
                //Detect Role 
                if (!((m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.Create) && m_ProductId == -1) || ((m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.EditAfter) || m_objRole.HasRole((int)Connection.UtilsProvider.CoreRole.EditAll)) && m_ProductId != -1)))
                {
                    this.lblError.Text = Localization.GetString("errNoRole.Text", this.LocalResourceFile);
                    //this.lblError.Text = m_objRole.HasRole((int)THCore.CoreRole.Create).ToString();
                    this.lblError.Visible = true;
                    return;
                }

                string strSmallimage = "";
                string strLargeimage = "";

                string strImageAdd1 = "";
                string strImageAdd2 = "";
                string strImageAdd3 = "";

                string strFolderName = m_strCategories;

                strSmallimage = DNNRelatedProvider.GetFilePath(urlSmallImage.Url, this.PortalId);
                strLargeimage = DNNRelatedProvider.GetFilePath(urlLargeImage.Url, this.PortalId);
                strImageAdd1 = DNNRelatedProvider.GetFilePath(urlSmallImageImgAdd1.Url, this.PortalId);
                strImageAdd2 = DNNRelatedProvider.GetFilePath(urlSmallImageImgAdd2.Url, this.PortalId);
                strImageAdd3 = DNNRelatedProvider.GetFilePath(urlSmallImageImgAdd3.Url, this.PortalId);
                /*
                strFolderName = CategoryProvider.GetDefaultFolderPath(TH.Utils.UIProvider.GetListBoxSelectedItems(",", chkCategoryList), this.PortalId);
                if (strFolderName == "" || strFolderName == null || strFolderName.Length == 0)
                {
                    strFolderName = "Folder";
                }
                string strFolderPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                if (!System.IO.Directory.Exists(strFolderPath))
                    strFolderName = m_strFolderName;
                #region
                if (txtSmallimage.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtSmallimage.PostedFile.FileName.Substring(txtSmallimage.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strSmallimage = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtSmallimage.PostedFile, false);

                }
                if (strSmallimage == "")
                    strSmallimage = txtSmallimageOld.Text;
                #endregion
                #region
                if (txtLargeimage.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtLargeimage.PostedFile.FileName.Substring(txtLargeimage.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strLargeimage = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtLargeimage.PostedFile, false);
                }

                if (strLargeimage == "")
                    strLargeimage = txtLargeimageOld.Text;
                #endregion
                #region imageAdd1

                if (txtAddImage1.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtAddImage1.PostedFile.FileName.Substring(txtAddImage1.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strImageAdd1 = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtAddImage1.PostedFile, false);
                }

                if (strImageAdd1 == "")
                    strImageAdd1 = txtImageAdd1Old.Text;
                #endregion
                #region imageAdd2

                if (txtAddImage2.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtAddImage2.PostedFile.FileName.Substring(txtAddImage2.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strImageAdd2 = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtAddImage2.PostedFile, false);
                }

                if (strImageAdd2 == "")
                    strImageAdd2 = txtImageAdd2Old.Text;
                #endregion
                #region imageAdd3

                if (txtAddImage3.PostedFile.FileName.Length != 0) //&& chkUseImage.Checked
                {
                    string strFileName = txtAddImage3.PostedFile.FileName.Substring(txtAddImage3.PostedFile.FileName.LastIndexOf(@"\") + 1);
                    strImageAdd3 = string.Format("{0}{1}", strFolderName, strFileName);
                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, strFolderName);
                    FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), txtAddImage3.PostedFile, false);
                }

                if (strImageAdd3 == "")
                    strImageAdd3 = txtImageAdd3Old.Text;
                #endregion
                 */
                DateTime ProducedDate;

                ProducedDate = DateTime.ParseExact(txtProducedDate.Text, "dd/MM/yyyy", null);

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
                // DyncmicForm
                string strExtendedSettings = GetValueDynamic(strFolderName);

                m_strCategories = UIProvider.GetListBoxSelectedItems(",", chkCategoryList);
                m_strTags = UIProvider.GetListBoxSelectedItems(",", chkTags);
                if (m_strCategories.Equals(""))
                {
                    this.lblError.Text = "Chưa chọn chuyên mục";
                    this.lblError.Visible = true;
                    return;
                }

                //Going into action.
                int result = 1;

                if (m_ProductId == -1)
                {
                    string realProductName = "";
                    realProductName = DataProcessingProvider.RemoveTags(this.txtProductName.Text);
                    result = ProductProvider.InsertProduct(realProductName, strLead, DataProcessingProvider.RemoveTags(strSummary), strSmallimage, strLargeimage, fWeight, DateTime.Now, ExpiredDate, DateTime.Now, ProducedDate, true, false, chkIsHot.Checked, intPeriod, this.UserId, this.PortalId, false, iPrice, iPriceOld, strStatusProduct, strExtendedSettings, iOrder, m_strCategories, strCode, strImageAdd1, strImageAdd2, strImageAdd3, DisplayDate, straddInfo1, straddInfo2, straddInfo3,straddInfo4,straddInfo5,straddInfo6, DataProcessingProvider.RemoveTags(straddRichInfo1), DataProcessingProvider.RemoveTags(straddRichInfo2), DataProcessingProvider.RemoveTags(straddRichInfo3), m_strTags, 1);

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

                        LogProvider.InsertLogAction(result, ProductProvider.TypeId, "", this.PortalId, (int)Connection.UtilsProvider.LogAction.Create, this.UserInfo.Username, this.UserId, this.txtProductName.Text, true, m_strCategories);
                    }

                }
                else
                {
                    DateTime CreateDate = DateTime.Parse(txtCreatedDateOld.Text);
                    string realTitle = "";
                    realTitle = DataProcessingProvider.RemoveTags(this.txtProductName.Text);
                    ProductProvider.UpdateProduct(m_ProductId, realTitle, strLead, DataProcessingProvider.RemoveTags(strSummary), strSmallimage, strLargeimage, fWeight, CreateDate, ExpiredDate, DateTime.Now, ProducedDate, true, false, chkIsHot.Checked, intPeriod, this.UserId, this.PortalId, false, iPrice, iPriceOld, strStatusProduct, iOrder, strExtendedSettings, m_strCategories, strCode, strImageAdd1, strImageAdd2, strImageAdd3, DisplayDate, straddInfo1, straddInfo2, straddInfo3, straddInfo4, straddInfo5, straddInfo6, DataProcessingProvider.RemoveTags(straddRichInfo1), DataProcessingProvider.RemoveTags(straddRichInfo2), DataProcessingProvider.RemoveTags(straddRichInfo3), m_strTags, 1);
                    result = m_ProductId;
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

                        LogProvider.InsertLogAction(result, ProductProvider.TypeId, "", this.PortalId, (int)Connection.UtilsProvider.LogAction.Update, this.UserInfo.Username, this.UserId, this.txtProductName.Text, true, m_strCategories);
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
                //this.lblError.Text = ex.GetType().ToString();
                this.lblError.Text = ex.ToString();
                this.lblError.Visible = true;
            }
        }
        protected string GetValueDynamic(string FolderName)
        {
            if (dtConfig != null && dtConfig.Rows.Count > 0)
            {
                string strData = "<DS>";
                for (int i = 0; i < dtConfig.Rows.Count; i++)
                {
                    string strName = dtConfig.Rows[i]["Name"].ToString();
                    string strTitle = dtConfig.Rows[i]["Title"].ToString();
                    string strType = dtConfig.Rows[i]["Type"].ToString().ToUpper();
                    string strWidth = dtConfig.Rows[i]["Width"].ToString();
                    switch (strType)
                    {
                        case "STRING":
                            try
                            {
                                TextBox sobjTxtTg = new TextBox();
                                sobjTxtTg = (TextBox)this.FindControl(strName);
                                strData += "<DT>";
                                strData += string.Format("<Name>{0}</Name>", strName);
                                strData += string.Format("<Type>{0}</Type>", "STRING");
                                strData += string.Format("<Value><![CDATA[{0}]]></Value>", sobjTxtTg.Text);
                                strData += "</DT>";
                            }
                            catch (Exception ex)
                            {
                                this.lblError.Text = ex.GetType().ToString();
                                this.lblError.Visible = true;
                            }
                            break;
                        case "RICHTEXT":
                            try
                            {
                                DotNetNuke.UI.WebControls.DNNRichTextEditControl rtobjTxtTg = new DotNetNuke.UI.WebControls.DNNRichTextEditControl();
                                rtobjTxtTg = (DotNetNuke.UI.WebControls.DNNRichTextEditControl)this.FindControl(strName);
                                strData += "<DT>";
                                strData += string.Format("<Name>{0}</Name>", strName);
                                strData += string.Format("<Type>{0}</Type>", "RICHTEXT");
                                strData += string.Format("<Value><![CDATA[{0}]]></Value>", DataProcessingProvider.RemoveTags(rtobjTxtTg.Value.ToString()));
                                strData += "</DT>";
                            }
                            catch (Exception ex)
                            {
                                this.lblError.Text = ex.GetType().ToString();
                                this.lblError.Visible = true;
                            }
                            break;
                        case "IMAGE":
                            try
                            {
                                HtmlInputFile iobjTxtFile = new HtmlInputFile();
                                iobjTxtFile = (HtmlInputFile)this.FindControl(strName);
                                string strImmageUrl = "";
                                if (iobjTxtFile.PostedFile.FileName.Length != 0)
                                {
                                    string strFileName = iobjTxtFile.PostedFile.FileName.Substring(iobjTxtFile.PostedFile.FileName.LastIndexOf(@"\") + 1);
                                    strImmageUrl = string.Format("{0}{1}", FolderName, strFileName);
                                    string strParentFolder = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, FolderName);
                                    FileProvider.Upload(this.PortalId, FolderName, strFileName, iobjTxtFile.PostedFile.InputStream);
                                   // FileSystemUtils.UploadFile(strParentFolder.Replace("/", @"\"), iobjTxtFile.PostedFile, false);

                                }
                                if (strImmageUrl == "")
                                {
                                    TextBox iobjTxtTg = new TextBox();
                                    iobjTxtTg = (TextBox)this.FindControl(strName + "_HIDE");
                                    strImmageUrl = iobjTxtTg.Text;
                                }
                                strData += "<DT>";
                                strData += string.Format("<Name>{0}</Name>", strName);
                                strData += string.Format("<Type>{0}</Type>", "IMAGE");
                                strData += string.Format("<Value><![CDATA[{0}]]></Value>", strImmageUrl);
                                strData += "</DT>";
                            }
                            catch (Exception ex)
                            {
                                this.lblError.Text = ex.GetType().ToString();
                                this.lblError.Visible = true;
                            }
                            break;
                        default: break;
                    }
                }
                strData += "</DS>";
                return strData;
            }
            else return "";
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

