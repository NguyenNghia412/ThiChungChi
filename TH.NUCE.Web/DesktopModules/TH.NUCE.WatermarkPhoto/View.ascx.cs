using System;
using System.Data;
using DotNetNuke.Entities.Modules;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework;
using DotNetNuke.Services.FileSystem;
using Image = System.Drawing.Image;
using System.Drawing.Drawing2D;

namespace TH.NUCE.Web.WatermarkPhoto
{
    public partial class View : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //IFolderInfo obj = DotNetNuke.Services.FileSystem.FolderManager.Instance.GetFolder(this.PortalId, "UploadFile");
                IFolderInfo obj = DotNetNuke.Services.FileSystem.FolderManager.Instance.GetFolder(this.PortalId, "");
                System.Collections.Generic.IEnumerable<IFolderInfo> objs =DotNetNuke.Services.FileSystem.FolderManager.Instance.GetFolders(obj);
                foreach (var test in objs)
                {
                    ListItem listItem=new ListItem();
                    listItem.Text = test.FolderName;
                    listItem.Value = test.FolderPath;
                    ddlFoldes.Items.Add(listItem);
                }
                ddlFoldes.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
             
            // HERE we will upload image with watermark LOGO
            string fileName = txtName.Text.Trim();
            
            if(fileName.Equals(""))
                fileName = string.Format("{0}_{1}_{2}_{3}_{4}", DateTime.Now.Year, DateTime.Now.Day, DateTime.Now.Month,Path.GetFileNameWithoutExtension(FU1.FileName), Path.GetExtension(FU1.FileName));
            else
            {
                fileName = string.Format("{0}.{1}", fileName, "jpg");
            }
            Image upImage = Image.FromStream(FU1.PostedFile.InputStream);
            Image logoImage = Image.FromStream(FULogo.PostedFile.InputStream);
            int iMaxHightImage = 1000;
            int iMaxHightWatermark = 50;
            int iMaxWidthImage = 1000;
            int iMaxWidthWatermark = 50;
            int.TryParse(txtMaxHightImage.Text.Trim(), out iMaxHightImage);
            int.TryParse(txtMaxHightWatermark.Text.Trim(), out iMaxHightWatermark);
            int.TryParse(txtMaxWidthImage.Text.Trim(), out iMaxWidthImage);
            int.TryParse(txtMaxWidthWatermark.Text.Trim(), out iMaxWidthWatermark);
            logoImage = RezizeImage(logoImage, iMaxWidthWatermark, iMaxHightWatermark);
            upImage = RezizeImage(upImage, iMaxWidthImage, iMaxHightImage);
            using (Graphics g = Graphics.FromImage(upImage))
            {
                Bitmap transparentGhost = new Bitmap(logoImage.Width, logoImage.Height);
                Graphics transGraphics = Graphics.FromImage(transparentGhost);
                ColorMatrix tranMatrix = new ColorMatrix();
                tranMatrix.Matrix33 = 0.25F; //this is the transparency value, tweak this to fine tuned results.

                ImageAttributes transparentAtt = new ImageAttributes();
                transparentAtt.SetColorMatrix(tranMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                transGraphics.DrawImage(logoImage, new Rectangle(0, 0, transparentGhost.Width, transparentGhost.Height), 0, 0, transparentGhost.Width, transparentGhost.Height, GraphicsUnit.Pixel, transparentAtt);
                transGraphics.Dispose();
                //g.DrawImage(logoImage, new Point(upImage.Width - logoImage.Width - 10, upImage.Height-logoImage.Height-10));
                g.DrawImage(logoImage, upImage.Width - logoImage.Width - 10, upImage.Height - logoImage.Height - 10, logoImage.Width, logoImage.Height);
                
               // upImage.Save(Path.Combine(Server.MapPath("/Portals/0/UploadFile"), fileName));
               // Image1.ImageUrl = "/Portals/0/UploadFile" + "//" + fileName;
                
                IFolderInfo obj=new FolderInfo();
                
                obj = DotNetNuke.Services.FileSystem.FolderManager.Instance.GetFolder(this.PortalId,ddlFoldes.SelectedValue);

                var ms = new MemoryStream();
                upImage.Save(ms, ImageFormat.Jpeg);
                ms.Position = 0;
                DotNetNuke.Services.FileSystem.FileManager.Instance.AddFile(obj, fileName, ms, true);
                Image1.ImageUrl = "/Portals/"+this.PortalId.ToString()+"/" + ddlFoldes.SelectedValue + "//" + fileName;
            }
        }
        private Image RezizeImage(Image img, int maxWidth, int maxHeight)
        {
            if (img.Height < maxHeight && img.Width < maxWidth) return img;
            using (img)
            {
                Double xRatio = (double)img.Width / maxWidth;
                Double yRatio = (double)img.Height / maxHeight;
                Double ratio = Math.Max(xRatio, yRatio);
                int nnx = (int)Math.Floor(img.Width / ratio);
                int nny = (int)Math.Floor(img.Height / ratio);
                Bitmap cpy = new Bitmap(nnx, nny, PixelFormat.Format32bppArgb);
                using (Graphics gr = Graphics.FromImage(cpy))
                {
                    gr.Clear(Color.Transparent);

                    // This is said to give best quality when resizing images
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    gr.DrawImage(img,
                        new Rectangle(0, 0, nnx, nny),
                        new Rectangle(0, 0, img.Width, img.Height),
                        GraphicsUnit.Pixel);
                }
                return cpy;
            }

        }
    }
}