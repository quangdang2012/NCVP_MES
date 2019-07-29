using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class CavityVo : ValueObject
    {
        /// <summary>
        /// get and set CavityId
        /// </summary>
        public int CavityId { get; set; }

        /// <summary>
        /// get and set CavityCode
        /// </summary>
        public string CavityCode { get; set; }

        /// <summary>
        /// get and set CavityName
        /// </summary>
        public string CavityName { get; set; }

        /// <summary>
        /// get and set MoldId
        /// </summary>
        public int MoldId { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string MoldCode { get; set; }

                /// <summary>
        /// get and set MoldId
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string ModelCode { get; set; }

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
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

    }
}
