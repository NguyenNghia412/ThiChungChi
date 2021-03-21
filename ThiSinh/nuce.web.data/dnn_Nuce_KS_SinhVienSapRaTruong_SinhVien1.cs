using System;
using System.Data;
using System.Data.SqlClient;

namespace nuce.web.data
{
    public static class dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1
    {
        public static DataTable get(int ID)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_get");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, ID).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable GetKetQuaKhaoSat()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_GetKetQuaKhaoSat");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataSet GetKetQuaKhaoSatExportTongHop()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_KetQuaKhaoSat_Export_TongHop");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql);

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable GetByKhoa(string MaKhoa)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_GetByKhoa");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, MaKhoa).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable GetKhoa()
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_GetKhoa");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable getByDotKhaoSat(int dotkhaosat, string masv)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_getByDotKhaoSat");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, dotkhaosat, masv).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static DataTable checkLogin(string masv, string psw)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_checkLogin");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, masv, psw).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static bool checkLogin1(string masv, string psw)
        {
            string psw1 = PasswordUtil.HashPassword(psw);
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return false;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"select 1 from [dbo].[dnn_Nuce_Eduweb_sv_pass] where [masv]='{0}' and [pass]='{1}' ",masv, psw1);
                    DataTable dt= Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection,  CommandType.Text, strSql).Tables[0];
                    if (dt.Rows.Count > 0)
                        return true;
                    else
                        return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static DataTable update(string masv, string email, string email1, string email2, string mobile, string mobile1, string mobile2, string addinfo1, string addinfo2)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return null;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_update_email");
                    return Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, strSql, masv, email, email1, email2, mobile, mobile1, mobile2, addinfo1, addinfo2).Tables[0];

                }
                catch
                {
                    return null;
                }
            }
        }
        public static int updateByChecksum(string checksum, string email, string email1, string email2, string mobile, string mobile1, string mobile2, string addinfo1, string addinfo2)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return -1;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_update_emailbychecksum");
                    return (int)Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, strSql, checksum, email, email1, email2, mobile, mobile1, mobile2, addinfo1, addinfo2);

                }
                catch
                {
                    return -1;
                }
            }
        }
        public static int authen_email(string masv, string key, int status)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return -1;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_authen_email");
                    return (int)Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, strSql, masv, key,status);

                }
                catch
                {
                    return -1;
                }
            }
        }

        public static void TinNhan_Insert(string Code, int SenderID, string StudentCode, string StudentName, string Receiver, string ReceiverEmail, string NoiDung
  , int Type, int UserID, string Title)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"INSERT INTO dnn_Nuce_KS_SinhVienSapRaTruong_TinNhan
           ([Code]
           ,[SenderID]
           ,[StudentCode]
           ,[StudentName]
           ,[receiver]
           ,[receiverEmail]
           ,[Content]
           ,[Type]
           ,[Status]
           ,[Deleted]
           ,[CreatedBy]
           ,[LastModifiedBy]
           ,[DeletedBy]
           ,[CreatedTime]
           ,[DeletedTime]
           ,[LastModifiedTime]
            ,[Title])
     VALUES
           (@Param0
           ,@Param1
           ,@Param2
           ,@Param3
           ,@Param4
           ,@Param5
           ,@Param6
           ,@Param7
           ,1
           ,0
           ,@Param8
           ,@Param8
           ,@Param8
           ,@Param9
           ,@Param9
           ,@Param9
            ,@Param10
            )");
                    SqlParameter[] sqlParams = new SqlParameter[11];
                    sqlParams[0] = new SqlParameter("@Param0", Code);
                    sqlParams[1] = new SqlParameter("@Param1", SenderID);
                    sqlParams[2] = new SqlParameter("@Param2", StudentCode);
                    sqlParams[3] = new SqlParameter("@Param3", StudentName);
                    sqlParams[4] = new SqlParameter("@Param4", Receiver);
                    sqlParams[5] = new SqlParameter("@Param5", ReceiverEmail);
                    sqlParams[6] = new SqlParameter("@Param6", NoiDung);
                    sqlParams[7] = new SqlParameter("@Param7", Type);
                    sqlParams[8] = new SqlParameter("@Param8", UserID);
                    sqlParams[9] = new SqlParameter("@Param9", DateTime.Now);
                    sqlParams[10] = new SqlParameter("@Param10", Title);
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(objConnection, CommandType.Text, strSql, sqlParams);
                    return;
                }
                catch
                {
                    return;
                }
            }

        }

        public static void insertLogAccess(int UId, string UCode, int status,string strMessage)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return ;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_LogAccess_insert");
                     Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(objConnection, strSql, UId, UCode, status,strMessage);

                }
                catch
                {
                    return ;
                }
            }
        }
        public static int insert(
string @dottotnghiep,
string @sovaoso,
string @masv,
string @noisiti,
string @tbcht,
string @xeploai,
string @soqdtn,
string @sohieuba,
string @tinh,
string @truong,
string @gioitinh,
string @ngaysinh,
string @tkhau,
string @lop12,
string @namtn,
string @sobaodanh,
string @tcong,
string @ghichu_thi,
string @lopqd,
string @k,
string @dtoc,
string @quoctich,
string @bangclc,
string @manganh,
string @tenchnga,
string @tennganh,
string @hedaotao,
string @khoahoc,
string @tensinhvien,
string @email,
string @email1,
string @email2,
string @mobile,
string @mobile1,
string @mobile2,
string @thongtinthem,
string @thongtinthem1,
int @dotkhoasat_id,
string @psw,
string @checksum, 
string @ex_masv,
int @type,
int @status,
string maKhoa,
string maLop
)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return -1;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_insert");
                    return (int)Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, strSql,
                @dottotnghiep,
