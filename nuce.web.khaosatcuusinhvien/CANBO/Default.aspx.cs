using System;
using System.Data;

namespace nuce.web.canbo
{
    public partial class Default : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
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
            if (Session[Utils.session_canbo] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/login_can_bo.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}

            m_CanBo = (model.CanBo)Session[Utils.session_canbo];
            spLogin.InnerHtml = string.Format("<a href='/login_can_bo.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} Đăng xuất</a>", m_CanBo.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/canbo/default.aspx'>Lựa chọn</ option >
                              <option value='/canbo/default.aspx'>Home</option>
                              <option value='/login_can_bo.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}