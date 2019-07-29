using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class UserLocationVo : ValueObject
    {
        /// <summary>
        /// get and set UserLocationId
        /// </summary>
        public int UserLocationId { get; set; }

        /// <summary>
        /// get and set UserLocationCode
        /// </summary>
        public string UserLocationCode { get; set; }

        /// <summary>
        /// get and set UserLocationName
        /// </summary>
        public string UserLocationName { get; set; }

        /// <summary>
        /// get and set DeptCode
        /// </summary>
        public string DeptCode { get; set; }
        
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
        /// list of UserLocationVo
        /// </summary>
        public List<UserLocationVo> UserLocationListVo = new List<UserLocationVo>();

    }
}
