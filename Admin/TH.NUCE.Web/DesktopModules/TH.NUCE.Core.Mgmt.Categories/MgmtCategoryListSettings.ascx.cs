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
namespace TH.NUCE.Web
{
    public partial class MgmtCategoryListSettings : CoreModuleSettings
    {
        #region Public Members & Properties
        public const int TYPE_ID = -1;
        public const string TYPE_INCLUDE = ",1,2,3,4,5,6,7,8,";
        public const string TYPE_RETURN = ",1-372,2-757,3-0,4-638,5-637,6-639,7-0,8-0,";
        public const int RECYCLE_BIN_LINK = -1;
        public const int RELATED_LINK = -1;
        public const int TAG_GROUP_LINK = -1;

        public const string TYPE_ID_KEY = "TypeId";
        public const string RECYCLE_BIN_LINK_KEY = "RecycleBinLink";
        public const string RELATED_LINK_KEY = "RelatedLink";
        public const string TAG_GROUP_LINK_KEY = "TagGroupLink";
        public const string TYPE_INCLUDE_KEY = "TYPE_INCLUDE_KEY";
        public const string TYPE_RETURN_KEY = "TYPE_RETURN_KEY";


        //Show Option
        public const string IS_SHOW_DIP1 = "IS_SHOW_DIP1";
        public const string IS_SHOW_DIP2 = "IS_SHOW_DIP2";
        public const string IS_SHOW_DIP3 = "IS_SHOW_DIP3";
        public const string IS_SHOW_DIP4 = "IS_SHOW_DIP4";
        public const string IS_SHOW_DIP5 = "IS_SHOW_DIP5";

        //Alt Text 
        public const string ALT_SOURCE_DIP1 = "ALT_SOURCE_DIP1";
        public const string ALT_SOURCE_DIP2 = "ALT_SOURCE_DIP2";
        public const string ALT_SOURCE_DIP3 = "ALT_SOURCE_DIP3";
        public const string ALT_SOURCE_DIP4 = "ALT_SOURCE_DIP4";
        public const string ALT_SOURCE_DIP5 = "ALT_SOURCE_DIP5";

        private int m_typeId;
        private int m_recyleBinLink;
        private int m_relatedLink;
        private int m_tagGroupLink;
        private string m_typeInclude;
        private string m_typeReturn;

        private bool m_isShowDip1;
        private bool m_isShowDip2;
        private bool m_isShowDip3;
        private bool m_isShowDip4;
        private bool m_isShowDip5;

        private string m_altSourceDip1;
        private string m_altSourceDip2;
        private string m_altSourceDip3;
        private string m_altSourceDip4;
        private string m_altSourceDip5;
        
        #endregion

