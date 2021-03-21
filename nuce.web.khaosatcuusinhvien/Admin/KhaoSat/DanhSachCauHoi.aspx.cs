using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace nuce.web.admin.KhaoSat
{
    public partial class DanhSachCauHoi : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Lấy dữ liệu của bang câu hỏi
                string strSQL = string.Format(@"select * from AS_Edu_Survey_CauHoi where status<>4 order by [Order];");
                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL).Tables[0];
                string strHtml = "";
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    strHtml += "<tr>";
                    strHtml += string.Format("<td>{0}</td>",i+1);
                    strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Ma"].ToString());
                    strHtml += string.Format("<td>{0}</td>", HttpUtility.HtmlDecode(dt.Rows[i]["Content"].ToString()));
                    strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Type"].ToString());
                    strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Order"].ToString());
                    strHtml += string.Format("<td><a href='/Admin/KhaoSat/SuaCauHoi.aspx?action=edit&&id={0}'>Sửa</a></td>", dt.Rows[i]["ID"].ToString());
                    strHtml += string.Format("<td><a href='/Admin/KhaoSat/SuaCauHoi.aspx?action=new'>Thêm mới</a></td>");
                    strHtml += string.Format("<td><a href='/Admin/KhaoSat/DanhSachDapAn.aspx?cauhoiid={0}'>Đáp án</a></td>", dt.Rows[i]["ID"].ToString());
                    strHtml += "</tr>";
                }
                tbContent.InnerHtml = strHtml;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_admin_user] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/admin/login.aspx"));
            }
            m_User = (model.User)Session[Utils.session_admin_user];
            spLogin.InnerHtml = string.Format("<a href='/admin/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Đăng xuất</a>");
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                                <option value='/ admin / Default.aspx'>Trang chủ</option>
                                   </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}