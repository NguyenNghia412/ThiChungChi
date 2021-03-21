using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class CategoryProvider
    {
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
        /// Lấy ra các Category mà item nằm trong.
        /// </summary>
        /// <param name="itemId">Mã của item.</param>
        /// <param name="typeId">Loại của item.</param>
        /// <returns>Một chuỗi batchstring chứa mã id của các category liên quan.</returns>
        public static string GetItemCategoryString(int itemId, int typeId)
        {
            string result = ",";
            //THCore_CM_GetItemCategories
            //DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_CM_GetItemCategories", itemId, typeId);
            IDataReader IDataReaders = DotNetNuke.Data.DataProvider.Instance().ExecuteReader("THCore_CM_GetItemCategories", itemId, typeId);
            while (IDataReaders.Read())
            {
                result = result + IDataReaders["CategoryId"].ToString() + ",";
            }
            IDataReaders.Close();

            if (result == ",")
                result = "";

            return result;
        }
        /// <summary>
        /// Lấy ra thư mục chứa ảnh đầu tiên trong một loạt category.
        /// </summary>
        /// <param name="portalId">Portal chứa Category.</param>
        /// <param name="strCategories">Chuỗi Category cần xét.</param>
        /// <returns>Đường dẫn của thư mục.</returns>
        public static string GetDefaultFolderPath(string strCategories, int portalId)
        {

            return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar("THCore_CM_GetSingleFolderFromBatch", portalId, strCategories).ToString();
        }

        /// <summary>
        /// Lấy ra danh sách Category với các thông tin cơ bản, bao gồm mã, tên và cấp. Có thể sử dụng để lấy tất cả các Category chưa bị xóa của portal,
        /// hoặc để lấy tất cả các category chưa bị xóa của portal trừ một category nhất định.
        /// </summary>
        /// <param name="portalId">Mã portal chứa Category.</param>
        /// <param name="categoryId">Category cần lược bỏ. Với giá trị -1, hàm sẽ trả về tất cả các category của Portal.
        /// Với một số dương, hàm sẽ trả về tất cả category của Portal trừ category có mã là số dương đầu vào.</param>
        /// <param name="typeId">Loại của Category.</param>
        /// <returns>Một Data Table chứa các category kết quả.</returns>
        public static DataTable GetExcludedCategories(int portalId, int categoryId, int typeId)
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
        /// <summary>
        /// Thêm một item vào một loạt category.
        /// </summary>
        /// <param name="itemId">Item được thêm.</param>
        /// <param name="strCategories">Chuỗi batch string chứa id của các category nhận.</param>
        /// <param name="typeId">Loại của category và item.</param>
        public static void AttachItemToManyCategories(int itemId, string strCategories, int typeId, string name)
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
    }
}