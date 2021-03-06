using System.Data;
namespace TH.NUCE.Web
{

    public class CoreType
    {
        private int m_typeId;
        private string m_typeName;
        private string m_roleString;
        private TypeRoleCollection m_objCollection;
        private bool m_isUseXSL;
        private bool m_isUseFolder;
        private bool m_isUseToolTip;
        private bool m_isUseApprove;
        private bool m_isUsePublic;
        private bool m_isUseIcon;
        private bool m_isValid;
        private bool m_isUseTagGroup;
        private bool m_isUseRelated;
        private bool m_isUseRecycleBin;

        public int TypeId
        {
            get { return m_typeId; }
            set { m_typeId = value; }
        }

        public string TypeName
        {
            get { return m_typeName; }
        }

        public string RoleString
        {
            get { return m_roleString; }
        }

        public TypeRoleCollection RoleCollection
        {
            get { return m_objCollection; }
        }

        public bool IsUseXSL
        {
            get { return m_isUseXSL; }
        }

        public bool IsUseFolder
        {
            get { return m_isUseFolder; }
        }

        public bool IsUseToolTip
        {
            get { return m_isUseToolTip; }
        }

        public bool IsUseApprove
        {
            get { return m_isUseApprove; }
        }

        public bool IsUsePublic
        {
            get { return m_isUsePublic; }
        }

        public bool IsUseIcon
        {
            get { return m_isUseIcon; }
        }


        public bool IsValid
        {
            get { return m_isValid; }
        }

        public bool IsUseTagGroup
        {
            get { return m_isUseTagGroup; }
        }

        public bool IsUseRelated
        {
            get { return m_isUseRelated; }
        }

        public bool IsUseRecycleBin
        {
            get { return m_isUseRecycleBin; }
        }

        #region Constructor

        public CoreType(int typeId)
        {
            DataTable objTable = CoreBase.TL_GetTypeFull(typeId);
            if (objTable.Rows.Count > 0)
            {
                m_typeId = typeId;
                m_isValid = true;
                m_typeName = objTable.Rows[0]["TypeName"].ToString();
                m_roleString = objTable.Rows[0][2].ToString();
                m_objCollection = new TypeRoleCollection(m_roleString);
                m_isUseXSL = "true".Equals(objTable.Rows[0]["IsUseXSL"].ToString().ToLower());
                m_isUseFolder = "true".Equals(objTable.Rows[0]["IsUseFolder"].ToString().ToLower());
                m_isUseToolTip = "true".Equals(objTable.Rows[0]["IsUseToolTip"].ToString().ToLower());
                m_isUseApprove = "true".Equals(objTable.Rows[0]["IsUseApprove"].ToString().ToLower());
                m_isUsePublic = "true".Equals(objTable.Rows[0]["IsUsePublic"].ToString().ToLower());
                m_isUseIcon = "true".Equals(objTable.Rows[0]["IsUseIcon"].ToString().ToLower());
                m_isUseTagGroup = "true".Equals(objTable.Rows[0]["IsUseTagGroup"].ToString().ToLower());
                m_isUseRelated = "true".Equals(objTable.Rows[0]["IsUseRelated"].ToString().ToLower());
                m_isUseRecycleBin = "true".Equals(objTable.Rows[0]["IsUseRecycleBin"].ToString().ToLower());
            }
            else
            {

            }
        }
        #endregion
    }
}