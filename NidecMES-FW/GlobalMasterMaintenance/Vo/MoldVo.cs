using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MoldVo : ValueObject
    {
        /// <summary>
        /// get and set MoldId
        /// </summary>
        public int MoldId { get; set; }

        /// <summary>
        /// get and set MoldCode
        /// </summary>
        public string MoldCode { get; set; }

        /// <summary>
        /// get and set MoldName
        /// </summary>
        public string MoldName { get; set; }

        /// <summary>
        /// get and set MoldTypeId
        /// </summary>
        public int MoldTypeId { get; set; }

        /// <summary>
        /// get and set MoldTypeCode
        /// </summary>
        public string MoldTypeCode { get; set; }

        /// <summary>
        /// get and set Width
        /// </summary>
        public decimal? Width { get; set; }

        /// <summary>
        /// get and set Depth
        /// </summary>
        public decimal? Depth { get; set; }

        /// <summary>
        /// get and set Height
        /// </summary>
        public decimal? Height { get; set; }

        /// <summary>
        /// get and set Weight
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// get and set CavNo
        /// </summary>
        public int CavNo { get; set; }

        /// <summary>
        /// get and set ProductionDate
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// get and set LifeShotCount
        /// </summary>
        public int? LifeShotCount { get; set; }

        /// <summary>
        /// get and set Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// get and set AssertCustomerId
        /// </summary>
        public int AssertCustomerId { get; set; }

        /// <summary>
        /// get and set AssertCustomerName
        /// </summary>
        public string AssertCustomerName { get; set; }

        /// <summary>
        /// get and set FixedAssetNo
        /// </summary>
        public string FixedAssetNo { get; set; }

        /// <summary>
        /// get and set LifeAlaramShotCount
        /// </summary>
        public int LifeAlaramShotCount { get; set; }

        /// <summary>
        /// get and set PeriodicAlarmShotCount1
        /// </summary>
        public int PeriodicAlarmShotCount1 { get; set; }

        /// <summary>
        /// get and set PeriodicAlarmShotCount2
        /// </summary>
        public int PeriodicAlarmShotCount2 { get; set; }

        /// <summary>
        /// get and set PeriodicAlarmShotCount3
        /// </summary>
        public int PeriodicAlarmShotCount3 { get; set; }

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
        /// get and set Model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// get and set MoldCategoryId
        /// </summary>
        public int MoldCategoryId { get; set; }

        /// <summary>
        /// get and set MoldCategoryName
        /// </summary>
        public string MoldCategoryName { get; set; }

        /// <summary>
        /// get and set MoldStructureId
        /// </summary>
        public int MoldStructureId { get; set; }

        /// <summary>
        /// get and set MoldStructureName
        /// </summary>
        public string MoldStructureName { get; set; }
        
        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        /// <summary>
        /// get and set Mode
        /// </summary>
        public string Mode = string.Empty;

        /// <summary>
        /// get and set list MoldVo
        /// </summary>
        public List<MoldVo> MoldListVo = new List<MoldVo>();
    }
}
