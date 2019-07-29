using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Vo
{
    public class MoldDetailVo : ValueObject
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
        /// get and set MoldName
        /// </summary>
        public string MoldCodeName { get; set; }

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
        /// get and set ProductionDate
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// get and set LifeShotCount
        /// </summary>
        public int? LifeShotCount { get; set; }

        /// <summary>
        /// get and set LifeAlarmShotCount
        /// </summary>
        public int? LifeAlarmShotCount { get; set; }

        /// <summary>
        /// get and set PeriodicAlarmShotCount1
        /// </summary>
        public int? PeriodicAlarmShotCount1 { get; set; }
        
        /// <summary>
        /// get and set PeriodicAlarmShotCount2
        /// </summary>
        public int? PeriodicAlarmShotCount2 { get; set; }

        /// <summary>
        /// get and set PeriodicAlarmShotCount3
        /// </summary>
        public int? PeriodicAlarmShotCount3 { get; set; }

        /// <summary>
        /// get and set Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// get and set mold_drawing_no
        /// </summary>
        public string MoldDrawingNo { get; set; }

        /// <summary>
        /// get and set MoldCategoryId
        /// </summary>
        public int MoldCategoryId { get; set; }

        /// <summary>
        /// get and set ModelId
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// get and set MoldCategoryName
        /// </summary>
        public string MoldCategoryName { get; set; }

        /// <summary>
        /// get and set MoldCategoryCode
        /// </summary>
        public string MoldCategoryCode { get; set; }

        /// <summary>
        /// get and set ModelName
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// get and set MoldItemCode
        /// </summary>
        public string MoldItemCode { get; set; }

        /// <summary>
        /// get and set ModelName
        /// </summary>
        public string SapItemCode { get; set; }


        /// <summary>
        /// get and set ModelName
        /// </summary>
        public string ProcessWorkCode { get; set; }
        /// <summary>
        /// get and set ModelCode
        /// </summary>
        public string ModelCode{ get; set; }

        /// <summary>
        /// get and set MoldItemId
        /// </summary>
        public int? MoldItemId { get; set; }

        /// <summary>
        /// get and set CavityId
        /// </summary>
        public int? CavityId { get; set; }

        /// <summary>
        /// get and set AffectedCount
        /// </summary>
        public int AffectedCount = 0;

        public ValueObjectList<MoldModelVo> MoldModel;

        public ValueObjectList<GlobalItemVo> GlobalItem;

        public ValueObjectList<ItemVo> LocalItem;

        public ValueObjectList<MoldDrawingVo> DrawingVo;

    }
}
