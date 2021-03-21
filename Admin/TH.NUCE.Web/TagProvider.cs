using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
namespace TH.NUCE.Web
{
    /// </summary>
    public static class TagProvider
    {
        /// <summary>
        /// Thêm một item vào nhiều tag của một tag group cùng lúc và đảm bảo rằng những tag này là những tag duy nhất mà item có trong tag group.
        /// Kết quả của hàm này là đối với tag group được chỉ định, item chỉ có các tag vừa được thêm  mà không có các tag khác.
        /// </summary>
        /// <param name="itemId">Mã của item.</param>
        /// <param name="strTags">Chuỗi batchstring chứa id của các tag đích.</param>
        /// <param name="typeId">Loại của item và Tag.</param>
        /// <param name="tagGroupId">Mã của nhóm từ khóa chứa strTag.</param>
        public static void AttachItemToManyTags(int itemId, string strTags, int typeId, int tagGroupId)
        {
            if (strTags != "" && strTags != ",")
            {
                string[] strSplitTags = DataProcessingProvider.GetBatchStringItems(strTags, ",");
                int i;
                strTags = ",";
                for (i = 0; i < strSplitTags.Length; i++)
                {
                    strTags = strTags + strSplitTags[i].Trim() + ",";
                }
                TM_InsertBatchTagItem(itemId, strTags, typeId, tagGroupId);
            }
        }
        /// <summary>
        /// Thêm một item vào nhiều tag của một tag group cùng lúc và đảm bảo rằng những tag này là những tag duy nhất mà item có trong tag group.
        /// Kết quả của hàm này là đối với tag group được chỉ định, item chỉ có các tag vừa được thêm  mà không có các tag khác.
        /// </summary>
        /// <param name="itemId">Mã của item.</param>
        /// <param name="strTags">Chuỗi batchstring chứa id của các tag đích.</param>
        /// <param name="typeId">Loại của item và Tag.</param>
        /// <param name="tagGroupId">Mã của nhóm từ khóa chứa strTag.</param>
        public static void TM_InsertBatchTagItem(int itemId, string strTags, int typeId, int tagGroupId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THCore("TM", "InsertItemBatchTags"), itemId, strTags, typeId, tagGroupId);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

    }
}