using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionTestInstructionVo : ValueObject
    {
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
        /// get and set InspectionTestInstructionDetailId
        /// </summary>
        public int InspectionTestInstructionDetailId { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailCode
        /// </summary>
        public string InspectionTestInstructionDetailCode { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailText
        /// </summary>
        public string InspectionTestInstructionDetailText { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailResultCount
        /// </summary>
        public int InspectionTestInstructionDetailResultCount { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailMachine
        /// </summary>
        public string InspectionTestInstructionDetailMachine { get; set; }
                
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
