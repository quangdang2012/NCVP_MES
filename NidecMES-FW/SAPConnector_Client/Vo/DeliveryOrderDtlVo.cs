using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class DeliveryOrderDtlVo : ValueObject
    {
        public string SoNumber { get; set; }
        public string SoItem { get; set; }
        public int OrderQuantity { get; set; }
        public int QuantityStock { get; set; }
        public int QuantitySales { get; set; }
        public string DoNo { get; set; }
        public string DeliveryItemNumber { get; set; }
        public string BatchNo { get; set; }
        public string MaterialNumber { get; set; }
        public string MaterialType { get; set; }
        public string MaterialTypeDesc { get; set; }
        public string MaterialDesc { get; set; }
        public string MaterialStatisticsGroup { get; set; }
        public string MaterialStatisticsGroupDesc { get; set; }
        public string MaterialGroup { get; set; }
        public string MaterialGroupDesc { get; set; }
        public DateTime PickingDate { get; set; }
        public DateTime PickingTime { get; set; }
        public string StorageLocation { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        public int PickedQuantity { get; set; }


    }
}
