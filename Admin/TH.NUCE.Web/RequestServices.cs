using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TH.NUCE.Web
{
    public static class RequestServices
    {
        public static int TypeId
        {
            get
            {
                return 13;
            }
        }
        public static DataSet GetListsWithPage(string strCategories, int portalId,int status,int userId, int firstRow, int lastRow)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[2];
                TableList[0] = "Total";
                TableList[1] = "GetRequestServices";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Common", "RequestServices_GetListsWithPage"), objDataSet, TableList, strCategories,portalId,status,userId, firstRow, lastRow);
                return objDataSet;
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static void UpdateStatus(int RequestServicesID,int Status)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            try
            {
                SqlHelper.ExecuteNonQuery(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Common", "RequestServices_UpdateStatus"), RequestServicesID, Status);
            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
        public static DataTable GetDetail(int RequestServicesID,int Status)
        {
            SqlConnection objConnection = new SqlConnection(Connection.UtilsProvider.ObjUtils.StrConnection);
            DataSet objDataSet = new DataSet();
            try
            {
                objDataSet.EnforceConstraints = false;
                string[] TableList = new string[1];
                TableList[0] = "GetDetail";
                SqlHelper.FillDataset(objConnection, Connection.UtilsProvider.ObjUtils.GetStoreName_THComponent("Common", "RequestServices_GetDetail"), objDataSet, TableList, RequestServicesID,Status);
                return objDataSet.Tables["GetDetail"];

            }
            finally
            {
                if (null != objConnection)
                    objConnection.Close();
            }
        }
    }
}