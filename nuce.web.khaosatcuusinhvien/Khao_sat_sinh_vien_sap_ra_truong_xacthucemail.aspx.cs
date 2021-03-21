using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web.khaosatcuusinhvien
{
    public partial class Khao_sat_sinh_vien_sap_ra_truong_xacthucemail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if( Request.QueryString["masv"]!=null && Request.QueryString["masv"]!="" && Request.QueryString["key"] != null && Request.QueryString["key"] != "")
            {
                string strMasv = Request.QueryString["masv"].Trim();
                string key = Request.QueryString["key"].Trim();
                if(data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.authen_email(strMasv, key,3)>0)
                {
                    Session.Abandon();
                    Session.RemoveAll();
                    divThongBao.InnerHtml = "Xác thực địa chỉ email thành công (<a href='/' style='cursor:pointer;'>quay về trang chủ</a>)";
                }
                else
                {
                    divThongBao.InnerHtml = "Không xác thực được địa chỉ email";
                }
            }
        }
    }
}