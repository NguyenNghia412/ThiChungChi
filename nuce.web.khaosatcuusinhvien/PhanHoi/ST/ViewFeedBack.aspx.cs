using System;
using System.Data;
namespace nuce.web.phanhoi.st
{
    public partial class ViewFeedBack : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = "";
                if (Request.QueryString["action"] == null)
                    Response.Redirect(string.Format("/phanhoi/st/default.aspx"));
                else
                    action = Request.QueryString["action"];
                if (!action.Equals("1"))
                    Response.Redirect(string.Format("/phanhoi/st/default.aspx"));
                else
                {
                    int iID = int.Parse(Request.QueryString["qa"]);
                    txtID.Text = iID.ToString();
                    //Lay du lieu cua cau hoi
                    DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_QuestionByID(iID);
                    int iStatus = int.Parse(dt.Rows[0]["Status"].ToString());
                    int isStudent = int.Parse(dt.Rows[0]["IsStudent"].ToString());
                    //if (iStatus.Equals(4) && isStudent.Equals(1))
                    //{
                        data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsStudent(iID, 2);
                    //}
                    DataTable dtCNameLecturer = data.Nuce_DanhGiaGiangVien.getCNameLecturerByStudentCode(m_SinhVien.MaSV);
                    if (dtCNameLecturer.Rows.Count > 0)
                    {
                        ddlGiangVien.DataTextField = "Name";
                        ddlGiangVien.DataValueField = "ID";
                        ddlGiangVien.DataSource = dtCNameLecturer;
                        ddlGiangVien.DataBind();
                    }
                    else
                    {
                        spThongBao.InnerText = "Không có thông tin giảng viên";
                    }
                    int iLecturerClassRoomID = int.Parse(dt.Rows[0]["LecturerClassRoomID"].ToString());
                    bindType(iLecturerClassRoomID);
                    ddlGiangVien.SelectedValue = iLecturerClassRoomID.ToString();
                    ddlType.SelectedValue = dt.Rows[0]["Type"].ToString();
                    txtQuestion.Text = dt.Rows[0]["Question"].ToString();
                    string strFile = dt.Rows[0].IsNull("Attachment") ? "" : dt.Rows[0]["Attachment"].ToString();
                    if (!strFile.Equals(""))
                        spFileDinhKem.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFile);
                    else
                        spFileDinhKem.InnerHtml = "Không có";
                    if (dt.Rows[0]["Status"].ToString().Equals("4"))
                    {
                        txtAnswer.Text = dt.Rows[0]["Answare"].ToString();
                        string strFileLec = dt.Rows[0].IsNull("Le_Attachment") ? "" : dt.Rows[0]["Le_Attachment"].ToString();
                        if (!strFileLec.Equals(""))
                            spFileDinhKemLec.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFileLec);
                        else
                            spFileDinhKemLec.InnerHtml = "Không có";
                    }
                }
            }
        }
        private void bindType(int Lecturer_ClassRoom)
        {
            DataTable dtType = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_TypeByLecturClass(Lecturer_ClassRoom);
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "ID";
            ddlType.DataSource = dtType;
            ddlType.DataBind();
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
            else
            {
                m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_qa];
                spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_SinhVien.Ten);
                mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            }
            base.OnInit(e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int iLecturerClassRoomID = int.Parse(ddlGiangVien.SelectedValue);
            int iType = int.Parse(ddlType.SelectedValue);
            Response.Redirect(string.Format("/phanhoi/st/default.aspx?id={0}&&type={1}", iLecturerClassRoomID, iType));
        }
    }
}