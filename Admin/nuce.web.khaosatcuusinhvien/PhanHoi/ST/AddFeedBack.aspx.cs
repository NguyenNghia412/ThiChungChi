using System;
using System.Data;
using System.IO;

namespace nuce.web.phanhoi.st
{
    public partial class AddFeedBack : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtCNameLecturer = data.Nuce_DanhGiaGiangVien.getCNameLecturerByStudentCode(m_SinhVien.MaSV);
                if (dtCNameLecturer.Rows.Count > 0)
                {
                    ddlGiangVien.DataTextField = "Name";
                    ddlGiangVien.DataValueField = "ID";
                    ddlGiangVien.DataSource = dtCNameLecturer;
                    ddlGiangVien.DataBind();
                    bindType(int.Parse(dtCNameLecturer.Rows[0]["ID"].ToString()));
                }
                else
                {
                    spThongBao.InnerText = "Không có thông tin giảng viên";
                    btnUpdate.Visible = false;
                }
            }
        }
        private void bindType(int Lecturer_ClassRoom)
        {
            DataTable dtType = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_TypeByLecturClass(Lecturer_ClassRoom);
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "ID";
            ddlType.DataSource = dtType;
            ddlType.DataBind();
        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_sinhvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}

            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_qa];
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_SinhVien.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int iLecturerClassRoomID = int.Parse(ddlGiangVien.SelectedValue);
            int iType = int.Parse(ddlType.SelectedValue);
            string strQuestion = txtQuestion.Text;
            if (strQuestion.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Nội dung phản hồi không được để trắng";
            }
            else
            {
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        string strFileGioiHan = "application/pdf;application/x-pdf;";
                        if (strFileGioiHan.Contains(FileUploadControl.PostedFile.ContentType))
                        {
                            if (FileUploadControl.PostedFile.ContentLength > 5000)
                            {
                                string strMoRongFile = Path.GetExtension(FileUploadControl.FileName);
                                string filename = Path.GetFileName(FileUploadControl.FileName);
                                string strTenCu = filename;
                                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", Utils.RemoveUnicode(m_SinhVien.Ten).Replace(" ", "_"), Utils.RemoveUnicode(m_SinhVien.Ho).Replace(" ", "_"), m_SinhVien.MaSV, iLecturerClassRoomID, iType, Utils.RemoveUnicode(filename).Replace(" ", "_"));
                                string directoryPath = Server.MapPath("~/NuceDataUpload/" + m_SinhVien.MaSV);
                                if (!System.IO.Directory.Exists(directoryPath))
                                    System.IO.Directory.CreateDirectory(directoryPath);

                                string path = Server.MapPath("~/NuceDataUpload/" + m_SinhVien.MaSV + "/" + strTenMoi);
                                string strLinkFile = path;
                                FileInfo file = new FileInfo(path);
                                if (file.Exists)//check file exsit or not
                                {
                                    file.Delete();
                                }
                                FileUploadControl.SaveAs(strLinkFile);
                                strLinkFile = "/NuceDataUpload/" + m_SinhVien.MaSV + "/" + strTenMoi;
                                data.Nuce_DanhGiaGiangVien.InsertQuestion(m_SinhVien.SinhVienID, m_SinhVien.MaSV, iLecturerClassRoomID, iType, strQuestion,2, strLinkFile);
                                string strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Gửi phản hồi thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecturerClassRoomID.ToString() + "&&type=" + iType.ToString() + "';";
                                strJs += "</script>";
                                divScript.InnerHtml = strJs;
                            }
                            else
                            {
                                spThongBao.InnerHtml = "File đính kèm không được Vượt quá 5MB";
                            }
                        }
                        else
                        {
                            spThongBao.InnerHtml = "File đính kèm phải là file pdf";
                        }
                    }
                    catch (Exception ex)
                    {
                        spThongBao.InnerHtml = ex.ToString();
                    }
                }
                else
                {
                    data.Nuce_DanhGiaGiangVien.InsertQuestion(m_SinhVien.SinhVienID, m_SinhVien.MaSV, iLecturerClassRoomID, iType, strQuestion, 2, "");
                    string strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Gửi phản hồi thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecturerClassRoomID.ToString() + "&&type=" + iType.ToString() + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
       
            }
        }
        protected void btnArchive_Click(object sender, EventArgs e)
        {
            spThongBao.InnerText = "";
            int iLecturerClassRoomID = int.Parse(ddlGiangVien.SelectedValue);
            int iType = int.Parse(ddlType.SelectedValue);
            string strQuestion = txtQuestion.Text;
            if (strQuestion.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Nội dung phản hồi không được để trắng";
            }
            else
            {
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        string strFileGioiHan = "application/pdf;application/x-pdf;";
                        if (strFileGioiHan.Contains(FileUploadControl.PostedFile.ContentType))
                        {
                            if (FileUploadControl.PostedFile.ContentLength > 5000)
                            {
                                string strMoRongFile = Path.GetExtension(FileUploadControl.FileName);
                                string filename = Path.GetFileName(FileUploadControl.FileName);
                                string strTenCu = filename;
                                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", Utils.RemoveUnicode(m_SinhVien.Ten).Replace(" ", "_"), Utils.RemoveUnicode(m_SinhVien.Ho).Replace(" ", "_"), m_SinhVien.MaSV, iLecturerClassRoomID, iType, Utils.RemoveUnicode(filename).Replace(" ", "_"));
                                string directoryPath = Server.MapPath("~/NuceDataUpload/" + m_SinhVien.MaSV);
                                if (!System.IO.Directory.Exists(directoryPath))
                                    System.IO.Directory.CreateDirectory(directoryPath);

                                string path = Server.MapPath("~/NuceDataUpload/" + m_SinhVien.MaSV + "/" + strTenMoi);
                                string strLinkFile = path;
                                FileInfo file = new FileInfo(path);
                                if (file.Exists)//check file exsit or not
                                {
                                    file.Delete();
                                }
                                FileUploadControl.SaveAs(strLinkFile);
                                strLinkFile = "/NuceDataUpload/" + m_SinhVien.MaSV + "/" + strTenMoi;
                                data.Nuce_DanhGiaGiangVien.InsertQuestion(m_SinhVien.SinhVienID, m_SinhVien.MaSV, iLecturerClassRoomID, iType, strQuestion, 1, strLinkFile);
                                string strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Lưu tạm phản hồi thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecturerClassRoomID.ToString() + "&&type=" + iType.ToString() + "';";
                                strJs += "</script>";
                                divScript.InnerHtml = strJs;
                            }
                            else
                            {
                                spThongBao.InnerHtml = "File đính kèm không được Vượt quá 5MB";
                            }
                        }
                        else
                        {
                            spThongBao.InnerHtml = "File đính kèm phải là file pdf";
                        }
                    }
                    catch (Exception ex)
                    {
                        spThongBao.InnerHtml = ex.ToString();
                    }
                }
                else
                {
                    data.Nuce_DanhGiaGiangVien.InsertQuestion(m_SinhVien.SinhVienID, m_SinhVien.MaSV, iLecturerClassRoomID, iType, strQuestion, 1, "");
                    string strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Lưu tạm phản hồi thành công');location.href='/phanhoi/st/default.aspx?id=" + iLecturerClassRoomID.ToString() + "&&type=" + iType.ToString() + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }

            }
        }

        protected void ddlGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}