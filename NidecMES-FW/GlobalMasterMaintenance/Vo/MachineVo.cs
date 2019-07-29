using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MachineVo : ValueObject
    {
        /// <summary>
        /// get and set MachineId
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// get and set MachineCode
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// get and set MachineName
        /// </summary>
        public string MachineName { get; set; }

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
        /// get and set MachineCodeEqualCheck
        /// </summary>
        public bool MachineCodeEqualCheck { get; set; }

        /// <summary>
        /// list of MachineVo
        /// </summary>
        public List<MachineVo> MachineListVo = new List<MachineVo>();

    }
}
