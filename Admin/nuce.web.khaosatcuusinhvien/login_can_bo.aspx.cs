using System;
using System.Collections.Generic;
using System.Data;

namespace nuce.web
{
    public partial class login_can_bo : System.Web.UI.Page
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
            if (Request.QueryString["ctl"] != null)
            {
                if (Request.QueryString["ctl"].ToString().Equals("dangxuat"))
                {
                    dangxuat();
                    Response.Redirect(string.Format("/login_can_bo.aspx"));
                }
            }
            if (Session[Utils.session_canbo] != null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/canbo.aspx"));
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
            DataTable dtData = data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.checkLogin(strTen, strMatKhau);
            if (dtData.Rows.Count > 0)
            {
                model.CanBo canBo = new model.CanBo();
                canBo.ID = int.Parse(dtData.Rows[0]["ID"].ToString());
                canBo.MaCB = dtData.Rows[0]["macb"].ToString();
                canBo.Ten= dtData.Rows[0]["hoten"].ToString();
                canBo.Khoa = dtData.Rows[0]["makhoa"].ToString();
                canBo.Type = int.Parse(dtData.Rows[0]["type"].ToString());

                Session[Utils.session_canbo] = canBo;
                spThongBao.InnerHtml = "Đăng nhập thành công";
                Response.Redirect(string.Format("/canbo/default.aspx"));
            }
            else
                spThongBao.InnerHtml = "Đăng nhập thất bại";
        }
    }
}