using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class RoleAuthorityControlVo : ValueObject
    {
        /// <summary>
        /// get and set RoleAuthorityControlId
        /// </summary>
        public int RoleAuthorityControlId { get; set; }

        /// <summary>
        /// get and set RoleCode
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// get and set AuthorityControlCode
        /// </summary>
        public string AuthorityControlCode { get; set; }

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

        /// <summary>
        /// list of RoleAuthorityControlVo
        /// </summary>
        public List<RoleAuthorityControlVo> RoleAuthorityControlListVo = new List<RoleAuthorityControlVo>();
    }
}
