using System;
using System.Data;

namespace nuce.web
{
    public partial class Admin_CuuSinhVien_TK : System.Web.UI.Page
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
            if(m_CanBo.Type.Equals(1))
            {
                Response.Redirect(string.Format("/CanBo/CuuSinhVien.aspx"));
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
            DataTable dt = data.dnn_Nuce_KS_SinhVienSapRaTruong_CanBo.SinhVienRaTruong_GetTK();
            spThongBao.InnerHtml = string.Format("<span style='font-weight:bold;'>Thống kê số sinh viên làm bài theo các chuyên ngành</span>");
            string strContent = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string MN = dt.Rows[i]["MN"].ToString();
                    string TN = dt.Rows[i]["TN"].ToString();
                    string CN = dt.Rows[i]["CN"].ToString();
                    int TSSVTN = int.Parse(dt.Rows[i]["TSSVTN"].ToString());
                    int TSSVTTPD = int.Parse(dt.Rows[i]["TSSVTTPD"].ToString());
                    int CUUSVDATGKS = int.Parse(dt.Rows[i]["CUUSVDATGKS"].ToString());
                    int SLCT = int.Parse(dt.Rows[i]["SLCT"].ToString());


                    strContent += "<tr class='success' style='text-align: center;'>";
                    strContent += string.Format("<td>{0}</td>", i + 1);
                    strContent += string.Format("<td>{0}</td>", MN);
                    strContent += string.Format("<td>{0}</td>", TN);
                    strContent += string.Format("<td>{0}</td>", CN);
                    strContent += string.Format("<td>{0}</td>", TSSVTN);
                    strContent += string.Format("<td>{0}</td>", TSSVTTPD);
                    strContent += string.Format("<td>{0}</td>", CUUSVDATGKS);
                    strContent += string.Format("<td>{0}</td>", SLCT);
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