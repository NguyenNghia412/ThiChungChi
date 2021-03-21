using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace nuce.web
{
    public partial class Khao_sat_sinh_vien : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu không có
            int id=-1;
            if(Request.QueryString["id"]==null||!int.TryParse(Request.QueryString["id"],out id))
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx"));
            }
            // đã có bài khảo sát
            m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[id];
            if ((Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien] == null) || (m_KiThiLopHocSinhViens == null) || (m_KiThiLopHocSinhViens.Count == 0)|| m_KiThiLopHocSinhVien==null)
            {
                divContentCauHoi.InnerHtml = string.Format("Chưa có bài khảo sát");
            }
            else
            {
                #region thong tin chung
                tdNamHoc.InnerHtml = "2019-2020";
                tdHocKi.InnerHtml = "Kì II";
                tdLopMonHoc.InnerHtml = m_KiThiLopHocSinhVien.ClassRoomCode.Replace(m_KiThiLopHocSinhVien.SubjectCode,"");
                tdTenGiangVien.InnerHtml = m_KiThiLopHocSinhVien.LecturerName;
                tdHoTenSinhVien.InnerHtml = string.Format("{0} {1}({2})", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
                #endregion
                #region xay dung bai khao sát
                // xay dung bai khao sat
                if ( m_KiThiLopHocSinhVien.Status.Equals(4))
                    {
                    btnNopBai.Visible = false;
                    btnNopBai.Enabled = false;
                    divBody.InnerHtml= @"<div style='text - align: center;width: 329px;margin: 0 auto;color:red;'>
                            Anh/chị đã hoàn thành bài khảo sát</br>
                            Trân trọng cảm ơn !</a>
                          </div> ";
                }
               else
                {
                    if(m_KiThiLopHocSinhVien.DeThiID.Equals(4))
                    {
                        Response.Redirect(string.Format("/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx"));
                    }
                    btnNopBai.Visible = true;
                    btnNopBai.Enabled = true;
                    string strHtmlOut = "<div>";
                    string strScript = string.Format("<script> var KiThi_LopHoc_SinhVienID={0};var BaiKhaoSatID={1};", m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.DeThiID);
                    string strScriptLast = "";
                    #region bindbailam
                    // Lay noi dung bai thi
                    string strNoiDungBaiThi = nuce.web.data.Nuce_Survey.getEdu_Survey_BaiKhaoSat_GetNoiDungDeThi(m_KiThiLopHocSinhVien.DeThiID);
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(strNoiDungBaiThi);
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
                    #region Danh Gia sao
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
                    #endregion
                    string strMatch = "";
                    if (lsDapAns != null)
                    {
                        foreach (model.DapAn dapAnTemp in lsDapAns)
                            strMatch += ";" + dapAnTemp.Match + ";";
                    }

                    // Chi so cau hoi
                    int l = 0;
                    int l1 = 0;
                    int l2 = 0;
                    string nIndex = "";
                    string strType;
                    int iSoCauTraLoi = -1;
                    string strIDMC = "";
                    string strSoCot = "2";
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        strType = cauhoi.Type;
                        switch (strType)
                        {
                            #region cau hoi ao
                            case "GQ":
                                //strHtmlOut += string.Format(@"<div><h5 style='font-weight:bold;padding-left:3px;'>{0} {1}</h5>", UtilsDisplayDe.getStringIndexLaMa(l2), UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)));
                                switch(cauhoi.DoKhoID)
                                {
                                    case 1:
                                        strHtmlOut += string.Format(@"<h4 class='H3_CAPTION' style='text-align: left; font-weight: normal; padding-left: 3px; '><b>III. Ý KIẾN KHÁC</b></h4>");
                                        break;
                                    case 2:
                                        strHtmlOut += string.Format(@"<h5 style='font-weight:bold;padding-left:3px;color:red;'>{0}</h5>", UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)));
                                        break;
                                    case 3:
                                        l++;
                                        l2 = 1;
                                        
                                        strHtmlOut += string.Format(@"<div class='block'><div class='block-title'>
                                            <span class='question-title' style='color: blue;'>{0}: {1}
                                            </span>
                                        </div></div>", l, UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)));
                                        break;
                                }
                                break;
                            #endregion
                            #region cau hoi lua chon
                            case "SC":
                            case "TQ":
                            case "FQ":
                                l++;
                                strSoCot = "2";
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>{0}: {1} <span style='color:red;'>(*)</span>
                                            </span> 
                                        </div>
                                        <div class='block-content'><div class='row' style='padding-left: 10px;'>", l, UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content).Replace("giời","giới")),cauhoi.CauHoiID);
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
                                                strScript +=string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                     <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M1), HttpUtility.HtmlDecode(cauhoi.A1), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                        case 2:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M2 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M2)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                     <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M2), HttpUtility.HtmlDecode(cauhoi.A2), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC,strSoCot);

                                            break;
                                        case 3:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M3 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M3)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                    <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M3), HttpUtility.HtmlDecode(cauhoi.A3), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC,strSoCot);

                                            break;
                                        case 4:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M4 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M4)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                    <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M4), HttpUtility.HtmlDecode(cauhoi.A4), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC,strSoCot);

                                            break;
                                        case 5:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M5 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M5)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'radio' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC({5});'>
                                                    <label onclick='checkDapAnMC({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M5), HttpUtility.HtmlDecode(cauhoi.A5), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC,strSoCot);

                                            break;
                                    }
                                    l1++;
                                }
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </div>
                                        </div>
                                    </div>");
                                break;
                            #endregion
                            #region Cau hoi nhieu lua chon
                            case "MC":
                                l++;
                                strSoCot = "12";
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>{0}: {1} <span style='color:red;'>(*)</span>
                                            </span> 
                                        </div>
                                        <div class='block-content'><div class='row' style='padding-left: 10px;'>", l, UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)), cauhoi.CauHoiID);
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
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M1), HttpUtility.HtmlDecode(cauhoi.A1), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                        case 2:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M2 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M2)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M2), HttpUtility.HtmlDecode(cauhoi.A2), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                        case 3:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M3 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M3)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                    <label onclick='checkDapAnMC1({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M3), HttpUtility.HtmlDecode(cauhoi.A3), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                        case 4:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M4 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M4)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                    <label onclick='checkDapAnMC1({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M4), HttpUtility.HtmlDecode(cauhoi.A4), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                        case 5:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M5 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M5)))
                                            {
                                                strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                            }
                                            strHtmlOut += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                    <label onclick='checkDapAnMC1({5});'>
                                                        {2}
                                                    </label>
                                                </div>", l, HttpUtility.HtmlDecode(cauhoi.M5), HttpUtility.HtmlDecode(cauhoi.A5), cauhoi.CauHoiID, strType.Equals("MC") ? l * 20 + l1 : l * 20, strIDMC, strSoCot);

                                            break;
                                    }
                                    l1++;
                                }
                                strHtmlOut += string.Format(@"<div class='col-sm-{0} col-xs-12 item'>
                                                    <textarea id = 'txtCauHoi_{1}' onblur='luuBai();'></textarea>
                                                </div>", strSoCot, cauhoi.CauHoiID);
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </div>
                                        </div>
                                    </div>");
                                strScript += string.Format("$('#txtCauHoi_{0}').val('{1}');", cauhoi.CauHoiID, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                                break;
                            #endregion
                            #region cau hoi text
                            case "SA":
                                if (l2.Equals(0))
                                { l++; nIndex = l.ToString(); }
                                else
                                {
                                    nIndex = string.Format("{0}.{1}", l, l2);
                                    l2++;
                                }
                                
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>{0}: {1}
                                            </span>
                                        </div>
                                        <div class='block-content'><ul><div class='block - content'>
                                        <ul>
                                            <li class='col-xs-12 item'>
                                                <textarea id = 'txtCauHoi_{2}' onblur='luuBai();'></textarea>
                                            </li>
                                            <div class='clear'></div>
                                        </ul>
                                    </div>", nIndex, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.CauHoiID);
                                strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </ul>
                                        </div>
                                    </div>");

                                strScript += string.Format("$('#txtCauHoi_{0}').val('{1}');", cauhoi.CauHoiID, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                                break;
                            #endregion
                            #region cau hoi cam xuc
                            case "EQ":
                                l++;
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
                #endregion
            }
        }
        protected override void OnInit(EventArgs e)
        {
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_sinhvien_khaosatdanhgiagiangvien] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/KSHDGD/login_sinh_vien.aspx"));
            }
            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvien_khaosatdanhgiagiangvien];
            spLogin.InnerHtml = string.Format("<a href='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - {1} ({2}) - Đăng xuất</a>", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
            //spLogin.InnerHtml = string.Format("<a href='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Đăng xuất</a>");
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx'>Lựa chọn</ option >
                              <option value='/KSHDGD/danhSach_BaiKhaoSat_SinhVien.aspx'>Home</option>
                              <option value='/KSHDGD/login_sinh_vien.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            if (Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien] != null)
            {
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lop_hoc_sinhvien_khaosatdanhgiagiangvien];
            }
            base.OnInit(e);
        }
        protected void btnNopBai_Click(object sender, EventArgs e)
        {
            string strAnswares = txtAnswares.Text;
            m_KiThiLopHocSinhVien.Status = 4;
            m_KiThiLopHocSinhVien.BaiLam = strAnswares;
            m_KiThiLopHocSinhViens[m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien] = m_KiThiLopHocSinhVien;

            // Cap nhat vao database
            data.Nuce_Survey.Edu_Survey_BaiKhaoSat_SinhVien_update_bailam(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.BaiLam, DateTime.Now,Utils.GetIPAddress(), m_KiThiLopHocSinhVien.Status);
            Response.Redirect(Request.RawUrl);
        }

    }
}