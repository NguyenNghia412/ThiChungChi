using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class ImageProvider
    {
        public static int TypeId
        {
            get
            {
                return 4;
            }
        }
        public static DataTable GetImage(int ImageId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "GetImage";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "IG_GetImage"), objDataSet, TableList, ImageId);
                return objDataSet.Tables["GetImage"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int InsertImage(string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories,string addInfo1,string addInfo2,string addInfo3,string addInfo4,string addInfo5)
        {
            int newId = -1;
            newId = IG_InsertImage(Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5);
            CategoryProvider.AttachItemToManyCategories(newId, strCategories, TypeId, Title);
            return newId;
        }
        public static int UpdateImage(int ImageId, string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            int result = -1;
            result = IG_UpdateImage(ImageId, Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5);
            CategoryProvider.AttachItemToManyCategories(ImageId, strCategories, TypeId, Title);
            return result;
        }
        public static int IG_InsertImage(string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "IG_InsertImage1"), Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int IG_UpdateImage(int ImageId, string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Gallery", "IG_UpdateImage1"), ImageId, Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order,addInfo1, addInfo2, addInfo3, addInfo4, addInfo5).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
    }
}