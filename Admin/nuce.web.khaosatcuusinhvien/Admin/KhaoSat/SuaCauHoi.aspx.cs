using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace nuce.web.admin.KhaoSat
{
    public partial class SuaCauHoi : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["action"] == null)
                    quayLaiDanhSach();
                else
                {
                    string strAction = Request.QueryString["action"].ToString();
                    if (strAction.Equals("edit"))
                    {
                        txtAction.Text = "edit";
                        string strID = Request.QueryString["id"].ToString();
                        //Lấy dữ liệu của bang câu hỏi
                        string strSQL = string.Format(@"select * from AS_Edu_Survey_CauHoi where status<>4 and ID='{0}';", strID);
                        DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            txtID.Text = strID;
                            txtMa.Text = dt.Rows[0]["Ma"].ToString();
                            txtNoiDung.Text = HttpUtility.HtmlDecode(dt.Rows[0]["Content"].ToString());

                            txtLoaiCauHoi.Text = dt.Rows[0]["Type"].ToString();
                            txtThuTu.Text = dt.Rows[0]["Order"].ToString();
                        }
                        else
                        {
                            quayLaiDanhSach();
                        }
                        divThongBao.InnerHtml = "Chỉnh sửa thông tin câu hỏi";
                    }
                    else
                    {
                        divThongBao.InnerHtml = "Thêm mới thông tin câu hỏi";
                        txtAction.Text = "new";
                    }
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

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string strContent = HttpUtility.HtmlEncode(txtNoiDung.Text);
            string strLoaiCauHoi = txtLoaiCauHoi.Text;
            string strMa = txtMa.Text;
            string strOrder = txtThuTu.Text;
            string strAction = txtAction.Text;
            string strID = txtID.Text;
            string strSQL = "";
            SqlParameter[] sqlParams;
            if (strAction.Equals("new"))
            {
                // Thêm mới
                Guid G_CauHoi = Guid.NewGuid();
                strSQL = string.Format(@"
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
           (@Param0,@Param1,-1,1,@Param1,@Param2,@Param3,@Param3,{0},1,@Param4,1)
END;", strOrder);

                 sqlParams = new SqlParameter[5];
                sqlParams[0] = new SqlParameter("@Param0", G_CauHoi);
                sqlParams[1] = new SqlParameter("@Param1", strMa);
                sqlParams[2] = new SqlParameter("@Param2", strContent);
                sqlParams[3] = new SqlParameter("@Param3", DateTime.Now);
                sqlParams[4] = new SqlParameter("@Param4", strLoaiCauHoi);
                if (Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams) > 0)
                {
                    divThongBao.InnerHtml = "Thêm mới thành công";
                    quayLaiDanhSach();
                }
                else
                    divThongBao.InnerHtml = "Thêm mới thất bại";
            }
            else
            {
                //update
                strSQL = string.Format(@"
if(not exists(select 1 from AS_Edu_Survey_CauHoi where CauHoiID=@Param1 and ID!=@Param0))
Begin
UPDATE [dbo].[AS_Edu_Survey_CauHoi]
   SET 
        Ma=@Param5,
        CauHoiID=@Param1,
        Content=@Param2,
        UpdatedDate=@Param3,
        [Order]={0},
        Type=@Param4
where ID=@Param0 
END;", strOrder);

                sqlParams = new SqlParameter[6];
                sqlParams[0] = new SqlParameter("@Param0", txtID.Text);
                sqlParams[1] = new SqlParameter("@Param1", int.Parse(strMa));
                sqlParams[2] = new SqlParameter("@Param2", strContent);
                sqlParams[3] = new SqlParameter("@Param3", DateTime.Now);
                sqlParams[4] = new SqlParameter("@Param4", strLoaiCauHoi);
                sqlParams[5] = new SqlParameter("@Param5", strMa);
                if (Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(data.Nuce_Survey.ConnectionString, CommandType.Text, strSQL, sqlParams) > 0)
                {
                    divThongBao.InnerHtml = "câp nhật thành công";
                    quayLaiDanhSach();
                }
                else
                    divThongBao.InnerHtml = "cập nhật thất bại";
            }
        }

        protected void btnQuayLaiDanhSach_Click(object sender, EventArgs e)
        {
            quayLaiDanhSach();
        }
        private void quayLaiDanhSach()
        {
            Response.Redirect(string.Format("/admin/khaosat/danhsachcauhoi.aspx"));
        }
    }
}