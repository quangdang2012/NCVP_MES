using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class CopyInspectionFormatVo : ValueObject
    {

        /// <summary>
        /// get and set InspectionFormatId
        /// </summary>
        public int InspectionFormatId { get; set; }

        /// <summary>
        /// get and set InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// get and set InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        /// get and set InspectionSelectionDataTypeValueId
        /// </summary>
        public int InspectionSelectionDataTypeValueId { get; set; }

        /// <summary>
        /// get and set InspectionSpecificationId
        /// </summary>
        public int InspectionSpecificationId { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionId
        /// </summary>
        public int InspectionTestInstructionId { get; set; }

        /// <summary>
        /// get and set InspectionTestInstructionDetailId
        /// </summary>
        public int InspectionTestInstructionDetailId { get; set; }



    }
}
