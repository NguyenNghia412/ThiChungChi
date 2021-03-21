using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ionic.Zip;
using System.IO;

namespace test_zip
{
    public partial class CreateZip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void bttnupload_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
                string pathname = Server.MapPath("~/zipa/" + filename);
                FileUpload.SaveAs(pathname);
                lbltxt.Text = "File Upload Successfully";
            }
        }
        protected void bttnzip_Click(object sender, EventArgs e)
        {
            try
            {
                string pathname = Server.MapPath("~/zipa/");
                string[] filename = Directory.GetFiles(pathname);
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddFiles(filename, "file");
                    zip.Save(Server.MapPath("~/zipa.zip"));
                    lbltxt.Text = "Zip File Created";
                }
            }
            catch (Exception ex)
            {
                lbltxt.Text = ex.Message;
            }
        }
    }
}