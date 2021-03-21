using Newtonsoft.Json;
using nuce.web.data;
using nuce.web.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using Thi_SV;

namespace nuce.web.sinhvien
{
    public partial class tcc_getDanhSachBaiThi : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string strData = "-1";
            try
            {
                #region KiThiLopHocSinhVien
                SinhVien sv = new SinhVien();
                sv = (SinhVien)Session[Utils.session_sinhvien];
                DataTable dtKiThiLopHocSinhVien = data.dnn_NuceThi_KiThi_LopHoc_SinhVien.getBySinhVien(sv.SinhVienID);

                Dictionary<int, KiThiLopHocSinhVien> KiThiLopHocSinhViens = new Dictionary<int, KiThiLopHocSinhVien>();

                if (dtKiThiLopHocSinhVien.Rows.Count > 0)
                {
                    int iLenghKiThiLopHocSinhVien = dtKiThiLopHocSinhVien.Rows.Count;
                    for (int i = 0; i < iLenghKiThiLopHocSinhVien; i++)
                    {
                        model.KiThiLopHocSinhVien KiThiLopHocSinhVien = new model.KiThiLopHocSinhVien();
                        KiThiLopHocSinhVien.BoDeID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["BoDeID"].ToString());
                        KiThiLopHocSinhVien.DeThiID = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["DeThiID"].ToString());
                        KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["KiThi_LopHoc_SinhVienID"].ToString());
                        KiThiLopHocSinhVien.Status = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["Status"].ToString());
                        KiThiLopHocSinhVien.StatusKiThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["StatusKiThi"].ToString());
                        KiThiLopHocSinhVien.TenBlockHoc = dtKiThiLopHocSinhVien.Rows[i]["PhongThi"].ToString();
                        KiThiLopHocSinhVien.TenKiThi = dtKiThiLopHocSinhVien.Rows[i]["TenKiThi"].ToString();
                        KiThiLopHocSinhVien.TenMonHoc = dtKiThiLopHocSinhVien.Rows[i]["TenMonHoc"].ToString();
                        KiThiLopHocSinhVien.NoiDungDeThi = dtKiThiLopHocSinhVien.Rows[i]["NoiDungDeThi"].ToString();
                        KiThiLopHocSinhVien.DapAn = dtKiThiLopHocSinhVien.Rows[i]["DapAn"].ToString();
                        KiThiLopHocSinhVien.Diem = float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString());
                        KiThiLopHocSinhVien.BaiLam = dtKiThiLopHocSinhVien.Rows[i]["BaiLam"].ToString();
                        KiThiLopHocSinhVien.TenBoDe = dtKiThiLopHocSinhVien.Rows[i]["TenBoDe"]?.ToString();
                        KiThiLopHocSinhVien.MaDe = dtKiThiLopHocSinhVien.Rows[i].IsNull("MaDe") ? "" : dtKiThiLopHocSinhVien.Rows[i]["MaDe"].ToString();
                        KiThiLopHocSinhVien.NgayGioBatDau = dtKiThiLopHocSinhVien.Rows[i].IsNull("NgayGioBatDau") ? DateTime.Now : DateTime.Parse(dtKiThiLopHocSinhVien.Rows[i]["NgayGioBatDau"].ToString());
                        if (KiThiLopHocSinhVien.Status.Equals(5) || KiThiLopHocSinhVien.Status.Equals(4))
                        {
                            KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianConLai"].ToString());
                            KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["ThoiGianThi"].ToString());
                            if (KiThiLopHocSinhVien.Status.Equals(4))
                                KiThiLopHocSinhVien.Mota = string.Format("<div style='text-align: center;font-weight: bold;font-size: 20px;color: red;padding-top: 20px;'>Bài thi được {0:N2} điểm</div>", float.Parse(dtKiThiLopHocSinhVien.Rows[i]["Diem"].ToString()));
                        }
                        else
                        {
                            KiThiLopHocSinhVien.TongThoiGianConLai = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["TongThoiGianConLai"].ToString());
                            KiThiLopHocSinhVien.TongThoiGianThi = int.Parse(dtKiThiLopHocSinhVien.Rows[i]["ThoiGianThi"].ToString());
                        }
                        KiThiLopHocSinhViens.Add(KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, KiThiLopHocSinhVien);
                    }
                    Session[Utils.session_kithi_lophoc_sinhvien] = KiThiLopHocSinhViens;
                }
                #endregion
                strData=JsonConvert.SerializeObject(KiThiLopHocSinhViens, Formatting.Indented);
            }
            catch (Exception ex)
            {
                strData = ex.Message;
            }
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.Write(strData);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}