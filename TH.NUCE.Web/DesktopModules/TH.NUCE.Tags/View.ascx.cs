using System;
using System.Data;
using DotNetNuke.Entities.Modules;
namespace TH.NUCE.Web.Tags
{
    public partial class View : PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["EditType"] != null && Request.QueryString["EditType"] != "")
                {
                    string strType = Request.QueryString["EditType"];
                    txtType.Text = strType;
                    txtGroup.Text = "1";
                    divAnnouce.InnerHtml = "Thêm mới tags"; 
                    if (strType == "edit")
                    {
                        //Lấy dữ liệu từ server để nhét vào các control
                        //THCore_CM_GetTag
                        divAnnouce.InnerHtml = "Chỉnh sửa tags"; 
                        int iID = int.Parse(Request.QueryString["id"]);
                        DataTable tblTable = DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_CM_GetTag", iID).Tables[0];
                        if (tblTable.Rows.Count > 0)
                        {
                            txtName.Text = tblTable.Rows[0]["Name"].ToString();
                            txtID.Text = iID.ToString();
                            txtGroup.Text = tblTable.Rows[0]["TagGroupId"].ToString();
                        }
                    }
                    else if(strType == "delete")
                    {
                        int iID = int.Parse(Request.QueryString["id"]);
                        DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("THCore_TM_UpdateStatusTags", iID,0);
                        returnMain();
                    }
                }
                else
                {
                    divAnnouce.InnerHtml = "";
                    lblName.Visible = false;
                    txtName.Visible = false;
                    btnUpdate.Visible = false;
                    btnQuayLai.Visible = false;
                    displayList();
                }
            }
        }

        private void displayList()
        {
            DataTable tblTable = DotNetNuke.Data.DataProvider.Instance().ExecuteDataSet("THCore_CM_GetTags", this.PortalId, 3).Tables[0];
            string strTable = "<div>" +
                              "<div style='font-weight:bold; font-size:16px; color:#333; float:left; padding-left:20px;'>Quản lý Tags</div>" +
                              "<div class='welcome_b'></div>" +
                              "<div class='nd fl'>" +
                              "<div class='noidung'>";
            strTable +="<div class='nd_t fl'>";
            strTable += string.Format("<div class='nd_t1 fl'>{0}</div>", "STT");
            strTable += string.Format("<div class='nd_t2 fl'>{0}</div>", "Tên");
            strTable += string.Format("<div class='nd_t3 fl'>{0}</div>", "Sửa");
            strTable += string.Format("<div class='nd_t3 fl'>{0}</div>", "Thêm mới");
            strTable += string.Format("<div class='nd_t3 fl'>{0}</div>", "Xóa");
            strTable += "</div>";
                    strTable += "<div class='nd_b fl'>";
                    for (int i = 0; i < tblTable.Rows.Count; i++)
                    {
                        strTable += " <div class='nd_b1 fl'>";
                        strTable += string.Format("<div class='nd_t1 fl'>{0}</div>", i);
                        strTable += string.Format("<div class='nd_t2 fl'>{0}</div>", tblTable.Rows[i]["Name"].ToString());
                        strTable += string.Format("<div class='nd_t3 fl'><a href='/tabid/{0}/default.aspx?EditType=edit&&id={1}'>Sửa</a></div>", this.TabId, tblTable.Rows[i]["TagId"].ToString());
                        strTable += string.Format("<div class='nd_t3 fl'><a href='/tabid/{0}/default.aspx?EditType=insert&&id={1}'>Thêm mới</a></div>", this.TabId, tblTable.Rows[i]["TagId"].ToString());
                        strTable += string.Format("<div class='nd_t3 fl'><a href='/tabid/{0}/default.aspx?EditType=delete&&id={1}'>Xóa</a></div>", this.TabId, tblTable.Rows[i]["TagId"].ToString());
                        strTable += "</div>";
                    }
                    strTable += "</div>";
                 strTable += "</div>";
                 strTable += "</div>";
            strTable += "</div>";
            divConent.InnerHtml = strTable;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strType = txtType.Text;
            string strName = txtName.Text;
            int iGroupTags = int.Parse(txtGroup.Text);
            if (strType == "insert")
            {
                DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("THCore_TM_InsertTags", iGroupTags, strName, "","","");
                returnMain();
            }
            else
            {
                if (strType == "edit")
                {
                    int iID = int.Parse(txtID.Text);
                    DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("THCore_TM_UpdateTags",iID, iGroupTags, strName, "", "", "");
                    returnMain();
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            returnMain()
            ;
        }
        private  void returnMain()
        {
              Response.Redirect(string.Format("/tabid/{0}/default.aspx?Type=100", this.TabId));
        }
    }
}