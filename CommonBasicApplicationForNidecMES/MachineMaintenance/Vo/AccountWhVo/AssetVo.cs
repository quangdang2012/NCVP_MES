using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class AssetVo : ValueObject
    {
        /// <summary>
        /// get and set AssetId
        /// </summary>
        public int AssetId { get; set; }
        public int AssetNo { get; set; }

        /// <summary>
        /// get and set AssetCode
        /// </summary>
        public string AssetCode { get; set; }
        public string AssetType { get; set; }
        public string AssetSerial { get; set; }
        public string AssetInvoice { get; set; }
        public string LabelStatus { get; set; }
        public string AssetPO { get; set; }

        public double AssetLife { get; set; }
        public double AcquistionCost { get; set; }
        public DateTime AcquistionDate { get; set; }
        /// <summary>
        /// get and set AssetName
        /// </summary>
        public string AssetName { get; set; }
        public string AssetModel { get; set; }
        public string AssetSuppiler { get; set; }
        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// list of AssetVo
        /// </summary>
        public List<AssetVo> AssetListVo = new List<AssetVo>();

    }
}
