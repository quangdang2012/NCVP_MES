using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessId
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// get and set ProcessCode
        /// </summary>
        public string ProcessCode { get; set; }

        /// <summary>
        /// get and set ProcessName
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// get and set NextPocessCode
        /// </summary>
        //public string NextPocessCode { get; set; }

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
        /// store UserProcessId
        /// </summary>
        public int UserProcessId = 0;

        /// <summary>
        /// store ProcessWorkId
        /// </summary>
        public int ProcessWorkId = 0;

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of ProcessVo
        /// </summary>
        public List<ProcessVo> ProcessListVo = new List<ProcessVo>();

    }
}
