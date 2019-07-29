using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class DispatchReportItemDtlVo : ValueObject
    {
        public int DispatchReportItemDtlId { get; set; }
        public string DeliveryOrderNo { get; set; }
        public string DeliveryOrderUnit { get; set; }
        public string ItemNo { get; set; }
        public string LotNo { get; set; }
        public int ItemQuantity { get; set; }
        public string BoxNo { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string BarcodeId { get; set; }
        public string StorageLocation { get; set; }
        public string IsDeleted { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public string SapSubmitStatus { get; set; }
        public string SapReturnResult { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }
        public bool SapSubmitOnly { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsLockingPeriod { get; set; }

        public List<DispatchReportItemDtlVo> DipatchReportItemDetailsList= new List<DispatchReportItemDtlVo>();
        public List<SapMessageVo> DispatchReportResultMessageList { get; set; }

    }
}
