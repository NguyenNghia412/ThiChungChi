using System;
using System.Data;
using System.IO;

namespace nuce.web.phanhoi.le
{
    public partial class EditFeedBack : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string action = "";
                if (Request.QueryString["action"] == null)
                    Response.Redirect(string.Format("/phanhoi/le/default.aspx"));
                else
                    action = Request.QueryString["action"];
                if (!action.Equals("1"))
                    Response.Redirect(string.Format("/phanhoi/le/default.aspx"));
                else
                {
                    int iID = int.Parse(Request.QueryString["qa"]);
                    DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_QuestionDetailByID(iID);
                    int iStatus = int.Parse(dt.Rows[0]["Status"].ToString());
                    int islecturer = int.Parse(dt.Rows[0]["IsLecturer"].ToString());
                    if (iStatus >5 || iStatus<2)
                    {
                        Response.Redirect(string.Format("/phanhoi/le/default.aspx"));
                    }
                    else {
                        //Fill loai cau tra loi
                        //Cap nhat trang thai
                        if(islecturer<2)
                            nuce.web.data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsLecturer(iID, 2);
                        DataTable dtType = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_Type();
                        spType.InnerHtml = data.Nuce_DanhGiaGiangVien.getQA_Type(int.Parse(dt.Rows[0]["Type"].ToString()));
                        txtType.Text = dt.Rows[0]["Type"].ToString();
                        txtID.Text = iID.ToString();
                        //Lay du lieu cua cau hoi
                        
                        txtSinhVien.Text = string.Format("{0} Lớp {1} - {2} ", dt.Rows[0]["FulName"].ToString(), dt.Rows[0]["GroupCode"].ToString(), dt.Rows[0]["Name"].ToString());
                        spQuestion.InnerHtml = dt.Rows[0]["Question"].ToString();
                        txtAnswer.Text = dt.Rows[0]["Answare"].ToString();
                        txtLecClass.Text = dt.Rows[0]["LecturerClassRoomID"].ToString();
                        string strFile = dt.Rows[0].IsNull("Attachment") ? "" : dt.Rows[0]["Attachment"].ToString();
                        if (!strFile.Equals(""))
                            spFileDinhKem.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFile);
                        else
                            spFileDinhKem.InnerHtml = "Không có";
                        string strFileLec = dt.Rows[0].IsNull("Le_Attachment") ? "" : dt.Rows[0]["Le_Attachment"].ToString();
                        if (!strFileLec.Equals(""))
                            spFileDinhKemLec.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFileLec);
                        else
                            spFileDinhKemLec.InnerHtml = "Không có";
                    }
                }


            }
        }
        private void dangxuat()
        {
            Session.Abandon();
            Session.RemoveAll();
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_giangvien_qa] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/phanhoi/default.aspx"));
            }
            else
            {
                m_CanBo = (model.CanBo)Session[Utils.session_giangvien_qa];
                spLogin.InnerHtml = string.Format("<a href='/phanhoi/le/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>", m_CanBo.Ten);
                mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/le/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/le/default.aspx'>Home</option>
                              <option value='/phanhoi/le/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            }
            base.OnInit(e);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int iID = int.Parse(txtID.Text.Trim());
            string strAnswer = txtAnswer.Text;
            if (strAnswer.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Phản hồi không được để trắng";
            }
            else
            {
                string strJs = "";
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
                                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", Utils.RemoveUnicode(m_CanBo.Ten).Replace(" ", "_"),"", m_CanBo.MaCB, txtLecClass.Text, txtType.Text, Utils.RemoveUnicode(filename).Replace(" ", "_"));
                                string directoryPath = Server.MapPath("~/NuceDataUpload/" + m_CanBo.MaCB);
                                if (!System.IO.Directory.Exists(directoryPath))
                                    System.IO.Directory.CreateDirectory(directoryPath);

                                string path = Server.MapPath("~/NuceDataUpload/" + m_CanBo.MaCB + "/" + strTenMoi);
                                string strLinkFile = path;
                                FileInfo file = new FileInfo(path);
                                if (file.Exists)//check file exsit or not
                                {
                                    file.Delete();
                                }
                                FileUploadControl.SaveAs(strLinkFile);
                                strLinkFile = "/NuceDataUpload/" + m_CanBo.MaCB + "/" + strTenMoi;
                                data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsStudent(iID, 1);
                                data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_CanBo.ID, strAnswer, 4,strLinkFile);
                                strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Phản hồi thành công');location.href='/phanhoi/le/default.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text + "';";
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
                    data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_CanBo.ID, strAnswer, 4);
                    data.Nuce_DanhGiaGiangVien.UpdateQuestion_IsStudent(iID, 1);
                    strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Phản hồi thành công');location.href='/phanhoi/le/default.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/phanhoi/le/default.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text));
        }

        protected void btnArchive_Click(object sender, EventArgs e)
        {
            int iID = int.Parse(txtID.Text.Trim());
            string strAnswer = txtAnswer.Text;
            if (strAnswer.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Phản hồi không được để trắng";
            }
            else
            {
                string strJs = "";
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
                                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", Utils.RemoveUnicode(m_CanBo.Ten).Replace(" ", "_"), "", m_CanBo.MaCB, txtLecClass.Text, txtType.Text, Utils.RemoveUnicode(filename).Replace(" ", "_"));
                                string directoryPath = Server.MapPath("~/NuceDataUpload/" + m_CanBo.MaCB);
                                if (!System.IO.Directory.Exists(directoryPath))
                                    System.IO.Directory.CreateDirectory(directoryPath);

                                string path = Server.MapPath("~/NuceDataUpload/" + m_CanBo.MaCB + "/" + strTenMoi);
                                string strLinkFile = path;
                                FileInfo file = new FileInfo(path);
                                if (file.Exists)//check file exsit or not
                                {
                                    file.Delete();
                                }
                                FileUploadControl.SaveAs(strLinkFile);
                                strLinkFile = "/NuceDataUpload/" + m_CanBo.MaCB + "/" + strTenMoi;
                                data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_CanBo.ID, strAnswer, 3, strLinkFile);
                                strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Lưu phản hồi thành công');location.href='/phanhoi/le/default.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text + "';";
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
                    data.Nuce_DanhGiaGiangVien.UpdateQuestion(iID, m_CanBo.ID, strAnswer, 3);
                     strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Lưu phản hồi thành công');location.href='/phanhoi/le/default.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
            }
        }
    }
}