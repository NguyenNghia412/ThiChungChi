using System;
using System.Collections.Generic;
using System.Linq;

namespace nuce.web
{
    public partial class Khao_sat_sinh_vien_luu_bai : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strData = "-1";
            try
            {
                if (Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien] == null)
                {
                    strData = "NotAuthenticated";
                }
                else
                {
                    int id = int.Parse(Request.QueryString["id"].ToString().Trim());
                    m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien];
                    m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[id];
                    if (m_KiThiLopHocSinhVien.Status!=4)
                    {
                        string strAnswares = Request.QueryString["answare"].ToString();
                        m_KiThiLopHocSinhVien.BaiLam = strAnswares;
                        m_KiThiLopHocSinhVien.Status = 2;
                        m_KiThiLopHocSinhViens[m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien] = m_KiThiLopHocSinhVien;
                        Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] = m_KiThiLopHocSinhViens;
                        data.Nuce_Survey.Edu_Survey_BaiKhaoSat_SinhVien_update_bailam(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, strAnswares, DateTime.Now, Utils.GetIPAddress(), 2);
                    }
                    strData = "1";
                }
            }
            catch (Exception ex)
            {
                strData = ex.Message;
            }
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write(strData);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}