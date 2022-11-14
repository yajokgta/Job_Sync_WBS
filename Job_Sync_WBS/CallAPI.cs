using Job_Sync_WBS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS
{
    internal class CallAPI
    {
        public static string apipath = ConfigurationSettings.AppSettings["APIUrl"];
        public static string datefrom = ConfigurationSettings.AppSettings["DATE_FROM"];
        public static string dateto = ConfigurationSettings.AppSettings["DATE_TO"];
        public async Task<string> getAllSAP()
        {
            string respones = null;
            try
            {
                /*string json = File.ReadAllText("D:\\response.json");
                var playerList = JsonConvert.DeserializeObject<SAPModel.Root>(json);*/
                Console.WriteLine("Start Call API : " + DateTime.Now);
                Console.WriteLine("DATE_FROM : " + datefrom);
                Console.WriteLine("DATE_TO : " + dateto);
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(30);
                WriteLogFile.writeLogFile("Process...10%");
                Console.WriteLine("Process...10%");
                
                var body = new
                {
                    I_DATA = new
                    {
                        DATE_FROM = datefrom,
                        DATE_TO = dateto
                    }
                };
                WriteLogFile.writeLogFile("Process...20%");
                Console.WriteLine("Process...20%");
                client.DefaultRequestHeaders.Add("Authorization", "Basic TU9MU0VSVklDRTppbml0MTIzNA==");
                var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                WriteLogFile.writeLogFile("Process...30%");
                Console.WriteLine("Process...30%");
                var respone = client.PostAsync("http://203.146.13.162:9010/e-expense/ZEX_M30?sap-client=900&format=json&sap-language=TH", content);
                respone.Wait();
                var result = respone.Result;
                var massage = result.Content.ReadAsStringAsync().Result;
                WriteLogFile.writeLogFile("Call API SUCCESS");
                Console.WriteLine("Call API SUCCESS");
                WriteLogFile.writeLogFile("Process...40%");
                Console.WriteLine("Process...40%");
                respones = massage;
                WriteLogFile.writeLogFile("Process...50%");
                Console.WriteLine("Process...50%");      
            }
            catch(Exception e)
            {
                WriteLogFile.writeLogFile(e.ToString());
                Console.WriteLine(e);
            }
            return respones;
        }
    }
}
