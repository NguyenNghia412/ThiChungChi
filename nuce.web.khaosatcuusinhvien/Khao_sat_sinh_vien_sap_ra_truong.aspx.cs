using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace nuce.web
{
    public partial class Khao_sat_sinh_vien_sap_ra_truong : System.Web.UI.Page
    {
        public model.SinhVien m_SinhVien;
        public Dictionary<int, model.KiThiLopHocSinhVien> m_KiThiLopHocSinhViens;
        public Dictionary<int, string> m_TinhThanhs;
        public model.KiThiLopHocSinhVien m_KiThiLopHocSinhVien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] == null) || (m_KiThiLopHocSinhViens == null) || (m_KiThiLopHocSinhViens.Count == 0))
            {
                divContentCauHoi.InnerHtml = string.Format("Chưa có bài khảo sát");
            }
            else
            {
                // xay dung bai khao sat
                m_KiThiLopHocSinhVien = m_KiThiLopHocSinhViens[m_KiThiLopHocSinhViens.ElementAt(0).Key];
               if( m_KiThiLopHocSinhVien.Status.Equals(4))
                    {
                    btnNopBai.Visible = false;
                    btnNopBai.Enabled = false;
                    divBody.InnerHtml= @"<div style='text - align: center;width: 329px;margin: 0 auto;color:red;'>
                            Anh/chị vui lòng xác thực hoàn thành khảo sát
                          </div><div style='text - align: center;width: 239px;margin: 0 auto;color:red;'>
                           <a href='/khao_sat_sinh_vien_sap_ra_truong_suathongtin.aspx'>Trân trọng cảm ơn !</a>
                          </div> ";
                }
               else
                {
                    btnNopBai.Visible = true;
                    btnNopBai.Enabled = true;

                    // string strHtmlOut = @"<div><h5 class='h5_groupcauhoi'></h5>";
                    string strHtmlOut = "";
                    string strScript = string.Format("<script> var KiThi_LopHoc_SinhVienID={0};", m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien);
                    string strScriptLast = "";
                    #region bindbailam
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(m_KiThiLopHocSinhVien.NoiDungDeThi);
                    //List<model.DapAn> lsDapAns = JsonConvert.DeserializeObject<List<model.DapAn>>(KiThiLopHocSinhVien.DapAn);
                    string strAnswares = m_KiThiLopHocSinhVien.BaiLam;
                    List<model.DapAn> lsDapAns = new List<model.DapAn>();
                    List<model.DapAn> lsDapAnsText = new List<model.DapAn>();
                    string strRate = "";
                    string strTinhThanh = "";
                    string[] strAnswaresSplit = strAnswares.Split(new string[] { "#####$$$$$@@@@@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (strAnswaresSplit.Length >= 3)
                    {
                        lsDapAns = Utils.convertListDapAnFromAnswares(strAnswaresSplit[0]);
                        lsDapAnsText = Utils.convertListDapAnFromAnswaresText(strAnswaresSplit[1]);
                        strRate = strAnswaresSplit[2];
                    }
                    if (strAnswaresSplit.Length >= 4)
                    {
                        lsDapAns = Utils.convertListDapAnFromAnswares(strAnswaresSplit[0]);
                        lsDapAnsText = Utils.convertListDapAnFromAnswaresText(strAnswaresSplit[1]);
                        strRate = strAnswaresSplit[2];
                        strTinhThanh = strAnswaresSplit[3];
                    }
                    strScript = strScript + "var m_TinhThanh = '" + strTinhThanh + "';";
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
                    int l2 = 0;
                    string strType;
                    int iSoCauTraLoi = -1;
                    string strIDMC = "";
                    string strSoCot = "2";
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        l++;
                        strType = cauhoi.Type;
                        switch (strType)
                        {
                            #region cau hoi ao
                            case "GQ":
                                l2++;
                                strHtmlOut += string.Format(@"<div><h5 class='h5_groupcauhoi'>{0} {1}</h5>",UtilsDisplayDe.getStringIndexLaMa(l2), UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)));
                                l--;
                                break;
                            #endregion
                            #region cau hoi lua chon
                            case "SC":
                            case "MC":
                            case "TQ":
                            case "FQ":
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1} <span style='color:red;'>(*)</span>
                                            </span> 
                                        </div>
                                        <div class='block-content'><div class='row' style='padding-left: 10px;'>", l, UtilsDisplayDe.stripHTML(HttpUtility.HtmlDecode(cauhoi.Content)),cauhoi.CauHoiID);
                                iSoCauTraLoi = cauhoi.SoCauTraLoi;
                                l1 = 1;
                                while (l1 < (iSoCauTraLoi + 1))
                                {
                                    strIDMC = "";
                                    if (l > 39) strSoCot = "3";
                                    switch (l1)
                                    {
                                        case 1:
                                            strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + cauhoi.M1 + "\"";
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M1)))
                                            {
                                                strScript +=string.Format("checkDapAnMCInit({0});", strIDMC);
                                                if(cauhoi.M1.Equals("5065")|| cauhoi.M1.Equals("5064") || cauhoi.M1.Equals("5063"))
                                                {
                                                    strScriptLast= string.Format("checkDapAnMC({0});", strIDMC);
                                                }
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
                                                if (cauhoi.M1.Equals("5065") || cauhoi.M1.Equals("5064") || cauhoi.M1.Equals("5063"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
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
                                                if (cauhoi.M1.Equals("5065") || cauhoi.M1.Equals("5064") || cauhoi.M1.Equals("5063"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
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
                                                if (cauhoi.M1.Equals("5065") || cauhoi.M1.Equals("5064") || cauhoi.M1.Equals("5063"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
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
                                                if (cauhoi.M1.Equals("5065") || cauhoi.M1.Equals("5064") || cauhoi.M1.Equals("5063"))
                                                {
                                                    strScriptLast = string.Format("checkDapAnMC({0});", strIDMC);
                                                }
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
                            #region cau hoi text
                            case "SA":
                                if (!cauhoi.CauHoiID.Equals(3269))
                                {
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
                                }
                                else
                                {
                                    string strHtmlAdd = "<div class='row' style='padding-left: 10px;'>";
                                     strSoCot = "12";
                                    #region truoc 2020
                                    //trước 2020
                                    /*
                                    #region cau 1
                                    string strM1 = "1111111111";
                                    string strContentCauHoi = "Đào tạo thêm kỹ năng mềm";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 2
                                    strM1 = "2222222222";
                                    strContentCauHoi = "Đào tạo thêm kỹ năng Ngoại ngữ và Tin học";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID,strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 3
                                    strM1 = "3333333333";
                                    strContentCauHoi = "Tăng cường trải nghiệm môn học tại thực tế trong quá trình học";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 4
                                    strM1 = "4444444444";
                                    strContentCauHoi = "Mời các doanh nghiệp tham gia giảng dạy, bổ trợ kiến thức thực tế cho sinh viên";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID,strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 5
                                    strM1 = "555555555";
                                    strContentCauHoi = "Sớm đưa sinh viên thực tập tại các cơ quan, doanh nghiệp";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 6
                                    strM1 = "666666666";
                                    strContentCauHoi = "Tổ chức hội chợ việc làm và hội thảo hướng nghiệp cho sinh viên";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID,strM1, strIDMC, strSoCot);
                                    #endregion
                                    */
                                    #endregion
                                    #region 2020
                                    #region cau 1
                                    string strM1 = "1111111111";
                                    string strContentCauHoi = "Kĩ năng đặt mục tiêu, lập kế hoạch, quản lý thời gian";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 2
                                    strM1 = "2222222222";
                                    strContentCauHoi = "Kĩ năng làm việc nhóm";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 3
                                    strM1 = "3333333333";
                                    strContentCauHoi = "Tăng cường giảng dạy về hệ thống văn bản pháp luật, quy chuẩn, tiêu chuẩn chuyên ngành";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 4
                                    strM1 = "4444444444";
                                    strContentCauHoi = "Mời các doanh nghiệp tham gia giảng dạy, bổ trợ kiến thức thực tế cho sinh viên";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 5
                                    strM1 = "555555555";
                                    strContentCauHoi = "Sớm đưa sinh viên thực tập tại các cơ quan, doanh nghiệp";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion
                                    #region cau 6
                                    strM1 = "666666666";
                                    strContentCauHoi = "Tổ chức hội chợ việc làm và hội thảo hướng nghiệp cho sinh viên";
                                    strIDMC = "";
                                    strIDMC = "\"#id_" + cauhoi.CauHoiID + "_" + strM1 + "\"";
                                    if (strMatch.Contains(string.Format(";{0};", strM1)))
                                    {
                                        strScript += string.Format("checkDapAnMCInit({0});", strIDMC);
                                    }

                                    strHtmlAdd += string.Format(@"<div class='col-sm-{6} col-xs-12 item'>
                                                    <input type = 'checkbox' name='nCauHoi_{4}' 
                                                    value='vcauhoi_{0}' id='id_{3}_{1}' onclick='checkDapAnMC2({5});'>
                                                     <label onclick='checkDapAnMC1({5});' style='font-weight: normal;'>
                                                        {2}
                                                    </label>
                                                </div>", 1, HttpUtility.HtmlDecode(strM1), strContentCauHoi,
                                                cauhoi.CauHoiID, strM1, strIDMC, strSoCot);
                                    #endregion

                                    #endregion
                                    strHtmlAdd += "</div>";
                                    strHtmlOut += string.Format(@"<div class='block' id='q_{2}'>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1}<span style='color:red;'>(Anh/chị có thể chọn nhiều phương án dưới đây)</span>
                                            </span>
                                        </div>
                                        <div class='block-content'><ul>", l, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.CauHoiID);
                                    //Chen cau hoi them
                                    strHtmlOut += strHtmlAdd;

                                    strHtmlOut += string.Format(@" <div class='block-title'>
                                            <span class='question-title'>Ý kiến khác (vui lòng ghi rõ):
                                            </span>
                                        </div><div class='block - content'><ul>
                                            <li class='col-xs-12 item'>
                                                <textarea id = 'txtCauHoi_{0}' onblur='luuBai();'></textarea>
                                            </li>
                                            <div class='clear'></div>
                                        </ul>
                                    </div>", cauhoi.CauHoiID);
                                    strHtmlOut += string.Format(@"<div class='clear'></div>
                                            </ul>
                                        </div>
                                    </div>");

                                    strScript += string.Format("$('#txtCauHoi_{0}').val('{1}');", cauhoi.CauHoiID, Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID));
                                }
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
                            #region Cau hoi Tinh Thanh
                            case "EX":
                                #region test
                                strHtmlOut += string.Format(@"<div class='block' id='q_{2}''>
                                        <div class='block-title'>
                                            <span class='question-title'>Câu {0}: {1}
                                            </span>
                                        </div>
                                        <div class='block-content' style='padding-left:20px;padding-top:5px;padding-bottom:5px;'>
                                        <select id='cbTinhThanh'>", l, HttpUtility.HtmlDecode(cauhoi.Content), cauhoi.CauHoiID);
                                for (int c1 = 0; c1 < m_TinhThanhs.Count; c1++)
                                {
                                    if ((c1 + 1).ToString().Equals(strTinhThanh))
                                        strHtmlOut += string.Format(@"<option value='{0}' selected>{1}</option>", c1 + 1, m_TinhThanhs[c1 + 1]);
                                    else
                                        strHtmlOut += string.Format(@"<option value='{0}'>{1}</option>", c1 + 1, m_TinhThanhs[c1 + 1]);
                                }
                                strHtmlOut += string.Format(@"</select>
                                    </div></div>");
                                #endregion
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
            #region tinh thanh
            m_TinhThanhs = new Dictionary<int, string>();
            m_TinhThanhs.Add(1, "Hà Nội");
            m_TinhThanhs.Add(2, "TP HCM");
            m_TinhThanhs.Add(3, "Hải Phòng");
            m_TinhThanhs.Add(4, "Đà Nẵng");
            m_TinhThanhs.Add(5, "Cần Thơ");
            m_TinhThanhs.Add(6, "An Giang");
            m_TinhThanhs.Add(7, "Bà Rịa - Vũng Tàu");
            m_TinhThanhs.Add(8, "Bắc Giang");
            m_TinhThanhs.Add(9, "Bắc Kạn");
            m_TinhThanhs.Add(10, "Bạc Liêu");
            m_TinhThanhs.Add(11, "Bắc Ninh");
            m_TinhThanhs.Add(12, "Bến Tre");
            m_TinhThanhs.Add(13, "Bình Định");
            m_TinhThanhs.Add(14, "Bình Dương");
            m_TinhThanhs.Add(15, "Bình Phước");
            m_TinhThanhs.Add(16, "Bình Thuận");
            m_TinhThanhs.Add(17, "Cà Mau");
            m_TinhThanhs.Add(18, "Cao Bằng");
            m_TinhThanhs.Add(19, "Đắk Lắk");
            m_TinhThanhs.Add(20, "Đắk Nông");
            m_TinhThanhs.Add(21, "Điện Biên");
            m_TinhThanhs.Add(22, "Đồng Nai");
            m_TinhThanhs.Add(23, "Đồng Tháp");
            m_TinhThanhs.Add(24, "Gia Lai");
            m_TinhThanhs.Add(25, "Hà Giang");
            m_TinhThanhs.Add(26, "Hà Nam");
            m_TinhThanhs.Add(27, "Hà Tĩnh");
            m_TinhThanhs.Add(28, "Hải Dương");
            m_TinhThanhs.Add(29, "Hậu Giang");
            m_TinhThanhs.Add(30, "Hòa Bình");
            m_TinhThanhs.Add(31, "Hưng Yên");
            m_TinhThanhs.Add(32, "Khánh Hòa");
            m_TinhThanhs.Add(33, "Kiên Giang");
            m_TinhThanhs.Add(34, "Kon Tum");
            m_TinhThanhs.Add(35, "Lai Châu");
            m_TinhThanhs.Add(36, "Lâm Đồng");
            m_TinhThanhs.Add(37, "Lạng Sơn");
            m_TinhThanhs.Add(38, "Lào Cai");
            m_TinhThanhs.Add(39, "Long An");
            m_TinhThanhs.Add(40, "Nam Định");
            m_TinhThanhs.Add(41, "Nghệ An");
            m_TinhThanhs.Add(42, "Ninh Bình");
            m_TinhThanhs.Add(43, "Ninh Thuận");
            m_TinhThanhs.Add(44, "Phú Thọ");
            m_TinhThanhs.Add(45, "Quảng Bình");
            m_TinhThanhs.Add(46, "Quảng Nam");
            m_TinhThanhs.Add(47, "Quảng Ngãi");
            m_TinhThanhs.Add(48, "Quảng Ninh");
            m_TinhThanhs.Add(49, "Quảng Trị");
            m_TinhThanhs.Add(50, "Sóc Trăng");
            m_TinhThanhs.Add(51, "Sơn La");
            m_TinhThanhs.Add(52, "Tây Ninh");
            m_TinhThanhs.Add(53, "Thái Bình");
            m_TinhThanhs.Add(54, "Thái Nguyên");
            m_TinhThanhs.Add(55, "Thanh Hóa");
            m_TinhThanhs.Add(56, "Thừa Thiên Huế");
            m_TinhThanhs.Add(57, "Tiền Giang");
            m_TinhThanhs.Add(58, "Trà Vinh");
            m_TinhThanhs.Add(59, "Tuyên Quang");
            m_TinhThanhs.Add(60, "Vĩnh Long");
            m_TinhThanhs.Add(61, "Vĩnh Phúc");
            m_TinhThanhs.Add(62, "Yên Bái");
            m_TinhThanhs.Add(63, "Phú Yên");

            #endregion
            m_KiThiLopHocSinhViens = new Dictionary<int, model.KiThiLopHocSinhVien>();
            if (Session[Utils.session_sinhvienchuanbitotnghiep] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/login_sinh_vien_sap_ra_truong.aspx"));
            }
            //{
            //    Response.Redirect(string.Format("/khao_sat_cuu_sinh_vien_suathongtin.aspx"));
            //}
            
            m_SinhVien = (model.SinhVien)Session[Utils.session_sinhvienchuanbitotnghiep];
            spLogin.InnerHtml = string.Format("<a href='/login_sinh_vien_sap_ra_truong.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Xin chào {0} - {1} ({2}) - Đăng xuất</a>", m_SinhVien.Ho, m_SinhVien.Ten, m_SinhVien.MaSV);
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                              <option value='/Default.aspx'>Lựa chọn</ option >
                              <option value='/Default.aspx'>Home</option>
                                             <option value='/khao_sat_sinh_vien_sap_ra_truong_suathongtin.aspx'>Xác thực hoàn thành khảo sát</option>
                              <option value='/login_sinh_vien_sap_ra_truong.aspx?ctl=dangxuat'>Đăng xuất</option>
                               </select>
                               <div class='clearfix'>
                               </div>";
            if (Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep] != null)
                m_KiThiLopHocSinhViens = (Dictionary<int, model.KiThiLopHocSinhVien>)Session[Utils.session_kithi_lophoc_sinhvienchuanbitotnghiep];


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
            data.dnn_Nuce_KS_SinhVienSapRaTruong_BaiKhaoSat_SinhVien1.update_bailam1(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.BaiLam, DateTime.Now,Utils.GetIPAddress(), m_KiThiLopHocSinhVien.Status);
            //data.dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus2(m_KiThiLopHocSinhVien.KiThi_LopHoc_SinhVien, m_KiThiLopHocSinhVien.Status, m_KiThiLopHocSinhVien.BaiLam, m_KiThiLopHocSinhVien.Diem);

            Response.Redirect(Request.RawUrl);

        }

    }
}