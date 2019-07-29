using System;

namespace Com.Nidec.Mes.Framework
{
    internal class AuthentificateStrategyDataTypeEnum
    {
        /// <summary>
        /// initialize UserAuthentificateStrategy
        /// </summary>
        private UserAuthentificateStrategy userAuthentificateStrategy;

        /// <summary>
        /// get keyname from the user
        /// </summary>
        private string keyName;

        /// <summary>
        /// private constructor
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="userAuthentificateStrategy"></param>
        private AuthentificateStrategyDataTypeEnum(string keyName, UserAuthentificateStrategy userAuthentificateStrategy)
        {
            this.keyName = keyName;
            this.userAuthentificateStrategy = userAuthentificateStrategy;
        }

        /// <summary>
        /// Get the authentificatestrategy instance by the authentificate flag from user
        /// 1- Ldap
        /// 2- local user
        /// default - null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static AuthentificateStrategyDataTypeEnum GetAuthentificateStrategyDataTypeEnum(String value)
        {
            if (value == null) return null; 

            switch (value.Trim())
            {
                case "1":
                    return LDAP_AUTHENTIFICATE;
                case "2":
                    return LOCAL_USER_AUTHENTIFICATE;
                default:
                    return null;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal String GetKeyName()
        {
            return this.keyName;
        }


        /// <summary>
        /// create new instance of the UserAuthentificateStrategy based on the input 1/2
        /// </summary>
        /// <returns></returns>
        internal UserAuthentificateStrategy CreateAuthentificateStrategy()
        {
            return userAuthentificateStrategy;
        }


        internal static readonly AuthentificateStrategyDataTypeEnum LDAP_AUTHENTIFICATE = new AuthentificateStrategyDataTypeEnum( "1" , new LdapUserAuthentificateStrategy());

        internal static readonly AuthentificateStrategyDataTypeEnum LOCAL_USER_AUTHENTIFICATE = new AuthentificateStrategyDataTypeEnum("2", new LocalUserAuthentificateStrategy());


    }

}
