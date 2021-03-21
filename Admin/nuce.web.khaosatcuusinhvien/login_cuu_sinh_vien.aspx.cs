using System;
using System.Collections.Generic;
using System.Data;

namespace nuce.web
{
    public partial class login_cuu_sinh_vien : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Request.QueryString["ctl"] != null)
            {
                if (Request.QueryString["ctl"].ToString().Equals("dangxuat"))
                {
                    dangxuat();
                    Response.Redirect(string.Format("/Default.aspx"));
                }
            }
            if (Session[Utils.session_cuusinhvien] != null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            }
            base.OnInit(e);
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            //spThongBao.InnerHtml = "Đã hết thời gian khảo sát online!";
            //return;
            string strTen = txtMaDangNhap.Text.Trim();
            string strMatKhau = txtMatKhau.Text.Trim();
            spThongBao.InnerHtml = "Đã hết thời gian khảo sát";
            if (strTen.Equals(""))
            {
                spThongBao.InnerHtml = "Không được để tên trắng";
                return;
            }
            if (strMatKhau.Equals(""))
            {
                spThongBao.InnerHtml = "Không được mật khẩu trắng";
                return;
            }
            DataTable dtData = data.dnn_Nuce_KS_SinhVienRaTruong_SinhVien1.checkLogin(strTen, strMatKhau);

            if (dtData.Rows.Count > 0)
            {
                model.SinhVien SinhVien = new model.SinhVien();
                SinhVien.Ho = "";
                SinhVien.Ten = dtData.Rows[0]["tensinhvien"].ToString();
                SinhVien.MaSV = dtData.Rows[0]["masv"].ToString();
                SinhVien.TrangThai = int.Parse(dtData.Rows[0]["status"].ToString());
                SinhVien.SinhVienID = int.Parse(dtData.Rows[0]["ID"].ToString());
                SinhVien.Email= dtData.Rows[0]["email"].ToString();
                SinhVien.Mobile = dtData.Rows[0]["mobile"].ToString();
                SinhVien.CMT = dtData.Rows[0]["mobile2"].ToString();
                Session[Utils.session_cuusinhvien] = SinhVien;

                DataTable dtKiThiLopHocSinhVien = data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.getBySv(SinhVien.SinhVienID);
                if (dtKiThiLopHocSinhVien.Rows.Count > 0)
                {
                    int iLenghKiThiLopHocSinhVien = dtKiThiLopHocSinhVien.Rows.Count;
                    Dictionary<int, model.KiThiLopHocSinhVien> KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
                    for (int i = 0; i < iLenghKiThiLopHocSinhVien; i++)
                    {
                        model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
                        KiThiLopHocSinhVien.BoDeID = -1;
                        KiThiLopHocSinhVien.DeThiID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["DeThiID"].ToString());
                        KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["SinhVienRaTruong_BaiKhaoSat_SinhVienID"].ToString());
                        KiThiLopHocSinhVien.Status = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                        KiThiLopHocSinhVien.LoaiKiThi = -1;
                        KiThiLopHocSinhVien.TenBlockHoc = "";
                        KiThiLopHocSinhVien.TenKiThi = "";
                        KiThiLopHocSinhVien.TenMonHoc = "";
                        KiThiLopHocSinhVien.NoiDungDeThi = dtKiThiLopHocSinhVien.Rows[i]["NoiDungDeThi"].ToString();
                        KiThiLopHocSinhVien.DapAn = "";
                        KiThiLopHocSinhVien.Diem = -1;
                        KiThiLopHocSinhVien.BaiLam = dtKiThiLopHocSinhVien.Rows[i]["BaiLam"].ToString();
                        KiThiLopHocSinhVien.MaDe = "";
                        KiThiLopHocSinhVien.NgayGioBatDau = dtKiThiLopHocSinhVien.Rows[i].IsNull("NgayGioBatDau") ? DateTime.Now : DateTime.Parse(dtKiThiLopHocSinhVien.Rows[i]["NgayGioBatDau"].ToString());
                        if (KiThiLopHocSinhVien.Status.Equals(5) || KiThiLopHocSinhVien.Status.Equals(4))
                        {
                            KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianConLai"].ToString());
                            KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianThi"].ToString());
                            /*
                            if (KiThiLopHocSinhVien.Status.Equals(4))
                                KiThiLopHocSinhVien.Mota = string.Format("<div style='width: 80%;text-align: center;font-weight: bold;font-size: 20px;color: red;padding-top: 20px;'>Bài thi được {0:N2} điểm</div>", float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString()));
                            //KiThiLopHocSinhVien.Mota = string.Format("Bài thi được {0:N2} điểm", float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString()));

                            // Đã thi xong, thông báo và thoát
                            spThongBao.InnerHtml = "Đăng nhập thành công";
                            divScript.InnerHtml = "<script>  $('#myModal').modal('show');</script>";
                            dangxuat();
                            return;
                            */
                        }
                        else
                        {
                            KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianThi"].ToString()) * 60;
                            KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianThi"].ToString());
                        }
                        KiThiLopHocSinhViens.Add(KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, KiThiLopHocSinhVien);
                    }
                    Session[Utils.session_kithi_lophoc_cuusinhvien] = KiThiLopHocSinhViens;
                }
           
                spThongBao.InnerHtml = "Đăng nhập thành công";
                Response.Redirect(string.Format("/Khao_sat_cuu_sinh_vien.aspx"));
            }
            else
                spThongBao.InnerHtml = "Đăng nhập thất bại";
        }
    }
}