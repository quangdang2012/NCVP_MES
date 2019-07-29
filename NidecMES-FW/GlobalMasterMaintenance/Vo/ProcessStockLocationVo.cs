using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ProcessStockLocationVo : ValueObject
    {
        /// <summary>
        /// get and set ProcessId
        /// </summary>
        public int ProcessId { get; set; }

        /// <summary>
        /// get and set StockLocationId
        /// </summary>
        public int StockLocationId { get; set; }

        /// <summary>
        /// get and set StockLocationCode
        /// </summary>
        public string StockLocationCode { get; set; }

        /// <summary>
        /// get and set StockLocationName
        /// </summary>
        public string StockLocationName { get; set; }

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


    }
}
