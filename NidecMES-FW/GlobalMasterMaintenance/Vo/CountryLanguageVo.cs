using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
   public class CountryLanguageVo : ValueObject
    {
        /// <summary>
        /// get and set Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// get and set Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// get and set Locale Id
        /// </summary>
        public int LocaleId { get; set; }

        /// <summary>
        /// get and set RegistrationUserCode
        /// </summary>
        public string RegistrationUserCode { get; set; }

        /// <summary>
        /// get and set RegistrationDateTime
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list CountryLanguageVo
        /// </summary>
        public List<CountryLanguageVo> CountryLangListVo = new List<CountryLanguageVo>();
    }
}
