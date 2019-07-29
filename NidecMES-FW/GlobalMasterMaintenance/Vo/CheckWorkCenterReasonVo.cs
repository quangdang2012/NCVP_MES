using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class CheckWorkCenterReasonVo : ValueObject
    {
        /// <summary>
        /// get and set Defective Reason ID
        /// </summary>
        public string  Defective_Reason_ID { get; set; }

        /// <summary>
        /// get and set Work Center
        /// </summary>
        public int Work_Center { get; set; }

        /// <summary>
        /// get and set Flag
        /// </summary>
        public int Flag { get; set; }


    }
}
