using System.Data;
using System.Data.SqlClient;

namespace nuce.web.data
{
    public static class dnn_NuceThi_DeThi
    {
        public static DataTable get(int DeThiID)
        {
            SqlParameter[] param = {
                new SqlParameter("@DeThiID", DeThiID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_get", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DeThi_get", DeThiID).Tables[0];
        }
        public static DataTable getRandomDeByBoDe(int BoDeID)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoDeID", BoDeID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_getRandomDeByBoDe", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DeThi_getRandomDeByBoDe", BoDeID).Tables[0];
        }
        public static DataTable getMa(int BoDeID)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoDeID", BoDeID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_getMa", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DeThi_getMa", BoDeID).Tables[0];
        }
        public static void deleteByBoDe(int BoDeID)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoDeID", BoDeID)
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_deleteByBoDe", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_DeThi_deleteByBoDe", BoDeID);
        }
        public static DataTable getByBoDe(int BoDeID)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoDeID", BoDeID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_getByBoDe", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DeThi_getByBoDe", BoDeID).Tables[0];
        }
        public static void update(int iID,int BoDeID,string Ma,string NoiDungDeThi,string DapAn,int Type)
        {
            SqlParameter[] param = {
                new SqlParameter("@DeThiID", iID),
                new SqlParameter("@BoDeID", BoDeID),
                new SqlParameter("@Ma", Ma),
                new SqlParameter("@NoiDungDeThi", NoiDungDeThi),
                new SqlParameter("@DapAn", DapAn),
                new SqlParameter("@Type", Type),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_update", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_DeThi_update", iID, BoDeID, Ma, NoiDungDeThi, DapAn, Type);
        }
        public static void updateStatus(int iID, int status)
        {
            SqlParameter[] param = {
                new SqlParameter("@DeThiID", iID),
                new SqlParameter("@Status", status),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_update_status", param);
            //DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("NuceThi_DeThi_update_status", iID, status);
        }
        public static int insert(int BoDeID, string Ma, string NoiDungDeThi, string DapAn, int Type)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoDeID", BoDeID),
                new SqlParameter("@Ma", Ma),
                new SqlParameter("@NoiDungDeThi", NoiDungDeThi),
                new SqlParameter("@DapAn", DapAn),
                new SqlParameter("@Type", Type),
            };
            var dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DeThi_insert", param).Tables[0];
            return (int)dt.Rows[0][0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteScalar<int>("NuceThi_DeThi_insert", BoDeID, Ma, NoiDungDeThi, DapAn, Type);
        }
    }
}
