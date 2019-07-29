using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class BuildingVo : ValueObject
    {
        /// <summary>
        /// get and set BuildingId
        /// </summary>
        public int BuildingId { get; set; }

        /// <summary>
        /// get and set BuildingCode
        /// </summary>
        public string BuildingCode { get; set; }

        /// <summary>
        /// get and set BuildingName
        /// </summary>
        public string BuildingName { get; set; }

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
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list BuildingVo
        /// </summary>
        public List<BuildingVo> BuildingListVo = new List<BuildingVo>();
    }
}
