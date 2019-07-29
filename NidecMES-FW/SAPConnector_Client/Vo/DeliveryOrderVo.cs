using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class DeliveryOrderVo : ValueObject
    {
        public DateTime CreationDate { get; set; }
        public DateTime DoumentDate { get; set; }
        public string Status { get; set; }
        public int PickedQuantity { get; set; }
        public string DoNo { get; set; }
        public string CustomerPoNumber { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public string SoNo { get; set; }
        public int Amount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DocumentType { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        public List<DeliveryOrderDtlVo> DeliveryOrderDtlList { get; set; }
        public List<SapMessageVo> DeliveryOrderResultMessageList { get; set; }

        //public ValueObjectList<DeliveryOrderDtlVo> DeliveryOrderDtlList { get; set; }
    }
}
