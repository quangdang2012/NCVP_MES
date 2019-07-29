using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class UserRoleVo : ValueObject
    {
        /// <summary>
        /// get and set UserRoleId
        /// </summary>
        public int UserRoleId { get; set; }

        /// <summary>
        /// get and set usercode
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// get and set UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get and set AuthorityControlCode
        /// </summary>
        public string AuthorityControlCode { get; set; }

        /// <summary>
        /// get and set RoleCode
        /// </summary>
        public string RoleCode { get; set; }

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
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// store mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// list of userrolevo
        /// </summary>
        public List<UserRoleVo> UserRoleListVo = new List<UserRoleVo>();
    }
}
