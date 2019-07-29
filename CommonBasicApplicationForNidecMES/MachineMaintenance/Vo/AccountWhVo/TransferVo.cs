using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class TransferVo : ValueObject
    {
        /// <summary>
        /// From Transfer Device table
        /// </summary>
        public int TransferDeviceId { get; set; }
        public string TransferDeviceCode { get; set; }
        public string TransferContent { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int AssetNo { get; set; }
        public int Qty { get; set; }
        public string LocationCd { get; set; }
        public string TransferDept { get; set; }
        public string TransferStatus { get; set; }
        public string TransferApprover { get; set; }
        public string DestinationDept { get; set; }
        public string DestinationStatus { get; set; }
        public string DestinationApprover { get; set; }
        public string Accounter { get; set; }
        public string ApproveStatus { get; set; }
        public string DeptCD { get; set; }
        public string UserName { get; set; }
        

        /// <summary>
        /// From Transfer Detail
        /// </summary>
        public int TransferDetailId { get; set; }
        public int TransferDeviceID { get; set; }
        public int AssetID { get; set; }
        public string RequestStatus { get; set; }

        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        public List<TransferVo> TransListVo = new List<TransferVo>();

        public DataTable dt { get; set; }
    }
}
