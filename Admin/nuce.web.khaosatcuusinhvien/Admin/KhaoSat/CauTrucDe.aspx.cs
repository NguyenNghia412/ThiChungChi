using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace nuce.web.admin.KhaoSat
{
    public partial class CauTrucDe : System.Web.UI.Page
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

                }
                else
                {
                    //Lấy dữ liệu của bang câu hỏi
                    txtID.Text = Request.QueryString["id"].ToString();
                    bindata();
                }
            }
        }
        private void bindata()
        {
            string strSQL = string.Format(@"SELECT DeThi,a.Count,a.ID,a.CauHoiID,b.Ma,b.Content,b.Type
  FROM [dbo].[AS_Edu_Survey_CauTrucDe] a inner join [dbo].[AS_Edu_Survey_CauHoi] b
  on a.CauHoiID=b.ID
where DeThi=@Param0
order by a.Count");
            SqlParameter[] sqlParams;
            sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@Param0", txtID.Text);
            DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams).Tables[0];
            string strHtml = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strHtml += "<tr>";
                strHtml += string.Format("<td>{0}</td>", i + 1);
                strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Ma"].ToString());
                strHtml += string.Format("<td>{0}</td>", HttpUtility.HtmlDecode(dt.Rows[i]["Content"].ToString()));
                strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Type"].ToString());
                strHtml += string.Format("<td>{0}</td>", dt.Rows[i]["Count"].ToString());
                strHtml += "</tr>";
            }
            tbContent.InnerHtml = strHtml;
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

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //Thêm mới câu hỏi vào trong đề
            string strMaCauHoi = txtMa.Text;
            string strThuTu = txtCount.Text;
            string strSQL = string.Format(@"
            declare @CauHoiID uniqueidentifier;
set @CauHoiID =(select [ID] from [dbo].[AS_Edu_Survey_CauHoi] where [Ma]='{2}');
select @CauHoiID
            INSERT INTO [dbo].[AS_Edu_Survey_CauTrucDe]
           ([ID]
           ,[DeThi]
           ,[CauHoiID]
           ,[Count])
     VALUES
           ('{0}'
           ,'{1}'
           , @CauHoiID
           ,{3})", Guid.NewGuid(), txtID.Text, strMaCauHoi, strThuTu);
            if (Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL) > 0)
            {
                divThongBao.InnerHtml = "Thêm mới câu hỏi vào bộ đề thành công";
                bindata();
            }
            else
            {
                divThongBao.InnerHtml = "Thêm mới câu hỏi vào bộ đề không thành công";
            }

        }

        protected void btnTaoDe_Click(object sender, EventArgs e)
        {
            List<model.CauHoi> lCauHoiTemp = new List<model.CauHoi>();
            List<model.DapAn> lDapAnTemp = new List<model.DapAn>();
            string strSQL = string.Format(@"SELECT b.*
  FROM [dbo].[AS_Edu_Survey_CauTrucDe] a inner join [dbo].[AS_Edu_Survey_CauHoi] b
  on a.CauHoiID=b.ID
where DeThi=@Param0
order by a.Count;
select * from AS_Edu_Survey_DapAn where CauHoiGID in (SELECT b.ID
  FROM [dbo].[AS_Edu_Survey_CauTrucDe] a inner join [dbo].[AS_Edu_Survey_CauHoi] b
  on a.CauHoiID=b.ID
where DeThi=@Param0 );");
            SqlParameter[] sqlParams;
            sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@Param0", txtID.Text);
            DataSet ds = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams);
            DataTable tblCauHoi = ds.Tables[0];
            DataTable tblDapAn = ds.Tables[1];
            for (int i = 0; i < tblCauHoi.Rows.Count; i++)
            {
                model.CauHoi CauHoiTemp = new model.CauHoi();
                model.DapAn DapAnTemp = new model.DapAn();
                DataRow[] drTemps;

                List<model.CauHoi> ChildCauHois = new List<model.CauHoi>();
                model.CauHoi CauHoiTemp1 = new model.CauHoi();
                model.DapAn DapAnTemp1 = new model.DapAn();

                CauHoiTemp = getRowCauHoi(tblCauHoi.Rows[i], tblDapAn, out DapAnTemp);
                if (!DapAnTemp.Equals(""))
                {
                    lDapAnTemp.Add(DapAnTemp);
                }
                // Them moi vao list
                lCauHoiTemp.Add(CauHoiTemp);
            }
            string strNoiDung = JsonConvert.SerializeObject(lCauHoiTemp);
            string strDapAn = JsonConvert.SerializeObject(lDapAnTemp);
            // Cap nhat vao co so du lieu
            strSQL = string.Format(@"UPDATE [dbo].[AS_Edu_Survey_DeThi]
   SET 
      [NoiDungDeThi] = @Param1
      ,[DapAn] =  @Param2
 WHERE ID=@Param3;");
            sqlParams = new SqlParameter[3];
            sqlParams[0] = new SqlParameter("@Param1", strNoiDung);
            sqlParams[1] = new SqlParameter("@Param2", strDapAn);
            sqlParams[2] = new SqlParameter("@Param3", txtID.Text);
            if (Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams) > 0)
            {
                divThongBao.InnerHtml = "Cập nhật nội dung đề thi thành công";
            }
            else
            {
                divThongBao.InnerHtml = "Cập nhật nội dung đề thi thất bại";
            }
        }
        model.CauHoi getRowCauHoi(DataRow dr, DataTable dtDapAns, out model.DapAn DapAnTemp)
        {
            // type=1 random
            //type=2 khong random
            model.CauHoi CauHoiTemp = new model.CauHoi();
            DapAnTemp = new model.DapAn();
            int iCauHoiTemp = int.Parse(dr["Ma"].ToString());
            CauHoiTemp.CauHoiID = iCauHoiTemp;
            CauHoiTemp.Content = dr["Content"].ToString();
            CauHoiTemp.DoKhoID = 1;
            CauHoiTemp.Explain = "";
            CauHoiTemp.Image = "";
            string strTypeCauHoiTemp = dr["Type"].ToString();
            CauHoiTemp.Type = strTypeCauHoiTemp;

            int iDoKhoIDTemp = int.Parse(dr["DoKhoID"].ToString());
            DataRow[] drTemps;
            drTemps = GetDapAnFromCauHoiNotRandom(Guid.Parse(dr["ID"].ToString()), dtDapAns);
            int iLengthDrTemp = drTemps.Length;
            CauHoiTemp.SoCauTraLoi = iLengthDrTemp;
            string strMatchTemp = "";
            if (iLengthDrTemp > 0)
            {
                switch (strTypeCauHoiTemp)
                {
                    case "SC":
                    case "MC":
                    case "TQ":
                    case "FQ":
                        int l = 1;
                        foreach (DataRow drTemp in drTemps)
                        {
                            bool blIsCheck1 = false;
                            int iDapAnID1 = int.Parse(drTemp["DapAnID"].ToString());
                            if (blIsCheck1)
                            {
                                strMatchTemp = strMatchTemp + ";" + iDapAnID1.ToString();
                            }
                            switch (l)
                            {
                                #region
                                case 1:
                                    CauHoiTemp.A1 = drTemp["Content"].ToString();
                                    CauHoiTemp.M1 = iDapAnID1.ToString();
                                    break;
                                case 2:
                                    CauHoiTemp.A2 = drTemp["Content"].ToString();
                                    CauHoiTemp.M2 = iDapAnID1.ToString();
                                    break;
                                case 3:
                                    CauHoiTemp.A3 = drTemp["Content"].ToString();
                                    CauHoiTemp.M3 = iDapAnID1.ToString();
                                    break;
                                case 4:
                                    CauHoiTemp.A4 = drTemp["Content"].ToString();
                                    CauHoiTemp.M4 = iDapAnID1.ToString();
                                    break;
                                case 5:
                                    CauHoiTemp.A5 = drTemp["Content"].ToString();
                                    CauHoiTemp.M5 = iDapAnID1.ToString();
                                    break;
                                case 6:
                                    CauHoiTemp.A6 = drTemp["Content"].ToString();
                                    CauHoiTemp.M6 = iDapAnID1.ToString();
                                    break;
                                case 7:
                                    CauHoiTemp.A7 = drTemp["Content"].ToString();
                                    CauHoiTemp.M7 = iDapAnID1.ToString();
                                    break;
                                case 8:
                                    CauHoiTemp.A8 = drTemp["Content"].ToString();
                                    CauHoiTemp.M8 = iDapAnID1.ToString();
                                    break;
                                case 9:
                                    CauHoiTemp.A9 = drTemp["Content"].ToString();
                                    CauHoiTemp.M9 = iDapAnID1.ToString();
                                    break;
                                case 10:
                                    CauHoiTemp.A10 = drTemp["Content"].ToString();
                                    CauHoiTemp.M10 = iDapAnID1.ToString();
                                    break;
                                case 11:
                                    CauHoiTemp.A11 = drTemp["Content"].ToString();
                                    CauHoiTemp.M11 = iDapAnID1.ToString();
                                    break;
                                case 12:
                                    CauHoiTemp.A12 = drTemp["Content"].ToString();
                                    CauHoiTemp.M12 = iDapAnID1.ToString();
                                    break;
                                case 13:
                                    CauHoiTemp.A13 = drTemp["Content"].ToString();
                                    CauHoiTemp.M13 = iDapAnID1.ToString();
                                    break;
                                case 14:
                                    CauHoiTemp.A14 = drTemp["Content"].ToString();
                                    CauHoiTemp.M14 = iDapAnID1.ToString();
                                    break;
                                case 15:
                                    CauHoiTemp.A15 = drTemp["Content"].ToString();
                                    CauHoiTemp.M15 = iDapAnID1.ToString();
                                    break;
                                default: break;
                                    #endregion
                            }
                            l++;
                        }
                        break;
                    default: break;
                }
            }
            DapAnTemp.CauHoiID = iCauHoiTemp;
            DapAnTemp.Type = strTypeCauHoiTemp;
            float fDiemTemp = -1;
            CauHoiTemp.Mark = fDiemTemp;
            DapAnTemp.Mark = fDiemTemp;
            DapAnTemp.Match = strMatchTemp;
            return CauHoiTemp;
        }
        public DataRow[] GetDapAnFromCauHoiNotRandom(Guid CauHoiGID, DataTable Dt)
        {
            DataRow[] drTemp = Dt.Select(string.Format("CauHoiGID='{0}'", CauHoiGID), "Order asc");
            return drTemp;
        }
    }
}