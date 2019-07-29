using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LineItemCycleTimeVo : ValueObject
    {
        /// <summary>
        /// get and set GlobalItemCode
        /// </summary>
        public string SapItemCode { get; set; }

        /// <summary>
        /// get and set GlobalItemName
        /// </summary>
        public string SapItemName { get; set; }

        /// <summary>
        /// get and set LineId
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// get and set LineName
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set StdCycleTime
        /// </summary>
        public decimal StdCycleTime { get; set; }

        /// <summary>
        /// get and set StdCycleTimeNull
        /// </summary>
        public decimal? StdCycleTimeNull { get; set; }

        /// <summary>
        /// get and set LineItemCycleTimeId
        /// </summary>
        public int LineItemCycleTimeId { get; set; }

    }
}
