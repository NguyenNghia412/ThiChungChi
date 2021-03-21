using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
namespace TH.NUCE.Web
{
    /// </summary>
    public sealed class LogProvider
    {
        #region Process Data
        /// <summary>
        /// Thêm một log vào hệ thống
        /// </summary>
        /// <param name="itemId">Item được ghi log</param>
        /// <param name="typeId">Loại của item</param>
        /// <param name="coreType">CoreType, sử dụng trong trường hợp log được lưu cho các thành phần core như category, Tag....</param>
        /// <param name="portalId">Portal chứa item</param>
        /// <param name="actionId">Hành động xảy ra</param>
        /// <param name="actionOwner">Tên người thực hiện hành động</param>
        /// <param name="actionOwnerId">Mã người thực hiện hành động</param>
        /// <param name="actionValue">Giá trị của hành động xảy ra</param>
        /// <param name="isChangeName">Có thay đổi tên của item không</param>
        /// <param name="strCategories">Danh mục xảy ra sự thay đổi</param>
        public static void InsertLogAction(int itemId, int typeId, string coreType, int portalId, int actionId, string actionOwner, int actionOwnerId, string actionValue, bool isChangeName, string strCategories)
        {
            if (actionOwner == null)
            {
                actionOwner = "-1";
            }
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("LM", "InsertLogAction"), itemId, typeId, coreType, portalId, actionId, actionOwner, actionOwnerId, actionValue, isChangeName, strCategories);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm một log vào hệ thống cho nhiều items trong trường hợp không biết category của item.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item</param>
        /// <param name="typeId">Loại của item</param>
        /// <param name="portalId">Mã Id của Portal</param>
        /// <param name="actionId">Loại hành động</param>
        /// <param name="actionOwner">Người thực hiện hành động</param>
        /// <param name="actionOwnerId">Mã người thực hiện hành động</param>
        /// <param name="actionValue">Giá trị của hành động</param>
        /// <param name="isChangeName">Hành động có thay đổi tên không</param>
        public static void InsertManyLogAction(string strItems, int typeId, int portalId, int actionId, string actionOwner, int actionOwnerId, string actionValue, bool isChangeName)
        {
            string[] items = DataProcessingProvider.GetBatchStringItems(strItems, ",");
            int itemId;
            string categories;

            foreach (string item in items)
            {
                itemId = int.Parse(item);
                categories = CategoryProvider.CM_GetItemCategoryString(itemId, typeId);
                LogProvider.InsertLogAction(itemId, typeId, "", portalId, actionId, actionOwner, actionOwnerId, actionValue, false, categories);
            }
        }

        /// <summary>
        /// Áp dụng cho trường hợp thêm action cho nhiều item, có biết category của item.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item</param>
        /// <param name="typeId">Loại của item</param>
        /// <param name="portalId">Mã Id của Portal</param>
        /// <param name="actionId">Loại hành động</param>
        /// <param name="actionOwner">Người thực hiện hành động</param>
        /// <param name="actionOwnerId">Mã người thực hiện hành động</param>
        /// <param name="actionValue">Giá trị của hành động</param>
        /// <param name="isChangeName">Hành động có thay đổi tên không</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category.</param>
        public static void InsertManyLogAction(string strItems, int typeId, int portalId, int actionId, string actionOwner, int actionOwnerId, string actionValue, bool isChangeName, string strCategories)
        {
            string[] items = DataProcessingProvider.GetBatchStringItems(strItems, ",");
            int itemId;

            foreach (string item in items)
            {
                itemId = int.Parse(item);
                LogProvider.InsertLogAction(itemId, typeId, "", portalId, actionId, actionOwner, actionOwnerId, actionValue, false, strCategories);
            }
        }
        public static DataTable GetLogs(string strCategories, string keyWord, DateTime startDate, DateTime endDate, int TypeId, int portalId, string ActionOwner)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDS = new DataSet();
            objDS.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "GetLogs";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("LM", "Getlogs"), objDS, TableList, strCategories, keyWord, startDate, endDate, TypeId, portalId, ActionOwner);
                return objDS.Tables["GetLogs"];
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable GetLogArticle(int itemId, int typeId, int portalId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDS = new DataSet();
            objDS.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "GetLogArticle";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("LM", "GetLogArticle"), objDS, TableList, itemId, typeId, portalId);
                return objDS.Tables["GetLogArticle"];
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static void DeleteLogs(int LogId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("LM", "DeleteLogAction"), LogId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static void DeleteLogAll(int PortalId, int TypeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("LM", "DeletelogAll"), PortalId, TypeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion
    }
}