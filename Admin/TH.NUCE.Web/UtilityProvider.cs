using System.Data;
namespace TH.NUCE.Web
{
    public static class UtilityProvider
    {

        #region Tab-Related
        
        /// <summary>
        /// Get the tabs of a portal, or the children tabs of a specific parent tab.
        /// </summary>
        /// <param name="portalId">The portal that has the tabs.</param>
        /// <param name="parentId">The parent tab, use -1 to get all tabs.</param>
        /// <returns>A table with the tabs' information</returns>
        public static DataTable GetTabs(int portalId, int parentId)
        {
            return CoreBase.TL_GetTabs(portalId, parentId);
        }

        public static DataTable GetFullTabs(int portalId)
        {
            return CoreBase.TL_GetFullTabs(portalId);
        }

        public static DataTable GetFullTabs(int portalId, int parentId)
        {
            return CoreBase.TL_GetFullTabs_Parent(portalId, parentId);
        }

        public static DataTable GetFullTabs(int portalId, string strTabs)
        {
            return CoreBase.TL_GetFullTabs_Batch(portalId, strTabs);
        }
        #endregion

        #region General

        /// <summary>
        /// Get an alias.
        /// </summary>
        /// <param name="portalAliasId">The alias's Id</param>
        /// <returns>The alias.</returns>
        public static string GetAlias(int portalAliasId)
        {
            return CoreBase.TL_GetAlias(portalAliasId);
        }

        /// <summary>
        /// Get the core types that are installed.
        /// </summary>
        /// <returns>A table with the information of the installed core types.</returns>
        public static DataTable GetCoreType()
        {
            return CoreBase.TL_GetType();
        }

        #endregion
    }
}