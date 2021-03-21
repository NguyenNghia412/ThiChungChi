using System.Data;
using System.Data.SqlClient;

namespace nuce.ks.data
{
    public class AS_Edu_Survey_ReportTotal
    {
        public static DataTable get()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"SELECT  * FROM [dbo].[AS_Edu_Survey_ReportTotal] where (QuestionId=41 or QuestionId=42 or QuestionId=43) and Value is not null");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection,CommandType.Text, strSql).Tables[0];
                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable getClassRoom()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"SELECT  * FROM [dbo].[AS_Academy_ClassRoom]");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, CommandType.Text, strSql).Tables[0];
                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable getSubject()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"SELECT  * FROM [dbo].[AS_Academy_Subject]");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, CommandType.Text, strSql).Tables[0];
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
