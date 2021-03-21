namespace TH.NUCE.Web
{
    /// <summary>
    /// Lớp DataProcessingProvider cung cấp các hàm tương tác với dữ liệu thô.
    /// </summary>
    public sealed partial class DataProcessingProvider
    {
        /// <summary>
        /// Một chuỗi batchstring có dạng: ,[value1],[value2],[value3,
        /// Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".
        /// Hàm này đảm bảo một chuỗi batchstring luôn bắt đầu bằng limiter và kết thúc bằng limiter, nếu batchstring rỗng hoặc null, trả về giá trị thay thế.
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring</param>
        /// <param name="strLimiter">Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".</param>
        /// <param name="alternativeValue">Giá trị thay thế nếu batchstring null hoặc rỗng.</param>
        /// <returns>Chuỗi batchstring bắt đầu bằng limiter và kết thúc bằng limiter.</returns>
        public static string GetProcessedBatchString(string strBatch, string strLimiter, string alternativeValue)
        {
            //Trường hợp batchstring null.
            if (strBatch == null)
                return alternativeValue;
            //Trường hợp không có limiter.
            if (strLimiter == null)
                return alternativeValue;
            //Trường hợp batstring rỗng
            if (strBatch.Length == 0)
            {
                strBatch = strLimiter;
            }
            //Trường hợp thông thường
            else
            {
                if (!strBatch.StartsWith(strLimiter))
                {
                    strBatch = strLimiter + strBatch;
                }
                if (!strBatch.EndsWith(strLimiter))
                {
                    strBatch = strBatch + strLimiter;
                }
            }

            if (alternativeValue == null)
                alternativeValue = "";

            if (strBatch == strLimiter)
            {
                if (!alternativeValue.StartsWith(strLimiter))
                {
                    alternativeValue = strLimiter + alternativeValue;
                }
                if (!alternativeValue.EndsWith(strLimiter))
                {
                    alternativeValue = alternativeValue + strLimiter;
                }
                return alternativeValue;
            }
            else
                return strBatch;
        }

        /// <summary>
        /// Một chuỗi batchstring có dạng: ,[value1],[value2],[value3,
        /// Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".
        /// Hàm này đảm bảo một chuỗi batchstring luôn bắt đầu bằng dấu "," và kết thúc bằng dấu ",".
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring</param>
        /// <param name="alternativeValue">Giá trị thay thế nếu batchstring null hoặc rỗng.</param>
        /// <returns>Chuỗi batchstring bắt đầu bằng dấu "," và kết thúc bằng dấu ",".</returns>
        public static string GetProcessedBatchString(string strBatch)
        {
            if (strBatch.Length == 0)
            {
                strBatch = ",";
            }
            else
            {
                if (!strBatch.StartsWith(","))
                {
                    strBatch = "," + strBatch;
                }
                if (!strBatch.EndsWith(","))
                {
                    strBatch = strBatch + ",";
                }
            }
            return strBatch;
        }

        /// <summary>
        /// Một chuỗi batchstring có dạng: ,[value1],[value2],[value3,
        /// Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".
        /// Hàm này đảm bảo một chuỗi batchstring luôn bắt đầu bằng limiter và kết thúc bằng limiter.
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring</param>
        /// <param name="strLimiter">Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".</param>
        /// <returns>Chuỗi batchstring bắt đầu bằng limiter và kết thúc bằng limiter.</returns>
        public static string GetProcessedBatchString(string strBatch, string strLimiter)
        {
            if (strBatch == null)
                return "";
            if (strLimiter == null)
                return "";
            if (strBatch.Length == 0)
            {
                strBatch = strLimiter;
            }
            else
            {
                if (!strBatch.StartsWith(strLimiter))
                {
                    strBatch = "," + strBatch;
                }
                if (!strBatch.EndsWith(strLimiter))
                {
                    strBatch = strBatch + strLimiter;
                }
            }
            return strBatch;
        }

        /// <summary>
        /// Lấy ra số phần tử của mảng.
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring.</param>
        /// <param name="strLimiter">Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".</param>
        /// <returns>Số phần tử của mảng.</returns>
        public static int GetBatchStringItemCount(string strBatch, string strLimiter)
        {

            strBatch = GetProcessedBatchString(strBatch, strLimiter);
            string[] strItems;
            strItems = GetBatchStringItems(strBatch, strLimiter);
            if (strItems != null)
                return strItems.Length;
            else
                return 0;
        }

        /// <summary>
        /// Chia một batchstring ra thành nhiều phần tử.
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring.</param>
        /// <param name="strLimiter">Limiter thường là "," nhưng nó cũng có thể là các ký tự khác như ";" hoặc "|".</param>
        /// <returns>Một mảng với các phần tử là phần tử của chuỗi batchstring.</returns>
        public static string[] GetBatchStringItems(string strBatch, string strLimiter)
        {
            strBatch = GetProcessedBatchString(strBatch, strLimiter);
            string[] strItems;
            int i;

            if (strBatch != strLimiter && strBatch != "")
            {
                strBatch = strBatch.Remove(0, 1);
                strBatch = strBatch.Remove(strBatch.Length - 1, 1);
                i = strBatch.IndexOf(strLimiter);
                if (i <= 0)
                {
                    strItems = new string[1];
                    strItems[0] = strBatch;
                }
                else
                {
                    strItems = strBatch.Split(char.Parse(strLimiter));
                }
            }
            else
            {
                strItems = new string[0];
            }
            return strItems;
        }

        /// <summary>
        /// Trả về giá trị int của chuỗi batchstring đơn nhất.
        /// Chuỗi batchstring đơn nhất là chuỗi batchstring chỉ chứa một item, vd: ,1,
        /// </summary>
        /// <param name="strBatch">Chuỗi batchstring.</param>
        /// <returns>Trả về giá trị duy nhất của chuỗi batchstring nếu có thể ép về kiểu int. Nếu không thể, trả về -1.</returns>
        public static int GetSingleBatchStringIntItem(string strBatch)
        {
            strBatch = GetProcessedBatchString(strBatch);
            int ItemId;
            string strTemp;
            strTemp = strBatch.Replace(",", "");
            if (!int.TryParse(strTemp, out ItemId))
            {
                ItemId = -1;
            }
            return ItemId;
        }

        /// <summary>
        /// Dùng một mảng string để tạo ra một batchstring.
        /// </summary>
        /// <param name="strItems">Mảng string.</param>
        /// <param name="limiter">Limiter sẽ được sử dụng.</param>
        /// <returns>Chuỗi batchstring.</returns>
        public static string CreateBatchString(string[] strItems, string limiter)
        {
            int i;
            string strResult = limiter;
            for (i = 0; i < strItems.Length; i++)
            {
                strResult = strResult + strItems[i] + limiter;
            }
            if (strResult == limiter)
                strResult = "";
            return strResult;
        }

        /// <summary>
        /// Dùng một mảng int để tạo ra một batchstring.
        /// </summary>
        /// <param name="strItems">Mảng int.</param>
        /// <param name="limiter">Limiter sẽ được sử dụng.</param>
        /// <returns>Chuỗi batchstring.</returns>
        public static string CreateBatchString(int[] strItems, string limiter)
        {
            int i;
            string strResult = limiter;
            for (i = 0; i < strItems.Length; i++)
            {
                strResult = strResult + strItems[i].ToString() + limiter;
            }
            if (strResult == limiter)
                strResult = "";
            return strResult;
        }
    }


}