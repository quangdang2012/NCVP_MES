using Com.Nidec.Mes.Framework;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MoldDrawingVo : ValueObject
    {
        /// <summary>
        /// get and set MoldDrawingId
        /// </summary>
        public int MoldDrawingId { get; set; }

        /// <summary>
        /// get and set MoldId
        /// </summary>
        public int MoldId { get; set; }

        /// <summary>
        /// get and set DrawingNo
        /// </summary>
        public string DrawingNo { get; set; }

        /// <summary>
        /// get and set RegistrationUserCd
        /// </summary>
        public string RegistrationUserCd { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set FactoryCd
        /// </summary>
        public string FactoryCd { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string MoldCode { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

    }
}
