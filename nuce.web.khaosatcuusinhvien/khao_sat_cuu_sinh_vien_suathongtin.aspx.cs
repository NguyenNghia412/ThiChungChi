using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web
{
    public partial class khao_sat_cuu_sinh_vien_suathongtin : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                spMaSV.InnerHtml = m_SinhVien.MaSV;
                spTenSinhVien.InnerHtml = m_SinhVien.Ten;
                txtEmail.Text = m_SinhVien.Email;
                txtMobile.Text = m_SinhVien.Mobile;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_cuusinhvien] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/login_cuu_sinh_vien.aspx"));
            }
            m_SinhVien = (model.SinhVien)Session[Utils.session_cuusinhvien];
            spLogin.InnerHtml = string.Format("<a href='/login_cuu_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_SinhVien.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/Khao_sat_cuu_sinh_vien.aspx'>Lựa chọn</ option >
                              <option value='/Khao_sat_cuu_sinh_vien.aspx'>Home</option>
                              <option value='/khao_sat_cuu_sinh_vien_suathongtin.aspx'>Sửa thông tin</option>
                              <option value='/login_cuu_sinh_vien.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            if (Session[Utils.session_kithi_lophoc_cuusinhvien] != null)
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lophoc_cuusinhvien];
            base.OnInit(e);
        }


        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            m_SinhVien.Mobile = txtMobile.Text.Trim();
            m_SinhVien.Email = txtEmail.Text.Trim();
            Session[Utils.session_cuusinhvien] = m_SinhVien;
            if (data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.update(m_SinhVien.MaSV,
 m_SinhVien.Email,
 "",
 "",
m_SinhVien.Mobile,
 "",
 m_SinhVien.CMT, "cap nhat tu sinh vien", ""

 ) > 0)
                spThongBao.InnerHtml = "Cập nhật dữ liệu thành công !";
            else
                spThongBao.InnerHtml = "Cập nhật dữ liệu không thành công !";

        }
    }
}