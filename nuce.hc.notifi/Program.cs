using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace nuce.hc.notifi
{
    partial class Program
    {
        static void Main(string[] args)
        {
            WriteLog("Begin");

            while (true)
            {
                //Run1();
                System.Threading.Thread.Sleep(10000);
                //Run();
                //Run();
                //if (!IsRunEndMonth&&DateTime.Now.Day.Equals(1) && DateTime.Now.Hour == 0 && DateTime.Now.Minute < 10)
                //{
                //    TinhToanChiaThuongCuoiThang();
                //    System.Threading.Thread.Sleep(m_TimeInterval);
                //    TinhToanLenSaoCuoiThang();
                //    System.Threading.Thread.Sleep(m_TimeInterval);
                //}
                Run2();
                WriteLog("Waiting");
                System.Threading.Thread.Sleep(m_TimeInterval);
            }
            //Test();
            Console.ReadLine();
        }
        public static void Test()
        {
            Send_Email("test", string.Format("<b>Hoàng nam thắng</b> <br /> Dòng text dài cần xuống hàng<br />Đã xuống hàng.</br>"), "namthangbk@gmail.com");
        }
        public static void Run1()
        {
            using (SqlConnection objConnection = GetConnection())
            {
                if (objConnection == null)
                    WriteLog("Can not connect to database!!!");
                try
                {
                    //Execute select command
                    string strSql = string.Format("[dbo].[VnsEvent_get]");
                    string strSqlInsert = string.Format("[dbo].[dnn_Nuce_Log_insert]");
                    //WriteLogNotFile(strSql);
                    DataSet objDS = new DataSet();
                    objDS = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql);
                    if (objDS != null || objDS.Tables.Count > 0)
                    {
                        DataTable dtData = objDS.Tables[0];
                        int iEventId;
                        DateTime dtLastUpdatedDate;
                        int iStatusId;
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            iEventId = int.Parse(dtData.Rows[i]["EventId"].ToString());
                            dtLastUpdatedDate = DateTime.Parse(dtData.Rows[i]["LastUpdatedDate"].ToString());
                            iStatusId = int.Parse(dtData.Rows[i]["StatusId"].ToString());
                            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, strSqlInsert, 2, iEventId, 1, "", DateTime.Now, dtLastUpdatedDate, -1, -1);
                            // WriteLog(string.Format("Vua insert vao log ban ghi co eventid: {0}; lan cuoi update la {1};", iEventId, dtLastUpdatedDate));
                            // Send_Email("thanghnTest", strDescription, "namthangbk@gmail.com");
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(ex.ToString());
                }
                finally
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
        }
        public static void Run()
        {
            using (SqlConnection objConnection = GetConnection())
            {
                if (objConnection == null)
                    WriteLog("Can not connect to database!!!");
                try
                {
                    //Execute select command
                    string strSql = string.Format("[dbo].[dnn_Nuce_Log_getByStatus]");
                    string strSqlUpdateNuceLog = string.Format("[dbo].[dnn_Nuce_Log_update_status]");
                    //WriteLogNotFile(strSql);
                    DataSet objDS = new DataSet();
                    DataSet objDSData = new DataSet();
                    objDS = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, 1);
                    if (objDS != null || objDS.Tables.Count > 0)
                    {
                        DataTable dtData = objDS.Tables[0];

                        DataTable dtData1;
                        DataTable dtData2;
                        DataTable dtData3;

                        string strNoiDung = "";
                        string strNoiDung1 = "";
                        string strNoiDung11 = "";
                        string strNoiDung2 = "";
                        string strNoiDung3 = "";
                        string strTieuDe = "";
                        string strEmailChairman = "";
                        string strEmailReg = "";
                        string strLocationName = "";
                        string strLocationName1 = "";

                        //LocationName1
                        string strChairmanName = "";
                        string strRegName = "";
                        string strParticipate = "";

                        DateTime dtStart;
                        DateTime dtEnd;

                        string strEmailParticipate;

                        int iLogId;
                        string strDescription = "";
                        int iLogType;
                        int iPartnerId;
                        List<string> lsEmailCheck = new List<string>();
                        for (int i = 0; i < dtData.Rows.Count; i++)
                        {
                            lsEmailCheck = new List<string>();
                            lsEmailCheck.Clear();
                            strNoiDung = "";
                            strNoiDung1 = string.Format("Kính mời thầy/cô:&nbsp;");
                            strNoiDung11 = string.Format("Kính mời:&nbsp;");
                            strNoiDung2 = " đến tham gia cuộc họp <br /> ";
                            strNoiDung3 = "";
                            strTieuDe = "";
                            strEmailChairman = "";
                            strEmailReg = "";
                            strLocationName = "";
                            strChairmanName = "";
                            strRegName = "";
                            strParticipate = "";

                            //strDescription = dtData.Rows[i]["Description"].ToString();
                            //WriteLog(strDescription);
                            iLogId = int.Parse(dtData.Rows[i]["LogId"].ToString());
                            iLogType = int.Parse(dtData.Rows[i]["LogType"].ToString());
                            iPartnerId = int.Parse(dtData.Rows[i]["PartnerId"].ToString());
                            objDSData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, "[dbo].[VnsEvent_getByEventId]", iPartnerId);
                            dtData1 = objDSData.Tables[0];
                            dtData2 = objDSData.Tables[1];
                            dtData3 = objDSData.Tables[2];
                            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, strSqlUpdateNuceLog, iLogId, 2);
                            strNoiDung = dtData1.Rows[0]["NoiDung"].ToString();
                            strEmailChairman = dtData1.Rows[0]["EmailChairman"].ToString();
                            strEmailReg = dtData1.Rows[0]["EmailReg"].ToString();
                            strLocationName = dtData1.Rows[0]["LocationName"].ToString();
                            strLocationName1 = dtData1.Rows[0]["LocationName1"].ToString();
                            strChairmanName = dtData1.Rows[0]["ChairmanName"].ToString();
                            strRegName = dtData1.Rows[0]["RegName"].ToString();
                            dtStart = DateTime.Parse(dtData1.Rows[0]["Start"].ToString());
                            dtEnd = DateTime.Parse(dtData1.Rows[0]["End"].ToString());
                            strParticipate = dtData1.Rows[0]["Participate"].ToString();
                            int dayI = ((int)dtStart.DayOfWeek);
                            strTieuDe = string.Format("Giấy mời: {1}h, {0} ngày {2}/{3}/{4}, tại {5} {6}", GetThu(dayI), dtStart.Hour, dtStart.Day, dtStart.Month, dtStart.Year, strLocationName, strLocationName1);

                            strNoiDung2 += " <b style='color:#b2062b;'>* Nội dung: </b><br /><span  style='padding-left:25px;'>" + StripHTML(HttpUtility.HtmlDecode(strNoiDung)) + "</span>";
                            strNoiDung2 += string.Format(" <br /><b style='color:#b2062b;'> * Thời gian: </b>{1}h, {0} ngày {2}/{3}/{4} <br /> <b style='color:#b2062b;'> * Địa điểm:</b>&nbsp;{5} {6}", GetThu(dayI), dtStart.Hour, dtStart.Day, dtStart.Month, dtStart.Year, strLocationName, strLocationName1);
                            strNoiDung2 += string.Format(" <br /> <b style='color:#b2062b;'>* Thành phần cuộc họp:</b> <br /> <span  style='padding-left:25px;'> + Chủ trì:&nbsp;</span> <br />");
                            strNoiDung2 += string.Format("<span  style='padding-left:50px;'>&nbsp;{0}</span>", strChairmanName);
                            strNoiDung2 += string.Format(" <br /><span  style='padding-left:25px;'> + Thành phần tham gia:&nbsp;</span>");
                            for (int j = 0; j < dtData3.Rows.Count; j++)
                            {
                                strNoiDung2 += string.Format("<br /><span  style='padding-left:50px;'>&nbsp;{0}</span>", dtData3.Rows[j]["DepartmentName"].ToString());
                            }
                            for (int j = 0; j < dtData2.Rows.Count; j++)
                            {
                                strNoiDung2 += string.Format("<br /><span  style='padding-left:50px;'>&nbsp;{0}</span>", dtData2.Rows[j]["DisplayName"].ToString());
                            }

                            strNoiDung2 = strNoiDung2.Remove(strNoiDung2.Length - 1, 1);
                            if (!strParticipate.Trim().Equals(""))
                            {
                                strNoiDung2 += string.Format(" <br /><span  style='padding-left:25px;'> + Thành phần khác:&nbsp;</span>");
                                strNoiDung2 += string.Format("<br /><span  style='padding-left:50px;'>&nbsp;{0}</span>", strParticipate);
                            }


                            strNoiDung2 += string.Format(" <br /> Xem nội dung chi tiết đăng nhập tại:&nbsp;<a href='http://testhc.nuce.edu.vn/Default.aspx?tabid=74&Date={0}/{1}/{2}&ViewMode=0&ListType=week'>đường dẫn</a> ", dtStart.Day, dtStart.Month, dtStart.Year);
                            strNoiDung2 += string.Format(" <br /> Kính mời các thầy/cô đến tham dự đúng giờ. <br /> Email này thay cho giấy mời.<br /> <br />Trân trọng! <br />");

                            strNoiDung3 = strNoiDung1 + "<b style='color:#2c3e98;'>" + strChairmanName + "</b>";
                            Send_Email(strTieuDe, strNoiDung3 + strNoiDung2, strEmailChairman);
                            lsEmailCheck.Add(strEmailChairman);
                            System.Threading.Thread.Sleep(2000);
                            if (!lsEmailCheck.Contains(strEmailReg))
                            {
                                strNoiDung3 = strNoiDung1 + "<b style='color:#2c3e98;'>" + strRegName + "</b>";
                                Send_Email(strTieuDe, strNoiDung3 + strNoiDung2, strEmailReg);
                                lsEmailCheck.Add(strEmailReg);
                                System.Threading.Thread.Sleep(2000);
                            }
                            for (int j = 0; j < dtData2.Rows.Count; j++)
                            {
                                strEmailParticipate = dtData2.Rows[j]["Email"].ToString();
                                strNoiDung3 = strNoiDung1 + "<b style='color:#2c3e98;'>" + dtData2.Rows[j]["DisplayName"].ToString() + " </b>";
                                if (!lsEmailCheck.Contains(strEmailParticipate))
                                {
                                    Send_Email(strTieuDe, strNoiDung3 + strNoiDung2, strEmailParticipate);
                                    System.Threading.Thread.Sleep(2000);
                                    lsEmailCheck.Add(strEmailParticipate);
                                }
                            }

                            for (int j = 0; j < dtData3.Rows.Count; j++)
                            {
                                strEmailParticipate = dtData3.Rows[j]["Email"].ToString();
                                strNoiDung3 = strNoiDung11 + "<b style='color:#2c3e98;'>" + dtData3.Rows[j]["DepartmentName"].ToString() + "</b>";
                                if (!strEmailParticipate.Trim().Equals(""))
                                {
                                    if (!lsEmailCheck.Contains(strEmailParticipate))
                                    {
                                        Send_Email(strTieuDe, strNoiDung3 + strNoiDung2, strEmailParticipate);
                                        System.Threading.Thread.Sleep(5000);
                                        lsEmailCheck.Add(strEmailParticipate);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(ex.ToString());
                }
                finally
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }
            }
        }
        public static void Run2()
        {
            // Lay du lieu tu bang table sinh vien 

            // Lay email va gui
            using (SqlConnection objConnection = GetConnection())
            {
                if (objConnection == null)
                    WriteLog("Can not connect to database!!!");
                try
                {
                    //Execute select command
                    string strSql = string.Format("[dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien_getByStatus]");
                    string strSqlUpdateNuceLog = string.Format("[dbo].[dnn_Nuce_KS_SinhVienRaTruong_SinhVien_update_status]");
                    //WriteLogNotFile(strSql);
                    DataSet objDS = new DataSet();
                    string strEmail = "";
                    string MaSV = "";
                    objDS = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, 1);
                    if (objDS != null || objDS.Tables.Count > 0)
                    {
                        for (int i = 0; i < objDS.Tables[0].Rows.Count; i++)
                        {
                            strEmail = objDS.Tables[0].Rows[i]["email"].ToString().Trim();
                            MaSV = objDS.Tables[0].Rows[i]["masv"].ToString().Trim();
                            if (IsValidEmail(strEmail))
                            {
                                Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, strSqlUpdateNuceLog, MaSV, 2);
                                System.Threading.Thread.Sleep(1000);
                                Console.Write(string.Format("{0}: {1} \n",i,strEmail));
                            }
                        }
                    }
                    else
                    {
                        WriteLog("Không lấy được dữ liệu");
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(ex.ToString());
                }
                finally
                {
                    objConnection.Close();
                    objConnection.Dispose();
                }

            }
        }

    }
}
