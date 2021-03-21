using System;
using System.Data;
namespace nuce.web.phanhoi.st
{
    public partial class EditInfo : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmail.Text = m_SinhVien.Email;
                txtMobile.Text = m_SinhVien.Mobile;
                spMaSV.InnerText = m_SinhVien.MaSV;
                spName.InnerText = m_SinhVien.Ho + " " + m_SinhVien.Ten;
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
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_SinhVien.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strEmail = txtEmail.Text.Trim();
            string strMobile = txtMobile.Text.Trim();
            //kiểm tra email
            if (Utils.IsValidEmail(strEmail))
            {
                if (Utils.IsMobile(strMobile))
                {
                    if (strMobile.Equals(m_SinhVien.Mobile) && strEmail.Equals(m_SinhVien.Email))
                    {
                        spThongBao.InnerHtml = "";
                    }
                    else
                    {
                        DataTable dt= data.Nuce_DanhGiaGiangVien.UpdateEmailStudent1(m_SinhVien.MaSV, strEmail, strMobile);
                        string strLoai = dt.Rows[0]["loai"].ToString();
                        if (strLoai.Equals("0"))
                        {
                            spThongBao.InnerHtml = "Cập nhật dữ liệu không thành công.";
                        }
                        else
                        {
                            if (strLoai.Equals("1"))
                            {
                                spThongBao.InnerHtml = "Cập nhật dữ liệu mobile thành công.";
                                m_SinhVien.Mobile = strMobile;
                                txtEmail.Text = m_SinhVien.Email;
                            }
                            else
                            if (strLoai.Equals("2"))
                            {
                                // Gửi email xác thực
                                string keyAuthorzie = dt.Rows[0]["authorize"].ToString();
                                string strTieuDe = string.Format("Xác thực hoàn thành khảo sát");
                                string strNoiDung = "<div style='color:black;'><div style='padding:5px;'>Cảm ơn Anh/Chị đã cập nhật thông tin email.</div>";
                                strNoiDung += "<div style='padding:5px;'>Vui lòng nhấn vào đường link dưới đây để xác thực email.</div>";
                                strNoiDung += string.Format("<div style='padding:5px;'><a href='http://ktdb.nuce.edu.vn/phanhoi/st/verify_email.aspx?masv={0}&&key={1}' style='cursor:pointer;'>http://khaosat.nuce.edu.vn/phanhoi/st/verify_email.aspx?masv={0}&&key={1}</a></div>", m_SinhVien.MaSV, keyAuthorzie);
                                strNoiDung += "<div style='padding:5px;'>Chúc Anh/Chị sức khỏe và thành công!</div>";
                                strNoiDung += "<div style='padding:5px;'>TRƯỜNG ĐẠI HỌC XÂY DỰNG</div></div>";
                                Utils.Send_Email(strTieuDe, strNoiDung, strEmail);
                                //spThongBao.InnerHtml = "Cập nhật dữ liệu email thành công. </br> email xác thực đã được gửi.";
                                spThongBao.InnerHtml = "Cập nhật dữ liệu thành công. </br> email xác thực đã được gửi.";
                                m_SinhVien.TrangThai = 2;
                                m_SinhVien.Email = strEmail;
                                m_SinhVien.Mobile = strMobile;
                            }
                            else
                            {
                                if (strLoai.Equals("3"))
                                {
                                    spThongBao.InnerHtml = "Địa chỉ email và mobile đã được sinh viên khác sử dụng.";
                                }
                                else
                                {
                                    if (strLoai.Equals("4"))
                                    {
                                        // Gửi email xác thực
                                        string keyAuthorzie = dt.Rows[0]["authorize"].ToString();
                                        string strTieuDe = string.Format("Xác thực hoàn thành khảo sát");
                                        string strNoiDung = "<div style='color:black;'><div style='padding:5px;'>Cảm ơn Anh/Chị đã cập nhật thông tin email.</div>";
                                        strNoiDung += "<div style='padding:5px;'>Vui lòng nhấn vào đường link dưới đây để xác thực email.</div>";
                                        strNoiDung += string.Format("<div style='padding:5px;'><a href='http://khaosat.nuce.edu.vn/phanhoi/st/verify_email.aspx?masv={0}&&key={1}' style='cursor:pointer;'>http://khaosat.nuce.edu.vn/phanhoi/st/verify_email.aspx?masv={0}&&key={1}</a></div>", m_SinhVien.MaSV, keyAuthorzie);
                                        strNoiDung += "<div style='padding:5px;'>Chúc Anh/Chị sức khỏe và thành công!</div>";
                                        strNoiDung += "<div style='padding:5px;'>TRƯỜNG ĐẠI HỌC XÂY DỰNG</div></div>";
                                        spThongBao.InnerHtml = "Cập nhật dữ liệu email thành công. </br> email xác thực đã được gửi.";
                                        Utils.Send_Email(strTieuDe, strNoiDung, strEmail);
                                        //spThongBao.InnerHtml = "Cập nhật dữ liệu thành công. </br> email xác thực đã được gửi.";
                                        m_SinhVien.TrangThai = 2;
                                        m_SinhVien.Email = strEmail;
                                        txtMobile.Text = m_SinhVien.Mobile;
                                    }
                                }
                            }
                        }
                    }
                    Session[Utils.session_sinhvien_qa] = m_SinhVien;
                }
                else
                    spThongBao.InnerHtml = "Mobile không hợp lệ";
            }
            else
                spThongBao.InnerHtml = "Email không hợp lệ";
        }
    }
}