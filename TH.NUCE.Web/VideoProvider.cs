using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TH.NUCE.Web
{
    public static class VideoProvider
    {
        public static int TypeId
        {
            get
            {
                return 5;
            }
        }
        public static DataTable GetVideo(int VideoId)
        {
            return VD_GetVideo(VideoId);
        }
        public static DataTable VD_GetVideo(int VideoId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "GetVideo";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "VD_GetVideo"), objDataSet, TableList, VideoId);
                return objDataSet.Tables["GetVideo"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int InsertVideo(string Title, string Summary, string VideoFile, string Avatar, bool IsUrlWeb, string Length, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            int newId = -1;
            newId = VD_InsertVideo(Title, Summary, VideoFile, Avatar, IsUrlWeb, Length, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5);
            CategoryProvider.AttachItemToManyCategories(newId, strCategories, TypeId, Title);
            return newId;
        }

        public static int UpdateVideo(int VideoId, string Title, string Summary, string VideoFile, string Avatar, bool IsUrlWeb, string Length, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            int result = -1;
            result = VD_UpdateVideo(VideoId, Title, Summary, VideoFile, Avatar, IsUrlWeb, Length, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5);
            CategoryProvider.AttachItemToManyCategories(VideoId, strCategories, TypeId, Title);
            return result;
        }
        public static int VD_InsertVideo(string Title, string Summary, string VideoFile, string Avatar, bool IsUrlWeb, string Length, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "VD_InsertVideo1"), Title, Summary, VideoFile, Avatar, IsUrlWeb, Length, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int VD_UpdateVideo(int VideoId, string Title, string Summary, string VideoFile, string Avatar, bool IsUrlWeb, string Length, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "VD_UpdateVideo1"), VideoId, Title, Summary, VideoFile, Avatar, IsUrlWeb, Length, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
    }
}