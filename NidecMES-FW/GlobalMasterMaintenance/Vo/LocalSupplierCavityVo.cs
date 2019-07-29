using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LocalSupplierCavityVo : ValueObject
    {
        /// <summary>
        /// get and set LocalSupplierCavityId
        /// </summary>
        public int LocalSupplierCavityId { get; set; }

        /// <summary>
        /// get and set ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// get and set LocalSupplierCavityCode
        /// </summary>
        public string LocalSupplierCavityCode { get; set; }

        /// <summary>
        /// get and set ItemCode
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// get and set LocalSupplierCavityName
        /// </summary>
        public string LocalSupplierCavityName { get; set; }

        /// <summary>
        /// get and set LocalSupplierId
        /// </summary>
        public int LocalSupplierId { get; set; }

        /// <summary>
        /// get and set LocalSupplierCode
        /// </summary>
        public string LocalSupplierCode { get; set; }

        /// <summary>
        /// get and set LocalSupplierCode
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
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// get and set list LocalSupplierCavityVo
        /// </summary>
        public List<LocalSupplierCavityVo> LocalSupplierCavityListVo = new List<LocalSupplierCavityVo>();
    }
}
