using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace TH.NUCE.Web
{
    public static class CategoryExtProvider
    {
        #region Get Data
        public static DataTable CM_GetCategory(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "Category";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "EX_GetCategory1"), objDataSet, TableList, categoryId);
                return objDataSet.Tables["Category"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion
        #region Process Data

        public static int CM_InsertCategory(int portalId, string name, string description, string toolTip, bool isDefaultXSL, string xslFile, string icon, int parentId, string defaultFolder, int typeId, bool isNeedPublic, bool isNeedApprove, string extendedSettings, int Order, int LanguageId, string CultureCode, bool Dip1, bool Dip2, bool Dip3, bool Dip4, bool Dip5,string AddInfo1,string AddInfo2,string AddInfo3,string AddInfo4,string AddInfo5)
        {

            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "EX_InsertCategory1"), portalId, name, description, toolTip, isDefaultXSL, xslFile, icon, parentId, defaultFolder, typeId, isNeedPublic, isNeedApprove, extendedSettings, Order, LanguageId, CultureCode, Dip1, Dip2, Dip3, Dip4, Dip5, AddInfo1, AddInfo2, AddInfo3, AddInfo4, AddInfo5).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int CM_UpdateCategory(int categoryId, int portalId, string name, string description, string toolTip, bool isDefaultXSL, string xslFile, string icon, int parentId, string defaultFolder, bool isNeedPublic, bool isNeedApprove, string extendedSettings, int Order, int LanguageId, string CultureCode, bool Dip1, bool Dip2, bool Dip3, bool Dip4, bool Dip5, string AddInfo1, string AddInfo2, string AddInfo3, string AddInfo4, string AddInfo5)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "EX_UpdateCategory1"), categoryId, portalId, name, description, toolTip, isDefaultXSL, xslFile, icon, parentId, defaultFolder, isNeedPublic, isNeedApprove, extendedSettings, Order, LanguageId, CultureCode, Dip1, Dip2, Dip3, Dip4, Dip5, AddInfo1, AddInfo2, AddInfo3, AddInfo4, AddInfo5).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int StatusAutoPublicItem1(string strItems, string strComment, int TypeID,
        int PortalID, int UserID, bool IsSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoPublicItem1"), strItems, strComment, TypeID,
                PortalID, UserID, IsSuperUser).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int StatusAutoDeleteItem1(string strItems, string strComment, int TypeID,
int PortalID, int UserID, bool IsSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoDeleteItem1"), strItems, strComment, TypeID,
                PortalID, UserID, IsSuperUser).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static int StatusAutoApproveItem1(string strItems, int TypeID,
int PortalID, int UserID, bool IsSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoApproveItem1"), strItems, TypeID,
                PortalID, UserID, IsSuperUser).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion


        #region I. Get Category Data

        #region I.1. Get All categories

        /// <summary>
        /// Lấy ra tất cả các Category thuộc về Portal. Tất cả thông tin đều được lấy ra.
        /// </summary>
        /// <param name="portalId">Portal cần lấy dữ liệu.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một chuỗi string chứ Id của các category.</returns>
        public static string CM_GetAllCategoryString(int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            SqlDataReader reader;
            string result = "";
            try
            {
                SqlCommand objCommand = new SqlCommand("dnn_THCore_CM_GetCategories_ExcludeCurrent", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("PortalId", SqlDbType.Int).Value = portalId;
                objCommand.Parameters.Add("CategoryId", SqlDbType.Int).Value = -1;
                objCommand.Parameters.Add("TypeId", SqlDbType.Int).Value = typeId;
                objConnection.Open();
                reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result = result + reader["CategoryId"].ToString() + ",";
                }
                reader.Close();
                result = DataProcessingProvider.GetProcessedBatchString(result);

                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region I.2. Get Excluded Categories

        /// <summary>
        /// Lấy ra danh sách Category với các thông tin cơ bản, bao gồm mã, tên và cấp. Có thể sử dụng để lấy tất cả các Category chưa bị xóa của portal,
        /// hoặc để lấy tất cả các category chưa bị xóa của portal trừ một category nhất định.
        /// </summary>
        /// <param name="portalId">Mã portal chứa Category.</param>
        /// <param name="categoryId">Category cần lược bỏ. Với giá trị -1, hàm sẽ trả về tất cả các category của Portal.
        /// Với một số dương, hàm sẽ trả về tất cả category của Portal trừ category có mã là số dương đầu vào.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một Data Table chứa các category kết quả.</returns>
        public static DataTable CM_GetExcludeCurrentCategories(int portalId, int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ExcludedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_ExcludeCurrent"), objDataSet, TableList, portalId, categoryId, typeId);
                return objDataSet.Tables[0];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable CM_GetExcludeCurrentCategories_Order(int portalId, int categoryId, int typeId, int levelId, int index, bool isDesc)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ExcludedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_ExcludeCurrent_Order"), objDataSet, TableList, portalId, categoryId, typeId, levelId, index, isDesc);
                return objDataSet.Tables[0];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra danh sách Category với các thông tin cơ bản cộng với số lượng Category liên quan của mỗi Category. Có thể sử dụng để lấy tất cả các Category chưa bị xóa của portal,
        /// hoặc để lấy tất cả các category chưa bị xóa của portal trừ một category nhất định.
        /// </summary>
        /// <param name="portalId">Mã portal chứa Category.</param>
        /// <param name="categoryId">Category cần lược bỏ. Với giá trị -1, hàm sẽ trả về tất cả các category của Portal.
        /// Với một số dương, hàm sẽ trả về tất cả category của Portal trừ category có mã là số dương đầu vào.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một Data Table chứa các category kết quả.</returns>
        public static DataTable CM_GetExcludeCurrentCategories_Related(int portalId, int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ExcludedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_ExcludeCurrent_Related"), objDataSet, TableList, portalId, categoryId, typeId);
                return objDataSet.Tables[0];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra danh sách Category với các thông tin cơ bản cộng với số lượng TagGroup liên quan của mỗi Category. Có thể sử dụng để lấy tất cả các Category chưa bị xóa của portal,
        /// hoặc để lấy tất cả các category chưa bị xóa của portal trừ một category nhất định.
        /// </summary>
        /// <param name="portalId">Mã portal chứa Category.</param>
        /// <param name="categoryId">Category cần lược bỏ. Với giá trị -1, hàm sẽ trả về tất cả các category của Portal.
        /// Với một số dương, hàm sẽ trả về tất cả category của Portal trừ category có mã là số dương đầu vào.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một Data Table chứa các category kết quả.</returns>
        public static DataTable CM_GetExcludeCurrentCategories_TagGroup(int portalId, int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ExcludedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_ExcludeCurrent_TagGroup"), objDataSet, TableList, portalId, categoryId, typeId);
                return objDataSet.Tables[0];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra danh sách Category với các thông tin cơ bản cộng với số lượng Item trong mỗi Category. Có thể sử dụng để lấy tất cả các Category chưa bị xóa của portal,
        /// hoặc để lấy tất cả các category chưa bị xóa của portal trừ một category nhất định.
        /// </summary>
        /// <param name="portalId">Mã portal chứa Category.</param>
        /// <param name="categoryId">Category cần lược bỏ. Với giá trị -1, hàm sẽ trả về tất cả các category của Portal.
        /// Với một số dương, hàm sẽ trả về tất cả category của Portal trừ category có mã là số dương đầu vào.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một Data Table chứa các category kết quả.</returns>
        public static DataTable CM_GetExcludeCurrentCategories_Items(int portalId, int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ExcludedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_ExcludeCurrent_Items"), objDataSet, TableList, portalId, categoryId, typeId);
                return objDataSet.Tables[0];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region I.3. Get Children Categories

        /// <summary>
        /// Lấy ra các categogry là con của một category.
        /// </summary>
        /// <param name="categoryId">Mã Category mẹ</param>
        /// <returns>Data Table chứa thông tin cơ bản, bao gồm mã Category, tên và level.</returns>
        public static DataTable CM_GetChildrenCategories(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "ChildrenCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_Path"), objDataSet, TableList, categoryId);
                return objDataSet.Tables["ChildrenCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các categogry là con của một category.
        /// </summary>
        /// <param name="categoryId">Mã Category mẹ</param>
        /// <returns>Một chuỗi string chứ Id của các category.</returns>
        public static string CM_GetChildrenCategoryString(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            SqlDataReader reader;
            string result = "";
            try
            {
                SqlCommand objCommand = new SqlCommand("dnn_THCore_CM_GetCategories_Path", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("CategoryId", SqlDbType.Int).Value = categoryId;
                objConnection.Open();
                reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result = result + reader["CategoryId"].ToString() + ",";
                }
                reader.Close();
                result = DataProcessingProvider.GetProcessedBatchString(result);

                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region I.4. Get Related & Bin Categories

        /// <summary>
        /// Lấy ra tất cả các Category không liên quan tới một category.
        /// </summary>
        /// <param name="portalId">Portal mẹ</param>
        /// <param name="categoryId">Category cần lấy dữ liệu.</param>
        /// <param name="typeId">Loại của category.</param>
        /// <returns>Một Data Table chứa danh sách các category không liên quan.</returns>
        public static DataTable CM_GetNotRelatedCategories(int categoryId, int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "NotRelatedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_NotRelated"), objDataSet, TableList, categoryId, portalId, typeId);
                return objDataSet.Tables["NotRelatedCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra tất cả các Category liên quan tới một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy dữ liệu.</param>
        /// <param name="typeId">Loại của category.</param>
        /// <returns>Một Data Table chứa danh sách các category liên quan.</returns>
        public static DataTable CM_GetRelatedCategories(int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "RelatedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_Related"), objDataSet, TableList, categoryId, typeId);
                return objDataSet.Tables["RelatedCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các category liên quan tới một loạt category.
        /// </summary>
        /// <param name="strCategories">Các category cần lấy liên quan, đặt dưới dạng batchString: ,1,2,3, </param>
        /// <param name="typeId">Loại của các category</param>
        /// <returns>Data Table chứa thông tin cơ bản (Tên, mã, cấp) của các category liên quan tới các category trong chuỗi "strCategories"</returns>
        public static DataTable CM_GetRelatedCategoriesByString(string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "RelatedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_RelatedByString"), objDataSet, TableList, strCategories, typeId);
                return objDataSet.Tables["RelatedCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các category liên quan tới một loạt category với điều kiện người sử dụng có quyền cập nhật đối với category đó.
        /// </summary>
        /// <param name="strCategories">Các category cần lấy liên quan, đặt dưới dạng batchString: ,1,2,3, </param>
        /// <param name="typeId">Loại của các category</param>
        /// <param name="userId">Mã người sử dụng cần lọc</param>
        /// <param name="isSuperUser">Lựa chọn xem người sử dụng có phải là Admin hoặc Host không.</param>
        /// <returns>Data Table chứa thông tin cơ bản (Tên, mã, cấp) của các category liên quan tới các category trong chuỗi "strCategories" mà người sử dụng có quyền cập nhật.</returns>
        public static DataTable CM_GetRelatedCategoriesByStringPerUser(string strCategories, int typeId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "RelatedCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_RelatedByStringPerUser"), objDataSet, TableList, strCategories, typeId, userId, isSuperUser);
                return objDataSet.Tables["RelatedCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các category liên quan tới một loạt category với điều kiện người sử dụng có quyền cập nhật đối với category đó.
        /// </summary>
        /// <param name="strCategories">Các category cần lấy liên quan, đặt dưới dạng batchString: ,1,2,3, </param>
        /// <param name="typeId">Loại của các category</param>
        /// <param name="userId">Mã người sử dụng cần lọc</param>
        /// <param name="isSuperUser">Lựa chọn xem người sử dụng có phải là Admin hoặc Host không.</param>
        /// <returns>Data Table chứa thông tin cơ bản (Tên, mã, cấp) của các category liên quan tới các category trong chuỗi "strCategories" mà người sử dụng có quyền cập nhật.</returns>
        public static DataTable CM_GetCategoriesPerUser(int typeId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "Category";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_PerUser"), objDataSet, TableList, typeId, userId, isSuperUser);
                return objDataSet.Tables["Category"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy tất cả category trong thùng rác.
        /// </summary>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="typeId">Loại category cần lấy.</param>
        /// <param name="isDetail">Nếu chọn là 'true', kết quả trả về đi kèm thông tin về số item có trong mỗi category.</param>
        /// <returns>Bảng chứa tất cả category với trạng thái IsDeleted = 1</returns>
        public static DataTable CM_GetBinCategories(int portalId, int typeId, bool isDetail)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "BinCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategories_RecycleBin"), objDataSet, TableList, portalId, typeId, isDetail);
                return objDataSet.Tables["BinCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region I.5. GetSingleCategory

        /// <summary>
        /// Lấy ra tên của một Category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy tên.</param>
        /// <returns>Tên của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryName(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_Name"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra tooltip của một Category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Tooltip của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryToolTip(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_ToolTip"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra mã Category mẹ của một Category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Id của Category mẹ. Nếu không tìm thấy category, trả về -1.</returns>
        public static int CM_GetCategoryParentId(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_ParentId"), categoryId).ToString();
                int i;
                if (!int.TryParse(result, out i))
                {
                    i = -1;
                }
                return i;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra cấp của một Category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy. </param>
        /// <returns>Cấp của category cần lấy. Nếu không tìm thấy category, trả về 0.</returns>
        public static int CM_GetCategoryLevel(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_Level"), categoryId).ToString();
                int i;
                if (!int.TryParse(result, out i))
                {
                    i = 0;
                }
                return i;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra path của một Category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Path của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryPath(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_Path"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra thiết lập xem items trong Category có cần qua bước công bố không.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>true/false. Nếu không tìm thấy category, trả về  false.</returns>
        public static bool CM_GetCategoryIsNeedPublic(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_IsNeedPublic"), categoryId).ToString();

                return "true".Equals(result.ToLower());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra thiết lập xem items trong Category có cần qua bước duyệt không.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>true/false. Nếu không tìm thấy category, trả về  false.</returns>
        public static bool CM_GetCategoryIsNeedApprove(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_IsNeedApprove"), categoryId).ToString();

                return "true".Equals(result.ToLower());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thiết lập xem trang chi tiết của Category sử dụng XSL tùy biến hay XSL mặc định
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>true/false. Nếu không tìm thấy category, trả về  false.</returns>
        public static bool CM_GetCategoryIsDefaultXSL(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_IsDefaultXSL"), categoryId).ToString();

                return "true".Equals(result.ToLower());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Xem Category có bị cho vào thùng rác không.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>true/false. Nếu không tìm thấy category, trả về true.</returns>
        public static bool CM_GetCategoryIsDeleted(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_IsDeleted"), categoryId).ToString();

                return "true".Equals(result.ToLower());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra XSLFile của một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>xSLFile của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryXSLFile(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_XSLFile"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra Mô tả của một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Mô tả của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryDescription(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_Description"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra Icon của một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Icon của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryIcon(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_Icon"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra thư mục chứa ảnh tiêu đề mặc định của một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Đường dẫn của thư mục chứa ảnh tiêu đề. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryDefaultFolder(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_DefaultFolder"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra nhóm thuộc tính động liên quan của một category.
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Chuỗi batchstring chứa id các nhóm thuộc tính động của category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryDPGroups(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_DPGroups"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra setting nâng cao của một category. Chuỗi settings là một chuỗi có dạng: [Setting1]=[value1];[Setting2]=[value2];[Setting3]=[value3]
        /// </summary>
        /// <param name="categoryId">Category cần lấy.</param>
        /// <returns>Chuỗi settings của  category. Nếu không tìm thấy category, trả về string rỗng.</returns>
        public static string CM_GetCategoryExtendedSettings(int categoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCategory_ExtendedSettings"), categoryId).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region I.6. Get Default Information in a Batch

        /// <summary>
        /// Lấy ra thư mục chứa ảnh đầu tiên trong một loạt category.
        /// </summary>
        /// <param name="portalId">Portal chứa Category.</param>
        /// <param name="strCategories">Chuỗi Category cần xét.</param>
        /// <returns>Đường dẫn của thư mục.</returns>
        public static string CM_GetDefaultFolderPath(int portalId, string strCategories)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                string result;
                result = SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetSingleFolderFromBatch"), portalId, strCategories).ToString();
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra XSL tùy biến đầu tiên trong một loạt category.
        /// </summary>
        /// <param name="portalId">Portal chứa Category.</param>
        /// <param name="strCategories">Chuỗi Category cần xét.</param>
        /// <returns>Đường dẫn của file XSL.</returns>
        public static string CM_GetDefaultXSLFile(int portalId, string strCategories)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetSingleXSLFileFromBatch"), portalId, strCategories).ToString();
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region I.7. Get Start With Categories

        public static string CM_GetStartWithCategoryString(int portalId, int typeId, string startWith, string strCategories)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            SqlDataReader reader;
            string result = "";
            try
            {
                SqlCommand objCommand = new SqlCommand("dnn_THCore_CM_GetCategories_StartWith", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("PortalId", SqlDbType.Int).Value = portalId;
                objCommand.Parameters.Add("TypeId", SqlDbType.Int).Value = typeId;
                objCommand.Parameters.Add("StartWith", SqlDbType.NVarChar).Value = startWith;
                objCommand.Parameters.Add("StrCategories", SqlDbType.VarChar).Value = strCategories;
                objConnection.Open();
                reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result = result + reader["CategoryId"].ToString() + ",";
                }
                reader.Close();
                result = DataProcessingProvider.GetProcessedBatchString(result);

                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #endregion

        #region II. Get Related Data

        #region II.1. Tag Groups

        /// <summary>
        /// Lấy ra tất cả các nhóm tag group liên quan tới một Category.
        /// </summary>
        /// <param name="categoryId">Category cần xét.</param>
        /// <param name="typeId">Loại của category cần xét.</param>
        /// <returns>Data Table chứa dữ liệu của các nhóm tag group liên quan tới một category, bao gồm các thông tin:
        /// + TagGroupId
        /// + Name
        /// + IsFreeMode
        /// + IsEnabled
        ///</returns>
        public static DataTable CM_GetRelatedTagGroups(int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "RelatedTags";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetTagGroups_Related"), objDataSet, TableList, categoryId, typeId);
                return objDataSet.Tables["RelatedTags"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra tất cả các nhóm tag group liên quan tới một nhóm category.
        /// </summary>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category cần xét.</param>
        /// <param name="typeId">Loại của category cần xét.</param>
        /// <returns>Data Table chứa dữ liệu của các nhóm tag group liên quan tới một nhóm category, bao gồm các thông tin:
        /// + TagGroupId
        /// + Name
        /// + IsFreeMode
        /// + IsEnabled
        ///</returns>
        public static DataTable CM_GetRelatedTagGroups(string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "RelatedTags";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetTagGroups_RelatedByString"), objDataSet, TableList, strCategories, typeId);
                return objDataSet.Tables["RelatedTags"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra tất cả các nhóm tag group không liên quan tới một Category.
        /// </summary>
        /// <param name="categoryId">Category cần xét.</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="typeId">Loại của category cần xét.</param>
        /// <returns>Data Table chứa dữ liệu của các nhóm tag group không liên quan tới một category, bao gồm các thông tin:
        /// + TagGroupId
        /// + Name
        ///</returns>
        public static DataTable CM_GetNotRelatedTagGroups(int categoryId, int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "NotRelatedTags";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetTagGroups_NotRelated"), objDataSet, TableList, categoryId, portalId, typeId);
                return objDataSet.Tables["NotRelatedTags"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra số tag groups liên quan tới một nhóm category.
        /// </summary>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category.</param>
        /// <param name="typeId">Loại của các category.</param>
        /// <returns>Số tag groups.</returns>
        public static int CM_GetCountRelatedTagGroups(string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                if (!int.TryParse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetCountTagGroups_RelatedByString"), strCategories, typeId).ToString(), out result))
                {
                    result = -1;
                }
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region II.2. Items

        /// <summary>
        /// Lấy ra các Category mà item nằm trong.
        /// </summary>
        /// <param name="itemId">Mã của item.</param>
        /// <param name="typeId">Loại của item.</param>
        /// <returns>Một bảng chứa thông tin của các category liên quan.
        /// Bao gồm: 
        /// + CategoryId
        /// + Name
        /// + Level
        /// + ParentId
        /// </returns>
        public static DataTable CM_GetItemCategories(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "ItemCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItemCategories"), objDataSet, TableList, itemId, typeId);
                return objDataSet.Tables["ItemCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các Category mà item nằm trong.
        /// </summary>
        /// <param name="itemId">Mã của item.</param>
        /// <param name="typeId">Loại của item.</param>
        /// <returns>Một chuỗi batchstring chứa mã id của các category liên quan.</returns>
        public static string CM_GetItemCategoryString(int itemId, int typeId)
        {
            string result = ",";
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            SqlDataReader reader;
            try
            {
                SqlCommand objCommand = new SqlCommand(Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItemCategories"), objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("ItemId", SqlDbType.Int).Value = itemId;
                objCommand.Parameters.Add("TypeId", SqlDbType.Int).Value = typeId;

                objConnection.Open();
                reader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result = result + reader["CategoryId"].ToString() + ",";
                }
                reader.Close();

                if (result == ",")
                    result = "";

                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra các Category liên quan tới một loạt items.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa mã id của các item.</param>
        /// <param name="typeId">Loại của các item.</param>
        /// <returns>Một data table chứa thông tin của các category, bao gồm:
        /// + ItemId
        /// + CategoryId
        /// + Name
        /// + Level
        /// + ParentId
        /// </returns>
        public static DataTable CM_GetItems_Categories(string strItems, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "ItemCategories";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItems_Categories"), objDataSet, TableList, strItems, typeId);
                return objDataSet.Tables["ItemCategories"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Lấy ra trạng thái của các item tại tất cả các Category mà nó có mặt.
        /// </summary>
        /// <param name="itemId">Item cần lấy.</param>
        /// <param name="portalId">Mã Id của Portal.</param>
        /// <param name="typeId">Loại của Item.</param>
        /// <returns>Một Data Table chứa trạng thái của các category.
        ///          Bao gồm:
        ///                 + CategoryId
        ///                 + Name
        ///                 + StatusString
        ///                 + CurrentCommnent 
        ///                 + CurrentActors
        /// </returns>
        public static DataTable CM_GetItemStatus(int itemId, int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "CategoryStatus";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItemStatus"), objDataSet, TableList, itemId, portalId, typeId);
                return objDataSet.Tables["CategoryStatus"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable CM_GetItems_WaitForApproval(int userId, int typeId, string title, int dateType, DateTime startDate, DateTime endDate, string strCategories)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "GetItemsWaitForApproval";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItems_WaitForApproval"), objDataSet, TableList, userId, typeId, title, dateType, startDate, endDate, strCategories);
                return objDataSet.Tables["GetItemsWaitForApproval"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable CM_GetItems_ByRoleCMSAndStatus(int userId, int typeId, string title, int dateType, DateTime startDate, DateTime endDate, string strCategories, string cmsRole, string status)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            objDataSet.EnforceConstraints = false;
            try
            {
                string[] TableList = new string[1];
                TableList[0] = "GetItemsWaitForApproval";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "GetItems_ByRoleCMSAndStatus"), objDataSet, TableList, userId, typeId, title, dateType, startDate, endDate, strCategories, cmsRole, status);
                return objDataSet.Tables["GetItemsWaitForApproval"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #endregion

        #region III. Process Data

        #region III.1. Basic Function

        /// <summary>
        /// Thêm mới một category vào CSDL.
        /// </summary>
        /// <param name="portalId">Portal chứa category.</param>
        /// <param name="name">Tên</param>
        /// <param name="description">Mô tả</param>
        /// <param name="toolTip">ToolTip</param>
        /// <param name="isDefaultXSL">Lựa chọn quyết định việc chi tiết chuyên mục sẽ sử dụng XSL mặc định hay tùy biến.</param>
        /// <param name="xslFile">Đường dẫn tới file XSL tùy biến.</param>
        /// <param name="icon">Đường dẫn tới file Icon</param>
        /// <param name="parentId">Mã Id của Category mẹ.</param>
        /// <param name="isExpired">Lựa chọn quyết định việc các item trong category có hết hạn không.</param>
        /// <param name="defaultFolder">Đường dẫn thư mục chứa ảnh tiêu đề.</param>
        /// <param name="typeId">Loại của category.</param>
        /// <param name="isNeedPublic">Lựa chọn quyết định việc item trong category có cần qua bước công bố không.</param>
        /// <param name="isNeedApprove">Lựa chọn quyết định việc item trong category có cần qua bước duyệt không.</param>
        /// <param name="extendedSettings">Thiết lập mở rộng.</param>
        /// <returns>Trả về:
        ///             -1: Đã có một Category cùng tên, cùng cấp, cùng Category mẹ với category định thêm mới.
        ///             -2: Không có category mẹ nào với id category mẹ được cung cấp.
        ///             >0: Id của Catgory mới.
        /// </returns>
        public static int CM_InsertCategory(int portalId, string name, string description, string toolTip, bool isDefaultXSL, string xslFile, string icon, int parentId, string defaultFolder, int typeId, bool isNeedPublic, bool isNeedApprove, string extendedSettings)
        {

            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "InsertCategory"), portalId, name, description, toolTip, isDefaultXSL, xslFile, icon, parentId, defaultFolder, typeId, isNeedPublic, isNeedApprove, extendedSettings).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Cập nhật thay đổi của một category vào CSL
        /// </summary>
        /// <param name="categoryId">Mã của Category cần cập nhật thay đổi.</param>
        /// <param name="portalId">Portal chứa category.</param>
        /// <param name="name">Tên</param>
        /// <param name="description">Mô tả</param>
        /// <param name="toolTip">ToolTip</param>
        /// <param name="isDefaultXSL">Lựa chọn quyết định việc chi tiết chuyên mục sẽ sử dụng XSL mặc định hay tùy biến.</param>
        /// <param name="xslFile">Đường dẫn tới file XSL tùy biến.</param>
        /// <param name="icon">Đường dẫn tới file Icon</param>
        /// <param name="parentId">Mã Id của Category mẹ.</param>
        /// <param name="isExpired">Lựa chọn quyết định việc các item trong category có hết hạn không.</param>
        /// <param name="defaultFolder">Đường dẫn thư mục chứa ảnh tiêu đề.</param>
        /// <param name="isNeedPublic">Lựa chọn quyết định việc item trong category có cần qua bước công bố không.</param>
        /// <param name="isNeedApprove">Lựa chọn quyết định việc item trong category có cần qua bước duyệt không.</param>
        /// <param name="extendedSettings">Thiết lập mở rộng.</param>
        /// <returns>Trả về:
        ///             -1: Không tìm thấy category định cập nhật.
        ///             -2: Đã có một Category cùng tên, cùng cấp, cùng Category mẹ với category định thêm mới.
        ///             -3: Không có category mẹ nào với id category mẹ được cung cấp.
        ///             >0: Hàm thành công, trả về id của category đã cập nhật.
        /// </returns>
        public static int CM_UpdateCategory(int categoryId, int portalId, string name, string description, string toolTip, bool isDefaultXSL, string xslFile, string icon, int parentId, string defaultFolder, bool isNeedPublic, bool isNeedApprove, string extendedSettings)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "UpdateCategory"), categoryId, portalId, name, description, toolTip, isDefaultXSL, xslFile, icon, parentId, defaultFolder, isNeedPublic, isNeedApprove, extendedSettings).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Xóa một Category.
        /// </summary>
        /// <param name="categoryId">Mã category cần xóa.</param>
        /// <param name="portalId">Portal chứa Category.</param>
        /// <param name="deleteOption">Lựa chọn xóa: 
        ///                             1 - Cho Category vào thùng rác; 
        ///                             2 - Xóa sạch.</param>
        public static void CM_DeleteCategory(int categoryId, int portalId, int deleteOption)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                objConnection.Open();
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "DeleteCategoryOption"), categoryId, portalId, deleteOption);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Phục hồi một category khỏi thùng rác.
        /// </summary>
        /// <param name="categoryId">Category cần phục hồi.</param>
        /// <param name="portalId">Portal chứa category.</param>
        /// <param name="typeId">Loại của category.</param>
        public static void CM_RestoreCategory(int categoryId, int portalId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                objConnection.Open();
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "RestoreCategory"), categoryId, portalId, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region III.2. Related Data Function


        /// <summary>
        /// Bỏ các Category liên quan ra khỏi một Category sẵn có. Sau hàm này, category với mã là categoryId không còn liên quan với category trong chuỗi batchstring UnRelated nữa
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các category muốn bỏ.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_RemoveRelatedCategory(int categoryId, int portalId, string unRelatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "Remove_RelatedCategory"), categoryId, portalId, unRelatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm các Category liên quan vào một Category không quan tâm tới các category đã liên quan sẵn. Sau hàm này, category với mã là categoryId chỉ liên quan tới các category trong chuỗi relatedString.
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các category muốn thêm liên quan.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_UpdateRelatedCategory(int categoryId, int portalId, string relatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "UpdateCategory_Related"), categoryId, portalId, relatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm các Category liên quan vào một Category mà không làm ảnh hưởng tới các category đã liên quan sẵn. Sau hàm này, category với mã là categoryId liên quan tới các 
        /// category trong chuỗi relatedString và các category liên quan mà nó đã có sẵn.
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các category muốn thêm liên quan.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_InsertRelatedCategory(int categoryId, int portalId, string relatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "InsertCategory_Related"), categoryId, portalId, relatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Bỏ các Tag Group liên quan ra khỏi một Category sẵn có. Sau hàm này, category với mã là categoryId không còn liên quan với Tag Group  trong chuỗi batchstring UnRelated nữa
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các tag group muốn bỏ.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_RemoveRelatedTagGroup(int categoryId, int portalId, string unRelatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "Remove_RelatedTagGroups"), categoryId, portalId, unRelatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm các nhóm từ khóa liên quan vào một category mà không quan tâm tới những nhóm tag group liên quan đã có sẵn.
        /// Sau hàm này, category chỉ liên quan tới các nhóm taggroup trong chuỗi relatedString.
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các tag group muốn thêm liên quan.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_UpdateRelatedTagGroups(int categoryId, int portalId, string relatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "UpdateCategory_RelatedTagGroups"), categoryId, portalId, relatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm các nhóm từ khóa liên quan vào một category và vẫn giữ nguyên nhóm tag group liên quan đã có sẵn.
        /// Sau hàm này, category không những liên quan tới các nhóm tag group trong chuỗi relatedString mà còn giữ nguyên các nhóm tag group đã sẵn có.
        /// </summary>
        /// <param name="categoryId">Mã category gốc</param>
        /// <param name="portalId">Portal chứa các category.</param>
        /// <param name="relatedString">Chuỗi batchstring chứa id của các tag group muốn thêm liên quan.</param>
        /// <returns>-1 nếu không tìm thấy category, 1 nếu cập nhật thành công.</returns>
        public static int CM_InsertRelatedTagGroups(int categoryId, int portalId, string relatedString)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                int result;
                result = int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "InsertCategory_RelatedTagGroups"), categoryId, portalId, relatedString).ToString());
                return result;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        #endregion

        #region III.3. Copy Data Function

        /// <summary>
        /// Copy các quyền của một Category sang một category khác.
        /// </summary>
        /// <param name="copyCategoryId">Category gốc.</param>
        /// <param name="destinationCategoryId">Category đích.</param>
        public static void CM_CopyCategoryRoles(int copyCategoryId, int destinationCategoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "CopyCategoryRoles"), copyCategoryId, destinationCategoryId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Copy các tag group liên quan của một category sang một category khác.
        /// </summary>
        /// <param name="copyCategoryId">Category gốc.</param>
        /// <param name="destinationCategoryId">Category đích.</param>
        public static void CM_CopyCategoryTagGroups(int copyCategoryId, int destinationCategoryId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "CopyCategoryTagGroup"), copyCategoryId, destinationCategoryId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region III.4. Item Processing Function

        /// <summary>
        /// Thêm một item vào một category.
        /// </summary>
        /// <param name="itemId">Item được thêm.</param>
        /// <param name="categoryId">Category nhận.</param>
        /// <param name="typeId">Loại của category và item.</param>
        public static void CM_InsertCategoryItem(int itemId, int categoryId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "InsertItem"), itemId, categoryId, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Thêm một item vào một loạt category.
        /// </summary>
        /// <param name="itemId">Item được thêm.</param>
        /// <param name="strCategories">Chuỗi batch string chứa id của các category nhận.</param>
        /// <param name="typeId">Loại của category và item.</param>
        public static void CM_InsertBatchCategoryItem(int itemId, string strCategories, int typeId, string name)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "InsertItemBatchCategories"), itemId, strCategories, typeId, name);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Bỏ item ra khỏi tất cả các category.
        /// </summary>
        /// <param name="itemId">Item được lược bỏ.</param>
        /// <param name="typeId">Loại của category và item.</param>
        public static void CM_DeleteItem(int itemId, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "DeleteItem"), itemId, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Bỏ một item ra khỏi một số category.
        /// </summary>
        /// <param name="itemId">Item cần bỏ.</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category muốn bỏ.</param>
        /// <param name="typeId">Loại của category và item.</param>
        public static void CM_DeleteItemBatchCategories(int itemId, string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "DeleteItemBatchCategories"), itemId, strCategories, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        #endregion

        #region III.5. Item Status Function

        /// <summary>
        /// Duyệt một item tại một hoặc một vài category. Sau khi hàm này chạy, tại các category đầu vào,  item sẽ có trạng thái là 'đã duyệt' với các category phải qua bước 'công bố', và có luôn trạng thái là 'công bố' nếu category
        /// không cần qua bước công bố.
        /// </summary>
        /// <param name="itemId">Item cần duyệt.</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category tham gia vào bước duyệt.</param>
        /// <param name="typeId">Loại của item.</param>
        public static void CM_ApproveItem(int itemId, string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusApproveItem"), itemId, strCategories, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Duyệt một loạt  item tại tất cả các category mà người thực hiện hành động có quyền duyệt. Sau khi hàm này chạy, tại các category mà người thực hiện hành động có quyền duyệt, 
        /// item sẽ có trạng thái là 'đã duyệt' với các category phải qua bước 'công bố', và có luôn trạng thái là 'công bố' nếu category không cần qua bước công bố.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item cần duyệt.</param>
        /// <param name="typeId">Loại của Item.</param>
        /// <param name="portalId">Portal chứa các item.</param>
        /// <param name="userId">Người thực hiện hành động</param>
        /// <param name="isSuperUser">Người thực hiện hành động có phải Super User không.</param>
        public static void CM_AutoApproveItem(string strItems, int typeId, int portalId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoApproveItem"), strItems, typeId, portalId, userId, isSuperUser);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Công bố một item tại một hoặc một vài category. Sau khi hàm này chạy, tại các category đầu vào, item sẽ có trạng thái là 'công bố'.
        /// </summary>
        /// <param name="itemId">Item cần công bố.</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category tham gia vào bước công bố.</param>
        /// <param name="typeId">Loại của item.</param>
        public static void CM_PublicItem(int itemId, string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusPublicItem"), itemId, strCategories, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Công bố một loạt  item tại tất cả các category mà người thực hiện hành động có quyền công bố. Sau khi hàm này chạy, các items sẽ có trạng thái là 'công bố' tại các  category mà người thực 
        /// hiện hành động có quyền công bố.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item cần công bố.</param>
        /// <param name="typeId">Loại của Item.</param>
        /// <param name="portalId">Portal chứa các item.</param>
        /// <param name="userId">Người thực hiện hành động</param>
        /// <param name="isSuperUser">Người thực hiện hành động có phải Super User không.</param>
        public static void CM_AutoPublicItem(string strItems, int typeId, int portalId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoPublicItem"), strItems, typeId, portalId, userId, isSuperUser);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Gỡ item khỏi các trạng thái duyệt, từ chối, công bố. Sau khi hàm này chạy, tại các category đầu vào, item sẽ có trạng thái là 'chờ duyệt'.
        /// </summary>
        /// <param name="itemId">Item cần gỡ trạng thái.</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category tham gia vào bước gỡ trạng thái.</param>
        /// <param name="typeId">Loại của item.</param>
        public static void CM_UnstateItem(int itemId, string strCategories, int typeId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusUnstateItem"), itemId, strCategories, typeId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Gỡ một loạt  item tại tất cả các category mà người thực hiện hành động có quyền gỡ duyệt. Sau khi hàm này chạy,các items sẽ có trạng thái là 'chờ duyệt' tại các  category mà người thực 
        /// hiện hành động có quyền gỡ duyệt.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item cần gỡ duyệt.</param>
        /// <param name="typeId">Loại của Item.</param>
        /// <param name="portalId">Portal chứa các item.</param>
        /// <param name="userId">Người thực hiện hành động</param>
        /// <param name="isSuperUser">Người thực hiện hành động có phải Super User không.</param>
        public static void CM_AutoUnstateItem(string strItems, int typeId, int portalId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoUnstateItem"), strItems, typeId, portalId, userId, isSuperUser);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Từ chối  một item tại một hoặc một vài category. Sau khi hàm này chạy, tại các category đầu vào, item sẽ có trạng thái là 'từ chối'.
        /// </summary>
        /// <param name="itemId">Item cần từ chối.</param>
        /// <param name="strCategories">Chuỗi batchstring chứa id của các category tham gia vào bước từ chối.</param>
        /// <param name="typeId">Loại của item.</param>
        /// <param name="reason">Lý do từ chối.</param>
        public static void CM_DenyItem(int itemId, string strCategories, int typeId, string reason)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusDenyItem"), itemId, strCategories, typeId, reason);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        /// <summary>
        /// Duyệt một loạt  item tại tất cả các category mà người thực hiện hành động có quyền gỡ từ chối. Sau khi hàm này chạy,các items sẽ có trạng thái là 'từ chối' tại các  category mà người thực 
        /// hiện hành động có quyền từ chối.
        /// </summary>
        /// <param name="strItems">Chuỗi batchstring chứa id của các item cần từ chối.</param>
        /// <param name="typeId">Loại của Item.</param>
        /// <param name="strDenyReason">Lý do từ chối.</param>
        /// <param name="portalId">Portal chứa các item.</param>
        /// <param name="userId">Người thực hiện hành động</param>
        /// <param name="isSuperUser">Người thực hiện hành động có phải Super User không.</param>
        public static void CM_AutoDenyItem(string strItems, int typeId, string strDenyReason, int portalId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoDenyItem"), strItems, typeId, strDenyReason, portalId, userId, isSuperUser);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static void CM_AutoDeleteItem(string strItems, int typeId, int portalId, int userId, bool isSuperUser)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("CM", "StatusAutoDeleteItem"), strItems, typeId, portalId, userId, isSuperUser);
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