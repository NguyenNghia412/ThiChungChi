using System.Data;
namespace TH.NUCE.Web
{
    /// <summary>
    /// Written by: Pu Pu Group - Kal Kally
    /// Content: The class for the core type: Category
    /// </summary>
    public class CategoryEx
    {
        #region Properties
        private int m_categoryId;
        private string m_name;
        private string m_description;
        private string m_toolTip;
        private int m_parentId;
        private int m_level;
        private string m_path;
        private int m_portalId;
        private bool m_isDeleted;
        private string m_defaultFolder;
        private bool m_isDefaultXSL;
        private string m_xslFile;
        private string m_icon;
        private int m_typeId;
        private bool m_isNeedPublic;
        private bool m_isNeedApprove;
        private string m_extendedSettings;
        private int m_Order;
        private int m_LanguageId;
        private string m_CultureCode;
        private bool  m_Dip1;
        private bool m_Dip2;
        private bool m_Dip3;
        private bool m_Dip4;
        private bool m_Dip5;

        private string m_AddInfo1;
        private string m_AddInfo2;
        private string m_AddInfo3;
        private string m_AddInfo4;
        private string m_AddInfo5;

        /// <summary>
        /// The core type for Category
        /// </summary>
        public string CoreType
        {
            get { return "Category"; }
        }

        /// <summary>
        /// The id of a category
        /// </summary>
        public int CategoryId
        {
            get { return m_categoryId; }
            set { m_categoryId = value; }
        }
        /// <summary>
        /// The name of a category
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        /// <summary>
        /// The description of a category
        /// </summary>
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        /// <summary>
        /// The tooltip of a category
        /// </summary>
        public string ToolTip
        {
            get { return m_toolTip; }
            set { m_toolTip = value; }
        }
        /// <summary>
        /// The parent of a category
        /// </summary>
        public int ParentId
        {
            get { return m_parentId; }
            set { m_parentId = value; }
        }
        /// <summary>
        /// A category level
        /// </summary>
        public int Level
        {
            get { return m_level; }
        }
        /// <summary>
        /// A category path
        /// </summary>
        public string Path
        {
            get { return m_path; }
        }
        /// <summary>
        /// The portal that holds this category
        /// </summary>
        public int PortalId
        {
            get { return m_portalId; }
            set { m_portalId = value; }
        }

        /// <summary>
        /// The setting that decides if this category is in recycle bin
        /// </summary>
        public bool IsDeleted
        {
            get { return m_isDeleted; }
            set { m_isDeleted = value; }
        }
        /// <summary>
        /// The default folder of this category
        /// </summary>
        public string DefaultFolder
        {
            get { return m_defaultFolder; }
            set { m_defaultFolder = value; }
        }
        /// <summary>
        /// The setting decides whether this category uses default xsl or custom xsl.
        /// </summary>
        public bool IsDefaultXSL
        {
            get { return m_isDefaultXSL; }
            set { m_isDefaultXSL = value; }
        }
        /// <summary>
        /// The setting that decides the detail xsl that this category should take.
        /// </summary>
        public string XSLFile
        {
            get { return m_xslFile; }
            set { m_xslFile = value; }
        }
        /// <summary>
        /// The icon of this category
        /// </summary>
        public string Icon
        {
            get { return m_icon; }
            set { m_icon = value; }
        }

        /// <summary>
        /// The type of this category
        /// </summary>
        public int TypeId
        {
            get { return m_typeId; }
            set { m_typeId = value; }
        }

        /// <summary>
        /// The choice to bypass censorship at public level
        /// </summary>
        public bool IsNeedPublic
        {
            get { return m_isNeedPublic; }
            set { m_isNeedPublic = value; }
        }

        /// <summary>
        /// The choice to bypass censorship at approve level
        /// </summary>
        public bool IsNeedApprove
        {
            get { return m_isNeedApprove; }
            set { m_isNeedApprove = value; }
        }

        /// <summary>
        /// The advance settings for this category
        /// </summary>
        public string ExtendedSettings
        {
            get { return m_extendedSettings; }
            set { m_extendedSettings = value; }
        }
        public int Order
        {
            get { return m_Order; }
            set { m_Order = value; }
        }
        public int LanguageId
        {
            get { return m_LanguageId; }
            set { m_LanguageId = value; }
        }
        public string CultureCode
        {
            get { return m_CultureCode; }
            set { m_CultureCode = value; }
        }
        public bool Dip1
        {
            get { return m_Dip1; }
            set { m_Dip1 = value; }
        }
        public bool Dip2
        {
            get { return m_Dip2; }
            set { m_Dip2 = value; }
        }
        public bool Dip3
        {
            get { return m_Dip3; }
            set { m_Dip3 = value; }
        }
        public bool Dip4
        {
            get { return m_Dip4; }
            set { m_Dip4 = value; }
        }
        public bool Dip5
        {
            get { return m_Dip5; }
            set { m_Dip5 = value; }
        }

