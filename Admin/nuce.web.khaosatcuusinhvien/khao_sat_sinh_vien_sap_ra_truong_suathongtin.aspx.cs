using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace nuce.web
{
    public partial class khao_sat_sinh_vien_sap_ra_truong_suathongtin : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (m_KiThiLopHocSinhVien.Status.Equals(4))
                {
                    spMaSV.InnerHtml = m_SinhVien.MaSV;
                    spTenSinhVien.InnerHtml = m_SinhVien.Ten;
                    txtEmail.Text = m_SinhVien.Email;
                    txtMobile.Text = m_SinhVien.Mobile;
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_sinhvienchuanbitotnghiep] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/login_sinh_vien_sap_ra_truong.aspx"));
            }
            if (Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] != null)
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep];
            if ((Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] == null) || (m_KiThiLopHocSinhViens == null) || (m_KiThiLopHocSinhViens.Count == 0))
            {
                Response.Redirect(string.Format("/Khao_sat_sinh_vien_sap_ra_truong.aspx"));
            }
            m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[m_KiThiLopHocSinhViens.ElementAt(0).Key];
            if (!m_KiThiLopHocSinhVien.Status.Equals(4))
            {
                divBody.InnerHtml = @"<div style='text - align: center;width: 329px;margin: 0 auto;color:red;'>
                            Anh/ chị chưa hoàn thành nội dung bài khảo sát
                          </div><div style='text - align: center;width: 346px;margin: 0 auto;color:red;'>
                            <a href='/Khao_sat_sinh_vien_sap_ra_truong.aspx'>Vui lòng quay lại hoàn thành nội dung bài khảo sát</a>
                          </div> ";
            }
            else
            {
                m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvienchuanbitotnghiep];
                if (m_SinhVien.TrangThai != 3)
                {
                    spTrangThai.InnerText = "Chưa xác thực hoàn thành khảo sát.";
                }
                else
                    spTrangThai.InnerText = "Đã xác thực hoàn thành khảo sát.";
                spLogin.InnerHtml = string.Format("<a href='/login_sinh_vien_sap_ra_truong.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - {1} ({2}) - Đăng xuất</a>", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
                mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/Default.aspx'>Lựa chọn</ option >
                              <option value='/Default.aspx'>Home</option>
                              <option value='/khao_sat_sinh_vien_sap_ra_truong_suathongtin.aspx'>Xác thực hoàn thành khảo sát</option>
                              <option value='/login_sinh_vien_sap_ra_truong.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            }
            base.OnInit(e);
        }


        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strEmail = txtEmail.Text.Trim();
            string strMobile = txtMobile.Text.Trim();
            string strCMT = txtCMT.Text.Trim();
            if(strCMT.Length<9)
            { 
                spThongBao.InnerHtml = "Bạn hãy nhập đúng thông tin CMT (CCCD).";
                return;
            }
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
                        DataTable dt = data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.update(m_SinhVien.MaSV,
            strEmail,
             "",
             "",
            strMobile,
             "",strCMT
             , "cap nhat tu sinh vien", ""

             );
                        string strLoai = dt.Rows[0]["loai"].ToString();
                        if (strLoai.Equals("0"))
                        {
                            spThongBao.InnerHtml = "Cập nhật dữ liệu không thành công.";
                            bThongBao.InnerHtml = "";
                        }
                        else
                        {
                            if (strLoai.Equals("1"))
                            {
                                spThongBao.InnerHtml = "Cập nhật dữ liệu mobile thành công.";
                                bThongBao.InnerHtml = "";
                                m_SinhVien.Mobile = strMobile;
                                txtEmail.Text = m_SinhVien.Email;
                            }
                            else
                            if (strLoai.Equals("2"))
                            {
                                // Gửi email xác thực
                                string keyAuthorzie = dt.Rows[0]["authorize"].ToString();
                                string strTieuDe = string.Format("Xác thực hoàn thành khảo sát");
                                string strNoiDung = "<div style='color:black;'><div style='padding:5px;'>Trân trọng cảm ơn Anh/Chị đã hoàn thành nội dung Phiếu khảo sát về chương trình đào tạo của Nhà trường.</div>";
                                strNoiDung += "<div style='padding:5px;'>Vui lòng nhấn vào đường link dưới đây để xác thực hoàn thành khảo sát.</div>";
                                strNoiDung += string.Format("<div style='padding:5px;'><a href='http://ktdb1.nuce.edu.vn/Khao_sat_sinh_vien_sap_ra_truong_xacthucemail.aspx?masv={0}&&key={1}' style='cursor:pointer;'>http://ktdb1.nuce.edu.vn/Khao_sat_sinh_vien_sap_ra_truong_xacthucemail.aspx?masv={0}&&key={1}</a></div>", m_SinhVien.MaSV, keyAuthorzie);
                                strNoiDung += "<div style='padding:5px;'>Chúc Anh/Chị sức khỏe và thành công!</div>";
                                strNoiDung += "<div style='padding:5px;'>TRƯỜNG ĐẠI HỌC XÂY DỰNG</div></div>";
                                GuiEmail(strTieuDe, strNoiDung, strEmail);
                                //spThongBao.InnerHtml = "Cập nhật dữ liệu email thành công. </br> email xác thực đã được gửi.";
                                spThongBao.InnerHtml = "Cập nhật dữ liệu thành công. </br> email xác thực đã được gửi.";
                                bThongBao.InnerHtml = "Chú ý: Email xác thực có thể được chuyển vào mục SPAM trong hộp thư của anh/chị. Vui lòng kiểm tra thưc mục SPAM.";
                                m_SinhVien.TrangThai = 2;
                                m_SinhVien.Email = strEmail;
                                m_SinhVien.Mobile = strMobile;
                            }
                            else
                            {
                                if (strLoai.Equals("3"))
                                {
                                    spThongBao.InnerHtml = "Địa chỉ email và mobile đã được sinh viên khác sử dụng.";
                                    bThongBao.InnerHtml = "";
                                }
                                else
                                {
                                    if (strLoai.Equals("4"))
                                    {
                                        // Gửi email xác thực
                                        string keyAuthorzie = dt.Rows[0]["authorize"].ToString();
                                        string strTieuDe = string.Format("Xác thực hoàn thành khảo sát");
                                        string strNoiDung = "<div style='color:black;'><div style='padding:5px;'>Trân trọng cảm ơn Anh/Chị đã hoàn thành nội dung Phiếu khảo sát về chương trình đào tạo của Nhà trường.</div>";
                                        strNoiDung += "<div style='padding:5px;'>Vui lòng nhấn vào đường link dưới đây để xác thực hoàn thành khảo sát.</div>";
                                        strNoiDung += string.Format("<div style='padding:5px;'><a href='http://ktdb1.nuce.edu.vn/Khao_sat_sinh_vien_sap_ra_truong_xacthucemail.aspx?masv={0}&&key={1}' style='cursor:pointer;'>http://ktdb1.nuce.edu.vn/Khao_sat_sinh_vien_sap_ra_truong_xacthucemail.aspx?masv={0}&&key={1}</a></div>", m_SinhVien.MaSV, keyAuthorzie);
                                        strNoiDung += "<div style='padding:5px;'>Chúc Anh/Chị sức khỏe và thành công!</div>";
                                        strNoiDung += "<div style='padding:5px;'>TRƯỜNG ĐẠI HỌC XÂY DỰNG</div></div>";
                                        spThongBao.InnerHtml = "Cập nhật dữ liệu email thành công. </br> email xác thực đã được gửi.";
                                        bThongBao.InnerHtml = "Chú ý: Email xác thực có thể được chuyển vào mục SPAM trong hộp thư của anh/chị. Vui lòng kiểm tra thưc mục SPAM.";
                                        GuiEmail(strTieuDe, strNoiDung, strEmail);
                                        //spThongBao.InnerHtml = "Cập nhật dữ liệu thành công. </br> email xác thực đã được gửi.";
                                        m_SinhVien.TrangThai = 2;
                                        m_SinhVien.Email = strEmail;
                                        txtMobile.Text = m_SinhVien.Mobile;
                                    }
                                }
                            }
                        }
                    }
                    Session[Utils.session_sinhvienchuanbitotnghiep] = m_SinhVien;
                }
                else
                {
                    spThongBao.InnerHtml = "Địa chỉ mobile sai định dạng.";
                }
            }
            else
            {
                spThongBao.InnerHtml = "Địa chỉ email sai định dạng.";
            }
        }
        public void GuiEmail(string Subject, string Message, string EmailTo)
        {
            try
            {
                string strReturn = Utils.Send_Email(Subject, Message, EmailTo);
                data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.TinNhan_Insert("GUI_EMAIL_", -1, m_SinhVien.MaSV, m_SinhVien.Ten, m_SinhVien.Ten, EmailTo, Message, 1, -1, Subject);
                // Cap nhat vao csdl
                //data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, "GUI_EMAIL_" + m_SinhVien.MaSV, 1, string.Format("Gưi email đến {0} với email {1}: {2} ", m_SinhVien.MaSV, m_SinhVien.Email, strReturn));
            }
            catch(Exception ex)
            {
                data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, "GUI_EMAIL_ERROR" + m_SinhVien.MaSV, 1, string.Format("Gưi email đến {0} với email {1}: {2} ", m_SinhVien.MaSV, m_SinhVien.Email, ex.ToString()));
            }
        }

    }
}