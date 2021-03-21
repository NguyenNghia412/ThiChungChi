using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace nuce.web.khaosatcuusinhvien
{
    public partial class danhSach_BaiKhaoSat_SinhVien : Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hiển thị danh sách sinh viên
            string strContentHtml = "";
            for (int i=0;i<m_KiThiLopHocSinhViens.Count;i++)
            {
                model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien= m_KiThiLopHocSinhViens[m_KiThiLopHocSinhViens.ElementAt(i).Key];
                string strTrangThai = "";
                string strLink = "";
                string strFile = "Khao_sat_sinh_vien";
                if (m_KiThiLopHocSinhVien.DeThiID.Equals(4))
                    strFile = "Khao_sat_sinh_vien_m4";
                switch (m_KiThiLopHocSinhVien.Status)
                {
                    case 1:
                        strTrangThai = "Chưa thực hiện";
                        strLink = string.Format("<a href='/KSHDGD/{0}.aspx?id={1}'>Tham gia<a>", strFile, m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien);
                        break;
                    case 2:
                        strTrangThai = "Đang thực hiện";
                        strLink = string.Format("<a href='/KSHDGD/{0}.aspx?id={1}'>Tiếp tục<a>", strFile,m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        strTrangThai = "Đã thực hiện";
                        strLink = "";
                        break;
                    default:
                        strTrangThai = "";
                        strLink = "";
                        break;
                }
                strContentHtml += "<tr>";
                strContentHtml += string.Format("<td>{0}</td>", m_KiThiLopHocSinhVien.TenMonHoc);
                strContentHtml += string.Format("<td>{0}</td>", m_KiThiLopHocSinhVien.LecturerName);
                strContentHtml += string.Format("<td>{0}</td>", strTrangThai);
                strContentHtml += string.Format("<td>{0}</td>", strLink);
                strContentHtml += "</tr>";
            }
            tbContent.InnerHtml = strContentHtml;
        }
        protected override void OnInit(EventArgs e)
        {
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_sinhvien_khaosatdanhgiagiangvien] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/KSHDGD/login_sinh_vien.aspx"));
            }
            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_khaosatdanhgiagiangvien];
            //spLogin.InnerHtml = string.Format("<a href='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Đăng xuất</a>");
            spLogin.InnerHtml = string.Format("<a href='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - {1} ({2}) - Đăng xuất</a>", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx'>Lựa chọn</ option >
                              <option value='/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx'>Home</option>
                              <option value='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            if (Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien] != null)
            {
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien];
            }
            base.OnInit(e);
        }
    }
}