using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Sync_WBS.Model
{
    class INFWBSElementModel
    {
		public int WBS_ID { get; set; }

		public string WBS_CODE { get; set; }

		public string DESC1 { get; set; }

		public string COM_CODE{ get; set; }

		public string BUSINESS_AREA{ get; set; }

		public string DESC2{ get; set; }

		public string CostCenter{ get; set; }

		public string IsActive { get; set; }

		public string SAPCode { get; set; }

		public string Year{ get; set; }

		public string CreatedBy{ get; set; }

		public string CreatedDate { get; set; }

		public string ModifiedBy{ get; set; }

		public string ModifiedDate { get; set; }
	}
}
