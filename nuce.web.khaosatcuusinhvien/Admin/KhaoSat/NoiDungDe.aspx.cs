using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace nuce.web.admin.KhaoSat
{
    public partial class NoiDungDe : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Nếu không có
                int id = -1;
                if (Request.QueryString["id"] == null)
                {
                    //Chuyển đến trang đăng nhập
                    divBody.InnerText = "Bạn hãy chọn id đề khảo sát";
                }
                else
                {
                    #region bindbailam
                    // Lay noi dung bai thi
                    string strSQL = string.Format(@"select * from AS_Edu_Survey_DeThi where ID=@Param0");
                    SqlParameter[] sqlParams;
                    sqlParams = new SqlParameter[1];
                    sqlParams[0] = new SqlParameter("@Param0", Request.QueryString["id"].ToString());
                    DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams).Tables[0];
                    string strNoiDungBaiThi = dt.Rows[0]["NoiDungDeThi"].ToString();
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(strNoiDungBaiThi);
                    string strHtml = "<table border='1px'>";
                    strHtml += string.Format("<tr style='color:red;text-align:center;'>");
                    strHtml += string.Format("<td width='20px'>STT</td>");
                    strHtml += string.Format("<td width='20px'>ID</td>");
                    strHtml += string.Format("<td>Nội dung câu hỏi</td>");
                    strHtml += string.Format("<td width='80px'>Loai cau hoi</td>");
                    strHtml += string.Format("</tr>");
                    int stt = 1;
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        // Cập nhật cơ sở dữ liệu
                        /*
                        Guid G_CauHoi = Guid.NewGuid();
                        string strSQL = string.Format(@"
    if(not exists(select 1 from AS_Edu_Survey_CauHoi where CauHoiID=@Param1))
    Begin
    INSERT INTO [dbo].[AS_Edu_Survey_CauHoi]
               ([ID]
               ,[CauHoiID]
               ,[BoCauHoiID]
               ,[DoKhoID]
               ,[Ma]
               ,[Content]
               ,[InsertedDate]
               ,[UpdatedDate]
               ,[Order]
               ,[Level]
               ,[Type]
               ,[Status]
               )
         VALUES
               (@Param0,@Param1,-1,1,@Param1,@Param2,@Param3,@Param3,{0},1,'{1}',1)
    END;
    INSERT INTO [dbo].[AS_Edu_Survey_CauTrucDe]
               ([ID]
               ,[DeThi]
               ,[CauHoiID]
               ,[Count])
         VALUES
               (@Param4
               ,'32B4C46A-8B34-4591-9DF3-B9CB67E2936C'
               ,'{2}'
               ,{3}) ", stt, cauhoi.Type, G_CauHoi,stt*5);

                        SqlParameter[] sqlParams = new SqlParameter[5];
                        sqlParams[0] = new SqlParameter("@Param0", G_CauHoi);
                        sqlParams[1] = new SqlParameter("@Param1", cauhoi.CauHoiID);
                        sqlParams[2] = new SqlParameter("@Param2", cauhoi.Content);
                        sqlParams[3] = new SqlParameter("@Param3", DateTime.Now);
                        sqlParams[4] = new SqlParameter("@Param4",Guid.NewGuid());
                        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams);
                        */
                        strHtml += string.Format("<tr>");
                        strHtml += string.Format("<td>{0}</td>", stt);
                        strHtml += string.Format("<td>{0}</td>", cauhoi.CauHoiID);
                        if (cauhoi.Type.Equals("GQ"))
                            strHtml += string.Format("<td style='color:red;font-weight:bold;'>{0}</td>", HttpUtility.HtmlDecode(cauhoi.Content));
                        else
                            strHtml += string.Format("<td style='color:blue;'>{0}</td>", HttpUtility.HtmlDecode(cauhoi.Content));
                        strHtml += string.Format("<td>{0}</td>", cauhoi.Type);
                        strHtml += string.Format("</tr>");
                        switch (cauhoi.Type)
                        {
                            case "SC":
                            case "MC":

                                strHtml += string.Format("<tr  style='text-align:center;'>");
                                strHtml += "<td colspan='4'>";
                                strHtml += "<table border='1px'>";
                                strHtml += string.Format("<tr style='color:red;text-align:center;'>");
                                strHtml += string.Format("<td width='20px'>STT</td>");
                                strHtml += string.Format("<td width='20px'>ID</td>");
                                strHtml += string.Format("<td>Nội dung câu trả lời</td>");
                                strHtml += string.Format("</tr>");
                                for (int i = 0; i < cauhoi.SoCauTraLoi; i++)
                                {
                                    string strNoiDungCauTraLoi = "", strIDCH = "";
                                    switch (i + 1)
                                    {
                                        case 1:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A1);
                                            strIDCH = cauhoi.M1;

                                            break;
                                        case 2:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A2);
                                            strIDCH = cauhoi.M2;
                                            break;
                                        case 3:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A3);
                                            strIDCH = cauhoi.M3;
                                            break;
                                        case 4:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A4);
                                            strIDCH = cauhoi.M4;
                                            break;
                                        case 5:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A5);
                                            strIDCH = cauhoi.M5;
                                            break;
                                        case 6:
                                            strNoiDungCauTraLoi = HttpUtility.HtmlDecode(cauhoi.A6);
                                            strIDCH = cauhoi.M6;
                                            break;
                                        default: break;
                                    }
                                    strHtml += string.Format("<tr>");
                                    strHtml += string.Format("<td>{0}</td>", i + 1);
                                    strHtml += string.Format("<td>{0}</td>", strIDCH);
                                    strHtml += string.Format("<td style='color:blue;'>{0}</td>", strNoiDungCauTraLoi);
                                    strHtml += string.Format("</tr>");
                                    /*
                                    strSQL = string.Format(@"
                                                        if(not exists(select 1 from AS_Edu_Survey_DapAn where DapAnID=@Param1))
                                                        Begin
                                                        INSERT INTO [dbo].[AS_Edu_Survey_DapAn]
                                                                   ([ID]
                                                                   ,[DapAnID]
                                                                   ,[CauHoiGID]
                                                                   ,[CauHoiID]
                                                                   ,[SubQuestionId]
                                                                   ,[Content]
                                                                   ,[IsCheck]
                                                                   ,[Order]
                                                                   ,[Status])
                                                             VALUES
                                                                   (@Param0,@Param1,@Param2,@Param3,-1,@Param4,0,{0},1)
                                                        END;", i);
                                    sqlParams = new SqlParameter[5];
                                    sqlParams[0] = new SqlParameter("@Param0", Guid.NewGuid());
                                    sqlParams[1] = new SqlParameter("@Param1", strIDCH);
                                    sqlParams[2] = new SqlParameter("@Param2", G_CauHoi);
                                    sqlParams[3] = new SqlParameter("@Param3", cauhoi.CauHoiID);
                                    sqlParams[4] = new SqlParameter("@Param4", HttpUtility.HtmlEncode(strNoiDungCauTraLoi));
                                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams);
                                    */
                                }
                                strHtml += string.Format("</table>");
                                strHtml += "</td>";
                                strHtml += string.Format("</tr>");
                                break;
                            default: break;
                        }
                        stt++;
                    }
                    strHtml += string.Format("</table>");
                    divBody.InnerHtml = strHtml;
                    #endregion
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