using Nuce.CTSV.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Nuce.CTSV
{
    public partial class Login : Page
    {
        #region Google
        //your client id  
        string clientid = Utils.lwg_clientid;
        //your client secret  
        string clientsecret = Utils.lwg_clientsecret;
        //your redirection url  
        string redirection_url = Utils.lwg_redirection_url;
        string url = Utils.lwg_url;
        public class Tokenclass
        {
            public string access_token
            {
                get;
                set;
            }
            public string token_type
            {
                get;
                set;
            }
            public int expires_in
            {
                get;
                set;
            }
            public string refresh_token
            {
                get;
                set;
            }
        }
        public class Userclass
        {
            public string id
            {
                get;
                set;
            }
            public string name
            {
                get;
                set;
            }
            public string given_name
            {
                get;
                set;
            }
            public string family_name
            {
                get;
                set;
            }
            public string link
            {
                get;
                set;
            }
            public string picture
            {
                get;
                set;
            }
            public string gender
            {
                get;
                set;
            }
            public string locale
            {
                get;
                set;
            }
            public string email
            {
                get;
                set;
            }
        }
        public void GetToken(string code)
        {
            string poststring = "grant_type=authorization_code&code=" + code + "&client_id=" + clientid + "&client_secret=" + clientsecret + "&redirect_uri=" + redirection_url + "&scope=email profile";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            UTF8Encoding utfenc = new UTF8Encoding();
            byte[] bytes = utfenc.GetBytes(poststring);
            Stream outputstream = null;
            try
            {
                request.ContentLength = bytes.Length;
                outputstream = request.GetRequestStream();
                outputstream.Write(bytes, 0, bytes.Length);
            }
            catch { }
            var response = (HttpWebResponse)request.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            string responseFromServer = streamReader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Tokenclass obj = js.Deserialize<Tokenclass>(responseFromServer);
            GetuserProfile(obj.access_token);
        }
        public void GetuserProfile(string accesstoken)
        {
            string url = "https://www.googleapis.com/oauth2/v2/userinfo?alt=json&access_token=" + accesstoken + "";
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Userclass userinfo = js.Deserialize<Userclass>(responseFromServer);
            //txtMaDangNhap.Text = userinfo.email;
            //string strMaSV = txtMaDangNhap.Text.Trim();
            //string strSql = string.Format("SELECT * FROM [dbo].[AS_Academy_Student] where Code='{0}'", strMaSV);
            string strSql = string.Format("SELECT * FROM [dbo].[AS_Academy_Student] where EmailNhaTruong=@Param1 and DaXacThucEmailNhaTruong=1");

            strSql += string.Format(@"INSERT INTO [dbo].[AS_Logs]
           ([UserId]
           ,[UserCode]
           ,[Status]
           ,[Code]
           ,[Message]
           ,[CreatedTime])
     VALUES
           (-1
           ,'{0}'
           ,1
           ,'LOGIN'
           ,'{2}'
           ,'{1}') ;", userinfo.email, DateTime.Now, 3);

            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@Param1", userinfo.email);
            //sqlParams[0].ParameterName = "@Param1";
            //sqlParams[0].SqlDbType = SqlDbType.VarChar;
            //sqlParams[0].Value = strMaSV;
            DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strSql, sqlParams).Tables[0];
            if (dtData != null && dtData.Rows.Count > 0)
            {
                nuce.web.model.SinhVien SinhVien = new nuce.web.model.SinhVien();
                string strFullName = dtData.Rows[0]["FulName"].ToString();
                string[] strFullNames = strFullName.Split(new char[] { ' ' });
                SinhVien.Ho = strFullName;
                SinhVien.Ten = strFullNames[strFullNames.Length - 1];
                //SinhVien.TrangThai = int.Parse(dtData.Rows[0]["status"].ToString());
                SinhVien.SinhVienID = int.Parse(dtData.Rows[0]["ID"].ToString());
                SinhVien.Email = dtData.Rows[0].IsNull("EmailNhaTruong") ? "" : dtData.Rows[0]["EmailNhaTruong"].ToString();
                SinhVien.Mobile = dtData.Rows[0]["Mobile"].ToString();
                SinhVien.MaSV = dtData.Rows[0]["Code"].ToString();
                string File1 = dtData.Rows[0].IsNull("File1") ? "" : dtData.Rows[0]["File1"].ToString();
                if (!File1.Trim().Equals(""))
                {
                    SinhVien.IMG = File1;
                }
                else
                    SinhVien.IMG = "/Data/images/noimage_human.png";

                Session[Utils.session_sinhvien] = SinhVien;
                Response.Redirect("/DichVuSinhVien.aspx");
            }
            else
            {
                spAlert.InnerHtml = string.Format(@"<div class='alert alert-warning alert-dismissible' style='position: absolute; top: 0; right: 0;'>
                                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
            {0}</div>", "Không đúng tên đăng nhập");
            }

            //Kiem tra ho ten xem co trung khong sau do lay trong csdl

            //imgprofile.ImageUrl = userinfo.picture;
            //lblid.Text = userinfo.id;
            //lblgender.Text = userinfo.gender;
            //lbllocale.Text = userinfo.locale;
            //lblname.Text = userinfo.name;
            //hylprofile.NavigateUrl = userinfo.link;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //https://www.oauth.com/oauth2-servers/signing-in-with-google/verifying-the-user-info/
            //https://www.c-sharpcorner.com/Blogs/login-with-google-account-api-in-asp-net-and-get-google-plus-profile-details-in-c-sharp
            //747341024576-mud1ao0e5jij2dkm56sfu0i0fqv9ggc0.apps.googleusercontent.com
            //0TQze0o2lGXb4gUw77S2vw7l
            if (!IsPostBack)
            {
                if (Request.QueryString["code"] != null)
                {
                    GetToken(Request.QueryString["code"].ToString());
                }
            }
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string strMaSV = txtMaDangNhap.Text.Trim();
            string strMatKhau = txtMatKhau.Text.Trim();
            if (strMaSV == "" || strMatKhau == "")
            {
                spAlert.InnerHtml = string.Format(@"<div class='alert alert-warning alert-dismissible' style='position: absolute; top: 0; right: 0;'>
                                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
            {0}</div>", "Bạn không được để trắng tên đăng nhập hoặc mật khẩu");
                return;
            }

            //Kiểm tra đăng nhập
            Service sv = new Service();
            services_direct.Service sv_1 = new services_direct.Service();
            int iTypeDichVu = -1;
            try
            {
                if (sv.authen(strMaSV, strMatKhau) <= 0)
                {
                    spAlert.InnerHtml = string.Format(@"<div class='alert alert-warning alert-dismissible' style='position: absolute; top: 0; right: 0;'>
                                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
            {0}</div>", "Thông tin đăng nhập sai");
                    return;
                }
                iTypeDichVu = 1;
            }
            catch (Exception ex)
            {
                try
                {
                    if (sv_1.authen(strMaSV, strMatKhau) <= 0)
                    {
                        spAlert.InnerHtml = string.Format(@"<div class='alert alert-warning alert-dismissible' style='position: absolute; top: 0; right: 0;'>
                                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
            {0}</div>", "Thông tin đăng nhập sai");
                        return;
                    }
                    iTypeDichVu = 2;
                }
                catch (Exception ex1)
                {
                    iTypeDichVu = 999;
                }
            }
            //string strSql = string.Format("SELECT * FROM [dbo].[AS_Academy_Student] where Code='{0}'", strMaSV);
            string strSql = string.Format("SELECT * FROM [dbo].[AS_Academy_Student] where Code=@Param1 ;");
            strSql += string.Format(@"INSERT INTO [dbo].[AS_Logs]
           ([UserId]
           ,[UserCode]
           ,[Status]
           ,[Code]
           ,[Message]
           ,[CreatedTime])
     VALUES
           (-1
           ,'{0}'
           ,1
           ,'LOGIN'
           ,'{2}'
           ,'{1}') ;",strMaSV,DateTime.Now,iTypeDichVu);
            SqlParameter[] sqlParams = new SqlParameter[1];
            sqlParams[0] = new SqlParameter("@Param1", strMaSV);
            //sqlParams[0].ParameterName = "@Param1";
            //sqlParams[0].SqlDbType = SqlDbType.VarChar;
            //sqlParams[0].Value = strMaSV;
            DataTable dtData = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strSql, sqlParams).Tables[0];
            if (dtData != null && dtData.Rows.Count > 0)
            {
                nuce.web.model.SinhVien SinhVien = new nuce.web.model.SinhVien();
                string strFullName = dtData.Rows[0]["FulName"].ToString();
                string[] strFullNames = strFullName.Split(new char[] { ' ' });
                SinhVien.Ho = strFullName;
                SinhVien.Ten = strFullNames[strFullNames.Length - 1];
                //SinhVien.TrangThai = int.Parse(dtData.Rows[0]["status"].ToString());
                SinhVien.SinhVienID = int.Parse(dtData.Rows[0]["ID"].ToString());
                SinhVien.Email = dtData.Rows[0].IsNull("EmailNhaTruong") ? "" : dtData.Rows[0]["EmailNhaTruong"].ToString();
                SinhVien.Mobile = dtData.Rows[0]["Mobile"].ToString();
                SinhVien.MaSV = dtData.Rows[0]["Code"].ToString();
                string File1 = dtData.Rows[0].IsNull("File1") ? "" : dtData.Rows[0]["File1"].ToString();
                if (!File1.Trim().Equals(""))
                {
                    SinhVien.IMG = File1;
                }
                else
                    SinhVien.IMG = "/Data/images/noimage_human.png";
                Session[Utils.session_sinhvien] = SinhVien;
                Response.Redirect("/DichVuSinhVien.aspx");
            }
            else
            {
                spAlert.InnerHtml = string.Format(@"<div class='alert alert-warning alert-dismissible' style='position: absolute; top: 0; right: 0;'>
                                                <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a>
            {0}</div>", "Không tồn tại dữ liệu sinh viên");
            }
        }
    }
}