using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessWorkLocalSupplierVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set ProcessWorkCode
        /// </summary>
        public string ProcessWorkCode { get; set; }

        /// <summary>
        /// get and set ProcessWorkName
        /// </summary>
        public string ProcessWorkName { get; set; }

        /// <summary>
        /// get and set LocalSupplierId
        /// </summary>
        public int LocalSupplierId { get; set; }

        /// <summary>
        /// get and set IsExists
        /// </summary>
        public string IsExists { get; set; }

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
        /// list of ProcessWorkVo
        /// </summary>
        public List<ProcessWorkLocalSupplierVo> ProcessWorkLocalSupplierListVo = new List<ProcessWorkLocalSupplierVo>();

    }
}
