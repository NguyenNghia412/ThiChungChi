using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class ServiceProvider
    {
        public static int TypeId
        {
            get
            {
                return 10;
            }
        }
        public static DataSet GetServicesByCategoriesWithPage(string strCategories, int portalId, int firstRow, int lastRow)
        {

            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[2];
                TableList[0] = "Total";
                TableList[1] = "GetServices";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "SV_GetService_ByCategoriesWithPage"), objDataSet, TableList, strCategories, portalId, firstRow, lastRow);
                return objDataSet;

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable GetService(int ServiceId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "GetService";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "SV_GetService"), objDataSet, TableList, ServiceId);
                return objDataSet.Tables["GetService"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int InsertImage(string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories,string addInfo1,string addInfo2,string addInfo3,string addInfo4,string addInfo5,string addRichInfo1,string addRichInfo2,string addRichInfo3)
        {
            int newId = -1;
            newId = SV_InsertService(Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5, addRichInfo1, addRichInfo2, addRichInfo3);
            CategoryProvider.AttachItemToManyCategories(newId, strCategories, TypeId, Title);
            return newId;
        }
        public static int UpdateImage(int ImageId, string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string strCategories, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5, string addRichInfo1, string addRichInfo2, string addRichInfo3)
        {
            int result = -1;
            result = SV_UpdateService(ImageId, Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5, addRichInfo1, addRichInfo2, addRichInfo3);
            CategoryProvider.AttachItemToManyCategories(ImageId, strCategories, TypeId, Title);
            return result;
        }
        public static int SV_InsertService(string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5, string addRichInfo1, string addRichInfo2, string addRichInfo3)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "SV_InsertService"), Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5, addRichInfo1, addRichInfo2, addRichInfo3).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int SV_UpdateService(int ImageId, string Title, string Summary, string ImageFile, string Avatar, bool IsUrlWeb, string Content, DateTime CreatedDate, DateTime ExpiredDate, DateTime DisplayDate, DateTime UpdatedDate, int UserId, bool IsHot, int HotPeriod, int PortalId, bool IsExpired, int Order, string addInfo1, string addInfo2, string addInfo3, string addInfo4, string addInfo5, string addRichInfo1, string addRichInfo2, string addRichInfo3)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "SV_UpdateService"), ImageId, Title, Summary, ImageFile, Avatar, IsUrlWeb, Content, CreatedDate, ExpiredDate, DisplayDate, UpdatedDate, UserId, IsHot, HotPeriod, PortalId, IsExpired, Order, addInfo1, addInfo2, addInfo3, addInfo4, addInfo5, addRichInfo1, addRichInfo2, addRichInfo3).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
    }
}