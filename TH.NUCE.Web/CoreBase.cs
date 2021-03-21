using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class CoreBase
    {

        /// <summary>
        /// Lấy ra các quyền của người sử dụng trên một item. Quyền trả về là tổng hợp quyền trên tất cả các chuyên mục có chứa item.
        /// Ví dụ: Một người có quyền Edit trên chuyên mục A, quyền Approve trên chuyên mục B và item thuộc về cả chuyên mục A và B
        /// Vậy kết quả trả về là với item, người này có cả quyền Edit và Approve.
        /// </summary>
        /// <param name="userId">Mã id của người sử dụng</param>
        /// <param name="itemId">Mã id  của item</param>
        /// <param name="isSuperUser">Cho biết người sử dụng có phải admin hoặc host không (admin và host có tất cả mọi quyền)</param>
        /// <param name="portalId">Mã id của portal</param>
        /// <param name="typeId">Loại của item</param>
        /// <returns>Bảng chứa:
        ///         + CMSRoleId
        ///         + CMSRoleName</returns>
        public static DataTable RM_GetUserRolesByItem(int userId, int itemId, bool isSuperUser, int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Roles";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("RM", "GetUserRolesPerItem"), objDataSet, TableList, userId, itemId, isSuperUser, portalId, typeId);
                return objDataSet.Tables["Roles"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        /// <summary>
        /// Lấy ra các quyền mà một người có trên toàn bộ các chuyên mục trên toàn bộ Portal. Quyền là tổng hợp quyền của tất cả các chuyên mục.
        /// Ví dụ: Một người có quyền Edit trên chuyên mục A, quyền Approve trên chuyên mục B, quyền Delete trên chuyên mục C
        /// Kết quả trả về là người sử dụng có cả quyền Edit, Approve và Delete
        /// </summary>
        /// <param name="userId">Mã id của người sử dụng</param>
        /// <param name="isSuperUser">Lựa chọn cho biết người sử dụng là admin hay host</param>
        /// <param name="portalId">Mã id của Portal</param>
        /// <param name="typeId">Loại của chuyên mục</param>
        /// <returns>Bảng chứa:
        ///         + CMSRoleId
        ///         + CMSRoleName</returns>
        public static DataTable RM_GetUserRolesByPortal(int userId, bool isSuperUser, int portalId, int typeId)
        {

            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Roles";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("RM", "GetUserRolesPerPortal"), objDataSet, TableList, userId, isSuperUser, portalId, typeId);
                return objDataSet.Tables["Roles"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        /// <summary>
        /// Lấy ra các quyền mà một người có trên một chuyên mục
        /// </summary>
        /// <param name="userId">Mã id của người sử dụng</param>
        /// <param name="isSuperUser">Lựa chọn cho biết người sử dụng là admin hay host</param>
        /// <param name="portalId">Mã id của Portal</param>
        /// <param name="categoryId">Mã id của chuyên mục cần xét</param>
        /// <returns>Bảng chứa:
        ///         + CMSRoleId
        ///         + CMSRoleName</returns>
        public static DataTable RM_GetUserRolesByCategory(int userId, bool isSuperUser, int portalId, int categoryId)
        {

            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Roles";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("RM", "GetUserRolesPerCategory"), objDataSet, TableList, userId, isSuperUser, portalId, categoryId);
                return objDataSet.Tables["Roles"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #region Tool Functions
        // This region has optional functions which only serve as extra tools for the core-based item.

        #region Tab-Related
        public static DataTable TL_GetTabs(int portalId, int parentId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Tabs";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetTabs"), objDataSet, TableList, portalId, parentId);
                return objDataSet.Tables["Tabs"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static DataTable TL_GetFullTabs(int portalId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Tabs";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetFullTabs"), objDataSet, TableList, portalId);
                return objDataSet.Tables["Tabs"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static DataTable TL_GetFullTabs_Batch(int portalId, string strTabs)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Tabs";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetFullTabs_Batch"), objDataSet, TableList, portalId, strTabs);
                return objDataSet.Tables["Tabs"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static DataTable TL_GetFullTabs_Parent(int portalId, int parentId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                DataSet objDataSet = new DataSet();
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Tabs";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetFullTabs_Parent"), objDataSet, TableList, portalId, parentId);
                return objDataSet.Tables["Tabs"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region General Tools
        public static DataTable TL_GetType()
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "Type";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetType"), objDataSet, TableList);
                return objDataSet.Tables["Type"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static DataTable TL_GetTypeFull(int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "Type";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetTypeFull"), objDataSet, TableList, typeId);
                return objDataSet.Tables["Type"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }


        public static string TL_GetAlias(int portalAliasId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetHTTPAlias"), portalAliasId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region Param-Related
        public static void TL_UpdateItemParam(int itemId, int typeId, string paramName, string paramValue)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                objConnection.Open();
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "UpdateItemParam"), itemId, typeId, paramName, paramValue);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static string TL_GetItemParam(int itemId, int typeId, string paramName)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetItemParam"), itemId, typeId, paramName).ToString();
                if (result == null)
                    result = "";
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region Rating-Related
        public static void TL_UpdateItemRating(int itemId, int typeId, int userId, double mark)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                objConnection.Open();
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "InsertRating"), itemId, typeId, userId, mark);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static double TL_GetItemRating(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string strRaw;
                double result;
                strRaw = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetRating"), itemId, typeId).ToString();
                if (!double.TryParse(strRaw, out result))
                    result = 0;
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static int TL_GetItemRatingVotes(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string strRaw;
                int result;
                strRaw = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetRatingVotes"), itemId, typeId).ToString();
                if (!int.TryParse(strRaw, out result))
                    result = 0;
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static double TL_GetItemRatingPerUser(int userId, int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                if (userId == -1)
                    return 0;

                string strRaw;
                double result;
                strRaw = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetRatingPerUser"), userId, itemId, typeId).ToString();
                if (!double.TryParse(strRaw, out result))
                    result = 0;
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region Counter-Related
        public static void TL_InsertCounter(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "InsertCounter"), itemId, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int TL_GetCounter(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = DataProcessingProvider.GetProcessedInt(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "GetCounter"), itemId, typeId).ToString(), 0);
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion
        #region Add
        public static DataTable TL_CheckPermission_WaitForApproval(int UserId, int TypeId, int ItemId, int CategoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "CheckPermission";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TL", "CheckPermission_WaitForApproval"), objDataSet, TableList, UserId, TypeId, ItemId, CategoryId);
                return objDataSet.Tables["CheckPermission"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion
        #endregion
    }
}