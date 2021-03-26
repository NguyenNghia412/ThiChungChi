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
                scrRun.InnerHtml = $"<script>ThiTuLuan.ID = {IDBaiThi}</script>";
            }
        }
    }
}