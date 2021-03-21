using System.Text.RegularExpressions;
namespace TH.NUCE.Web
{
    /// <summary>
    /// Lớp DataProcessingProvider cung cấp các hàm tương tác với dữ liệu thô.
    /// </summary>
    public sealed partial class DataProcessingProvider
    {
        /// <summary>
        /// Lược bỏ thẻ HTML khỏi một chuỗi HTML.
        /// </summary>
        /// <param name="strTag">Thẻ HTML để hủy khỏi string.</param>
        /// <param name="input">Chuỗi HTML cần lược bỏ thẻ.</param>
        /// <returns>Chuỗi HTML không có thẻ bị loại bỏ.</returns>
        public static string RemoveTag(string strTag, string input)
        {
            string strReg = string.Format("<{0}[^>]*?>|</{1}[^>]*?>", strTag, strTag);
            return System.Text.RegularExpressions.Regex.Replace(input, strReg, "").Trim();
        }

        /// <summary>
        /// Lược bỏ các thẻ script, link, style ra khỏi một chuỗi HTML.
        /// </summary>
        /// <param name="input">Chuỗi HTML cần lược bỏ thẻ.</param>
        /// <returns>Chuỗi HTML không có thẻ bị loại bỏ.</returns>
        public static string RemoveTags(string input)
        {
            string result;
            result = RemoveTag("script", input);
            result = RemoveTag("link", result);
            result = RemoveTag("style", result);
            return result;
        }

        /// <summary>
        /// Kiểm tra xem một chuỗi string có đáp ứng một regular expression không.
        /// </summary>
        /// <param name="value">Chuỗi string cần kiểm tra</param>
        /// <param name="pattern">Regular expression</param>
        /// <returns>True nếu đáp ứng, false nếu không đáp ứng.</returns>
        public static bool ValidateRegEx(string value, string pattern)
        {
            Regex regex = new Regex(pattern);
            if (!value.StartsWith("^"))
            {
                value = "^" + value;
            }
            if (!value.EndsWith("$"))
            {
                value = value + "$";
            }
            return regex.IsMatch(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static string GetValueByPattern(string input, string pattern, string groupName)
        {
            try
            {
                //Extract values from source   
                Match objMatch = Regex.Match(input, pattern, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
                if (!objMatch.Success || objMatch.Groups[groupName] == null)
                {
                    return null;
                }
                else
                {
                    return objMatch.Groups[groupName].Value;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}