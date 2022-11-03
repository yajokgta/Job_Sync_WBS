using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS.Model
{
    class SAPModel
    {
        public class EDATum
        {
            public string WBS { get; set; }
            public string DESC { get; set; }
            public string CREATE_DATE { get; set; }
            public string COM_CODE { get; set; }
            public string BUSINESS_AREA { get; set; }
            public string YEAR { get; set; }
            public string COSTCENTER { get; set; }
            public string PLANT { get; set; }
        }

        public class ERETURN
        {
            public string TYPE { get; set; }
            public string ID { get; set; }
            public string NUMBER { get; set; }
            public string MESSAGE { get; set; }
            public string LOG_NO { get; set; }
            public string LOG_MSG_NO { get; set; }
            public string MESSAGE_V1 { get; set; }
            public string MESSAGE_V2 { get; set; }
            public string MESSAGE_V3 { get; set; }
            public string MESSAGE_V4 { get; set; }
            public string PARAMETER { get; set; }
            public int ROW { get; set; }
            public string FIELD { get; set; }
            public string SYSTEM { get; set; }
        }

        public class Root
        {
            public List<EDATum> E_DATA { get; set; }
            public List<ERETURN> E_RETURN { get; set; }
        }
    }
}
