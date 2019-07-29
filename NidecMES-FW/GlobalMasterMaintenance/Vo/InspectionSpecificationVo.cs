using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionSpecificationVo : ValueObject
    {
        /// <summary>
        /// get and set InspectionSpecificationId
        /// </summary>
        public int InspectionSpecificationId { get; set; }

        /// <summary>
        /// get and set InspectionSpecificationCode
        /// </summary>
        public string InspectionSpecificationCode { get; set; }

        /// <summary>
        /// get and set InspectionSpecificationText
        /// </summary>
        public string InspectionSpecificationText { get; set; }

        /// <summary>
        /// get and set ValueFrom
        /// </summary>
        public string ValueFrom { get; set; }

        /// <summary>
        /// get and set ValueTo
        /// </summary>
        public string ValueTo { get; set; }

        /// <summary>
        /// get and set Unit
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// get and set OperatorFrom
        /// </summary>
        public string OperatorFrom { get; set; }

        /// <summary>
        /// get and set OperatorTo
        /// </summary>
        public string OperatorTo { get; set; }

        /// <summary>
        /// get and set InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// get and set InspectionItemCode
        /// </summary>
        public string InspectionItemCode { get; set; }

        /// <summary>
        /// get and set InspectionItemName
        /// </summary>
        public string InspectionItemName { get; set; }

        /// <summary>
        /// get and set SpecificationResultJudgeType
        /// </summary>
        public int SpecificationResultJudgeType { get; set; }

        /// <summary>
        /// get and set SpecificationResultJudgeTypeMode
        /// </summary>
        public string SpecificationResultJudgeTypeMode { get; set; }
        
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
        /// get and set DeleteFlag
        /// </summary>
        public bool DeleteFlag = false;
    }
}
