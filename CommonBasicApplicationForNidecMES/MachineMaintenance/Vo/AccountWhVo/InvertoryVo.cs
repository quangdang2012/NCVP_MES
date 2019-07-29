using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo
{
    public class InvertoryVo : ValueObject
    {
        /// <summary>
        /// get and set InvertoryEquipmentId
        /// </summary>
        public int InvertoryEquipmentId { get; set; }

        /// <summary>
        /// get and set WarehouseMainId
        /// </summary>
        public int WarehouseMainId { get; set; }
        public int AccountMainId { get; set; }

        /// <summary>
        /// get and set invertory_time_cd
        /// </summary>
        public string InvertoryTimeCode { get; set; }
        public bool InvertoryValue { get; set; }

        //from m_invertory_time
        public int InvertoryTimeId { get; set; }
        public string InvertoryTimeName { get; set; }
        //from asset
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        //end m_from 
        public int AssetId { get; set; }

        public string BeforeLocation { get; set; }

        public int LocationID { get; set; }
        public string NowLocation { get; set; }


        public string   RankNameBefore { get; set; }
        public string RankNameNow { get; set; }
        public int RankID { get; set; }
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
        /// store AffectedCount
        /// </summary>
        public int AffectedCount { get; set; }

        /// <summary>
        /// list of RankVo
        /// </summary>
        public List<InvertoryVo> InvertoryListVo = new List<InvertoryVo>();

    }
}
