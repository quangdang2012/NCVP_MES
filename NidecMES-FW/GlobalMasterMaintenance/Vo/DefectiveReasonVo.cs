using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class DefectiveReasonVo : ValueObject
    {
        /// <summary>
        /// get and set DefectiveReasonId
        /// </summary>
        public int DefectiveReasonId { get; set; }

        /// <summary>
        /// get and set DefectiveReasonCode
        /// </summary>
        public string DefectiveReasonCode { get; set; }

        /// <summary>
        /// get and set DefectiveReasonName
        /// </summary>
        public string DefectiveReasonName { get; set; }
        public int DefectiveCategoryId { get; set; }

        /// <summary>
        /// get and set DefectiveReasonCode
        /// </summary>
        public string DefectiveCategoryCode { get; set; }

        /// <summary>
        /// get and set DefectiveReasonName
        /// </summary>
        public string DefectiveCategoryName { get; set; }

        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

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
        /// get and set ProcessId
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list DefectiveReasonVo
        /// </summary>
        public List<DefectiveReasonVo> DefectiveReasonListVo = new List<DefectiveReasonVo>();

    }
}
