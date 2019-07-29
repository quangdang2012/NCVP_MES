using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class GlobalLocalItemVo : ValueObject
    {
        /// <summary>
        /// get and set GlobalLocalItemId
        /// </summary>
        public int GlobalLocalItemId { get; set; }

        /// <summary>
        /// get and set GlobalItemId
        /// </summary>
        public int GlobalItemId { get; set; }

        /// <summary>
        /// get and set LocalItemName
        /// </summary>
        public string GlobalItemCode { get; set; }

        /// <summary>
        /// get and set LocalItemName
        /// </summary>
        public string GlobalItemName { get; set; }

        /// <summary>
        /// get and set LocalItemId
        /// </summary>
        public int LocalItemId { get; set; }

        /// <summary>
        /// get and set LocalItemName
        /// </summary>
        public string LocalItemCode { get; set; }

        /// <summary>
        /// get and set LocalItemName
        /// </summary>
        public string LocalItemName { get; set; }

        /// <summary>
        /// get and set FactoryCode
        /// </summary>
        public string FactoryCode { get; set; }

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
        /// get and set list ItemVo
        /// </summary>
        public List<GlobalLocalItemVo> GlobalLocalItemListVo = new List<GlobalLocalItemVo>();
    }
}
