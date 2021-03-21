using System;
using System.Data;
using System.IO;

namespace nuce.web.phanhoi.le
{
    public partial class EditMessage : System.Web.UI.Page
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
                    DataTable dt = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_MessageDetailByID(iID);
                    int iStatus = int.Parse(dt.Rows[0]["Status"].ToString());
                    int islecturer = int.Parse(dt.Rows[0]["IsLecturer"].ToString());
                    if (iStatus >3 )
                    {
                        Response.Redirect(string.Format("/phanhoi/le/default.aspx"));
                    }
                    else {
                        //Fill loai cau tra loi
                        DataTable dtClassRoomName = nuce.web.data.Nuce_DanhGiaGiangVien.getC_ClassRoomByLecturer(m_CanBo.ID);
                        if (dtClassRoomName.Rows.Count > 0)
                        {

                            ddlClassRoom.DataTextField = "ClassRoomName";
                            ddlClassRoom.DataValueField = "ID";
                            ddlClassRoom.DataSource = dtClassRoomName;
                            ddlClassRoom.DataBind();
                        }
                        else
                        {
                            spThongBao.InnerText = "Không có thông tin Lớp môn học";
                        }
                        txtID.Text = iID.ToString();
                        txtMessage.Text = dt.Rows[0]["Message"].ToString();
                        txtLecClass.Text = dt.Rows[0]["LecturerClassRoomID"].ToString();
                        ddlClassRoom.SelectedValue = dt.Rows[0]["ClassRoomID"].ToString();
                        string strFile = dt.Rows[0].IsNull("Attachment") ? "" : dt.Rows[0]["Attachment"].ToString();
                        if (!strFile.Equals(""))
                            spFileDinhKemLec.InnerHtml = string.Format("<a href='{0}'  target='_blank'>Chi tiết</a>", strFile);
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
            string strMessage= txtMessage.Text;
            int iClassRoomID = int.Parse(ddlClassRoom.SelectedValue);
            if (strMessage.Trim()=="")
            {
                spThongBao.InnerHtml = "Thông báo không được để trắng";
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
                                data.Nuce_DanhGiaGiangVien.UpdateMessage(iID, m_CanBo.ID,m_CanBo.MaCB, iClassRoomID, strMessage,strLinkFile);
                                strJs = "<script type=\"text/javascript\">";
                                strJs += "alert('Cập nhật thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
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
                    data.Nuce_DanhGiaGiangVien.UpdateMessage(iID, m_CanBo.ID, m_CanBo.MaCB, iClassRoomID,strMessage);
                    strJs = "<script type=\"text/javascript\">";
                    strJs += "alert('cập nhật thành công');location.href='/phanhoi/le/Message.aspx?ClassRoomID=" + iClassRoomID.ToString() + "';";
                    strJs += "</script>";
                    divScript.InnerHtml = strJs;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("/phanhoi/le/Message.aspx?id=" + txtLecClass.Text + "&&type=" + txtType.Text));
        }
    }
}