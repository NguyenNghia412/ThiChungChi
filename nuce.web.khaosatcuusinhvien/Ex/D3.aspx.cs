using System;

namespace nuce.web.thanhnt
{
    public partial class D3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void btnNopBai_Click(object sender, EventArgs e)
        {
            string strAnswares = txtAnswares.Text;
            string strHoTen = txtHoTen.Text.Trim();
            string strEmail = txtEmail.Text;
            string strTenCoQuan = txtTenCoQuan.Text;
            int iGioiTinh = 1;
            try
            {
                iGioiTinh = int.Parse(rbGioiTinh.SelectedValue.ToString().Trim());
            }
            catch
            {
                iGioiTinh = 1;
            }
            string strDoiTuongTraLoi = rbDoiTuongTraLoi.SelectedValue;
            //nuce.web.data.Nuce_Survey.InsertAS_Edu_Survey_Ext_BaiLam(1, "ThanhNT_PHD", strHoTen, iGioiTinh, strEmail, "", strTenCoQuan, strDoiTuongTraLoi, 3, strAnswares);
            string strStript = string.Format("<script type='text/javascript'>alert('Thời gian khảo sát đã hết, bạn có thể xem nội dung câu hỏi nhưng hệ thống không nhận kết quả khảo sát từ 1/6/2019 !');window.location = '{0}'</script>", Request.RawUrl);
            divScript.InnerHtml = strStript;
            //Response.Redirect(Request.RawUrl);
        }
    }
}