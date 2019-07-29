using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class AuthorityControlVo : ValueObject
    {
        /// <summary>
        /// get and set AuthorityControlCode
        /// </summary>
        public string AuthorityControlCode { get; set; }

        /// <summary>
        /// get and set AuthorityControlName
        /// </summary>
        public string AuthorityControlName { get; set; }

        /// <summary>
        /// get and set ParentControlCode
        /// </summary>
        public string ParentControlCode { get; set; }

        /// <summary>
        /// get and set FormName
        /// </summary>
        public string FormName { get; set; }

        /// <summary>
        /// get and set AssemblyName
        /// </summary>
        public string AssemblyName { get; set; }

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
        /// get and set list AuthorityControlVo
        /// </summary>
        public List<AuthorityControlVo> AuthorityControlListVo = new List<AuthorityControlVo>();
    }
}
