using Job_Sync_WBS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Job_Sync_WBS
{

    public class CallAPI
    {
        public static string datefrom = ConfigurationSettings.AppSettings["DATE_FROM"];
        public static string dateto = ConfigurationSettings.AppSettings["DATE_TO"];
        public static string BaseAPI = ConfigurationSettings.AppSettings["BaseAPI"];
        public static string Module = ConfigurationSettings.AppSettings["Module"];
        public static string SAPClient = ConfigurationSettings.AppSettings["sap-client"];
        public static string Authorization = ConfigurationSettings.AppSettings["Authorization"];
        public async Task<string> getAllSAP()
        {
            string respones = null;
            try {
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
                string apiPath = $"{BaseAPI}/e-expense/{Module}?sap-client={SAPClient}&format=json&sap-language=TH";
                WriteLogFile.writeLogFile("Process...20%");
                Console.WriteLine("Process...20%");
                WriteLogFile.writeLogFile($"Authorization : {Authorization}");
                WriteLogFile.writeLogFile($"apiPath : {apiPath}");
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseAPI);
                    client.Timeout = TimeSpan.FromMinutes(10);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", Authorization);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    JavaScriptSerializer java = new JavaScriptSerializer();
                    java.MaxJsonLength = 2147483644;
                    string json = java.Serialize(body);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    WriteLogFile.writeLogFile("Process...30%");
                    Console.WriteLine("Process...30%");
                    var response = await client.PostAsync(apiPath, content);
                    WriteLogFile.writeLogFile("Call API SUCCESS");
                    Console.WriteLine("Call API SUCCESS");
                    WriteLogFile.writeLogFile("Process...40%");
                    Console.WriteLine("Process...40%");

                    respones = await response.Content.ReadAsStringAsync();
                    WriteLogFile.writeLogFile("Process...50%");
                    Console.WriteLine("Process...50%");
                }

            }
            catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
            {
                WriteLogFile.writeLogFile("API call timed out.");
                Console.WriteLine("API call timed out.");
            }
            catch (Exception ex)
            {
                WriteLogFile.writeLogFile($"An error occurred: {ex.Message}");
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return respones;
        }
    }
}
