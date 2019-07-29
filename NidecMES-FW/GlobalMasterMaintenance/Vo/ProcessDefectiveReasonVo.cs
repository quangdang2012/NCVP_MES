using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessDefectiveReasonVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkDefectiveReasonId
        /// </summary>
        public int ProcessWorkDefectiveReasonId { get; set; }

        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set ProcessWorkName
        /// </summary>
        public string ProcessWorkName { get; set; }

        /// <summary>
        /// get and set DefectiveReasonId
        /// </summary>
        public int DefectiveReasonId { get; set; }

        /// <summary>
        /// get and set DefectiveReasonName
        /// </summary>
        public string DefectiveReasonName { get; set; }

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
        public List<ProcessDefectiveReasonVo> ProcessDefectiveReasonListVo = new List<ProcessDefectiveReasonVo>();

    }
}
