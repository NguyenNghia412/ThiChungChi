using System;
using System.Windows.Forms;

namespace AppConnectDaoTao
{
    public partial class frmLecturerClassRoom : Form
    {
        public frmLecturerClassRoom()
        {
            InitializeComponent();
        }

        private void btnCUpdate_Click(object sender, EventArgs e)
        {
            string strLecturerCode = txtLecturerCode.Text.Trim();
            string strClassRoomCode = txtClassRoomCode.Text.Trim();
            nuce.web.data.Nuce_DanhGiaGiangVien.InsertAcademy_C_Lecturer_ClassRoom(strClassRoomCode, strLecturerCode, 1);
            MessageBox.Show("OK");
        }
    }
}
