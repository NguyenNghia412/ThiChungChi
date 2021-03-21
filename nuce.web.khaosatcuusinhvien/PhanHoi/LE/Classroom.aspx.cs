using System;
using System.Data;

namespace nuce.web.phanhoi.le
{
    public partial class Classroom : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Lay sinh vien trong lop hoc
                DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getC_ClassRoomByLecturer(m_CanBo.ID);
                ddlClassRoom.DataTextField = "ClassRoomName";
                ddlClassRoom.DataValueField = "ID";
                ddlClassRoom.DataSource = dt;
                ddlClassRoom.DataBind();
                if(Request.QueryString["classroom"]!=null)
                    ddlClassRoom.SelectedValue = Request.QueryString["classroom"];
                string strClassRoomID = ddlClassRoom.SelectedValue;
                //Lay sinh vien trong lop hoc
            }
        }
        private void bindata(DataTable dt)
        {
            string strHTMl = "";
            DateTime dtNgayHoi;
            DateTime dtNgayCapNhat;
            string strSinhVien;
            string strMonHoc;
            string strQuestion;
            string strAnsware;
            int iType;
            string strType = "";
            int iStatus;
            string strStatus = "";
            string strAction = "";
            string GroupCode = "";
            int iQAID = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strAction = "";
                iStatus = int.Parse(dt.Rows[i]["Status"].ToString());
                if (iStatus < 4)
                    strHTMl += "<tr style=\'color:red;vertical-align: top;text-align: center;'>";
                else
                    strHTMl += "<tr style=\'vertical-align: top;text-align: center;'>";
                iQAID = int.Parse(dt.Rows[i]["ID"].ToString());
                dtNgayHoi = DateTime.Parse(dt.Rows[i]["CreatedTime"].ToString());
                dtNgayCapNhat = DateTime.Parse(dt.Rows[i]["UpdatedTime"].ToString());

                switch (iStatus)
                {
                    case 2:
                        strStatus = "Chưa trả lời";
                        strAction = string.Format("<a href='/phanhoi/le/EditQuestion.aspx?action=1&&qa={0}'>Trả lời</a>", iQAID);
                        break;
                    case 3:
                        strStatus = "Đang trả lời";
                        strAction = string.Format("<a href='/phanhoi/le/EditQuestion.aspx?action=1&&qa={0}'>Sửa</a> - <a href='/phanhoi/le/Default.aspx?action=1&&qa={0}'>Gửi sinh viên</a>", iQAID);
                        break;
                    case 4:
                        strStatus = "Đã trả lời";
                        strAction = string.Format("<a href='/phanhoi/le/ViewQuestion.aspx?action=1&&qa={0}'>Xem chi tiết</a> - <a href='/phanhoi/le/EditQuestion.aspx?action=1&&qa={0}'>Sửa</a>", iQAID);
                        break;
                    default: strStatus = ""; break;
                }
                strSinhVien = dt.Rows[i]["FulName"].ToString();
                strMonHoc = dt.Rows[i]["Name"].ToString();
                strQuestion = dt.Rows[i]["Question"].ToString();
                strAnsware = dt.Rows[i]["Answare"].ToString();

                GroupCode = dt.Rows[i]["GroupCode"].ToString();
                strSinhVien = string.Format("{0} -{1}({2})", strSinhVien, strMonHoc, GroupCode);
                strHTMl += string.Format("<td>{0} </br><p style='color:blue;'>{1} ({2} - {3})</p></td>", strQuestion.Length > 100 ? strQuestion.Substring(0, 100) : strQuestion, strSinhVien, strType, dtNgayHoi.ToString("dd/MM/yyyy"));


                if (iStatus < 3)
                    strHTMl += "<td></td>";
                else
                    strHTMl += string.Format("<td>{0}</br><p style='color:blue;'>({1})</p></td>", strAnsware.Length > 100 ? strAnsware.Substring(0, 100) : strAnsware, dtNgayCapNhat.ToString("dd/MM/yyyy"));
                strHTMl += string.Format("<td>{0}</td>", strStatus);

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