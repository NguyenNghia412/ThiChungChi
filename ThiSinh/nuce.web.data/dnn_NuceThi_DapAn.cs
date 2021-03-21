using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace nuce.web.data
{
    public static class dnn_NuceThi_DapAn
    {
        public static DataTable get(int DapAnID)
        {
            SqlParameter[] param = {
                new SqlParameter("@DapAnID", DapAnID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DapAn_get", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DapAn_get", DapAnID).Tables[0];
        }
        public static DataTable getByCauHoi(int CauHoiID)
        {
            SqlParameter[] param = {
                new SqlParameter("@CauHoiID", CauHoiID)
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DapAn_getByCauHoi", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DapAn_getByCauHoi", CauHoiID).Tables[0];
        }
        public static DataTable getByBoCauHoiAndDoKho(int BoCauHoiID, int DoKhoID)
        {
            SqlParameter[] param = {
                new SqlParameter("@BoCauHoiID", BoCauHoiID),
                new SqlParameter("@DoKhoID", DoKhoID),
            };
            return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DapAn_getByBoCauHoiAndDoKho", param).Tables[0];
            //return DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("NuceThi_DapAn_getByBoCauHoiAndDoKho", BoCauHoiID, DoKhoID).Tables[0];
        }
        public static void update(int iID, int CauHoiID, int SubQuestionId, string Content, bool IsCheck, string Matching,
            float Mark, float MarkFail, int Order)
        {
            SqlParameter[] param = {
                new SqlParameter("@iID", iID),
                new SqlParameter("@CauHoiID", CauHoiID),
                new SqlParameter("@SubQuestionId", SubQuestionId),
                new SqlParameter("@Content", Content),
                new SqlParameter("@IsCheck", IsCheck),
                new SqlParameter("@Matching", Matching),
                new SqlParameter("@Mark", Mark),
                new SqlParameter("@MarkFail", MarkFail),
                new SqlParameter("@Order", Order),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DapAn_update", param);
            //DotNetNuke.Data.DataProvider.Instance()
            //    .ExecuteNonQuery("NuceThi_DapAn_update", iID, CauHoiID, SubQuestionId, Content, IsCheck, Matching
            //    , Mark, MarkFail, Order);
        }
        /*
        @CauHoiID int,
  @SubQuestionId int,
  @Content nvarchar(max),
  @IsCheck bit,
  @Matching nvarchar(max),
  @Mark float,
  @MarkFail float,
  @Order int,
  @Status int*/
        public static int insert(int CauHoiID, int SubQuestionId,string Content, bool IsCheck,string Matching,
            float Mark,float MarkFail,int Order,int Status)
        {
            SqlParameter[] param = {
                new SqlParameter("@CauHoiID", CauHoiID),
                new SqlParameter("@SubQuestionId", SubQuestionId),
                new SqlParameter("@Content", Content),
                new SqlParameter("@IsCheck", IsCheck),
                new SqlParameter("@Matching", Matching),
                new SqlParameter("@Mark", Mark),
                new SqlParameter("@MarkFail", MarkFail),
                new SqlParameter("@Order", Order),
                new SqlParameter("@Status", Status),
            };
            var dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_DapAn_insert", param).Tables[0];
            return (int)dt.Rows[0][0];
        }
    }
}
