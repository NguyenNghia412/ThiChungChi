using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace nuce.web.khaosatsinhvien.ad
{
    public partial class DeThi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu không có
            int id = -1;
            if (Request.QueryString["id"] == null || !int.TryParse(Request.QueryString["id"], out id))
            {
                //Chuyển đến trang đăng nhập
                divBody.InnerText = "Bạn hãy chọn id đề thi";
            }
            else
            {
                #region bindbailam
                // Lay noi dung bai thi
                string strNoiDungBaiThi = nuce.web.data.Nuce_Survey.getEdu_Survey_BaiKhaoSat_GetNoiDungDeThi(id);
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
  declare @CauHoiID uniqueidentifier;
  set @CauHoiID =(select ID from [dbo].[AS_Edu_Survey_CauHoi] where [CauHoiID]={0}) ;
INSERT INTO [dbo].[AS_Edu_Survey_CauTrucDe]
           ([ID]
           ,[DeThi]
           ,[CauHoiID]
           ,[Count])
     VALUES
           ('{1}'
           ,'32b4c46a-8b34-4591-9df3-b9cb67e2936c'
           ,@CauHoiID
           ,{2}) ", cauhoi.CauHoiID, Guid.NewGuid(),stt*5);
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL);
      */
                    strHtml += string.Format("<tr>");
                    strHtml += string.Format("<td>{0}</td>", stt);
                    strHtml += string.Format("<td>{0}</td>", cauhoi.CauHoiID);
                    if(cauhoi.Type.Equals("GQ"))
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
                                string strNoiDungCauTraLoi="",strIDCH="";
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
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}