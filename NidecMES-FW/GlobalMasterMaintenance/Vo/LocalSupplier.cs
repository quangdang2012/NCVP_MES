using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LocalSupplierVo : ValueObject
    {
        /// <summary>
        /// get and set LocalSupplierId
        /// </summary>
        public int LocalSupplierId { get; set; }

        /// <summary>
        /// get and set LocalSupplierCode
        /// </summary>
        public string LocalSupplierCode { get; set; }

        /// <summary>
        /// get and set LocalSupplierName
        /// </summary>
        public string LocalSupplierName { get; set; }

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
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of LocalSupplierVo
        /// </summary>
        public List<LocalSupplierVo> LocalSupplierListVo = new List<LocalSupplierVo>();

    }
}
