namespace TH.NUCE.Web
{
    /// <summary>
    /// Lớp DataProcessingProvider cung cấp các hàm tương tác với dữ liệu thô.
    /// </summary>
    public sealed partial class DataProcessingProvider
    {
        /// <summary>
        /// Lấy vào một giá trị string và ép kiểu về int.
        /// </summary>
        /// <param name="requestValue">Giá trị cần ép kiểu.</param>
        /// <returns>Luôn trả về một giá trị int. Trả về -1 nếu không ép được kiểu.</returns>
        public static int GetProcessedInt(string requestValue)
        {
            int returnValue;
            if (requestValue == null)
            {
                returnValue = -1;
            }
            else if (!int.TryParse(requestValue.ToString(), out returnValue))
            {
                returnValue = -1;
            }
            return returnValue;
        }

        /// <summary>
        /// Lấy vào một giá trị string và ép kiểu về int.
        /// </summary>
        /// <param name="requestValue">Giá trị cần ép kiểu.</param>
        /// <param name="alternativeValue">Giá trị thay thế.</param>
        /// <returns>Luôn trả về một giá trị int. Trả về giá trị thay thế nếu không ép được kiểu.</returns>
        public static int GetProcessedInt(string requestValue, int alternativeValue)
        {
            int returnValue;
            if (requestValue == null)
            {
                returnValue = alternativeValue;
            }
            else if (!int.TryParse(requestValue.ToString(), out returnValue))
            {
                returnValue = alternativeValue;
            }
            return returnValue;
        }

        /// <summary>
        /// Lấy vào một giá trị string và ép kiểu về double.
        /// </summary>
        /// <param name="requestValue">Giá trị cần ép kiểu.</param>
        /// <param name="alternativeValue">Giá trị thay thế.</param>
        /// <returns>Luôn trả về một giá trị int. Trả về giá trị thay thế nếu không ép được kiểu.</returns>
        public static double GetProcessedDouble(string requestValue, double alternativeValue)
        {
            double returnValue;
            if (requestValue == null)
            {
                returnValue = alternativeValue;
            }
            else if (!double.TryParse(requestValue.ToString(), out returnValue))
            {
                returnValue = alternativeValue;
            }
            return returnValue;
        }

        /// <summary>
        /// Lấy vào một giá trị string và trả về một giá trị string, đảm bảo không xảy ra trường hợp giá trị bị null.
        /// </summary>
        /// <param name="requestValue">Giá trị cần ép kiểu.</param>
        /// <returns>Luôn trả về một giá trị string. Trả về chuỗi rỗng nếu giá trị truyền vào null.</returns>
        public static string GetProcessedString(string requestValue)
        {
            if (requestValue == null)
            {
                return "";
            }
            else
            {
                return requestValue;
            }
        }
    }
}