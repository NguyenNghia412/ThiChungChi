using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace nuce.web.khaosatsinhvien.ad
{
    public partial class tong_hop_ket_qua : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, model.reportTotal> dtReportTotals = new Dictionary<string, model.reportTotal>();
                string strContent = string.Format("Bat dau: {0:d/M/yyyy HH:mm:ss}", DateTime.Now);
                DataTable dt = data.Nuce_Survey.getByStatus(4, 1);
                DataTable dtNoiDungBaiKhaoSat = data.Nuce_Survey.getEdu_Survey_BaiKhaoSat_GetNoiDungDeThi();
                DataTable dtLecturer = data.Nuce_Survey.getAcademy_Lecturer();
                DataTable dtClassRoom = data.Nuce_Survey.getAcademy_ClassRoom();
                for (int i = 0; i < dt.Rows.Count; i++)
                //for (int i = 0; i < 10; i++)
                {
                    int SinhVien_BaiKhaoSat_SinhVienID = int.Parse(dt.Rows[i]["ID"].ToString());
                    int SinhVien_BaiKhaoSatID = int.Parse(dt.Rows[i]["BaiKhaoSatID"].ToString());
                    int SinhVienID = int.Parse(dt.Rows[i]["SinhVienID"].ToString());
                    int iDeThiID = int.Parse(dt.Rows[i]["DeThiID"].ToString());
                    string NoiDungDeThi = getNoiDungDeThi(iDeThiID.ToString(), dtNoiDungBaiKhaoSat);
                    string strAnswares = dt.Rows[i]["BaiLam"].ToString();
                    string stringClassRoomCode = dt.Rows[i]["ClassRoomCode"].ToString();
                    string stringLecturerCode = dt.Rows[i]["LecturerCode"].ToString();
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(NoiDungDeThi);
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
                    //data.dnn_Nuce_KS_SinhVienRaTruong_ReportTotal1.insert(SinhVien_BaiKhaoSat_SinhVienID,SinhVien_BaiKhaoSatID,SinhVienID,)
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
                    #region
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        l++;
                        strType = cauhoi.Type;
                        model.reportTotal rpt1 = new model.reportTotal();
                        model.reportTotal rpt2 = new model.reportTotal();
                        model.reportTotal rpt3 = new model.reportTotal();
                        model.reportTotal rpt4 = new model.reportTotal();
                        model.reportTotal rpt5 = new model.reportTotal();
                        model.reportTotal rpt6 = new model.reportTotal();
                        switch (strType)
                        {
                            #region cau hoi lua chon
                            case "SC":
                            case "MC":
                            case "TQ":
                            case "FQ":
                                iSoCauTraLoi = cauhoi.SoCauTraLoi;
                                l1 = 1;
                                while (l1 < (iSoCauTraLoi + 1))
                                {
                                    strIDMC = "";
                                    switch (l1)
                                    {
                                        case 1:
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M1)))
                                            {
                                                // Cap nhat cau hoi duoc tra loi
                                                #region rpt
                                                rpt1.CampaignId = 1;
                                                rpt1.SemesterId = 1;
                                                rpt1.CampaignTemplateId = iDeThiID;
                                                rpt1.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                                rpt1.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                                #region QuestionType
                                                switch (strType)
                                                {
                                                    case "SC":
                                                        rpt1.QuestionType = 1;
                                                        break;
                                                    case "MC":
                                                        rpt1.QuestionType = 2;
                                                        break;
                                                    case "SA":
                                                        rpt1.QuestionType = 3;
                                                        break;
                                                    default:
                                                        rpt1.QuestionType = -1;
                                                        break;
                                                }
                                                #endregion
                                                rpt1.QuestionId = cauhoi.CauHoiID;
                                                rpt1.QuestionIndex = l;
                                                rpt1.Total = 1;
                                                rpt1.AnswerId = -1;
                                                rpt1.Value = "";
                                                #endregion
                                                rpt1.AnswerId = int.Parse(cauhoi.M1);
                                                dtReportTotals = insertReportTotal(rpt1, dtReportTotals);
                                            }
                                            break;
                                        case 2:
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M2)))
                                            {
                                                // Cap nhat cau hoi duoc tra loi
                                                #region rpt
                                                rpt2.CampaignId = 1;
                                                rpt2.SemesterId = 1;
                                                rpt2.CampaignTemplateId = iDeThiID;
                                                rpt2.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                                rpt2.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                                #region QuestionType
                                                switch (strType)
                                                {
                                                    case "SC":
                                                        rpt2.QuestionType = 1;
                                                        break;
                                                    case "MC":
                                                        rpt2.QuestionType = 2;
                                                        break;
                                                    case "SA":
                                                        rpt2.QuestionType = 3;
                                                        break;
                                                    default:
                                                        rpt2.QuestionType = -1;
                                                        break;
                                                }
                                                #endregion
                                                rpt2.QuestionId = cauhoi.CauHoiID;
                                                rpt2.QuestionIndex = l;
                                                rpt2.Total = 1;
                                                rpt2.AnswerId = -1;
                                                rpt2.Value = "";
                                                #endregion
                                                rpt2.AnswerId = int.Parse(cauhoi.M2);
                                                dtReportTotals = insertReportTotal(rpt2, dtReportTotals);
                                            }
                                            break;
                                        case 3:
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M3)))
                                            {
                                                #region rpt
                                                rpt3.CampaignId = 1;
                                                rpt3.SemesterId = 1;
                                                rpt3.CampaignTemplateId = iDeThiID;
                                                rpt3.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                                rpt3.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                                #region QuestionType
                                                switch (strType)
                                                {
                                                    case "SC":
                                                        rpt3.QuestionType = 1;
                                                        break;
                                                    case "MC":
                                                        rpt3.QuestionType = 2;
                                                        break;
                                                    case "SA":
                                                        rpt3.QuestionType = 3;
                                                        break;
                                                    default:
                                                        rpt3.QuestionType = -1;
                                                        break;
                                                }
                                                #endregion
                                                rpt3.QuestionId = cauhoi.CauHoiID;
                                                rpt3.QuestionIndex = l;
                                                rpt3.Total = 1;
                                                rpt3.AnswerId = -1;
                                                rpt3.Value = "";
                                                #endregion
                                                rpt3.AnswerId = int.Parse(cauhoi.M3);
                                                dtReportTotals = insertReportTotal(rpt3, dtReportTotals);
                                            }
                                            break;
                                        case 4:
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M4)))
                                            {
                                                #region rpt
                                                rpt4.CampaignId = 1;
                                                rpt4.SemesterId = 1;
                                                rpt4.CampaignTemplateId = iDeThiID;
                                                rpt4.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                                rpt4.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                                #region QuestionType
                                                switch (strType)
                                                {
                                                    case "SC":
                                                        rpt4.QuestionType = 1;
                                                        break;
                                                    case "MC":
                                                        rpt4.QuestionType = 2;
                                                        break;
                                                    case "SA":
                                                        rpt4.QuestionType = 3;
                                                        break;
                                                    default:
                                                        rpt4.QuestionType = -1;
                                                        break;
                                                }
                                                #endregion
                                                rpt4.QuestionId = cauhoi.CauHoiID;
                                                rpt4.QuestionIndex = l;
                                                rpt4.Total = 1;
                                                rpt4.AnswerId = -1;
                                                rpt4.Value = "";
                                                #endregion
                                                rpt4.AnswerId = int.Parse(cauhoi.M4);
                                                dtReportTotals = insertReportTotal(rpt4, dtReportTotals);
                                            }
                                            break;
                                        case 5:
                                            if (strMatch.Contains(string.Format(";{0};", cauhoi.M5)))
                                            {
                                                #region rpt
                                                rpt5.CampaignId = 1;
                                                rpt5.SemesterId = 1;
                                                rpt5.CampaignTemplateId = iDeThiID;
                                                rpt5.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                                rpt5.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                                #region QuestionType
                                                switch (strType)
                                                {
                                                    case "SC":
                                                        rpt5.QuestionType = 1;
                                                        break;
                                                    case "MC":
                                                        rpt5.QuestionType = 2;
                                                        break;
                                                    case "SA":
                                                        rpt5.QuestionType = 3;
                                                        break;
                                                    default:
                                                        rpt5.QuestionType = -1;
                                                        break;
                                                }
                                                #endregion
                                                rpt5.QuestionId = cauhoi.CauHoiID;
                                                rpt5.QuestionIndex = l;
                                                rpt5.Total = 1;
                                                rpt5.AnswerId = -1;
                                                rpt5.Value = "";
                                                #endregion
                                                rpt5.AnswerId = int.Parse(cauhoi.M5);
                                                dtReportTotals = insertReportTotal(rpt5, dtReportTotals);
                                            }
                                            break;
                                    }
                                    l1++;
                                }
                                if (strType.Equals("MC"))
                                {
                                    #region rpt
                                    rpt6.CampaignId = 1;
                                    rpt6.SemesterId = 1;
                                    rpt6.CampaignTemplateId = iDeThiID;
                                    rpt6.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                    rpt6.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                    #region QuestionType
                                    switch (strType)
                                    {
                                        case "SC":
                                            rpt6.QuestionType = 1;
                                            break;
                                        case "MC":
                                            rpt6.QuestionType = 2;
                                            break;
                                        case "SA":
                                            rpt6.QuestionType = 3;
                                            break;
                                        default:
                                            rpt6.QuestionType = -1;
                                            break;
                                    }
                                    #endregion
                                    rpt6.QuestionId = cauhoi.CauHoiID;
                                    rpt6.QuestionIndex = l;
                                    rpt6.Total = 1;
                                    rpt6.AnswerId = -1;
                                    rpt6.Value = "";
                                    #endregion
                                    rpt6.AnswerId = -1;
                                    rpt6.Value = Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID);
                                    dtReportTotals = insertReportTotal1(rpt6, dtReportTotals);
                                }
                                break;
                            #endregion
                            #region cau hoi text
                            case "SA":
                                #region rpt
                                model.reportTotal rpt = new model.reportTotal();
                                rpt.CampaignId = 1;
                                rpt.SemesterId = 1;
                                rpt.CampaignTemplateId = iDeThiID;
                                rpt.ClassRoomId = getClassRoomID(stringClassRoomCode, dtClassRoom);
                                rpt.LecturerId = getLecturerID(stringLecturerCode, dtLecturer);
                                #region QuestionType
                                switch (strType)
                                {
                                    case "SC":
                                        rpt.QuestionType = 1;
                                        break;
                                    case "MC":
                                        rpt.QuestionType = 2;
                                        break;
                                    case "SA":
                                        rpt.QuestionType = 3;
                                        break;
                                    default:
                                        rpt.QuestionType = -1;
                                        break;
                                }
                                #endregion
                                rpt.QuestionId = cauhoi.CauHoiID;
                                rpt.QuestionIndex = l;
                                rpt.Total = 1;
                                rpt.AnswerId = -1;
                                rpt.Value = "";
                                #endregion
                                rpt.AnswerId = -1;
                                rpt.Value = Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID);
                                dtReportTotals = insertReportTotal1(rpt, dtReportTotals);
                                //rpt.Value = Utils.getValueTextFromDapAn(lsDapAnsText, cauhoi.CauHoiID);
                                //dtReportTotals = insertReportTotal1(rpt, dtReportTotals);
                                break;
                            #endregion
                            default: break;
                        }
                    }
                    // Cap nhat dat xu ly

                }
                #endregion
                // Cap nhat
                foreach (var pair in dtReportTotals)
                {
                    string Key = pair.Key;
                    model.reportTotal rpt = pair.Value;
                    data.Nuce_Survey.InsertReportTotal(rpt.SemesterId, rpt.CampaignId, rpt.CampaignTemplateId, rpt.ClassRoomId, rpt.LecturerId, rpt.QuestionType, rpt.QuestionId, rpt.QuestionIndex, rpt.AnswerId, rpt.Total, rpt.Value);
                }
                strContent += string.Format("------ ket thuc : {0:d/M/yyyy HH:mm:ss}", DateTime.Now);
                divContent.InnerHtml = string.Format("{0} ----- Co ta ca {1} ban ghi", strContent, dtReportTotals.Count);
            }
            catch(Exception ex)
            {
                divContent.InnerHtml = ex.ToString();
            }
        }
        public string getNoiDungDeThi(string id, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["BoDeID"].ToString().Equals(id))
                    return dt.Rows[i]["NoiDungDeThi"].ToString();
            }
            return "";
        }
        public int getClassRoomID(string Code, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Code"].ToString().Equals(Code))
                    return int.Parse(dt.Rows[i]["ID"].ToString());
            }
            return -1;
        }
        public int getLecturerID(string Code, DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Code"].ToString().Equals(Code))
                    return int.Parse(dt.Rows[i]["ID"].ToString());
            }
            return -1;
        }
        // Cau hoi lua chon
        public Dictionary<string, model.reportTotal> insertReportTotal(model.reportTotal rpt, Dictionary<string, model.reportTotal> dt)
        {
            Dictionary<string, model.reportTotal> dtReturn;
            dtReturn = dt;
            string key = string.Format("{0}_{1}_{2}_{3}", rpt.LecturerId, rpt.ClassRoomId, rpt.QuestionId,rpt.AnswerId);
            if (dt.ContainsKey(key))
            {
                model.reportTotal rpt1 = dt[key];
                rpt1.Total = rpt1.Total + 1;
                dtReturn.Remove(key);
                dtReturn.Add(key, rpt1);
            }
            else
                dtReturn.Add(key, rpt);
            return dtReturn;
        }
        // Cau hoi text
        public Dictionary<string, model.reportTotal> insertReportTotal1(model.reportTotal rpt, Dictionary<string, model.reportTotal> dt)
        {
            Dictionary<string, model.reportTotal> dtReturn;
            dtReturn = dt;
            string key = string.Format("{0}_{1}_{2}_{3}", rpt.LecturerId, rpt.ClassRoomId, rpt.QuestionId, rpt.AnswerId);
            if (dt.ContainsKey(key))
            {
                model.reportTotal rpt1 = dt[key];
                rpt1.Value = rpt1.Value + ";"+rpt.Value;
                dtReturn.Remove(key);
                dtReturn.Add(key, rpt1);
            }
            else
                dtReturn.Add(key, rpt);
            return dtReturn;
        }
    }

}