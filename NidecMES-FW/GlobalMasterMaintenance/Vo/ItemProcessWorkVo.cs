using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ItemProcessWorkVo : ValueObject
    {
        /// <summary>
        /// get and set ItemProcessWorkId
        /// </summary>
        public int ItemProcessWorkId { get; set; }

        /// <summary>
        /// get and set ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// get and set ItemName
        /// </summary>
        public string ItemCd { get; set; }

        /// <summary>
        /// get and set ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// get and set ProcessWorkId
        /// </summary>
        public int ProcessWorkId { get; set; }

        /// <summary>
        /// get and set ProcessWorkCode
        /// </summary>
        public string ProcessWorkCode { get; set; }

        /// <summary>
        /// get and set ProcessWorkname
        /// </summary>
        public string ProcessWorkName { get; set; }

        /// <summary>
        /// get and set ProcessWorkSeq
        /// </summary>
        public int ProcessWorkSeq { get; set; }

        /// <summary>
        /// get and set OptionalProcessFlag
        /// </summary>
        public string OptionalProcessFlag { get; set; }

        /// <summary>
        /// get and set SkipPreventionFlag
        /// </summary>
        public string SkipPreventionFlag { get; set; }

        /// <summary>
        /// get and set WorkOrder
        /// </summary>
        public int WorkOrder { get; set; }

        /// <summary>
        /// get and set ProcessFlowRuleId
        /// </summary>
        public int ProcessFlowRuleId { get; set; }

        /// <summary>
        /// get and set Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string ItemProcessTypeCode { get; set; }

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
        /// list of ItemProcessWorkVo
        /// </summary>
        public List<ItemProcessWorkVo> ItemProcessWorkListVo = new List<ItemProcessWorkVo>();

    }
}
