using System;
using System.Data;

namespace nuce.web
{
    public partial class SinhVienTruocKhiTotNghiep : System.Web.UI.Page
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
            spLogin.InnerHtml = string.Format("<a href='/login_can_bo.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} Đăng xuất</a>",m_CanBo.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/canbo/default.aspx'>Lựa chọn</ option >
                              <option value='/canbo/default.aspx'>Home</option>
                              <option value='/login_can_bo.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
        protected void btnTim_Click(object sender, EventArgs e)
        {
            string strMaSV = txtMSV.Text.Trim();
            //m_KiThiLopHocSinhVien.BaiLam = strAnswares;
            // Cap nhat vao database
            DataTable dt = data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.SearchSV(strMaSV);
            if(dt!=null &&dt.Rows.Count>0)
            {
                string strTen = dt.Rows[0]["tensinhvien"].ToString();
                string strLop = dt.Rows[0]["malop"].ToString();
                string strMaKhoa= dt.Rows[0]["makhoa"].ToString();
                string strNganh= dt.Rows[0]["tennganh"].ToString();
                string strEmail = dt.Rows[0]["email"].ToString();
                int iTrangThaiBaiKhaoSat=int.Parse( dt.Rows[0]["StatusBKS"].ToString());
                string strTrangThaiBaiKhaoSat = "";
                int iTrangThaiCapNhatEmail = int.Parse(dt.Rows[0]["status"].ToString());
                string strTrangThaiCapNhatEmail = "";
                string strTrangThai = "";
                if(iTrangThaiBaiKhaoSat.Equals(4))
                {
                    if (iTrangThaiCapNhatEmail.Equals(3))
                    {
                        strTrangThai = "Đã xác thực hoàn thành bải khảo sát";
                    }
                    else
                    {
                        strTrangThai = "Chưa xác thực hoàn thành bài khảo sát";
                    }
                }
                else
                {
                    strTrangThai = "Chưa hoàn thành bải khảo sát";
                }
                string strContent = "";
                if(iTrangThaiCapNhatEmail.Equals(3)&& iTrangThaiBaiKhaoSat.Equals(4))
                {
                    strContent += "<tr class='success' style='text-align: center;'>";
                }
                else
                {
                   if(iTrangThaiBaiKhaoSat.Equals(4))
                    {
                        strContent += "<tr class='danger' style='text-align: center;'>";
                    }
                   else
                    {
                        strContent += "<tr class='danger' style='text-align: center;'>";
                    }
                }
                strContent += string.Format("<td>{0}</td>", strTen);
                strContent += string.Format("<td>{0}</td>", strMaSV);
                strContent += string.Format("<td>{0}</td>", strLop);
                strContent += string.Format("<td>{0}</td>", strMaKhoa);
                strContent += string.Format("<td>{0}</td>", strNganh);
                strContent += string.Format("<td>{0}</td>", strTrangThai);
                if (iTrangThaiCapNhatEmail.Equals(3) && iTrangThaiBaiKhaoSat.Equals(4))
                {
                    // Chèn dữ liệu in
                    string strHtmlIn = "<div style='font-size:16px;'><table style='font-size:16px;' width='100%'><tr><td style='text-align:center;' width='40%'>TRƯỜNG ĐẠI HỌC XÂY DỰNG</td><td style='text-align:center; font-weight:bold;' width='60%'>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</td><tr>";
                    strHtmlIn += "<tr><td style='text-align:center;font-weight:bold;' width='40%'>Phòng KT&ĐBCLGD</td><td style='text-align:center; font-weight:bold;' width='60%'>Độc lập - Tự do - Hạnh phúc</td><tr></table></div>";
                    strHtmlIn += "<div style='font-size:16px;padding: 10px; margin: 15px;'><table style='font-size:16px;'  width='100%'><tr><td style='text-align:center;font-weight:bold;' width='100%'>PHIẾU XÁC NHẬN HOÀN THÀNH KHẢO SÁT</td></tr></table></div>";
                    strHtmlIn += "<div style='font-size:16px;padding-bottom:5px;'>Phòng KT&ĐBCLGD xác nhận sinh viên:</div>";
                    strHtmlIn += string.Format("<div style='font-size:16px; padding-left:5px;padding-bottom:5px;'>- Họ và tên: <span style='font-weight:bold;'>{0}</span></div>", strTen);
                    strHtmlIn += string.Format("<div style='font-size:16px; padding-left:5px;padding-bottom:5px;'>- Mã số sinh viên: <span style='font-weight:bold;'>{0}</span></div>", strMaSV);
                    strHtmlIn += "<div style='font-size:16px;'>Đã hoàn thành khảo sát phản hồi của sinh viên trước khi tốt nghiệp đợt tháng 3 năm 2018 về chương trình đào tạo. </div>";
                    strHtmlIn += string.Format("<div style='font-size:16px; margin:35px;'><table style='font-size:16px;' width='100%'><tr><td width='60%'></td><td style='text-align:center;' width='40%'>Hà Nội, ngày {0} tháng {1} năm 2018</td><tr>", DateTime.Now.Day, DateTime.Now.Month);
                    strHtmlIn += "<tr><td width='60%'></td><td style='text-align:center;' width='40%'>T/M Phòng KT&ĐBCLGD</td><tr></table></div>";
                    divIn.InnerHtml = strHtmlIn;
                    strContent += string.Format("<td><input  type='button' onclick='exportDoc(\"/ExportDoc.aspx?type=1&&masv={0}\")' value='Doc'/><input  type='button' onclick='PrintElem(\"{1}\")' value='IN'/></td>", strMaSV,divIn.ClientID);
                }
                else
                {
                    divIn.InnerHtml = "";
                    strContent += string.Format("<td></td>");
                }
                strContent += "</tr>";
                tbContent.InnerHtml = strContent;
                spThongBao.InnerHtml = "";
            }
            else
            {
                spThongBao.InnerHtml = "Không có dữ liệu";
                tbContent.InnerHtml = "";
            }
        }
    }
}