        public string AddInfo1
        {
            get { return m_AddInfo1; }
            set { m_AddInfo1 = value; }
        }
        public string AddInfo2
        {
            get { return m_AddInfo2; }
            set { m_AddInfo2 = value; }
        }
        public string AddInfo3
        {
            get { return m_AddInfo3; }
            set { m_AddInfo3 = value; }
        }
        public string AddInfo4
        {
            get { return m_AddInfo4; }
            set { m_AddInfo4 = value; }
        }
        public string AddInfo5
        {
            get { return m_AddInfo5; }
            set { m_AddInfo5 = value; }
        }
        #endregion

        #region Intitialization

        /// <summary>
        /// Initialize the class with no information. 
        /// </summary>
        public CategoryEx()
        {
            FillEmpty();
        }

        /// <summary>
        /// Intitialize the class with information stored in database.
        /// </summary>
        /// <param name="categoryId"></param>
        public CategoryEx(int categoryId)
        {
            //CategoryId.this.CategoryId = categoryId;
            Fill(categoryId);
        }


        /// <summary>
        /// Intitialize the class with custom information
        /// </summary>
        /// <param name="categoryId">The id of the category</param>
        /// <param name="name">The name of the category</param>
        /// <param name="description">The description of the category</param>
        /// <param name="toolTip">The toolTip of the category</param>
        /// <param name="parentId">The parent category of the category</param>
        /// <param name="portalId">The portal of the category</param>
        /// <param name="isDeleted">The setting that decides if this category is in recycle bin</param>
        /// <param name="defaultFolder">The default folder of this category</param>
        /// <param name="isDefaultXSL">The setting decides whether this category uses default xsl or custom xsl.</param>
        /// <param name="XSLFile">The setting that decides the detail xsl that this category should take.</param>
        /// <param name="icon">The icon of the category</param>
        /// <param name="typeId">The type of this category</param>
        /// <param name="isNeedApprove">The choice to bypass censorship at approve level</param>
        /// <param name="isNeedPublic">The choice to bypass censorship at public level</param>
        /// <param name="extendedSettings">The advance settings for this category</param>
        /// <param name="dpGroups">a string that holds the ids of the dynamic groups that should associate with this category</param>
        public CategoryEx(int categoryId, string name, string description, string toolTip, int parentId, int portalId, bool isDeleted, string defaultFolder,
            bool isDefaultXSL, string XSLFile, string icon, int typeId, bool isNeedApprove, bool isNeedPublic, string extendedSettings,int order, int languageId, string cultureCode
            , bool dip1, bool dip2, bool dip3, bool dip4, bool dip5, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            this.CategoryId = categoryId;
            this.Name = name;
            this.Description = description;
            this.ToolTip = toolTip;
            this.ParentId = parentId;
            this.PortalId = portalId;
            this.IsDeleted = isDeleted;
            this.DefaultFolder = defaultFolder;
            this.IsDefaultXSL = isDefaultXSL;
            this.XSLFile = XSLFile;
            this.Icon = icon;
            this.TypeId = typeId;
            this.IsNeedPublic = isNeedPublic;
            this.IsNeedApprove = isNeedApprove;
            this.ExtendedSettings = extendedSettings;
            this.m_Order=order;
            this.m_LanguageId=languageId;
            this.m_CultureCode=cultureCode;
            this.m_Dip1=dip1;
            this.m_Dip2=dip2;
            this.m_Dip3=dip3;
            this.m_Dip4=dip4;
            this.m_Dip5=dip5;
            this.AddInfo1 = addInfo1;
            this.AddInfo2 = addInfo2;
            this.AddInfo3 = addInfo3;
            this.AddInfo4 = addInfo4;
            this.AddInfo5 = addInfo5;
        }

