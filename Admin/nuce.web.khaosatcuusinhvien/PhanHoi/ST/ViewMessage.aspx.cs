using System;
using System.Data;

namespace nuce.web.phanhoi.st
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    txtMessage.Text = dt.Rows[0]["Message"].ToString();
                    divViewMessage.InnerHtml= dt.Rows[0]["Message"].ToString(); 
                    string strFile = dt.Rows[0].IsNull("Attachment") ? "" : dt.Rows[0]["Attachment"].ToString();
                    if (!strFile.Equals(""))
                        spFileDinhKemLec.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFile);
                    else
                        spFileDinhKemLec.InnerHtml = "Không có";
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
            if (Session[Utils.session_sinhvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}

            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_qa];
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>",m_SinhVien.Ten);
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
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/phanhoi/St/Message.aspx"));
        }
    }
}