using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace nuce.web.admin
{
    public partial class Default : System.Web.UI.Page
    {
        public model.User m_User;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Lay Lai cau hoi - khong xoa
                /*
                // Lay du lieu tu cau hoi
                DataTable dt = data.Nuce_Survey.getEdu_Survey_BaiKhaoSat_GetNoiDungDeThi();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int iBoCauHoi = int.Parse(dt.Rows[i]["BoDeID"].ToString());
                    string strNoiDungDeThi = dt.Rows[i]["NoiDungDeThi"].ToString();
                    string strDapAn = dt.Rows[i]["DapAn"].ToString();
                    List<model.CauHoi> lsCauHois = JsonConvert.DeserializeObject<List<model.CauHoi>>(strNoiDungDeThi);
                    List<model.DapAn> lsDapAns = Utils.convertListDapAnFromAnswares(strDapAn);
                    int iThuTu = 0;
                    foreach (model.CauHoi cauhoi in lsCauHois)
                    {
                        iThuTu++;
                        data.Nuce_Survey.insertWithID_AS_Edu_Survey_CauHoi(cauhoi.CauHoiID, iBoCauHoi, 1, cauhoi.CauHoiID.ToString(), cauhoi.Content, "", "", "", 1, 1, true, 1, cauhoi.Explain, -1, 1, DateTime.Now.AddYears(10), 1, 1, 1, DateTime.Now, DateTime.Now, iThuTu, 1, cauhoi.Type, 1);
                        int iSoCauTraLoi = cauhoi.SoCauTraLoi;
                        for (int j = 1; j < iSoCauTraLoi + 1; j++)
                        {
                            switch (j)
                            {
                                case 1:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M1), cauhoi.CauHoiID, -1, cauhoi.A1, false, "", 1, 1, j, 1);
                                    break;
                                case 2:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M2), cauhoi.CauHoiID, -1, cauhoi.A2, false, "", 1, 1, j, 1);
                                    break;
                                case 3:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M3), cauhoi.CauHoiID, -1, cauhoi.A3, false, "", 1, 1, j, 1);
                                    break;
                                case 4:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M4), cauhoi.CauHoiID, -1, cauhoi.A4, false, "", 1, 1, j, 1);
                                    break;
                                case 5:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M5), cauhoi.CauHoiID, -1, cauhoi.A5, false, "", 1, 1, j, 1);
                                    break;
                                case 6:
                                    data.Nuce_Survey.insertWithIDAS_Edu_Survey_DapAn(int.Parse(cauhoi.M6), cauhoi.CauHoiID, -1, cauhoi.A6, false, "", 1, 1, j, 1);
                                    break;
                                default: break;
                            }

                        }
                        //List<model.DapAn> dapAn = lsDapAns.FindAll(x => x.CauHoiID.Equals(cauhoi.CauHoiID));
                    }
                }
                */
                #endregion
            }
        }
        protected override void OnInit(EventArgs e)
        {
            if (Session[Utils.session_admin_user] == null)
            {
                //Chuyển đến trang đăng nhập
                Response.Redirect(string.Format("/admin/login.aspx"));
            }
            m_User = (model.User)Session[Utils.session_admin_user];
            spLogin.InnerHtml = string.Format("<a href='/admin/login.aspx?ctl=dangxuat' class='btn_dangnhap_header'>Đăng xuất</a>");
            mo_menuheader.InnerHtml = @"<a href='javascript: showmenu()'>Menu </a><select>
                                <option value='/ admin / Default.aspx'>Trang chủ</option>
                                   </select>
                               <div class='clearfix'>
                               </div>";
            base.OnInit(e);
        }
    }
}