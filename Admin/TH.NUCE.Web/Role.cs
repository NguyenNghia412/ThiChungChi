using System.Data;

namespace TH.NUCE.Web
{
    public class Role 
    {
        #region public & private members
        private DataTable m_objTable;
        private string m_strRoles;
        private bool m_isManage;

        public string StrManageRoles
        {
            get
            {
                return ",1,2,3,4,5,6,7,";
            }
        }

        public string StrEditRoles
        {
            get
            {
                return ",1,2,3,";
            }
        }

        public string RoleString
        {
            get
            {
                return m_strRoles;
            }
        }

        public bool IsManage
        {
            get
            {
                return m_isManage;
            }
        }
        #endregion

        #region initilization

        public Role(int userId, int itemId, bool isSuperUser, int portalId, int typeId)
        {
            m_objTable = CoreBase.RM_GetUserRolesByItem(userId, itemId, isSuperUser, portalId, typeId);
            m_strRoles = GetRoleString();
        }

        public Role(int userId, bool isSuperUser, int portalId, int typeId)
        {
            m_objTable = CoreBase.RM_GetUserRolesByPortal(userId, isSuperUser, portalId, typeId);
            m_strRoles = GetRoleString();
        }

        public Role(int userId, bool isSuperUser, int portalId, int categoryId, bool isCategory)
        {
            m_objTable = CoreBase.RM_GetUserRolesByCategory(userId, isSuperUser, portalId, categoryId);
            m_strRoles = GetRoleString();
        }

        #endregion

        #region functions
        private string GetRoleString()
        {
            string strResult;

            m_isManage = false;
            if (m_objTable.Rows.Count == 0)
            {
                strResult = "";
            }
            else
            {
                int i;
                strResult = ",";
                int roleId;
                for (i = 0; i < m_objTable.Rows.Count; i++)
                {
                    roleId = DataProcessingProvider.GetProcessedInt(m_objTable.Rows[i][0].ToString());
                    if (roleId != -1)
                    {
                        if (StrManageRoles.Contains(roleId.ToString()))
                        {
                            m_isManage = true;
                        }
                        strResult = strResult + m_objTable.Rows[i][0].ToString() + ",";
                    }
                }
                if (strResult == ",")
                {
                    strResult = "";
                }
            }
            return strResult;
        }

        public bool HasRole(int CMSRoleId)
        {
            if (m_strRoles.Contains(string.Format(",{0},", CMSRoleId.ToString())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}