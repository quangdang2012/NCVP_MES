using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class GlobalItemVo : ValueObject
    {
        /// <summary>
        /// get and set GlobalItemId
        /// </summary>
        public int GlobalItemId { get; set; }

        /// <summary>
        /// get and set GlobalItemCode
        /// </summary>
        public string GlobalItemCode { get; set; }

        /// <summary>
        /// get and set GlobalItemName
        /// </summary>
        public string GlobalItemName { get; set; }

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
        /// get and set LocallItemId
        /// </summary>
        public int LocallItemId { get; set; }

        /// <summary>
        /// get and set list ItemVo
        /// </summary>
        public List<GlobalItemVo> GlobalItemListVo = new List<GlobalItemVo>();
    }
}
