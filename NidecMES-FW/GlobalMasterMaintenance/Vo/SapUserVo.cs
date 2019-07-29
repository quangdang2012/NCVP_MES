using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class SapUserVo : ValueObject
    {
        /// <summary>
        /// get and set SapUserId
        /// </summary>
        public int SapUserId { get; set; }

        /// <summary>
        /// get and set usercode
        /// </summary>
        public string MesUserCode { get; set; }

        /// <summary>
        /// get and set UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get and set SapUser
        /// </summary>
        public string SapUser { get; set; }

        /// <summary>
        /// get and set username
        /// </summary>
        public string SapPassWord { get; set; }

        /// <summary>
        /// get and set registrationusercode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set registrationdatetime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set  registrationfactorycode
        /// </summary>
        public string RegistrationFactoryCode { get; set; }

        /// <summary>
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// list of SapUserVo
        /// </summary>
        public List<SapUserVo> SapUserListVo = new List<SapUserVo>();

    }
}
