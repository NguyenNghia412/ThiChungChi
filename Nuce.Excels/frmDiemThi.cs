using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuce.Excels
{
    public partial class frmDiemThi : Form
    {
        private DataTable dt;
        public frmDiemThi()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            //diem mon hoc cac nam
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            ExcelFile ef = ExcelFile.Load("diem mon hoc cac nam.xlsx");

            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["Nam hoc 17-18"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
            }
            int iColumn = 0;
            bool blCheckExit = false;
            int iRowsCount = 2254700;
            iRowsCount = sheet.Rows.Count > iRowsCount ? iRowsCount : sheet.Rows.Count;
            for (int i = 1; i < iRowsCount; i++)
            {
                iColumn = 0;
                dt.Rows.Add();
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {

                        if (cell.Value != null)
                            dt.Rows[i - 1][iColumn] = Converter.TCVN3ToUnicode(cell.Value.ToString());
                        else
                            dt.Rows[i - 1][iColumn] = "";
                        //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                        iColumn++;
                        if (iColumn >= dt.Columns.Count)
                            break;
                }
            }
            grvView.DataSource = dt;

        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            string masv = "";
            string mamh = "";
            string manh = "";
            string diem1 = "";
            string diem2 = "";
            string diem3 = "";
            float fdiem1 = 0;
            float fdiem2 = 0;
            float fdiem3 = 0;
            string namhoc = "2017-2018";
            //DataTable dtCheck = nuce.web.data.dnn_Nuce_KS_DiemThi1.Check34();
            for (int i=0;i<dt.Rows.Count;i++)
            {
                masv = dt.Rows[i][0].ToString().Trim();
                mamh = dt.Rows[i][1].ToString().Trim();
                manh = dt.Rows[i][2].ToString().Trim();
                diem1 = dt.Rows[i][3].ToString().Trim();
                diem2 = dt.Rows[i][4].ToString().Trim();
                diem3 = dt.Rows[i][5].ToString().Trim();
                fdiem1 = 0;
                float.TryParse(diem1, out fdiem1);
                fdiem2 = 0;
                float.TryParse(diem2, out fdiem2);
                fdiem3 = 0;
                float.TryParse(diem2, out fdiem3);
                try
                {
                    if(!masv.Equals(""))
                       // if(check(dtCheck,masv,mamh,manh))
                            nuce.web.data.dnn_Nuce_KS_DiemThi1.insert78(masv, mamh, manh, diem1, diem2, diem3, fdiem1, fdiem2, fdiem3, namhoc);
                }
                catch(Exception ex)
                {

                }
            }
        }
        public bool check(DataTable dt,string masv,string mamh,string manh)
        {
            try
            {
                if (dt.Select(string.Format("F_MASV='{0}' and F_MAMH='{1}' and F_MANH='{2}'", masv, mamh, manh)).Length > 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return true;
            }
        }
    }
}
