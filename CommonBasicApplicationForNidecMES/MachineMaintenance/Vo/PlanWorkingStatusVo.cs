using System;
using System.Collections.Generic;
using Com.Nidec.Mes.Framework;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo
{
   public class PlanWorkingStatusVo : ValueObject
    {
        public int PlanId { get; set; }
        public string PlanSection { get; set; }
        public DateTime DateTimeAdd { get; set; }
        public int TotalNo { get; set; }
        public int PlanNo { get; set; }
        public double Rate { get; set; }
        public string RegistrationUserCode { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string FactoryCode { get; set; }
        public int AffectedCount { get; set; }

        public List<PlanWorkingStatusVo> AssetListVo = new List<PlanWorkingStatusVo>();
    }
}
