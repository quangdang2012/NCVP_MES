using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class AccountLocationVo : ValueObject
    {
        /// <summary>
        /// get and set AssetId
        /// </summary>
        public int AccountLocationId { get; set; }

        /// <summary>
        /// get and set AssetCode
        /// </summary>
        public string AccountLocationCode { get; set; }
        public string AccountLocationName { get; set; }
        public string AccountLocationType { get; set; }

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

        /// <summary>
        /// list of AssetVo
        /// </summary>
        public List<AccountLocationVo> accountlocationvo = new List<AccountLocationVo>();

    }
}
