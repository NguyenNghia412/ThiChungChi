using System;
using System.Data;

namespace nuce.web.phanhoi.le
{
    public partial class Message : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                            data.Nuce_DanhGiaGiangVien.UpdateMessage(iID, 2);
                            strJs += "alert('Gửi thông báo cho sinh viên thành công');location.href='/phanhoi/le/Message.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        case "2":
                            //Xoa
                            data.Nuce_DanhGiaGiangVien.UpdateMessage(iID, 4);
                            strJs += "alert('Xóa thông báo thành công');location.href='/phanhoi/le/Message.aspx?id=" + iLecClassID.ToString() + "&&type=" + iType.ToString() + "';";
                            break;
                        default:
                            break;
                    }
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;

                }
                else
                {
                    //Lay sinh vien trong lop hoc
                    DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getC_ClassRoomByLecturer(m_CanBo.ID);
                    ddlClassRoom.DataTextField = "ClassRoomName";
                    ddlClassRoom.DataValueField = "ID";
                    ddlClassRoom.DataSource = dt;
                    ddlClassRoom.DataBind();
                    if (Request.QueryString["classroom"] != null)
                        ddlClassRoom.SelectedValue = Request.QueryString["classroom"];
                    string strClassRoomID = ddlClassRoom.SelectedValue;
                    //Lay sinh vien trong lop hoc
                    DataTable dtMessage = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_MessageByLecturer1(m_CanBo.ID);
                    if (dtMessage != null)
                        bindata(dtMessage);
                }
            }
        }
        private void bindata(DataTable dt)
        {
            DateTime dtNgayHoi, dtNgayCapNhat;
            string strHTMl = "";
            string strMessage;
            int iType;
            string strType = "gửi cả lớp";
            int iStatus;
            string strStatus = "";
            string strAction = "";
            string GroupCode = "";
            int iQAID = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strAction = "";
                iStatus = int.Parse(dt.Rows[i]["Status"].ToString());
                if (iStatus < 2)
                    strHTMl += "<tr style=\'color:red;vertical-align: top;text-align: center;'>";
                else
                    strHTMl += "<tr style=\'vertical-align: top;text-align: center;'>";
                iQAID = int.Parse(dt.Rows[i]["ID"].ToString());
                dtNgayHoi = DateTime.Parse(dt.Rows[i]["CreatedTime"].ToString());
                dtNgayCapNhat = DateTime.Parse(dt.Rows[i]["UpdatedTime"].ToString());

                switch (iStatus)
                {
                    case 2:
                        strStatus = "Đã gửi thông báo";
                        strAction = string.Format("<a href='/phanhoi/le/ViewMessage.aspx?action=1&&qa={0}'>Xem chi tiết</a>", iQAID);
                        break;
                    case 1:
                        strStatus = "Đang soạn thảo";
                        strAction = string.Format("<a href='/phanhoi/le/Message.aspx?action=1&&qa={0}'>Gửi sinh viên</a>", iQAID);
                        strAction += string.Format(" - <a href='/phanhoi/le/EditMessage.aspx?action=1&&qa={0}'>Sửa</a>", iQAID);
                        strAction += string.Format(" - <a href='/phanhoi/le/Message.aspx?action=2&&qa={0}'>Xóa</a>", iQAID);
                        break;
                    default: strStatus = ""; break;
                }
                strMessage = dt.Rows[i]["Message"].ToString();
                GroupCode = dt.Rows[i]["GroupCode"].ToString();
                strHTMl += string.Format("<td>{0}</td>", i + 1);
                strHTMl += string.Format("<td style='text-align: left;'>{0} <p style='color:blue;'>{1} - {2} - {3} - {4} </p></td>", strMessage.Length > 100 ? strMessage.Substring(0, 100) : strMessage, GroupCode, strType, strStatus, dtNgayHoi.ToString("dd/MM/yyyy"));

                strHTMl += string.Format("<td>{0}</td>", strAction);
                strHTMl += "</tr>";
            }
            tbContent.InnerHtml = strHTMl;
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
            m_CanBo = (model.CanBo)Session[Utils.session_giangvien_qa];
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/le/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_CanBo.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}