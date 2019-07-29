using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ItemLineInspectionFormatVo : ValueObject
    {
        /// <summary>
        /// get and set ItemLineInspectionFormatId
        /// </summary>
        public int ItemLineInspectionFormatId { get; set; }

        /// <summary>
        /// get and set SapItemCode
        /// </summary>
        public string SapItemCode { get; set; }

        /// <summary>
        /// get and set ItemName
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
        /// get and set InspectionFormatId
        /// </summary>
        public int InspectionFormatId { get; set; }

        /// <summary>
        /// get and set InspectionFormatName
        /// </summary>
        public string InspectionFormatName { get; set; }

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
    }
}