        public int FillEmpty()
        {
            this.Name = "";
            this.ToolTip = "";
            this.ParentId = -1;
            m_level = 0;
            m_path = "";
            this.PortalId = -1;
            this.IsDeleted = true;
            this.DefaultFolder = "";
            this.IsDefaultXSL = true;
            this.XSLFile = "";
            this.Icon = "";
            this.Description = "";
            this.TypeId = -1;
            this.IsNeedApprove = true;
            this.IsNeedPublic = true;
            this.ExtendedSettings = "";
            this.Order=-1;
            this.LanguageId=-1;
            this.CultureCode="vi-VN";
            this.Dip1=m_Dip1;
            this.Dip2 = m_Dip2;
            this.Dip3 = m_Dip3;
            this.Dip4 = m_Dip4;
            this.Dip5 = m_Dip5;
            this.AddInfo1 = m_AddInfo1;
            this.AddInfo2 = m_AddInfo2;
            this.AddInfo3 = m_AddInfo3;
            this.AddInfo4 = m_AddInfo4;
            this.AddInfo5 = m_AddInfo5;
            return -1;
        }

        /// <summary>
        /// Fill this category with information from the database.
        /// </summary>
        public int Fill(int categoryId)
        {
            
            DataTable tblUnit = CategoryExtProvider.CM_GetCategory(categoryId);
            if (tblUnit.Rows.Count > 0)
            {
                this.CategoryId = categoryId;
                this.Name = tblUnit.Rows[0]["Name"].ToString();
                this.ToolTip = tblUnit.Rows[0]["ToolTip"].ToString();
                this.ParentId = int.Parse(tblUnit.Rows[0]["ParentId"].ToString());
                m_level = int.Parse(tblUnit.Rows[0]["Level"].ToString());
                m_path = tblUnit.Rows[0]["Path"].ToString();
                this.PortalId = int.Parse(tblUnit.Rows[0]["PortalId"].ToString());
                this.IsDeleted = bool.Parse(tblUnit.Rows[0]["IsDeleted"].ToString());
                this.DefaultFolder = tblUnit.Rows[0]["defaultFolder"].ToString();
                this.IsDefaultXSL = bool.Parse(tblUnit.Rows[0]["IsDefaultXSL"].ToString());
                this.XSLFile = tblUnit.Rows[0]["XSLFile"].ToString();
                this.Icon = tblUnit.Rows[0]["Icon"].ToString();
                this.Description = tblUnit.Rows[0]["Description"].ToString();
                this.TypeId = int.Parse(tblUnit.Rows[0]["TypeId"].ToString());
                this.IsNeedApprove = bool.Parse(tblUnit.Rows[0]["IsNeedApprove"].ToString());
                this.IsNeedPublic = bool.Parse(tblUnit.Rows[0]["IsNeedPublic"].ToString());
                this.ExtendedSettings = tblUnit.Rows[0]["ExtendedSettings"].ToString();
                this.m_Order = int.Parse(tblUnit.Rows[0]["Order"].ToString());
                this.m_LanguageId = int.Parse(tblUnit.Rows[0]["LanguageId"].ToString());
                this.m_CultureCode = tblUnit.Rows[0]["CultureCode"].ToString();
                this.m_Dip1 = bool.Parse(tblUnit.Rows[0]["Dip1"].ToString());
                this.m_Dip2 = bool.Parse(tblUnit.Rows[0]["Dip2"].ToString());
                this.m_Dip3 = bool.Parse(tblUnit.Rows[0]["Dip3"].ToString());
                this.m_Dip4 = bool.Parse(tblUnit.Rows[0]["Dip4"].ToString());
                this.m_Dip5 = bool.Parse(tblUnit.Rows[0]["Dip5"].ToString());
                this.m_AddInfo1 = tblUnit.Rows[0]["AddInfo1"].ToString();
                this.m_AddInfo2 = tblUnit.Rows[0]["AddInfo2"].ToString();
                this.m_AddInfo3 = tblUnit.Rows[0]["AddInfo3"].ToString();
                this.m_AddInfo4 = tblUnit.Rows[0]["AddInfo4"].ToString();
                this.m_AddInfo5 = tblUnit.Rows[0]["AddInfo5"].ToString();
                
                return this.CategoryId;
            }
            else
            {
                FillEmpty();
                return -1;
            }
        }

        /// <summary>
        /// Put the current category into the recycle bin.
        /// </summary>
        public void Delete(int userId)
        {
            CategoryExtProvider.CM_DeleteCategory(this.CategoryId, this.PortalId, 1);            
        }

        /// <summary>
        /// Delete the current category permanently.
        /// </summary>
        public void Remove(int userId)
        {
            CategoryExtProvider.CM_DeleteCategory(this.CategoryId, this.PortalId, 0);
        }

