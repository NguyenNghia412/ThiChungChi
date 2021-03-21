using ClosedXML.Excel;
using Newtonsoft.Json;
using nuce.web.commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace nuce.web.Handler.nuce.ad.thichungchi
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ad_tcc_read_excel_thisinh : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            try
            {
                var files = context.Request.Files;
                var file = files[0];
                string strMoRongFile = System.IO.Path.GetExtension(file.FileName);
                string filename = file.FileName;
                string strTenCu = filename;
                string strTenMoi = string.Format("{0}_{1}_{2}_{3}_{4}_{5}", DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Second, 0, 0, Utils.RemoveUnicode(filename).Replace(" ", "_"));

                string path = HttpContext.Current.Server.MapPath("~/NuceDataUpload/cauhoi/" + strTenMoi);
                string strLinkFile = path;
                
                file.SaveAs(strLinkFile);

                //Open the Excel file using ClosedXML.
                var m_DSDataImport = new DataSet();
                string result = "";
                using (XLWorkbook workBook = new XLWorkbook(strLinkFile))
                {
                    string strHtml = "";
                    for (int i = 1; i <= workBook.Worksheets.Count; i++)
                    {
                        IXLWorksheet workSheet = workBook.Worksheet(i);
                        m_DSDataImport.Tables.Add(Utils.getTableFromWorkSheet(workSheet));
                        strHtml += string.Format("<div style='margin:10px;text-align: center;'>Sheet: <b>{0}</b></div><div style='margin:10px;text-align: center;'>{1}</div>", workSheet.Name, Utils.getHtmlFromDataTable(m_DSDataImport.Tables[i - 1]));
                    }
                    result = strHtml;
                }

                string data = DataTableToJSONWithJavaScriptSerializer(m_DSDataImport.Tables[0]);
                string json = JsonConvert.SerializeObject(new { data, view = result });
                context.Response.Write(json);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}