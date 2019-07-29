using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class StockLocationVo : ValueObject
    {
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
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list StockLocationVo
        /// </summary>
        public List<StockLocationVo> StockLocationListVo = new List<StockLocationVo>();

        /// <summary>
        /// get and set StockLocation ProcessWork Id
        /// </summary>
        public int StockLocationProcessWorkId = 0;

        /// <summary>
        /// get and set Mold Type Id
        /// </summary>
        public int MoldTypeId = 0;

        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// get and set LocationType
        /// </summary>
        public int LocationType { get; set; }

        /// <summary>
        /// get and set LocationType for display
        /// </summary>
        public string LocationTypeDisplay { get; set; }

    }
}
