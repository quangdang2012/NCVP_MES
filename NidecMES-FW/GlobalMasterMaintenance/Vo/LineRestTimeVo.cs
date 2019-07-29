using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LineRestTimeVo : ValueObject
    {
        /// <summary>
        /// get and set LineRestTimeId
        /// </summary>
        public int LineRestTimeId { get; set; }

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
        /// get and set Shift
        /// </summary>
        public int Shift { get; set; }

        /// <summary>
        /// get and set Shift
        /// </summary>
        public string ShiftText { get; set; }

        /// <summary>
        /// get and set Shift
        /// </summary>
        public int? PlanRestMinutes { get; set; }

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
        public int AffectedCount { get; set; }
        
    }
}
