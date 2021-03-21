using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuce.ks.form_analytisc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private string getSubjectCode(DataTable dt,string ID)
        {
            DataRow[] dr = dt.Select(string.Format("ID= {0}", ID));
            if (dr.Length > 0)
                return dr[0]["SubjectCode"].ToString();
            else return "";
        }
        private string getSubjectName(DataTable dt, string Code)
        {
            DataRow[] dr = dt.Select(string.Format("Code= '{0}'", Code));
            if (dr.Length > 0)
                return dr[0]["Name"].ToString();
            else return "";
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataTable dt = data.AS_Edu_Survey_ReportTotal.get();
            DataTable dtClassRoom = data.AS_Edu_Survey_ReportTotal.getClassRoom();
            DataTable dtSubject = data.AS_Edu_Survey_ReportTotal.getSubject();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strText = dt.Rows[i]["Value"].ToString();
                string[] strSplit = strText.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string strID = dt.Rows[i]["ID"].ToString();
                string strClassRoomID = dt.Rows[i]["ClassRoomId"].ToString();
                string strQuestionID= dt.Rows[i]["QuestionId"].ToString();
                int iType = 1;
                string subCode = getSubjectCode(dtClassRoom, strClassRoomID);
                string subName = getSubjectName(dtSubject, subCode);
                switch(strID)
                {
                    case "41":
                        iType = 1;
                        break;
                    case "42":
                        iType = 2;
                        break;
                    case "43":
                        iType = 3;
                        break;
                    default:break;
                }
                foreach (string strTemp in strSplit)
                {
                    string strRemoveDau = data.Nuce_Common.RemoveUnicode(strTemp).Replace("  ", " ").Replace(" ", "-");
                    strRemoveDau = strRemoveDau.Trim();
                    strRemoveDau = strRemoveDau.ToUpper();
                    if (!strRemoveDau.Equals("KHONG-CO") && !strRemoveDau.Equals("KHONG-CO")
                       && !strRemoveDau.Equals("KHONG")
                       && !strRemoveDau.Equals("KO-CO")
                       && !strRemoveDau.Equals("TOT")
                       && !strRemoveDau.Equals("KHONG-CO-"))
                    {
                        data.Nuce_KS_OutputText.insert(strRemoveDau, strTemp, strID, "ki_2_2018_Q_"+strQuestionID,iType,subCode,subName);
                    }
                }
            }
            MessageBox.Show("Thanh Cong");
        }
    }
}
