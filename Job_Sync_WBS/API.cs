using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS
{
    public class API
    {
        public static string apipath = ConfigurationSettings.AppSettings["APIUrl"];
        public static string datefrom = ConfigurationSettings.AppSettings["DATE_FROM"];
        public static string dateto = ConfigurationSettings.AppSettings["DATE_TO"];
        public static async Task<string> post(string subUri)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(subUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Basic TU9MU0VSVklDRTppbml0MTIzNA==");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var body = new
                    {
                        I_DATA = new
                        {
                            DATE_FROM = datefrom,
                            DATE_TO = dateto
                        }
                    };
                    client.Timeout = new TimeSpan(0, 20, 0);
                    

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(subUri, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