        /// <summary>
        /// Insert this current category.
        /// </summary>
        /// <returns>Return the new category id if success, -1 if the name already exists, -2 if parent not found.</returns>
        public int Insert(int userId)
        {
            int result;
            result = CategoryExtProvider.CM_InsertCategory(this.PortalId, this.Name, this.Description, this.ToolTip, this.IsDefaultXSL, this.XSLFile, this.Icon, this.ParentId, this.DefaultFolder, this.TypeId, this.IsNeedPublic, this.IsNeedApprove, this.ExtendedSettings, this.Order, this.LanguageId, this.CultureCode, this.Dip1, this.Dip2, this.Dip3, this.Dip4, this.Dip5, this.AddInfo1, this.AddInfo2, this.AddInfo3, this.AddInfo4, this.AddInfo5);

            //If insert successfully, start to update related categories.
            if (result != -1 && this.ParentId != -1)
            {
                string strOldRelatedString;
                int i;
                DataTable tblRelated;
                tblRelated = CategoryExtProvider.CM_GetChildrenCategories(this.ParentId);
                strOldRelatedString = ",";
                if (tblRelated.Rows.Count > 0)
                {
                    for (i = 0; i < tblRelated.Rows.Count; i++)
                    {
                        strOldRelatedString = strOldRelatedString + tblRelated.Rows[i]["CategoryId"].ToString() + ",";
                    }
                }
                CategoryExtProvider.CM_UpdateRelatedCategory(result, PortalId, strOldRelatedString);
            }

            return result;
        }

        /// <summary>
        /// Update this current category.
        /// </summary>
        /// <returns>Return 1 if success, -1 if category not found. -2 if the name already exists, -3 if parent not found.</returns>
        public int Update(int userId)
        {
            int result;
            result = CategoryExtProvider.CM_UpdateCategory(this.CategoryId, this.PortalId, this.Name, this.Description, this.ToolTip, this.IsDefaultXSL, this.XSLFile, this.Icon, this.ParentId, this.DefaultFolder, this.IsNeedPublic, this.IsNeedApprove, this.ExtendedSettings, this.Order, this.LanguageId, this.CultureCode, this.Dip1, this.Dip2, this.Dip3, this.Dip4, this.Dip5, this.AddInfo1, this.AddInfo2, this.AddInfo3, this.AddInfo4, this.AddInfo5);
            //If update successfully, start to change the related categories.
            if (this.CategoryId != -1 && this.ParentId != -1)
            {
                string strOldRelatedString;
                int i;
                DataTable tblRelated;
                tblRelated = CategoryExtProvider.CM_GetChildrenCategories(this.ParentId);
                strOldRelatedString = ",";
                if (tblRelated.Rows.Count > 0)
                {
                    for (i = 0; i < tblRelated.Rows.Count; i++)
                    {
                        strOldRelatedString = strOldRelatedString + tblRelated.Rows[i]["CategoryId"].ToString() + ",";
                    }
                }
                CategoryExtProvider.CM_InsertRelatedCategory(this.CategoryId, PortalId, strOldRelatedString);
            }
            return result;
        }

        /// <summary>
        /// Copy the information of the current category into a new one.
        /// </summary>
        /// <param name="strNewTitle">The title for the new category</param>
        /// <param name="strNewDescription">The description for the new category</param>
        /// <param name="userId">The action owner</param>
        /// <returns>Return the new category id if success, -1 if the name already exists, -2 if parent not found.</returns>
        public int Copy(string strNewTitle, string strNewDescription, int userId)
        {
            int newId, i;
            int sampleId;
            string strOldRelatedString = "";
            sampleId = this.CategoryId;
            //Change the current category into -1
            this.CategoryId = -1;
            this.Name = strNewTitle;
            if (strNewDescription != "")
            {
                this.Description = strNewDescription;
            }
            //Insert a new category with the information of the sample one
            newId = Insert(userId);
            if (newId > 0)
            {
                //Copy roles
                CategoryExtProvider.CM_CopyCategoryRoles(sampleId, newId);
                //Copy tag groups
                CategoryExtProvider.CM_CopyCategoryTagGroups(sampleId, newId);
                DataTable tblRelated;

                //Copy related categories
                tblRelated = CategoryExtProvider.CM_GetRelatedCategories(sampleId, TypeId);
                strOldRelatedString = ",";
                strOldRelatedString = strOldRelatedString + sampleId.ToString() + ",";
                if (tblRelated.Rows.Count > 0)
                {
                    for (i = 0; i < tblRelated.Rows.Count; i++)
                    {
                        strOldRelatedString = strOldRelatedString + tblRelated.Rows[i]["CategoryId"].ToString() + ",";
                    }
                }
                CategoryExtProvider.CM_UpdateRelatedCategory(newId, PortalId, strOldRelatedString);
            }
            // Change the current category back to its old information.
            this.CategoryId = sampleId;
            return newId;
        }
        #endregion
    }
}