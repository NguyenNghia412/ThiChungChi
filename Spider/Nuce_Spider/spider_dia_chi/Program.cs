using Analayza.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebSpiderLib;

namespace spider_dia_chi
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i < 100; i++)
            //{
            //    ArrayList ALMatch = GetContent(i, 1);
            //    foreach (string temp in ALMatch)
            //    {
            //        string temp1 = temp.Trim().Replace(" ", "");
            //        temp1 = Regex.Replace(temp1, ".*<ahref=\"", "");
            //        temp1 = Regex.Replace(temp1, "\"title=\".*", "");

            //        string sql = string.Format(@"
            //        if(not exists(select 1 from [dbo].[nuce_link] where Link='{1}'))
            //        Begin
            //                INSERT INTO [dbo].[nuce_link]
            //                    ([Name],[Link],[Pattern],[PatternID],[Type],[Status],[Parent],[Level],[isGetContent]) 
            //                    VALUES ('{0}','{1}','{2}',{3},1,1,-1,1,1)
            //        end;", temp1, "https://batdongsan.com.vn" + temp1, "< div class=\"p-title\">(?<ITEM>[\\w\\W]*?)</div>", -1);
            //        Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(common.GetConnection(), CommandType.Text, sql);
            //    }
            //}
            DateTime temp = DateTime.ParseExact("11/02/16", "dd/MM/yy", CultureInfo.InvariantCulture);
            Console.WriteLine(temp);

            DateTime dateValue;
            string dateString = "2/16/2008 03:00:00 PM";
            try
            {
                dateValue = DateTime.Parse(dateString);
                Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}'.", dateString);
            }
            Console.WriteLine((int)DateTime.Now.DayOfWeek);
            Console.Write(DateTime.Now.Hour);


           
            Console.ReadLine();
        }
        protected static ArrayList GetContent(int strInput, int Start)
        {
            System.Threading.Thread.Sleep(10000);
            MyWebClient wc = new MyWebClient();
            string strURL = string.Format("https://batdongsan.com.vn/nha-dat-can-mua/p{0}", strInput);
            common.WriteLog(strURL);
            //string strURL = string.Format("https://batdongsan.com.vn/nha-dat-ban/p{0}", strInput);
            string result = wc.DownloadString(strURL, false, "UTF-8");
            string strPatternItem = "<div class=\"p-title\">(?<ITEM>[\\w\\W]*?)</div>";
            string strTest = WebRegEx.GetValueByPattern(result, strPatternItem, "ITEM");
            ArrayList ALMatch = WebRegEx.GetRepeatingValuesByPattern(result, strPatternItem, "ITEM");
            return ALMatch;
        }
    }
    public class ViduHttpClient
    {
        HttpClient _httpClient = null;
        public HttpClient httpClient => _httpClient ?? (new HttpClient());

        // Post Json Data
        public async Task<string> SendAsyncJson(string url, string json)
        {
            Console.WriteLine($"Starting connect {url}");
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                request.Content = httpContent;
                var response = await httpClient.SendAsync(request);
                var rcontent = await response.Content.ReadAsStringAsync();
                return rcontent;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
