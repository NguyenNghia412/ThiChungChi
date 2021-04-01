using nuce.web.data;
using nuce.web.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using Thi_SV;

namespace nuce.web.sinhvien
{
    public partial class tcc_logout : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string strData = "-1";
            try
            {
                var nguoiThi = (SinhVien)Session[Utils.session_sinhvien];
                dnn_NuceThi_Log.insertLog(nguoiThi.SinhVienID, "Đăng xuất", "");
                Session.RemoveAll();
                strData = "1";
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