using System;
using System.Data;

namespace nuce.web.admin
{
    public partial class login : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Request.QueryString["ctl"] != null)
            {
                if (Request.QueryString["ctl"].ToString().Equals("dangxuat"))
                {
                    dangxuat();
                    Response.Redirect(string.Format("/admin/login.aspx"));
                }
            }
            if (Session[Utils.session_admin_user] != null)
            {
                Response.Redirect(string.Format("/admin/default.aspx"));
            }
            base.OnInit(e);
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string strTen = txtMaDangNhap.Text.Trim();
            string strMatKhau = txtMatKhau.Text.Trim();
            if (strTen.Equals(""))
            {
                spThongBao.InnerHtml = "Không được để tên trắng";
                return;
            }
            if (strMatKhau.Equals(""))
            {
                spThongBao.InnerHtml = "Không được mật khẩu trắng";
                return;
            }
            DataTable dtData = data.Nuce_Survey.Authenticate(strTen,strMatKhau);

            if (dtData!=null&&dtData.Rows.Count > 0)
            {
                model.User user = new model.User();
                user.ID = int.Parse(dtData.Rows[0]["ID"].ToString());
                user.FirstName = dtData.Rows[0]["FirstName"].ToString();
                user.LastName = dtData.Rows[0]["LastName"].ToString();
                user.DisplayName = dtData.Rows[0]["DisplayName"].ToString();
                user.Email = dtData.Rows[0]["Email"].ToString();

                Session[Utils.session_admin_user] = user;
                spThongBao.InnerHtml = "Đăng nhập thành công";
                Response.Redirect(string.Format("/admin/default.aspx"));
            }
            else
                spThongBao.InnerHtml = "Đăng nhập thất bại";
        }
    }
}