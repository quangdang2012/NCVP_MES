using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MoldTypeVo : ValueObject
    {
        /// <summary>
        /// get and set MoldTypeId
        /// </summary>
        public int MoldTypeId { get; set; }

        /// <summary>
        /// get and set MoldTypeCode
        /// </summary>
        public string MoldTypeCode { get; set; }

        /// <summary>
        /// get and set MoldTypeName
        /// </summary>
        public string MoldTypeName { get; set; }

        /// <summary>
        /// get and set ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// get and set ItemCode
        /// </summary>
        public string ItemCode { get; set; }

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

        /// <summary>
        /// get and set list MoldTypeVo
        /// </summary>
        public List<MoldTypeVo> MoldTypeListVo = new List<MoldTypeVo>();
    }
}
