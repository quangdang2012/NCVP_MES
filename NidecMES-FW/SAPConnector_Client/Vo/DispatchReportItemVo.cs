using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class DispatchReportItemVo : ValueObject
    {
        public int DispatchReportItemId { get; set; }
        public string DeliveryOrderNumber { get; set; }
        public string DeliveryOrderUnit { get; set; }
        public string LotNo { get; set; }
        public string StorageLocation { get; set; }
        public DateTime ActualDeliveryDate { get; set; }
        public string SapSubmitStatus { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        public List<DispatchReportItemVo> DispatchReportItemList { get; set; }
        public List<DispatchReportItemDtlVo> DispatchReportItemDtlList { get; set; }
        public List<SapMessageVo> DispatchReportResultMessageList { get; set; }
    }
}
