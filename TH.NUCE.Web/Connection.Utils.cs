using DotNetNuke.Framework.Providers;
using System.Configuration;
namespace TH.NUCE.Connection
{

    public class Utils
    {
        #region Fields & Properties & Consts

        private const string PROVIDER_TYPE = "data";
        private ProviderConfiguration m_objProviderConfig = ProviderConfiguration.GetProviderConfiguration(PROVIDER_TYPE);
        private string m_strProviderPath;
        private string m_strObjectQualifier;
        private string m_strDatabaseOwner;
        private string m_strConnection;

        public string StrConnection
        {
            get { return m_strConnection; }
        }
        public string StrDatabaseOwner
        {
            get { return m_strDatabaseOwner; }
        }
        public string StrObjectQualifier
        {
            get { return m_strObjectQualifier; }
        }

        #endregion

        #region Constructors

        public Utils()
        {
            // Read the configuration specific information for this provider.
            Provider objProvider = (Provider)m_objProviderConfig.Providers[m_objProviderConfig.DefaultProvider];

            // Read the attribute for this provider.
            if ((objProvider.Attributes["connectionStringName"] != "") &&
            (ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]] != ""))
            {
                m_strConnection = ConfigurationManager.AppSettings[objProvider.Attributes["connectionStringName"]];
            }
            else
            {
                m_strConnection = objProvider.Attributes["connectionString"];
            }

            m_strProviderPath = objProvider.Attributes["providerPath"];

            m_strObjectQualifier = objProvider.Attributes["objectQualifier"];
            if (m_strObjectQualifier != null && !m_strObjectQualifier.EndsWith("_"))
                m_strObjectQualifier += "_";


            m_strDatabaseOwner = objProvider.Attributes["databaseOwner"];
            if (m_strDatabaseOwner != null && !m_strDatabaseOwner.EndsWith("."))
                m_strDatabaseOwner += ".";
        }

        public Utils(string connectionString, string databaseOwner, string objectQualifier)
        {
            //Lưu các tham số
            m_strConnection = connectionString;
            m_strDatabaseOwner = databaseOwner;
            m_strObjectQualifier = objectQualifier;

        }


        #endregion

        #region Store Tools
        public string GetStoreName_THCore(string catName, string subName)
        {
            return string.Format("{0}{1}THCore_{2}_{3}", m_strDatabaseOwner, m_strObjectQualifier, catName, subName);
        }

        public string GetStoreName_THComponent(string catName, string subName)
        {
            return string.Format("{0}{1}TH{2}_{3}", m_strDatabaseOwner, m_strObjectQualifier, catName, subName);
        }
        public string GetStoreName_THComponentExpand(string catName, string subName)
        {
            return string.Format("{0}TH{1}_{2}", m_strDatabaseOwner, catName, subName);
        }
        #endregion

        #region FileUpload
        #endregion

    }
    public static class UtilsProvider
    {
        private static Utils m_objUtils;

        /// <summary>
        /// The utility object.
        /// </summary>
        public static Utils ObjUtils
        {
            get
            {
                if (m_objUtils == null)
                {
                    m_objUtils = new Utils();
                }
                return m_objUtils;
            }
        }
        #region Enum

        public enum CoreRole
        {
            Create = 1,
            EditAll = 2,
            EditAfter = 3,
            Delete = 4,
            Approve = 5,
            Public = 6,
            Unstate = 7,
            View = 8,
            Read = 9,
            Manage = 10
        }

        public enum LogAction
        {
            Create = 1,
            Update = 2,
            Delete = 3,
            Approve = 4,
            Public = 5,
            Unstate = 6,
            Deny = 7,
            RecycleBin = 8,
            Restore = 9,
            OffCategories = 10,
            AttachToCategories = 11
        }

        public enum ItemStatus
        {
            Pending = 1,
            Approved = 2,
            Public = 3,
            Denied = 4,
            Deleted = 5
        }

        public enum Order
        {
            CreatedDate = 1,
            ApprovedDate = 2,
            PublicDate = 3,
            DisplayDate = 4,
            Alphabetically = 5,
            Orderly = 6
        }

        #endregion
    }
}