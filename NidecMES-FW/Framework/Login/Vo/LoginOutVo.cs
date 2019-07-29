using System;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Framework.Login
{
    [Serializable]
    public class LoginOutVo : ValueObject
    {
        /// <summary>
        /// get and set userid
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// get and set username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// get and set LocaleId
        /// </summary>
        public int LocaleId { get; set; }

        /// <summary>
        /// get and set languagecode
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// get and set countrycode
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// get and set multiloginflag
        /// </summary>
        public string MultiLoginFlg { get; set; }

        /// <summary>
        /// get and set countrycode
        /// </summary>
        public int ResultCount { get; set; }

        /// <summary>
        /// get and set factorycodelist
        /// </summary>
        public List<string> FactoryCodeList { get; set; } = new List<string>();

        /// <summary>
        /// get and set controllist
        /// </summary>
        public List<string> ControlList { get; set; } = new List<string>();

        /// <summary>
        /// get and set pda authentificate
        /// </summary>
        public bool PdaLoginAuthentificate { get; set; }
    }
}
