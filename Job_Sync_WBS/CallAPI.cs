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
        public static List<INFWBSElement> getAllSAP()
        {
            List<INFWBSElement> respones = new List<INFWBSElement>();
            try
            {
                /*string json = File.ReadAllText("D:\\response.json");
                var playerList = JsonConvert.DeserializeObject<SAPModel.Root>(json);*/
                Console.WriteLine("Start Call API : " + DateTime.Now);
                Console.WriteLine("DATE_FROM : " + datefrom);
                Console.WriteLine("DATE_TO : " + dateto);
                HttpClient client = new HttpClient();
                Console.WriteLine("Process...");
                List<INFWBSElement> customer = new List<INFWBSElement>();
                var body = new
                {
                    I_DATA = new
                    {
                        DATE_FROM = datefrom,
                        DATE_TO = dateto
                    }
                };
                client.DefaultRequestHeaders.Add("Authorization", "Basic TU9MU0VSVklDRTppbml0MTIzNA==");
                var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
                var respone = client.PostAsync("http://203.146.13.162:9010/e-expense/ZEX_M30?sap-client=900&format=json&sap-language=TH", content);
                respone.Wait();
                var result = respone.Result;
                var message = result.Content.ReadAsStringAsync().Result;
                var sapmodel = JsonConvert.DeserializeObject<SAPModel.Root > (message);
                foreach (var sap in sapmodel.E_DATA)
                {
                    INFWBSElement sapmap = new INFWBSElement
                    {
                        WBS_CODE = sap.WBS,
                        DESC1 = sap.DESC,
                        COM_CODE = sap.COM_CODE,
                        CreatedDate = Convert.ToDateTime(sap.CREATE_DATE),
                        BUSINESS_AREA = sap.BUSINESS_AREA,
                        Year = sap.YEAR,
                        CostCenter = sap.COSTCENTER,
                        CreatedBy = "SYSTEM",
                        ModifiedBy = "SYSTEM",
                        ModifiedDate = DateTime.Now,
                        IsActive = true,
                        SAPCode = true,
                        DESC2 = string.Empty
                    };
                    customer.Add(sapmap);
                }
                Console.WriteLine("Call API Success : " + DateTime.Now);
                respones = customer;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return respones;



        }
    }
}
