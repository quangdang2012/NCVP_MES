using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class PurchaseOrderOutVo : ValueObject
    {
        public string Material { get; set; }
        public string MaterialName { get; set; }
        public string Supplier { get; set; }
        public string SupplierName { get; set; }
        public string PurchaseOrderNumber { get; set; }

        public string POLineNumber { get; set; }
        public decimal OrderQuantity { get; set; }
        public decimal OpenQuantity { get; set; }
        public decimal ReceivedQuantity { get; set; }
        public decimal SelectQuantity { get; set; }
        public string Unit { get; set; }

        public string EINFromDate { get; set; }
        public string EINToDate { get; set; }

        public string BEFromDate { get; set; }
        public string BEToDate { get; set; }

        public string Status { get; set; }

        public int POCount { get; set; }
        public List<PurchaseOrderOutVo> PurchaseOrderList { get; set; }
        public List<SapMessageVo> PurchaseOrderResultMessageList { get; set; }

    }
}
