using System;
using System.Data;
using System.Web.UI;

namespace Nuce.CTSV
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy dữ liệu từ CSDL
                DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, string.Format(@"SELECT [ID]
      ,[CatID]
      ,[title],update_datetime
  FROM [dbo].[AS_News_Items]
  where CatID in ({0}) order by update_datetime desc", "10,11,12,14")).Tables[0];
                string strThongBao = "<blockquote class='blockquote mb-0'>", strVanBan = "<blockquote class='blockquote mb-0'>", strTuyenDung = "<blockquote class='blockquote mb-0'>", strHocBong = "<blockquote class='blockquote mb-0'>";
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    switch (dtData.Rows[i]["CatID"].ToString())
                    {
                        case "11":
                            //strThongBao += string.Format(@"<div class='row'> <a href='/ChiTietBaiTin?ID={0}'><i class='glyphicon glyphicon-info-sign'></i> {1} - {2:dd/MM/yyyy}</a></div>",
                            //    dtData.Rows[i]["ID"].ToString(), dtData.Rows[i]["title"].ToString(),DateTime.Parse(dtData.Rows[i]["update_datetime"].ToString()));
                            strThongBao += string.Format(@"<div style='font-size: 1rem;'>
                           <i class='fas fa-exclamation'></i>
                        <a href = '/ChiTietBaiTin?ID={0}'>{1} - {2:dd/MM/yyyy}</a>
                      </div>", dtData.Rows[i]["ID"].ToString(), dtData.Rows[i]["title"].ToString(), DateTime.Parse(dtData.Rows[i]["update_datetime"].ToString()));
                            break;
                        case "10":
                            strVanBan += string.Format(@"<div style='font-size: 1rem;'>
                           <i class='fas fa-check'></i>
                        <a href = '/ChiTietBaiTin?ID={0}'>{1} - {2:dd/MM/yyyy}</a>
                      </div>", dtData.Rows[i]["ID"].ToString(), dtData.Rows[i]["title"].ToString(), DateTime.Parse(dtData.Rows[i]["update_datetime"].ToString()));
                            break;
                        case "12":
                            strTuyenDung += string.Format(@"<div style='font-size: 1rem;'>
                           <i class='fas fa-exclamation'></i>
                        <a href = '/ChiTietBaiTin?ID={0}'>{1} - {2:dd/MM/yyyy}</a>
                      </div>", dtData.Rows[i]["ID"].ToString(), dtData.Rows[i]["title"].ToString(), DateTime.Parse(dtData.Rows[i]["update_datetime"].ToString()));
                            break;
                        case "13":
                            strHocBong += string.Format(@"<div style='font-size: 1rem;'>
                           <i class='fas fa-exclamation'></i>
                        <a href = '/ChiTietBaiTin?ID={0}'>{1} - {2:dd/MM/yyyy}</a>
                      </div>", dtData.Rows[i]["ID"].ToString(), dtData.Rows[i]["title"].ToString(), DateTime.Parse(dtData.Rows[i]["update_datetime"].ToString()));
                            break;

                    }
                }
                strThongBao += "</blockquote>";
                strHocBong += "</blockquote>";
                strTuyenDung += "</blockquote>";
                strVanBan += "</blockquote>";

                divThongBaoSinhVien.InnerHtml = strThongBao;
                divHocBong.InnerHtml = strHocBong;
                divTuyenDung.InnerHtml = strTuyenDung;
                divVanBan.InnerHtml = strVanBan;
            }
        }
    }
}