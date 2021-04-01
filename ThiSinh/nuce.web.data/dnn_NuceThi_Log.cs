using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuce.web.data
{
    public static class dnn_NuceThi_Log
    {
        public static void insertLog(int nguoiThiID, string Message, string Notice)
        {
            SqlParameter[] param = {
                new SqlParameter("@NguoiThiId", nguoiThiID),
                new SqlParameter("@Message", Message),
                new SqlParameter("@Notice", Notice),
            };
            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(Nuce_ThiChungChi.ConnectionString, CommandType.StoredProcedure, "NuceThi_insert_log", param);
        }
    }
}
