using Newtonsoft.Json;
using nuce.web.data;
using nuce.web.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Thi_SV.Handler.nuce.thichungchi
{
    /// <summary>
    /// Summary description for tcc_updatestatus
    /// </summary>
    public class tcc_updatestatus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string body = new StreamReader(context.Request.InputStream).ReadToEnd();
            var data = JsonConvert.DeserializeObject<UpdateStatusThiModel>(body);

            string msg = "ok";
            try
            {
                 dnn_NuceThi_KiThi_LopHoc_SinhVien.updateStatus(data.id, data.status);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(msg);
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