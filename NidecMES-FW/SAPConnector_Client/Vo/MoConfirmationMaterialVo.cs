using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class MoConfirmationMaterialVo : ValueObject
    {
        public string OrderNumber { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string MaterialNumber { get; set; }
        public string MaterialOld { get; set; }
        public string AlternateGroup { get; set; }
        public string SapBatchNumber { get; set; }
        public string ProcureType { get; set; }
        public string SapVendor { get; set; }
        public string VendorBatchNumber { get; set; }
        public string MovementType { get; set; }
        public decimal Quantity { get; set; }
        public string StorageLocation { get; set; }
        public string Unit { get; set; }
        public string ItemType { get; set; }

        public List<MoConfirmationMaterialVo> MoConfirmationMaterialListVo = new List<MoConfirmationMaterialVo>();

        public MoConfirmationHeaderVo MoConfirmationHeaderVo = new MoConfirmationHeaderVo();

        public int AffectedCount { get; set; }

    }
}
