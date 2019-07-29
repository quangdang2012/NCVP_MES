using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class RoleVo : ValueObject
    {
        /// <summary>
        /// get and set rolecode
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// get and  set rolename
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// get and set registrationusercode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set registrationdatetime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set factorycode
        /// </summary>
        public string FactoryCode { get; set; }

        /// <summary>
        /// store UserCount
        /// </summary>
        public int UserCount = 0;

        /// <summary>
        /// store AuthorityCount
        /// </summary>
        public int AuthorityCount = 0;

        /// <summary>
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of rolevo
        /// </summary>
        public List<RoleVo> RoleListVo = new List<RoleVo>();

    }
}
