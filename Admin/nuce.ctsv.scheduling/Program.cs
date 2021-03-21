using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace nuce.ctsv.scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            common.WriteLog("Start");
            while (true)
            {
                //Lấy dữ liệu từ bảng tin nhắn
                string strSql = string.Format(@"SELECT *
  FROM [dbo].[AS_Academy_Student_TinNhan] where Status=1 ");

                DataTable dt = Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteDataset(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strSql).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    common.WriteLog(dt.Rows[i]["receiverEmail"].ToString());
                    EmailParam1 param1 = new EmailParam1();
                    param1.data = dt.Rows[i]["Content"].ToString();
                    EmailData[] eDatas = new EmailData[1];
                    eDatas[0] = new EmailData();

                   eDatas[0].data = param1;
                    eDatas[0].email = dt.Rows[i]["receiverEmail"].ToString();
                    EmailTemplate eTemplate = new EmailTemplate();
                    eTemplate.emails = eDatas;
                    eTemplate.template = "1";
                    eTemplate.subject = string.Format("{0}", dt.Rows[i]["Title"].ToString()); 
                    eTemplate.email_identifier = "emails";
                    //eTemplate.datetime = DateTime.Now;
                    eTemplate.send_later_email = "0";
                    eTemplate.timezone = "7";
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://mail.amtool.vn/api/");
                        var serializer = new JavaScriptSerializer();
                        var serializedResult = serializer.Serialize(eTemplate);
                        var postTask = client.PostAsync("send-email", new StringContent(serializedResult, System.Text.Encoding.UTF8, "application/json"));
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {

                            var readTask = result.Content.ReadAsStringAsync();
                            readTask.Wait();

                            var insertedStudent = readTask.Result;

                            Console.WriteLine("Receive {0}", readTask.Result);
                            strSql = string.Format(@"Update [dbo].[AS_Academy_Student_TinNhan] set Status=2 where Id={0}", dt.Rows[i]["ID"].ToString());

                            Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(nuce.web.data.Nuce_Common.ConnectionString, CommandType.Text, strSql);
                        }
                        else
                        {
                            Console.WriteLine(result.StatusCode);
                        }
                    }

               
                }
                common.WriteLog("Waiting !!!!!");
                Thread.Sleep(60*2000);
            }
            common.WriteLog("Finish");
            Console.ReadLine();
        }
    }
    public class EmailTemplate
    {
        public EmailData[] emails { get; set; }
        public string template { get; set; }
        public string subject { get; set; }
        public string email_identifier { get; set; }
        //public DateTime datetime { get; set; }
        public string send_later_email { get; set; }
        public string timezone { get; set; }
    }
    public class EmailData
    {
        public string email { get; set; }
        public EmailParam1 data { get; set; }
    }
    public class EmailParam1
    {
        public string data { get; set; }
    }
}
