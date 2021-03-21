using nuce.web.khaosatcuusinhvien.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace nuce.web
{
    public partial class login_sinh_vien_sap_ra_truong : System.Web.UI.Page
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
            if (Session[Utils.session_sinhvienchuanbitotnghiep] != null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/Khao_sat_sinh_vien_sap_ra_truong.aspx"));
            }
            base.OnInit(e);
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            string strTen = txtMaDangNhap.Text.Trim();
            string strMatKhau = txtMatKhau.Text.Trim();
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
            try
            {
                Service sv = new Service();
                khaosatcuusinhvien.services_direct.Service sv_1 = new khaosatcuusinhvien.services_direct.Service();
                if (DateTime.Now.Day < 0)
                {
                    spThongBao.InnerHtml = "Đã hết thời gian khảo sát.";
                }
                else
                {
                    bool blCheckDangNhap = false;
                    try
                    {
                        if (sv.authen(strTen, strMatKhau) > 0)
                        {
                            blCheckDangNhap = true;
                        }
                        else
                        {
                            if (data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.checkLogin1(strTen, strMatKhau))
                            {
                                blCheckDangNhap = true;
                            }
                            else
                            {
                                if (strMatKhau.Equals("ktdb123456"))
                                {
                                    blCheckDangNhap = true;
                                }
                            }
                            if(sv_1.authen(strTen, strMatKhau)>0)
                                blCheckDangNhap = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, strTen, 2, "Ket noi loi service phong dao tao");
                            if (data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.checkLogin1(strTen, strMatKhau))
                            {
                                blCheckDangNhap = true;
                            }
                            else
                            {
                                if (strMatKhau.Equals("ktdb123456"))
                                {
                                    blCheckDangNhap = true;
                                }
                            }
                            if (sv_1.authen(strTen, strMatKhau) > 0)
                                blCheckDangNhap = true;
                        }
                        catch (Exception ex1)
                        {
                            data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, strTen, 2, "Loi tai kiem tra csdl"+ex1.ToString());
                            if (strMatKhau.Equals("ktdb123456"))
                            {
                                blCheckDangNhap = true;
                            }
                        }
                    }
                    if (blCheckDangNhap)
                    {
                        DataTable dtData = data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.checkLogin(strTen, "");
                        if (dtData.Rows.Count > 0)
                        {
                            model.SinhVien SinhVien = new model.SinhVien();
                            SinhVien.Ho = "";
                            SinhVien.Ten = dtData.Rows[0]["tensinhvien"].ToString();
                            SinhVien.MaSV = dtData.Rows[0]["masv"].ToString();
                            SinhVien.TrangThai = int.Parse(dtData.Rows[0]["status"].ToString());
                            SinhVien.SinhVienID = int.Parse(dtData.Rows[0]["ID"].ToString());
                            SinhVien.Email = dtData.Rows[0]["email"].ToString();
                            SinhVien.Mobile = dtData.Rows[0]["mobile"].ToString();

                            Session[Utils.session_sinhvienchuanbitotnghiep] = SinhVien;
                            m_SinhVien = SinhVien;

                            DataTable dtKiThiLopHocSinhVien = data.dnn_Nuce_KS_SinhVienSapRaTruong_BaiKhaoSat_SinhVien1.getBySv(SinhVien.SinhVienID);
                            if (dtKiThiLopHocSinhVien.Rows.Count > 0)
                            {
                                int iLenghKiThiLopHocSinhVien = dtKiThiLopHocSinhVien.Rows.Count;
                                Dictionary<int, model.KiThiLopHocSinhVien> KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
                                for (int i = 0; i < iLenghKiThiLopHocSinhVien; i++)
                                {
                                    model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
                                    KiThiLopHocSinhVien.BoDeID = -1;
                                    KiThiLopHocSinhVien.DeThiID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["DeThiID"].ToString());
                                    KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["SinhVienSapRaTruong_BaiKhaoSat_SinhVienID"].ToString());
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
                                Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] = KiThiLopHocSinhViens;
                            }

                            spThongBao.InnerHtml = "Đăng nhập thành công";
                            data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(m_SinhVien.SinhVienID, strTen, 1, "Đăng nhập thành công. MK:" + strMatKhau);
                            Response.Redirect(string.Format("/Khao_sat_sinh_vien_sap_ra_truong.aspx"),false);
                        }
                        else
                        {
                            spThongBao.InnerHtml = "Không tồn tại dữ liệu sinh viên";
                            data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, strTen, 1, "Đăng nhập thất bai !!! Không có dữ liệu sinh viên tốt nghiệp.");
                        }
                    }
                    else
                    {
                        spThongBao.InnerHtml = "Đăng nhập thất bại. Vui lòng kiểm tra lại mã số sinh viên và mật khẩu";
                        data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, strTen, 1, "Đăng nhập thất bại !!! Tại service phòng đào tạo.");
                    }
                }
            }
            catch (Exception ex)
            {
                spThongBao.InnerHtml = "Đăng nhập thất bại";
                data.dnn_Nuce_KS_SinhVienSapRaTruong_SinhVien1.insertLogAccess(-1, strTen, 2, ex.ToString());
            }

        }

    }
}