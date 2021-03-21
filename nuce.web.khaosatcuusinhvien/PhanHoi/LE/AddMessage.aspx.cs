using System;
using System.Data;
using System.IO;

namespace nuce.web.phanhoi.le
{
    public partial class AddMessage : System.Web.UI.Page
    {
        public model.CanBo m_CanBo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getC_ClassRoomByLecturer(m_CanBo.ID);
                if (dt.Rows.Count > 0)
                {
                   
                    ddlClassRoom.DataTextField = "ClassRoomName";
                    ddlClassRoom.DataValueField = "ID";
                    ddlClassRoom.DataSource = dt;
                    ddlClassRoom.DataBind();
                }
                else
                {
                    spThongBao.InnerText = "Không có thông tin Lớp môn học";
                    btnUpdate.Visible = false;
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
            string strMessage = txtMessage.Text;
            int iClassRoomID = int.Parse(ddlClassRoom.SelectedValue);
            if (strMessage.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Thống báo không được để trắng";
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
                                data.Nuce_DanhGiaGiangVien.InsertMessage(m_CanBo.ID,m_CanBo.MaCB, iClassRoomID,1, strMessage, 2,strLinkFile);
                                strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Gửi thông báo thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
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
                    data.Nuce_DanhGiaGiangVien.InsertMessage(m_CanBo.ID, m_CanBo.MaCB, iClassRoomID, 1, strMessage,2);
                    strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Gửi thông báo thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/phanhoi/le/Message.aspx?ClassRoomID=" + ddlClassRoom.SelectedValue));
        }

        protected void btnArchive_Click(object sender, EventArgs e)
        {
            string strMessage = txtMessage.Text;
            int iClassRoomID = int.Parse(ddlClassRoom.SelectedValue);
            if (strMessage.Trim().Equals(""))
            {
                spThongBao.InnerHtml = "Thống báo không được để trắng";
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
                                data.Nuce_DanhGiaGiangVien.InsertMessage(m_CanBo.ID, m_CanBo.MaCB, iClassRoomID, 1, strMessage, 1, strLinkFile);
                                strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Lưu thông báo thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
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
                    data.Nuce_DanhGiaGiangVien.InsertMessage(m_CanBo.ID, m_CanBo.MaCB, iClassRoomID, 1, strMessage,1);
                    strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('Lưu thông báo thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
            }
        }
    }
}