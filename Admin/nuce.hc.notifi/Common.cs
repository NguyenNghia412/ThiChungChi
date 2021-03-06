using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace nuce.hc.notifi
{
    partial class Program
    {
        #region config
        private static int m_TimeInterval = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TimeInterval"]);

        /*
       
        private static int m_CountChild = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["CountChild"]);
        private static string m_NVI = System.Configuration.ConfigurationSettings.AppSettings["NVI"];
        private static int m_Rat1 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat1"]);
        private static int m_Rat2 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat2"]);
        private static int m_Rat3 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat3"]);
        private static int m_Rat4 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat4"]);
        private static int m_Rat5 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat5"]);
        private static int m_Rat6 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat6"]);
        private static int m_Rat7 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat7"]);
        private static int m_Rat8 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat8"]);
        private static int m_Rat9 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Rat9"]);

        private static int m_Set1 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set1"]);
        private static int m_Set2 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set2"]);
        private static int m_Set3 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set3"]);
        private static int m_Set4 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set4"]);
        private static int m_Set5 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set5"]);
        private static int m_Set6 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set6"]);
        private static int m_Set7 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set7"]);
        private static int m_Set8 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set8"]);
        private static int m_Set9 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Set9"]);

        private static int m_Star1 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star1"]);
        private static int m_Star2 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star2"]);
        private static int m_Star3 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star3"]);
        private static int m_Star4 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star4"]);
        private static int m_Star5 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star5"]);
        private static int m_Star6 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star6"]);
        private static int m_Star7 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star7"]);
        private static int m_Star8 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star8"]);
        private static int m_Star9 = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["Star9"]);
        private static int m_Floor = 11;
        */

        #endregion
        #region Conection
        private static string m_strConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DB"];
        public static string ConnectionString
        {
            get
            {
                return m_strConnectionString;
            }
        }

        private static string m_strPoolingConnectionString = System.Configuration.ConfigurationSettings.AppSettings["DB"];
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

        #region email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static void Send_Email(string Subject,string Message,string EmailTo)
        {
            try
            {
                // Gui Mail
                string strSubject = Subject;
                string strMessage = Message;
                string strEmailTo = EmailTo;

                string strEmailSend = "elive@nuce.edu.vn";
                string strSmpt = "smtp.gmail.com";
                int iPort = 587;
                //int iIsSSL = 1;
                bool isSSL = true;
                string strUserNameSend = "elive@nuce.edu.vn";
                string strPasswordSend = "nuce@#2017";
                WriteLog(Send_Email(strEmailSend, strEmailTo, strSubject, strMessage, strSmpt, iPort, isSSL, strUserNameSend, strPasswordSend));
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
        }


        public static string Send_Email(string SendFrom, string SendTo, string Subject, string Body, string smtpAdr, int port, bool isSSL, string UserName, string Password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


                bool result = regex.IsMatch(SendTo);
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {
                    System.Net.Mail.SmtpClient smtp = new SmtpClient();
                    System.Net.Mail.MailMessage msg = new MailMessage(SendFrom, SendTo, Subject, Body);
                    msg.IsBodyHtml = true;
                    smtp.Host = smtpAdr;//"smtp.gmail.com";//Sử dụng SMTP của gmail 
                    smtp.Port = port;
                    smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);
                    smtp.EnableSsl = isSSL;
                    smtp.Send(msg);
                    return "Email đã được gửi đến: " + SendTo + ".";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public static string Send_Email(string SendFrom, string SendTo, string Subject, string Body,bool isHtmlBody, string smtpAdr, int port, bool isSSL, string UserName, string Password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


                bool result = regex.IsMatch(SendTo);
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {
                    System.Net.Mail.SmtpClient smtp = new SmtpClient();
                    System.Net.Mail.MailMessage msg = new MailMessage(SendFrom, SendTo, Subject, Body);
                    msg.IsBodyHtml = isHtmlBody;
                    smtp.Host = smtpAdr;//"smtp.gmail.com";//Sử dụng SMTP của gmail 
                    smtp.Port = port;
                    smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);
                    smtp.EnableSsl = isSSL;
                    smtp.Send(msg);
                    return "Email đã được gửi đến: " + SendTo + ".";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string Send_Email_With_Attachment(string SendTo, string SendFrom, string Subject, string Body, string AttachmentPath, string smtpAdr, int port, bool isSSL, string UserName, string Password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                string from = SendFrom;
                string to = SendTo;
                string subject = Subject;
                string body = Body;
                bool result = regex.IsMatch(to);
                if (result == false)
                {
                    return "Địa chỉ email không hợp lệ.";
                }
                else
                {
                    try
                    {
                        MailMessage em = new MailMessage(from, to, subject, body);
                        Attachment attach = new Attachment(AttachmentPath);
                        em.Attachments.Add(attach);
                        em.Bcc.Add(from);
                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        smtp.Host = smtpAdr;//"smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail 
                        smtp.Port = port;
                        smtp.EnableSsl = isSSL;
                        smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);
                        smtp.Send(em);
                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Send_Email_With_BCC_Attachment(string SendTo, string SendBCC, string SendFrom, string Subject, string Body, string AttachmentPath, string smtpAdr, int port, bool isSSL, string UserName, string Password)
        {
            try
            {
                System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                string from = SendFrom;
                string to = SendTo; //Danh sách email được ngăn cách nhau bởi dấu ";" 
                string subject = Subject;
                string body = Body;
                string bcc = SendBCC;
                bool result = true;
                String[] ALL_EMAILS = to.Split(';');
                foreach (string emailaddress in ALL_EMAILS)
                {
                    result = regex.IsMatch(emailaddress);
                    if (result == false)
                    {
                        return "Địa chỉ email không hợp lệ.";
                    }
                }
                if (result == true)
                {
                    try
                    {
                        MailMessage em = new MailMessage(from, to, subject, body);
                        Attachment attach = new Attachment(AttachmentPath);
                        em.Attachments.Add(attach);
                        em.Bcc.Add(bcc);
                        

                        System.Net.Mail.SmtpClient smtp = new SmtpClient();
                        smtp.Host = smtpAdr;//"smtp.gmail.com";//Ví dụ xử dụng SMTP của gmail 
                        smtp.Port = port;
                        smtp.EnableSsl = isSSL;
                        smtp.Credentials = new System.Net.NetworkCredential(UserName, Password);
                        smtp.Send(em);

                        return "";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion
        #region addFunction

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        public static string GetThu(int input)
        {
            switch(input)
            {
                case 0: return "Chủ nhật";
                case 1: return "Thứ 2";
                case 2: return "Thứ 3";
                case 3: return "Thứ 4";
                case 4: return "Thứ 5";
                case 5: return "Thứ 6";
                case 6: return "Thứ 7";
                default: break;
            }
            return "";
        }
        #endregion
    }
}
