using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConnectDaoTao
{
    public static class Utils
    {
        /*
        public static int tabCheckCommon = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TABCOMMON"]);
        public static int moduleCheckCommon = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["MODCOMMON"]);

        public static int tabCheckQlpm = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["TABQLPM"]);
        public static int moduleCheckQlpm = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["MODQLPM"]);
        */
        #region Syn phong Dao Tao
        /*
        1. Dong bo lich hoc
        2. Dong bo lich thi
        3. Lich hoc dong bo bi thay doi
        4. Lich thi dong bo bi thay doi
        5. Lich hoc dang ki
        6. Lich thi dang ki
        */
        public static int synTypeLichHoc = 1;
        public static int synTypeLichThi = 2;
        public static int synTypeLichHocThayDoi = 3;
        public static int synTypeLichThiThayDoi = 4;
        public static int synTypeLichHocTuDangKi = 5;
        public static int synTypeLichThiTuDangKi = 6;
        public static int synTypeGVLichHocTuDangKi = 7;
        public static int synTypeGVLichThiTuDangKi = 8;
        #endregion
        #region khaosat
        public static string session_cuusinhvien = "session_cuusinhvien";
        public static string session_kithi_lophoc_cuusinhvien = "session_kithi_lop_hoc_cuusinhvien";
        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        #endregion

        #region Role
        public static string role_Admin = "Administrators";
        public static string role_QuanTriThongTinChung = "Quản trị thông tin chung";
        public static string role_QuanTriPhongMay = "Quản trị phòng máy";
        public static string role_GiangVien = "Giảng viên";
        public static string role_GiangVien_DangKiLichPhongMay = "GV_DKLPM";
        #endregion
        #region Random
        public static int getRandom(int begin, int end)
        {
            Random rnd = new Random();
            return rnd.Next(begin, end); //
        }
        #endregion

    }
}
