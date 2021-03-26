using Newtonsoft.Json;
using nuce.web.data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Thi_SV.Common;

namespace Thi_SV.Handler.nuce.thichungchi
{
    /// <summary>
    /// Summary description for tcc_upload_thituluan
    /// </summary>
    public class tcc_upload_thituluan : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string msg = "ok";
            int status = 0;
            try
            {
                string idKiThiLopHocSinhVien = context.Request["ID"].ToString();

                var files = context.Request.Files;
                var file = files[0];
                string extension = Path.GetExtension(file.FileName);
                string filename = file.FileName;
                string strTenCu = filename;
                string strTenMoi = string.Format("{0}", Utils.RemoveUnicode(filename).Replace(" ", "_"));

                var uploadFolder = ConfigManager.GetConfig(ConfigManager.UploadsFolder);

                string path = Path.Combine(uploadFolder, strTenMoi);
                //HttpContext.Current.Server.MapPath("~/NuceDataUpload/cauhoi/" + strTenMoi);
                //file.SaveAs(path);
                byte[] content = new byte[file.ContentLength];
                file.InputStream.Read(content, 0, file.ContentLength);
                File.WriteAllBytes(path, content);

                dnn_NuceThi_KiThi_LopHoc_SinhVien.updateNopBaiTuLuan(Convert.ToInt32(idKiThiLopHocSinhVien), strTenMoi);
            }
            catch (Exception ex)
            {
                status = 1;
                msg = ex.Message;
            }
            string json = JsonConvert.SerializeObject(new { status, msg });
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}