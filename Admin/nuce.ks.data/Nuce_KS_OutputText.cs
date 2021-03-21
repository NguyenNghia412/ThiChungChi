using System.Data;
using System.Data.SqlClient;

namespace nuce.ks.data
{
    public class Nuce_KS_OutputText
    {
        public static void insert(string text, string textOld, string reference, string survey)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnectionD())
            {
                if (objConnection == null)
                    return ;
                try
                {
                    //Execute select command
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, "Nuce_KS_OutputText_insert", text, textOld, reference, survey);
                }
                catch
                {
                    return ;
                }
            }
            return;
        }
        public static void insert(string text, string textOld, string reference, string survey,int Type,string SubjectCode,string SubjectName)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnectionD())
            {
                if (objConnection == null)
                    return;
                try
                {
                    //Execute select command
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, "Nuce_KS_OutputText_insert1", text, textOld, reference, survey,Type,SubjectCode,SubjectName);
                }
                catch
                {
                    return;
                }
            }
            return;
        }
        public static DataSet getThongKe2018()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnectionD())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_OutputText_GetThongKe_2018");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
