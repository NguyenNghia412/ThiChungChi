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

namespace nuce.ctsv.excels
{
    public partial class frmDongBoEmailSinhVien : Form
    {
        private DataTable dt;
        public frmDongBoEmailSinhVien()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            GemBox.Spreadsheet.SpreadsheetInfo.SetLicense("EL6O-26C7-AZ0H-090X");
            //ExcelFile ef = ExcelFile.Load("TN10_2019.xls");
            ExcelFile ef = ExcelFile.Load("All.xlsx");
            StringBuilder sb = new StringBuilder();

            // Iterate through all worksheets in an Excel workbook.
            ExcelWorksheet sheet = ef.Worksheets["ALL-THO"];
            //    sb.AppendLine();
            //sb.AppendFormat("{0} {1} {0}", new string('-', 25), Converter.TCVN3ToUnicode(sheet.Name));

            // Iterate through all rows in an Excel worksheet.
            dt = new DataTable();
            foreach (ExcelCell cell in sheet.Rows[0].AllocatedCells)
            {
                //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                dt.Columns.Add(cell.Value.ToString());
            }
            int iColumn = 0;
            for (int i = 1; i < sheet.Rows.Count; i++)
            {
                iColumn = 0;
                foreach (ExcelCell cell in sheet.Rows[i].AllocatedCells)
                {
                    dt.Rows.Add();
                    if (cell.Value != null)
                        //dt.Rows[i - 1][iColumn] = Converter.TCVN3ToUnicode(cell.Value.ToString());
                        dt.Rows[i - 1][iColumn] = cell.Value.ToString();
                    else
                        dt.Rows[i - 1][iColumn] = "";
                    //dt.Columns.Add(Converter.LocDau(Converter.TCVN3ToUnicode(cell.Value.ToString())));
                    iColumn++;
                    if (iColumn >= dt.Columns.Count)
                        break;
                }
            }

            grvData.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strSql = "";
            string Code = "";
            string Email = "";
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Code = dt.Rows[i][0].ToString().Trim();
                Email = dt.Rows[i][3].ToString().Trim();
                if (Code != "" && Email != "")
                {
                    strSql += string.Format(@"UPDATE [dbo].[AS_Academy_Student]
   SET 
      [EmailNhaTruong] = '{0}'
      ,[DaXacThucEmailNhaTruong] = 1
 WHERE code='{1}' ;", Email, Code);
                }
            }
            MessageBox.Show(strSql);
        }
    }
}