        #region Private Methods

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!this.Page.IsPostBack)
            {
                cboType.Items.Clear();
                cboType.DataSource = UtilityProvider.GetCoreType();
                cboType.DataTextField = "TypeName";
                cboType.DataValueField = "TypeId";

                cboRecycleBin.Items.Clear();
                cboRecycleBin.DataSource = DataProcessingProvider.ProcessDataTable(UtilityProvider.GetTabs(this.PortalId, -1), 1, 2);
                cboRecycleBin.DataTextField = "TabName";
                cboRecycleBin.DataValueField = "TabId";

                cboRelated.Items.Clear();
                cboRelated.DataSource = DataProcessingProvider.ProcessDataTable(UtilityProvider.GetTabs(this.PortalId, -1), 1, 2);
                cboRelated.DataTextField = "TabName";
                cboRelated.DataValueField = "TabId";

                cboTypeGroup.Items.Clear();
                cboTypeGroup.DataSource = DataProcessingProvider.ProcessDataTable(UtilityProvider.GetTabs(this.PortalId, -1), 1, 2);
                cboTypeGroup.DataTextField = "TabName";
                cboTypeGroup.DataValueField = "TabId";

                DataBind();
                ListItem li=new ListItem();
                li.Text="All";
                li.Value="-1";
                cboType.Items.Insert(0,li);
                
                cboType.SelectedValue = m_typeId.ToString();
                cboRecycleBin.SelectedValue = m_recyleBinLink.ToString();
                cboRelated.SelectedValue = m_relatedLink.ToString();
                cboTypeGroup.SelectedValue = m_tagGroupLink.ToString();
                txtTypeInclude.Text=m_typeInclude;
                txtTypeReturn.Text = m_typeReturn;


                #region Load Show Choice & Alt Text

                //Load show choice
                this.chkDip1.Checked = m_isShowDip1;
                this.chkDip2.Checked = m_isShowDip1;
                this.chkDip3.Checked = m_isShowDip1;
                this.chkDip4.Checked = m_isShowDip1;
                this.chkDip5.Checked = m_isShowDip1;

                //Load alt text
                this.txtDip1.Text = m_altSourceDip1;
                this.txtDip2.Text = m_altSourceDip2;
                this.txtDip3.Text = m_altSourceDip3;
                this.txtDip4.Text = m_altSourceDip4;
                this.txtDip5.Text = m_altSourceDip5;
                #endregion
            }
        }
        #endregion

        #region Public Methods
        public override void LoadSettings()
        {
            try
            {
                base.LoadSettings();

                EnsureChildControls();
                int i;

                if (ModuleSettings[TYPE_ID_KEY] == null || !int.TryParse(ModuleSettings[TYPE_ID_KEY].ToString(), out i))
                { m_typeId = TYPE_ID; }
                else
                { m_typeId = int.Parse(ModuleSettings[TYPE_ID_KEY].ToString()); }

                if (ModuleSettings[TYPE_INCLUDE_KEY] == null)
                { m_typeInclude = TYPE_INCLUDE; }
                else
                { m_typeInclude = ModuleSettings[TYPE_INCLUDE_KEY].ToString(); }

                if (ModuleSettings[TYPE_RETURN_KEY] == null)
                { m_typeReturn = TYPE_RETURN; }
                else
                { m_typeReturn = ModuleSettings[TYPE_RETURN_KEY].ToString(); }

                if (ModuleSettings[RELATED_LINK_KEY] == null || !int.TryParse(ModuleSettings[RELATED_LINK_KEY].ToString(), out i))
                { m_relatedLink = RELATED_LINK; }
                else
                { m_relatedLink = int.Parse(ModuleSettings[RELATED_LINK_KEY].ToString()); }

                if (ModuleSettings[RECYCLE_BIN_LINK_KEY] == null || !int.TryParse(ModuleSettings[RECYCLE_BIN_LINK_KEY].ToString(), out i))
                { m_recyleBinLink = RECYCLE_BIN_LINK; }
                else
                { m_recyleBinLink = int.Parse(ModuleSettings[RECYCLE_BIN_LINK_KEY].ToString()); }

                if (ModuleSettings[TAG_GROUP_LINK_KEY] == null || !int.TryParse(ModuleSettings[TAG_GROUP_LINK_KEY].ToString(), out i))
                { m_tagGroupLink = TAG_GROUP_LINK; }
                else
                { m_tagGroupLink = int.Parse(ModuleSettings[TAG_GROUP_LINK_KEY].ToString()); }

                #region Load Show Choices & Alt Text
                //Load show choices
                m_isShowDip1 = LoadBaseTrueSetting(IS_SHOW_DIP1);
                m_isShowDip2 = LoadBaseTrueSetting(IS_SHOW_DIP2);
                m_isShowDip3 = LoadBaseTrueSetting(IS_SHOW_DIP3);
                m_isShowDip4 = LoadBaseTrueSetting(IS_SHOW_DIP4);
                m_isShowDip5 = LoadBaseTrueSetting(IS_SHOW_DIP5);
                //Load alt text
                m_altSourceDip1 = LoadStringSetting(ALT_SOURCE_DIP1, ALT_SOURCE_DIP1);
                m_altSourceDip2 = LoadStringSetting(ALT_SOURCE_DIP2, ALT_SOURCE_DIP2);
                m_altSourceDip3 = LoadStringSetting(ALT_SOURCE_DIP3, ALT_SOURCE_DIP3);
                m_altSourceDip4 = LoadStringSetting(ALT_SOURCE_DIP4, ALT_SOURCE_DIP4);
                m_altSourceDip5 = LoadStringSetting(ALT_SOURCE_DIP5, ALT_SOURCE_DIP5);
                #endregion
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
                lblError.Visible = true;
            }

        }

        public override void UpdateSettings()
        {


            //m_intDefaultArticleID = int.Parse(cboArticle.SelectedValue);

            m_typeId = int.Parse(cboType.SelectedValue);
            m_typeInclude=txtTypeInclude.Text;
            m_typeReturn=txtTypeReturn.Text;
            m_recyleBinLink = int.Parse(cboRecycleBin.SelectedValue);
            m_relatedLink = int.Parse(cboRelated.SelectedValue);
            m_tagGroupLink = int.Parse(cboTypeGroup.SelectedValue);

            //Get Show Choice
            m_isShowDip1 = this.chkDip1.Checked;
            m_isShowDip2 = this.chkDip2.Checked;
            m_isShowDip3 = this.chkDip3.Checked;
            m_isShowDip4 = this.chkDip4.Checked;
            m_isShowDip5 = this.chkDip5.Checked;

            //Get Alt text
            m_altSourceDip1 = this.txtDip1.Text;
            m_altSourceDip2 = this.txtDip2.Text;
            m_altSourceDip3 = this.txtDip3.Text;
            m_altSourceDip4 = this.txtDip4.Text;
            m_altSourceDip5 = this.txtDip5.Text;

            EnsureChildControls();
            ModuleController objModController = new ModuleController();

            //Update DisplayTabID

            objModController.UpdateModuleSetting(this.ModuleId, RECYCLE_BIN_LINK_KEY, m_recyleBinLink.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, TAG_GROUP_LINK_KEY, m_tagGroupLink.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, RELATED_LINK_KEY, m_relatedLink.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, TYPE_ID_KEY, m_typeId.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, TYPE_INCLUDE_KEY, m_typeInclude);
            objModController.UpdateModuleSetting(this.ModuleId, TYPE_RETURN_KEY, m_typeReturn);

            //Update Show choices
            objModController.UpdateModuleSetting(this.ModuleId, IS_SHOW_DIP1, m_isShowDip1.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, IS_SHOW_DIP2, m_isShowDip2.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, IS_SHOW_DIP3, m_isShowDip3.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, IS_SHOW_DIP4, m_isShowDip4.ToString());
            objModController.UpdateModuleSetting(this.ModuleId, IS_SHOW_DIP5, m_isShowDip5.ToString());

            //Update Alt Text
            objModController.UpdateModuleSetting(this.ModuleId, ALT_SOURCE_DIP1, m_altSourceDip1);
            objModController.UpdateModuleSetting(this.ModuleId, ALT_SOURCE_DIP2, m_altSourceDip2);
            objModController.UpdateModuleSetting(this.ModuleId, ALT_SOURCE_DIP3, m_altSourceDip3);
            objModController.UpdateModuleSetting(this.ModuleId, ALT_SOURCE_DIP4, m_altSourceDip4);
            objModController.UpdateModuleSetting(this.ModuleId, ALT_SOURCE_DIP5, m_altSourceDip5);
            ModuleController.SynchronizeModule(this.ModuleId);
            base.UpdateSettings();
        }

        #endregion

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
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