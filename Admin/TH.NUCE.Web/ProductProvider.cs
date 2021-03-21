using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class ProductProvider
    {
        public static int TypeId
        {
            get
            {
                return 3;
            }
        }
        public static int InsertProduct(string ProductName, string Lead, string Summary, string Smallimage, string Largeimage, double Weight, DateTime CreatedDate, DateTime ExpiredDate, DateTime UpdatedDate, DateTime ProducedDate, bool IsProducedDate, bool IsExpired, bool IsHot, int HotPeriod, int UserId, int PortalId, bool IsDeleted, int Price, int PriceOld, string StatusProduct, string ExtendedSettings, int Order, string strCategories, string strCode, string strAddImage1, string strAddImage2, string strAddImage3, DateTime dtDisplayDate, string strAddInfo1, string strAddInfo2, string strAddInfo3,string strAddInfo4,string strAddInfo5,string strAddInfo6, string strAddRichInfo1, string strAddRichInfo2, string strAddRichInfo3, string strTags, int TagGroupId)
        {
            int newId = -1;
            newId = PD_InsertProduct(ProductName, Lead, Summary, Smallimage, Largeimage, Weight, CreatedDate, ExpiredDate, UpdatedDate, ProducedDate, IsProducedDate, IsExpired, IsHot, HotPeriod, UserId, PortalId, IsDeleted, Price, PriceOld, StatusProduct, Order, ExtendedSettings, strCode, strAddImage1, strAddImage2, strAddImage3, dtDisplayDate, strAddInfo1, strAddInfo2, strAddInfo3, strAddRichInfo1, strAddRichInfo2, strAddRichInfo3,strAddInfo4,strAddInfo5,strAddInfo6);
            CategoryProvider.AttachItemToManyCategories(newId, strCategories, TypeId, ProductName);
            TagProvider.AttachItemToManyTags(newId, strTags, TypeId, TagGroupId);
            return newId;
        }

        public static int UpdateProduct(int ProductId, string ProductName, string Lead, string Summary, string Smallimage, string Largeimage, double Weight, DateTime CreatedDate, DateTime ExpiredDate, DateTime UpdatedDate, DateTime ProducedDate, bool IsProducedDate, bool IsExpired, bool IsHot, int HotPeriod, int UserId, int PortalId, bool IsDeleted, int Price, int PriceOld, string StatusProduct, int Order, string ExtendedSettings, string strCategories, string strCode, string strAddImage1, string strAddImage2, string strAddImage3, DateTime dtDisplayDate, string strAddInfo1, string strAddInfo2, string strAddInfo3,string strAddInfo4,string strAddInfo5,string strAddInfo6, string strAddRichInfo1, string strAddRichInfo2, string strAddRichInfo3, string strTags, int TagGroupId)
        {
            int result = -1;
            result = PD_UpdateProduct(ProductId, ProductName, Lead, Summary, Smallimage, Largeimage, Weight, CreatedDate, ExpiredDate, UpdatedDate, ProducedDate, IsProducedDate, IsExpired, IsHot, HotPeriod, UserId, PortalId, IsDeleted, Price, PriceOld, StatusProduct, Order, ExtendedSettings, strCode, strAddImage1, strAddImage2, strAddImage3, dtDisplayDate, strAddInfo1, strAddInfo2, strAddInfo3, strAddRichInfo1, strAddRichInfo2, strAddRichInfo3, strAddInfo4, strAddInfo5, strAddInfo6);
            CategoryProvider.AttachItemToManyCategories(ProductId, strCategories, TypeId, ProductName);
            TagProvider.AttachItemToManyTags(ProductId, strTags, TypeId, TagGroupId);
            return result;
        }

        public static DataTable GetProduct(int ProductId)
        {
            return PD_GetProduct(ProductId);
        }
        #region Process Data
        public static int PD_InsertProduct(string ProductName, string Lead, string Summary, string Smallimage, string Largeimage, double Weight, DateTime CreatedDate, DateTime ExpiredDate, DateTime UpdatedDate, DateTime ProducedDate, bool IsProducedDate, bool IsExpired, bool IsHot, int HotPeriod, int UserId, int PortalId, bool IsDeleted, int Price, int PriceOld, string StatusProduct, int Order, string ExtendedSettings, string strCode, string strAddImage1, string strAddImage2, string strAddImage3, DateTime dtDisplayDate, string strAddInfo1, string strAddInfo2, string strAddInfo3, string strAddRichInfo1, string strAddRichInfo2, string strAddRichInfo3,string strAddInfo4,string strAddInfo5,string strAddInfo6)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "PD_InsertProduct1"), ProductName, Lead, Summary, Smallimage, Largeimage, Weight, CreatedDate, ExpiredDate, UpdatedDate, ProducedDate, IsProducedDate, IsExpired, IsHot, HotPeriod, UserId, PortalId, IsDeleted, Price, PriceOld, StatusProduct, Order, ExtendedSettings, strCode, strAddImage1, strAddImage2, strAddImage3, dtDisplayDate, strAddInfo1, strAddInfo2, strAddInfo3, strAddRichInfo1, strAddRichInfo2, strAddRichInfo3,strAddInfo4,strAddInfo5,strAddInfo6).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static int PD_UpdateProduct(int ProductId, string ProductName, string Lead, string Summary, string Smallimage, string Largeimage, double Weight, DateTime CreatedDate, DateTime ExpiredDate, DateTime UpdatedDate, DateTime ProducedDate, bool IsProducedDate, bool IsExpired, bool IsHot, int HotPeriod, int UserId, int PortalId, bool IsDeleted, int Price, int PriceOld, string StatusProduct, int Order, string ExtendedSettings, string strCode, string strAddImage1, string strAddImage2, string strAddImage3, DateTime dtDisplayDate, string strAddInfo1, string strAddInfo2, string strAddInfo3, string strAddRichInfo1, string strAddRichInfo2, string strAddRichInfo3, string strAddInfo4, string strAddInfo5, string strAddInfo6)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                return int.Parse(SqlHelper.ExecuteScalar(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "PD_UpdateProduct1"), ProductId, ProductName, Lead, Summary, Smallimage, Largeimage, Weight, CreatedDate, ExpiredDate, UpdatedDate, ProducedDate, IsProducedDate, IsExpired, IsHot, HotPeriod, UserId, PortalId, IsDeleted, Price, PriceOld, StatusProduct, Order, ExtendedSettings, strCode, strAddImage1, strAddImage2, strAddImage3, dtDisplayDate, strAddInfo1, strAddInfo2, strAddInfo3, strAddRichInfo1, strAddRichInfo2, strAddRichInfo3, strAddInfo4, strAddInfo5, strAddInfo6).ToString());
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }

        public static DataTable PD_GetProduct(int ProductId)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "GetProduct";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "PD_GetProduct"), objDataSet, TableList, ProductId);
                return objDataSet.Tables["GetProduct"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataSet PD_GetProducts_SearchProducts1(string Code,bool isGroup, string ProductName, string Lead, string Summary, string categories, int portalId, int firstRow, int lastRow)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[2];
                TableList[0] = "Total";
                TableList[1] = "SearchProducts";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Ecommerce", "PD_SearchProducts1"), objDataSet, TableList, Code,isGroup, ProductName, Lead, Summary, categories, portalId, firstRow, lastRow);
                return objDataSet;

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