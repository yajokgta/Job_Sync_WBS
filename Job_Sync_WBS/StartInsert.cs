using Job_Sync_WBS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Job_Sync_WBS
{
    internal class StartInsert
    {
        public static string constr = ConfigurationSettings.AppSettings["ConnectionString"];
        public async Task insertDB()
        {
            SqlBulkCopy copy = new SqlBulkCopy(constr);
            CallAPI sap = new CallAPI();
            /*string json = File.ReadAllText("D:\\response.json");*/
            /*var playerList = JsonConvert.DeserializeObject<SAPModel.Root>(json);*/
            List<INFWBSElementModel> custommodel = new List<INFWBSElementModel>();
            /*List<INFWBSElement> freezena = new List<INFWBSElement>();*/
            SinghaDbDataContext db = new SinghaDbDataContext(constr);
            try
            {
                db.Connection.Open();
                db.Connection.Close();
                WriteLogFile.writeLogFile("DB Connection = Online");
                Console.WriteLine("DB Connection = Online");
            }
            catch(Exception e)
            {
                WriteLogFile.writeLogFile("Connect DataBase Fail..! : "+ e);
                Console.WriteLine("Connect DataBase Fail..!");
            }
            var freezena = db.INFWBSElements.Where(x => x.DESC1 == "N/A").ToList();
            foreach (var freez in freezena)
            {
                INFWBSElementModel freezmodel = new INFWBSElementModel
                {
                    WBS_CODE = freez.WBS_CODE,
                    DESC1 = freez.DESC1,
                    COM_CODE = freez.COM_CODE,
                    BUSINESS_AREA = freez.BUSINESS_AREA,
                    DESC2 = freez.DESC2,
                    CostCenter = freez.CostCenter,
                    IsActive = freez.IsActive.ToString(),
                    SAPCode = freez.SAPCode.ToString(),
                    Year = freez.Year,
                    CreatedDate = DateTime.Now.ToString("yyyy/MM/dd h:mm:ss", CultureInfo.InvariantCulture),
                    ModifiedDate = DateTime.Now.ToString("yyyy/MM/dd h:mm:ss"),
                    CreatedBy = "SYSTEM",
                    ModifiedBy = "SYSTEM",
                };
                custommodel.Add(freezmodel);
            }

            string message = await sap.getAllSAP();
            var sapmodel = JsonConvert.DeserializeObject<SAPModel.Root>(message);

            foreach (var sapm in sapmodel.E_DATA)
            {
                string dt = Convert.ToDateTime(sapm.CREATE_DATE).ToString("yyyy/MM/dd h:mm:ss");
                INFWBSElementModel sapmap = new INFWBSElementModel
                {
                    WBS_CODE = sapm.WBS,
                    DESC1 = sapm.DESC,
                    COM_CODE = sapm.COM_CODE,
                    CreatedDate = DateTime.ParseExact(dt, "yyyy/MM/dd h:mm:ss", CultureInfo.InvariantCulture).ToString("yyyy/MM/dd h:mm:ss"),
                    BUSINESS_AREA = sapm.BUSINESS_AREA,
                    Year = sapm.YEAR,
                    CostCenter = sapm.COSTCENTER,
                    CreatedBy = "SYSTEM",
                    ModifiedBy = "SYSTEM",
                    ModifiedDate = DateTime.Now.ToString("yyyy/MM/dd h:mm:ss"),
                    IsActive = "true",
                    SAPCode = "true",
                    DESC2 = string.Empty
                };
                
                custommodel.Add(sapmap);
            }

            //var olddata = db.INFWBSElements.ToList();
            WriteLogFile.writeLogFile("DATA RECORD : " + custommodel.Count);
            Console.WriteLine("DATA RECORD : " + custommodel.Count);
            WriteLogFile.writeLogFile("Delete All : "+ db.INFWBSElements.Count());
            Console.WriteLine("Delete All : " + db.INFWBSElements.Count());
            WriteLogFile.writeLogFile("Process...60%");
            Console.WriteLine("Process...60%");
            db.ExecuteCommand("TRUNCATE TABLE [dbo.INFWBSElement]");
            WriteLogFile.writeLogFile("Insert RECORD : " + custommodel.Count);
            Console.WriteLine("Insert RECORD : " + custommodel.Count);
            WriteLogFile.writeLogFile("Process...70%");
            Console.WriteLine("Process...70%");
            try
            {
                WriteLogFile.writeLogFile("Process...80%");
                Console.WriteLine("Process...80%");
                copy.DestinationTableName = "dbo.INFWBSElement";
                copy.WriteToServer(ToDataTable(custommodel));

                WriteLogFile.writeLogFile("Process...90%");
                Console.WriteLine("Process...90%");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                WriteLogFile.writeLogFile(e.ToString());
            }
            WriteLogFile.writeLogFile("Process...100% " + DateTime.Now);
            Console.WriteLine("Process...100% " + DateTime.Now);
            Console.WriteLine("Close (10 Sec) " + DateTime.Now);
            Thread.Sleep(10000);
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
