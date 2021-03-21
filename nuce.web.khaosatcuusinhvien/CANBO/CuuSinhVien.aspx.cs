using System;
using System.Data;

namespace nuce.web
{
    public partial class CuuSinhVien : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            initData();
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
            if (m_CanBo.Type.Equals(2))
            {
                Response.Redirect(string.Format("/CanBo/Admin_CuuSinhVien_TK.aspx"));
            }
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
        protected void initData()
        {
            // Cap nhat vao database
            DataTable dt = data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.CuuSinhVienSearchSVByMAKhoa(m_CanBo.Khoa);
            spThongBao.InnerHtml = string.Format("<span style='font-weight:bold;'>{0}</span> cựu sinh viên hoàn thành bài khảo sát", dt.Rows.Count);
            string strContent = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strTen = dt.Rows[i]["tensinhvien"].ToString();
                    string strLop = dt.Rows[i]["lopqd"].ToString();
                    string strMaSV = dt.Rows[i]["ex_masv"].ToString();
                    DateTime dtNgay = DateTime.Parse(dt.Rows[i]["NgayGioNopBai"].ToString());


                    strContent += "<tr class='success' style='text-align: center;'>";
                    strContent += string.Format("<td>{0}</td>", i + 1);
                    strContent += string.Format("<td>{0}</td>", strTen);
                    strContent += string.Format("<td>{0}</td>", strMaSV);
                    strContent += string.Format("<td>{0}</td>", strLop);
                    strContent += string.Format("<td>{0:dd/MM/yyyy}</td>", dtNgay);
                    strContent += string.Format("<td>{0:HH:mm}</td>", dtNgay);
                    strContent += "</tr>";
                }
                tbContent.InnerHtml = strContent;
            }
            else
            {
                spThongBao.InnerHtml = "Không có dữ liệu";
                tbContent.InnerHtml = m_CanBo.Khoa;
            }
        }
    }
}