using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionProcessVo : ValueObject
    {
        /// <summary>
        /// get and set InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// get and set InspectionProcessCode
        /// </summary>
        public string InspectionProcessCode { get; set; }

        /// <summary>
        /// get and set InspectionProcessName
        /// </summary>
        public string InspectionProcessName { get; set; }

        /// <summary>
        /// get and set InspectionFormatId
        /// </summary>
        public int InspectionFormatId { get; set; }

        /// <summary>
        /// get and set InspectionFormatCode
        /// </summary>
        public string InspectionFormatCode { get; set; }

        /// <summary>
        /// get and set InspectionFormatName
        /// </summary>
        public string InspectionFormatName { get; set; }

        /// <summary>
        /// get and set InspectionItemCode
        /// </summary>
        public string InspectionItemCode { get; set; }

        /// <summary>
        /// get and set InspectionItemCode
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// get and set InspectionItemName
        /// </summary>
        public string InspectionItemName { get; set; }

        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        
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
        /// get and set ItemCode
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// get and set LineCode
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// get and set InspectionProcessIdCopy
        /// </summary>
        public int InspectionProcessIdCopy { get; set; }

        /// <summary>
        /// get and set SequenceNo
        /// </summary>
        public int SequenceNo { get; set; }

        /// <summary>
        /// get and set DeleteFlag
        /// </summary>
        public bool DeleteFlag = false;
    }
}
