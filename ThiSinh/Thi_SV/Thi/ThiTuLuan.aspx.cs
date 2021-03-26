using nuce.web.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Thi_SV.Thi
{
    public partial class ThiTuLuan : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["kithilophocsinhvien"] == null)
                {
                    Response.Redirect("/thi/DanhSachKiThi");
                    return;
                }
                int IDBaiThi = Convert.ToInt32(Request.QueryString["kithilophocsinhvien"]);
                var dt = dnn_NuceThi_KiThi_LopHoc_SinhVien.get(IDBaiThi);
                int Status =  int.Parse(dt.Rows[0]["status"]?.ToString());
                DateTime NgayGioNopBai = dt.Rows[0].IsNull("NgayGioNopBai") ? DateTime.Now : DateTime.Parse(dt.Rows[0]["NgayGioNopBai"].ToString());

                if (Status > 3 || DateTime.Now > NgayGioNopBai)
                {
                    Response.Redirect("/thi/DanhSachKiThi");
                    return;
                }

                scrRun.InnerHtml = $"<script>ThiTuLuan.ID = {IDBaiThi}</script>";
            }
        }
    }
}