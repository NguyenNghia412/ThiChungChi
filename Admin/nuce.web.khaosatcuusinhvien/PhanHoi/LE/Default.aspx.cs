using System;
using System.Data;

namespace nuce.web.phanhoi.le
{
    public partial class Default : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                infoLe.InnerText = string.Format("{0} - {1} - {2}", m_CanBo.Ten, m_CanBo.MaCB, m_CanBo.BoMon);
                if (Request.QueryString["action"] != null && Request.QueryString["qa"] != null)
                {
                    string strAction = Request.QueryString["action"];
                    int iID = int.Parse(Request.QueryString["qa"]);
                    int iType = -1;
                    int.TryParse(Request.QueryString["type"], out iType);
                    int iLecClassID = -1;
                    int.TryParse(Request.QueryString["id"], out iLecClassID);
                    string strJs = "<script type=\"text/javascript\">";
                    switch (strAction)
                    {
                        case "1":
                            //Gui
                            data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, 4);
                            data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsStudent(iID, 1);
                            strJs += "alert('Gửi phản hồi cho sinh viên thành công');location.href='/phanhoi/le/default.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        case "2":
                            //Xoa
                            //strJs += "alert('Xoá câu hỏi thành công');location.href='/phanhoi/le/default.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        default:
                            break;
                    }
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;

                }
                else
                {
                    DataSet ds = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_QuestionByLecturer(m_CanBo.ID);

                    DataTable dtType = ds.Tables[1];
                    DataTable dtSubject = ds.Tables[2];
                    string strHtml = "";

                    int iLecturerClassRoomID = -1;
                    int iType = -1;
                    if (Request.QueryString["id"] != null)
                        int.TryParse(Request.QueryString["id"], out iLecturerClassRoomID);
                    if (Request.QueryString["type"] != null)
                        int.TryParse(Request.QueryString["type"], out iType);
                    string strcollapse = "class='panel-collapse collapse'";
                    string strcollapseIn = "class='panel-collapse in' style='height: auto;'";
                    for (int i = 0; i < dtSubject.Rows.Count; i++)
                    {
                        int LecturerClassRoomID = int.Parse(dtSubject.Rows[i]["LecturerClassRoomID"].ToString());
                        int iTemplate = int.Parse(dtSubject.Rows[i]["Template"].ToString());
                        strHtml += string.Format(@"<div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h4 class='panel-title'>
                                            <a data-toggle='collapse' data-parent='#accordion' href='#collapse_1_{0}'>{1} <span style='color:red;'>({2} phản hồi)</span></a>
                                        </h4>
                                    </div>
                                    <div id = 'collapse_1_{0}' {3}>
                                           <div class='panel-body'>", LecturerClassRoomID.ToString(), "(" + (i + 1).ToString() + ") " + dtSubject.Rows[i]["Name"].ToString() + " - " + dtSubject.Rows[i]["GroupCode"].ToString(), "count_l1", LecturerClassRoomID.Equals(iLecturerClassRoomID) ? strcollapseIn : strcollapse);
                        //strHtml += getHtml(ds.Tables[0], int.Parse(dtType.Rows[i]["ID"].ToString()));
                        int iCountL1 = 0;
                        int iCountType = 0;
                        for (int j = 0; j < dtType.Rows.Count; j++)
                        {
                            if (dtType.Rows[j]["Template"].ToString().Equals(iTemplate.ToString()))
                            {
                                int iCountL2Temp = 0;
                                iCountType++;
                                int Type = int.Parse(dtType.Rows[j]["ID"].ToString());
                                strHtml += string.Format(@"<div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h4 class='panel-title'>
                                            <a data-toggle='collapse' data-parent='#collapse_1_{3}' href='#collapse_2_{3}_{0}'>{1} <span style='color:red;'>({2} phản hồi)</span></a>
                                        </h4>
                                    </div>
                                    <div id = 'collapse_2_{3}_{0}' {4}>
                                        <div class='panel-body'>", Type, dtType.Rows[j]["Name"].ToString(), "count_l2", LecturerClassRoomID, Type.Equals(iType) ? strcollapseIn : strcollapse);
                                strHtml += getHtml(ds.Tables[0], LecturerClassRoomID, Type, out iCountL2Temp);
                                iCountL1 = iCountL1 + iCountL2Temp;
                                strHtml += @"
                                        </div>
                                    </div>
                                </div>";
                                strHtml = strHtml.Replace("count_l2", iCountL2Temp.ToString());
                            }
                        }
                        strHtml += @"
                                        </div>
                                    </div>
                                </div>";
                        strHtml = strHtml.Replace("count_l1", iCountL1.ToString());
                    }
                    accordion.InnerHtml = strHtml;
                }
            }
        }
        private string getHtml(DataTable dt, int LecturerClassRoomID, int Type, out int count)
        {
            string strHTMl = @"<div class='table-responsive'>
                                  <table class='table table-hover' style='width:100%;'>
                                    <thead>
                                        <tr style = 'vertical-align: top; text-align: center;'>
                                            <th style='text-align: center; width: 55%;'>Phản hồi của sinh viên</th>
                                            <th style = 'text-align: center;'>Hồi đáp của giảng viên</th>
                                            <th style= 'text-align: center;'>Thao tác</th>
                                         </tr>
                                     </thead>
                                    <tbody>";


            DateTime dtNgayHoi;
            DateTime dtNgayCapNhat;
            string strSinhVien;
            string strMonHoc;
            string strQuestion;
            string strAnsware;
            int iType = -1;
            int iLecturerClassRoomID = -1;
            string strType = "";
            int iStatus;
            string strStatus = "";
            int isStudent = -1;
            int isLecturer = -1;
            string strAction = "";
            string GroupCode = "";
            int iQAID = -1;
            int iCount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                iType = int.Parse(dt.Rows[i]["Type"].ToString());
                iLecturerClassRoomID = int.Parse(dt.Rows[i]["LecturerClassRoomID"].ToString());
                if (iType.Equals(Type) && iLecturerClassRoomID.Equals(LecturerClassRoomID))
                {
                    iCount++;
                    strAction = "";
                    iStatus = int.Parse(dt.Rows[i]["Status"].ToString());
                    isStudent = int.Parse(dt.Rows[i]["IsStudent"].ToString());
                    isLecturer = int.Parse(dt.Rows[i]["IsLecturer"].ToString());
                    if (isLecturer < 2)
                        strHTMl += "<tr style=\'color:black;vertical-align: top;text-align: left;font-weight:bold;'>";
                    else
                        strHTMl += "<tr style=\'vertical-align: top;text-align: left;'>";
                    iQAID = int.Parse(dt.Rows[i]["ID"].ToString());
                    dtNgayHoi = DateTime.Parse(dt.Rows[i]["CreatedTime"].ToString());
                    dtNgayCapNhat = DateTime.Parse(dt.Rows[i]["UpdatedTime"].ToString());
                    switch (iStatus)
                    {
                        case 2:
                        case 5:
                            strStatus = "Chưa trả lời";
                            strAction = string.Format("<a href='/phanhoi/le/EditFeedBack.aspx?action=1&&qa={0}'>Xem chi tiết</a>", iQAID);
                            break;
                        case 3:
                            strStatus = "Đang trả lời";
                            strAction = string.Format("<a href='/phanhoi/le/EditFeedBack.aspx?action=1&&qa={0}'>Sửa</a> - <a href='/phanhoi/le/Default.aspx?action=1&&qa={0}&&id={1}&&type={2}'>Gửi</a>", iQAID, LecturerClassRoomID, Type);
                            break;
                        case 4:
                            strStatus = "Đã trả lời";
                            strAction = string.Format("<a href='/phanhoi/le/ViewFeedBack.aspx?action=1&&qa={0}'>Xem chi tiết</a> - <a href='/phanhoi/le/EditFeedBack.aspx?action=1&&qa={0}'>Sửa</a>", iQAID);
                            break;
                        default: strStatus = ""; break;
                    }
                    strSinhVien = dt.Rows[i]["FulName"].ToString();
                    strMonHoc = dt.Rows[i]["Name"].ToString();
                    strQuestion = dt.Rows[i]["Question"].ToString();
                    strAnsware = dt.Rows[i]["Answare"].ToString();

                    GroupCode = dt.Rows[i]["GroupCode"].ToString();
                    strSinhVien = string.Format("{0} - {1}", strMonHoc, GroupCode);
                    strHTMl += string.Format("<td>{0}<p style='color:blue;'>({2})</p></td>", strQuestion.Length > 100 ? strQuestion.Substring(0, 100) : strQuestion, strSinhVien, dtNgayHoi.ToString("dd/MM/yyyy"));


                    if (iStatus < 3)
                        strHTMl += "<td></td>";
                    else
                        strHTMl += string.Format("<td style='text-align: left;'>{0}<p style='color:blue;'>({1})</p></td>", strAnsware.Length > 100 ? strAnsware.Substring(0, 100) : strAnsware, dtNgayCapNhat.ToString("dd/MM/yyyy"));
                    //strHTMl += string.Format("<td>{0}</td>", strStatus);
                    strHTMl += string.Format("<td>{0}</td>", strAction);
                    strHTMl += "</tr>";
                }
            }
            strHTMl += @"</tbody> </table></div> ";
            count = iCount;
            return strHTMl;
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_giangvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            m_CanBo = (model.CanBo)Session[Utils.session_giangvien_qa];
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/le/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_CanBo.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/le/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/le/default.aspx'>Home</option>
                              <option value='/phanhoi/le/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}