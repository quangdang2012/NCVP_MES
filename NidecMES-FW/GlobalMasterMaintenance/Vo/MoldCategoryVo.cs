using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MoldCategoryVo : ValueObject
    {
        /// <summary>
        /// get and set MoldCategoryId
        /// </summary>
        public int MoldCategoryId { get; set; }

        /// <summary>
        /// get and set MoldCategoryCode
        /// </summary>
        public string MoldCategoryCode { get; set; }

        /// <summary>
        /// get and set MoldCategoryName
        /// </summary>
        public string MoldCategoryName { get; set; }

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
        /// get and set DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

    }
}
