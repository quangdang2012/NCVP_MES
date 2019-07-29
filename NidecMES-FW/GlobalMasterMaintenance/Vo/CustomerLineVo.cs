using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class CustomerLineVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkDefectiveReasonId
        /// </summary>
        public int CustomerLineId { get; set; }

        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// get and set ProcessWorkName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// get and set DefectiveReasonId
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// get and set DefectiveReasonName
        /// </summary>
        public string LineName { get; set; }

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
        public int AffectedCount = 0;

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of ProcessDefectiveReasonVo
        /// </summary>
        public List<CustomerLineVo> customerLineListVo = new List<CustomerLineVo>();

    }
}
