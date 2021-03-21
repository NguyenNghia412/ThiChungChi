using nuce.web.data;
using System;
using System.Data;
using System.Web.UI;

namespace Nuce.CTSV
{
    public partial class HoSoSinhVien : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "select * from AS_Academy_Student where Status<>4 and ID=" + m_SinhVien.SinhVienID;
                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.ConnectionString, CommandType.Text, sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    // Xử lý dữ liệu sinh viên
                    string Email = dt.Rows[0].IsNull("Email") ? "" : dt.Rows[0]["Email"].ToString();
                    string Mobile = dt.Rows[0].IsNull("Mobile") ? "" : dt.Rows[0]["Mobile"].ToString();
                    string NgaySinh = dt.Rows[0].IsNull("NgaySinh") ? "1/1/1900" : DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString()).ToString("dd/MM/yyyy");
                    string BirthPlace = dt.Rows[0].IsNull("BirthPlace") ? "" : dt.Rows[0]["BirthPlace"].ToString();
                    string DanToc = dt.Rows[0].IsNull("DanToc") ? "" : dt.Rows[0]["DanToc"].ToString();
                    string TonGiao = dt.Rows[0].IsNull("TonGiao") ? "" : dt.Rows[0]["TonGiao"].ToString();
                    string HKTT_SoNha = dt.Rows[0].IsNull("HKTT_SoNha") ? "" : dt.Rows[0]["HKTT_SoNha"].ToString();
                    string HKTT_Pho = dt.Rows[0].IsNull("HKTT_Pho") ? "" : dt.Rows[0]["HKTT_Pho"].ToString();
                    string HKTT_Phuong = dt.Rows[0].IsNull("HKTT_Phuong") ? "" : dt.Rows[0]["HKTT_Phuong"].ToString();
                    string HKTT_Quan = dt.Rows[0].IsNull("HKTT_Quan") ? "" : dt.Rows[0]["HKTT_Quan"].ToString();
                    string HKTT_Tinh = dt.Rows[0].IsNull("HKTT_Tinh") ? "" : dt.Rows[0]["HKTT_Tinh"].ToString();
                    string CMT = dt.Rows[0].IsNull("CMT") ? "" : dt.Rows[0]["CMT"].ToString();
                    string CMT_NoiCap = dt.Rows[0].IsNull("CMT_NoiCap") ? "" : dt.Rows[0]["CMT_NoiCap"].ToString();
                    string CMT_NgayCap = dt.Rows[0].IsNull("CMT_NgayCap") ? "1/1/1900" : DateTime.Parse(dt.Rows[0]["CMT_NgayCap"].ToString()).ToString("dd/MM/yyyy");
                    string NamTotNghiepPTTH = dt.Rows[0].IsNull("NamTotNghiepPTTH") ? "" : dt.Rows[0]["NamTotNghiepPTTH"].ToString();
                    string NgayVaoDoan = dt.Rows[0].IsNull("NgayVaoDoan") ? "1/1/1900" : DateTime.Parse(dt.Rows[0]["NgayVaoDoan"].ToString()).ToString("dd/MM/yyyy");
                    string NgayVaoDang = dt.Rows[0].IsNull("NgayVaoDang") ? "1/1/1900" : DateTime.Parse(dt.Rows[0]["NgayVaoDang"].ToString()).ToString("dd/MM/yyyy");
                    string DiemThiPTTH = dt.Rows[0].IsNull("DiemThiPTTH") ? "" : dt.Rows[0]["DiemThiPTTH"].ToString();
                    string KhuVucHKTT = dt.Rows[0].IsNull("KhuVucHKTT") ? "" : dt.Rows[0]["KhuVucHKTT"].ToString();
                    string DoiTuongUuTien = dt.Rows[0].IsNull("DoiTuongUuTien") ? "" : dt.Rows[0]["DoiTuongUuTien"].ToString();
                    bool DaTungLamCanBoLop = dt.Rows[0].IsNull("DaTungLamCanBoLop") ? false : bool.Parse(dt.Rows[0]["DaTungLamCanBoLop"].ToString());
                    bool DaTungLamCanBoDoan = dt.Rows[0].IsNull("DaTungLamCanBoLop") ? false : bool.Parse(dt.Rows[0]["DaTungLamCanBoDoan"].ToString());
                    bool DaThamGiaDoiTuyenThiHSG = dt.Rows[0].IsNull("DaThamGiaDoiTuyenThiHSG") ? false : bool.Parse(dt.Rows[0]["DaThamGiaDoiTuyenThiHSG"].ToString());
                    string BaoTin_DiaChi = dt.Rows[0].IsNull("BaoTin_DiaChi") ? "" : dt.Rows[0]["BaoTin_DiaChi"].ToString();
                    string BaoTin_HoVaTen = dt.Rows[0].IsNull("BaoTin_HoVaTen") ? "" : dt.Rows[0]["BaoTin_HoVaTen"].ToString();
                    string BaoTin_DiaChiNguoiNhan = dt.Rows[0].IsNull("BaoTin_DiaChiNguoiNhan") ? "" : dt.Rows[0]["BaoTin_DiaChiNguoiNhan"].ToString();
                    string BaoTin_SoDienThoai = dt.Rows[0].IsNull("BaoTin_SoDienThoai") ? "" : dt.Rows[0]["BaoTin_SoDienThoai"].ToString();
                    string BaoTin_Email = dt.Rows[0].IsNull("BaoTin_Email") ? "" : dt.Rows[0]["BaoTin_Email"].ToString();
                    bool LaNoiTru = dt.Rows[0].IsNull("LaNoiTru") ? false : bool.Parse(dt.Rows[0]["LaNoiTru"].ToString());
                    string DiaChiCuThe = dt.Rows[0].IsNull("DiaChiCuThe") ? "" : dt.Rows[0]["DiaChiCuThe"].ToString();

                    string File1 = dt.Rows[0].IsNull("File1") ? "" : dt.Rows[0]["File1"].ToString();
                    string File2 = dt.Rows[0].IsNull("File2") ? "" : dt.Rows[0]["File2"].ToString();

                    hovaten.InnerHtml = m_SinhVien.Ho.ToUpper();
                    masosv.InnerHtml = m_SinhVien.MaSV;
                    namsinh.InnerHtml = NgaySinh;
                    noisinh.InnerHtml = BirthPlace;
                    dantoc.InnerHtml = DanToc;
                    tongiao.InnerHtml = TonGiao;
                    hktt_sonha.InnerHtml = HKTT_SoNha;
                    hktt_phothon.InnerHtml = HKTT_Pho;
                    hktt_phuongxa.InnerHtml = HKTT_Phuong;
                    hktt_quanhuyen.InnerHtml = HKTT_Quan;
                    hktt_thanhpho.InnerHtml = HKTT_Tinh;
                    socmt.InnerHtml = CMT;
                    cmtngaycap.InnerHtml = CMT_NgayCap;
                    cmtnoicap.InnerHtml = CMT_NoiCap;
                    ngayvaodoan.InnerHtml = NgayVaoDoan;
                    ngayvaodang.InnerHtml = NgayVaoDang;
                    namtotnghiepthpt.InnerHtml = NamTotNghiepPTTH;
                    diemthithptqg.InnerHtml = DiemThiPTTH;
                    hktttkv.InnerHtml = KhuVucHKTT;
                    dtut.InnerHtml = DoiTuongUuTien;
                    datunglamcanbodoan.InnerHtml = DaTungLamCanBoDoan ? "Có" : "Không";
                    datunglamcanbolop.InnerHtml = DaTungLamCanBoLop ? "Có" : "Không";
                    dathamgiadoituyenthihsg.InnerHtml=DaThamGiaDoiTuyenThiHSG? "Có" : "Không";
                    //baotindiachi.InnerHtml = BaoTin_DiaChi;
                    baotindiachinguoinhan.InnerHtml = BaoTin_DiaChiNguoiNhan;
                    baotinhovaten.InnerHtml = BaoTin_HoVaTen;
                    baotinsodienthoainguoinhan.InnerHtml = BaoTin_SoDienThoai;
                    email.InnerHtml = Email;
                    mobile.InnerHtml = Mobile;
                    coonoitrukhong.InnerHtml= LaNoiTru ? "Có" : "Không";
                    diachicuthe.InnerHtml = DiaChiCuThe;
                    if (!File1.Trim().Equals(""))
                    {
                        imgAnh.Src = File1;
                    }
                    else
                        imgAnh.Src = "/Data/images/noimage.png";
                    sql = "select * from AS_Academy_Student_QuaTrinhHocTap where StudentID=" + m_SinhVien.SinhVienID +" order by Count";
                    DataTable dtQTHT = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.ConnectionString, CommandType.Text, sql).Tables[0];
                    if(dtQTHT.Rows.Count>0)
                    {
                        string strQTHT = "";
                        for(int i=0;i< dtQTHT.Rows.Count;i++)
                        {
                            strQTHT += "<tr>";
                            strQTHT += string.Format("<td>{0}</td><td>{1}</td>",dtQTHT.Rows[i]["ThoiGian"].ToString(), dtQTHT.Rows[i]["TenTruong"].ToString());
                            strQTHT += "</tr>";
                        }
                        tbQTHT.InnerHtml = strQTHT;
                    }

                    sql = "select * from AS_Academy_Student_ThiHSG where StudentID=" + m_SinhVien.SinhVienID + " order by Count";
                    DataTable dtThiHSG = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.ConnectionString, CommandType.Text, sql).Tables[0];
                    if (dtThiHSG.Rows.Count > 0)
                    {
                        string strThiHSG = "";
                        for (int i = 0; i < dtThiHSG.Rows.Count; i++)
                        {
                            strThiHSG += "<tr>";
                            strThiHSG += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td>", dtThiHSG.Rows[i]["CapThi"].ToString(), dtThiHSG.Rows[i]["MonThi"].ToString(), dtThiHSG.Rows[i]["DatGiai"].ToString());
                            strThiHSG += "</tr>";
                        }
                        tbthihsg.InnerHtml = strThiHSG;
                    }

                    sql = "select * from AS_Academy_Student_GiaDinh where StudentID=" + m_SinhVien.SinhVienID + " order by Count";
                    DataTable dtTTGD = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(Nuce_Common.ConnectionString, CommandType.Text, sql).Tables[0];
                    if (dtTTGD.Rows.Count > 0)
                    {
                        string strTTGD = "";
                        for (int i = 0; i < dtTTGD.Rows.Count; i++)
                        {
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Họ tên {0}:</td><td>{1}</td></tr>", dtTTGD.Rows[i]["MoiQuanHe"].ToString(), dtTTGD.Rows[i]["HoVaTen"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Năm sinh:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["NamSinh"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Quốc tịch:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["QuocTich"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Dân tộc:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["DanToc"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Tôn giáo:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["TonGiao"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Nghề nghiệp, chức vụ:</td><td>{0}, {1}</td></tr>", dtTTGD.Rows[i]["NgheNghiep"].ToString(), dtTTGD.Rows[i]["ChucVu"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Tôn giáo:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["TonGiao"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Nơi công tác:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["NoiCongTac"].ToString());
                            strTTGD += string.Format("<tr><td class='font-weight-bold'>Nơi ở hiện nay:</td><td>{0}</td></tr>", dtTTGD.Rows[i]["NoiOHienNay"].ToString());
                        }

                        tbttgd.InnerHtml = strTTGD;
                    }
                }
            }
        }
    }
}