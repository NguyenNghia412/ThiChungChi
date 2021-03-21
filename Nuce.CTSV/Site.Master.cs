using System;
using System.Web.UI;
namespace Nuce.CTSV
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[Utils.session_sinhvien] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/Login.aspx"));
            }
            else
            {
                nuce.web.model.SinhVien SinhVien = (nuce.web.model.SinhVien)Session[Utils.session_sinhvien];
                spNameUser.InnerHtml = string.Format("{0} - {1}", SinhVien.Ho, SinhVien.MaSV);
                imgUser.Src = SinhVien.IMG;
                string strNav = @"<a class='sidebar-brand d-flex align-items-center justify-content-center' href = '/dichvusinhvien'>
                    <div class='sidebar-brand-icon rotate-n-15'>
                        <i class='fas fa-laugh-wink'></i>
                    </div>
                    <div class='sidebar-brand-text mx-3'>Dashboard</div>
                </a>
                <hr class='sidebar-divider my-0' />";
                string URL = Request.RawUrl.ToUpper();
                if (URL.Contains("DICHVU"))//dichvusinhvien
                    strNav += string.Format(@"<li class='nav-item active'>
          <a class='nav-link' href='/dichvusinhvien'>
            <i class='fas fa-tools'></i>
            <span>Thủ tục hành chính</span>
          </a> </li><hr class='sidebar-divider'/>");
                else
                    strNav += string.Format(@"<li class='nav-item'>
          <a class='nav-link' href='/dichvusinhvien'>
            <i class='fas fa-tools'></i>
            <span>Thủ tục hành chính</span>
          </a>
        </li><hr class='sidebar-divider'/>");
                //      if (URL.Contains("DEFAULT") || URL.Contains("CHITIETBAITIN"))
                //          strNav += string.Format(@"<li class='nav-item active'>
                //<a class='nav-link' href='/default'>
                //  <i class='fas fa-home'></i>
                //  <span>Trang chủ</span></a>
                //  </li> <hr class='sidebar-divider'/>");
                //      else
                //          strNav += string.Format(@"<li class='nav-item'>
                //<a class='nav-link' href='/default'>
                //  <i class='fas fa-home'></i>
                //  <span>Trang chủ</span></a>
                //   </li> <hr class='sidebar-divider'/>");
                if (URL.Contains("HOSOSINHVIEN")) ///hososinhvien
                    strNav += string.Format(@"<li class='nav-item active'>
          <a class='nav-link' href='/hososinhvien'>
            <i class='fas fa-address-book'></i>
            <span>Hồ sơ</span>
          </a>
        </li>");
                else
                    strNav += string.Format(@"<li class='nav-item'>
          <a class='nav-link' href='/hososinhvien'>
            <i class='fas fa-address-book'></i>
            <span>Hồ sơ</span>
          </a>
        </li>");
                if (URL.Contains("CAPNHATHOSO")) ///capnhathoso
                    strNav += string.Format(@"<li class='nav-item active'>
          <a class='nav-link' href='/capnhathoso'>
            <i class='fas fa-user-edit'></i>
            <span>Cập nhật hồ sơ</span>
          </a></li>");
                else
                    strNav += string.Format(@"<li class='nav-item'>
          <a class='nav-link' href='/capnhathoso'>
            <i class='fas fa-user-edit'></i>
            <span>Cập nhật hồ sơ</span>
          </a>
        </li>");

                if (URL.Contains("DEFAULT") || URL.Contains("CHITIETBAITIN"))
                    strNav += string.Format(@"<li class='nav-item active'>
          <a class='nav-link' href='/default'>
            <i class='fas fa-newspaper'></i>
            <span>Thông báo</span></a>
            </li> ");
                else
                    strNav += string.Format(@"<li class='nav-item'>
          <a class='nav-link' href='/default'>
            <i class='fas fa-newspaper'></i>
            <span>Thông báo</span></a>
             </li> ");
                accordionSidebar.InnerHtml = strNav;
            }
        }
    }
}