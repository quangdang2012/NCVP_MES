using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class UserFactoryVo : ValueObject
    {
        /// <summary>
        /// get and set UserFactoryId
        /// </summary>
        public int UserFactoryId { get; set; }

        /// <summary>
        /// get and set UserCode
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// get and set FactoryCd
        /// </summary>
        public string FactoryCd { get; set; }

        /// <summary>
        /// get and set FactoryName
        /// </summary>
        public string FactoryName { get; set; }

        /// <summary>
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of UserFactoryVo
        /// </summary>
        public List<UserFactoryVo> UserFactoryListVo = new List<UserFactoryVo>();
    }
}
