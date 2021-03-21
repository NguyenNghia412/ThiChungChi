using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace nuce.web.admin.KhaoSat
{
    public partial class DanhSachDapAn : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["cauhoiid"] != null)
                {
                    string strCauHoiID = Request.QueryString["cauhoiid"].ToString();
                    //Lấy dữ liệu của bang câu hỏi
                    string strSQL = string.Format(@"select * from AS_Edu_Survey_CauHoi where status<>4 and ID=@Param0;
                    select * from AS_Edu_Survey_DapAn where status<>4 and CauHoiGID=@Param0 order by [Order]");

                    SqlParameter[] sqlParams = new SqlParameter[1];
                    sqlParams[0] = new SqlParameter("@Param0", strCauHoiID);
                    DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        DataTable dt2 = ds.Tables[1];
                        spNoiDungCauHoi.InnerHtml = HttpUtility.HtmlDecode( dt1.Rows[0]["Content"].ToString());
                        string strHtml = "";
                        if (dt2.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt2.Rows.Count; i++)
                            {
                                strHtml += "<tr>";
                                strHtml += string.Format("<td>{0}</td>", i + 1);
                                strHtml += string.Format("<td>{0}</td>", dt2.Rows[i]["DapAnID"].ToString());
                                strHtml += string.Format("<td>{0}</td>", HttpUtility.HtmlDecode(dt2.Rows[i]["Content"].ToString()));
                                strHtml += string.Format("<td>{0}</td>", dt2.Rows[i]["Order"].ToString());
                                strHtml += string.Format("<td><a href='/Admin/KhaoSat/SuaDapAn.aspx?action=edit&&id={0}&&cauhoiid={1}'>Sửa</a></td>", dt2.Rows[i]["ID"].ToString(), strCauHoiID);
                                strHtml += string.Format("<td><a href='/Admin/KhaoSat/SuaDapAn.aspx?action=new&&cauhoiid={0}'>Thêm mới</a></td>", strCauHoiID);

                                strHtml += "</tr>";
                            }
                        }
                        else
                        {
                            strHtml += "<tr>";
                            strHtml += string.Format("<td colspan='6'><a href='/Admin/KhaoSat/SuaDapAn.aspx?action=new&&cauhoiid={0}'>Thêm mới</a></td>",strCauHoiID);
                            strHtml += "</tr>";
                        }
                        tbContent.InnerHtml = strHtml;
                    }
                    else
                    {
                        Response.Redirect(string.Format("/admin/khaosat/danhsachcauhoi.aspx"));
                    }
                }
                else
                {
                    Response.Redirect(string.Format("/admin/khaosat/danhsachcauhoi.aspx"));
                }
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