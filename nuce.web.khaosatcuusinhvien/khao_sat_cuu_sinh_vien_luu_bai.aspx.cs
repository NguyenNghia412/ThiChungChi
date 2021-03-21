using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web
{
    public partial class khao_sat_cuu_sinh_vien_luu_bai : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            string strData = "-1";
            try
            {
                if (Session[Utils.session_kithi_lophoc_cuusinhvien] == null)
                {
                    strData = "NotAuthenticated";
                }
                else
                {
                    m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lophoc_cuusinhvien];
                    m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[m_KiThiLopHocSinhViens.ElementAt(0).Key];
                    if (m_KiThiLopHocSinhVien.Status!=4)
                    {
                        string strAnswares = Request.QueryString["answare"].ToString();
                        m_KiThiLopHocSinhVien.BaiLam = strAnswares;
                        m_KiThiLopHocSinhViens[m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien] = m_KiThiLopHocSinhVien;
                        Session[Utils.session_kithi_lophoc_cuusinhvien] = m_KiThiLopHocSinhViens;
                        data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.update_bailam1(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, strAnswares, DateTime.Now, Utils.GetIPAddress(), 1);
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