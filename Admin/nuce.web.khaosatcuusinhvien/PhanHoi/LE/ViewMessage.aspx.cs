using System;
using System.Data;
namespace nuce.web.phanhoi.le
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = "";
                if (Request.QueryString["action"] == null)
                    Response.Redirect(string.Format("/phanhoi/le/Message.aspx"));
                else
                    action = Request.QueryString["action"];
                if (!action.Equals("1"))
                    Response.Redirect(string.Format("/phanhoi/le/Message.aspx"));
                else
                {
                    DataTable dtClassRoomName = nuce.web.data.Nuce_DanhGiaGiangVien.getC_ClassRoomByLecturer(m_CanBo.ID);
                    if (dtClassRoomName.Rows.Count > 0)
                    {

                        ddlClassRoom.DataTextField = "ClassRoomName";
                        ddlClassRoom.DataValueField = "ID";
                        ddlClassRoom.DataSource = dtClassRoomName;
                        ddlClassRoom.DataBind();
                    }
                    else
                    {
                        spThongBao.InnerText = "Không có thông tin Lớp môn học";
                    }



                    int iID = int.Parse(Request.QueryString["qa"]);
                    DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_MessageDetailByID(iID);
                    int iStatus = int.Parse(dt.Rows[0]["Status"].ToString());
                    int islecturer = int.Parse(dt.Rows[0]["IsLecturer"].ToString());
                    if (iStatus > 4 || iStatus < 2)
                    {
                        Response.Redirect(string.Format("/phanhoi/le/default.aspx"));
                    }
                    else
                    {
                        txtType.Text = dt.Rows[0]["Type"].ToString();
                        txtMessage.Text = dt.Rows[0]["Message"].ToString();
                        txtLecClass.Text = dt.Rows[0]["LecturerClassRoomID"].ToString();
                        ddlClassRoom.SelectedValue = dt.Rows[0]["ClassRoomID"].ToString();
                        string strFile = dt.Rows[0].IsNull("Attachment") ? "" : dt.Rows[0]["Attachment"].ToString();
                        if (!strFile.Equals(""))
                            spFileDinhKemLec.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFile);
                        else
                            spFileDinhKemLec.InnerHtml = "Không có";
                    }
                }


            }
        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_giangvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            else
            {
                m_CanBo = (model.CanBo)Session[Utils.session_giangvien_qa];
                spLogin.InnerHtml = string.Format("<a href='/phanhoi/le/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_CanBo.Ten);
                mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/le/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/le/default.aspx'>Home</option>
                              <option value='/phanhoi/le/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            }
            base.OnInit(e);
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/phanhoi/le/Message.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text));
        }
    }
}