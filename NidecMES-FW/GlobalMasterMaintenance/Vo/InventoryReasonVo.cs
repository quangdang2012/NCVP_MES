using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InventoryReasonVo : ValueObject
    {
        /// <summary>
        /// get and set InventoryReasonId
        /// </summary>
        public int InventoryReasonId { get; set; }

        /// <summary>
        /// get and set InventoryReasonCode
        /// </summary>
        public string InventoryReasonCode { get; set; }

        /// <summary>
        /// get and set InventoryReasonName
        /// </summary>
        public string InventoryReasonName { get; set; }

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
        /// list of LineVo
        /// </summary>
        public List<InventoryReasonVo> InventoryReasonListVo = new List<InventoryReasonVo>();

    }
}
