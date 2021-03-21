using System;
using System.Data;

namespace nuce.web.phanhoi.st
{
    public partial class Default : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                infoSt.InnerText = string.Format("{0} {1} - MSSV: {2}", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
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
                            nuce.web.data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_SinhVien.SinhVienID, 2);
                            nuce.web.data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsLecturer(iID, 1);
                            strJs += "alert('Gửi phản hồi cho giảng viên thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        case "2":
                            //Xoa
                            nuce.web.data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_SinhVien.SinhVienID, 999);
                            strJs += "alert('Xoá phản hồi thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        default:
                            break;
                    }
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;

                }
                else
                {
                    DataSet ds = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_QuestionByStudent(m_SinhVien.SinhVienID);

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
                                           <div class='panel-body'>", LecturerClassRoomID.ToString(), "(" + (i + 1).ToString() + ") " + dtSubject.Rows[i]["Name"].ToString() + " - " + dtSubject.Rows[i]["GroupCode"].ToString() + " -  Giảng viên: " + dtSubject.Rows[i]["FullName"].ToString(), "count_l1", LecturerClassRoomID.Equals(iLecturerClassRoomID) ? strcollapseIn : strcollapse);
                        //strHtml += getHtml(ds.Tables[0], int.Parse(dtType.Rows[i]["ID"].ToString()));
                        int iCountL1 = 0;
                        int iCountType = 0;
                        for (int j = 0; j < dtType.Rows.Count; j++)
                        {
                            if (dtType.Rows[j]["Template"].ToString().Equals(iTemplate.ToString()))
                            {
                                iCountType++;
                                int iCountL2Temp = 0;
                                int Type = int.Parse(dtType.Rows[j]["ID"].ToString());
                                strHtml += string.Format(@"<div class='panel panel-default'>
                                    <div class='panel-heading'>
                                        <h4 class='panel-title'>
                                            <a data-toggle='collapse' data-parent='#collapse_1_{3}' href='#collapse_2_{3}_{0}'>{1} <span style='color:red;'>({2} phản hồi)</span></a>
                                        </h4>
                                    </div>
                                    <div id = 'collapse_2_{3}_{0}' {4}>
                                        <div class='panel-body'>", Type, "(" + iCountType.ToString() + ") " + dtType.Rows[j]["Name"].ToString(), "count_l2", LecturerClassRoomID, Type.Equals(iType) ? strcollapseIn : strcollapse);
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
            //< th style = 'text-align: left;vertical-align: top; width: 20%;' >< a href = '/phanhoi/st/AddFeedBack.aspx' > Tạo mới phản hồi </ a ></ th >

                     string strHTMl = @"<div class='table-responsive'>
                                  <table class='table table-hover' style='width:100%;'>
                                    <thead>
                                        <tr style = 'vertical-align: top; text-align: center;'>
                                            <th style='text-align: left;vertical-align: top; width: 1%;'></th>
                                            <th style='text-align: center;vertical-align: top; width: 35%;'>Phản hồi của sinh viên</th>
                                            <th style='text-align: center;vertical-align: top; width: 45%;'>Hồi đáp của giảng viên</th>
                                            <th style= 'text-align: center;'>Thao tác</th>
                                         </tr>
                                     </thead>
                                    <tbody>";
            DateTime dtNgayHoi;
            DateTime dtNgayCapNhat;
            string strGiangVien;
            string strMonHoc;
            string strQuestion;
            string strAnsware;
            int iType;
            int iLecturerClassRoomID;
            string strType = "";
            int iStatus;
            string strStatus = "";
            int isStudent = -1;
            int isLecturer = -1;
            string strAction = "";
            int iQAID = -1;
            string GroupCode = "";
            int iCount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                iType = int.Parse(dt.Rows[i]["Type"].ToString());
                isStudent = int.Parse(dt.Rows[i]["IsStudent"].ToString());
                isLecturer = int.Parse(dt.Rows[i]["IsLecturer"].ToString());
                iLecturerClassRoomID = int.Parse(dt.Rows[i]["LecturerClassRoomID"].ToString());
                if (iType.Equals(Type) && iLecturerClassRoomID.Equals(LecturerClassRoomID))
                {
                    iCount++;
                    strAction = "";
                    iStatus = int.Parse(dt.Rows[i]["Status"].ToString());
                    isStudent = int.Parse(dt.Rows[i]["IsStudent"].ToString());
                    isLecturer = int.Parse(dt.Rows[i]["IsLecturer"].ToString());
                    if (iStatus.Equals(4) && isStudent.Equals(1))
                    {
                        strHTMl += "<tr style=\'vertical-align: top;text-align: center; color:black;font-weight:bold;'>";
                    }
                    else
                        strHTMl += "<tr style=\'vertical-align: top;text-align: center;'>";
                    iQAID = int.Parse(dt.Rows[i]["ID"].ToString());
                    dtNgayHoi = DateTime.Parse(dt.Rows[i]["CreatedTime"].ToString());
                    dtNgayCapNhat = DateTime.Parse(dt.Rows[i]["UpdatedTime"].ToString());
                    iStatus = int.Parse(dt.Rows[i]["Status"].ToString());
                    switch (iStatus)
                    {
                        //1 Dang soan
                        //2 Da gui
                        //3 Dang tra loi
                        //4 Da tra loi
                        //5 da doc
                        case 1:
                            strStatus = "Đang soạn";
                            strAction = string.Format("<a href='/phanhoi/st/EditFeedBack.aspx?action=1&&qa={0}'>Sửa</a> - <a href='/phanhoi/st/Default.aspx?action=2&&qa={0}&&id={1}&&type={2}'>Xoá</a> - <a href='/phanhoi/st/Default.aspx?action=1&&qa={0}&&id={1}&&type={2}'>Gửi</a>", iQAID, iLecturerClassRoomID, iType);
                            break;
                        case 2:
                        case 3:
                        case 5:
                            //strStatus = "Đã gửi";
                            if (isLecturer.Equals(2))
                                strStatus = "Giảng viên đã xem";
                            else
                                strStatus = "";
                            strAction = string.Format("<a href='/phanhoi/st/ViewFeedBack.aspx?action=1&&qa={0}'>Xem chi tiết</a>", iQAID);
                            break;
                        case 4:
                            //strStatus = "Trả lời";
                            if (isLecturer.Equals(2))
                                strStatus = "Giảng viên đã xem";
                            else
                                strStatus = "";
                            strAction = string.Format("<a href='/phanhoi/st/ViewFeedBack.aspx?action=1&&qa={0}'>Xem chi tiết</a>", iQAID);
                            break;
                        default: strStatus = ""; break;
                    }
                    strGiangVien = dt.Rows[i]["FullName"].ToString();
                    strMonHoc = dt.Rows[i]["Name"].ToString();
                    strQuestion = dt.Rows[i]["Question"].ToString();
                    strAnsware = dt.Rows[i]["Answare"].ToString();
                    GroupCode = dt.Rows[i]["GroupCode"].ToString();
                    //strHTMl += string.Format("<td>{0}</br>({1}){2}</td>", strGiangVien, GroupCode, strMonHoc);
                    strHTMl += string.Format("<td colspan='2' style='text-align: left;'>{0} ({1} <span style='color:blue'>{2}</span>)</td>", strQuestion.Length > 100 ? strQuestion.Substring(0, 100) : strQuestion, dtNgayHoi.ToString("dd/MM/yyyy"), strStatus);
                    //strHTMl += string.Format("<td>{0}</td>", strStatus);
                    if (!iStatus.Equals(4))
                        strHTMl += "<td></td>";
                    else
                        strHTMl += string.Format("<td style='text-align: left;'>{0}({1})</td>", strAnsware.Length > 100 ? strAnsware.Substring(0, 100) : strAnsware, dtNgayCapNhat.ToString("dd/MM/yyyy"));

                    strHTMl += string.Format("<td>{0}</td>", strAction);
                    strHTMl += "</tr>";
                }
            }
            strHTMl += @"</tbody> </table></div> ";
            count = iCount;
            return strHTMl;
        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_sinhvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}

            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_qa];
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_SinhVien.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/AddFeedBack.aspx'>Tạo mới phản hồi</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}