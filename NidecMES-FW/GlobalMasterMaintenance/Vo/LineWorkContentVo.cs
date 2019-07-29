using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class LineWorkContentVo : ValueObject
    {

        /// <summary>
        /// get and set LineWorkContentId
        /// </summary>
        public int LineWorkContentId { get; set; }

        /// <summary>
        /// get and set WorkContentId
        /// </summary>
        public int WorkContentId { get; set; }
        /// <summary>
        /// get and set LineId
        /// </summary>
        public int LineId { get; set; }
        /// <summary>
        /// get and set LineName
        /// </summary>
        public string  LineName { get; set; }
        /// <summary>
        /// get and set WorkContentName
        /// </summary>
        public string  WorkContentName { get; set; }

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
