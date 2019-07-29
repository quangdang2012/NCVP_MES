using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class PurchaseOrderInVo : ValueObject
    {
        public string Material { get; set; }
        public string MaterialName { get; set; }
        public string Supplier { get; set; }
        public string SupplierName { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int OrderQuantity { get; set; }
        public int OpenQuantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public string Unit { get; set; }

        public string EINFromDate { get; set; }
        public string EINToDate { get; set; }

        public string BEFromDate { get; set; }
        public string BEToDate { get; set; }

        public List<string> LIFNRValueList { get; set; }

        public List<string> EBELNValueList { get; set; }

        public List<string> MATNRValueList { get; set; }

        public string Status { get; set; }
        public List<PurchaseOrderInVo> PurchaseOrderList { get; set; }
        public List<SapMessageVo> PurchaseOrderResultMessageList { get; set; }

    }
}
