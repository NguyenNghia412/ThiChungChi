using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace nuce.web
{
    public partial class Khao_sat_cuu_sinh_vien2016 : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Utils.session_kithi_lophoc_cuusinhvien] == null) || (m_KiThiLopHocSinhViens == null) || (m_KiThiLopHocSinhViens.Count == 0))
            {
                divContentCauHoi.InnerHtml = string.Format("Chưa có bài khảo sát");
            }
            else
            {
                // xay dung bai khao sat
                m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[m_KiThiLopHocSinhViens.ElementAt(0).Key];
               if( m_KiThiLopHocSinhVien.Status.Equals(3))
                    {
                    btnNopBai.Visible = false;
                    btnNopBai.Enabled = false;
                    divBody.InnerHtml= @"<div style='text - align: center;width: 268px;margin: 0 auto;color:red;'>
                            Cảm ơn anh/chị đã hoàn thành bài khảo sát !
                          </ div > ";
                }
               else
                {
                    btnNopBai.Visible = true;
                    btnNopBai.Enabled = true;


                    string strHtmlOut = @"<div><h5 class='h5_groupcauhoi'></h5>";
                    string strScript = string.Format("<script> var KiThi_LopHoc_SinhVienID={0};", m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien);
                    string strScriptLast = "";
                    #region bindbailam
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(m_KiThiLopHocSinhVien.NoiDungDeThi);
                    //List<model.DapAn> lsDapAns = JsonConvert.DeserializeObject<List<model.DapAn>>(KiThiLopHocSinhVien.DapAn);
                    string strAnswares = m_KiThiLopHocSinhVien.BaiLam;
                    List<model.DapAn> lsDapAns = new List<model.DapAn>();
                    List<model.DapAn> lsDapAnsText = new List<model.DapAn>();
                    string strRate = "";
                    string[] strAnswaresSplit = strAnswares.Split(new string[] { "#####$$$$$@@@@@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strAnswaresSplit.Length >= 3)
                    {
                        lsDapAns = Utils.convertListDapAnFromAnswares(strAnswaresSplit[0]);
                        lsDapAnsText = Utils.convertListDapAnFromAnswaresText(strAnswaresSplit[1]);
                        strRate = strAnswaresSplit[2];
                    }
                    string strChecked5 = "";
                    string strChecked4 = "";
                    string strChecked3 = "";
                    string strChecked2 = "";
                    string strChecked1 = "";
                    switch (strRate)
                    {
                        case "5":
                            strChecked5 = "checked";
                            strScript = strScript + "var m_index = '5';";
                            break;
                        case "4":
                            strChecked4 = "checked";
                            strScript = strScript + "var m_index = '4';";
                            break;
                        case "3":
                            strChecked3 = "checked";
                            strScript = strScript + "var m_index = '3';";
                            break;
                        case "2":
                            strChecked2 = "checked";
                            strScript = strScript + "var m_index = '2';";
                            break;
                        case "1":
                            strChecked1 = "checked";
                            strScript = strScript + "var m_index = '1';";
                            break;
                        default:
                            strScript = strScript + "var m_index = '0';";
                            break;
                    }

                    string strMatch = "";
                    if (lsDapAns != null)
                    {
                        //string strMatch = dapAn != null ? dapAn.Match : "";
                        foreach (model.DapAn dapAnTemp in lsDapAns)
                            strMatch += ";" + dapAnTemp.Match + ";";
                    }

                    // Chi so cau hoi
                    int l = 0;
                    int l1 = 0;
                    string strType;
                    int iSoCauTraLoi = -1;
                    string strIDMC = "";
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        l++;
                        strType = cauhoi.Type;
                        switch (strType)
                        {
                            #region cau hoi lua chon
                            case "SC":
                            case "MC":
                            case "TQ":
                            case "FQ":
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1}
                                            </span>
                                        </div>
                                        <div class='block-content'><ul>", l, HttpUtility.HtmlDecode(cauhoi.Content),cauhoi.CauHoiID);
                                iSoCauTraLoi = cauhoi.SoCauTraLoi;
                                l1 = 1;
                                while (l1 < (iSoCauTraLoi + 1))
                                {
                                    strIDMC = "";
                                    switch (l1)
                                    {
                                        case 1:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M1 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M1)))
                                            {
                                                strScript +=string.Format( "checkDapAnMC({0});", strIDMC);
                                                if(cauhoi.M1.Equals("4851"))
                                                {
                                                    strScriptLast= string.Format("checkDapAnMC({0});", strIDMC);
                                                }
                                            }
                                            strHtmlOut += string.Format(@"<li class='col-sm-6 col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                     <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </li>", l, HttpUtility.HtmlDecode(cauhoi.M1), HttpUtility.HtmlDecode(cauhoi.A1), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC);

                                            break;
                                        case 2:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M2 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M2)))
                                            {
                                                strScript += string.Format("checkDapAnMC({0});", strIDMC);
                                                if (cauhoi.M2.Equals("4851"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
                                            }
                                            strHtmlOut += string.Format(@"<li class='col-sm-6 col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                     <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </li>", l, HttpUtility.HtmlDecode(cauhoi.M2), HttpUtility.HtmlDecode(cauhoi.A2), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC);

                                            break;
                                        case 3:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M3 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M3)))
                                            {
                                                strScript += string.Format("checkDapAnMC({0});", strIDMC);
                                                if (cauhoi.M3.Equals("4851"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
                                            }
                                            strHtmlOut += string.Format(@"<li class='col-sm-6 col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                    <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </li>", l, HttpUtility.HtmlDecode(cauhoi.M3), HttpUtility.HtmlDecode(cauhoi.A3), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC);

                                            break;
                                        case 4:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M4 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M4)))
                                            {
                                                strScript += string.Format("checkDapAnMC({0});", strIDMC);
                                                if (cauhoi.M4.Equals("4851"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
                                            }
                                            strHtmlOut += string.Format(@"<li class='col-sm-6 col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                    <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </li>", l, HttpUtility.HtmlDecode(cauhoi.M4), HttpUtility.HtmlDecode(cauhoi.A4), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC);

                                            break;
                                    }
                                    l1++;
                                }
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </ul>
                                        </div>
                                    </div>");
                                break;
                            #endregion
                            #region cau hoi text
                            case "SA":
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1}
                                            </span>
                                        </div>
                                        <div class='block-content'><ul><div class='block - content'>
                                        <ul>
                                            <li class='col-xs-12 item'>
                                                <textarea id = 'txtCauHoi_{2}' onblur='luuBai();'></textarea>
                                            </li>
                                            <div class='clear'></div>
                                        </ul>
                                    </div>", l, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.CauHoiID);
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </ul>
                                        </div>
                                    </div>");

                                strScript += string.Format("$('#txtCauHoi_{0}').val('{1}');", cauhoi.CauHoiID, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                                break;
                            #endregion
                            #region cau hoi cam xuc
                            case "EQ":
                                strHtmlOut += string.Format(@"<div class='block'>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1}
                                            </span>
                                        </div>
                                        <div class='block-content'><ul><div class='block - content'>
                                         <ul>
                                            <li class='col - xs - 12 item'>
                                                <div class='rating_wrapper'>
                                                    <div class='rating'>
                                                        <input {3} id ='rating5' type='radio' name='rating' value='5'>
                                                        <label for='rating5' onclick='setRate(5,{2});'>5</label>
                                                        <input {4} id ='rating4' type='radio' name='rating' value='4'>
                                                        <label for='rating4' onclick='setRate(4,{2});'>4</label>
                                                        <input {5} id ='rating3' type='radio' name='rating' value='3'>
                                                        <label for='rating3' onclick='setRate(3,{2});'>3</label>
                                                        <input {6} id ='rating2' type='radio' name='rating' value='2'>
                                                        <label for='rating2' onclick='setRate(2,{2});'>2</label>
                                                        <input {7} id ='rating1' type='radio' name='rating' value='1'>
                                                        <label for='rating1' onclick='setRate(1,{2});'>1</label>
                                                    </div>
                                                </div>
                                            </li>
                                            <div class='clear'></div>
                                        </ul>
                                    </div>", l, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.CauHoiID, strChecked5, strChecked4, strChecked3, strChecked2, strChecked1);
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </ul>
                                        </div>
                                    </div>");
                                break;
                            #endregion
                            default: break;
                        }
                    }

                    #endregion

                    strHtmlOut += "</div>";
                    divContentCauHoi.InnerHtml = strHtmlOut;
                    strScript += strScriptLast;
                    strScript += "</script>";
                    divInitData.InnerHtml = strScript;

                }
   
            }
        }
        protected override void OnInit(EventArgs e)
        {
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_cuusinhvien] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/login_cuu_sinh_vien.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}
            
            m_SinhVien = (model.SinhVien)Session[Utils.session_cuusinhvien];
            spLogin.InnerHtml = string.Format("<a href='/login_cuu_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Đăng xuất</a>");
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/Default.aspx'>Lựa chọn</ option >
                              <option value='/Default.aspx'>Home</option>
                                             <option value='/khao_sat_cuu_sinh_vien_suathongtin.aspx'>Sửa thông tin</option>
                              <option value='/login_cuu_sinh_vien.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            if (Session[Utils.session_kithi_lophoc_cuusinhvien] != null)
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lophoc_cuusinhvien];
           
            base.OnInit(e);
        }

        protected void btnNopBai_Click(object sender, EventArgs e)
        {
            string strAnswares = txtAnswares.Text;
            //m_KiThiLopHocSinhVien.BaiLam = strAnswares;
            m_KiThiLopHocSinhVien.Status = 4;
            m_KiThiLopHocSinhVien.BaiLam = strAnswares;
            m_KiThiLopHocSinhViens[m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien] = m_KiThiLopHocSinhVien;

            // Cap nhat vao database
            data.dnn_Nuce_KS_SinhVienRaTruong_BaiKhaoSat_SinhVien1.update_bailam1(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.BaiLam, DateTime.Now,Utils.GetIPAddress(), m_KiThiLopHocSinhVien.Status);
            //data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.Status, m_KiThiLopHocSinhVien.BaiLam, m_KiThiLopHocSinhVien.Diem);

            Response.Redirect(Request.RawUrl);

        }

    }
}