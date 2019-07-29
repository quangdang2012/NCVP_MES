using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class InspectionFormatVo : ValueObject
    {
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
        /// get and set SapItemName
        /// </summary>
        public string SapItemName { get; set; }

        ///// <summary>
        ///// get and set ItemId
        ///// </summary>
        //public int ItemId { get; set; }

        /// <summary>
        /// get and set SapItemCode
        /// </summary>
        public string SapItemCode { get; set; }

        /// <summary>
        /// get and set LineName
        /// </summary>
        public string LineName { get; set; }


        /// <summary>
        /// get and set LineId
        /// </summary>
        public int LineId { get; set; }

        /// <summary>
        /// get and set LineCode
        /// </summary>
        public string LineCode { get; set; }

        /// <summary>
        /// get and set InspectionProcessName
        /// </summary>
        public string InspectionProcessName { get; set; }

        /// <summary>
        /// get and set InspectionItemLineName
        /// </summary>
        public string InspectionItemLineName { get; set; }

        /// <summary>
        /// get and set InspectionItemLineFormatId
        /// </summary>
        public int InspectionItemLineFormatId { get; set; }

        /// <summary>
        /// get and set InspectionProcessId
        /// </summary>
        public int InspectionProcessId { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// store AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store InspectionFormatSeq
        /// </summary>
        public int InspectionFormatSeq { get; set; }

        /// <summary>
        /// store SapMaterialGroupId
        /// </summary>
        public string SapMaterialGroupId { get; set; }

        /// <summary>
        /// get and set InspectionFormatIdCopy
        /// </summary>
        public int InspectionFormatIdCopy { get; set; }

        /// <summary>
        /// store Mode
        /// </summary>
        public string Mode = string.Empty;
    }
}
