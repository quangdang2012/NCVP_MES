using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessWorkLineVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set MachineId
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// get and set LineName
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// get and set LineCode
        /// </summary>
        public string LineCode { get; set; }

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
        /// get and set WorkCenter
        /// </summary>
        public string WorkCenter { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of ProcessWorkVo
        /// </summary>
        public List<ProcessWorkLineVo> ProcessWorkLineListVo = new List<ProcessWorkLineVo>();

    }
}
