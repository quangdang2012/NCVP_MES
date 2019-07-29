using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionItemVo : ValueObject
    {
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
        /// get and set ParentItemName
        /// </summary>
        public string ParentItemName { get; set; }

        /// <summary>
        /// get and set ParentInspectionItemId
        /// </summary>
        public int ParentInspectionItemId { get; set; }

        /// <summary>
        /// get and set InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// get and set InspectionProcessCode
        /// </summary>
        public string InspectionProcessCode { get; set; }

        /// <summary>
        /// get and set InspectionEmployeeMandatory
        /// </summary>
        public int InspectionEmployeeMandatory { get; set; }

        /// <summary>
        /// get and set InspectionMachineMandatory
        /// </summary>
        public int InspectionMachineMandatory { get; set; }

        /// <summary>
        /// get and set InspectionProcessName
        /// </summary>
        public string InspectionProcessName { get; set; }

        /// <summary>
        /// get and set InspectionProcessId
        /// </summary>
        public int InspectionItemMandatory { get; set; }

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
        /// get and set InspectionTestInstructionId
        /// </summary>
        public int InspectionTestInstructionId { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionCode
        /// </summary>
        public string InspectionTestInstructionCode { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionText
        /// </summary>
        public string InspectionTestInstructionText { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailId
        /// </summary>
        public int InspectionTestInstructionDetailId { get; set; }

        /// <summary>
        /// get and set InspectionItemDataType
        /// </summary>
        public int InspectionItemDataType { get; set; }

        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// get and set FormattedDisplayOrder
        /// </summary>
        public string FormattedDisplayOrder { get; set; }

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
        /// get and set InspectionResultItemDecimalDigits
        /// </summary>
        public int InspectionResultItemDecimalDigits { get; set; }
        
        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set DeleteFlag
        /// </summary>
        public bool DeleteFlag = false;

        /// <summary>
        /// get and set InspectionItemIdCopy
        /// </summary>
        public int InspectionItemIdCopy { get; set; }

    }
}
