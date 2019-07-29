using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessWorkMoldVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessWorkMoldId
        /// </summary>
        public int ProcessWorkMoldId { get; set; }

        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set ProcessWorkName
        /// </summary>
        public string ProcessWorkName { get; set; }

        /// <summary>
        /// get and set MoldName
        /// </summary>
        public string MoldName { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string MoldCode { get; set; }

        /// <summary>
        /// get and set MoldId
        /// </summary>
        public int MoldId { get; set; }

        /// <summary>
        /// get and set RegistrationUserCd
        /// </summary>
        public string RegistrationUserCd { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCd
        /// </summary>
        public string FactoryCd { get; set; }

        /// <summary>
        /// get and set IsExists
        /// </summary>
        public string IsExists { get; set; }

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set ProcessWorkMoldListVo
        /// </summary>
        public List<ProcessWorkMoldVo> ProcessWorkMoldListVo = new List<ProcessWorkMoldVo>();

    }
}
