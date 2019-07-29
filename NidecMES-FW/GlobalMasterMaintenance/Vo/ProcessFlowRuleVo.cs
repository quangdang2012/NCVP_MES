using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessFlowRuleVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessFlowRuleId
        /// </summary>
        public int ProcessFlowRuleId { get; set; }

        /// <summary>
        /// get and set ProcessFlowRuleCode
        /// </summary>
        public string ProcessFlowRuleCode { get; set; }

        /// <summary>
        /// get and set Comment
        /// </summary>
        public string Comment { get; set; }

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
        /// list of ProcessFlowRuleVo
        /// </summary>
        public List<ProcessFlowRuleVo> ProcessFlowRuleListVo = new List<ProcessFlowRuleVo>();

    }
}
