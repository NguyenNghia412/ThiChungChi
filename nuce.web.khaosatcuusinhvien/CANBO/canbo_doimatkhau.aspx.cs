using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web
{
    public partial class canbo_doimatkhau : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                              <option value='/canbo/canbo.aspx'>Lựa chọn</ option >
                              <option value='/canbo/canbo.aspx'>Home</option>
                              <option value='/login_can_bo.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strMatKhauCu = txtMatKhauCu.Text.Trim();
            string strMatKhauMoi = txtMatKhauMoi.Text.Trim();
            string strXacNhanMatKhauMoi = txtMatKhauNhapLai.Text.Trim();

            if (strMatKhauCu.Length == 0 || strMatKhauMoi.Length == 0 || strXacNhanMatKhauMoi.Length == 0)
            {
                spThongBao.InnerText = "Không được để trắng mật khẩu";
                return;
            }
            if (!strMatKhauMoi.Equals(strXacNhanMatKhauMoi))
            {
                spThongBao.InnerText = "Xác nhận mật khẩu không hợp hệ";
                return;
            }
            if (strMatKhauCu.Equals(strXacNhanMatKhauMoi))
            {
                spThongBao.InnerText = "Mật khẩu cũ và mật khẩu mới trùng nhau";
                return;
            }
            if (strMatKhauMoi.Length < 6)
            {
                spThongBao.InnerText = "Mật khẩu mới phải lớn hơn 5 ký tự";
                return;
            }
            if (data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.DoiMatKhau(m_CanBo.MaCB, strMatKhauCu, strMatKhauMoi) > 0)
            {
                spThongBao.InnerText = "Đổi mật khẩu thành công !";
                return;
            }
            else
            {
                spThongBao.InnerText = "Mậu khẩu cũ không đúng.";
                return;
            }
        }
    }
}