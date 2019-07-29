using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class InspectionReturnVo : ValueObject
    {

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        ///  get or set InspectionFormatId
        /// </summary>
        public int InspectionFormatId { get; set; }

        /// <summary>
        ///  get or set InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        ///  get or set InspectionItemId
        /// </summary>
        public int InspectionItemId { get; set; }

        /// <summary>
        ///  get or set InspectionSpecificationId
        /// </summary>
        public int InspectionSpecificationId { get; set; }

        /// <summary>
        ///  get or set InspectionTestInstructionId
        /// </summary>
        public int InspectionTestInstructionId { get; set; }

        /// <summary>
        ///   get or set InspectionTestInstructionDetailId
        /// </summary>
        public int InspectionTestInstructionDetailId { get; set; }

        /// <summary>
        ///  get or set InspectionSelectionValueDataTypeId
        /// </summary>
        public int InspectionSelectionValueDataTypeId { get; set; }

    }
}
