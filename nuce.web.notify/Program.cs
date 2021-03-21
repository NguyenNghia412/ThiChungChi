using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nuce.web.notify
{
    class Program
    {
        static void Main(string[] args)
        {
            Common.WriteLog("Bat dau");
            //Lay du lieu cua giang vien can gui
            //Status>1 và islecturer=1 -> giang vien chua doc
            //
            #region Lecturer
            DataSet dsT = data.Nuce_Survey.getStatisticsSendEmailLecturer();
            DataTable dtT = dsT.Tables[0];
            for(int i=0;i< dtT.Rows.Count;i++)
            {
                int iID = int.Parse(dtT.Rows[i]["ID"].ToString());
                string Email = dtT.Rows[i]["Email"].ToString();
                string FullName = dtT.Rows[i]["FullName"].ToString();
                int iTotalQuestion = getCountQuestionLecturer(dsT.Tables[2], iID);
                int iTotalQuestionNoRead = getCountQuestionLecturer(dsT.Tables[1], iID);

                string strTieuDe = string.Format("({0}) - Thông báo: Có phản hồi mới từ sinh viên",DateTime.Now.ToString("dd/MM/yyyy"));
                string strNoiDungMail =string.Format("Kính gửi thầy/cô {0}",FullName);
                strNoiDungMail+= string.Format(@"</br>Tính đến ngày {0} quý thầy/cô đã nhận được {1} phản hồi từ sinh viên. Trong đó có {2} phản hồi chưa được xem.
Quý thầy / cô vui lòng đăng nhập vào hệ thống <a href='{3}'>{3}</a> để xem phản hồi.", DateTime.Now.ToString("dd/MM/yyyy"),iTotalQuestion,iTotalQuestionNoRead, "http://khaosat.nuce.edu.vn");
                strNoiDungMail += string.Format(@"</br>Trân trọng cảm ơn và kính chúc thầy/cô sức khoẻ !");
                //Gui mail
                //Common.Send_Email(strTieuDe, strNoiDungMail, Email);
                //CapNhat
                data.Nuce_Survey.UpdateQA_Log_Mail(iID, 1, strNoiDungMail);
                Common.WriteLog(string.Format("Giang Vien - {0} - {1} - {2} - {3}", FullName, Email, strTieuDe, strNoiDungMail));
                Thread.Sleep(10000);
            }
            #endregion
            #region Student
            DataSet dsS = data.Nuce_Survey.getStatisticsSendEmailStudent();
            DataTable dtS = dsS.Tables[0];
            for (int i = 0; i < dtS.Rows.Count; i++)
            {
                int iID = int.Parse(dtS.Rows[i]["ID"].ToString());
                string Email = dtS.Rows[i]["Email"].ToString();
                string FullName = dtS.Rows[i]["FulName"].ToString();
                string Code= dtS.Rows[i]["Code"].ToString();
                int iTotalQuestion = getCountQuestionStudent(dsS.Tables[2], iID);
                int iTotalQuestionNoRead = getCountQuestionStudent(dsS.Tables[1], iID);

                string strTieuDe = string.Format("({0}) - Thông báo: Có hồi đáp mới từ giảng viên", DateTime.Now.ToString("dd/MM/yyyy"));
                string strNoiDungMail = string.Format("Kính gửi sinh viên {0} (mã số sv: {1})", FullName,Code);
                strNoiDungMail += string.Format(@"</br>Tính đến ngày {0} bạn đã nhận được {1} hồi đáp của giảng viên. Trong đó có {2} hồi đáp chưa được xem. 
Đề nghị bạn vui lòng đăng nhập vào hệ thống <a href='{3}'>{3}</a> để xem phản hồi.", DateTime.Now.ToString("dd/MM/yyyy"), iTotalQuestion, iTotalQuestionNoRead, "http://khaosat.nuce.edu.vn");
                strNoiDungMail += string.Format(@"</br>Trân trọng cảm ơn và chúc bạn sức khoẻ !");
                //Gui mail
                //Common.Send_Email(strTieuDe, strNoiDungMail, Email);
                //CapNhat
                data.Nuce_Survey.UpdateQA_Log_Mail(iID, 2, strNoiDungMail);
                Common.WriteLog(string.Format("Sinh vien - {0} - {1} - {2} - {3}", FullName, Email, strTieuDe, strNoiDungMail));
                Thread.Sleep(10000);
            }
            #endregion
            Common.WriteLog("Ket thuc");
            Console.ReadLine();
        }
        static int getCountQuestionLecturer(DataTable dt,int ID)
        {
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(dt.Rows[i]["LecturerID"].ToString().Equals(ID.ToString()))
                {
                    return int.Parse(dt.Rows[i]["Count"].ToString());
                }
            }
            return 0;
        }
        static int getCountQuestionStudent(DataTable dt, int ID)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["StudentID"].ToString().Equals(ID.ToString()))
                {
                    return int.Parse(dt.Rows[i]["Count"].ToString());
                }
            }
            return 0;
        }
    }
}
