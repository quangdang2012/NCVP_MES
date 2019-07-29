using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class ItemVo : ValueObject
    {
        /// <summary>
        /// get and set ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// get and set ItemCode
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// get and set ItemName
        /// </summary>
        public string ItemName { get; set; }

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
        /// get and set UnitType
        /// </summary>
        public int UnitType { get; set; }

        /// <summary>
        /// get and set Unit Type
        /// </summary>
        public string UnitType_Display { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list ItemVo
        /// </summary>
        public List<ItemVo> ItemListVo = new List<ItemVo>();

        /// <summary>
        /// get and set Item ProcessWork Id
        /// </summary>
        public int ItemProcessWorkId = 0;

        /// <summary>
        /// get and set Mold Type Id
        /// </summary>
        public int MoldTypeId = 0;

    }
}
