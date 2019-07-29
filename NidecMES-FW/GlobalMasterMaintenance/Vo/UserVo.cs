using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class UserVo:ValueObject
    {
        /// <summary>
        /// get and set usercode
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// get and set username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get and set username
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// get and set country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// get and set language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// get and set MultiLoginFlag
        /// </summary>
        public string MultiLoginFlag { get; set; }

        /// <summary>
        /// get and set IpAddress
        /// </summary>
        public string IpAddress { get; set; }

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
        /// store RoleCount
        /// </summary>
        public int RoleCount = 0;

        /// <summary>
        /// store FactoryCount
        /// </summary>
        public int FactoryCount = 0;

        /// <summary>
        /// store ProcessCount
        /// </summary>
        public int ProcessCount = 0;

        /// <summary>
        /// store mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set Locale Id
        /// </summary>
        public int LocaleId { get; set; }

        /// <summary>
        /// get and set username
        /// </summary>
        public string UserDetail          {
            get
            {
                return UserCode + ":" + UserName;
            }
        }

    /// <summary>
    /// list of uservo
    /// </summary>
    public List<UserVo> UserListVo = new List<UserVo>();
    }
}
