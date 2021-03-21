﻿using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.Services;
namespace nuce.web.commons
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UpdateLopHoc1 : CoreHandlerCommonAdmin
    {
        public override void WriteData(HttpContext context)
        {
            /*
            @LopHocID int,
            @MonHocID int,
            @UserID int,
            @BlockID int,
            @Ma varchar(20),
            @Ten nvarchar(100),
            @SoChi int,
            @MoTa nvarchar(1000),
            @NgayBatDau datetime,
            @NgayKetThuc datetime*/
            context.Response.ContentType = "text/plain";
            if ((context.Request["lophocid"] != null) && (context.Request["monhocid"] != null)
        && (context.Request["blockid"] != null) &&
        (context.Request["ma"] != null) &&
        (context.Request["ten"] != null) &&
        (context.Request["sotinchi"] != null) &&
         (context.Request["mota"] != null))
            {
                int lophocid = int.Parse(context.Request["lophocid"]);
                int monhocid = int.Parse(context.Request["monhocid"]);
                int blockid = int.Parse(context.Request["blockid"]);
                string ma = context.Request["ma"];
                string ten = context.Request["ten"];
                string strNgayBatDau = context.Request["ngaybatdau"];
                string strNgayKetThuc = context.Request["ngayketthuc"];

                DateTime dtNgayBatDau;
                try
                {
                    dtNgayBatDau = DateTime.ParseExact(strNgayBatDau, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    dtNgayBatDau = DateTime.Now;
                }
                DateTime dtNgayKetThuc;
                try
                {
                    dtNgayKetThuc = DateTime.ParseExact(strNgayKetThuc, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    dtNgayKetThuc = DateTime.Now;
                }

                int sotinchi = int.Parse(context.Request["sotinchi"]);
                string mota = context.Request["mota"];
                if (data.dnn_NuceCommon_MonHoc.checkNguoiDungAndMonHoc(this.objUserInfo.UserID, monhocid) > 0)
                {
                    data.dnn_NuceCommon_LopHoc.update(lophocid, monhocid, this.objUserInfo.UserID, blockid, ma, ten, sotinchi, mota, dtNgayBatDau,
                    dtNgayKetThuc);
                    context.Response.Write("1");
                }
                context.Response.Write("0");
            }
            else
            {
                context.Response.Write("-1");
            }
            context.Response.Flush(); // Sends all currently buffered output to the client.
            context.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
            context.ApplicationInstance.CompleteRequest();
        }
    }
}
