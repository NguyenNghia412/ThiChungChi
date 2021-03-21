using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuce.ctsv.excels
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnDongBoEmailSinhVien_Click(object sender, EventArgs e)
        {
            frmDongBoEmailSinhVien frm = new frmDongBoEmailSinhVien();
            frm.Show();
        }

        private void btnDongBoThongTinHoKhauThuongTru_Click(object sender, EventArgs e)
        {
            services.Service sv = new services.Service();
            DataTable dt= sv.getAllTTSV1();
            string strSql = "";
            string Code = "";
            string DCTHONXOM = "";
            string tenpxvn = "";
            string TENQHVN = "";
            string TENTPVN = "";
            for (int i=0;i<dt.Rows.Count;i++)
            {
                Code = dt.Rows[i]["MASV"].ToString().Trim();
                DCTHONXOM = dt.Rows[i]["DCThonXom"].ToString().Trim();
                tenpxvn = dt.Rows[i]["tenpxvn"].ToString().Trim();
                TENQHVN = dt.Rows[i]["TENQHVN"].ToString().Trim();
                TENTPVN = dt.Rows[i]["TENTPVN"].ToString().Trim();
                strSql += string.Format(@"UPDATE [dbo].[AS_Academy_Student]
   SET 
      [HKTT_Pho] = N'{0}'
      , [HKTT_Phuong] = N'{1}'
     , [HKTT_Quan] = N'{2}'
      , [HKTT_Tinh] = N'{3}'
 WHERE code='{4}' ;", DCTHONXOM, tenpxvn, TENQHVN, TENTPVN, Code);
            }
            MessageBox.Show(strSql);
        }

        private void btnDongBoThongTinDiaChiTamTru_Click(object sender, EventArgs e)
        {
            services.Service sv = new services.Service();
            DataTable dt = sv.getAllTTSV2_HoKhauTamTru();
            string strSql = "";
            string Code = "";
            string DCTT1 = "";
            string TENQHVN = "";
            string TENTPVN = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Code = dt.Rows[i]["MASV"].ToString().Trim();
                DCTT1 = dt.Rows[i]["DCTT1"].ToString().Trim();
                TENQHVN = dt.Rows[i]["TENQHVN"].ToString().Trim();
                TENTPVN = dt.Rows[i]["TENTPVN"].ToString().Trim();
                strSql += string.Format(@"UPDATE [dbo].[AS_Academy_Student]
   SET 
      [LaNoiTru] = 0
      , [DiaChiCuThe] = N'{0}, {1}, {2}'
 WHERE code='{3}' ;", DCTT1, TENQHVN, TENTPVN,  Code);
            }
            MessageBox.Show(strSql);
        }
    }
}
