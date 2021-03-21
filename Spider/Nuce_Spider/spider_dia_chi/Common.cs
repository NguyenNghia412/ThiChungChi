using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace spider_dia_chi
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
        #region Logs
        public static void WriteLogNotFile(string description)
        {
            string strMessage = string.Format("{0:HH:mm:ss}\t{1}", DateTime.Now, description);
            Console.WriteLine(strMessage);
        }
        public static void WriteLog(string description)
        {
            System.IO.StreamWriter objStreamWriter = OpenLogFile();
            string strMessage = string.Format("{0:HH:mm:ss}\t{1}", DateTime.Now, description);
            objStreamWriter.WriteLine(strMessage);
            objStreamWriter.Flush();
            objStreamWriter.Close();
            objStreamWriter.Dispose();
            Console.WriteLine(strMessage);
        }
        public static string LogFolder = new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName + "\\Logs";
        public static void ClearLogFiles()
        {
            if (!System.IO.Directory.Exists(LogFolder))
                return;
        }
        public static System.IO.StreamWriter OpenLogFile()
        {
            try
            {
                if (!System.IO.Directory.Exists(LogFolder))
                    System.IO.Directory.CreateDirectory(LogFolder);
                string strLogFile = string.Format("{0}\\{1:yyyyMMdd-HH}.log", LogFolder, DateTime.Now);

                if (!System.IO.File.Exists(strLogFile))
                {
                    System.IO.StreamWriter objStreamWriter = System.IO.File.CreateText(strLogFile);
                    objStreamWriter.WriteLine("Time\tDescription");
                    objStreamWriter.Flush();
                    objStreamWriter.Close();
                    objStreamWriter.Dispose();
                }

                return System.IO.File.AppendText(strLogFile);
            }
            catch
            {
                Thread.Sleep(10);
                return OpenLogFile();
            }
        }
        #endregion
    }
}
