using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using nuce.web.commons;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class ad_tcc_exportbangdiem : CoreHandlerCommonAdminThiChungChi
    {
        public override void WriteData(HttpContext context)
        {
            string idPhongCaNgay = context.Request["IDPhongCaNgay"]?.ToString();
            string path = HttpContext.Current.Server.MapPath("~/NuceDataUpload/Templates/Bang-diem-vien-tin-hoc.docx");
            string destinationPath = HttpContext.Current.Server.MapPath($"~/NuceDataUpload/Templates/Bang-diem-vien-tin-hoc-{DateTime.Now.ToFileTime()}.docx");

            //byte[] templateBytes = File.ReadAllBytes(path);
            //using (MemoryStream templateStream = new MemoryStream())
            //{
            //    templateStream.Write(templateBytes, 0, templateBytes.Length);
            //    using (WordprocessingDocument doc = WordprocessingDocument.Open(templateStream, true))
            //    {
            //        doc.ChangeDocumentType(WordprocessingDocumentType.Document);
            //        var mainPart = doc.MainDocumentPart;
            //        #region handle text
            //        var textList = mainPart.Document.Descendants<Text>().ToList();
            //        foreach (var text in textList)
            //        {
            //            replaceTextTemplate(text, "<ngay_thi>", "18/03/2021");
            //            replaceTextTemplate(text, "<phong_thi>", "310.H1");
            //            replaceTextTemplate(text, "<ca_thi>", "Sáng");
            //        }
            //        #endregion
            //        mainPart.Document.Save();
            //    }
            //    File.WriteAllBytes(destinationPath, templateStream.ToArray());
            //}
            //byte[] rsByte = File.ReadAllBytes(destinationPath);
            context.Response.Clear();
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            //context.Response.ContentType = "application/octet-stream";
            //context.Response.AddHeader("content-disposition", "attachment; filename=Bang-diem.docx");
            //context.Response.BufferOutput = true;
            //context.Response.BinaryWrite(templateBytes);
            //context.Response.OutputStream.Write(templateBytes, 0, templateBytes.Length);
            //context.Response.TransmitFile(path);
            context.Response.WriteFile(path);
            context.Response.End();
        }

        private void replaceTextTemplate(Text model, string oldValue, string newValue)
        {
            if (oldValue == null)
            {
                oldValue = "";
            }
            if (newValue == null)
            {
                newValue = "";
            }
            if (!model.Text.Contains(oldValue)) return;
            if (!newValue.Contains('\r'))
            {
                model.Text = model.Text.Replace(oldValue, newValue);
            }
            else
            {
                var arr = newValue.Split('\r');
                for (int i = 0; i < arr.Count(); i++)
                {
                    string replaceText = arr[i];
                    if (i == 0)
                    {
                        model.Text = model.Text.Replace(oldValue, replaceText);
                        continue;
                    }
                    model.Parent.Append(new Break());
                    model.Parent.Append(new Text(replaceText));
                }
            }
        }
    }
}