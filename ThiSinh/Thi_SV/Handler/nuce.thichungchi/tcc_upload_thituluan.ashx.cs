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
            string msg = "Thành công";
            int status = 0;
            string[] allowExtension = new string[] { ".zip", ".rar", ".rar4" };

            var files = context.Request.Files;
            var file = files[0];
            string filename = file.FileName;
            string strTenCu = filename;
            string extension = Path.GetExtension(file.FileName);

            if (!allowExtension.Contains(extension.ToLower()))
            {
                makeResponse(context, 2, "Chỉ chấp nhận file có một trong các định dạng zip, rar hoặc rar4");
                return;
            }

            if (!strTenCu.Contains("_"))
            {
                makeResponse(context, 2, "Tên bài làm phải đặt theo cú pháp [mã thí sinh]_[mã đề]");
                return;
            }

            var splited = strTenCu.Split('_');
            string maDe = splited[1].Split('.')[0];

            try
            {
                string idKiThiLopHocSinhVien = context.Request["ID"].ToString();
                
                string strTenMoi = string.Format("{0}", Utils.RemoveUnicode(filename).Replace(" ", "_"));

                var uploadFolder = ConfigManager.GetConfig(ConfigManager.UploadsFolder);

                string path = Path.Combine(uploadFolder, strTenMoi);
                
                byte[] content = new byte[file.ContentLength];
                file.InputStream.Read(content, 0, file.ContentLength);
                File.WriteAllBytes(path, content);

                dnn_NuceThi_KiThi_LopHoc_SinhVien.updateNopBaiTuLuan(Convert.ToInt32(idKiThiLopHocSinhVien), strTenMoi, maDe);
            }
            catch (Exception ex)
            {
                status = 1;
                msg = ex.Message;
            }
            makeResponse(context, status, msg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void makeResponse(HttpContext context, int status, string msg)
        {
            string json = JsonConvert.SerializeObject(new { status, msg });
            context.Response.Write(json);
        }

    }
}