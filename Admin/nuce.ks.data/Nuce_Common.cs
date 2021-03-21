using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace nuce.ks.data
{
    public static class Nuce_Common
    {
        #region Conection
        private static string m_strConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DBS"];
        public static string ConnectionString
        {
            get
            {
                return m_strConnectionString;
            }
        }

        private static string m_strPoolingConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DBS"];
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
        #region Conection D
        private static string m_strConnectionStringD = System.Configuration.ConfigurationSettings.AppSettings["DBD"];
        public static string ConnectionStringD
        {
            get
            {
                return m_strConnectionStringD;
            }
        }

        private static string m_strPoolingConnectionStringD = System.Configuration.ConfigurationSettings.AppSettings["DBD"];
        public static string PoolingConnectionStringD
        {
            get
            {
                return m_strPoolingConnectionStringD;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnectionD()
        {
            try
            {
                SqlConnection objConnection = new SqlConnection();
                try
                {
                    objConnection.ConnectionString = PoolingConnectionStringD;
                    objConnection.Open();
                }
                catch (Exception)
                {
                    if (objConnection.State != ConnectionState.Closed)
                        objConnection.Close();
                    //Open new connection if all the connections are being used
                    objConnection.ConnectionString = ConnectionStringD;
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


        #region Conection_k1_16_17
        private static string m_strConnectionString_k1_16_17 = System.Configuration.ConfigurationSettings.AppSettings["DB_k1_16_17"];
        public static string ConnectionString_k1_16_17
        {
            get
            {
                return m_strConnectionString_k1_16_17;
            }
        }

        private static string m_strPoolingConnectionString_k1_16_17 = System.Configuration.ConfigurationSettings.AppSettings["DB_k1_16_17"];
        public static string PoolingConnectionString_k1_16_17
        {
            get
            {
                return m_strPoolingConnectionString_k1_16_17;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection_k1_16_17()
        {
            try
            {
                SqlConnection objConnection_k1_16_17 = new SqlConnection();
                try
                {
                    objConnection_k1_16_17.ConnectionString = PoolingConnectionString_k1_16_17;
                    objConnection_k1_16_17.Open();
                }
                catch (Exception)
                {
                    if (objConnection_k1_16_17.State != ConnectionState.Closed)
                        objConnection_k1_16_17.Close();
                    //Open new connection if all the connections are being used
                    objConnection_k1_16_17.ConnectionString = ConnectionString;
                    objConnection_k1_16_17.Open();
                }

                return objConnection_k1_16_17;
            }
            catch
            {
                return null;
            }
        }
        #endregion


        #region Conection_k2_16_17
        private static string m_strConnectionString_k2_16_17 = System.Configuration.ConfigurationSettings.AppSettings["DB_k2_16_17"];
        public static string ConnectionString_k2_16_17
        {
            get
            {
                return m_strConnectionString_k2_16_17;
            }
        }

        private static string m_strPoolingConnectionString_k2_16_17 = System.Configuration.ConfigurationSettings.AppSettings["DB_k2_16_17"];
        public static string PoolingConnectionString_k2_16_17
        {
            get
            {
                return m_strPoolingConnectionString_k2_16_17;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection_k2_16_17()
        {
            try
            {
                SqlConnection objConnection_k2_16_17 = new SqlConnection();
                try
                {
                    objConnection_k2_16_17.ConnectionString = PoolingConnectionString_k2_16_17;
                    objConnection_k2_16_17.Open();
                }
                catch (Exception)
                {
                    if (objConnection_k2_16_17.State != ConnectionState.Closed)
                        objConnection_k2_16_17.Close();
                    //Open new connection if all the connections are being used
                    objConnection_k2_16_17.ConnectionString = ConnectionString;
                    objConnection_k2_16_17.Open();
                }

                return objConnection_k2_16_17;
            }
            catch
            {
                return null;
            }
        }
        #endregion


        #region Conection_k1_17_18
        private static string m_strConnectionString_k1_17_18 = System.Configuration.ConfigurationSettings.AppSettings["DB_k1_17_18"];
        public static string ConnectionString_k1_17_18
        {
            get
            {
                return m_strConnectionString_k1_17_18;
            }
        }

        private static string m_strPoolingConnectionString_k1_17_18 = System.Configuration.ConfigurationSettings.AppSettings["DB_k1_17_18"];
        public static string PoolingConnectionString_k1_17_18
        {
            get
            {
                return m_strPoolingConnectionString_k1_17_18;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection_k1_17_18()
        {
            try
            {
                SqlConnection objConnection_k1_17_18 = new SqlConnection();
                try
                {
                    objConnection_k1_17_18.ConnectionString = PoolingConnectionString_k1_17_18;
                    objConnection_k1_17_18.Open();
                }
                catch (Exception)
                {
                    if (objConnection_k1_17_18.State != ConnectionState.Closed)
                        objConnection_k1_17_18.Close();
                    //Open new connection if all the connections are being used
                    objConnection_k1_17_18.ConnectionString = ConnectionString;
                    objConnection_k1_17_18.Open();
                }

                return objConnection_k1_17_18;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Conection_k2_17_18
        private static string m_strConnectionString_k2_17_18 = System.Configuration.ConfigurationSettings.AppSettings["DB_k2_17_18"];
        public static string ConnectionString_k2_17_18
        {
            get
            {
                return m_strConnectionString_k2_17_18;
            }
        }

        private static string m_strPoolingConnectionString_k2_17_18 = System.Configuration.ConfigurationSettings.AppSettings["DB_k2_17_18"];
        public static string PoolingConnectionString_k2_17_18
        {
            get
            {
                return m_strPoolingConnectionString_k2_17_18;
            }
        }

        /// <summary>
        /// Return a database connection
        /// </summary>
        /// <returns>System.Data.SqlClient.SqlConnection</returns>
        public static SqlConnection GetConnection_k2_17_18()
        {
            try
            {
                SqlConnection objConnection_k2_17_18 = new SqlConnection();
                try
                {
                    objConnection_k2_17_18.ConnectionString = PoolingConnectionString_k2_17_18;
                    objConnection_k2_17_18.Open();
                }
                catch (Exception)
                {
                    if (objConnection_k2_17_18.State != ConnectionState.Closed)
                        objConnection_k2_17_18.Close();
                    //Open new connection if all the connections are being used
                    objConnection_k2_17_18.ConnectionString = ConnectionString;
                    objConnection_k2_17_18.Open();
                }

                return objConnection_k2_17_18;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public static String StripUnicodeCharactersFromString(string inputValue)
        {
            return Regex.Replace(inputValue, @"[^\u0000-\u007F]", String.Empty);
        }
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}
