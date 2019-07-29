using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class PoGoodReceiptVo : ValueObject
    {
        public DateTime DocumentDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string DeliveryNote { get; set; }
        public string Batch { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string POItem { get; set; }
        public string Material { get; set; }
        public decimal Quantity { get; set; }
        public string SupplierLotNo { get; set; }
      
        public List<PoGoodReceiptVo> PoGoodReceiptList { get; set; }
        public List<SapMessageVo> PoGoodReceiptResultMessageList { get; set; }

    }
}
