using System;
using System.Data;

namespace nuce.web.phanhoi.st
{
    public partial class Message : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Lay du lieu cua message
                DataTable dtMessage = nuce.web.data.Nuce_DanhGiaGiangVien.getQA_MessageByStudent1(m_SinhVien.SinhVienID);
                if (dtMessage != null)
                    bindata(dtMessage);
            }
        }
        private void bindata(DataTable dt)
        {
            DateTime dtNgayHoi, dtNgayCapNhat;
            string strHTMl = "";
            string strMessage;
            string strAction = "";
            int iQAID = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                iQAID = int.Parse(dt.Rows[i]["ID"].ToString());
                dtNgayHoi = DateTime.Parse(dt.Rows[i]["CreatedTime"].ToString());
                dtNgayCapNhat = DateTime.Parse(dt.Rows[i]["UpdatedTime"].ToString());
                strMessage = dt.Rows[i]["Message"].ToString();
                strHTMl += string.Format("<td>{0}</td>", i + 1);
                strHTMl += string.Format("<td style='text-align: left;'>{0} <p style='color:blue;'>{1}</p></td>", strMessage.Length > 100 ? strMessage.Substring(0, 100) : strMessage, dtNgayCapNhat.ToString("dd/MM/yyyy"));
                strAction = string.Format("<a href='/phanhoi/St/ViewMessage.aspx?action=1&&qa={0}'>Xem chi tiết</a>", iQAID);
                strHTMl += string.Format("<td>{0}</td>", strAction);
                strHTMl += "</tr>";
            }
            tbContent.InnerHtml = strHTMl;
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
            spLogin.InnerHtml = string.Format("<a href='/phanhoi/st/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - Đăng xuất</a>",m_SinhVien.Ten);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/phanhoi/st/default.aspx'>Lựa chọn</ option >
                              <option value='/phanhoi/st/default.aspx'>Home</option>
                              <option value='/phanhoi/st/AddFeedBack.aspx'>Tạo mới phản hồi</option>
                              <option value='/phanhoi/st/login.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";

            base.OnInit(e);
        }
    }
}