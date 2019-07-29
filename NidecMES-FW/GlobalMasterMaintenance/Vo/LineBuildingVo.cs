using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LineBuildingVo : ValueObject
    {
        /// <summary>
        /// get and set LineBuildingId
        /// </summary>
        public int LineBuildingId { get; set; }

        /// <summary>
        /// get and set BuildingId
        /// </summary>
        public int BuildingId { get; set; }
        /// <summary>
        /// get and set LineId
        /// </summary>
        public int LineId { get; set; }
        /// <summary>
        /// get and set LineCode
        /// </summary>
        public string LineCode { get; set; }
        /// <summary>
        /// get and set LineName
        /// </summary>
        public string LineName { get; set; }
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
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;
    }
}
