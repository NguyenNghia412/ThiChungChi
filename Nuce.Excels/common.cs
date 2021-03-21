using System;
using System.Data;
using System.Data.SqlClient;

namespace Nuce.Excels
{
    public static class common
    {
        #region Conection
        private static string m_strConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DBLocal"];
        public static string ConnectionString
        {
            get
            {
                return m_strConnectionString;
            }
        }

        private static string m_strPoolingConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DBLocal"];
        public static string PoolingConnectionString
        {
            get
            {
                return m_strPoolingConnectionString;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection objConnection = new SqlConnection();
                try
                {
                    objConnection.ConnectionString = PoolingConnectionString;
                    objConnection.Open();
                }
                catch (Exception)
                {
                    if (objConnection.State != ConnectionState.Closed)
                        objConnection.Close();
                    //Open new connection if all the connections are being used
                    objConnection.ConnectionString = ConnectionString;
                    objConnection.Open();
                }

                return objConnection;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Conection1
        private static string m_strConnectionString1 = System.Configuration.ConfigurationSettings.AppSettings["DBLocal1"];
        public static string ConnectionString1
        {
            get
            {
                return m_strConnectionString1;
            }
        }

        private static string m_strPoolingConnectionString1 = System.Configuration.ConfigurationSettings.AppSettings["DBLocal1"];
        public static string PoolingConnectionString1
        {
            get
            {
                return m_strPoolingConnectionString1;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection1()
        {
            try
            {
                SqlConnection objConnection1 = new SqlConnection();
                try
                {
                    objConnection1.ConnectionString = PoolingConnectionString1;
                    objConnection1.Open();
                }
                catch (Exception)
                {
                    if (objConnection1.State != ConnectionState.Closed)
                        objConnection1.Close();
                    //Open new connection if all the connections are being used
                    objConnection1.ConnectionString = ConnectionString1;
                    objConnection1.Open();
                }

                return objConnection1;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region add function
        public static DataRow[] getDeparmentFromFacultyCode(DataTable dt, string code)
        {
            return dt.Select(string.Format("FacultyCode= '{0}' ", code), "Code");

        }
        public static bool checkLecturerBeSurvedByDepartement(DataTable dt, string Code)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["LecturerCode"].ToString().Trim().Equals(Code))
                    return true;
            }
            return false;
        }
        public static string getTextFromQuestionAndLecturer(DataTable dt, int QId, int LecId)
        {
            string strReturn = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["LecturerId"].ToString().Trim().Equals(LecId.ToString())&& dt.Rows[i]["QuestionId"].ToString().Trim().Equals(QId.ToString()))
                    strReturn+= dt.Rows[i]["Value"].ToString()+ "; ";
            }
            strReturn = strReturn.Replace(";;", "");
            strReturn = strReturn.Replace("; không;", "");
            strReturn = strReturn.Replace("; Không;", "");
            strReturn = strReturn.Replace(";không;", "");
            strReturn = strReturn.Replace("; không có;", "");
            strReturn = strReturn.Replace("; Không có;", "");
            strReturn = strReturn.Replace(";không có;", "");
            strReturn = strReturn.Replace("; ko;", "");
            strReturn = strReturn.Replace(";ko;", "");
            return strReturn;
        }
        public static string getTextFromClassroom(DataTable dt, int QId, int ClassRoomID)
        {
            string strReturn = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ClassRoomId"].ToString().Trim().Equals(ClassRoomID.ToString()) && dt.Rows[i]["QuestionId"].ToString().Trim().Equals(QId.ToString()))
                    strReturn += dt.Rows[i]["Value"].ToString() + "; ";
            }
            strReturn = strReturn.Replace(";;", "");
            strReturn = strReturn.Replace("; không;", "");
            strReturn = strReturn.Replace("; Không;", "");
            strReturn = strReturn.Replace(";không;", "");
            strReturn = strReturn.Replace("; không có;", "");
            strReturn = strReturn.Replace("; Không có;", "");
            strReturn = strReturn.Replace(";không có;", "");
            strReturn = strReturn.Replace("; ko;", "");
            strReturn = strReturn.Replace(";ko;", "");
            return strReturn;
        }
        #endregion
    }
}
