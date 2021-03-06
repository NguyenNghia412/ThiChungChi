namespace TH.NUCE.Web
{

    public class TypeRoleCollection
    {
        #region Private Variable
        private bool m_isUseCreate;
        private bool m_isUseEditAll;
        private bool m_isUseEditAfter;
        private bool m_isUseDelete;
        private bool m_isUseApprove;
        private bool m_isUsePublic;
        private bool m_isUseUnstate;
        private bool m_isUseView;
        private bool m_isUseRead;
        private bool m_isUseManage;
        #endregion

        #region Public Variable
        public bool IsUseCreate
        {
            get { return m_isUseCreate; }
            set { m_isUseCreate = value; }
        }

        public bool IsUseEditAll
        {
            get { return m_isUseEditAll; }
            set { m_isUseEditAll = value; }
        }

        public bool IsUseEditAfter
        {
            get { return m_isUseEditAfter; }
            set { m_isUseEditAfter = value; }
        }

        public bool IsUseDelete
        {
            get { return m_isUseDelete; }
            set { m_isUseDelete = value; }
        }

        public bool IsUseApprove
        {
            get { return m_isUseApprove; }
            set { m_isUseApprove = value; }
        }

        public bool IsUsePublic
        {
            get { return m_isUsePublic; }
            set { m_isUsePublic = value; }
        }

        public bool IsUseUnstate
        {
            get { return m_isUseUnstate; }
            set { m_isUseUnstate = value; }
        }

        public bool IsUseView
        {
            get { return m_isUseView; }
            set { m_isUseView = value; }
        }

        public bool IsUseRead
        {
            get { return m_isUseRead; }
            set { m_isUseRead = value; }
        }

        public bool IsUseManage
        {
            get { return m_isUseManage; }
            set { m_isUseManage = value; }
        }


        #endregion

        #region Constructor
        public TypeRoleCollection(string strRoles)
        {
            if(strRoles.Contains(",1,")) m_isUseCreate = true;
            if(strRoles.Contains(",2,")) m_isUseEditAll = true;
            if(strRoles.Contains(",3,")) m_isUseEditAfter = true;
            if(strRoles.Contains(",4,")) m_isUseDelete = true;
            if(strRoles.Contains(",5,")) m_isUseApprove = true;
            if(strRoles.Contains(",6,")) m_isUsePublic = true;
            if(strRoles.Contains(",7,")) m_isUseUnstate = true;
            if(strRoles.Contains(",8,")) m_isUseView = true;
            if(strRoles.Contains(",9,")) m_isUseRead = true;
            if(strRoles.Contains(",10,")) m_isUseManage = true;
        }

        #endregion
    }
}