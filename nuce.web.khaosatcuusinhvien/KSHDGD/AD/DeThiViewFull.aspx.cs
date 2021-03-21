using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace nuce.web.khaosatsinhvien.ad
{
    public partial class DeThiViewFull : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Nếu không có
            int id=-1;
            if(Request.QueryString["id"]==null||!int.TryParse(Request.QueryString["id"],out id))
            {
                divBody.InnerText = "Bạn hãy chọn id đề thi";
            }
            // đã có bài khảo sát
            else
            {
                #region xay dung bai khao sát
               
                    string strHtmlOut = "<div>";
                    string strScript = string.Format("<script> var KiThi_LopHoc_SinhVienID={0};var BaiKhaoSatID={1};", -1, -1);
                    string strScriptLast = "";
                    #region bindbailam
                    // Lay noi dung bai thi
                    string strNoiDungBaiThi = nuce.web.data.Nuce_Survey.getEdu_Survey_BaiKhaoSat_GetNoiDungDeThi(id);
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(strNoiDungBaiThi);
                    string strAnswares = "";
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
                    divBody.InnerHtml = strHtmlOut;
                    strScript += strScriptLast;
                    strScript += "</script>";
                    divInitData.InnerHtml = strScript;

                #endregion
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

    }
}