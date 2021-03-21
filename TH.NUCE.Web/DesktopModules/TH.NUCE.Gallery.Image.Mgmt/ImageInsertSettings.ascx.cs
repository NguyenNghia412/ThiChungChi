using System;
using System.Collections;
using System.Web.UI.WebControls;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.FileSystem;

namespace TH.NUCE.Web
{
    public partial class ImageInsertSettings : CoreModuleSettings
    {
        #region Public Members
        public const string FOLDER_IMAGE_DEFAULT = "";
        public const string FOLDER_IMAGE_KEY = "ImageFolder";
        
        //Alt Text 
        public const string EXTENSTION_VALUE_DEFAULT="rar,zip";
        public const string EXTENSTION_KEY = "EXTENSTION_KEY";

        //Link Upload image 
        public const string LINKUPLOAD_VALUE_DEFAULT = "/";
        public const string LINKUPLOAD_KEY = "LINKUPLOAD_KEY";
        #endregion

        #region Private Members
        private string m_strImageFolder;
        private string m_strExtension;
        private string m_linkupload;

        #endregion


        #region Private Methods

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!this.Page.IsPostBack)
            {
                #region Load default folder
                cboFolders.Items.Clear();
                ArrayList arrFolders = FileSystemUtils.GetFolders(this.PortalId);
                foreach (FolderInfo objFolder in arrFolders)
                {
                    ListItem objFolderItem = new ListItem();
                    if (objFolder.FolderPath.Length == 0)
                        objFolderItem.Text = "Root";
                    else
                    {
                        objFolderItem.Text = objFolder.FolderPath;
                    }
                    objFolderItem.Value = objFolder.FolderPath;
                    cboFolders.Items.Add(objFolderItem);
                }
                cboFolders.DataBind();
                cboFolders.SelectedValue = m_strImageFolder;
                #endregion
                #region Load Show Choice & Alt Text
                this.txtExtension.Text = m_strExtension;
                this.txtLinkUpload.Text = m_linkupload;

                #endregion

            }
        }
        #endregion

        #region Public Methods

        public override void LoadSettings()
        {
            base.LoadSettings();

            EnsureChildControls();
            #region Load Image, Return Type, Variable, Order, Tag
            //Load image
            m_strImageFolder = (string)ModuleSettings[FOLDER_IMAGE_KEY];
            if (m_strImageFolder == null || m_strImageFolder.Length == 0)
                m_strImageFolder = FOLDER_IMAGE_DEFAULT;

            string strFolderPath = string.Format("{0}{1}", PortalSettings.HomeDirectoryMapPath, m_strImageFolder);
            if (!System.IO.Directory.Exists(strFolderPath))
                m_strImageFolder = FOLDER_IMAGE_DEFAULT;



            #endregion
            #region Load Show Choices & Alt Text
            m_strExtension = LoadStringSetting(EXTENSTION_KEY, EXTENSTION_VALUE_DEFAULT);
            m_linkupload = LoadStringSetting(LINKUPLOAD_KEY, LINKUPLOAD_VALUE_DEFAULT);
            #endregion

        }

        public override void UpdateSettings()
        {

            #region Get Value
            //Get default folder
            m_strImageFolder = cboFolders.SelectedValue;

            m_strExtension = this.txtExtension.Text;
            m_linkupload = txtLinkUpload.Text;
            #endregion

            #region UpdateValue
            EnsureChildControls();
            ModuleController objModController = new ModuleController();


            //Update Folder
            objModController.UpdateModuleSetting(this.ModuleId, FOLDER_IMAGE_KEY, m_strImageFolder);


            objModController.UpdateModuleSetting(this.ModuleId, EXTENSTION_KEY, m_strExtension);

            objModController.UpdateModuleSetting(this.ModuleId, LINKUPLOAD_KEY, m_linkupload);

            ModuleController.SynchronizeModule(this.ModuleId);
            base.UpdateSettings();
            #endregion
        }

        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion
    }
}