@sovaoso,
@masv,
@noisiti,
@tbcht,
@xeploai,
@soqdtn,
@sohieuba,
@tinh,
@truong,
@gioitinh,
@ngaysinh,
@tkhau,
@lop12,
@namtn,
@sobaodanh,
@tcong,
@ghichu_thi,
@lopqd,
@k,
@dtoc,
@quoctich,
@bangclc,
@manganh,
@tenchnga,
@tennganh,
@hedaotao,
@khoahoc,
@tensinhvien,
@email,
@email1,
@email2,
@mobile,
@mobile1,
@mobile2,
@thongtinthem,
@thongtinthem1,
@dotkhoasat_id, @psw, @checksum, @ex_masv,
@type, @status,maKhoa,maLop
                );

                }
                catch(Exception ex)
                {
                    return -1;
                }
            }
        }

        public static int insert1(
string @dottotnghiep,
string @sovaoso,
string @masv,
string @noisiti,
string @tbcht,
string @xeploai,
string @soqdtn,
string @sohieuba,
string @tinh,
string @truong,
string @gioitinh,
string @ngaysinh,
string @tkhau,
string @lop12,
string @namtn,
string @sobaodanh,
string @tcong,
string @ghichu_thi,
string @lopqd,
string @k,
string @dtoc,
string @quoctich,
string @bangclc,
string @manganh,
string @tenchnga,
string @tennganh,
string @hedaotao,
string @khoahoc,
string @tensinhvien,
string @email,
string @email1,
string @email2,
string @mobile,
string @mobile1,
string @mobile2,
string @thongtinthem,
string @thongtinthem1,
int @dotkhoasat_id,
string @psw,
string @checksum,
string @ex_masv,
int @type,
int @status,
string maKhoa,
string maLop
)
        {
            using (SqlConnection objConnection = Nuce_Common.GetConnection())
            {
                if (objConnection == null)
                    return -1;
                try
                {
                    //Execute select command
                    string strSql = string.Format(@"dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien_insert1");
                    return (int)Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteScalar(objConnection, strSql,
                @dottotnghiep,
@sovaoso,
@masv,
@noisiti,
@tbcht,
@xeploai,
@soqdtn,
@sohieuba,
@tinh,
@truong,
@gioitinh,
@ngaysinh,
@tkhau,
@lop12,
@namtn,
@sobaodanh,
@tcong,
@ghichu_thi,
@lopqd,
@k,
@dtoc,
@quoctich,
@bangclc,
@manganh,
@tenchnga,
@tennganh,
@hedaotao,
@khoahoc,
@tensinhvien,
@email,
@email1,
@email2,
@mobile,
@mobile1,
@mobile2,
@thongtinthem,
@thongtinthem1,
@dotkhoasat_id, @psw, @checksum, @ex_masv,
@type, @status, maKhoa, maLop
                );

                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
        }
    }
}
